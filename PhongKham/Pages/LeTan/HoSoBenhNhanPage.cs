using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Core;
using PhongKham.Models;
using PhongKham.Pages.Chung.Dialogs;
using PhongKham.Services;

namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.HoSoBenhNhan, "Hồ sơ bệnh nhân", PageGroups.TiepNhan, 30, Roles.LeTan, Roles.BacSi)]
public sealed partial class HoSoBenhNhanPage : BasePage
{
    protected override void OnPageShown() => Execute(Find);
    private void Find()
    {
        var rows = BenhNhanService.List(_search.Text.Trim(), _allDays.Checked ? null : _from.Value.Date, _allDays.Checked ? null : _to.Value.Date);
        Ui.Bind(_grid, rows);
        _count.Text = $"Tổng số hồ sơ: {rows.Count} · " + (_allDays.Checked ? "Từ trước đến nay" : $"Ngày tạo {_from.Value:dd/MM/yyyy} – {_to.Value:dd/MM/yyyy}");
    }

    public HoSoBenhNhanPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _from.Value = DateTime.Today.AddMonths(-1);
        _to.Value = DateTime.Today;
        _layout10_create.Visible = Session.HasRole(Roles.LeTan);
        _allDays.CheckedChanged += (_, _) => _from.Enabled = _to.Enabled = !_allDays.Checked;
        Ui.RowAction<BenhNhan>(_grid, "xem", "👁", patient =>
        {
            using var detail = new ChiTietHoSoDialog(patient.Id);
            detail.ShowDialog(this);
        });
    }

    private void _layout9_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Find);
    }

    private void _layout10_create_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            using var dialog = new TaoHoSoDialog(false);
            if (dialog.ShowDialog(this) == DialogResult.OK)
                Find();
        });
    }

    private void _layout11_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Execute(Find);
            e.SuppressKeyPress = true;
        }
    }
}