using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;

namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.DanhMucThuoc, "Danh mục thuốc", PageGroups.DuocKho, 20, Roles.DuocSi)]
public sealed partial class DanhMucThuocPage : BasePage
{
    protected override void OnPageShown() => Execute(Find);
    private void Find() => Ui.BindKeep(_grid, ThuocService.List(_search.Text.Trim()), x => x.Id);
    public DanhMucThuocPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
    }

    private void _layout7_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Find);
    }

    private void _layout8_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => Navigator.Open(PageKeys.ThemThuoc));
    }

    private void _layout9_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => Navigator.Open(PageKeys.SuaThongTinThuoc));
    }

    private void _layout10_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Execute(Find);
            e.SuppressKeyPress = true;
        }
    }
}