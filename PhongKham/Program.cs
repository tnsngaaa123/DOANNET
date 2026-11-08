using System.Globalization;
using PhongKham.Core;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham;
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        CultureInfo.DefaultThreadCurrentCulture=Formatters.Vietnamese;
        CultureInfo.DefaultThreadCurrentUICulture=Formatters.Vietnamese;
        ApplicationConfiguration.Initialize();
        try
        {
            Navigator.Initialize(typeof(Program).Assembly);
            
            while(true)
            {
                Session.Clear();
                if(Navigator.OpenModal(PageKeys.DangNhap)!=DialogResult.OK)break;
                bool logout=false;
                using var form=new MainForm();
                form.LogoutRequested+=(_,_)=>{form.Close();logout=form.IsDisposed;};
                form.ChangePasswordRequested+=(_,_)=>{using var dialog=new DoiMatKhauDialog();dialog.ShowDialog(form);};
                Application.Run(form);
                Navigator.Detach();Session.Clear();
                if(!logout)break;
            }
        }
        catch(Exception error){MessageBox.Show(error.Message,"Phòng khám",MessageBoxButtons.OK,MessageBoxIcon.Error);}
        finally{Navigator.Detach();Session.Clear();}
    }
}