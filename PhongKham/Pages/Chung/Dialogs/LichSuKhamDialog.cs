using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed class LichSuKhamDialog : BaseDialog
{
    public LichSuKhamDialog(int patient)
    {
        Text="Lịch sử khám trước đây";ClientSize=new Size(900,620);
        OkButton.Text="Đóng";CancelAction.Visible=false;
        Content.Controls.Add(Ui.Grid(("c0","Ngày khám"),("c1","Triệu chứng"),("c2","Chẩn đoán"),("c3","Kết quả khám"),("c4","Lời dặn"),("c5","Đơn thuốc cũ")));
    }

}