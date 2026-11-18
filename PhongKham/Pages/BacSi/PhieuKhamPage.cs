using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.PhieuKham, "Phiếu khám", PageGroups.DangKham, 20, Roles.BacSi)]
public sealed partial class PhieuKhamPage : BasePage
{
    
    public PhieuKhamPage()
    {
        InitializeComponent();
    }
    protected override void BuildUI()
    {


    }

    private void _layout13_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private void _layout14_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private void _layout15_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}