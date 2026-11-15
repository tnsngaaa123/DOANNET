using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.SuaThongTinThuoc, "Sửa thông tin thuốc", PageGroups.DuocKho, 26, Roles.DuocSi)]
public sealed partial class SuaThongTinThuocPage : BasePage
{
    
    public SuaThongTinThuocPage()
    {
        InitializeComponent();
    }
    protected override void BuildUI()
    {


    }

    private void _layout17_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}