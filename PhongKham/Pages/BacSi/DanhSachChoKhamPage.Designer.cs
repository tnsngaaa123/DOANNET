#nullable disable
using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;

namespace PhongKham.Pages.BacSi;
public sealed partial class DanhSachChoKhamPage
{
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.FlowLayoutPanel Toolbar;
    private System.Windows.Forms.Panel Content;
    private System.Windows.Forms.FlowLayoutPanel Footer;
    private System.Windows.Forms.Label _pageTitle;
    private TextBox _search;
    private ComboBox _filter;
    private PhongKham.Controls.AppGrid _grid;
    private DataGridViewTextBoxColumn _layout1_Column;
    private DataGridViewTextBoxColumn _layout2_Column;
    private DataGridViewTextBoxColumn _layout3_Column;
    private DataGridViewTextBoxColumn _layout4_Column;
    private AppButton _layout5_Button;
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
        _layout5_Button = new PhongKham.Controls.AppButton();
        Content = new System.Windows.Forms.Panel();
        _grid = new PhongKham.Controls.AppGrid();
        Footer = new System.Windows.Forms.FlowLayoutPanel();
        _pageTitle = new System.Windows.Forms.Label();
        _search = new System.Windows.Forms.TextBox();
        _filter = new System.Windows.Forms.ComboBox();
        Toolbar.SuspendLayout();
        Content.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        SuspendLayout();
        // 
        // Toolbar
        // 
        Toolbar.AutoScroll = true;
        Toolbar.BackColor = System.Drawing.Color.White;
        Toolbar.Controls.Add(_layout5_Button);
        Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
        Toolbar.Location = new System.Drawing.Point(0, 58);
        Toolbar.Name = "Toolbar";
        Toolbar.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
        Toolbar.Size = new System.Drawing.Size(202, 56);
        Toolbar.TabIndex = 1;
        Toolbar.WrapContents = false;
        // 
        // _layout5_Button
        // 
        _layout5_Button.AutoSize = true;
        _layout5_Button.BackColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
        _layout5_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout5_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout5_Button.ForeColor = System.Drawing.Color.White;
        _layout5_Button.Location = new System.Drawing.Point(15, 8);
        _layout5_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout5_Button.Name = "_layout5_Button";
        _layout5_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout5_Button.Size = new System.Drawing.Size(205, 37);
        _layout5_Button.TabIndex = 0;
        _layout5_Button.Text = "Khám bệnh nhân tiếp theo";
        _layout5_Button.UseVisualStyleBackColor = false;
        _layout5_Button.Click += _layout5_Button_Click;
        // 
        // Content
        // 
        Content.Controls.Add(_grid);
        Content.Dock = System.Windows.Forms.DockStyle.Fill;
        Content.Location = new System.Drawing.Point(0, 114);
        Content.Name = "Content";
        Content.Padding = new System.Windows.Forms.Padding(12);
        Content.Size = new System.Drawing.Size(202, 0);
        Content.TabIndex = 0;
        // 
        // _grid
        // 
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        _grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        _grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        _grid.BackgroundColor = System.Drawing.Color.White;
        _grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        _grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        _grid.ColumnHeadersHeight = 40;
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
        _grid.Location = new System.Drawing.Point(12, 12);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.RowTemplate.Height = 38;
        _grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new System.Drawing.Size(178, 0);
        _grid.TabIndex = 0;
        // 
        // Footer
        // 
        Footer.AutoScroll = true;
        Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
        Footer.Location = new System.Drawing.Point(0, -64);
        Footer.Name = "Footer";
        Footer.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
        Footer.Size = new System.Drawing.Size(202, 64);
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
        _pageTitle.Size = new System.Drawing.Size(202, 58);
        _pageTitle.TabIndex = 2;
        _pageTitle.Text = "Danh sách chờ khám";
        // 
        // _search
        // 
        _search.Location = new System.Drawing.Point(0, 0);
        _search.Name = "_search";
        _search.Size = new System.Drawing.Size(100, 23);
        _search.TabIndex = 0;
        // 
        // _filter
        // 
        _filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        _filter.Location = new System.Drawing.Point(0, 0);
        _filter.Name = "_filter";
        _filter.Size = new System.Drawing.Size(121, 23);
        _filter.TabIndex = 0;
        // 
        // DanhSachChoKhamPage
        // 
        Controls.Add(Content);
        Controls.Add(Toolbar);
        Controls.Add(_pageTitle);
        Controls.Add(Footer);
        Size = new System.Drawing.Size(202, 0);
        Toolbar.ResumeLayout(false);
        Toolbar.PerformLayout();
        Content.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ResumeLayout(false);
    }
}
