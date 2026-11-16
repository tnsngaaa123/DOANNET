using System.Drawing;

namespace PhongKham.Core;

public static class BarChartGeometry
{
    public static RectangleF Bar(RectangleF plot, int index, int count, decimal value, decimal maximum)
    {
        if (count < 1 || index < 0 || index >= count || maximum <= 0) throw new ArgumentOutOfRangeException(nameof(count));
        float cell = plot.Width / count;
        float width = cell * .56f;
        float height = plot.Height * (float)Math.Clamp(value / maximum, 0, 1);
        return new RectangleF(plot.Left + cell * index + (cell - width) / 2, plot.Bottom - height, width, height);
    }

    public static RectangleF ValueLabel(RectangleF plot, int index, int count, RectangleF bar, float height, float gap)
    {
        float cell = plot.Width / count;
        return new RectangleF(plot.Left + cell * index, bar.Top - height - gap, cell, height);
    }
}