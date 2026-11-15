using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.ThuNgan;
[PageInfo(PageKeys.ThanhToan, "Thanh toán", PageGroups.ThuNgan, 20, Roles.ThuNgan)]
public sealed partial class ThanhToanPage : BasePage
{
    
    public ThanhToanPage()
    {
        InitializeComponent();
    }
    protected override void BuildUI()
    {


    }

    private void _layout15_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}