using PhongKham.Core;

namespace PhongKham.Controls;

public sealed class KpiCard : CardPanel
{
    private string _caption = "", _value = "0";

    public KpiCard() : this("") { }

    [System.ComponentModel.DefaultValue("")]
    public string Caption
    {
        get => _caption;
        set { _caption = value; Invalidate(); }
    }

    public KpiCard(string caption)
    {
        _caption = caption;
        Height = 140;
        MinimumSize = new Size(180, 130);
        DoubleBuffered = true;
    }

    public void Set(string value)
    {
        _value = value;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        float width = Math.Max(1, ClientSize.Width - Padding.Horizontal);
        float titleHeight = e.Graphics.MeasureString(_caption, Font, (int)width).Height;
        using var muted = new SolidBrush(Theme.Muted);
        using var green = new SolidBrush(Theme.Primary);
        e.Graphics.DrawString(_caption, Font, muted, new RectangleF(Padding.Left, Padding.Top, width, titleHeight + 4));
        float top = Padding.Top + titleHeight + 12;
        float availableHeight = Math.Max(1, ClientSize.Height - top - Padding.Bottom);
        for (int size = 28; size >= 16; size--)
        {
            using var numberFont = new Font("Segoe UI", size, FontStyle.Bold);
            var measured = e.Graphics.MeasureString(_value, numberFont);
            if (measured.Width <= width || size == 16)
            {
                e.Graphics.DrawString(_value, numberFont, green,
                    new RectangleF(Padding.Left, top, width, Math.Max(availableHeight, measured.Height + 2)));
                break;
            }
        }
    }
}