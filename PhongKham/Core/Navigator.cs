using System.Reflection;
using PhongKham.Base;

namespace PhongKham.Core;

public static class Navigator
{
    public sealed record Entry(Type PageType, PageInfoAttribute Info);
    private static List<Entry> _entries = new();
    private static Panel? _host;
    private static BasePage? _current;
    private static Action<PageInfoAttribute>? _changed;
    private static readonly HashSet<BaseForm> Forms = new();
    public static IReadOnlyList<Entry> RegisteredPages => _entries.AsReadOnly();

    public static void Initialize(Assembly assembly)
    {
        if (_host is not null)
            throw new InvalidOperationException("Detach trước khi đăng ký lại.");
        var entries = new List<Entry>();
        foreach (var type in assembly.GetTypes().Where(x => !x.IsAbstract))
        {
            var info = type.GetCustomAttribute<PageInfoAttribute>();
            if (info is null)
                continue;
            if ((!typeof(BasePage).IsAssignableFrom(type) && !typeof(BaseForm).IsAssignableFrom(type)) || type.GetConstructor(Type.EmptyTypes) is null)
                throw new InvalidOperationException("PageInfo cần BasePage/BaseForm và constructor không tham số.");
            entries.Add(new Entry(type, info));
        }

        if (entries.GroupBy(x => x.Info.Key).Any(g => g.Count() > 1))
            throw new InvalidOperationException("Trùng khóa màn hình.");
        _entries = entries.OrderBy(x => PageGroups.OrderOf(x.Info.Group)).ThenBy(x => x.Info.Order).ToList();
    }

    public static void Attach(Panel host, Action<PageInfoAttribute> changed)
    {
        if (_host is not null)
            throw new InvalidOperationException("Navigator đã gắn vùng nội dung.");
        _host = host;
        _changed = changed;
    }

    public static bool CanOpen(PageInfoAttribute info) => info.Key == PageKeys.DangNhap ? !Session.IsAuthenticated : Session.HasRole(info.Roles);
    private static Entry? Resolve(string key)
    {
        var e = _entries.FirstOrDefault(x => x.Info.Key == key);
        if (e is null)
        {
            Dialogs.Warning("Màn hình chưa được đăng ký.");
            return null;
        }

        if (!CanOpen(e.Info))
        {
            Dialogs.Warning("Bạn không có quyền vào màn hình này.");
            return null;
        }

        return e;
    }

    public static bool CanLeave() => _current?.CanLeave() ?? true;
    public static bool Open(string key, object? args = null)
    {
        var e = Resolve(key);
        if (e is null)
            return false;
        if (typeof(BaseForm).IsAssignableFrom(e.PageType))
        {
            var f = (BaseForm)Activator.CreateInstance(e.PageType)!;
            f.SetArguments(args);
            Forms.Add(f);
            f.FormClosed += (_, _) => Forms.Remove(f);
            try
            {
                f.Show(_host?.FindForm());
            }
            catch
            {
                Forms.Remove(f);
                f.Dispose();
                throw;
            }

            return true;
        }

        if (_host is null)
            throw new InvalidOperationException("Chưa gắn MainForm.");
        if (!CanLeave())
            return false;
        var page = (BasePage)Activator.CreateInstance(e.PageType)!;
        try
        {
            page.Prepare(args);
        }
        catch
        {
            page.Dispose();
            throw;
        }

        Release();
        _current = page;
        _host.Controls.Add(page);
        try
        {
            page.ActivatePage();
            _changed?.Invoke(e.Info);
        }
        catch
        {
            Release();
            throw;
        }

        return true;
    }

    public static DialogResult OpenModal(string key, object? args = null, IWin32Window? owner = null)
    {
        var e = Resolve(key);
        if (e is null)
            return DialogResult.Cancel;
        if (!typeof(BaseForm).IsAssignableFrom(e.PageType))
            throw new InvalidOperationException("Modal cần BaseForm.");
        using var f = (BaseForm)Activator.CreateInstance(e.PageType)!;
        f.SetArguments(args);
        return f.ShowDialog(owner ?? _host?.FindForm());
    }

    private static void Release()
    {
        if (_current is null)
            return;
        _current.HidePage();
        _host?.Controls.Remove(_current);
        _current.Dispose();
        _current = null;
    }

    public static void Detach()
    {
        Release();
        foreach (var f in Forms.ToArray())
            f.Close();
        Forms.Clear();
        _host = null;
        _changed = null;
    }
}
