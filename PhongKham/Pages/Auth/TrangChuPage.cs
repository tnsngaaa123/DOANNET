using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.Auth;
[PageInfo(PageKeys.TrangChu,"Trang chủ",PageGroups.TongQuan,0)]
public sealed class TrangChuPage : BasePage
{
    protected override void BuildUI()
    {
        var cards=new TableLayoutPanel { Dock=DockStyle.Top,Height=140,ColumnCount=2 };cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50));cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50));var count=new KpiCard("Lượt khám hôm nay"){Dock=DockStyle.Fill};var money=new KpiCard("Doanh thu hôm nay"){Dock=DockStyle.Fill};count.Set("3");money.Set("1.500.000 đ");cards.Controls.Add(count,0,0);cards.Controls.Add(money,1,0);Content.Controls.Add(cards);
        Ui.Button(Toolbar,"Tạo hồ sơ",()=>{using var dialog=new TaoHoSoDialog(true);dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Chi tiết hồ sơ",()=>{using var dialog=new ChiTietHoSoDialog(0);dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Lịch sử khám",()=>{using var dialog=new LichSuKhamDialog(0);dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Chi tiết biên lai",()=>{using var dialog=new ChiTietThanhToanDialog(0);dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Kết quả xuất thuốc",()=>{using var dialog=new KetQuaXuatThuocDialog();dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Đổi mật khẩu",()=>{using var dialog=new DoiMatKhauDialog();dialog.ShowDialog(this);});
    }
}