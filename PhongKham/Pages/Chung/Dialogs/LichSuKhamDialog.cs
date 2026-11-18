using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class LichSuKhamDialog : BaseDialog
{
    

    public LichSuKhamDialog()
    {
        InitializeComponent();
    }
    public LichSuKhamDialog(int patient)
    {

        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime(patient);
    }
    private void InitializeRuntime(int patient)
    {
        Ui.ConfigureGridFormatting(_layout1_DataGridView);

    }


    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}