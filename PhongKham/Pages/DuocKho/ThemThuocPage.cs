using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.ThemThuoc, "Thêm thuốc", PageGroups.DuocKho, 25, Roles.DuocSi)]
public sealed class ThemThuocPage : BasePage
{
    protected override void BuildUI()
    {
        Content.Controls.Add(new Label { Text="Thêm thuốc",Dock=DockStyle.Top,Height=100,Font=Theme.TitleFont });
    }
}