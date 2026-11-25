#nullable disable
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.Chung;
public sealed partial class LichSuKhamPanel
{
    private System.ComponentModel.IContainer components;
    private PhongKham.Controls.AppGrid _visits;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout1_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout2_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout3_Column;
    private DataGridViewButtonColumn _viewVisit;
    private PhongKham.Controls.AppGrid _drugs;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout4_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout5_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout6_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout7_Column;
    private System.Windows.Forms.DataGridViewTextBoxColumn _layout8_Column;
    private System.Windows.Forms.TextBox _info;
    private System.Windows.Forms.Panel _layout9_detail;
    private System.Windows.Forms.Panel _layout10_host;
    private System.Windows.Forms.TableLayoutPanel _layout11_Split;
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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        _visits = new PhongKham.Controls.AppGrid();
        _viewVisit = new System.Windows.Forms.DataGridViewButtonColumn();
        _drugs = new PhongKham.Controls.AppGrid();
        _info = new System.Windows.Forms.TextBox();
        _layout9_detail = new System.Windows.Forms.Panel();
        _layout10_host = new System.Windows.Forms.Panel();
        _layout11_Split = new System.Windows.Forms.TableLayoutPanel();
        ((System.ComponentModel.ISupportInitialize)_visits).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_drugs).BeginInit();
        _layout9_detail.SuspendLayout();
        _layout10_host.SuspendLayout();
        _layout11_Split.SuspendLayout();
        SuspendLayout();
        // 
        // _visits
        // 
        _visits.AllowUserToAddRows = false;
        _visits.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        _visits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        _visits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        _visits.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        _visits.BackgroundColor = System.Drawing.Color.White;
        _visits.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        _visits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        _visits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _visits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { _viewVisit });
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)((byte)204)), ((int)((byte)251)), ((int)((byte)241)));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        _visits.DefaultCellStyle = dataGridViewCellStyle3;
        _visits.Dock = System.Windows.Forms.DockStyle.Fill;
        _visits.EnableHeadersVisualStyles = false;
        _visits.Location = new System.Drawing.Point(3, 3);
        _visits.MultiSelect = false;
        _visits.Name = "_visits";
        _visits.ReadOnly = true;
        _visits.RowHeadersVisible = false;
        _visits.RowTemplate.Height = 38;
        _visits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _visits.Size = new System.Drawing.Size(66, 14);
        _visits.TabIndex = 0;
        _visits.CellContentClick += _viewVisit_Click;
        // 
        // _viewVisit
        // 
        _viewVisit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        _viewVisit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _viewVisit.HeaderText = "";
        _viewVisit.MinimumWidth = 55;
        _viewVisit.Name = "_viewVisit";
        _viewVisit.ReadOnly = true;
        _viewVisit.Text = "👁";
        _viewVisit.ToolTipText = "Xem chi tiết lần khám và đơn thuốc";
        _viewVisit.UseColumnTextForButtonValue = true;
        _viewVisit.Width = 55;
        // 
        // _drugs
        // 
        _drugs.AllowUserToAddRows = false;
        _drugs.AllowUserToDeleteRows = false;
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        _drugs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
        _drugs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        _drugs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        _drugs.BackgroundColor = System.Drawing.Color.White;
        _drugs.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        _drugs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
        _drugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)((byte)204)), ((int)((byte)251)), ((int)((byte)241)));
        dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        _drugs.DefaultCellStyle = dataGridViewCellStyle6;
        _drugs.Dock = System.Windows.Forms.DockStyle.Fill;
        _drugs.EnableHeadersVisualStyles = false;
        _drugs.Location = new System.Drawing.Point(0, 260);
        _drugs.MultiSelect = false;
        _drugs.Name = "_drugs";
        _drugs.ReadOnly = true;
        _drugs.RowHeadersVisible = false;
        _drugs.RowTemplate.Height = 38;
        _drugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _drugs.Size = new System.Drawing.Size(124, 0);
        _drugs.TabIndex = 0;
        // 
        // _info
        // 
        _info.Dock = System.Windows.Forms.DockStyle.Top;
        _info.Location = new System.Drawing.Point(0, 0);
        _info.Multiline = true;
        _info.Name = "_info";
        _info.ReadOnly = true;
        _info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        _info.Size = new System.Drawing.Size(124, 260);
        _info.TabIndex = 1;
        // 
        // _layout9_detail
        // 
        _layout9_detail.Controls.Add(_drugs);
        _layout9_detail.Controls.Add(_info);
        _layout9_detail.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout9_detail.Location = new System.Drawing.Point(75, 3);
        _layout9_detail.Name = "_layout9_detail";
        _layout9_detail.Size = new System.Drawing.Size(124, 14);
        _layout9_detail.TabIndex = 1;
        // 
        // _layout10_host
        // 
        _layout10_host.Controls.Add(_layout11_Split);
        _layout10_host.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout10_host.Location = new System.Drawing.Point(0, 0);
        _layout10_host.Name = "_layout10_host";
        _layout10_host.Size = new System.Drawing.Size(202, 0);
        _layout10_host.TabIndex = 0;
        // 
        // _layout11_Split
        // 
        _layout11_Split.ColumnCount = 2;
        _layout11_Split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
        _layout11_Split.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
        _layout11_Split.Controls.Add(_visits, 0, 0);
        _layout11_Split.Controls.Add(_layout9_detail, 1, 0);
        _layout11_Split.Dock = System.Windows.Forms.DockStyle.Fill;
        _layout11_Split.Location = new System.Drawing.Point(0, 0);
        _layout11_Split.Name = "_layout11_Split";
        _layout11_Split.RowCount = 1;
        _layout11_Split.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        _layout11_Split.Size = new System.Drawing.Size(202, 0);
        _layout11_Split.TabIndex = 0;
        // 
        // LichSuKhamPanel
        // 
        Controls.Add(_layout10_host);
        Size = new System.Drawing.Size(202, 0);
        ((System.ComponentModel.ISupportInitialize)_visits).EndInit();
        ((System.ComponentModel.ISupportInitialize)_drugs).EndInit();
        _layout9_detail.ResumeLayout(false);
        _layout9_detail.PerformLayout();
        _layout10_host.ResumeLayout(false);
        _layout11_Split.ResumeLayout(false);
        ResumeLayout(false);
    }
}
