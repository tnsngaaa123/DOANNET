#nullable disable
namespace PhongKham.Base;
public partial class BasePage
{
    private void InitializeComponent()
    {
        SuspendLayout();
        Font = new Font("Segoe UI", 10F);
        BackColor = Color.FromArgb(241, 245, 249);
        Size = new Size(1100, 720);
        ResumeLayout(false);
        PerformLayout();
    }
}