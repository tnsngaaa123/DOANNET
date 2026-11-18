using System.Globalization;
using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Pages.Chung.Dialogs;

namespace PhongKham;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        CultureInfo.DefaultThreadCurrentCulture = Formatters.Vietnamese;
        CultureInfo.DefaultThreadCurrentUICulture = Formatters.Vietnamese;
        ApplicationConfiguration.Initialize();
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => HandleError(e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (_, e) => Log(e.ExceptionObject as Exception ?? new Exception("Lỗi chưa xác định"));
        try
        {
            Navigator.Initialize(typeof(Program).Assembly);
            DbInitializer.Initialize();
            while (true)
            {
                Session.Clear();
                if (Navigator.OpenModal(PageKeys.DangNhap) != DialogResult.OK)
                    break;
                bool logout = false;
                using var form = new MainForm();
                form.LogoutRequested += (_, _) =>
                {
                    form.Close();
                    logout = form.IsDisposed;
                };
                form.ChangePasswordRequested += (_, _) =>
                {
                    using var d = new DoiMatKhauDialog();
                    d.ShowDialog(form);
                };
                Application.Run(form);
                Navigator.Detach();
                Session.Clear();
                if (!logout)
                    break;
            }
        }
        catch (NghiepVuException e)
        {
            Dialogs.Warning(e.Message);
        }
        catch (Exception e)
        {
            HandleError(e);
        }
        finally
        {
            Navigator.Detach();
            Session.Clear();
        }
    }

    private static void HandleError(Exception error)
    {
        if (error is NghiepVuException)
        {
            Dialogs.Warning(error.Message);
            return;
        }

        string? path = Log(error);
        Dialogs.Error("Ứng dụng gặp lỗi và cần đóng.\n" + (path is null ? "Không ghi được nhật ký." : "Nhật ký: " + path));
        Application.Exit();
    }

    internal static string? Log(Exception error)
    {
        try
        {
            Directory.CreateDirectory(AppPaths.LogDirectory);
            string p = Path.Combine(AppPaths.LogDirectory, "errors-" + DateTime.Today.ToString("yyyy-MM-dd") + ".log");
            File.AppendAllText(p, DateTime.Now.ToString("O") + "\n" + error + "\n");
            return p;
        }
        catch (IOException)
        {
            return null;
        }
        catch (UnauthorizedAccessException)
        {
            return null;
        }
    }
}
