#nullable disable
using PhongKham.Controls;

namespace PhongKham.Pages.Chung;
public sealed partial class LichSuKhamPanel
{
    private System.ComponentModel.IContainer components;
    private DataGridView _layout1_DataGridView;
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

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this._layout1_DataGridView = new AppGrid();
        this._layout2_Column = new DataGridViewTextBoxColumn();
        this._layout3_Column = new DataGridViewTextBoxColumn();
        this._layout4_Column = new DataGridViewTextBoxColumn();
        this._layout5_Column = new DataGridViewTextBoxColumn();
        this._layout1_DataGridView.Name = "_layout1_DataGridView";
        ((System.ComponentModel.ISupportInitialize)this._layout1_DataGridView).BeginInit();
        SuspendLayout();
        this.Dock = DockStyle.Fill;
        this._layout1_DataGridView.ReadOnly = true;
        this._layout1_DataGridView.AllowUserToAddRows = false;
        this._layout1_DataGridView.AllowUserToDeleteRows = false;
        this._layout1_DataGridView.AutoGenerateColumns = false;
        this._layout1_DataGridView.MultiSelect = false;
        this._layout1_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this._layout1_DataGridView.RowHeadersVisible = false;
        this._layout1_DataGridView.Dock = DockStyle.Fill;
        this._layout1_DataGridView.BackgroundColor = Color.White;
        this._layout1_DataGridView.BorderStyle = BorderStyle.None;
        this._layout1_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this._layout1_DataGridView.EnableHeadersVisualStyles = false;
        this._layout1_DataGridView.ColumnHeadersHeight = 40;
        this._layout1_DataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
        this._layout1_DataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
        this._layout1_DataGridView.DefaultCellStyle.Padding = new Padding(6);
        this._layout1_DataGridView.RowTemplate.Height = 38;
        this._layout1_DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        this._layout1_DataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 251, 241);
        this._layout1_DataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        this._layout2_Column.DataPropertyName = "c0";
        this._layout2_Column.Name = "c0";
        this._layout2_Column.HeaderText = "Ngày khám";
        this._layout2_Column.MinimumWidth = 65;
        this._layout2_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout3_Column.DataPropertyName = "c1";
        this._layout3_Column.Name = "c1";
        this._layout3_Column.HeaderText = "Triệu chứng";
        this._layout3_Column.MinimumWidth = 65;
        this._layout3_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout4_Column.DataPropertyName = "c2";
        this._layout4_Column.Name = "c2";
        this._layout4_Column.HeaderText = "Chẩn đoán";
        this._layout4_Column.MinimumWidth = 65;
        this._layout4_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout5_Column.DataPropertyName = "c3";
        this._layout5_Column.Name = "c3";````
        this._layout5_Column.HeaderText = "Đơn thuốc";
        this._layout5_Column.MinimumWidth = 65;
        this._layout5_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout1_DataGridView.Name = "_layout1_DataGridView";
        Controls.Add(this._layout1_DataGridView);
        this._layout1_DataGridView.Columns.AddRange(new DataGridViewColumn[] { this._layout2_Column, this._layout3_Column, this._layout4_Column, this._layout5_Column });
        ((System.ComponentModel.ISupportInitialize)this._layout1_DataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
