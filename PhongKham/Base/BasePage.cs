using System.Reflection;
using PhongKham.Core;
using PhongKham.Controls;
using Timer = System.Windows.Forms.Timer;

namespace PhongKham.Base;

public abstract class BasePage : UserControl
{
    protected FlowLayoutPanel Toolbar
    {
        get;
    } = new()
    {
        Dock = DockStyle.Top,
        Height = 56,
        AutoScroll = true,
        WrapContents = false,
        Padding = new Padding(12, 5, 12, 5),
        BackColor = Theme.Surface
    };
    protected Panel Content
    {
        get;
    } = new()
    {
        Dock = DockStyle.Fill,
        Padding = new Padding(12)
    };
    protected FlowLayoutPanel Footer
    {
        get;
    } = new()
    {
        Dock = DockStyle.Bottom,
        Height = 64,
        Padding = new Padding(12, 6, 12, 6),
        AutoScroll = true,
        WrapContents = false,
        Visible = false
    };

    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public object? Args
    {
        get; private set;
    }

    private readonly List<Timer> _timers = new();
    public event EventHandler? RefreshRequested, SaveRequested;
    protected BasePage()
    {
        Dock = DockStyle.Fill;
        Font = Theme.BodyFont;
        BackColor = Theme.Background;
        var title = new Label
        {
            Text = GetType().GetCustomAttribute<PageInfoAttribute>()?.Title ?? "",
            Dock = DockStyle.Top,
            Height = 58,
            Font = Theme.TitleFont,
            Padding = new Padding(16, 10, 0, 0)
        };
        Controls.Add(Content);
        Controls.Add(Toolbar);
        Controls.Add(title);
        Controls.Add(Footer);
    }

    internal void Prepare(object? args)
    {
        Args = args;
        BuildUI();
    }

    internal void ActivatePage() => OnPageShown();
    internal void HidePage()
    {
        foreach (var t in _timers)
            t.Stop();
        OnPageHidden();
    }

    protected abstract void BuildUI();
    protected virtual void OnPageShown()
    {
    }

    protected virtual void OnPageHidden()
    {
    }

    public virtual bool CanLeave() => true;
    protected void Execute(Action action) => Ui.Run(action);
    protected Timer RegisterTimer(int interval, EventHandler tick, bool start = true)
    {
        var t = new Timer
        {
            Interval = interval
        };
        t.Tick += tick;
        _timers.Add(t);
        if (start)
            t.Start();
        return t;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        EventHandler? handler = keyData switch
        {
            Keys.F5 => RefreshRequested,
            Keys.Control | Keys.S => SaveRequested,
            _ => null
        };
        if (handler is null)
            return base.ProcessCmdKey(ref msg, keyData);
        Ui.Run(() => handler(this, EventArgs.Empty));
        return true;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            foreach (var t in _timers)
                t.Dispose();
            _timers.Clear();
        }

        base.Dispose(disposing);
    }
}
