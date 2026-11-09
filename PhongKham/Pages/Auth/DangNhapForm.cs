using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Pages.Auth;

[PageInfo(PageKeys.DangNhap, "Đăng nhập", "", 0, ShowInMenu = false)]
public sealed class DangNhapForm : BaseForm
{
    private readonly TextBox _login = Ui.Text(), _password = Ui.Text();
    public DangNhapForm()
    {
        Text = "Đăng nhập | Phòng khám";
        ClientSize = new Size(540, 680);
        MinimumSize = new Size(460, 500);
        MaximizeBox = false;
        Font = new Font("Segoe UI", 11);
        BackColor = Theme.Background;
        Padding = new Padding(24);
        BuildUI();
    }
    private void BuildUI()
    {
        var card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, AutoScroll = true };
        var stack = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 1, Padding = new Padding(30, 22, 30, 24) };
        stack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        void Add(Control control, int height)
        {
            int row = stack.RowCount++;
            stack.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            control.Margin = Padding.Empty;
            stack.Controls.Add(control, 0, row);
        }
        Add(new LogoMark { Size = new Size(46, 46), Anchor = AnchorStyles.None }, 58);
        Add(new Label { Text = "PHÒNG KHÁM", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = Theme.TitleFont, ForeColor = Theme.Primary }, 42);
        Add(new Label { Text = "Quản lý phòng khám & đơn thuốc", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Theme.Muted }, 28);
        Add(new Panel(), 18);
        Add(new Label { Text = "Tài khoản", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 27);
        _login.AutoSize = false;
        _login.Dock = DockStyle.Fill;
        _login.PlaceholderText = "Nhập tên đăng nhập";
        Add(_login, 40);
        Add(new Panel(), 14);
        Add(new Label { Text = "Mật khẩu", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 27);
        _password.AutoSize = false;
        _password.Dock = DockStyle.Fill;
        _password.UseSystemPasswordChar = true;
        _password.PlaceholderText = "Nhập mật khẩu";
        Add(_password, 40);
        Add(new Panel(), 24);
        var role=Ui.Combo();
        Ui.Choices(role,Roles.All.Select(r=>(r,Roles.TenHienThi(r))).ToArray());
        Add(new Label { Text="Vai trò",Dock=DockStyle.Fill },27);
        Add(role,36);
        var login = new AppButton("Đăng nhập", AppButtonStyle.Primary) { Dock = DockStyle.Fill, AutoSize = false };
        login.Click += (_, _) => Ui.Run(() => { Session.Start(new NguoiDung { Id=0,TenDangNhap="giaodien",HoTen="",VaiTro=Ui.Value(role),TrangThai=true }); DialogResult = DialogResult.OK; Close(); });
        Add(login, 44);
        Add(new Panel(), 12);
        var exit = new LinkLabel { Text = "Thoát", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, LinkColor = Theme.Muted };
        exit.LinkClicked += (_, _) => Close();
        Add(exit, 28);
        card.Controls.Add(stack);
        Controls.Add(card);
        AcceptButton = login;
        Shown += (_, _) => _login.Focus();
    }
}
