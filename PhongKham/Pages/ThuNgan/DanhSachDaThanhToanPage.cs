using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;
using PhongKham.Pages.Chung.Dialogs;

namespace PhongKham.Pages.ThuNgan;
[PageInfo(PageKeys.DaThanhToan, "Danh sách bệnh nhân đã thanh toán", PageGroups.ThuNgan, 20, Roles.ThuNgan)]
public sealed partial class DanhSachDaThanhToanPage : BasePage
{
    private List<ThanhToanRow> _rows = new();
    private string _appliedFilter = "";
    protected override void OnPageShown() => Execute(Find);
    private void Find()
    {
        _rows = ThanhToanService.Paid(_allDays.Checked ? null : _day.Value.Date, Ui.Value(_method), _search.Text.Trim());
        _appliedFilter = (_allDays.Checked ? "Tất cả ngày" : "Ngày " + _day.Value.ToString("dd/MM/yyyy")) + " · " + _method.Text + " · Từ khóa: " + _search.Text.Trim();
        Ui.Bind(_grid, _rows);
    }

    public DanhSachDaThanhToanPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _layout10_Button.Enabled=false;
        _day.Value = DateTime.Today;
        _allDays.CheckedChanged += (_, _) => _day.Enabled = !_allDays.Checked;
        Ui.Choices(_method, ("", "Tất cả hình thức"), (TrangThai.TienMat, "Tiền mặt"), (TrangThai.ChuyenKhoan, "Chuyển khoản"));
        Ui.RowAction<ThanhToanRow>(_grid, "xem", "👁", x =>
        {
            using var d = new ChiTietThanhToanDialog(x.Id);
            d.ShowDialog(this);
        });
    }

    private void _layout9_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Find);
    }

    private void _layout10_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => Ui.PrintList("Danh sách bệnh nhân đã thanh toán", new[] { "Mã biên lai", "Bệnh nhân", "CCCD", "Ngày thanh toán", "Tiền khám", "Tiền thuốc", "Giảm giá", "Tổng thanh toán" }, _rows.Select(x => new[] { x.MaHoaDon, x.HoTen, x.CanCuocCongDan, x.NgayThanhToan.ToString("dd/MM/yyyy HH:mm"), Formatters.Tien(x.HoaDon.TienKham), Formatters.Tien(x.HoaDon.TienThuoc), Formatters.Tien(x.HoaDon.GiamGia), Formatters.Tien(x.HoaDon.TongThu) }), _appliedFilter));
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
