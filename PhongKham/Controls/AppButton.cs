using PhongKham.Core;

namespace PhongKham.Controls;

public enum AppButtonStyle
{
    Primary,
    Secondary,
    Danger,
    Light
}

public class AppButton : Button
{
    public AppButton(string text = "", AppButtonStyle style = AppButtonStyle.Secondary)
    {
        Text = text;
        AutoSize = true;
        MinimumSize = new Size(75, 36);
        Padding = new Padding(10, 3, 10, 3);
        Margin = new Padding(3);
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderColor = Theme.Border;
        Cursor = Cursors.Hand;
        BackColor = style switch
        {
            AppButtonStyle.Primary => Theme.Primary,
            AppButtonStyle.Danger => Theme.Danger,
            AppButtonStyle.Light => Theme.Background,
            _ => Theme.Surface
        };
        ForeColor = style is AppButtonStyle.Primary or AppButtonStyle.Danger ? Color.White : Theme.Text;
    }
}