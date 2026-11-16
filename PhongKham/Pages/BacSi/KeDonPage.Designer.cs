#nullable disable
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;

namespace PhongKham.Pages.BacSi;
public sealed partial class KeDonPage
{
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.FlowLayoutPanel Toolbar;
    private System.Windows.Forms.Panel Content;
    private System.Windows.Forms.FlowLayoutPanel Footer;
    private System.Windows.Forms.Label _pageTitle;
    private System.Windows.Forms.TableLayoutPanel _layout1_form;
    private System.Windows.Forms.TextBox _layout2_drug;
    private System.Windows.Forms.Label _layout3_FieldLabel;
    private System.Windows.Forms.NumericUpDown _layout4_NumericUpDown;
    private System.Windows.Forms.Label _layout5_FieldLabel;
    private System.Windows.Forms.TextBox _layout6_TextBox;
    private System.Windows.Forms.Label _layout7_FieldLabel;
    private PhongKham.Controls.AppGrid _layout8_grid;
    private DataGridViewTextBoxColumn _layout9_Column;
    private DataGridViewTextBoxColumn _layout10_Column;
    private DataGridViewTextBoxColumn _layout11_Column;
    private DataGridViewTextBoxColumn _layout12_Column;
    private DataGridViewButtonColumn _layout13_del;
    private System.Windows.Forms.Panel _layout14_Panel;
    private System.Windows.Forms.TableLayoutPanel _layout15_Split;
    private AppButton _layout16_Button;
    private AppButton _layout17_Button;
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
        _layout16_Button = new PhongKham.Controls.AppButton();
        _layout17_Button = new PhongKham.Controls.AppButton();
        Content = new System.Windows.Forms.Panel();
        _layout15_Split = new System.Windows.Forms.TableLayoutPanel();
        _layout14_Panel = new System.Windows.Forms.Panel();
        _layout1_form = new System.Windows.Forms.TableLayoutPanel();
        _layout3_FieldLabel = new System.Windows.Forms.Label();
        _layout2_drug = new System.Windows.Forms.TextBox();
        _layout5_FieldLabel = new System.Windows.Forms.Label();
        _layout4_NumericUpDown = new System.Windows.Forms.NumericUpDown();
        _layout7_FieldLabel = new System.Windows.Forms.Label();
        _layout6_TextBox = new System.Windows.Forms.TextBox();
        _layout8_grid = new PhongKham.Controls.AppGrid();
        _layout13_del = new System.Windows.Forms.DataGridViewButtonColumn();
        Footer = new System.Windows.Forms.FlowLayoutPanel();
        _pageTitle = new System.Windows.Forms.Label();
        Toolbar.SuspendLayout();
        Content.SuspendLayout();
        _layout15_Split.SuspendLayout();
        _layout14_Panel.SuspendLayout();
        _layout1_form.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_layout4_NumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_layout8_grid).BeginInit();
        SuspendLayout();
        // 
        // Toolbar
        // 
        Toolbar.AutoScroll = true;
        Toolbar.BackColor = System.Drawing.Color.White;
        Toolbar.Controls.Add(_layout16_Button);
        Toolbar.Controls.Add(_layout17_Button);
        Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
        Toolbar.Location = new System.Drawing.Point(0, 58);
        Toolbar.Name = "Toolbar";
        Toolbar.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
        Toolbar.Size = new System.Drawing.Size(202, 56);
        Toolbar.TabIndex = 1;
        Toolbar.WrapContents = false;
        // 
        // _layout16_Button
        // 
        _layout16_Button.AutoSize = true;
        _layout16_Button.BackColor = System.Drawing.Color.White;
        _layout16_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout16_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout16_Button.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _layout16_Button.Location = new System.Drawing.Point(15, 8);
        _layout16_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout16_Button.Name = "_layout16_Button";
        _layout16_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout16_Button.Size = new System.Drawing.Size(114, 37);
        _layout16_Button.TabIndex = 0;
        _layout16_Button.Text = "Thêm thuốc";
        _layout16_Button.UseVisualStyleBackColor = false;
        _layout16_Button.Click += _layout16_Button_Click;
        // 
        // _layout17_Button
        // 
        _layout17_Button.AutoSize = true;
        _layout17_Button.BackColor = System.Drawing.Color.White;
        _layout17_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        _layout17_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _layout17_Button.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _layout17_Button.Location = new System.Drawing.Point(135, 8);
        _layout17_Button.MinimumSize = new System.Drawing.Size(75, 36);
        _layout17_Button.Name = "_layout17_Button";
        _layout17_Button.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _layout17_Button.Size = new System.Drawing.Size(77, 37);
        _layout17_Button.TabIndex = 1;
        _layout17_Button.Text = "Trở lại";
        _layout17_Button.UseVisualStyleBackColor = false;
        _layout17_Button.Click += _layout17_Button_Click;
        // 
        // Content
        // 
        Content.Controls.Add(_layout15_Split);
        Content.Dock = System.Windows.Forms.DockStyle.Fill;
        Content.Location = new System.Drawing.Point(0, 114);
        Content.Name = "Content";
        Content.Padding = new System.Windows.Forms.Padding(12);
        Content.Size = new System.Drawing.Size(202, 0);
        Content.TabIndex = 0;
        // 
        // _layout15_Split
        // 
        _layout15_Split.ColumnCount = 2;
        _layout15_Split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
        _layout15_Split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        _layout15_Split.Controls.Add(_layout14_Panel, 0, 0);
        _layout15_Split.Controls.Add(_layout8_grid, 1, 0);
        _layout15_Split.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout15_Split.Location = new System.Drawing.Point(12, 12);
        _layout15_Split.Name = "_layout15_Split";
        _layout15_Split.RowCount = 1;
        _layout15_Split.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        _layout15_Split.Size = new System.Drawing.Size(178, 0);
        _layout15_Split.TabIndex = 0;
        // 
        // _layout14_Panel
        // 
        _layout14_Panel.AutoScroll = true;
        _layout14_Panel.Controls.Add(_layout1_form);
        _layout14_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout14_Panel.Location = new System.Drawing.Point(3, 3);
        _layout14_Panel.Name = "_layout14_Panel";
        _layout14_Panel.Size = new System.Drawing.Size(51, 14);
        _layout14_Panel.TabIndex = 0;
        // 
        // _layout1_form
        // 
        _layout1_form.AutoSize = true;
        _layout1_form.BackColor = System.Drawing.Color.White;
        _layout1_form.ColumnCount = 2;
        _layout1_form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
        _layout1_form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
        _layout1_form.Controls.Add(_layout3_FieldLabel, 0, 0);
        _layout1_form.Controls.Add(_layout2_drug, 1, 0);
        _layout1_form.Controls.Add(_layout5_FieldLabel, 0, 1);
        _layout1_form.Controls.Add(_layout4_NumericUpDown, 1, 1);
        _layout1_form.Controls.Add(_layout7_FieldLabel, 0, 2);
        _layout1_form.Controls.Add(_layout6_TextBox, 1, 2);
        _layout1_form.Dock = System.Windows.Forms.DockStyle.Top;
        _layout1_form.Location = new System.Drawing.Point(0, 0);
        _layout1_form.Name = "_layout1_form";
        _layout1_form.Padding = new System.Windows.Forms.Padding(16);
        _layout1_form.RowCount = 3;
        _layout1_form.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout1_form.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout1_form.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _layout1_form.Size = new System.Drawing.Size(34, 149);
        _layout1_form.TabIndex = 0;
        // 
        // _layout3_FieldLabel
        // 
        _layout3_FieldLabel.AutoSize = true;
        _layout3_FieldLabel.Location = new System.Drawing.Point(20, 26);
        _layout3_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout3_FieldLabel.Name = "_layout3_FieldLabel";
        _layout3_FieldLabel.Size = new System.Drawing.Size(1, 19);
        _layout3_FieldLabel.TabIndex = 0;
        _layout3_FieldLabel.Text = "Tên thuốc";
        // 
        // _layout2_drug
        // 
        _layout2_drug.Dock = System.Windows.Forms.DockStyle.Top;
        _layout2_drug.Location = new System.Drawing.Point(19, 22);
        _layout2_drug.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _layout2_drug.Name = "_layout2_drug";
        _layout2_drug.PlaceholderText = "Gõ tên thuốc";
        _layout2_drug.Size = new System.Drawing.Size(1, 25);
        _layout2_drug.TabIndex = 1;
        // 
        // _layout5_FieldLabel
        // 
        _layout5_FieldLabel.AutoSize = true;
        _layout5_FieldLabel.Location = new System.Drawing.Point(20, 65);
        _layout5_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout5_FieldLabel.Name = "_layout5_FieldLabel";
        _layout5_FieldLabel.Size = new System.Drawing.Size(1, 19);
        _layout5_FieldLabel.TabIndex = 2;
        _layout5_FieldLabel.Text = "Số lượng";
        // 
        // _layout4_NumericUpDown
        // 
        _layout4_NumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
        _layout4_NumericUpDown.Location = new System.Drawing.Point(19, 61);
        _layout4_NumericUpDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _layout4_NumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        _layout4_NumericUpDown.Name = "_layout4_NumericUpDown";
        _layout4_NumericUpDown.Size = new System.Drawing.Size(1, 25);
        _layout4_NumericUpDown.TabIndex = 3;
        _layout4_NumericUpDown.ThousandsSeparator = true;
        // 
        // _layout7_FieldLabel
        // 
        _layout7_FieldLabel.AutoSize = true;
        _layout7_FieldLabel.Location = new System.Drawing.Point(20, 104);
        _layout7_FieldLabel.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _layout7_FieldLabel.Name = "_layout7_FieldLabel";
        _layout7_FieldLabel.Size = new System.Drawing.Size(1, 19);
        _layout7_FieldLabel.TabIndex = 4;
        _layout7_FieldLabel.Text = "Liều dùng";
        // 
        // _layout6_TextBox
        // 
        _layout6_TextBox.Dock = System.Windows.Forms.DockStyle.Top;
        _layout6_TextBox.Location = new System.Drawing.Point(19, 100);
        _layout6_TextBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _layout6_TextBox.Name = "_layout6_TextBox";
        _layout6_TextBox.Size = new System.Drawing.Size(1, 25);
        _layout6_TextBox.TabIndex = 5;
        // 
        // _layout8_grid
        // 
        _layout8_grid.AllowUserToAddRows = false;
        _layout8_grid.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        _layout8_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        _layout8_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        _layout8_grid.BackgroundColor = System.Drawing.Color.White;
        _layout8_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        _layout8_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        _layout8_grid.ColumnHeadersHeight = 40;
        _layout8_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { _layout13_del });
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)((byte)204)), ((int)((byte)251)), ((int)((byte)241)));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        _layout8_grid.DefaultCellStyle = dataGridViewCellStyle3;
        _layout8_grid.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout8_grid.EnableHeadersVisualStyles = false;
        _layout8_grid.Location = new System.Drawing.Point(60, 3);
        _layout8_grid.MultiSelect = false;
        _layout8_grid.Name = "_layout8_grid";
        _layout8_grid.ReadOnly = true;
        _layout8_grid.RowHeadersVisible = false;
        _layout8_grid.RowTemplate.Height = 38;
        _layout8_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _layout8_grid.Size = new System.Drawing.Size(115, 14);
        _layout8_grid.TabIndex = 1;
        // 
        // _layout13_del
        // 
        _layout13_del.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        _layout13_del.HeaderText = "";
        _layout13_del.Name = "_layout13_del";
        _layout13_del.ReadOnly = true;
        _layout13_del.Text = "×";
        _layout13_del.UseColumnTextForButtonValue = true;
        _layout13_del.Width = 50;
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
        _pageTitle.Text = "Kê đơn";
        // 
        // KeDonPage
        // 
        Controls.Add(Content);
        Controls.Add(Toolbar);
        Controls.Add(_pageTitle);
        Controls.Add(Footer);
        Size = new System.Drawing.Size(202, 0);
        Toolbar.ResumeLayout(false);
        Toolbar.PerformLayout();
        Content.ResumeLayout(false);
        _layout15_Split.ResumeLayout(false);
        _layout14_Panel.ResumeLayout(false);
        _layout14_Panel.PerformLayout();
        _layout1_form.ResumeLayout(false);
        _layout1_form.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_layout4_NumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)_layout8_grid).EndInit();
        ResumeLayout(false);
    }
}
