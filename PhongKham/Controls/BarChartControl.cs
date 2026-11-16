using PhongKham.Core;

namespace PhongKham.Controls;

public sealed class BarChartControl : Control
{
    private string _title = "";
    private bool _money;
    private List<(string Label, decimal Value)> _rows = new();

    public BarChartControl()
    {
        BackColor = Theme.Surface;
        DoubleBuffered = true;
        MinimumSize = new Size(360, 320);
        SetStyle(ControlStyles.ResizeRedraw, true);
    }

    [System.ComponentModel.DefaultValue("")]
    public string Title { get => _title; set { _title = value; Invalidate(); } }

    [System.ComponentModel.DefaultValue(false)]
    public bool Money { get => _money; set { _money = value; Invalidate(); } }

    private decimal Step => _money ? Math.Max(1000, decimal.Ceiling(Math.Max(1, _rows.Max(x => x.Value)) / 4000) * 1000) : Math.Max(1, decimal.Ceiling(Math.Max(1, _rows.Max(x => x.Value)) / 4));
    private static string Number(decimal value) => value.ToString("N0", Formatters.Vietnamese);

    public void SetData(IEnumerable<(string Label, decimal Value)> rows)
    {
        var next = rows.ToList();
        if (_rows.SequenceEqual(next)) return;
        _rows = next;
        if (_rows.Count > 0)
        {
            using var valueFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            const TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;
            int widest = _rows.Max(x => Math.Max(TextRenderer.MeasureText(Number(x.Value), valueFont, Size.Empty, flags).Width, TextRenderer.MeasureText(x.Label, Theme.SmallFont, Size.Empty, flags).Width));
            int axis = TextRenderer.MeasureText(Number(Step * 4), Theme.SmallFont, Size.Empty, flags).Width;
            int width = axis + 48 * DeviceDpi / 96 + _rows.Count * (widest + 16 * DeviceDpi / 96);
            var needed = new Size(Math.Max(360 * DeviceDpi / 96, width), 320 * DeviceDpi / 96);
            if (MinimumSize != needed) MinimumSize = needed;
        }
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        float pad = 16 * DeviceDpi / 96f, gap = 8 * DeviceDpi / 96f;
        int contentWidth = Math.Max(1, ClientSize.Width - (int)(pad * 2));
        var titleSize = TextRenderer.MeasureText(Title, Theme.BodyFont, new Size(contentWidth, int.MaxValue), TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
        TextRenderer.DrawText(g, Title, Theme.BodyFont, new Rectangle((int)pad, (int)pad, contentWidth, titleSize.Height), Theme.Text, TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
        string axes = Money ? "Trục dọc: doanh thu (VNĐ) · Trục ngang: ngày" : "Trục dọc: số lượt khám · Trục ngang: ngày";
        var axesSize = TextRenderer.MeasureText(axes, Theme.SmallFont, new Size(contentWidth, int.MaxValue), TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
        int axesTop = (int)(pad + titleSize.Height + gap / 2);
        TextRenderer.DrawText(g, axes, Theme.SmallFont, new Rectangle((int)pad, axesTop, contentWidth, axesSize.Height), Color.DimGray, TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
        if (_rows.Count == 0) return;

        using var valueFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        const TextFormatFlags single = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;
        int valueHeight = TextRenderer.MeasureText("0123456789", valueFont, Size.Empty, single).Height + 4;
        int dateHeight = TextRenderer.MeasureText("00/00", Theme.SmallFont, Size.Empty, single).Height + 4;
        decimal step = Step, maximum = step * 4;
        var tickSize = TextRenderer.MeasureText(Number(maximum), Theme.SmallFont, Size.Empty, single);
        float left = pad + tickSize.Width + gap;
        float top = axesTop + axesSize.Height + gap * 2 + valueHeight;
        float bottom = ClientSize.Height - pad - dateHeight - gap - tickSize.Height / 2f;
        var plot = new RectangleF(left, top, Math.Max(1, ClientSize.Width - pad - left), Math.Max(1, bottom - top));
        using var grid = new Pen(Theme.Border);
        using var barBrush = new SolidBrush(Theme.Primary);
        for (int i = 0; i <= 4; i++)
        {
            float y = plot.Bottom - plot.Height * i / 4;
            g.DrawLine(grid, plot.Left, y, plot.Right, y);
            var tick = Rectangle.Round(new RectangleF(pad, y - tickSize.Height / 2f, tickSize.Width, tickSize.Height + 3));
            TextRenderer.DrawText(g, Number(step * i), Theme.SmallFont, tick, Color.DimGray, single | TextFormatFlags.Right);
        }
        for (int i = 0; i < _rows.Count; i++)
        {
            var bar = BarChartGeometry.Bar(plot, i, _rows.Count, _rows[i].Value, maximum);
            if (bar.Height > 0) g.FillRectangle(barBrush, bar);
            var label = BarChartGeometry.ValueLabel(plot, i, _rows.Count, bar, valueHeight, gap / 2);
            TextRenderer.DrawText(g, Number(_rows[i].Value), valueFont, Rectangle.Round(label), Theme.PrimaryDark, single | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            float cell = plot.Width / _rows.Count;
            var day = Rectangle.Round(new RectangleF(plot.Left + cell * i, plot.Bottom + gap + tickSize.Height / 2f, cell, dateHeight));
            TextRenderer.DrawText(g, _rows[i].Label, Theme.SmallFont, day, Color.DimGray, single | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
