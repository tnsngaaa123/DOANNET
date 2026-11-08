namespace PhongKham.Pages.Chung.Dialogs;

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
    }

}
