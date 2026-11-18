using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Core;
using PhongKham.Models;
using PhongKham.Services;

namespace PhongKham.Pages.QuanTri;

public sealed partial class TaiKhoanDialog : BaseDialog
{
    private readonly int _id;

    public TaiKhoanDialog()
    {
        InitializeComponent();
        if (DesignTimeSupport.IsDesignMode(this))
            return;
        Ui.Choices(_role, Roles.All.Select(x => (x, Roles.TenHienThi(x))).ToArray());
        Ui.Select(_role, Roles.LeTan);
    }

    public TaiKhoanDialog(int id) : this()
    {
        if (DesignTimeSupport.IsDesignMode(this))
            return;
        var user = NguoiDungService.All().FirstOrDefault(x => x.Id == id)
                   ?? throw new NghiepVuException("Tài khoản không tồn tại.");
        _id = id;
        Text = "Sửa tài khoản";
        OkButton.Text = "Cập nhật tài khoản";
        _login.Text = user.TenDangNhap;
        _login.ReadOnly = true;
        _name.Text = user.HoTen;
        _active.Checked = user.TrangThai;
        _password.PlaceholderText = "Để trống nếu giữ mật khẩu hiện tại";
        Ui.Select(_role, user.VaiTro);
    }

    protected override bool ValidateAndSave()
    {
        NguoiDungService.Save(new NguoiDung
        {
            Id = _id,
            TenDangNhap = _login.Text,
            HoTen = _name.Text,
            VaiTro = Ui.Value(_role),
            TrangThai = _active.Checked
        }, _password.Text);
        return true;
    }

    private void OkButton_Click(object? sender, EventArgs e) => SaveAndClose();
}