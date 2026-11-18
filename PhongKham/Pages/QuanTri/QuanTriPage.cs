using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;
using PhongKham.Models;

namespace PhongKham.Pages.QuanTri;

[PageInfo(PageKeys.QuanTri, "Quản trị hệ thống", PageGroups.QuanTri, 10, Roles.Admin)]
public sealed partial class QuanTriPage : BasePage
{
    public QuanTriPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _tabs.SelectedIndexChanged += (_, _) => Toolbar.Visible = _tabs.SelectedIndex == 0;
        RegisterTimer(2000, (_, _) => Execute(RefreshUsers));
        SaveRequested += (_, _) =>
        {
            if (_tabs.SelectedIndex == 1)
                SaveSettings();
        };
    }

    protected override void OnPageShown() => Execute(() =>
    {
        RefreshUsers();
        var settings = CauHinhService.GetAll();
        _clinic.Text = settings.GetValueOrDefault("TenPhongKham", "");
        _address.Text = settings.GetValueOrDefault("DiaChi", "");
        _phone.Text = settings.GetValueOrDefault("SoDienThoai", "");
        _fee.Value = CauHinhService.TienKham;
    });

    private void RefreshUsers() => Ui.BindKeep(_grid, NguoiDungService.All(), x => x.Id);

    private void _createUser_Click(object? sender, EventArgs e) => Ui.Run(() =>
    {
        using var dialog = new TaiKhoanDialog();
        if (dialog.ShowDialog(this) == DialogResult.OK)
            RefreshUsers();
    });

    private void _editUser_Click(object? sender, EventArgs e) => Ui.Run(() =>
    {
        int id = Ui.Selected<NguoiDung>(_grid).Id;
        using var dialog = new TaiKhoanDialog(id);
        if (dialog.ShowDialog(this) == DialogResult.OK)
            RefreshUsers();
    });

    private void _resetPassword_Click(object? sender, EventArgs e) => Ui.Run(() =>
    {
        var user = Ui.Selected<NguoiDung>(_grid);
        var text = AppDialogs.Prompt("Mật khẩu mới cho " + user.TenDangNhap, "", true);
        if (text is not null)
        {
            NguoiDungService.ResetPassword(user.Id, text);
            AppDialogs.Info("Đã đặt lại mật khẩu.");
        }
    });

    private void SaveSettings()
    {
        CauHinhService.Save(_clinic.Text, _address.Text, _phone.Text, (long)_fee.Value);
        AppDialogs.Info("Đã lưu cấu hình.");
    }

    private void _saveSettings_Click(object? sender, EventArgs e) => Ui.Run(SaveSettings);
}
