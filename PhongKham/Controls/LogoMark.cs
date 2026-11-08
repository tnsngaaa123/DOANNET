using PhongKham.Core;

namespace PhongKham.Controls;

public sealed class LogoMark : Control
{
    public LogoMark()
    {
        DoubleBuffered = true;
        Size = new Size(42, 42);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using var b = new SolidBrush(Theme.Primary);
        int s = Math.Min(Width, Height);
        e.Graphics.FillRectangle(b, s / 3, 2, s / 3, s - 4);
        e.Graphics.FillRectangle(b, 2, s / 3, s - 4, s / 3);
    }
}