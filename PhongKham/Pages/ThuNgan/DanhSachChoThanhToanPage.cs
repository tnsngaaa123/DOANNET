using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.ThuNgan;
[PageInfo(PageKeys.ChoThanhToan, "Danh sách chờ thanh toán", PageGroups.ThuNgan, 10, Roles.ThuNgan)]
public sealed partial class DanhSachChoThanhToanPage : BasePage
{
    protected override void OnPageShown() => Execute(LoadData);
    private void LoadData() => Ui.BindKeep(_grid, ThanhToanService.Waiting(), x => x.Id);
    public DanhSachChoThanhToanPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _layout6_list = new RowActionList<LuotKhamRow>(_grid, x => x.Id, "Thanh toán", x => Navigator.Open(PageKeys.ThanhToan, new LuotKhamArgs(x.Id)));
        _layout7_RowActionsHost.Controls.Add(_layout6_list);
        RegisterTimer(2000, (_, _) => Execute(LoadData));
    }

    private RowActionList<LuotKhamRow> _layout6_list = null!;
}