using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class ChiTietThanhToanDialog : BaseDialog
{
    private readonly int _patient;
    private int _bill;
    public ChiTietThanhToanDialog()
    {
        InitializeComponent();
        if (DesignTimeSupport.IsDesignMode(this))
            return;
        _exportReceipt.Enabled=false;
        Ui.ConfigureGridFormatting(_historyGrid);
        Ui.ConfigureGridFormatting(_medicines);
        Ui.RowAction<ThanhToanRow>(_historyGrid, "xem", "👁", row => ViewInvoice(row.Id));
    }

    public ChiTietThanhToanDialog(int bill) : this()
    {
        if (DesignTimeSupport.IsDesignMode(this))
            return;
        var initial = ThanhToanService.Detail(bill);
        _patient = initial.LuotKham.BenhNhan.Id;
        Ui.Bind(_historyGrid, ThanhToanService.History(_patient));
        ViewInvoice(bill);
    }

    public void ViewInvoice(int bill)
    {
        var detail = ThanhToanService.Detail(bill);
        if (detail.LuotKham.BenhNhan.Id != _patient)
            throw new NghiepVuException("Biên lai không thuộc bệnh nhân này.");
        var h = detail.HoaDon;
        _bill = bill;
        Text = "Chi tiết biên lai — " + h.MaHoaDon;
        _invoiceValue0.Text = h.MaHoaDon;
        _invoiceValue1.Text = detail.LuotKham.BenhNhan.HoTen;
        _invoiceValue2.Text = detail.LuotKham.BenhNhan.CanCuocCongDan;
        _invoiceValue3.Text = h.NgayThanhToan.ToString("dd/MM/yyyy HH:mm:ss");
        _invoiceValue4.Text = detail.TenNguoiThu;
        _invoiceValue5.Text = Formatters.Tien(h.TienKham);
        _invoiceValue6.Text = Formatters.Tien(h.TienThuoc);
        _invoiceValue7.Text = Formatters.Tien(h.GiamGia);
        _invoiceValue8.Text = Formatters.Tien(h.TongThu);
        _invoiceValue9.Text = TrangThai.TenHienThi(h.HinhThuc);
        _invoiceValue10.Text = Formatters.Tien(h.TienKhachDua) + " / " + Formatters.Tien(h.TienThua);
        Ui.Bind(_medicines, detail.LuotKham.CacThuoc);
        _invoiceScroll.AutoScrollPosition = Point.Empty;
        _tabs.SelectedTab = _invoice;
    }

    private void _exportReceipt_Click(object? sender, EventArgs e)
    {

}
    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}
