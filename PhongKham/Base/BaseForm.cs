using PhongKham.Core;

namespace PhongKham.Base;

public partial class BaseForm : Form
{
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public object? Args
    {
        get; private set;
    }

    public BaseForm()
    {
        InitializeComponent();
    }

    internal void SetArguments(object? args)
    {
        Args = args;
        OnArgumentsChanged();
    }

    protected virtual void OnArgumentsChanged()
    {
    }

    protected override void OnLoad(EventArgs e)
    {
        if (DesignTimeSupport.IsDesignMode(this)) { base.OnLoad(e); return; }
        PhongKham.Controls.SelectionCleaner.Attach(this);
        Rectangle area = Screen.FromControl(this).WorkingArea;
        MinimumSize = new Size(Math.Min(MinimumSize.Width, area.Width), Math.Min(MinimumSize.Height, area.Height));
        if (WindowState == FormWindowState.Maximized)
        {
            WindowState = FormWindowState.Normal;
            MaximizedBounds = area;
            WindowState = FormWindowState.Maximized;
        }
        else
        {
            Size = new Size(Math.Min(Width, area.Width), Math.Min(Height, area.Height));
        }
        base.OnLoad(e);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Escape)
        {
            Close();
            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }
}