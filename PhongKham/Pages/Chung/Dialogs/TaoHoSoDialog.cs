using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed class TaoHoSoDialog : BaseDialog
{
    private readonly TextBox _name=Ui.Text(),_cccd=Ui.Text();
    public string HoTen=>_name.Text;
    public string CanCuoc=>_cccd.Text;
    public TaoHoSoDialog(bool reception)
    {
        Text="Tạo hồ sơ bệnh nhân";ClientSize=new Size(900,620);
        OkButton.Text="Lưu hồ sơ";var form=Ui.Form();_cccd.MaxLength=12;Ui.Field(form,"CCCD 12 số *",_cccd);Ui.Field(form,"Họ tên *",_name);Ui.Field(form,"Ngày sinh",Ui.Date(DateTime.Today.AddYears(-30)));
        Ui.Field(form,"Giới tính",Ui.Text());
        Ui.Field(form,"Điện thoại",Ui.Text());
        Ui.Field(form,"Địa chỉ",Ui.Text());
        Ui.Field(form,"Tiền sử bệnh",Ui.Text());
        Ui.Field(form,"Dị ứng",Ui.Text());
        Ui.Field(form,"Bác sĩ",Ui.Text());
        Content.Controls.Add(Ui.Scroll(form));

    }
    protected override bool ValidateAndSave(){MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");return false;}
}