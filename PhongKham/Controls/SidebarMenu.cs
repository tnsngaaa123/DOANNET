using PhongKham.Core;

namespace PhongKham.Controls;
public sealed class SidebarMenu : Panel
{
    private readonly Panel _content = new() { BackColor = Theme.Sidebar };
    private readonly Dictionary<string, Button> _buttons = new();
    private readonly Dictionary<Button, string> _titles = new();
    private readonly List<Control> _items = new();
    private int _offset, _contentHeight;
    public event Action<string>? PageSelected;
    public SidebarMenu()
    {
        Dock = DockStyle.Fill;
        BackColor = Theme.Sidebar;
        AutoScroll = false;
        Controls.Add(_content);
        _content.MouseWheel += Wheel;
        SizeChanged += (_, _) => ArrangeMenu();
        FontChanged += (_, _) => ArrangeMenu();
    }
    public void BuildMenu(IEnumerable<Navigator.Entry> entries)
    {
        foreach (Control item in _items)
            item.Dispose();
        _items.Clear();
        _buttons.Clear();
        _titles.Clear();
        _offset = 0;
        foreach (var group in entries.Where(x => x.Info.ShowInMenu && Navigator.CanOpen(x.Info)).GroupBy(x => x.Info.Group))
        {
            var heading = new Label { Text = group.Key.ToUpper(Formatters.Vietnamese), ForeColor = Color.FromArgb(148, 163, 184), Font = Theme.SmallFont, AutoSize = false };
            AddItem(heading);
            foreach (var entry in group)
            {
                string key = entry.Info.Key;
                var button = new Button { FlatStyle = FlatStyle.Flat, ForeColor = Color.White, BackColor = Theme.Sidebar, TextAlign = ContentAlignment.MiddleLeft, UseCompatibleTextRendering = true, UseMnemonic = false, Padding = new Padding(10, 4, 8, 4), Cursor = Cursors.Hand, AccessibleName = entry.Info.Title };
                button.FlatAppearance.BorderSize = 0;
                button.Click += (_, _) => PageSelected?.Invoke(key);
                button.Enter += (_, _) => EnsureVisible(button);
                _buttons.Add(key, button);
                _titles.Add(button, entry.Info.Title);
                AddItem(button);
            }
        }
        ArrangeMenu();
    }
    private void AddItem(Control item)
    {
        item.MouseWheel += Wheel;
        _items.Add(item);
        _content.Controls.Add(item);
    }
    private static string WrapTitle(string title, Font font, int width)
    {
        var lines = new List<string>();
        string line = "";
        foreach (string word in title.Split(' '))
        {
            string next = line.Length == 0 ? word : line + " " + word;
            if (line.Length > 0 && TextRenderer.MeasureText(next, font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding | TextFormatFlags.SingleLine).Width > width)
            {
                lines.Add(line);
                line = word;
            }
            else
                line = next;
        }
        if (line.Length > 0)
            lines.Add(line);
        return string.Join(Environment.NewLine, lines);
    }
    private void ArrangeMenu()
    {
        if (IsDisposed || _content is null)
            return;
        int scale = Math.Max(96, DeviceDpi), pad = 8 * scale / 96;
        int width = Math.Max(80, ClientSize.Width - pad * 2), top = pad;
        foreach (Control item in _items)
        {
            int height;
            if (item is Button button)
            {
                button.Text = WrapTitle(_titles[button], Font, Math.Max(40, width - 26 * scale / 96));
                height = Math.Max(48 * scale / 96, TextRenderer.MeasureText(button.Text, Font, new Size(width - 26 * scale / 96, int.MaxValue), TextFormatFlags.NoPadding).Height + 22 * scale / 96);
            }
            else
                height = 34 * scale / 96;
            item.SetBounds(pad, top, width, height);
            top += height + 4 * scale / 96;
        }
        _contentHeight = top + pad;
        MoveTo(_offset);
    }
    private void MoveTo(int value)
    {
        _offset = Math.Clamp(value, 0, Math.Max(0, _contentHeight - ClientSize.Height));
        _content.SetBounds(0, -_offset, ClientSize.Width, _contentHeight);
    }
    private void EnsureVisible(Control item)
    {
        if (item.Top < _offset)
            MoveTo(item.Top);
        else if (item.Bottom > _offset + ClientSize.Height)
            MoveTo(item.Bottom - ClientSize.Height);
    }
    private void Wheel(object? sender, MouseEventArgs e)
    {
        if (e is HandledMouseEventArgs { Handled: true })
            return;
        MoveTo(_offset - e.Delta * 48 * DeviceDpi / (120 * 96));
        if (e is HandledMouseEventArgs handled)
            handled.Handled = true;
    }
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        Wheel(this, e);
        base.OnMouseWheel(e);
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.PageDown)
        {
            MoveTo(_offset + ClientSize.Height - 30);
            return true;
        }
        if (keyData == Keys.PageUp)
        {
            MoveTo(_offset - ClientSize.Height + 30);
            return true;
        }
        if (keyData == Keys.Home)
        {
            MoveTo(0);
            return true;
        }
        if (keyData == Keys.End)
        {
            MoveTo(_contentHeight);
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    public void SelectPage(string key)
    {
        foreach (var pair in _buttons)
            pair.Value.BackColor = pair.Key == key ? Theme.PrimaryDark : Theme.Sidebar;
        if (_buttons.TryGetValue(key, out var button))
            EnsureVisible(button);
    }
}
