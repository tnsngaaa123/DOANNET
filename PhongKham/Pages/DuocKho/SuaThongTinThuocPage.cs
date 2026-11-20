using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Core;
using PhongKham.Models;
using PhongKham.Services;

namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.SuaThongTinThuoc, "Sửa thông tin thuốc", PageGroups.DuocKho, 26, Roles.DuocSi, ShowInMenu = false)]
public sealed partial class SuaThongTinThuocPage : BasePage
{
    private int _id;
    private void SaveInfo()
    {
        if (_id == 0)
            throw new NghiepVuException("Chọn thuốc từ gợi ý trước khi cập nhật.");
        ThuocService.UpdateInfo(new Thuoc { Id = _id, MaThuoc = _code.Text, TenThuoc = _name.Text, DonViTinh = _unit.Text, NhomThuocId = Ui.Id(_group), GiaBan = (long)_price.Value });
        Navigator.Open(PageKeys.DanhMucThuoc);
    }

    public SuaThongTinThuocPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        _layout1_suggest.UseTimerFactory((ms, tick) => RegisterTimer(ms, tick, false));
        _layout1_suggest.Suggest = query => ThuocService.GoiY(query);
        _layout1_suggest.SelectionCleared += () =>
        {
            _id = 0;
            _update.Enabled = false;
        };
        _layout1_suggest.DrugSelected += selected => Ui.Run(() =>
        {
            var medicine = ThuocService.Get(selected.ThuocId);
            _id = medicine.Id;
            _code.Text = medicine.MaThuoc;
            _name.Text = medicine.TenThuoc;
            _unit.Text = medicine.DonViTinh;
            _group.SelectedValue = medicine.NhomThuocId;
            _price.Value = medicine.GiaBan;
            _stock.Text = ThuocService.List(medicine.MaThuoc).Single(x => x.Id == _id).SoLuongCon.ToString();
            _update.Enabled = true;
        });
        Ui.Options(_group, ThuocService.Groups(), "TenNhom");
    }

    private void _update_Click(object? sender, EventArgs e)
    {
        Ui.Run(SaveInfo);
    }
    private void _back_Click(object? sender, EventArgs e) => Ui.Run(() => Navigator.Open(PageKeys.DanhMucThuoc));
}