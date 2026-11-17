#nullable disable
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;

namespace PhongKham.Pages.Chung.Dialogs;
public sealed partial class KetQuaXuatThuocDialog
{
    private System.ComponentModel.IContainer components;
    private Panel Content;
    private AppButton OkButton;
    private AppButton CancelAction;
    private FlowLayoutPanel _dialogFooter;
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
        this.Content = new Panel();
        this.OkButton = new AppButton();
        this.CancelAction = new AppButton();
        this._dialogFooter = new FlowLayoutPanel();
        this._layout1_DataGridView = new AppGrid();
        this._layout2_Column = new DataGridViewTextBoxColumn();
        this._layout3_Column = new DataGridViewTextBoxColumn();
        this._layout4_Column = new DataGridViewTextBoxColumn();
        this._layout5_Column = new DataGridViewTextBoxColumn();
        this.Content.Name = "Content";
        this.OkButton.Name = "OkButton";
        this.CancelAction.Name = "CancelAction";
        this._dialogFooter.Name = "_dialogFooter";
        this._layout1_DataGridView.Name = "_layout1_DataGridView";
        ((System.ComponentModel.ISupportInitialize)this._layout1_DataGridView).BeginInit();
        this.Content.SuspendLayout();
        this._dialogFooter.SuspendLayout();
        SuspendLayout();
        this.Content.Name = "Content";
        this.Content.Dock = DockStyle.Fill;
        this.Content.Padding = new Padding(16);
        this.OkButton.Name = "OkButton";
        this.OkButton.Text = "Lưu";
        this.OkButton.BackColor = Color.FromArgb(22, 163, 74);
        this.OkButton.ForeColor = Color.White;
        this.OkButton.Click += OkButton_Click;
        this.CancelAction.Name = "CancelAction";
        this.CancelAction.Text = "Hủy";
        this.CancelAction.DialogResult = DialogResult.Cancel;
        this._dialogFooter.Name = "_dialogFooter";
        this._dialogFooter.Dock = DockStyle.Bottom;
        this._dialogFooter.Height = 68;
        this._dialogFooter.FlowDirection = FlowDirection.RightToLeft;
        this._dialogFooter.Padding = new Padding(10);
        this._dialogFooter.Controls.Add(this.CancelAction);
        this._dialogFooter.Controls.Add(this.OkButton);
        this.Text = "Kết quả xuất thuốc";
        this.ClientSize = new Size(900, 620);
        this.OkButton.Text = "Đóng";
        this.CancelAction.Visible = false;
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
        this._layout2_Column.HeaderText = "Tên thuốc";
        this._layout2_Column.MinimumWidth = 65;
        this._layout2_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout3_Column.DataPropertyName = "c1";
        this._layout3_Column.Name = "c1";
        this._layout3_Column.HeaderText = "ĐVT";
        this._layout3_Column.MinimumWidth = 65;
        this._layout3_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout4_Column.DataPropertyName = "c2";
        this._layout4_Column.Name = "c2";
        this._layout4_Column.HeaderText = "Số lượng đã xuất";
        this._layout4_Column.MinimumWidth = 65;
        this._layout4_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout5_Column.DataPropertyName = "c3";
        this._layout5_Column.Name = "c3";
        this._layout5_Column.HeaderText = "Số lượng còn trong kho";
        this._layout5_Column.MinimumWidth = 65;
        this._layout5_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        this._layout1_DataGridView.Name = "_layout1_DataGridView";
        this.Content.Controls.Add(this._layout1_DataGridView);
        Controls.Add(this.Content);
        Controls.Add(this._dialogFooter);
        AcceptButton = this.OkButton;
        CancelButton = this.CancelAction;
        this._layout1_DataGridView.Columns.AddRange(new DataGridViewColumn[] { this._layout2_Column, this._layout3_Column, this._layout4_Column, this._layout5_Column });
        ((System.ComponentModel.ISupportInitialize)this._layout1_DataGridView).EndInit();
        this._dialogFooter.ResumeLayout(false);
        this._dialogFooter.PerformLayout();
        this.Content.ResumeLayout(false);
        this.Content.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
