#nullable disable
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.ThuNgan;
public sealed partial class DanhSachChoThanhToanPage
{
    private System.ComponentModel.IContainer components;
    private FlowLayoutPanel Toolbar;
    private Panel Content;
    private FlowLayoutPanel Footer;
    private Label _pageTitle;
    private PhongKham.Controls.AppGrid _grid;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout1_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout2_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout3_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout4_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout5_Column;
    private Panel _layout7_RowActionsHost;
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
        Content = new System.Windows.Forms.Panel();
        _layout7_RowActionsHost = new System.Windows.Forms.Panel();
        _grid = new PhongKham.Controls.AppGrid();
        Footer = new System.Windows.Forms.FlowLayoutPanel();
        _pageTitle = new System.Windows.Forms.Label();
        Content.SuspendLayout();
        _layout7_RowActionsHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        SuspendLayout();
        // 
        // Toolbar
        // 
        Toolbar.AutoScroll = true;
        Toolbar.BackColor = System.Drawing.Color.White;
        Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
        Toolbar.Location = new System.Drawing.Point(0, 58);
        Toolbar.Name = "Toolbar";
        Toolbar.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
        Toolbar.Size = new System.Drawing.Size(1100, 56);
        Toolbar.TabIndex = 1;
        Toolbar.Visible = false;
        Toolbar.WrapContents = false;
        // 
        // Content
        // 
        Content.Controls.Add(_layout7_RowActionsHost);
        Content.Dock = System.Windows.Forms.DockStyle.Fill;
        Content.Location = new System.Drawing.Point(0, 114);
        Content.Name = "Content";
        Content.Padding = new System.Windows.Forms.Padding(12);
        Content.Size = new System.Drawing.Size(1100, 542);
        Content.TabIndex = 0;
        // 
        // _layout7_RowActionsHost
        // 
        _layout7_RowActionsHost.BackColor = System.Drawing.Color.FromArgb(((int)((byte)241)), ((int)((byte)245)), ((int)((byte)249)));
        _layout7_RowActionsHost.Controls.Add(_grid);
        _layout7_RowActionsHost.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout7_RowActionsHost.Location = new System.Drawing.Point(12, 12);
        _layout7_RowActionsHost.Name = "_layout7_RowActionsHost";
        _layout7_RowActionsHost.Size = new System.Drawing.Size(1076, 518);
        _layout7_RowActionsHost.TabIndex = 0;
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
        _grid.Location = new System.Drawing.Point(0, 0);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.RowHeadersWidth = 51;
        _grid.RowTemplate.Height = 38;
        _grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new System.Drawing.Size(1076, 518);
        _grid.TabIndex = 0;
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
        _pageTitle.Text = "Danh sách chờ thanh toán";
        // 
        // DanhSachChoThanhToanPage
        // 
        Controls.Add(Content);
        Controls.Add(Toolbar);
        Controls.Add(_pageTitle);
        Controls.Add(Footer);
        Content.ResumeLayout(false);
        _layout7_RowActionsHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ResumeLayout(false);
    }
}
