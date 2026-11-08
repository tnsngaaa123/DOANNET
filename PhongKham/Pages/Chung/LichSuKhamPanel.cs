namespace PhongKham.Pages.Chung;

using PhongKham.Controls;
namespace PhongKham.Pages.Chung;
public sealed class LichSuKhamPanel : UserControl
{
    public LichSuKhamPanel(int patient)
    {
        Dock=DockStyle.Fill;
        Controls.Add(new Label { Text="Lịch sử khám và đơn thuốc",Dock=DockStyle.Top,Height=60 });
    }
}
