using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;
using PhongKham.Pages.Chung.Dialogs;

namespace PhongKham.Pages.Auth;

[PageInfo(PageKeys.TrangChu, "Trang chủ", PageGroups.TongQuan, 0)]
public sealed partial class TrangChuPage : BasePage
{
    private DateTime _appliedDay = DateTime.Today;
    public TrangChuPage() { InitializeComponent(); }
    protected override void OnPageShown() => Execute(UpdateData);

    protected override void BuildUI()
    {
        _selectedDay.Value = DateTime.Today;
        _layout1_Button.Visible = !Session.IsAdmin;
        _printReport.Visible = Session.HasRole(Roles.LeTan, Roles.ThuNgan);
        RegisterTimer(1000, (_, _) => Execute(UpdateData));
    }

    private void UpdateData()
    {
        DateTime day = _appliedDay;
        var data = DashboardService.Get(day);
        _patients.Caption = day == DateTime.Today ? "Lượt khám hôm nay" : "Lượt khám ngày " + day.ToString("dd/MM/yyyy");
        _revenue.Caption = day == DateTime.Today ? "Doanh thu hôm nay" : "Doanh thu ngày " + day.ToString("dd/MM/yyyy");
        _patients.Set(data.LuotKhamHomNay.ToString());
        _revenue.Set(Formatters.Tien(data.DoanhThuHomNay));
        _countChart.SetData(data.BayNgay.Select(d => (d.Ngay.ToString("dd/MM"), (decimal)d.SoLuot)));
        _moneyChart.SetData(data.BayNgay.Select(d => (d.Ngay.ToString("dd/MM"), (decimal)d.DoanhThu)));
        var needed = new Size(2 * Math.Max(_countChart.MinimumSize.Width, _moneyChart.MinimumSize.Width) + 24, Math.Max(_countChart.MinimumSize.Height, _moneyChart.MinimumSize.Height) + 16);
        if (_charts.MinimumSize != needed) _charts.MinimumSize = needed;
        if (_chartScroll.AutoScrollMinSize != needed) _chartScroll.AutoScrollMinSize = needed;
    }

    private void _printReport_Click(object? sender, EventArgs e) => Ui.Run(() =>
    {
        using var dialog = new BaoCaoDialog(_appliedDay);
        dialog.ShowDialog(this);
    });

    private void _view_Click(object? sender, EventArgs e) => Ui.Run(() =>
    {
        _appliedDay = _selectedDay.Value.Date;
        UpdateData();
    });

    private void _selectedDay_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        e.SuppressKeyPress = true;
        _view_Click(sender, EventArgs.Empty);
    }

    private void _layout1_Button_Click(object? sender, EventArgs e) => Ui.Run(() => Navigator.Open(Session.CurrentUser?.VaiTro switch
    {
        Roles.BacSi => PageKeys.DsChoKham,
        Roles.ThuNgan => PageKeys.ChoThanhToan,
        Roles.DuocSi => PageKeys.XuatThuoc,
        _ => PageKeys.TiepNhan
    }));
}
    