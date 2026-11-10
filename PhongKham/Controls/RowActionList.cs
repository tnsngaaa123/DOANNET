using PhongKham.Core;

namespace PhongKham.Controls;

public sealed class RowActionList<T> : UserControl where T : class
{
    private readonly DataGridView _grid;
    private readonly Panel _actions = new() { Dock = DockStyle.Right, BackColor = Theme.Background };
    private readonly Dictionary<int, AppButton> _buttons = new();
    private readonly Func<T, int> _id;
    private readonly string _text;
    private readonly Action<T> _action;
    private readonly Func<T, bool>? _allowed;
    private bool _queued;

    public RowActionList(DataGridView grid, Func<T, int> id, string text, Action<T> action, Func<T, bool>? allowed = null)
    {
        Dock = DockStyle.Fill;
        BackColor = Theme.Background;
        _grid = grid;
        _id = id;
        _text = text;
        _action = action;
        _allowed = allowed;
        Controls.Add(grid);
        Controls.Add(_actions);
        grid.Dock = DockStyle.Fill;
        grid.DataBindingComplete += (_, _) => Schedule();
        grid.Layout += (_, _) => Schedule();
        grid.Scroll += (_, _) => Schedule();
        grid.RowHeightChanged += (_, _) => Schedule();
        grid.ColumnHeadersHeightChanged += (_, _) => Schedule();
        grid.SizeChanged += (_, _) => Schedule();
        grid.HandleCreated += (_, _) => Schedule();
        HandleCreated += (_, _) => Schedule();
        SizeChanged += (_, _) => { _actions.Width = 220 * DeviceDpi / 96; Schedule(); };
        _actions.Width = 220;
    }

    private void Schedule()
    {
        if (_queued || IsDisposed || !IsHandleCreated)
            return;
        _queued = true;
        BeginInvoke(new Action(() =>
        {
            _queued = false;
            if (!IsDisposed && !Disposing)
                SyncButtons();
        }));
    }

    public void SyncButtons()
    {
        if (!_grid.IsHandleCreated || IsDisposed)
            return;
        int gap = Math.Max(6, 10 * DeviceDpi / 96);
        var visible = new HashSet<int>();
        foreach (DataGridViewRow row in _grid.Rows)
        {
            if (row.DataBoundItem is not T item || !row.Visible)
                continue;
            Rectangle rectangle = _grid.GetRowDisplayRectangle(row.Index, false);
            if (rectangle.Top < _grid.ColumnHeadersHeight || rectangle.Top >= _grid.ClientSize.Height)
                continue;
            if (!(_allowed?.Invoke(item) ?? true))
                continue;
            int key = _id(item);
            visible.Add(key);
            if (!_buttons.TryGetValue(key, out var button))
            {
                button = new AppButton(_text, AppButtonStyle.Primary)
                {
                    Name = "rowAction_" + key,
                    AutoSize = false,
                    MinimumSize = Size.Empty,
                    Margin = Padding.Empty,
                    Padding = new Padding(6, 0, 6, 0),
                    Font = _grid.Font,
                    AccessibleName = _text
                };
                button.Click += (_, _) =>
                {
                    if (button.Tag is T current && (_allowed?.Invoke(current) ?? true))
                        Ui.Run(() => _action(current));
                };
                _buttons.Add(key, button);
                _actions.Controls.Add(button);
            }
            button.Tag = item;
            var bounds = new Rectangle(gap, rectangle.Top + 3, Math.Max(60, _actions.Width - gap * 2), Math.Max(22, rectangle.Height - 6));
            if (button.Bounds != bounds)
                button.Bounds = bounds;
        }
        foreach (int key in _buttons.Keys.Where(key => !visible.Contains(key)).ToList())
        {
            _buttons[key].Dispose();
            _buttons.Remove(key);
        }
    }
}
