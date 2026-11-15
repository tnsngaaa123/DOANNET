using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class TaoHoSoDialog : BaseDialog
{
    
    public string HoTen=>_name.Text;
    public string CanCuoc=>_cccd.Text;
    
    protected override bool ValidateAndSave(){MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");return false;}
    public TaoHoSoDialog()
    {
        InitializeComponent();
    }
    public TaoHoSoDialog(bool reception)
    {

        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime(reception);
    }
    private void InitializeRuntime(bool reception)
    {

        _layout4_DateTimePicker.Value = DateTime.Today.AddYears(-30);
    }


    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}