using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models;
using PhongKham.Services;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class TaoHoSoDialog : BaseDialog
{
    private readonly bool _reception;
    private readonly System.Windows.Forms.Timer _timer = new()
    {
        Interval = 350
    };
    private bool _usingExisting;
    private void ResetPersonal()
    {
        _usingExisting = false;
        foreach (var c in new Control[]
        {
            _name,
            _phone,
            _address,
            _history,
            _allergy,
            _birth,
            _gender
        }

        )
            c.Enabled = true;
        _name.Clear();
        _phone.Clear();
        _address.Clear();
        _history.Clear();
        _allergy.Clear();
        _birth.Value = DateTime.Today.AddYears(-30);
    }

    private void Lookup()
    {
        var x = BenhNhanService.FindCanCuoc(_cccd.Text);
        if (x is null)
        {
            _lookup.Text = "CCCD chưa có trong hồ sơ phòng khám.";
            OkButton.Enabled = true;
            return;
        }

        if (!_reception)
        {
            _lookup.Text = "CCCD đã tồn tại. Không tạo hồ sơ trùng.";
            OkButton.Enabled = false;
            return;
        }

        _usingExisting = true;
        _name.Text = x.HoTen;
        _birth.Value = x.NgaySinh;
        Ui.Select(_gender, x.GioiTinh);
        _phone.Text = x.SoDienThoai;
        _address.Text = x.DiaChi;
        _history.Text = x.TienSuBenh;
        _allergy.Text = x.DiUng;
        foreach (var c in new Control[]
        {
            _name,
            _phone,
            _address,
            _history,
            _allergy,
            _birth,
            _gender
        }

        )
            c.Enabled = false;
        _lookup.Text = "Đã lấy hồ sơ cũ. Tiếp tục chọn bác sĩ, loại khám và ưu tiên.";
        OkButton.Enabled = true;
    }

    protected override bool ValidateAndSave()
    {
        _timer.Stop();
        var x = new BenhNhan
        {
            CanCuocCongDan = _cccd.Text.Trim(),
            HoTen = _name.Text,
            NgaySinh = _birth.Value.Date,
            GioiTinh = Ui.Value(_gender),
            SoDienThoai = _phone.Text,
            DiaChi = _address.Text,
            TienSuBenh = _history.Text,
            DiUng = _allergy.Text
        };
        if (_reception)
            TiepNhanService.Save(x, Ui.Id(_doctor), Ui.Value(_type), _priority.Checked);
        else
            BenhNhanService.Create(x);
        return true;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _timer.Dispose();
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    public TaoHoSoDialog()
    {
        InitializeComponent();
    }

    public TaoHoSoDialog(bool reception)
    {
        _reception = reception;
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this))
            InitializeRuntime(reception);
    }

    private void InitializeRuntime(bool reception)
    {
        _birth.Value = DateTime.Today.AddYears(-30);
        this.Text = reception ? "Tiếp nhận bệnh nhân mới" : "Tạo hồ sơ bệnh nhân";
        Ui.Choices(_gender, (TrangThai.Nam, "Nam"), (TrangThai.Nu, "Nữ"), (TrangThai.Khac, "Khác"));
        Ui.Select(_gender, TrangThai.Khac);
        if (_reception)
        {
            Ui.Options(_doctor, NguoiDungService.Doctors());
            Ui.Choices(_type, (TrangThai.KhamMoi, "Khám mới"), (TrangThai.TaiKham, "Tái khám"));
        }

        _layout11_FieldLabel.Visible = _reception;
        _doctor.Visible = _reception;
        _layout12_FieldLabel.Visible = _reception;
        _type.Visible = _reception;
        _layout13_FieldLabel.Visible = _reception;
        _priority.Visible = _reception;
        _cccd.TextChanged += (_, _) =>
        {
            _timer.Stop();
            if (_usingExisting)
            {
                ResetPersonal();
            }

            if (_cccd.Text.Length == 12)
                _timer.Start();
            else
            {
                _lookup.Text = "Nhập đủ 12 chữ số CCCD.";
                OkButton.Enabled = true;
            }
        };
        _timer.Tick += (_, _) =>
        {
            _timer.Stop();
            Ui.Run(Lookup);
        };
        Shown += (_, _) => _cccd.Focus();
    }
    private void OkButton_Click(object? sender, EventArgs e)
    {
        SaveAndClose();
    }
}
