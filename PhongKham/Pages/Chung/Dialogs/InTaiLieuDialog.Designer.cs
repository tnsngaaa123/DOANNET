#nullable disable
using PhongKham.Controls;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class InTaiLieuDialog
{
    private System.ComponentModel.IContainer components;
    private FlowLayoutPanel _toolbar;
    private Label _documentLabel;
    private ComboBox _documentList;
    private AppButton _print;
    private AppButton _close;
    private PrintPreviewControl _preview;
    private FlowLayoutPanel _pageBar;
    private AppButton _previous;
    private AppButton _next;
    private Label _page;
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            this._preview.Document = null;
            this._combinedPreview?.Dispose();
            this.components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this._toolbar = new FlowLayoutPanel();
        this._documentLabel = new Label();
        this._documentList = new ComboBox();
        this._print = new AppButton();
        this._close = new AppButton();
        this._preview = new PrintPreviewControl();
        this._pageBar = new FlowLayoutPanel();
        this._previous = new AppButton();
        this._next = new AppButton();
        this._page = new Label();
        this._toolbar.Name = "_toolbar";
        this._documentLabel.Name = "_documentLabel";
        this._documentList.Name = "_documentList";
        this._print.Name = "_print";
        this._close.Name = "_close";
        this._preview.Name = "_preview";
        this._pageBar.Name = "_pageBar";
        this._previous.Name = "_previous";
        this._next.Name = "_next";
        this._page.Name = "_page";
        this._toolbar.SuspendLayout();
        this._pageBar.SuspendLayout();
        SuspendLayout();
        this._toolbar.Dock = DockStyle.Top;
        this._toolbar.AutoSize = true;
        this._toolbar.MinimumSize = new Size(0, 64);
        this._toolbar.Padding = new Padding(12, 8, 12, 8);
        this._toolbar.BackColor = Color.White;
        this._documentLabel.Text = "Tài liệu";
        this._documentLabel.AutoSize = true;
        this._documentLabel.Margin = new Padding(4, 12, 8, 0);
        this._documentList.Width = 350;
        this._documentList.DropDownStyle = ComboBoxStyle.DropDownList;
        this._documentList.Margin = new Padding(3, 6, 12, 3);
        this._documentList.SelectedIndexChanged += _documentList_SelectedIndexChanged;
        this._print.Text = "IN";
        this._print.BackColor = Color.FromArgb(22, 163, 74);
        this._print.ForeColor = Color.White;
        this._print.Click += _print_Click;
        this._close.Text = "Đóng";
        this._close.Click += _close_Click;
        this._toolbar.Controls.Add(this._documentLabel);
        this._toolbar.Controls.Add(this._documentList);
        this._toolbar.Controls.Add(this._print);
        this._toolbar.Controls.Add(this._close);
        this._preview.Dock = DockStyle.Fill;
        this._preview.AutoZoom = true;
        this._preview.UseAntiAlias = true;
        this._preview.StartPageChanged += _preview_StartPageChanged;
        this._pageBar.Dock = DockStyle.Bottom;
        this._pageBar.AutoSize = true;
        this._pageBar.MinimumSize = new Size(0, 56);
        this._pageBar.Padding = new Padding(12, 4, 12, 4);
        this._pageBar.BackColor = Color.White;
        this._previous.Text = "Trang trước";
        this._previous.Enabled = false;
        this._previous.Click += _previous_Click;
        this._next.Text = "Trang sau";
        this._next.Click += _next_Click;
        this._page.Text = "Trang 1";
        this._page.AutoSize = true;
        this._page.Margin = new Padding(12, 12, 12, 0);
        this._pageBar.Controls.Add(this._previous);
        this._pageBar.Controls.Add(this._page);
        this._pageBar.Controls.Add(this._next);
        Controls.Add(this._preview);
        Controls.Add(this._toolbar);
        Controls.Add(this._pageBar);
        Text = "Xem trước và in";
        Name = "InTaiLieuDialog";
        ClientSize = new Size(1100, 800);
        MinimumSize = new Size(760, 560);
        StartPosition = FormStartPosition.CenterParent;
        this._pageBar.ResumeLayout(false);
        this._pageBar.PerformLayout();
        this._toolbar.ResumeLayout(false);
        this._toolbar.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
        