using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.Auth;
[PageInfo(PageKeys.TrangChu,"Trang chủ",PageGroups.TongQuan,0)]
public sealed partial class TrangChuPage : BasePage
{
    
    public TrangChuPage()
    {
        InitializeComponent();
    }
    protected override void BuildUI()
    {

        _layout2_count.Set("3");
        _layout3_money.Set("1.500.000 đ");
        var values=new decimal[] {0,1,2,4,3,5,3};
        _visits.SetData(values.Select((value,i)=>(DateTime.Today.AddDays(i-6).ToString("dd/MM"),value)));
        _revenue.SetData(values.Select((value,i)=>(DateTime.Today.AddDays(i-6).ToString("dd/MM"),value*150000)));
    }

    private void _layout4_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{using var dialog=new TaoHoSoDialog(true);dialog.ShowDialog(this);});
    }
    private void _layout5_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{using var dialog=new ChiTietHoSoDialog(0);dialog.ShowDialog(this);});
    }
    private void _layout6_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{using var dialog=new LichSuKhamDialog(0);dialog.ShowDialog(this);});
    }
    private void _layout7_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{using var dialog=new ChiTietThanhToanDialog(0);dialog.ShowDialog(this);});
    }
    private void _layout8_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{using var dialog=new KetQuaXuatThuocDialog();dialog.ShowDialog(this);});
    }
    private void _layout9_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{using var dialog=new DoiMatKhauDialog();dialog.ShowDialog(this);});
    }
}