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
        var form=Ui.Form();Ui.Field(form,"Mật khẩu hiện tại",new TextBox { UseSystemPasswordChar=true });Ui.Field(form,"Mật khẩu mới",new TextBox { UseSystemPasswordChar=true });Ui.Field(form,"Nhập lại",new TextBox { UseSystemPasswordChar=true });Content.Controls.Add(Ui.Scroll(form));

    }

}