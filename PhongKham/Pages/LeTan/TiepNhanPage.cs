using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;
using PhongKham.Pages.Chung.Dialogs;

namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.TiepNhan, "Tiếp nhận bệnh nhân", PageGroups.TiepNhan, 10, Roles.LeTan)]
public sealed partial class TiepNhanPage : BasePage
{
    protected override void OnPageShown() => Execute(Find);
    private void Find() => Ui.BindKeep(_grid, TiepNhanService.List(_search.Text.Trim()), x => x.Id);
    public TiepNhanPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _layout10_list = new RowActionList<LuotKhamRow>(_grid, x => x.Id, "Xem số khám", x =>
        {
            var ticket = TiepNhanService.Issue(x.Id);
            PhongKham.Core.Dialogs.Info("STT: " + ticket.LuotKham.Phieu.SoThuTu);
            Find();
        }, x => x.Phieu.TrangThai == TrangThai.ChoKham);
        _layout11_RowActionsHost.Controls.Add(_layout10_list);
    }

    private void _layout8_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Find);
    }

    private void _layout9_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            using var d = new TaoHoSoDialog(true);
            if (d.ShowDialog(this) == DialogResult.OK)
                Find();
        });
    }

    private void _layout12_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Execute(Find);
            e.SuppressKeyPress = true;
        }
    }

    private RowActionList<LuotKhamRow> _layout10_list = null!;
}