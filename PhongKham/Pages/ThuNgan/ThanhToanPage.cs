using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;

namespace PhongKham.Pages.ThuNgan;
[PageInfo(PageKeys.ThanhToan, "Thanh toán", PageGroups.ThuNgan, 20, Roles.ThuNgan, ShowInMenu = false)]
public sealed partial class ThanhToanPage : BasePage
{
    private int _id;
    private long _drugs;
    private bool _ready;
    private void Calculate()
    {
        long gross = checked((long)_fee.Value + _drugs);
        var t = ThanhToanService.Calculate((long)_fee.Value, _drugs, _discount.Value, _percent.Checked, Ui.Value(_method), Math.Max(gross, (long)_given.Value));
        long difference = (long)_given.Value - t.TongThu;
        _summary.Text = "Tiền khám: " + Formatters.Tien(t.TienKham) + Environment.NewLine + "Tiền thuốc: " + Formatters.Tien(t.TienThuoc) + Environment.NewLine + "Giảm giá: " + Formatters.Tien(t.GiamGia) + Environment.NewLine + "TỔNG CẦN THU: " + Formatters.Tien(t.TongThu) + (Ui.Value(_method) == TrangThai.TienMat ? Environment.NewLine + (difference < 0 ? "Còn thiếu: " : "Tiền thừa: ") + Formatters.Tien(Math.Abs(difference)) : "");
    }

    private void Pay()
    {
        var total = ThanhToanService.Calculate((long)_fee.Value, _drugs, _discount.Value, _percent.Checked, Ui.Value(_method), (long)_given.Value);
        if (!AppDialogs.Confirm("Đã nhận đủ " + Formatters.Tien(total.TongThu) + " gồm tiền khám và tiền thuốc?"))
            return;
        int bill = ThanhToanService.Pay(_id, (long)_fee.Value, _discount.Value, _percent.Checked, Ui.Value(_method), (long)_given.Value);

        Navigator.Open(PageKeys.ChoThanhToan);
    }

    public ThanhToanPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _id = (Args as LuotKhamArgs)?.PhieuKhamId ?? throw new NghiepVuException("Thiếu lượt thanh toán.");
        var d = ThanhToanService.VisitDetail(_id);
        if (d.Phieu.TrangThai != TrangThai.ChoThanhToan)
            throw new NghiepVuException("Bệnh nhân không còn chờ thanh toán.");
        Ui.Choices(_method, (TrangThai.TienMat, "Tiền mặt"), (TrangThai.ChuyenKhoan, "Chuyển khoản"));
        _percent.CheckedChanged += (_, _) =>
        {
            _discount.Maximum = _percent.Checked ? 100 : 9000000000000000;
            if (_ready)
                Execute(Calculate);
        };
        _method.SelectedIndexChanged += (_, _) =>
        {
            _given.Enabled = Ui.Value(_method) == TrangThai.TienMat;
            if (_ready)
                Execute(Calculate);
        };
        foreach (var n in new[]
        {
            _fee,
            _discount,
            _given
        }

        )
            n.ValueChanged += (_, _) =>
            {
                if (_ready)
                    Execute(Calculate);
            };
        _person.Text = d.BenhNhan.HoTen + Environment.NewLine + "CCCD: " + d.BenhNhan.CanCuocCongDan + Environment.NewLine + "Bác sĩ: " + d.TenBacSi;
        _drugs = d.CacThuoc.Sum(x => x.ThanhTien);
        Ui.Bind(_grid, d.CacThuoc);
        _fee.Value = CauHinhService.TienKham;
        _ready = true;
        Calculate();
    }

    private void _layout5_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Pay);
    }
}
