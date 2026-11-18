using PhongKham.Models.Views;
using Timer = System.Windows.Forms.Timer;

namespace PhongKham.Controls;
public sealed class DrugAutoCompleteBox : UserControl
{
    private readonly TextBox _txt = new()
    {
        Dock = DockStyle.Top,
        PlaceholderText = "Gõ ít nhất 2 ký tự tên thuốc…"
    };
    private readonly ListBox _list = new()
    {
        Dock = DockStyle.Fill,
        Visible = false,
        HorizontalScrollbar = true,
        IntegralHeight = false
    };
    private Timer _timer;
    private bool _ownsTimer;
    private bool _choosing;
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public Func<string, IReadOnlyList<GoiYThuoc>>? Suggest { get; set; }

    public event Action<GoiYThuoc>? DrugSelected;
    public event Action? SelectionCleared;
    public DrugAutoCompleteBox() : this(CreateOwnedTimer)
    {
        _ownsTimer = true;
    }

    private static Timer CreateOwnedTimer(int interval, EventHandler tick)
    {
        var timer = new Timer
        {
            Interval = interval
        };
        timer.Tick += tick;
        return timer;
    }

    public void UseTimerFactory(Func<int, EventHandler, Timer> factory)
    {
        if (_ownsTimer)
            _timer.Dispose();
        _timer = factory(250, (_, _) =>
        {
            _timer.Stop();
            Ui.Run(RefreshSuggestions);
        });
        _ownsTimer = false;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && _ownsTimer)
            _timer.Dispose();
        base.Dispose(disposing);
    }

    public DrugAutoCompleteBox(Func<int, EventHandler, Timer> timerFactory)
    {
        Height = 34;
        Controls.Add(_list);
        Controls.Add(_txt);
        _timer = timerFactory(250, (_, _) =>
        {
            _timer?.Stop();
            Ui.Run(RefreshSuggestions);
        });
        _txt.TextChanged += (_, _) =>
        {
            if (_choosing)
                return;
            SelectionCleared?.Invoke();
            _timer.Stop();
            if (_txt.Text.Trim().Length < 2)
            {
                HideList();
                return;
            }

            _timer.Start();
        };
        _txt.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Down && _list.Items.Count > 0)
            {
                _list.Focus();
                _list.SelectedIndex = 0;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideList();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter && _list.Visible)
            {
                Choose();
                e.SuppressKeyPress = true;
            }
        };
        _list.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                Choose();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                HideList();
                _txt.Focus();
                e.SuppressKeyPress = true;
            }
        };
        _list.Click += (_, _) => Choose();
    }

    private void HideList()
    {
        _list.Visible = false;
        Height = 34;
    }

    public void FocusInput()
    {
        _txt.Focus();
        _txt.Select(_txt.TextLength, 0);
    }

    private void RefreshSuggestions()
    {
        var rows = Suggest?.Invoke(_txt.Text.Trim()) ?? Array.Empty<GoiYThuoc>();
        _list.DataSource = rows.Take(12).ToList();
        _list.Visible = rows.Count > 0;
        Height = rows.Count > 0 ? Math.Min(210, 34 + rows.Count * 23) : 34;
    }

    private void Choose()
    {
        if (_list.SelectedItem is not GoiYThuoc row)
            return;
        _choosing = true;
        _timer.Stop();
        _txt.Text = row.TenThuoc;
        _choosing = false;
        HideList();
        _txt.Focus();
        DrugSelected?.Invoke(row);
    }
}
