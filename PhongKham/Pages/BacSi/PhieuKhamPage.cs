using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Core;
using PhongKham.Base;
using PhongKham.Controls;
using PhongKham.Services;
using PhongKham.Pages.Chung.Dialogs;
using PhongKham.Printing;

namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.PhieuKham, "Phiếu khám", PageGroups.DangKham, 20, Roles.BacSi)]
public sealed partial class PhieuKhamPage : BasePage
{
    private int _id, _patient;
    private bool _loaded, _completed, _editable;
    private string _saved = "";
    private System.Windows.Forms.Timer? _saveTimer;
    private string Snapshot() => string.Join("\u001f", _symptoms.Text, _diagnosis.Text, _result.Text, _advice.Text);
    private void AutoSave()
    {
        _saveTimer?.Stop();
        if (!_loaded || !_editable || _completed || Snapshot() == _saved)
            return;
        KhamBenhService.Save(_id, _symptoms.Text, _diagnosis.Text, _result.Text, _advice.Text);
        _saved = Snapshot();
    }

    private void Complete()
    {
        if (!_completed)
        {
            if (!AppDialogs.Confirm("Hoàn tất phiếu khám và mở bản in hóa đơn, đơn thuốc cho bệnh nhân?"))
                return;
            _saveTimer?.Stop();
            KhamBenhService.Save(_id, _symptoms.Text, _diagnosis.Text, _result.Text, _advice.Text, true);
            _completed = true;
            _editable = false;
            _saved = Snapshot();
            foreach (var editor in new[] { _symptoms, _diagnosis, _result, _advice }) editor.ReadOnly = true;
            _layout2_rx.Enabled = false;
        }
        var data = InAnService.CompletedVisit(_id);
        if (Ui.PrintAndArchive(new HoaDonKhamPrintDocument(data), new DonThuocPrintDocument(data)))
            Navigator.Open(PageKeys.DsChoKham);
        else
            _layout10_complete.Text = "In lại hóa đơn và đơn thuốc";
    }

    public override bool CanLeave()
    {
        try
        {
            AutoSave();
            return true;
        }
        catch (NghiepVuException e)
        {
            AppDialogs.Warning(e.Message);
            return false;
        }
    }

    public PhieuKhamPage()
    {
        InitializeComponent();
    }

    protected override void BuildUI()
    {
        _id = (Args as LuotKhamArgs)?.PhieuKhamId ?? KhamBenhService.Active()?.Id ?? 0;
        if (_id == 0)
        {
            foreach (Control child in Content.Controls)
                child.Visible = false;
            Toolbar.Visible = false;
            Footer.Visible = false;
            _emptyState.Visible = true;
            return;
        }

        _saveTimer = RegisterTimer(900, (_, _) =>
        {
            _saveTimer?.Stop();
            Execute(AutoSave);
        }, false);
        foreach (var t in new[]
        {
            _symptoms,
            _diagnosis,
            _result,
            _advice
        }

        )
            t.TextChanged += (_, _) =>
            {
                if (_loaded && _editable)
                {
                    _saveTimer?.Stop();
                    _saveTimer?.Start();
                }
            };
        var data = KhamBenhService.Get(_id);
        _patient = data.BenhNhan.Id;
        _info.Text = data.BenhNhan.HoTen + " · CCCD " + data.BenhNhan.CanCuocCongDan + Environment.NewLine + "Ngày sinh: " + Formatters.Ngay(data.BenhNhan.NgaySinh) + Environment.NewLine + "Dị ứng: " + data.BenhNhan.DiUng + Environment.NewLine + "Tiền sử: " + data.BenhNhan.TienSuBenh;
        _symptoms.Text = data.Phieu.TrieuChung;
        _diagnosis.Text = data.Phieu.ChanDoan;
        _result.Text = data.Phieu.KetQua;
        _advice.Text = data.Phieu.LoiDan;
        _editable = data.Phieu.TrangThai == TrangThai.DangKham;
        foreach (var t in new[]
        {
            _symptoms,
            _diagnosis,
            _result,
            _advice
        }

        )
            t.ReadOnly = !_editable;
        _completed = data.Phieu.TrangThai is TrangThai.ChoThanhToan or TrangThai.ChoXuatThuoc or TrangThai.HoanTat;
        _layout10_complete.Enabled = _editable || _completed;
        _layout2_rx.Enabled = _editable;
        if (_completed) _layout10_complete.Text = "In lại hóa đơn và đơn thuốc";
        _saved = Snapshot();
        _loaded = true;
    }

    private void _layout1_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            AutoSave();
            using var d = new LichSuKhamDialog(_patient);
            d.ShowDialog(this);
        });
    }

    private void _layout2_rx_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            AutoSave();
            Navigator.Open(PageKeys.KeDon, new LuotKhamArgs(_id));
        });
    }

    private void _layout10_complete_Click(object? sender, EventArgs e)
    {
        Ui.Run(Complete);
    }
}
