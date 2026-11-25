using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.KeDon, "Kê đơn", PageGroups.DangKham, 30, Roles.BacSi, ShowInMenu = false)]
public sealed partial class KeDonPage : BasePage
{
    private int _id;
    private bool _loading = true, _dirty, _editorDirty, _editable;
    private List<DongDonThuocRow> _rows = new();
    private GoiYThuoc? _drug;
    private ChiTietDonThuoc Input() => new()
    {
        ThuocId = _drug?.ThuocId ?? 0,
        SoLuong = (int)_qty.Value,
        SoNgay = (int)_days.Value,
        Sang = (double)_morning.Value,
        Trua = (double)_noon.Value,
        Chieu = (double)_afternoon.Value,
        Toi = (double)_evening.Value,
        ThoiDiemUong = Ui.Value(_timing),
        LieuDung = _dose.Text,
        DonGia = _drug?.GiaBan ?? 0
    };
    private void SuggestDose()
    {
        var x = Input();
        _qty.Value = KeDonService.GoiYSoLuong(x.Sang, x.Trua, x.Chieu, x.Toi, x.SoNgay);
        _dose.Text = KeDonService.GoiYLieuDung(x, _drug?.DonViTinh ?? "viên");
    }

    private void AddLine()
    {
        if (!_editable)
            throw new NghiepVuException("Phiếu không còn được sửa.");
        if (_drug is null)
            throw new NghiepVuException("Chọn thuốc từ gợi ý.");
        var x = Input();
        if (x.SoLuong < 1 || x.SoNgay < 1 || string.IsNullOrWhiteSpace(x.LieuDung))
            throw new NghiepVuException("Nhập số lượng, số ngày và liều dùng.");
        KeDonService.KiemTraSoLuongTheoLieu(x);
        if (x.SoLuong > ThuocService.KhaDung(x.ThuocId, _id))
            throw new NghiepVuException("Không đủ thuốc còn hạn cho số lượng này.");
        _rows.RemoveAll(r => r.ThuocId == x.ThuocId);
        _rows.Add(new DongDonThuocRow { Dong = x, TenThuoc = _drug.TenThuoc, DonViTinh = _drug.DonViTinh });
        _dirty = true;
        _editorDirty = false;
        Bind();
    }

    private void SelectLine()
    {
        if (_grid.CurrentRow?.DataBoundItem is not DongDonThuocRow row)
            return;
        _loading = true;
        try
        {
            var t = ThuocService.Get(row.ThuocId);
            _drug = new GoiYThuoc
            {
                ThuocId = t.Id,
                MaThuoc = t.MaThuoc,
                TenThuoc = t.TenThuoc,
                DonViTinh = t.DonViTinh,
                GiaBan = t.GiaBan
            };
            var x = row.Dong;
            _chosen.Text = t.TenThuoc;
            _qty.Value = x.SoLuong;
            _days.Value = x.SoNgay;
            _morning.Value = (decimal)x.Sang;
            _noon.Value = (decimal)x.Trua;
            _afternoon.Value = (decimal)x.Chieu;
            _evening.Value = (decimal)x.Toi;
            Ui.Select(_timing, x.ThoiDiemUong);
            _dose.Text = x.LieuDung;
            _editorDirty = false;
        }
        finally
        {
            _loading = false;
        }
    }

    private void Bind()
    {
        Ui.Bind(_grid, _rows);
        _total.Text = "Tổng tiền thuốc: " + Formatters.Tien(_rows.Sum(x => x.ThanhTien));
    }

    private void Save(bool notify)
    {
        if (_editorDirty && _drug is not null)
            AddLine();
        KeDonService.Save(_id, _rows.Select(x => x.Dong).ToList());
        _rows = KeDonService.Load(_id);
        Bind();
        _dirty = _editorDirty = false;
        if (notify)
            AppDialogs.Info("Đã lưu đơn thuốc.");
    }

    private void Back()
    {
        if (_editable && (_dirty || _editorDirty))
            Save(false);
        Navigator.Open(PageKeys.PhieuKham, new LuotKhamArgs(_id));
    }

    public override bool CanLeave() => (!_dirty && !_editorDirty) || AppDialogs.Confirm("Bỏ thay đổi đơn thuốc chưa lưu?");
    public KeDonPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _id = (Args as LuotKhamArgs)?.PhieuKhamId ?? throw new NghiepVuException("Thiếu lượt khám.");
        Ui.RowAction<DongDonThuocRow>(_grid, "remove", "✕", x =>
        {
            if (!AppDialogs.Confirm("Xóa thuốc " + x.TenThuoc + " khỏi đơn?"))
                return;
            _rows.Remove(x);
            _dirty = true;
            _editorDirty = false;
            Bind();
        }, _ => _editable);
        _auto.UseTimerFactory((i, h) => RegisterTimer(i, h, false));
        _auto.Suggest = q => ThuocService.GoiY(q, _id);
        _auto.SelectionCleared += () =>
        {
            _drug = null;
            _chosen.Text = "Chọn thuốc từ gợi ý để thêm vào đơn.";
        };
        _auto.DrugSelected += d => Ui.Run(() =>
        {
            _drug = d;
            _chosen.Text = d.TenThuoc + " · Có thể kê " + d.SoLuongCon + " " + d.DonViTinh;
            SuggestDose();
            _editorDirty = true;
        });
        Ui.Choices(_timing, (TrangThai.SauAn, "Sau ăn"), (TrangThai.TruocAn, "Trước ăn"), (TrangThai.TrongBuaAn, "Trong bữa ăn"), (TrangThai.KhongQuyDinh, "Không quy định"));
        foreach (var n in new[]
        {
            _qty,
            _days,
            _morning,
            _noon,
            _afternoon,
            _evening
        }

        )
            n.ValueChanged += (_, _) =>
            {
                if (!_loading)
                    _editorDirty = true;
            };
        _timing.SelectedIndexChanged += (_, _) =>
        {
            if (!_loading)
                _editorDirty = true;
        };
        _dose.TextChanged += (_, _) =>
        {
            if (!_loading)
                _editorDirty = true;
        };
        _grid.SelectionChanged += (_, _) => Execute(SelectLine);
        var data = KhamBenhService.Get(_id);
        _editable = data.Phieu.TrangThai == TrangThai.DangKham;
        _layout6_save.Enabled = _layout21_add.Enabled = _layout20_suggest.Enabled = _editable;
        _auto.Enabled = _editable;
        foreach (var c in new Control[]
        {
            _qty,
            _days,
            _morning,
            _noon,
            _afternoon,
            _evening,
            _timing,
            _dose
        }

        )
            c.Enabled = _editable;
        _rows = data.CacThuoc;
        Bind();
        _loading = false;
        _dirty = _editorDirty = false;
    }

    private void _layout6_save_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => Save(true));
    }

    private void _layout7_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Back);
    }

    private void _layout20_suggest_Click(object? sender, EventArgs e)
    {
        Ui.Run(SuggestDose);
    }

    private void _layout21_add_Click(object? sender, EventArgs e)
    {
        Ui.Run(AddLine);
    }
}
