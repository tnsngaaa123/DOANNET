namespace PhongKham.Pages.BacSi;

using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.PhieuKham, "Phiếu khám", PageGroups.DangKham, 20, Roles.BacSi)]
public sealed class PhieuKhamPage : BasePage
{
    protected override void BuildUI()
    {
        Content.Controls.Add(new Label { Text="Phiếu khám",Dock=DockStyle.Top,Height=100,Font=Theme.TitleFont });
    }
}
