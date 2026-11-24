using PhongKham.Base;

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
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this))
            InitializeRuntime(patient);
    }

    private void InitializeRuntime(int patient)
    {
        _layout1_LichSuKhamPanel.LoadPatient(patient);
    }
    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}