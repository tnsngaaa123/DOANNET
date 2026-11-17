using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class ChiTietHoSoDialog : BaseDialog
{
    

    public ChiTietHoSoDialog()
    {
        InitializeComponent();
    }
    public ChiTietHoSoDialog(int patient)
    {

        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime(patient);
    }
    private void InitializeRuntime(int patient)
    {
        Ui.ConfigureGridFormatting(_layout24_grid);

    }


    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}