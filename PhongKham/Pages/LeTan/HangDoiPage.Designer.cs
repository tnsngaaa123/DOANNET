#nullable disable
using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models;
using PhongKham.Models.Views;
using PhongKham.Services;
using PhongKham.Printing;

namespace PhongKham.Pages.LeTan;
public sealed partial class HangDoiPage
{
    private System.ComponentModel.IContainer components;
    private FlowLayoutPanel Toolbar;
    private Panel Content;
    private FlowLayoutPanel Footer;
    private Label _pageTitle;
    private TextBox _search;
    private DateTimePicker _day;
    private System.Windows.Forms.ComboBox _doctor;
    private PhongKham.Controls.AppGrid _grid;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout1_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout2_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout3_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout4_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout5_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout6_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout7_Column;
    private AppButton _layout8_Button;
    private FlowLayoutPanel _layout9_actions;
    private AppButton _layout10_Button;
    private AppButton _layout11_Button;
    private Panel _layout13_RowActionsHost;
    private AppButton _layout14_Button;
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
        _day = new System.Windows.Forms.DateTimePicker();
        _doctor = new System.Windows.Forms.ComboBox();
        _layout8_Button = new PhongKham.Controls.AppButton();
        Content = new System.Windows.Forms.Panel();
        _layout13_RowActionsHost = new System.Windows.Forms.Panel();
        _grid = new PhongKham.Controls.AppGrid();
        _layout9_actions = new System.Windows.Forms.FlowLayoutPanel();
        _layout10_Button = new PhongKham.Controls.AppButton();
        _layout11_Button = new PhongKham.Controls.AppButton();
        _layout14_Button = new PhongKham.Controls.AppButton();
        Footer = new System.Windows.Forms.FlowLayoutPanel();
        _pageTitle = new System.Windows.Forms.Label();
        Toolbar.SuspendLayout();
        Content.SuspendLayout();
        _layout13_RowActionsHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _layout9_actions.SuspendLayout();
        SuspendLayout();
        // 
        // Toolbar
        // 
        Toolbar.AutoScroll = true;
        Toolbar.BackColor = System.Drawing.Color.White;
        Toolbar.Controls.Add(_search);
        Toolbar.Controls.Add(_day);
        Toolbar.Controls.Add(_doctor);
        Toolbar.Controls.Add(_layout8_Button);
        Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
        Toolbar.Location = new System.Drawing.Point(0, 58);
        Toolbar.Name = "Toolbar";
        Toolbar.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
        Toolbar.Size = new System.Drawing.Size(1100, 56);
        Toolbar.TabIndex = 1;
        Toolbar.WrapContents = false;
        // 
        // _search
        // 
        _search.Location = new System.Drawing.Point(15, 8);
        _search.Name = "_search";
        _search.PlaceholderText = "Tên, CCCD, mã lượt…";
        _search.Size = new System.Drawing.Size(240, 25);
        _search.TabIndex = 0;
        _search.KeyDown += _layout15_OnKeyDown;
        // 
        // _day
        // 
        _day.CustomFormat = "dd/MM/yyyy";
        _day.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        _day.Location = new System.Drawing.Point(261, 8);
        _day.Name = "_day";
        _day.Size = new System.Drawing.Size(200, 25);
        _day.TabIndex = 1;
        // 
        // _doctor
        // 
        _doctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        _doctor.Location = new System.Drawing.Point(467, 8);
        _doctor.Name = "_doctor";
        _doctor.Size = new System.Drawing.Size(180, 25);
        _doctor.TabIndex = 2;
        // 
        // _layout8_Button
        // 
        _layout8_Button.AutoSize = true;
        _layout8_Button.BackColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
        _layout8_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout8_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout8_Button.ForeColor = System.Drawing.Color.White;
        _layout8_Button.Location = new System.Drawing.Point(653, 8);
        _layout8_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout8_Button.Name = "_layout8_Button";
        _layout8_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout8_Button.Size = new System.Drawing.Size(75, 37);
        _layout8_Button.TabIndex = 3;
        _layout8_Button.Text = "Tìm";
        _layout8_Button.UseVisualStyleBackColor = false;
        _layout8_Button.Click += _layout8_Button_Click;
        // 
        // Content
        // 
        Content.Controls.Add(_layout13_RowActionsHost);
        Content.Controls.Add(_layout9_actions);
        Content.Dock = System.Windows.Forms.DockStyle.Fill;
        Content.Location = new System.Drawing.Point(0, 114);
        Content.Name = "Content";
        Content.Padding = new System.Windows.Forms.Padding(12);
        Content.Size = new System.Drawing.Size(1100, 542);
        Content.TabIndex = 0;
        // 
        // _layout13_RowActionsHost
        // 
        _layout13_RowActionsHost.BackColor = System.Drawing.Color.FromArgb(((int)((byte)241)), ((int)((byte)245)), ((int)((byte)249)));
        _layout13_RowActionsHost.Controls.Add(_grid);
        _layout13_RowActionsHost.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout13_RowActionsHost.Location = new System.Drawing.Point(12, 12);
        _layout13_RowActionsHost.Name = "_layout13_RowActionsHost";
        _layout13_RowActionsHost.Size = new System.Drawing.Size(1076, 464);
        _layout13_RowActionsHost.TabIndex = 0;
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
        _grid.RowTemplate.Height = 38;
        _grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new System.Drawing.Size(1076, 464);
        _grid.TabIndex = 0;
        // 
        // _layout9_actions
        // 
        _layout9_actions.AutoScroll = true;
        _layout9_actions.Controls.Add(_layout10_Button);
        _layout9_actions.Controls.Add(_layout11_Button);
        _layout9_actions.Controls.Add(_layout14_Button);
        _layout9_actions.Dock = System.Windows.Forms.DockStyle.Bottom;
        _layout9_actions.Location = new System.Drawing.Point(12, 476);
        _layout9_actions.Name = "_layout9_actions";
        _layout9_actions.Size = new System.Drawing.Size(1076, 54);
        _layout9_actions.TabIndex = 1;
        _layout9_actions.WrapContents = false;
        // 
        // _layout10_Button
        // 
        _layout10_Button.AutoSize = true;
        _layout10_Button.BackColor = System.Drawing.Color.White;
        _layout10_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout10_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout10_Button.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _layout10_Button.Location = new System.Drawing.Point(3, 3);
        _layout10_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout10_Button.Name = "_layout10_Button";
        _layout10_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout10_Button.Size = new System.Drawing.Size(86, 37);
        _layout10_Button.TabIndex = 0;
        _layout10_Button.Text = "Ưu tiên";
        _layout10_Button.UseVisualStyleBackColor = false;
        _layout10_Button.Click += _layout10_Button_Click;
        // 
        // _layout11_Button
        // 
        _layout11_Button.AutoSize = true;
        _layout11_Button.BackColor = System.Drawing.Color.White;
        _layout11_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout11_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout11_Button.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _layout11_Button.Location = new System.Drawing.Point(95, 3);
        _layout11_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout11_Button.Name = "_layout11_Button";
        _layout11_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout11_Button.Size = new System.Drawing.Size(100, 37);
        _layout11_Button.TabIndex = 1;
        _layout11_Button.Text = "Đổi bác sĩ";
        _layout11_Button.UseVisualStyleBackColor = false;
        _layout11_Button.Click += _layout11_Button_Click;
        // 
        // _layout14_Button
        // 
        _layout14_Button.AutoSize = true;
        _layout14_Button.BackColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
        _layout14_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout14_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout14_Button.ForeColor = System.Drawing.Color.White;
        _layout14_Button.Location = new System.Drawing.Point(201, 3);
        _layout14_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout14_Button.Name = "_layout14_Button";
        _layout14_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout14_Button.Size = new System.Drawing.Size(147, 37);
        _layout14_Button.TabIndex = 2;
        _layout14_Button.Text = "In tất cả số khám";
        _layout14_Button.UseVisualStyleBackColor = false;
        _layout14_Button.Click += _layout14_Button_Click;
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
        _pageTitle.Text = "Hàng đợi";
        // 
        // HangDoiPage
        // 
        Controls.Add(Content);
        Controls.Add(Toolbar);
        Controls.Add(_pageTitle);
        Controls.Add(Footer);
        Toolbar.ResumeLayout(false);
        Toolbar.PerformLayout();
        Content.ResumeLayout(false);
        _layout13_RowActionsHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _layout9_actions.ResumeLayout(false);
        _layout9_actions.PerformLayout();
        ResumeLayout(false);
    }
}
