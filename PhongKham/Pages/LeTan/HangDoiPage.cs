using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Models;
using PhongKham.Models.Views;
using PhongKham.Services;
using PhongKham.Printing;


namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.HangDoi, "Hàng đợi", PageGroups.TiepNhan, 20, Roles.LeTan)]
public sealed partial class HangDoiPage : BasePage
{
    private string _query = "";
    private DateTime _selectedDay = DateTime.Today;
    private int? _selectedDoctor;


    protected override void OnPageShown() => Execute(() =>
    {
        var doctors = NguoiDungService.Doctors();
        doctors.Insert(0, new NguoiDung { Id = 0, HoTen = "Tất cả bác sĩ" });
        Ui.Options(_doctor, doctors);
        Find();
    });
    
    
    

    private void Find()
    {
        _query = _search.Text.Trim();
        _selectedDay = _day.Value.Date;
        _selectedDoctor = Ui.Id(_doctor) == 0 ? null : Ui.Id(_doctor);
        Reload();
    }
    
    private void Reload() => Ui.BindKeep(_grid, HangDoiService.List(_selectedDay, _selectedDoctor, _query), x => x.Id);
    
    public HangDoiPage()
    {
        InitializeComponent();
    }
    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_grid);
        _day.Value = DateTime.Today;
        _layout12_list = new RowActionList<LuotKhamRow>(_grid, x => x.Id, "In số khám", x =>
        {
            Ui.Print(new PhieuSoPrintDocument(new[] { InAnService.Ticket(x.Id) }));
            Reload();
        });
        _layout13_RowActionsHost.Controls.Add(_layout12_list);
        RegisterTimer(2000, (_, _) => Execute(Reload));
    }
    
    private void _layout8_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Find);
    }

    private void _layout10_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            var x = Ui.Selected<LuotKhamRow>(_grid);
            HangDoiService.Priority(x.Id, !x.UuTien);
            Reload();
        });
    }
    private void _layout11_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            var x = Ui.Selected<LuotKhamRow>(_grid);
            var id = AppDialogs.Select("Chọn bác sĩ", NguoiDungService.Doctors().Select(d => (d.Id, d.HoTen)));
            if (id is int b)
            {
                HangDoiService.ChangeDoctor(x.Id, b);
                Reload();
            }
        });
    }
    private void _layout14_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            var tickets = HangDoiService.List(_selectedDay, _selectedDoctor, _query).Where(x => !x.DaInSoKham).Select(x => InAnService.Ticket(x.Id)).ToList();
            if (tickets.Count == 0)
                throw new NghiepVuException("Không có số khám chưa in trong danh sách đang lọc.");
            Ui.Print(new PhieuSoPrintDocument(tickets));
            Reload();
        });
    }
    private void _layout15_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Execute(Find);
            e.SuppressKeyPress = true;
        }
    
    private RowActionList<LuotKhamRow> _layout12_list = null!;
}