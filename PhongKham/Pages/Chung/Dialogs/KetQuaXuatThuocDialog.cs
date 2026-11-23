using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class KetQuaXuatThuocDialog : BaseDialog
{
    public KetQuaXuatThuocDialog()
    {
        InitializeComponent();
    }

    public KetQuaXuatThuocDialog(string patient, IEnumerable<KetQuaXuatThuocRow> rows)
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this))
            InitializeRuntime(patient, rows);
    }

    private void InitializeRuntime(string patient, IEnumerable<KetQuaXuatThuocRow> rows)
    {
        Ui.ConfigureGridFormatting(_layout1_grid);
        this.Text = "Đã xuất thuốc cho " + patient;
        Ui.Bind(_layout1_grid, rows);
    }
    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}