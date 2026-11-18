using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.ThuocSapHetHan, "Thuốc sắp hết hạn", PageGroups.DuocKho, 30, Roles.DuocSi)]
public sealed partial class ThuocSapHetHanPage : BasePage
{
    private List<HanDungRow> _rows = new();
    private string _appliedFilter = "";
    protected override void OnPageShown() => Execute(Find);
    private void Find()
    {
        var filter = Enum.Parse<LocHanDung>(Ui.Value(_filter));
        _rows = CanhBaoThuocService.HanDung(_search.Text.Trim(), filter);
        _appliedFilter = Convert.ToString(_filter.Text) + " · Từ khóa: " + _search.Text.Trim();
        Ui.Bind(_grid, _rows);
    }

    public ThuocSapHetHanPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _layout7_Button.Enabled=false;
        Ui.Choices(_filter, (nameof(LocHanDung.TatCa), "Tất cả"), (nameof(LocHanDung.DaHetHan), "Thuốc đã hết hạn"), (nameof(LocHanDung.DuoiBaThang), "Thuốc còn hạn dưới 3 tháng"), (nameof(LocHanDung.DuoiSauThang), "Thuốc còn hạn dưới 6 tháng"));
        _grid.RowPrePaint += (_, e) =>
        {
            if (_grid.Rows[e.RowIndex].DataBoundItem is HanDungRow x)
                _grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Ui.WarningColor(CanhBaoThuocService.MauHanDung(x.HanSuDung));
        };
    }

    private void _layout6_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Find);
    }

    private void _layout7_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => Ui.PrintList("Thuốc theo hạn sử dụng", new[] { "Tên thuốc", "Nhóm", "ĐVT", "Hạn sử dụng", "Số lượng đã hết hạn", "Số lượng còn trong kho (bao gồm số thuốc hết hạn)", "Ngày còn lại" }, _rows.Select(x => new[] { x.TenThuoc, x.TenNhom, x.DonViTinh, Formatters.Ngay(x.HanSuDung), x.SoLuongDaHetHan.ToString(), x.SoLuongTon.ToString(), x.NgayConLai }), _appliedFilter));
    }

    private void _layout8_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Execute(Find);
            e.SuppressKeyPress = true;
        }
    }
}
