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
        Toolbar.WrapContents=true;Toolbar.Height=110;
        Ui.Button(Toolbar,"Tạo hồ sơ",()=>{using var dialog=new TaoHoSoDialog(true);dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Chi tiết hồ sơ",()=>{using var dialog=new ChiTietHoSoDialog(0);dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Lịch sử khám",()=>{using var dialog=new LichSuKhamDialog(0);dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Chi tiết biên lai",()=>{using var dialog=new ChiTietThanhToanDialog(0);dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Kết quả xuất thuốc",()=>{using var dialog=new KetQuaXuatThuocDialog();dialog.ShowDialog(this);});
        Ui.Button(Toolbar,"Đổi mật khẩu",()=>{using var dialog=new DoiMatKhauDialog();dialog.ShowDialog(this);});
    }
}