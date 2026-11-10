using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed class ChiTietThanhToanDialog : BaseDialog
{
    public ChiTietThanhToanDialog(int bill)
    {
        Text="Chi tiết biên lai";ClientSize=new Size(900,620);
        OkButton.Text="Đóng";CancelAction.Visible=false;
        var tabs=new TabControl { Dock=DockStyle.Fill };var info=new TabPage("Chi tiết biên lai");var details=Ui.Form();
        Ui.Field(details,"Mã biên lai",new Label { Text="BL001",AutoSize=true });
        Ui.Field(details,"Bệnh nhân",new Label { Text="Bệnh nhân minh họa 1",AutoSize=true });
        Ui.Field(details,"CCCD",new Label { Text="000000000001",AutoSize=true });
        Ui.Field(details,"Ngày thanh toán",new Label { Text="08/11/2026",AutoSize=true });
        Ui.Field(details,"Tiền khám",new Label { Text="150.000 đ",AutoSize=true });
        Ui.Field(details,"Tiền thuốc",new Label { Text="20.000 đ",AutoSize=true });
        Ui.Field(details,"Giảm giá",new Label { Text="0 đ",AutoSize=true });
        Ui.Field(details,"Tổng thanh toán",new Label { Text="170.000 đ",AutoSize=true });
        Ui.Field(details,"Hình thức",new Label { Text="Tiền mặt",AutoSize=true });
        Ui.Field(details,"Khách đưa / Tiền thừa",new Label { Text="200.000 đ / 30.000 đ",AutoSize=true });
        info.Controls.Add(Ui.Scroll(details));var history=new TabPage("Lịch sử thanh toán");
        var grid=Ui.Grid(("c0","Mã biên lai"),("c1","Ngày thanh toán"),("c2","Tiền khám"),("c3","Tiền thuốc"),("c4","Tổng thanh toán"));history.Controls.Add(grid);tabs.TabPages.Add(info);tabs.TabPages.Add(history);Content.Controls.Add(tabs);
    }

}