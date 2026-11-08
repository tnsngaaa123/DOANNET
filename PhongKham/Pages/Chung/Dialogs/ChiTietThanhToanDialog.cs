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
    }

}