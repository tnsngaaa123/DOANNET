using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class ChiTietThanhToanDialog : BaseDialog
{
    

    public ChiTietThanhToanDialog()
    {
        InitializeComponent();
    }
    public ChiTietThanhToanDialog(int bill)
    {

        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime(bill);
    }
    private void InitializeRuntime(int bill)
    {
        Ui.ConfigureGridFormatting(_layout26_grid);

    }


    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}