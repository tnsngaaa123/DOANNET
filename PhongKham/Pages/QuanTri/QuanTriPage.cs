using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
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


    }

    private void _layout24_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}