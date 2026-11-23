#nullable disable
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models.Views;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class KetQuaXuatThuocDialog
{
    private System.ComponentModel.IContainer components;
    private Panel Content;
    private AppButton OkButton;
    private AppButton CancelAction;
    private FlowLayoutPanel _dialogFooter;
    private AppGrid _layout1_grid;
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
        DataGridViewCellStyle _layout1_grid_ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle _layout1_grid_DefaultCellStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle _layout1_grid_AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
        this.components = new System.ComponentModel.Container();
        this.Content = new Panel();
        this.OkButton = new AppButton();
        this.CancelAction = new AppButton();
        this._dialogFooter = new FlowLayoutPanel();
        this._layout1_grid = new AppGrid();
        this._layout2_Column = new DataGridViewTextBoxColumn();
        this._layout3_Column = new DataGridViewTextBoxColumn();
        this._layout4_Column = new DataGridViewTextBoxColumn();
        this._layout5_Column = new DataGridViewTextBoxColumn();
        this.Content.Name = "Content";
        this.OkButton.Name = "OkButton";
        this.CancelAction.Name = "CancelAction";
        this._dialogFooter.Name = "_dialogFooter";
        this._layout1_grid.Name = "_layout1_grid";
        ((System.ComponentModel.ISupportInitialize)this._layout1_grid).BeginInit();
        this.Content.SuspendLayout();
        this._dialogFooter.SuspendLayout();
        SuspendLayout();
        this.Content.Dock = DockStyle.Fill;
        this.Content.Padding = new Padding(16);
        this.OkButton.Text = "Lưu";
        this.OkButton.BackColor = Color.FromArgb(22, 163, 74);
        this.OkButton.ForeColor = Color.White;
        this.OkButton.Click += OkButton_Click;
        this.CancelAction.Text = "Hủy";
        this.CancelAction.DialogResult = DialogResult.Cancel;
        this._dialogFooter.Dock = DockStyle.Bottom;
        this._dialogFooter.Height = 68;
        this._dialogFooter.FlowDirection = FlowDirection.RightToLeft;
        this._dialogFooter.Padding = new Padding(10);
        this._dialogFooter.Controls.Add(this.CancelAction);
        this._dialogFooter.Controls.Add(this.OkButton);
        this.ClientSize = new Size(1000, 580);
        this.OkButton.Text = "Đóng";
        this.CancelAction.Visible = false;
        this._layout1_grid.ReadOnly = true;
        this._layout1_grid.AllowUserToAddRows = false;
        this._layout1_grid.AllowUserToDeleteRows = false;
        this._layout1_grid.AutoGenerateColumns = false;
        this._layout1_grid.MultiSelect = false;
        this._layout1_grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this._layout1_grid.RowHeadersVisible = false;
        this._layout1_grid.Dock = DockStyle.Fill;
        this._layout1_grid.BackgroundColor = Color.White;
        this._layout1_grid.BorderStyle = BorderStyle.None;
        this._layout1_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this._layout1_grid.EnableHeadersVisualStyles = false;
        this._layout1_grid.ColumnHeadersHeight = 40;
        _layout1_grid_ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
        _layout1_grid_ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
        this._layout1_grid.ColumnHeadersDefaultCellStyle = _layout1_grid_ColumnHeadersDefaultCellStyle;
        _layout1_grid_DefaultCellStyle.Padding = new Padding(6);
        _layout1_grid_DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 251, 241);
        _layout1_grid_DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        this._layout1_grid.DefaultCellStyle = _layout1_grid_DefaultCellStyle;
        this._layout1_grid.RowTemplate.Height = 38;
        _layout1_grid_AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        this._layout1_grid.AlternatingRowsDefaultCellStyle = _layout1_grid_AlternatingRowsDefaultCellStyle;
        this._layout2_Column.DataPropertyName = "TenThuoc";
        this._layout2_Column.Name = "_layout2_Column";
        this._layout2_Column.HeaderText = "Thuốc đã xuất";
        this._layout2_Column.MinimumWidth = 65;
        this._layout2_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout3_Column.DataPropertyName = "DonViTinh";
        this._layout3_Column.Name = "_layout3_Column";
        this._layout3_Column.HeaderText = "ĐVT";
        this._layout3_Column.MinimumWidth = 65;
        this._layout3_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout4_Column.DataPropertyName = "SoLuongDaXuat";
        this._layout4_Column.Name = "_layout4_Column";
        this._layout4_Column.HeaderText = "Số lượng đã xuất";
        this._layout4_Column.MinimumWidth = 65;
        this._layout4_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout5_Column.DataPropertyName = "SoLuongCon";
        this._layout5_Column.Name = "_layout5_Column";
        this._layout5_Column.HeaderText = "Số lượng còn trong kho";
        this._layout5_Column.MinimumWidth = 65;
        this._layout5_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.Content.Controls.Add(this._layout1_grid);
        this.Name = "KetQuaXuatThuocDialog";
        this.Text = "Kết quả xuất thuốc";
        Controls.Add(this.Content);
        Controls.Add(this._dialogFooter);
        AcceptButton = this.OkButton;
        CancelButton = this.CancelAction;
        this._layout1_grid.Columns.AddRange(new DataGridViewColumn[] { this._layout2_Column, this._layout3_Column, this._layout4_Column, this._layout5_Column });
        this._layout1_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        this._layout1_grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        this._layout1_grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        this._layout1_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this._layout1_grid.RowTemplate.MinimumHeight = 38;
        this._layout2_Column.MinimumWidth = 130;
        this._layout2_Column.FillWeight = 140;
        ((System.ComponentModel.ISupportInitialize)this._layout1_grid).EndInit();
        this._dialogFooter.ResumeLayout(false);
        this._dialogFooter.PerformLayout();
        this.Content.ResumeLayout(false);
        this.Content.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}

