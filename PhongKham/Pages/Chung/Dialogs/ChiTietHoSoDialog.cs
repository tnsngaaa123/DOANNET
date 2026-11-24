using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class ChiTietHoSoDialog : BaseDialog
{
    public ChiTietHoSoDialog()
    {
        InitializeComponent();
    }

    public ChiTietHoSoDialog(int patient)
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this))
            InitializeRuntime(patient);
    }

    private void InitializeRuntime(int patient)
    {
        var x = BenhNhanService.Get(patient);
        this.Text = "Chi tiết hồ sơ — " + x.HoTen;
        _profileValue0.Text = x.MaBenhNhan;
        _profileValue1.Text = x.CanCuocCongDan;
        _profileValue2.Text = x.HoTen;
        _profileValue3.Text = Formatters.Ngay(x.NgaySinh);
        _profileValue4.Text = TrangThai.TenHienThi(x.GioiTinh);
        _profileValue5.Text = x.SoDienThoai;
        _profileValue6.Text = x.DiaChi;
        _profileValue7.Text = x.TienSuBenh;
        _profileValue8.Text = x.DiUng;
        _layout6_LichSuKhamPanel.LoadPatient(patient);
    }
    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}