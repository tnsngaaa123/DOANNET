#nullable disable
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Core;
using PhongKham.Models;
using PhongKham.Pages.Chung.Dialogs;
using PhongKham.Services;

namespace PhongKham.Pages.LeTan;
public sealed partial class HoSoBenhNhanPage
{
    private System.ComponentModel.IContainer components;
    private FlowLayoutPanel Toolbar;
    private Panel Content;
    private FlowLayoutPanel Footer;
    private Label _pageTitle;
    private TextBox _search;
    private DateTimePicker _from;
    private DateTimePicker _to;
    private CheckBox _allDays;
    private Label _count;
    private PhongKham.Controls.AppGrid _grid;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout1_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout2_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout3_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout4_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout5_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout6_Column;
    private Label _layout7_Label;
    private Label _layout8_Label;
    private AppButton _layout9_Button;
    private AppButton _layout10_create;
    private Panel _layout12_heading;
    private Label _layout13_Label;
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            this.components?.Dispose();
        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        Toolbar = new System.Windows.Forms.FlowLayoutPanel();
        _search = new System.Windows.Forms.TextBox();
        _allDays = new System.Windows.Forms.CheckBox();
        _layout7_Label = new System.Windows.Forms.Label();
        _from = new System.Windows.Forms.DateTimePicker();
        _layout8_Label = new System.Windows.Forms.Label();
        _to = new System.Windows.Forms.DateTimePicker();
        _layout9_Button = new PhongKham.Controls.AppButton();
        _layout10_create = new PhongKham.Controls.AppButton();
        Content = new System.Windows.Forms.Panel();
        _grid = new PhongKham.Controls.AppGrid();
        _layout12_heading = new System.Windows.Forms.Panel();
        _layout13_Label = new System.Windows.Forms.Label();
        _count = new System.Windows.Forms.Label();
        Footer = new System.Windows.Forms.FlowLayoutPanel();
        _pageTitle = new System.Windows.Forms.Label();
        Toolbar.SuspendLayout();
        Content.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _layout12_heading.SuspendLayout();
        SuspendLayout();
        // 
        // Toolbar
        // 
        Toolbar.AutoScroll = true;
        Toolbar.BackColor = System.Drawing.Color.White;
        Toolbar.Controls.Add(_search);
        Toolbar.Controls.Add(_allDays);
        Toolbar.Controls.Add(_layout7_Label);
        Toolbar.Controls.Add(_from);
        Toolbar.Controls.Add(_layout8_Label);
        Toolbar.Controls.Add(_to);
        Toolbar.Controls.Add(_layout9_Button);
        Toolbar.Controls.Add(_layout10_create);
        Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
        Toolbar.Location = new System.Drawing.Point(0, 58);
        Toolbar.Name = "Toolbar";
        Toolbar.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
        Toolbar.Size = new System.Drawing.Size(1100, 105);
        Toolbar.TabIndex = 1;
        // 
        // _search
        // 
        _search.Location = new System.Drawing.Point(15, 8);
        _search.Name = "_search";
        _search.PlaceholderText = "Tên, CCCD, mã hồ sơ…";
        _search.Size = new System.Drawing.Size(220, 25);
        _search.TabIndex = 0;
        _search.KeyDown += _layout11_OnKeyDown;
        // 
        // _allDays
        // 
        _allDays.AutoSize = true;
        _allDays.Checked = true;
        _allDays.CheckState = System.Windows.Forms.CheckState.Checked;
        _allDays.Location = new System.Drawing.Point(241, 8);
        _allDays.Name = "_allDays";
        _allDays.Size = new System.Drawing.Size(98, 23);
        _allDays.TabIndex = 1;
        _allDays.Text = "Tất cả ngày";
        // 
        // _layout7_Label
        // 
        _layout7_Label.AutoSize = true;
        _layout7_Label.Location = new System.Drawing.Point(348, 15);
        _layout7_Label.Margin = new System.Windows.Forms.Padding(6, 10, 0, 0);
        _layout7_Label.Name = "_layout7_Label";
        _layout7_Label.Size = new System.Drawing.Size(82, 19);
        _layout7_Label.TabIndex = 2;
        _layout7_Label.Text = "Từ ngày tạo";
        // 
        // _from
        // 
        _from.CustomFormat = "dd/MM/yyyy";
        _from.Enabled = false;
        _from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        _from.Location = new System.Drawing.Point(433, 8);
        _from.Name = "_from";
        _from.Size = new System.Drawing.Size(140, 25);
        _from.TabIndex = 3;
        // 
        // _layout8_Label
        // 
        _layout8_Label.AutoSize = true;
        _layout8_Label.Location = new System.Drawing.Point(582, 15);
        _layout8_Label.Margin = new System.Windows.Forms.Padding(6, 10, 0, 0);
        _layout8_Label.Name = "_layout8_Label";
        _layout8_Label.Size = new System.Drawing.Size(68, 19);
        _layout8_Label.TabIndex = 4;
        _layout8_Label.Text = "Đến ngày";
        // 
        // _to
        // 
        _to.CustomFormat = "dd/MM/yyyy";
        _to.Enabled = false;
        _to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        _to.Location = new System.Drawing.Point(653, 8);
        _to.Name = "_to";
        _to.Size = new System.Drawing.Size(140, 25);
        _to.TabIndex = 5;
        // 
        // _layout9_Button
        // 
        _layout9_Button.AutoSize = true;
        _layout9_Button.BackColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
        _layout9_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout9_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout9_Button.ForeColor = System.Drawing.Color.White;
        _layout9_Button.Location = new System.Drawing.Point(799, 8);
        _layout9_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout9_Button.Name = "_layout9_Button";
        _layout9_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout9_Button.Size = new System.Drawing.Size(75, 37);
        _layout9_Button.TabIndex = 6;
        _layout9_Button.Text = "Tìm";
        _layout9_Button.UseVisualStyleBackColor = false;
        _layout9_Button.Click += _layout9_Button_Click;
        // 
        // _layout10_create
        // 
        _layout10_create.AutoSize = true;
        _layout10_create.BackColor = System.Drawing.Color.White;
        _layout10_create.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout10_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout10_create.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _layout10_create.Location = new System.Drawing.Point(880, 8);
        _layout10_create.MinimumSize = new System.Drawing.Size(75, 36);
        _layout10_create.Name = "_layout10_create";
        _layout10_create.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout10_create.Size = new System.Drawing.Size(101, 37);
        _layout10_create.TabIndex = 7;
        _layout10_create.Text = "Tạo hồ sơ";
        _layout10_create.UseVisualStyleBackColor = false;
        _layout10_create.Click += _layout10_create_Click;
        // 
        // Content
        // 
        Content.Controls.Add(_grid);
        Content.Controls.Add(_layout12_heading);
        Content.Dock = System.Windows.Forms.DockStyle.Fill;
        Content.Location = new System.Drawing.Point(0, 163);
        Content.Name = "Content";
        Content.Padding = new System.Windows.Forms.Padding(12);
        Content.Size = new System.Drawing.Size(1100, 493);
        Content.TabIndex = 0;
        // 
        // _grid
        // 
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        _grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        _grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        _grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        _grid.BackgroundColor = System.Drawing.Color.White;
        _grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        _grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        _grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)((byte)204)), ((int)((byte)251)), ((int)((byte)241)));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        _grid.DefaultCellStyle = dataGridViewCellStyle3;
        _grid.Dock = System.Windows.Forms.DockStyle.Fill;
        _grid.EnableHeadersVisualStyles = false;
        _grid.Location = new System.Drawing.Point(12, 77);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.RowTemplate.Height = 38;
        _grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new System.Drawing.Size(1076, 404);
        _grid.TabIndex = 0;
        // 
        // _layout12_heading
        // 
        _layout12_heading.Controls.Add(_layout13_Label);
        _layout12_heading.Controls.Add(_count);
        _layout12_heading.Dock = System.Windows.Forms.DockStyle.Top;
        _layout12_heading.Location = new System.Drawing.Point(12, 12);
        _layout12_heading.Name = "_layout12_heading";
        _layout12_heading.Size = new System.Drawing.Size(1076, 65);
        _layout12_heading.TabIndex = 1;
        // 
        // _layout13_Label
        // 
        _layout13_Label.Dock = System.Windows.Forms.DockStyle.Top;
        _layout13_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        _layout13_Label.Location = new System.Drawing.Point(0, 0);
        _layout13_Label.Name = "_layout13_Label";
        _layout13_Label.Size = new System.Drawing.Size(1076, 35);
        _layout13_Label.TabIndex = 0;
        _layout13_Label.Text = "Danh sách hồ sơ bệnh nhân của phòng khám";
        // 
        // _count
        // 
        _count.AutoSize = true;
        _count.Dock = System.Windows.Forms.DockStyle.Bottom;
        _count.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        _count.Location = new System.Drawing.Point(0, 46);
        _count.Name = "_count";
        _count.Size = new System.Drawing.Size(0, 19);
        _count.TabIndex = 1;
        // 
        // Footer
        // 
        Footer.AutoScroll = true;
        Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
        Footer.Location = new System.Drawing.Point(0, 656);
        Footer.Name = "Footer";
        Footer.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
        Footer.Size = new System.Drawing.Size(1100, 64);
        Footer.TabIndex = 3;
        Footer.Visible = false;
        Footer.WrapContents = false;
        // 
        // _pageTitle
        // 
        _pageTitle.Dock = System.Windows.Forms.DockStyle.Top;
        _pageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        _pageTitle.Location = new System.Drawing.Point(0, 0);
        _pageTitle.Name = "_pageTitle";
        _pageTitle.Padding = new System.Windows.Forms.Padding(16, 10, 0, 0);
        _pageTitle.Size = new System.Drawing.Size(1100, 58);
        _pageTitle.TabIndex = 2;
        _pageTitle.Text = "Hồ sơ bệnh nhân";
        // 
        // HoSoBenhNhanPage
        // 
        Controls.Add(Content);
        Controls.Add(Toolbar);
        Controls.Add(_pageTitle);
        Controls.Add(Footer);
        Toolbar.ResumeLayout(false);
        Toolbar.PerformLayout();
        Content.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _layout12_heading.ResumeLayout(false);
        _layout12_heading.PerformLayout();
        ResumeLayout(false);
    }
}
