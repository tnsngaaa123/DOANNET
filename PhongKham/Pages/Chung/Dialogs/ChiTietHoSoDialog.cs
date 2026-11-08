namespace PhongKham.Pages.Chung.Dialogs;

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
    }

}
