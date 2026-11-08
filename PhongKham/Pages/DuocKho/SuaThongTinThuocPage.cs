using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.SuaThongTinThuoc, "Sửa thông tin thuốc", PageGroups.DuocKho, 26, Roles.DuocSi)]
public sealed class SuaThongTinThuocPage : BasePage
{
    protected override void BuildUI()
    {
        Content.Controls.Add(new Label { Text="Sửa thông tin thuốc",Dock=DockStyle.Top,Height=100,Font=Theme.TitleFont });
    }
}