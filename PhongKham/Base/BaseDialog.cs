using PhongKham.Core;
using PhongKham.Controls;

namespace PhongKham.Base;
public partial class BaseDialog : Form
{
    public BaseDialog()
    {
        InitializeComponent();
    }

    protected void SaveAndClose()
    {
        if (DesignTimeSupport.IsDesignMode(this)) return;
        Ui.Run(() =>
        {
            if (ValidateAndSave())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        });
    }

    protected override void OnShown(EventArgs e)
    {
        if (DesignTimeSupport.IsDesignMode(this))
        {
            base.OnShown(e);
            return;
        }

        SelectionCleaner.Attach(this);
        Rectangle area = Screen.FromControl(Owner ?? this).WorkingArea;
        int width = Math.Min(Width, area.Width - 24);
        int height = Math.Min(Height, area.Height - 24);
        MinimumSize = new Size(Math.Min(MinimumSize.Width, width), Math.Min(MinimumSize.Height, height));
        Size = new Size(width, height);
        Location = new Point(area.Left + (area.Width - width) / 2, area.Top + (area.Height - height) / 2);
        base.OnShown(e);
    }

    protected virtual bool ValidateAndSave() => true;
}