using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed class ChiTietHoSoDialog : BaseDialog
{
    public ChiTietHoSoDialog(int patient)
    {
        Text="Chi tiết hồ sơ bệnh nhân";ClientSize=new Size(900,620);
        OkButton.Text="Đóng";CancelAction.Visible=false;
        var tabs=new TabControl { Dock=DockStyle.Fill };var info=new TabPage("Thông tin hồ sơ");var details=Ui.Form();
        Ui.Field(details,"Mã hồ sơ",new Label { Text="HS001",AutoSize=true });
        Ui.Field(details,"CCCD",new Label { Text="000000000001",AutoSize=true });
        Ui.Field(details,"Họ tên",new Label { Text="Bệnh nhân minh họa 1",AutoSize=true });
        Ui.Field(details,"Ngày sinh",new Label { Text="01/01/1995",AutoSize=true });
        Ui.Field(details,"Giới tính",new Label { Text="Nam",AutoSize=true });
        Ui.Field(details,"Điện thoại",new Label { Text="0900000000",AutoSize=true });
        Ui.Field(details,"Địa chỉ",new Label { Text="TP. Hồ Chí Minh",AutoSize=true });
        Ui.Field(details,"Tiền sử bệnh",new Label { Text="Không",AutoSize=true });
        Ui.Field(details,"Dị ứng",new Label { Text="Không",AutoSize=true });
        info.Controls.Add(Ui.Scroll(details));var history=new TabPage("Lịch sử khám và đơn thuốc cũ");
        var grid=Ui.Grid(("c0","Ngày khám"),("c1","Triệu chứng"),("c2","Chẩn đoán"),("c3","Kết quả"),("c4","Lời dặn"),("c5","Đơn thuốc cũ"));history.Controls.Add(grid);tabs.TabPages.Add(info);tabs.TabPages.Add(history);Content.Controls.Add(tabs);
    }

}