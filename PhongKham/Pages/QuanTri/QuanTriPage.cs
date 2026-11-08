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
        Content.Controls.Add(new Label { Text="Quản trị hệ thống",Dock=DockStyle.Top,Height=100,Font=Theme.TitleFont });
    }
}