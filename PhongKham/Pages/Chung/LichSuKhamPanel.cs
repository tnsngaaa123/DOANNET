using PhongKham.Controls;
namespace PhongKham.Pages.Chung;
public sealed class LichSuKhamPanel : UserControl
{
    public LichSuKhamPanel(int patient)
    {
        Dock=DockStyle.Fill;
        Controls.Add(Ui.Grid(("c0","Ngày khám"),("c1","Triệu chứng"),("c2","Chẩn đoán"),("c3","Đơn thuốc")));
    }
}