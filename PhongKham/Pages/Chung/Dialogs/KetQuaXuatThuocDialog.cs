using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class KetQuaXuatThuocDialog : BaseDialog
{
    

    public KetQuaXuatThuocDialog()
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime();
    }
    private void InitializeRuntime()
    {
        Ui.ConfigureGridFormatting(_layout1_DataGridView);

    }


    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}