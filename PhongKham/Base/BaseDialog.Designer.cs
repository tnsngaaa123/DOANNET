#nullable disable
namespace PhongKham.Base;
public partial class BaseDialog
{
    private void InitializeComponent()
    {
        SuspendLayout();
        Font = new Font("Segoe UI", 10F);
        BackColor = Color.FromArgb(241, 245, 249);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScaleDimensions = new SizeF(96, 96);
        ClientSize = new Size(800, 560);
        StartPosition = FormStartPosition.CenterParent;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ResumeLayout(false);
        PerformLayout();
    }
}