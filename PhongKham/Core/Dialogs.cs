namespace PhongKham.Core;

public static class Dialogs
{
    public static void Info(string text) => MessageBox.Show(text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    public static void Warning(string text) => MessageBox.Show(text, "Cần kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    public static void Error(string text) => MessageBox.Show(text, "Lỗi ứng dụng", MessageBoxButtons.OK, MessageBoxIcon.Error);
    public static bool Confirm(string text) => MessageBox.Show(text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    public static string? Prompt(string title, string initial = "", bool secret = false)
    {
        using var form = Make(title);
        var txt = new TextBox
        {
            Text = initial,
            UseSystemPasswordChar = secret,
            Dock = DockStyle.Top,
            Margin = new Padding(0, 12, 0, 12)
        };
        form.Controls.Add(txt);
        txt.BringToFront();
        return form.ShowDialog(Form.ActiveForm) == DialogResult.OK ? txt.Text : null;
    }

    public static int? Select(string title, IEnumerable<(int Id, string Text)> values)
    {
        using var form = Make(title);
        var box = new ComboBox
        {
            Dock = DockStyle.Top,
            DropDownStyle = ComboBoxStyle.DropDownList,
            DisplayMember = "Text",
            ValueMember = "Id",
            DataSource = values.Select(x => new Item(x.Id, x.Text)).ToList()
        };
        form.Controls.Add(box);
        box.BringToFront();
        return form.ShowDialog(Form.ActiveForm) == DialogResult.OK && box.SelectedValue is int id ? id : null;
    }

    private sealed record Item(int Id, string Text);
    private static Form Make(string title)
    {
        var f = new Form
        {
            Text = title,
            ClientSize = new Size(460, 130),
            StartPosition = FormStartPosition.CenterParent,
            Font = Theme.BodyFont,
            Padding = new Padding(20),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };
        var bar = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 38,
            FlowDirection = FlowDirection.RightToLeft
        };
        var ok = new Button
        {
            Text = "Đồng ý",
            DialogResult = DialogResult.OK,
            AutoSize = true
        };
        var cancel = new Button
        {
            Text = "Hủy",
            DialogResult = DialogResult.Cancel,
            AutoSize = true
        };
        bar.Controls.Add(ok);
        bar.Controls.Add(cancel);
        f.Controls.Add(bar);
        f.AcceptButton = ok;
        f.CancelButton = cancel;
        return f;
    }
}
