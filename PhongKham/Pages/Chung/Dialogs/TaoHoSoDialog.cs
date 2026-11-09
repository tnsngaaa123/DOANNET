namespace PhongKham.Pages.Chung.Dialogs;

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
        OkButton.Text="Đóng";
    }
    protected override bool ValidateAndSave(){MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");return false;}
}
