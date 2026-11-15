using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Pages.Auth;

[PageInfo(PageKeys.DangNhap, "Đăng nhập", "", 0, ShowInMenu = false)]
public sealed partial class DangNhapForm : BaseForm
{
    
    
    
    public DangNhapForm()
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime();
    }
    private void InitializeRuntime()
    {

        Ui.Choices(_layout11_role,Roles.All.Select(r=>(r,Roles.TenHienThi(r))).ToArray());
        Shown += (_, _) => _login.Focus();
    }

    private void _layout14_OnClick(object? sender, EventArgs e)
    {
        Ui.Run(() => { Session.Start(new NguoiDung { Id=0,TenDangNhap="giaodien",HoTen="",VaiTro=Ui.Value(_layout11_role),TrangThai=true }); DialogResult = DialogResult.OK; Close(); });
    }
    private void _layout17_OnLinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        Close();
    }
}