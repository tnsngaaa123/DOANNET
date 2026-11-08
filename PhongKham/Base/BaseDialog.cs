using PhongKham.Core;
using PhongKham.Controls;

namespace PhongKham.Base;

public class BaseDialog : Form
{
    protected Panel Content
    {
        get;
    } = new()
    {
        Dock = DockStyle.Fill,
        Padding = new Padding(16)
    };
    protected AppButton OkButton { get; } = new("Lưu", AppButtonStyle.Primary);
    protected AppButton CancelAction { get; } = new("Hủy");

    protected BaseDialog()
    {
        Font = Theme.BodyFont;
        BackColor = Theme.Background;
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScaleDimensions = new SizeF(96, 96);
        ClientSize = new Size(800, 560);
        StartPosition = FormStartPosition.CenterParent;
        MinimizeBox = false;
        ShowInTaskbar = false;
        var footer = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 68,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(10)
        };
        footer.Controls.Add(CancelAction);
        footer.Controls.Add(OkButton);
        Controls.Add(Content);
        Controls.Add(footer);
        AcceptButton = OkButton;
        CancelButton = CancelAction;
        CancelAction.DialogResult = DialogResult.Cancel;
        OkButton.Click += (_, _) => Ui.Run(() =>
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
