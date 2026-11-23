using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;
using PhongKham.Pages.Chung.Dialogs;

namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.XuatThuoc, "Danh sách chờ lấy thuốc", PageGroups.DuocKho, 10, Roles.DuocSi)]
public sealed partial class DanhSachChoLayThuocPage : BasePage
{
    protected override void OnPageShown() => Execute(LoadData);
    private void LoadData() => Ui.BindKeep(_grid, XuatThuocService.Waiting(), x => x.Id);
    public DanhSachChoLayThuocPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _layout5_list = new RowActionList<LuotKhamRow>(_grid, x => x.Id, "Xuất thuốc", x =>
        {
            if (!AppDialogs.Confirm("Xuất thuốc cho " + x.HoTen + "?"))
                return;
            var result = XuatThuocService.Dispense(x.Id);
            using var d = new KetQuaXuatThuocDialog(x.HoTen, result);
            d.ShowDialog(this);
            LoadData();
        });
        _layout6_RowActionsHost.Controls.Add(_layout5_list);
        RegisterTimer(2000, (_, _) => Execute(LoadData));
    }

    private RowActionList<LuotKhamRow> _layout5_list = null!;
}