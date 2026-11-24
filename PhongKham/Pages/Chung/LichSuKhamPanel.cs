using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Pages.Chung;
public sealed partial class LichSuKhamPanel : UserControl
{
    public LichSuKhamPanel()
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this))
            InitializeRuntime();
    }

    public LichSuKhamPanel(int patient) : this()
    {
        LoadPatient(patient);
    }

    public void LoadPatient(int patient)
    {
        if (PhongKham.Core.DesignTimeSupport.IsDesignMode(this))
            return;
        Ui.Bind(_visits, BenhNhanService.History(patient));
    }

    private void InitializeRuntime()
    {
        Ui.ConfigureGridFormatting(_visits);
        Ui.ConfigureGridFormatting(_drugs);
        _visits.SelectionChanged += (_, _) => Ui.Run(() =>
        {
            if (_visits.CurrentRow?.DataBoundItem is not LichSuKhamRow x)
                return;
            ShowVisit(x.PhieuKhamId);
        });
    }

    private void _viewVisit_Click(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != _viewVisit.Index)
            return;
        if (_visits.Rows[e.RowIndex].DataBoundItem is LichSuKhamRow visit)
            Ui.Run(() => ShowVisit(visit.PhieuKhamId));
    }

    private void ShowVisit(int visit)
    {
        var d = BenhNhanService.HistoryDetail(visit);
        _info.Text = "Ngày khám: " + Formatters.Ngay(d.Phieu.NgayKham) + Environment.NewLine + "Bác sĩ: " + d.TenBacSi + Environment.NewLine + Environment.NewLine + "Triệu chứng: " + d.Phieu.TrieuChung + Environment.NewLine + Environment.NewLine + "Chẩn đoán: " + d.Phieu.ChanDoan + Environment.NewLine + Environment.NewLine + "Kết quả khám: " + d.Phieu.KetQua + Environment.NewLine + Environment.NewLine + "Lời dặn: " + d.Phieu.LoiDan;
        Ui.Bind(_drugs, d.CacThuoc);
    }
}