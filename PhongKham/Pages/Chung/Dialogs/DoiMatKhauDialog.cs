using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class DoiMatKhauDialog : BaseDialog
{
    

    public DoiMatKhauDialog()
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime();
    }
    private void InitializeRuntime()
    {


    }


    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}