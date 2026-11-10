using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.QuanTri;
[PageInfo(PageKeys.QuanTri, "Quản trị hệ thống", PageGroups.QuanTri, 10, Roles.Admin)]
public sealed class QuanTriPage : BasePage
{
    protected override void BuildUI()
    {
        var tabs=new TabControl { Dock=DockStyle.Fill };var users=new TabPage("Tài khoản");var cfg=new TabPage("Cấu hình phòng khám");var uf=Ui.Form();
        Ui.Field(uf,"Tài khoản",Ui.Text());
        Ui.Field(uf,"Họ tên",Ui.Text());
        Ui.Field(uf,"Vai trò",Ui.Text());
        Ui.Field(uf,"Mật khẩu",Ui.Text());
        users.Controls.Add(Ui.Scroll(uf));var cf=Ui.Form();
        Ui.Field(cf,"Tên phòng khám",Ui.Text());
        Ui.Field(cf,"Địa chỉ",Ui.Text());
        Ui.Field(cf,"Điện thoại",Ui.Text());
        Ui.Field(cf,"Phí khám mặc định",Ui.Text());
        cfg.Controls.Add(Ui.Scroll(cf));tabs.TabPages.Add(users);tabs.TabPages.Add(cfg);Content.Controls.Add(tabs);Ui.Button(Toolbar,"Lưu tài khoản",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});    }
}