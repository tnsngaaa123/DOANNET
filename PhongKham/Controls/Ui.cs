using System.ComponentModel;
using PhongKham.Core;

namespace PhongKham.Controls;

public static class Ui
{
    public sealed record Choice(string Value, string Text)
    {
        public override string ToString() => Text;
    }

    public static TextBox Text(bool multi = false) => new()
    {
        Multiline = multi,
        Height = multi ? 75 : 32,
        ScrollBars = multi ? ScrollBars.Vertical : ScrollBars.None
    };
    public static NumericUpDown Number(decimal max = 1000000000, int decimals = 0) => new()
    {
        Minimum = 0,
        Maximum = max,
        DecimalPlaces = decimals,
        Increment = decimals > 0 ? 0.5m : 1,
        ThousandsSeparator = true,
        Height = 32
    };
    public static DateTimePicker Date(DateTime date) => new()
    {
        Format = DateTimePickerFormat.Custom,
        CustomFormat = "dd/MM/yyyy",
        Value = date,
        Height = 32
    };
    public static ComboBox Combo() => new()
    {
        DropDownStyle = ComboBoxStyle.DropDownList
    };
    public static void Choices(ComboBox box, params (string Value, string Text)[] rows)
    {
        box.DisplayMember = "Text";
        box.ValueMember = "Value";
        box.DataSource = rows.Select(x => new Choice(x.Value, x.Text)).ToList();
    }

    public static string Value(ComboBox box) => box.SelectedItem is Choice c ? c.Value : Convert.ToString(box.SelectedValue) ?? "";
    public static void Select(ComboBox box, string value)
    {
        for (int i = 0; i < box.Items.Count; i++)
            if (box.Items[i] is Choice c && c.Value == value)
            {
                box.SelectedIndex = i;
                return;
            }
    }

    public static void Options<T>(ComboBox box, IEnumerable<T> rows, string display = "HoTen", string id = "Id")
    {
        box.DisplayMember = display;
        box.ValueMember = id;
        box.DataSource = rows.ToList();
    }

    public static int Id(ComboBox box) => box.SelectedValue is int id ? id : 0;
    public static TableLayoutPanel Form() => new()
    {
        Dock = DockStyle.Top,
        AutoSize = true,
        ColumnCount = 2,
        Padding = new Padding(16),
        BackColor = Theme.Surface,
        ColumnStyles =
        {
            new ColumnStyle(SizeType.Percent, 32),
            new ColumnStyle(SizeType.Percent, 68)
        }
    };
    public static void Field(TableLayoutPanel f, string title, Control editor)
    {
        int row = f.RowCount++;
        f.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        f.Controls.Add(new Label { Text = title, AutoSize = true, Margin = new Padding(4, 10, 8, 4) }, 0, row);
        editor.Dock = DockStyle.Top;
        editor.Margin = new Padding(3, 6, 3, 8);
        f.Controls.Add(editor, 1, row);
    }

    public static Panel Scroll(Control c)
    {
        var p = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true
        };
        p.Controls.Add(c);
        return p;
    }

    public static void Split(Panel parent, Control left, Control right, int leftPercent = 48)
    {
        var t = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1
        };
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, leftPercent));
        t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 - leftPercent));
        left.Dock = DockStyle.Fill;
        right.Dock = DockStyle.Fill;
        t.Controls.Add(left, 0, 0);
        t.Controls.Add(right, 1, 0);
        parent.Controls.Add(t);
    }

    public static DataGridView Grid(params (string Property, string Title)[] columns)
    {
        var g = new AppGrid();
        GridStyler.Apply(g);
        foreach (var col in columns)
            GridStyler.Add(g, col.Property, col.Title);
        g.CellFormatting += (_, e) =>
        {
            if (e.ColumnIndex < 0 || e.Value is null)
                return;
            string n = g.Columns[e.ColumnIndex].DataPropertyName;
            if (e.Value is bool b)
            {
                e.Value = b ? "Có" : "Không";
                e.FormattingApplied = true;
            }
            else if (e.Value is DateTime date)
            {
                e.Value = date.ToString(n is "NgayThanhToan" or "NgayTao" or "InSoKhamLuc" ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy");
                e.FormattingApplied = true;
            }
            else if (n is "TrangThai" or "LoaiKham" or "HinhThuc" or "GioiTinh")
            {
                e.Value = TrangThai.TenHienThi(Convert.ToString(e.Value) ?? "");
                e.FormattingApplied = true;
            }
            else if (n == "VaiTro")
            {
                e.Value = Roles.TenHienThi(Convert.ToString(e.Value) ?? "");
                e.FormattingApplied = true;
            }
            else if (e.Value is long money)
            {
                e.Value = Formatters.Tien(money);
                e.FormattingApplied = true;
            }
        };
        return g;
    }

    public static void RowAction<T>(DataGridView grid, string key, string text, Action<T> action, Func<T, bool>? allowed = null)
        where T : class
    {
        var column = new DataGridViewButtonColumn
        {
            Name = key,
            HeaderText = "",
            Text = text,
            UseColumnTextForButtonValue = true,
            Width = text.Length < 4 ? 55 : 175,
            MinimumWidth = text.Length < 4 ? 55 : 175,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            FlatStyle = FlatStyle.Flat
        };
        grid.Columns.Add(column);
        grid.CellContentClick += (_, e) =>
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || grid.Columns[e.ColumnIndex].Name != key)
                return;
            if (grid.Rows[e.RowIndex].DataBoundItem is T row && (allowed?.Invoke(row) ?? true))
                Run(() => action(row));
        };
        if (allowed is not null)
            grid.CellPainting += (_, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && grid.Columns[e.ColumnIndex].Name == key && grid.Rows[e.RowIndex].DataBoundItem is T row && !allowed(row))
                {
                    e.PaintBackground(e.ClipBounds, true);
                    e.Handled = true;
                }
            };
    }

    private static bool HasSelection(DataGridView grid) => grid is AppGrid appGrid
        ? appGrid.HasUserSelection : grid.SelectedRows.Count > 0;

    public static T Selected<T>(DataGridView grid)
        where T : class => HasSelection(grid) && grid.CurrentRow?.DataBoundItem is T row ? row : throw new NghiepVuException("Chọn một dòng trong danh sách.");
    public static void Bind<T>(DataGridView grid, IEnumerable<T> rows)
    {
        var source = new BindingList<T>(rows.ToList());
        if (grid is AppGrid appGrid)
            appGrid.BindRows(source);
        else
        {
            grid.DataSource = source;
            grid.CurrentCell = null;
            grid.ClearSelection();
        }
    }

    public static void BindKeep<T>(DataGridView grid, IEnumerable<T> rows, Func<T, int> id)
        where T : class
    {
        int? old = HasSelection(grid) && grid.CurrentRow?.DataBoundItem is T current ? id(current) : null;
        Bind(grid, rows);
        if (old is null)
            return;
        foreach (DataGridViewRow row in grid.Rows)
            if (row.DataBoundItem is T x && id(x) == old)
            {
                if (grid is AppGrid appGrid)
                    appGrid.RestoreUserSelection(row.Index);
                else
                    grid.CurrentCell = row.Cells[0];
                break;
            }
    }

    public static void Run(Action action)
    {
        try
        {
            action();
        }
        catch (NghiepVuException e)
        {
            Dialogs.Warning(e.Message);
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException)
        {
            Dialogs.Warning("Không đọc/ghi được file: " + e.Message);
        }
    }

    public static AppButton Button(FlowLayoutPanel bar, string text, Action action, AppButtonStyle style = AppButtonStyle.Secondary)
    {
        var b = new AppButton(text, style);
        b.Click += (_, _) => Run(action);
        bar.Controls.Add(b);
        return b;
    }

}
