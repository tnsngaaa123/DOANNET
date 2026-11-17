using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Core;
using PhongKham.Services;

namespace PhongKham.Pages.Auth;
[PageInfo(PageKeys.DangNhap, "Đăng nhập", "", 0, ShowInMenu = false)]
public sealed partial class DangNhapForm : BaseForm
{
    public DangNhapForm()
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this))
            InitializeRuntime();
    }

    private void InitializeRuntime()
    {
        Shown += (_, _) => _login.Focus();
    }

    private void _layout12_OnClick(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            AuthService.Login(_login.Text, _password.Text);
            DialogResult = DialogResult.OK;
            Close();
        });
    }

    private void _layout15_OnLinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        Close();
    }
}