using PhongKham.Core;

namespace PhongKham.Controls;

public sealed class KpiCard : CardPanel
{
    private readonly Label _caption = new()
    {
        Dock = DockStyle.Top,
        Height = 28,
        ForeColor = Theme.Muted
    };
    private readonly Label _value = new()
    {
        Dock = DockStyle.Fill,
        Font = new Font("Segoe UI", 24, FontStyle.Bold),
        ForeColor = Theme.Primary
    };
    public KpiCard(string caption = "")
    {
        Height = 112;
        MinimumSize = new Size(150, 112);
        _caption.Text = caption;
        Controls.Add(_value);
        Controls.Add(_caption);
        _value.Click += (_, e) => OnClick(e);
        _caption.Click += (_, e) => OnClick(e);
    }

    public void Set(string value) => _value.Text = value;
}