#nullable disable
using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;

namespace PhongKham;
public sealed partial class MainForm
{
    private System.ComponentModel.IContainer components;
    private Panel _host;
    private SidebarMenu _sidebar;
    private Label _title;
    private TableLayoutPanel _layout1_table;
    private Panel _layout2_side;
    private Label _layout3_brand;
    private TableLayoutPanel _layout4_header;
    private FlowLayoutPanel _layout5_account;
    private Label _layout6_Label;
    private AppButton _layout7_Button;
    private AppButton _layout8_Button;
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            this.components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this._host = new Panel();
        this._sidebar = new SidebarMenu();
        this._title = new Label();
        this._layout1_table = new TableLayoutPanel();
        this._layout2_side = new Panel();
        this._layout3_brand = new Label();
        this._layout4_header = new TableLayoutPanel();
        this._layout5_account = new FlowLayoutPanel();
        this._layout6_Label = new Label();
        this._layout7_Button = new AppButton();
        this._layout8_Button = new AppButton();
        this._host.Name = "_host";
        this._sidebar.Name = "_sidebar";
        this._title.Name = "_title";
        this._layout1_table.Name = "_layout1_table";
        this._layout2_side.Name = "_layout2_side";
        this._layout3_brand.Name = "_layout3_brand";
        this._layout4_header.Name = "_layout4_header";
        this._layout5_account.Name = "_layout5_account";
        this._layout6_Label.Name = "_layout6_Label";
        this._layout7_Button.Name = "_layout7_Button";
        this._layout8_Button.Name = "_layout8_Button";
        this._host.SuspendLayout();
        this._layout1_table.SuspendLayout();
        this._layout2_side.SuspendLayout();
        this._layout4_header.SuspendLayout();
        this._layout5_account.SuspendLayout();
        SuspendLayout();
        this._host.Dock = DockStyle.Fill;
        this._title.Dock = DockStyle.Fill;
        this._title.TextAlign = ContentAlignment.MiddleLeft;
        this.Text = "PhongKham — Quản lý phòng khám";
        this.WindowState = FormWindowState.Maximized;
        this._layout1_table.Dock = DockStyle.Fill;
        this._layout1_table.ColumnCount = 2;
        this._layout1_table.RowCount = 3;
        this._layout1_table.Margin = Padding.Empty;
        this._layout1_table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
        this._layout1_table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        this._layout1_table.RowStyles.Add(new RowStyle(SizeType.Absolute, 76));
        this._layout1_table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        this._layout1_table.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));
        this._layout2_side.Dock = DockStyle.Fill;
        this._layout2_side.BackColor = Color.FromArgb(15, 23, 42);
        this._layout2_side.Margin = Padding.Empty;
        this._layout3_brand.Text = "✚  PHÒNG KHÁM\n     & ĐƠN THUỐC";
        this._layout3_brand.Dock = DockStyle.Top;
        this._layout3_brand.Height = 92;
        this._layout3_brand.Padding = new Padding(16, 18, 0, 0);
        this._layout3_brand.ForeColor = Color.White;
        this._layout3_brand.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        this._layout2_side.Controls.Add(this._sidebar);
        this._layout2_side.Controls.Add(this._layout3_brand);
        this._layout1_table.Controls.Add(this._layout2_side, 0, 0);
        this._layout1_table.SetRowSpan(this._layout2_side, 3);
        this._layout4_header.Dock = DockStyle.Fill;
        this._layout4_header.ColumnCount = 2;
        this._layout4_header.Padding = new Padding(12);
        this._layout4_header.BackColor = Color.White;
        this._layout4_header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        this._layout4_header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        this._layout4_header.Controls.Add(this._title, 0, 0);
        this._layout5_account.AutoSize = true;
        this._layout5_account.Dock = DockStyle.Fill;
        this._layout5_account.WrapContents = false;
        this._layout6_Label.AutoSize = true;
        this._layout6_Label.Margin = new Padding(5, 13, 10, 0);
        this._layout5_account.Controls.Add(this._layout6_Label);
        this._layout7_Button.Text = "Đổi mật khẩu";
        this._layout7_Button.BackColor = Color.White;
        this._layout7_Button.ForeColor = Color.FromArgb(15, 23, 42);
        this._layout5_account.Controls.Add(this._layout7_Button);
        this._layout7_Button.Click += _layout7_Button_Click;
        this._layout8_Button.Text = "Đăng xuất";
        this._layout8_Button.BackColor = Color.White;
        this._layout8_Button.ForeColor = Color.FromArgb(15, 23, 42);
        this._layout5_account.Controls.Add(this._layout8_Button);
        this._layout8_Button.Click += _layout8_Button_Click;
        this._layout4_header.Controls.Add(this._layout5_account, 1, 0);
        this._layout1_table.Controls.Add(this._layout4_header, 1, 0);
        this._layout1_table.Controls.Add(this._host, 1, 1);
        Controls.Add(this._layout1_table);
        this.Name = "MainForm";
        this._layout5_account.ResumeLayout(false);
        this._layout5_account.PerformLayout();
        this._layout4_header.ResumeLayout(false);
        this._layout4_header.PerformLayout();
        this._layout2_side.ResumeLayout(false);
        this._layout2_side.PerformLayout();
        this._layout1_table.ResumeLayout(false);
        this._layout1_table.PerformLayout();
        this._host.ResumeLayout(false);
        this._host.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
