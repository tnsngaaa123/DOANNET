using PhongKham.Core;

namespace PhongKham.Controls;

public class CardPanel : Panel
{
    public CardPanel()
    {
        BackColor = Theme.Surface;
        Padding = new Padding(16);
        BorderStyle = BorderStyle.FixedSingle;
    }
}