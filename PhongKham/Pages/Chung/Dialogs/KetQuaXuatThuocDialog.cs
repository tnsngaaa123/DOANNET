using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
namespace PhongKham.Pages.Chung.Dialogs;
public sealed class KetQuaXuatThuocDialog : BaseDialog
{
    public KetQuaXuatThuocDialog()
    {
        Text="Kết quả xuất thuốc";ClientSize=new Size(900,620);
        OkButton.Text="Đóng";CancelAction.Visible=false;
        Content.Controls.Add(Ui.Grid(("c0","Tên thuốc"),("c1","ĐVT"),("c2","Số lượng đã xuất"),("c3","Số lượng còn trong kho")));
    }

}