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
    public AppButton() : this("", AppButtonStyle.Secondary)
    {
    }

    public AppButton(string text, AppButtonStyle style = AppButtonStyle.Secondary)
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
        UseVisualStyleBackColor = false;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (!Enabled && (BackColor.ToArgb() == Theme.Primary.ToArgb() || BackColor.ToArgb() == Theme.PrimaryDark.ToArgb()))
        {
            e.Graphics.Clear(BackColor);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Theme.Border, ButtonBorderStyle.Solid);
            var bounds = Rectangle.Inflate(ClientRectangle, -Padding.Horizontal / 2, -Padding.Vertical / 2);
            TextRenderer.DrawText(e.Graphics, Text, Font, bounds, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            return;
        }
        base.OnPaint(e);
    }
}