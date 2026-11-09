namespace PhongKham.Pages.BacSi;

using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.KeDon, "Kê đơn", PageGroups.DangKham, 30, Roles.BacSi)]
public sealed class KeDonPage : BasePage
{
    protected override void BuildUI()
    {
        Content.Controls.Add(new Label { Text="Kê đơn",Dock=DockStyle.Top,Height=100,Font=Theme.TitleFont });
    }
}
