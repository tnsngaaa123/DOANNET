using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;

namespace PhongKham.Pages.LeTan;

[PageInfo(PageKeys.PhongCho, "Phòng chờ", PageGroups.TiepNhan, 40, Roles.LeTan, Roles.BacSi, Roles.ThuNgan, Roles.DuocSi)]
public sealed partial class PhongChoForm : BaseForm
{
    private readonly System.Windows.Forms.Timer _timer = new() { Interval = 1000 };
    public PhongChoForm()
    {
        InitializeComponent();
        if (DesignTimeSupport.IsDesignMode(this)) return;
        Ui.ConfigureGridFormatting(_grid);
        Ui.ConfigureGridFormatting(_paymentGrid);
        Ui.ConfigureGridFormatting(_pickupGrid);
        _timer.Tick += (_, _) => Ui.Run(UpdateData);
        Shown += (_, _) =>
        {
            var second = Screen.AllScreens.FirstOrDefault(s => !s.Primary);
            if (second is not null)
            {
                StartPosition = FormStartPosition.Manual;
                Bounds = second.WorkingArea;
            }
            else WindowState = FormWindowState.Maximized;
            Ui.Run(UpdateData);
            _timer.Start();
        };
    }

    private void UpdateData()
    {
        var data = PhongChoService.Get();
        _number.Text = data.ChoKham.SoDangKham;
        _paymentNumber.Text = data.ChoThanhToan.SoDangKham;
        _pickupNumber.Text = data.ChoLayThuoc.SoDangKham;
        Ui.Bind(_grid, data.ChoKham.DangCho);
        Ui.Bind(_paymentGrid, data.ChoThanhToan.DangCho);
        Ui.Bind(_pickupGrid, data.ChoLayThuoc.DangCho);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) { _timer.Stop(); _timer.Dispose(); components?.Dispose(); }
        base.Dispose(disposing);
    }
}