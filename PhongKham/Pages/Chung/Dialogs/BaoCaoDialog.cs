using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Core;
using PhongKham.Models.Views;
using PhongKham.Printing;
using PhongKham.Services;

namespace PhongKham.Pages.Chung.Dialogs;

public sealed partial class BaoCaoDialog : BaseDialog
{
    public BaoCaoDialog()
    {
        InitializeComponent();
        if (DesignTimeSupport.IsDesignMode(this)) return;
        Ui.Choices(_kind, (nameof(KyBaoCao.Ngay), "Theo ngày"));
        SetDate(DateTime.Today);
        _kind.SelectedIndexChanged += (_, _) => UpdateFields();
        UpdateFields();
    }

    public BaoCaoDialog(DateTime day) : this()
    {
        if (!DesignTimeSupport.IsDesignMode(this)) SetDate(day);
    }

    private void SetDate(DateTime day)
    {
        _day.Value = day;
        _year.Value = day.Year;
        _month.Value = day.Month;
        _quarter.Value = (day.Month - 1) / 3 + 1;
    }

    private void UpdateFields()
    {
        string kind = Ui.Value(_kind);
        _form.SuspendLayout();
        ShowRow(1, _fieldLabel1, _day, kind == nameof(KyBaoCao.Ngay));
        ShowRow(2, _fieldLabel2, _year, kind != nameof(KyBaoCao.Ngay));
        ShowRow(3, _fieldLabel3, _month, kind == nameof(KyBaoCao.Thang));
        ShowRow(4, _fieldLabel4, _quarter, kind == nameof(KyBaoCao.Quy));
        _form.ResumeLayout(true);
    }

    private void ShowRow(int row, Control label, Control input, bool visible)
    {
        label.Visible = input.Visible = visible;
        input.Enabled = visible;
        _form.RowStyles[row].SizeType = visible ? SizeType.AutoSize : SizeType.Absolute;
        _form.RowStyles[row].Height = 0;
    }

    protected override bool ValidateAndSave()
    {
        var kind = Enum.Parse<KyBaoCao>(Ui.Value(_kind));
        var day = kind == KyBaoCao.Ngay ? _day.Value.Date : DateTime.Today;
        var data = BaoCaoService.Get(kind, day, (int)_year.Value, (int)_month.Value, (int)_quarter.Value);
        return Ui.PrintAndArchive(new BaoCaoPrintDocument(data));
    }

    private void OkButton_Click(object? sender, EventArgs e) => SaveAndClose();
}
    