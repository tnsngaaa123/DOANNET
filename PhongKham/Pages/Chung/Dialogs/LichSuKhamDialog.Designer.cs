#nullable disable
using PhongKham.Base;
using PhongKham.Controls;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class LichSuKhamDialog
{
    private System.ComponentModel.IContainer components;
    private Panel Content;
    private AppButton OkButton;
    private AppButton CancelAction;
    private FlowLayoutPanel _dialogFooter;
    private Pages.Chung.LichSuKhamPanel _layout1_LichSuKhamPanel;
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            this.components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.Content = new Panel();
        this.OkButton = new AppButton();
        this.CancelAction = new AppButton();
        this._dialogFooter = new FlowLayoutPanel();
        this._layout1_LichSuKhamPanel = new Pages.Chung.LichSuKhamPanel();
        this.Content.Name = "Content";
        this.OkButton.Name = "OkButton";
        this.CancelAction.Name = "CancelAction";
        this._dialogFooter.Name = "_dialogFooter";
        this._layout1_LichSuKhamPanel.Name = "_layout1_LichSuKhamPanel";
        this.Content.SuspendLayout();
        this._dialogFooter.SuspendLayout();
        SuspendLayout();
        this.Content.Dock = DockStyle.Fill;
        this.Content.Padding = new Padding(16);
        this.OkButton.Text = "Lưu";
        this.OkButton.BackColor = Color.FromArgb(22, 163, 74);
        this.OkButton.ForeColor = Color.White;
        this.OkButton.Click += OkButton_Click;
        this.CancelAction.Text = "Hủy";
        this.CancelAction.DialogResult = DialogResult.Cancel;
        this._dialogFooter.Dock = DockStyle.Bottom;
        this._dialogFooter.Height = 68;
        this._dialogFooter.FlowDirection = FlowDirection.RightToLeft;
        this._dialogFooter.Padding = new Padding(10);
        this._dialogFooter.Controls.Add(this.CancelAction);
        this._dialogFooter.Controls.Add(this.OkButton);
        this.Text = "Lịch sử khám trước đây";
        this.ClientSize = new Size(1200, 780);
        this.OkButton.Text = "Đóng";
        this.CancelAction.Visible = false;
        this.Content.Controls.Add(this._layout1_LichSuKhamPanel);
        this.Name = "LichSuKhamDialog";
        Controls.Add(this.Content);
        Controls.Add(this._dialogFooter);
        AcceptButton = this.OkButton;
        CancelButton = this.CancelAction;
        this._dialogFooter.ResumeLayout(false);
        this._dialogFooter.PerformLayout();
        this.Content.ResumeLayout(false);
        this.Content.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
