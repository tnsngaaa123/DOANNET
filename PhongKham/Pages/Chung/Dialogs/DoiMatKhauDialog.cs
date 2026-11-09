using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed class DoiMatKhauDialog : BaseDialog
{
    public DoiMatKhauDialog()
    {
        Text="Đổi mật khẩu";ClientSize=new Size(900,620);
        OkButton.Text="Đóng";CancelAction.Visible=false;
    }

}