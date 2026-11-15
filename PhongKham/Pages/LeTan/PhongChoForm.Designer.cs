#nullable disable
using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;

namespace PhongKham.Pages.LeTan;
public sealed partial class PhongChoForm
{
    private System.ComponentModel.IContainer components;
    private TextBox _search;
    private ComboBox _filter;
    private DataGridView _grid;
    private Panel _layout1_content;
    private FlowLayoutPanel _layout2_toolbar;
    private Label _layout3_title;
    private DataGridViewTextBoxColumn _layout4_Column;
    private DataGridViewTextBoxColumn _layout5_Column;
    private DataGridViewTextBoxColumn _layout6_Column;
    private DataGridViewTextBoxColumn _layout7_Column;
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            this.components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this._search = new TextBox();
        this._filter = new ComboBox();
        this._layout1_content = new Panel();
        this._layout2_toolbar = new FlowLayoutPanel();
        this._layout3_title = new Label();
        this._grid = new AppGrid();
        this._layout4_Column = new DataGridViewTextBoxColumn();
        this._layout5_Column = new DataGridViewTextBoxColumn();
        this._layout6_Column = new DataGridViewTextBoxColumn();
        this._layout7_Column = new DataGridViewTextBoxColumn();
        this._search.Name = "_search";
        this._filter.Name = "_filter";
        this._layout1_content.Name = "_layout1_content";
        this._layout2_toolbar.Name = "_layout2_toolbar";
        this._layout3_title.Name = "_layout3_title";
        this._grid.Name = "_grid";
        ((System.ComponentModel.ISupportInitialize)this._grid).BeginInit();
        this._layout1_content.SuspendLayout();
        this._layout2_toolbar.SuspendLayout();
        SuspendLayout();
        this._search.Multiline = false;
        this._search.Height = 32;
        this._search.ScrollBars = ScrollBars.None;
        this._search.Name = "_search";
        this._filter.DropDownStyle = ComboBoxStyle.DropDownList;
        this._filter.Name = "_filter";
        this.ClientSize = new Size(1000, 700);
        this.Text = "Phòng chờ";
        this._layout1_content.Dock = DockStyle.Fill;
        this._layout1_content.Padding = new Padding(16);
        this._layout1_content.Name = "_layout1_content";
        Controls.Add(this._layout1_content);
        this._layout2_toolbar.Dock = DockStyle.Top;
        this._layout2_toolbar.Height = 60;
        this._layout2_toolbar.Name = "_layout2_toolbar";
        this._layout3_title.Text = "Mời STT sau đây vào phòng khám: 1";
        this._layout3_title.Dock = DockStyle.Top;
        this._layout3_title.Height = 100;
        this._layout3_title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this._layout3_title.Name = "_layout3_title";
        Controls.Add(this._layout3_title);
        this._grid.ReadOnly = true;
        this._grid.AllowUserToAddRows = false;
        this._grid.AllowUserToDeleteRows = false;
        this._grid.AutoGenerateColumns = false;
        this._grid.MultiSelect = false;
        this._grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this._grid.RowHeadersVisible = false;
        this._grid.Dock = DockStyle.Fill;
        this._grid.BackgroundColor = Color.White;
        this._grid.BorderStyle = BorderStyle.None;
        this._grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this._grid.EnableHeadersVisualStyles = false;
        this._grid.ColumnHeadersHeight = 40;
        this._grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
        this._grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
        this._grid.DefaultCellStyle.Padding = new Padding(6);
        this._grid.RowTemplate.Height = 38;
        this._grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        this._grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 251, 241);
        this._grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        this._layout4_Column.DataPropertyName = "c0";
        this._layout4_Column.Name = "c0";
        this._layout4_Column.HeaderText = "STT";
        this._layout4_Column.MinimumWidth = 65;
        this._layout4_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout5_Column.DataPropertyName = "c1";
        this._layout5_Column.Name = "c1";
        this._layout5_Column.HeaderText = "Tên bệnh nhân";
        this._layout5_Column.MinimumWidth = 65;
        this._layout5_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout6_Column.DataPropertyName = "c2";
        this._layout6_Column.Name = "c2";
        this._layout6_Column.HeaderText = "Ngày sinh";
        this._layout6_Column.MinimumWidth = 65;
        this._layout6_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout7_Column.DataPropertyName = "c3";
        this._layout7_Column.Name = "c3";
        this._layout7_Column.HeaderText = "Ưu tiên";
        this._layout7_Column.MinimumWidth = 65;
        this._layout7_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._grid.Name = "_grid";
        this._layout1_content.Controls.Add(this._grid);
        this._grid.Columns.AddRange(new DataGridViewColumn[] { this._layout4_Column, this._layout5_Column, this._layout6_Column, this._layout7_Column });
        ((System.ComponentModel.ISupportInitialize)this._grid).EndInit();
        this._layout2_toolbar.ResumeLayout(false);
        this._layout2_toolbar.PerformLayout();
        this._layout1_content.ResumeLayout(false);
        this._layout1_content.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
