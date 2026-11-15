using PhongKham.Controls;
namespace PhongKham.Pages.Chung;
public sealed partial class LichSuKhamPanel : UserControl
{
    
    public LichSuKhamPanel()
    {
        InitializeComponent();
    }
    public LichSuKhamPanel(int patient)
    {

        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime(patient);
    }
    private void InitializeRuntime(int patient)
    {
        Ui.ConfigureGridFormatting(_layout1_DataGridView);

    }


    public void LoadPatient(int patient) { }
}