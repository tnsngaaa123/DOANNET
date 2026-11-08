using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.ThuNgan;
[PageInfo(PageKeys.ThanhToan, "Thanh toán", PageGroups.ThuNgan, 20, Roles.ThuNgan)]
public sealed class ThanhToanPage : BasePage
{
    protected override void BuildUI()
    {
        Content.Controls.Add(new Label { Text="Thanh toán",Dock=DockStyle.Top,Height=100,Font=Theme.TitleFont });
    }
}