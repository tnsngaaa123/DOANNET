using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;


namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.DsChoKham, "Danh sách chờ khám", PageGroups.KhamBenh, 10, Roles.BacSi)]
public sealed partial class DanhSachChoKhamPage : BasePage
{
    protected override void OnPageShown() => Execute(LoadData);
    private void LoadData() => Ui.BindKeep(_grid, KhamBenhService.Waiting(), x => x.Id);

    private void Next()
    {
        var result = KhamBenhService.Next();
        if (result.CoPhieuDangKham && !AppDialogs.Confirm("Bạn đang có phiếu khám chưa hoàn tất trong mục Đang khám. Trở lại trang làm việc đó?"))
            return;
        Navigator.Open(PageKeys.PhieuKham, new LuotKhamArgs(result.PhieuKhamId));
    }
    

    
    public DanhSachChoKhamPage()
    {
        InitializeComponent();
    }
    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        RegisterTimer(2000, (_, _) => Execute(LoadData));
    }

    private void _layout6_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Next);
    }
}