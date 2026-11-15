using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;

namespace PhongKham;

public sealed partial class MainForm : BaseForm
{
    public event EventHandler? LogoutRequested, ChangePasswordRequested;
    
    
    
    

    

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (DesignTimeSupport.IsDesignMode(this)) { base.OnFormClosing(e); return; }
        if (e.CloseReason == CloseReason.UserClosing && (!Navigator.CanLeave() || !AppDialogs.Confirm("Đóng phiên làm việc?")))
            e.Cancel = true;
        base.OnFormClosing(e);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (DesignTimeSupport.IsDesignMode(this)) { base.OnFormClosed(e); return; }
        Navigator.Detach();
        base.OnFormClosed(e);
    }
    public MainForm()
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime();
    }
    private void InitializeRuntime()
    {

        _sidebar.PageSelected += key => Ui.Run(() => Navigator.Open(key));
        _layout6_Label.Text = Roles.TenHienThi(Session.CurrentUser?.VaiTro ?? "");
        Navigator.Attach(_host, info =>
        {
            _title.Text = info.Group + " / " + info.Title;
            _sidebar.SelectPage(info.Key);
        });
        _sidebar.BuildMenu(Navigator.RegisteredPages);
        Shown += (_, _) => Navigator.Open(PageKeys.TrangChu);
    }

    private void _layout7_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => ChangePasswordRequested?.Invoke(this, EventArgs.Empty));
    }
    private void _layout8_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() => LogoutRequested?.Invoke(this, EventArgs.Empty));
    }
}