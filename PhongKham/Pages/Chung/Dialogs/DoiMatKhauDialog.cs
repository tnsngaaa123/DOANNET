using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class DoiMatKhauDialog : BaseDialog
{
    protected override bool ValidateAndSave()
    {
        AuthService.ChangePassword(_old.Text, _next.Text, _confirm.Text);
        AppDialogs.Info("Đã đổi mật khẩu.");
        return true;
    }

    public DoiMatKhauDialog()
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this))
            InitializeRuntime();
    }

    private void InitializeRuntime()
    {
        foreach (var t in new[]
                 {
                     _old,
                     _next,
                     _confirm
                 }

                )
            t.UseSystemPasswordChar = true;
    }
    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}