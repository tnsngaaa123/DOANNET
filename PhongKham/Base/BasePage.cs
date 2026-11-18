using PhongKham.Core;
using PhongKham.Controls;
using Timer = System.Windows.Forms.Timer;

namespace PhongKham.Base;
public partial class BasePage : UserControl
{
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public object? Args { get; private set; }

    private readonly List<Timer> _timers = new();
    public event EventHandler? RefreshRequested, SaveRequested;
    public BasePage()
    {
        InitializeComponent();
    }

    internal void Prepare(object? args)
    {
        Args = args;
        BuildUI();
    }

    internal void ActivatePage() => OnPageShown();
    internal void HidePage()
    {
        foreach (var t in _timers)
            t.Stop();
        OnPageHidden();
    }

    protected virtual void BuildUI()
    {
    }

    protected virtual void OnPageShown()
    {
    }

    protected virtual void OnPageHidden()
    {
    }

    public virtual bool CanLeave() => true;
    protected void Execute(Action action) => Ui.Run(action);
    protected Timer RegisterTimer(int interval, EventHandler tick, bool start = true)
    {
        var t = new Timer
        {
            Interval = interval
        };
        t.Tick += tick;
        _timers.Add(t);
        if (start && !DesignTimeSupport.IsDesignMode(this))
            t.Start();
        return t;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        EventHandler? handler = keyData switch
        {
            Keys.F5 => RefreshRequested,
            Keys.Control | Keys.S => SaveRequested,
            _ => null
        };
        if (handler is null)
            return base.ProcessCmdKey(ref msg, keyData);
        Ui.Run(() => handler(this, EventArgs.Empty));
        return true;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            foreach (var t in _timers)
                t.Dispose();
            _timers.Clear();
        }

        base.Dispose(disposing);
    }
}
