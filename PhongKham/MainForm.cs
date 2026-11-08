using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;

namespace PhongKham;

public sealed class MainForm : BaseForm
{
    public event EventHandler? LogoutRequested, ChangePasswordRequested;
    private readonly Panel _host = new()
    {
        Dock = DockStyle.Fill
    };
    private readonly SidebarMenu _sidebar = new();
    private readonly Label _title = new()
    {
        Dock = DockStyle.Fill,
        TextAlign = ContentAlignment.MiddleLeft
    };
    public MainForm()
    {
        Text = "PhongKham — Quản lý phòng khám";
        WindowState = FormWindowState.Maximized;
        BuildUI();
        Navigator.Attach(_host, info =>
        {
            _title.Text = info.Group + " / " + info.Title;
            _sidebar.SelectPage(info.Key);
        });
        _sidebar.BuildMenu(Navigator.RegisteredPages);
        Shown += (_, _) => Navigator.Open(PageKeys.TrangChu);
    }

    private void BuildUI()
    {
        var table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 3,
            Margin = Padding.Empty
        };
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Theme.SidebarWidth));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        table.RowStyles.Add(new RowStyle(SizeType.Absolute, 76));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        table.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));
        var side = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Theme.Sidebar,
            Margin = Padding.Empty
        };
        var brand = new Label
        {
            Text = "✚  PHÒNG KHÁM\n     & ĐƠN THUỐC",
            Dock = DockStyle.Top,
            Height = 92,
            Padding = new Padding(16, 18, 0, 0),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 12, FontStyle.Bold)
        };
        side.Controls.Add(_sidebar);
        side.Controls.Add(brand);
        _sidebar.PageSelected += key => Ui.Run(() => Navigator.Open(key));
        table.Controls.Add(side, 0, 0);
        table.SetRowSpan(side, 3);
        var header = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            Padding = new Padding(12),
            BackColor = Theme.Surface
        };
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        header.Controls.Add(_title, 0, 0);
        var account = new FlowLayoutPanel
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            WrapContents = false
        };
        account.Controls.Add(new Label { Text = Roles.TenHienThi(Session.CurrentUser?.VaiTro ?? ""), AutoSize = true, Margin = new Padding(5, 13, 10, 0) });
        Ui.Button(account, "Đổi mật khẩu", () => ChangePasswordRequested?.Invoke(this, EventArgs.Empty));
        Ui.Button(account, "Đăng xuất", () => LogoutRequested?.Invoke(this, EventArgs.Empty));
        header.Controls.Add(account, 1, 0);
        table.Controls.Add(header, 1, 0);
        table.Controls.Add(_host, 1, 1);
        Controls.Add(table);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing && (!Navigator.CanLeave() || !AppDialogs.Confirm("Đóng phiên làm việc?")))
            e.Cancel = true;
        base.OnFormClosing(e);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        Navigator.Detach();
        base.OnFormClosed(e);
    }
}
