namespace PhongKham.Base;
public partial class BaseForm
{
    private void InitializeComponent()
    {
        SuspendLayout();
        Font = new Font("Segoe UI", 10F);
        BackColor = Color.FromArgb(241, 245, 249);
        ForeColor = Color.FromArgb(15, 23, 42);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScaleDimensions = new SizeF(96, 96);
        ClientSize = new Size(1280, 800);
        MinimumSize = new Size(1000, 680);
        StartPosition = FormStartPosition.CenterScreen;
        KeyPreview = true;
        ResumeLayout(false);
        PerformLayout();
    }
}