using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.ThuocSapHetHang, "Thuốc sắp hết hàng", PageGroups.DuocKho, 40, Roles.DuocSi)]
public sealed partial class ThuocSapHetHangPage : BasePage
{
    private List<SoLuongThuocRow> _rows = new();
    private string _appliedFilter = "";
    protected override void OnPageShown() => Execute(Find);
    private void Find()
    {
        string value = Ui.Value(_filter);
        _rows = CanhBaoThuocService.SoLuong(_search.Text.Trim(), value == "" ? null : int.Parse(value));
        _appliedFilter = _filter.Text + " · Từ khóa: " + _search.Text.Trim();
        Ui.Bind(_grid, _rows);
    }

    public ThuocSapHetHangPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        Ui.Choices(_filter, ("", "Tất cả"), ("5000", "Danh sách thuốc có số lượng dưới 5000"), ("3000", "Danh sách thuốc có số lượng dưới 3000"), ("1000", "Danh sách thuốc có số lượng dưới 1000"));
        _grid.RowPrePaint += (_, e) =>
        {
            if (_grid.Rows[e.RowIndex].DataBoundItem is SoLuongThuocRow x)
                _grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Ui.WarningColor(CanhBaoThuocService.MauSoLuong(x.SoLuongCon));
        };
    }

    private void _layout4_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Find);
    }

    private void _layout5_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => Ui.PrintList("Danh sách số lượng thuốc", new[] { "Tên", "ĐVT", "Số lượng còn lại" }, _rows.Select(x => new[] { x.TenThuoc, x.DonViTinh, x.SoLuongCon.ToString() }), _appliedFilter));
    }

    private void _layout6_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Execute(Find);
            e.SuppressKeyPress = true;
        }
    }
}