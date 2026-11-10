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
        var form=Ui.Form();
        Ui.Field(form,"Bệnh nhân",Ui.Text(true));
        Ui.Field(form,"Triệu chứng *",Ui.Text(true));
        Ui.Field(form,"Chẩn đoán *",Ui.Text(true));
        Ui.Field(form,"Kết quả khám",Ui.Text(true));
        Ui.Field(form,"Lời dặn",Ui.Text(true));
        Content.Controls.Add(Ui.Scroll(form));Footer.Visible=true;Footer.FlowDirection=FlowDirection.RightToLeft;
        Ui.Button(Toolbar,"Lịch sử khám trước đây",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        Ui.Button(Toolbar,"Xem đơn thuốc đang kê",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        Ui.Button(Footer,"Hoàn tất khám",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);
    }
}