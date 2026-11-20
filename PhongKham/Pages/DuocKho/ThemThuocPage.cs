using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.ThemThuoc, "Thêm thuốc", PageGroups.DuocKho, 25, Roles.DuocSi, ShowInMenu = false)]
public sealed partial class ThemThuocPage : BasePage
{
    private int _selectedId;
    private string _selectedCode = "";
    private List<ImportThuocRow> _excelRows = new();
    private void LoadExcel(string path)
    {
        _excelStatus.Text=Path.GetFileName(path);
        _addExcel.Enabled=false;
    }

    public ThemThuocPage()
    {
        InitializeComponent();
    }

    protected override void OnPageShown()
    {
        _unit.SelectionLength = 0;
        _suggest.FocusInput();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_preview);
        _expiry.Value = DateTime.Today.AddYears(1);
        _suggest.UseTimerFactory((i, h) => RegisterTimer(i, h, false));
        _suggest.Suggest = q => ThuocService.GoiY(q);
        _suggest.DrugSelected += g => Ui.Run(() =>
        {
            var t = ThuocService.Get(g.ThuocId);
            _selectedId = t.Id;
            _selectedCode = t.MaThuoc;
            _code.Text = t.MaThuoc;
            _name.Text = t.TenThuoc;
            _unit.Text = t.DonViTinh;
            _group.SelectedValue = t.NhomThuocId;
            _price.Value = t.GiaBan;
            _qty.Value = 0;
            _mode.Text = "Đã chọn thuốc có sẵn. Nhập số lượng cộng thêm và hạn dùng.";
        });
        Ui.Options(_group, ThuocService.Groups(), "TenNhom");
        _code.TextChanged += (_, _) =>
        {
            if (_selectedId > 0 && !string.Equals(_code.Text.Trim(), _selectedCode, StringComparison.OrdinalIgnoreCase))
            {
                _selectedId = 0;
                _mode.Text = "Thêm thuốc mới theo mã vừa nhập.";
            }
        };
        void EnterFile(object? sender, DragEventArgs e)
        {
            e.Effect = e.Data?.GetDataPresent(DataFormats.FileDrop) == true ? DragDropEffects.Copy : DragDropEffects.None;
        }

        void DropFile(object? sender, DragEventArgs e)
        {
            Ui.Run(() =>
            {
                if (e.Data?.GetData(DataFormats.FileDrop)is not string[] paths || paths.Length != 1)
                    throw new NghiepVuException("Chỉ thả một file Excel mỗi lần.");
                LoadExcel(paths[0]);
            });
        }

        _layout23_drop.DragEnter += EnterFile;
        _layout24_text.DragEnter += EnterFile;
        _preview.DragEnter += EnterFile;
        _layout23_drop.DragDrop += DropFile;
        _layout24_text.DragDrop += DropFile;
        _preview.DragDrop += DropFile;
        _preview.RowPrePaint += (_, e) =>
        {
            if (_preview.Rows[e.RowIndex].DataBoundItem is ImportThuocRow x)
                _preview.Rows[e.RowIndex].DefaultCellStyle.BackColor = x.HopLe ? Color.White : Color.MistyRose;
        };
    }

    private void _layout20_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            var input = new ThemThuocInput
            {
                Thuoc = new Thuoc
                {
                    Id = _selectedId,
                    MaThuoc = _code.Text,
                    TenThuoc = _name.Text,
                    DonViTinh = _unit.Text,
                    NhomThuocId = Ui.Id(_group),
                    GiaBan = (long)_price.Value
                },
                SoLuong = (int)_qty.Value,
                HanSuDung = _expiry.Value.Date
            };
            var result = ThuocService.Add(input);
            AppDialogs.Info((result.LaThuocMoi ? "Đã thêm thuốc mới: " : "Đã cộng số lượng: ") + result.TenThuoc + Environment.NewLine + "Cộng thêm: " + result.SoLuongThem + Environment.NewLine + "Số lượng còn: " + result.SoLuongCon);
            Navigator.Open(PageKeys.DanhMucThuoc);
        });
    }

    private void _layout28_OnLinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        Ui.Run(() =>
        {
            using var f = new OpenFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx"
            };
            if (f.ShowDialog() == DialogResult.OK)
                LoadExcel(f.FileName);
        });
    }

    private void _layout29_OnLinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        Ui.Run(() =>
        {
            using var f = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = "MauNhapThuoc.xlsx"
            };
            if (f.ShowDialog() == DialogResult.OK)
                File.Copy(Path.Combine(AppContext.BaseDirectory, "templates", "MauNhapThuoc.xlsx"), f.FileName, true);
        });
    }

    private void _addExcel_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            if (!_excelRows.Any(x => x.HopLe))
                throw new NghiepVuException("Chưa có dòng hợp lệ.");
            if (!AppDialogs.Confirm("Thêm/cộng số lượng cho " + _excelRows.Count(x => x.HopLe) + " dòng hợp lệ? Các dòng lỗi sẽ không được ghi."))
                return;
            _addExcel.Enabled = false;
            try
            {
                var result = ImportThuocService.Add(_excelRows);
                _excelRows = new();
                Ui.Bind(_preview, _excelRows);
                AppDialogs.Info($"Đã thêm {result.DongThanhCong} dòng · {result.ThuocMoi} thuốc mới · {result.LuotCongThem} lượt cộng kho · {result.TongSoLuong} đơn vị · {result.DongLoi} dòng lỗi không ghi.");
                Navigator.Open(PageKeys.DanhMucThuoc);
            }
            catch
            {
                _addExcel.Enabled = true;
                _excelStatus.Text = "Lỗi thêm thuốc: đợt ghi đã rollback, có thể thử lại.";
                throw;
            }
        });
    }
    private void _backToCatalog_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => Navigator.Open(PageKeys.DanhMucThuoc));
    }
}
