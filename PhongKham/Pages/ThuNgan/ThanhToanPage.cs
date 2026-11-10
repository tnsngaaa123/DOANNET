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
        var form=Ui.Form();
        Ui.Field(form,"Bệnh nhân",new Label { Text="Bệnh nhân minh họa 1",AutoSize=true });
        Ui.Field(form,"Tiền khám",new Label { Text="150.000 đ",AutoSize=true });
        Ui.Field(form,"Tiền thuốc",new Label { Text="150.000 đ",AutoSize=true });
        Ui.Field(form,"Tổng thanh toán",new Label { Text="150.000 đ",AutoSize=true });
        Ui.Field(form,"Khách đưa",Ui.Number());var method=Ui.Combo();method.Items.AddRange(new object[]{"Tiền mặt","Chuyển khoản"});method.SelectedIndex=0;Ui.Field(form,"Hình thức",method);Content.Controls.Add(Ui.Scroll(form));Footer.Visible=true;Footer.FlowDirection=FlowDirection.RightToLeft;
        Ui.Button(Footer,"Thanh toán và in biên lai",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);
    }
}