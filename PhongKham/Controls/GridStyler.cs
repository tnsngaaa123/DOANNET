using PhongKham.Core;

namespace PhongKham.Controls;

public static class GridStyler
{
    public static void Apply(DataGridView g)
    {
        g.ReadOnly = true;
        g.AllowUserToAddRows = false;
        g.AllowUserToDeleteRows = false;
        g.AutoGenerateColumns = false;
        g.MultiSelect = false;
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        g.RowHeadersVisible = false;
        g.Dock = DockStyle.Fill;
        g.BackgroundColor = Theme.Surface;
        g.BorderStyle = BorderStyle.None;
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        g.EnableHeadersVisualStyles = false;
        g.ColumnHeadersHeight = 40;
        g.ColumnHeadersDefaultCellStyle.BackColor = Theme.Border;
        g.ColumnHeadersDefaultCellStyle.ForeColor = Theme.Text;
        g.DefaultCellStyle.Padding = new Padding(6);
        g.RowTemplate.Height = 38;
        g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 251, 241);
        g.DefaultCellStyle.SelectionForeColor = Theme.Text;
    }

    public static void Add(DataGridView g, string property, string title) => g.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = property, Name = property, HeaderText = title, MinimumWidth = 65, SortMode = DataGridViewColumnSortMode.NotSortable });
}