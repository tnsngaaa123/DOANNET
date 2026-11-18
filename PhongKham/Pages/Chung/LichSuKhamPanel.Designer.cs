#nullable disable
using PhongKham.Controls;

namespace PhongKham.Pages.Chung;
public sealed partial class LichSuKhamPanel
{
    private System.ComponentModel.IContainer components;
    private PhongKham.Controls.AppGrid _layout1_DataGridView;
    private DataGridViewTextBoxColumn _layout2_Column;
    private DataGridViewTextBoxColumn _layout3_Column;
    private DataGridViewTextBoxColumn _layout4_Column;
    private DataGridViewTextBoxColumn _layout5_Column;

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
        _layout1_DataGridView = new PhongKham.Controls.AppGrid();
        ((System.ComponentModel.ISupportInitialize)_layout1_DataGridView).BeginInit();
        SuspendLayout();
        // 
        // _layout1_DataGridView
        // 
        _layout1_DataGridView.AllowUserToAddRows = false;
        _layout1_DataGridView.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        _layout1_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        _layout1_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        _layout1_DataGridView.BackgroundColor = System.Drawing.Color.White;
        _layout1_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        _layout1_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        _layout1_DataGridView.ColumnHeadersHeight = 40;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)((byte)204)), ((int)((byte)251)), ((int)((byte)241)));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        _layout1_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
        _layout1_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout1_DataGridView.EnableHeadersVisualStyles = false;
        _layout1_DataGridView.Location = new System.Drawing.Point(0, 0);
        _layout1_DataGridView.MultiSelect = false;
        _layout1_DataGridView.Name = "_layout1_DataGridView";
        _layout1_DataGridView.ReadOnly = true;
        _layout1_DataGridView.RowHeadersVisible = false;
        _layout1_DataGridView.RowHeadersWidth = 51;
        _layout1_DataGridView.RowTemplate.Height = 38;
        _layout1_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _layout1_DataGridView.Size = new System.Drawing.Size(201, 0);
        _layout1_DataGridView.TabIndex = 0;
        // 
        // LichSuKhamPanel
        // 
        Controls.Add(_layout1_DataGridView);
        Size = new System.Drawing.Size(201, 0);
        ((System.ComponentModel.ISupportInitialize)_layout1_DataGridView).EndInit();
        ResumeLayout(false);
    }
}