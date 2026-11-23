#nullable disable
using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models;
using PhongKham.Models.Views;
using PhongKham.Services;


namespace PhongKham.Pages.BacSi;
public sealed partial class KeDonPage
{
    private System.ComponentModel.IContainer components;
    private FlowLayoutPanel Toolbar;
    private Panel Content;
    private FlowLayoutPanel Footer;
    private Label _pageTitle;
    private PhongKham.Controls.DrugAutoCompleteBox _auto;
    private PhongKham.Controls.AppGrid _grid;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout1_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout2_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout3_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout4_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout5_Column;
    private System.Windows.Forms.NumericUpDown _qty;
    private System.Windows.Forms.NumericUpDown _days;
    private System.Windows.Forms.NumericUpDown _morning;
    private System.Windows.Forms.NumericUpDown _noon;
    private System.Windows.Forms.NumericUpDown _afternoon;
    private System.Windows.Forms.NumericUpDown _evening;
    private System.Windows.Forms.ComboBox _timing;
    private System.Windows.Forms.TextBox _dose;
    private System.Windows.Forms.Label _chosen;
    private Label _total;
    private AppButton _layout6_save;
    private AppButton _layout7_Button;
    private System.Windows.Forms.TableLayoutPanel _layout8_f;
    private Label _layout9_FieldLabel;
    private Label _layout10_FieldLabel;
    private Label _layout11_FieldLabel;
    private Label _layout12_FieldLabel;
    private Label _layout13_FieldLabel;
    private Label _layout14_FieldLabel;
    private Label _layout15_FieldLabel;
    private Label _layout16_FieldLabel;
    private Label _layout17_FieldLabel;
    private Label _layout18_FieldLabel;
    private System.Windows.Forms.FlowLayoutPanel _layout19_bar;
    private AppButton _layout20_suggest;
    private AppButton _layout21_add;
    private Label _layout22_FieldLabel;
    private Panel _layout23_Panel;
    private System.Windows.Forms.TableLayoutPanel _layout24_Split;
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
        _layout6_save = new PhongKham.Controls.AppButton();
        _layout7_Button = new PhongKham.Controls.AppButton();
        Content = new System.Windows.Forms.Panel();
        _layout24_Split = new System.Windows.Forms.TableLayoutPanel();
        _grid = new PhongKham.Controls.AppGrid();
        _layout23_Panel = new System.Windows.Forms.Panel();
        _layout8_f = new System.Windows.Forms.TableLayoutPanel();
        _layout9_FieldLabel = new System.Windows.Forms.Label();
        _auto = new PhongKham.Controls.DrugAutoCompleteBox();
        _layout10_FieldLabel = new System.Windows.Forms.Label();
        _chosen = new System.Windows.Forms.Label();
        _layout11_FieldLabel = new System.Windows.Forms.Label();
        _morning = new System.Windows.Forms.NumericUpDown();
        _layout12_FieldLabel = new System.Windows.Forms.Label();
        _noon = new System.Windows.Forms.NumericUpDown();
        _layout13_FieldLabel = new System.Windows.Forms.Label();
        _afternoon = new System.Windows.Forms.NumericUpDown();
        _layout14_FieldLabel = new System.Windows.Forms.Label();
        _evening = new System.Windows.Forms.NumericUpDown();
        _layout15_FieldLabel = new System.Windows.Forms.Label();
        _days = new System.Windows.Forms.NumericUpDown();
        _layout16_FieldLabel = new System.Windows.Forms.Label();
        _timing = new System.Windows.Forms.ComboBox();
        _layout17_FieldLabel = new System.Windows.Forms.Label();
        _qty = new System.Windows.Forms.NumericUpDown();
        _layout18_FieldLabel = new System.Windows.Forms.Label();
        _dose = new System.Windows.Forms.TextBox();
        _layout22_FieldLabel = new System.Windows.Forms.Label();
        _layout19_bar = new System.Windows.Forms.FlowLayoutPanel();
        _layout20_suggest = new PhongKham.Controls.AppButton();
        _layout21_add = new PhongKham.Controls.AppButton();
        Footer = new System.Windows.Forms.FlowLayoutPanel();
        _total = new System.Windows.Forms.Label();
        _pageTitle = new System.Windows.Forms.Label();
        Toolbar.SuspendLayout();
        Content.SuspendLayout();
        _layout24_Split.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _layout23_Panel.SuspendLayout();
        _layout8_f.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_morning).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_noon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_afternoon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_evening).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_days).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_qty).BeginInit();
        _layout19_bar.SuspendLayout();
        Footer.SuspendLayout();
        SuspendLayout();
        // 
        // Toolbar
        // 
        Toolbar.AutoScroll = true;
        Toolbar.BackColor = System.Drawing.Color.White;
        Toolbar.Controls.Add(_layout6_save);
        Toolbar.Controls.Add(_layout7_Button);
        Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
        Toolbar.Location = new System.Drawing.Point(0, 58);
        Toolbar.Name = "Toolbar";
        Toolbar.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
        Toolbar.Size = new System.Drawing.Size(1100, 56);
        Toolbar.TabIndex = 1;
        Toolbar.WrapContents = false;
        // 
        // _layout6_save
        // 
        _layout6_save.AutoSize = true;
        _layout6_save.BackColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
        _layout6_save.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout6_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout6_save.ForeColor = System.Drawing.Color.White;
        _layout6_save.Location = new System.Drawing.Point(15, 8);
        _layout6_save.MinimumSize = new System.Drawing.Size(75, 36);
        _layout6_save.Name = "_layout6_save";
        _layout6_save.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout6_save.Size = new System.Drawing.Size(92, 37);
        _layout6_save.TabIndex = 0;
        _layout6_save.Text = "Lưu đơn";
        _layout6_save.UseVisualStyleBackColor = false;
        _layout6_save.Click += _layout6_save_Click;
        // 
        // _layout7_Button
        // 
        _layout7_Button.AutoSize = true;
        _layout7_Button.BackColor = System.Drawing.Color.White;
        _layout7_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout7_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout7_Button.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _layout7_Button.Location = new System.Drawing.Point(113, 8);
        _layout7_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout7_Button.Name = "_layout7_Button";
        _layout7_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout7_Button.Size = new System.Drawing.Size(77, 37);
        _layout7_Button.TabIndex = 1;
        _layout7_Button.Text = "Trở lại";
        _layout7_Button.UseVisualStyleBackColor = false;
        _layout7_Button.Click += _layout7_Button_Click;
        // 
        // Content
        // 
        Content.Controls.Add(_layout24_Split);
        Content.Dock = System.Windows.Forms.DockStyle.Fill;
        Content.Location = new System.Drawing.Point(0, 114);
        Content.Name = "Content";
        Content.Padding = new System.Windows.Forms.Padding(12);
        Content.Size = new System.Drawing.Size(1100, 542);
        Content.TabIndex = 0;
        // 
        // _layout24_Split
        // 
        _layout24_Split.ColumnCount = 2;
        _layout24_Split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
        _layout24_Split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
        _layout24_Split.Controls.Add(_grid, 0, 0);
        _layout24_Split.Controls.Add(_layout23_Panel, 1, 0);
        _layout24_Split.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout24_Split.Location = new System.Drawing.Point(12, 12);
        _layout24_Split.Name = "_layout24_Split";
        _layout24_Split.RowCount = 1;
        _layout24_Split.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        _layout24_Split.Size = new System.Drawing.Size(1076, 518);
        _layout24_Split.TabIndex = 0;
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
        _grid.Location = new System.Drawing.Point(3, 3);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.RowTemplate.Height = 38;
        _grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new System.Drawing.Size(618, 512);
        _grid.TabIndex = 0;
        // 
        // _layout23_Panel
        // 
        _layout23_Panel.AutoScroll = true;
        _layout23_Panel.Controls.Add(_layout8_f);
        _layout23_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout23_Panel.Location = new System.Drawing.Point(627, 3);
        _layout23_Panel.Name = "_layout23_Panel";
        _layout23_Panel.Size = new System.Drawing.Size(446, 512);
        _layout23_Panel.TabIndex = 1;
        // 
        // _layout8_f
        // 
        _layout8_f.AutoSize = true;
        _layout8_f.BackColor = System.Drawing.Color.White;
        _layout8_f.ColumnCount = 2;
        _layout8_f.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
        _layout8_f.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
        _layout8_f.Controls.Add(_layout9_FieldLabel, 0, 0);
        _layout8_f.Controls.Add(_auto, 1, 0);
        _layout8_f.Controls.Add(_layout10_FieldLabel, 0, 1);
        _layout8_f.Controls.Add(_chosen, 1, 1);
        _layout8_f.Controls.Add(_layout11_FieldLabel, 0, 2);
        _layout8_f.Controls.Add(_morning, 1, 2);
        _layout8_f.Controls.Add(_layout12_FieldLabel, 0, 3);
        _layout8_f.Controls.Add(_noon, 1, 3);
        _layout8_f.Controls.Add(_layout13_FieldLabel, 0, 4);
        _layout8_f.Controls.Add(_afternoon, 1, 4);
        _layout8_f.Controls.Add(_layout14_FieldLabel, 0, 5);
        _layout8_f.Controls.Add(_evening, 1, 5);
        _layout8_f.Controls.Add(_layout15_FieldLabel, 0, 6);
        _layout8_f.Controls.Add(_days, 1, 6);
        _layout8_f.Controls.Add(_layout16_FieldLabel, 0, 7);
        _layout8_f.Controls.Add(_timing, 1, 7);
        _layout8_f.Controls.Add(_layout17_FieldLabel, 0, 8);
        _layout8_f.Controls.Add(_qty, 1, 8);
        _layout8_f.Controls.Add(_layout18_FieldLabel, 0, 9);
        _layout8_f.Controls.Add(_dose, 1, 9);
        _layout8_f.Controls.Add(_layout22_FieldLabel, 0, 10);
        _layout8_f.Controls.Add(_layout19_bar, 1, 10);
        _layout8_f.Dock = System.Windows.Forms.DockStyle.Top;
        _layout8_f.Location = new System.Drawing.Point(0, 0);
        _layout8_f.Name = "_layout8_f";
        _layout8_f.Padding = new System.Windows.Forms.Padding(16);
        _layout8_f.RowCount = 11;
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout8_f.Size = new System.Drawing.Size(429, 608);
        _layout8_f.TabIndex = 0;
        // 
        // _layout9_FieldLabel
        // 
        _layout9_FieldLabel.AutoSize = true;
        _layout9_FieldLabel.Location = new System.Drawing.Point(20, 26);
        _layout9_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout9_FieldLabel.Name = "_layout9_FieldLabel";
        _layout9_FieldLabel.Size = new System.Drawing.Size(70, 19);
        _layout9_FieldLabel.TabIndex = 0;
        _layout9_FieldLabel.Text = "Tìm thuốc";
        // 
        // _auto
        // 
        _auto.Dock = System.Windows.Forms.DockStyle.Top;
        _auto.Location = new System.Drawing.Point(146, 22);
        _auto.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _auto.Name = "_auto";
        _auto.Size = new System.Drawing.Size(264, 34);
        _auto.TabIndex = 1;
        // 
        // _layout10_FieldLabel
        // 
        _layout10_FieldLabel.AutoSize = true;
        _layout10_FieldLabel.Location = new System.Drawing.Point(20, 74);
        _layout10_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout10_FieldLabel.Name = "_layout10_FieldLabel";
        _layout10_FieldLabel.Size = new System.Drawing.Size(99, 19);
        _layout10_FieldLabel.TabIndex = 2;
        _layout10_FieldLabel.Text = "Thuốc đã chọn";
        // 
        // _chosen
        // 
        _chosen.AutoSize = true;
        _chosen.Dock = System.Windows.Forms.DockStyle.Top;
        _chosen.Location = new System.Drawing.Point(146, 70);
        _chosen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _chosen.Name = "_chosen";
        _chosen.Size = new System.Drawing.Size(264, 19);
        _chosen.TabIndex = 3;
        // 
        // _layout11_FieldLabel
        // 
        _layout11_FieldLabel.AutoSize = true;
        _layout11_FieldLabel.Location = new System.Drawing.Point(20, 107);
        _layout11_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout11_FieldLabel.Name = "_layout11_FieldLabel";
        _layout11_FieldLabel.Size = new System.Drawing.Size(39, 19);
        _layout11_FieldLabel.TabIndex = 4;
        _layout11_FieldLabel.Text = "Sáng";
        // 
        // _morning
        // 
        _morning.DecimalPlaces = 1;
        _morning.Dock = System.Windows.Forms.DockStyle.Top;
        _morning.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        _morning.Location = new System.Drawing.Point(146, 103);
        _morning.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _morning.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        _morning.Name = "_morning";
        _morning.Size = new System.Drawing.Size(264, 25);
        _morning.TabIndex = 5;
        _morning.ThousandsSeparator = true;
        _morning.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // _layout12_FieldLabel
        // 
        _layout12_FieldLabel.AutoSize = true;
        _layout12_FieldLabel.Location = new System.Drawing.Point(20, 146);
        _layout12_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout12_FieldLabel.Name = "_layout12_FieldLabel";
        _layout12_FieldLabel.Size = new System.Drawing.Size(35, 19);
        _layout12_FieldLabel.TabIndex = 6;
        _layout12_FieldLabel.Text = "Trưa";
        // 
        // _noon
        // 
        _noon.DecimalPlaces = 1;
        _noon.Dock = System.Windows.Forms.DockStyle.Top;
        _noon.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        _noon.Location = new System.Drawing.Point(146, 142);
        _noon.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _noon.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        _noon.Name = "_noon";
        _noon.Size = new System.Drawing.Size(264, 25);
        _noon.TabIndex = 7;
        _noon.ThousandsSeparator = true;
        // 
        // _layout13_FieldLabel
        // 
        _layout13_FieldLabel.AutoSize = true;
        _layout13_FieldLabel.Location = new System.Drawing.Point(20, 185);
        _layout13_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout13_FieldLabel.Name = "_layout13_FieldLabel";
        _layout13_FieldLabel.Size = new System.Drawing.Size(44, 19);
        _layout13_FieldLabel.TabIndex = 8;
        _layout13_FieldLabel.Text = "Chiều";
        // 
        // _afternoon
        // 
        _afternoon.DecimalPlaces = 1;
        _afternoon.Dock = System.Windows.Forms.DockStyle.Top;
        _afternoon.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        _afternoon.Location = new System.Drawing.Point(146, 181);
        _afternoon.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _afternoon.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        _afternoon.Name = "_afternoon";
        _afternoon.Size = new System.Drawing.Size(264, 25);
        _afternoon.TabIndex = 9;
        _afternoon.ThousandsSeparator = true;
        // 
        // _layout14_FieldLabel
        // 
        _layout14_FieldLabel.AutoSize = true;
        _layout14_FieldLabel.Location = new System.Drawing.Point(20, 224);
        _layout14_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout14_FieldLabel.Name = "_layout14_FieldLabel";
        _layout14_FieldLabel.Size = new System.Drawing.Size(27, 19);
        _layout14_FieldLabel.TabIndex = 10;
        _layout14_FieldLabel.Text = "Tối";
        // 
        // _evening
        // 
        _evening.DecimalPlaces = 1;
        _evening.Dock = System.Windows.Forms.DockStyle.Top;
        _evening.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        _evening.Location = new System.Drawing.Point(146, 220);
        _evening.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _evening.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        _evening.Name = "_evening";
        _evening.Size = new System.Drawing.Size(264, 25);
        _evening.TabIndex = 11;
        _evening.ThousandsSeparator = true;
        _evening.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // _layout15_FieldLabel
        // 
        _layout15_FieldLabel.AutoSize = true;
        _layout15_FieldLabel.Location = new System.Drawing.Point(20, 263);
        _layout15_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout15_FieldLabel.Name = "_layout15_FieldLabel";
        _layout15_FieldLabel.Size = new System.Drawing.Size(58, 19);
        _layout15_FieldLabel.TabIndex = 12;
        _layout15_FieldLabel.Text = "Số ngày";
        // 
        // _days
        // 
        _days.Dock = System.Windows.Forms.DockStyle.Top;
        _days.Location = new System.Drawing.Point(146, 259);
        _days.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _days.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
        _days.Name = "_days";
        _days.Size = new System.Drawing.Size(264, 25);
        _days.TabIndex = 13;
        _days.ThousandsSeparator = true;
        _days.Value = new decimal(new int[] { 3, 0, 0, 0 });
        // 
        // _layout16_FieldLabel
        // 
        _layout16_FieldLabel.AutoSize = true;
        _layout16_FieldLabel.Location = new System.Drawing.Point(20, 302);
        _layout16_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout16_FieldLabel.Name = "_layout16_FieldLabel";
        _layout16_FieldLabel.Size = new System.Drawing.Size(69, 19);
        _layout16_FieldLabel.TabIndex = 14;
        _layout16_FieldLabel.Text = "Thời điểm";
        // 
        // _timing
        // 
        _timing.Dock = System.Windows.Forms.DockStyle.Top;
        _timing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        _timing.Location = new System.Drawing.Point(146, 298);
        _timing.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _timing.Name = "_timing";
        _timing.Size = new System.Drawing.Size(264, 25);
        _timing.TabIndex = 15;
        // 
        // _layout17_FieldLabel
        // 
        _layout17_FieldLabel.AutoSize = true;
        _layout17_FieldLabel.Location = new System.Drawing.Point(20, 339);
        _layout17_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout17_FieldLabel.Name = "_layout17_FieldLabel";
        _layout17_FieldLabel.Size = new System.Drawing.Size(63, 19);
        _layout17_FieldLabel.TabIndex = 16;
        _layout17_FieldLabel.Text = "Số lượng";
        // 
        // _qty
        // 
        _qty.Dock = System.Windows.Forms.DockStyle.Top;
        _qty.Location = new System.Drawing.Point(146, 335);
        _qty.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _qty.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        _qty.Name = "_qty";
        _qty.Size = new System.Drawing.Size(264, 25);
        _qty.TabIndex = 17;
        _qty.ThousandsSeparator = true;
        // 
        // _layout18_FieldLabel
        // 
        _layout18_FieldLabel.AutoSize = true;
        _layout18_FieldLabel.Location = new System.Drawing.Point(20, 378);
        _layout18_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout18_FieldLabel.Name = "_layout18_FieldLabel";
        _layout18_FieldLabel.Size = new System.Drawing.Size(70, 19);
        _layout18_FieldLabel.TabIndex = 18;
        _layout18_FieldLabel.Text = "Liều dùng";
        // 
        // _dose
        // 
        _dose.Dock = System.Windows.Forms.DockStyle.Top;
        _dose.Location = new System.Drawing.Point(146, 374);
        _dose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _dose.Multiline = true;
        _dose.Name = "_dose";
        _dose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        _dose.Size = new System.Drawing.Size(264, 110);
        _dose.TabIndex = 19;
        // 
        // _layout22_FieldLabel
        // 
        _layout22_FieldLabel.AutoSize = true;
        _layout22_FieldLabel.Location = new System.Drawing.Point(20, 502);
        _layout22_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout22_FieldLabel.Name = "_layout22_FieldLabel";
        _layout22_FieldLabel.Size = new System.Drawing.Size(0, 19);
        _layout22_FieldLabel.TabIndex = 20;
        // 
        // _layout19_bar
        // 
        _layout19_bar.AutoSize = true;
        _layout19_bar.Controls.Add(_layout20_suggest);
        _layout19_bar.Controls.Add(_layout21_add);
        _layout19_bar.Dock = System.Windows.Forms.DockStyle.Top;
        _layout19_bar.Location = new System.Drawing.Point(146, 498);
        _layout19_bar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _layout19_bar.Name = "_layout19_bar";
        _layout19_bar.Size = new System.Drawing.Size(264, 86);
        _layout19_bar.TabIndex = 21;
        // 
        // _layout20_suggest
        // 
        _layout20_suggest.AutoSize = true;
        _layout20_suggest.BackColor = System.Drawing.Color.White;
        _layout20_suggest.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout20_suggest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout20_suggest.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _layout20_suggest.Location = new System.Drawing.Point(3, 3);
        _layout20_suggest.MinimumSize = new System.Drawing.Size(75, 36);
        _layout20_suggest.Name = "_layout20_suggest";
        _layout20_suggest.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout20_suggest.Size = new System.Drawing.Size(164, 37);
        _layout20_suggest.TabIndex = 0;
        _layout20_suggest.Text = "Gợi ý số lượng / liều";
        _layout20_suggest.UseVisualStyleBackColor = false;
        _layout20_suggest.Click += _layout20_suggest_Click;
        // 
        // _layout21_add
        // 
        _layout21_add.AutoSize = true;
        _layout21_add.BackColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
        _layout21_add.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout21_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout21_add.ForeColor = System.Drawing.Color.White;
        _layout21_add.Location = new System.Drawing.Point(3, 46);
        _layout21_add.MinimumSize = new System.Drawing.Size(75, 36);
        _layout21_add.Name = "_layout21_add";
        _layout21_add.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout21_add.Size = new System.Drawing.Size(180, 37);
        _layout21_add.TabIndex = 1;
        _layout21_add.Text = "Thêm / cập nhật thuốc";
        _layout21_add.UseVisualStyleBackColor = false;
        _layout21_add.Click += _layout21_add_Click;
        // 
        // Footer
        // 
        Footer.AutoScroll = true;
        Footer.Controls.Add(_total);
        Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
        Footer.Location = new System.Drawing.Point(0, 656);
        Footer.Name = "Footer";
        Footer.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
        Footer.Size = new System.Drawing.Size(1100, 64);
        Footer.TabIndex = 3;
        Footer.WrapContents = false;
        // 
        // _total
        // 
        _total.AutoSize = true;
        _total.Location = new System.Drawing.Point(15, 6);
        _total.Name = "_total";
        _total.Size = new System.Drawing.Size(0, 19);
        _total.TabIndex = 0;
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
        _pageTitle.Text = "Kê đơn";
        // 
        // KeDonPage
        // 
        Controls.Add(Content);
        Controls.Add(Toolbar);
        Controls.Add(_pageTitle);
        Controls.Add(Footer);
        Toolbar.ResumeLayout(false);
        Toolbar.PerformLayout();
        Content.ResumeLayout(false);
        _layout24_Split.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _layout23_Panel.ResumeLayout(false);
        _layout23_Panel.PerformLayout();
        _layout8_f.ResumeLayout(false);
        _layout8_f.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_morning).EndInit();
        ((System.ComponentModel.ISupportInitialize)_noon).EndInit();
        ((System.ComponentModel.ISupportInitialize)_afternoon).EndInit();
        ((System.ComponentModel.ISupportInitialize)_evening).EndInit();
        ((System.ComponentModel.ISupportInitialize)_days).EndInit();
        ((System.ComponentModel.ISupportInitialize)_qty).EndInit();
        _layout19_bar.ResumeLayout(false);
        _layout19_bar.PerformLayout();
        Footer.ResumeLayout(false);
        Footer.PerformLayout();
        ResumeLayout(false);
    }
}
