using System.Drawing.Printing;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Models.Views;
using PhongKham.Services;

namespace PhongKham.Printing;

public sealed class PhieuSoPrintDocument : PrintDocument
{
    private readonly List<PhieuSoData> _tickets;
    private int _index;
    private bool _preview;
    public PhieuSoPrintDocument(IEnumerable<PhieuSoData> tickets)
    {
        _tickets = tickets.ToList();
        DocumentName = "Số khám PhongKham";
    }

    protected override void OnBeginPrint(PrintEventArgs e)
    {
        _index = 0;
        _preview = PrintController.IsPreview;
        if (_tickets.Count == 0)
            e.Cancel = true;
    }

    protected override void OnPrintPage(PrintPageEventArgs e)
    {
        if (e.Graphics is null || _index >= _tickets.Count)
            return;
        var data = _tickets[_index];
        var p = data.LuotKham;
        using var body = new Font("Segoe UI", 11);
        using var heading = new Font("Segoe UI", 13, FontStyle.Bold);
        using var large = new Font("Segoe UI", 62, FontStyle.Bold);
        float width = Math.Min(390, e.MarginBounds.Width);
        float x = e.MarginBounds.Left + (e.MarginBounds.Width - width) / 2;
        float y = e.MarginBounds.Top;
        using var center = new StringFormat { Alignment = StringAlignment.Center };
        void Write(string text, Font font, bool centered = false)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            float height = e.Graphics.MeasureString(text, font, (int)width).Height + 4;
            e.Graphics.DrawString(text, font, Brushes.Black, new RectangleF(x, y, width, height), centered ? center : StringFormat.GenericDefault);
            y += height + 8;
        }
        Write(data.TenPhongKham, heading, true);
        Write("Địa chỉ: " + data.DiaChi, body, true);
        Write("Điện thoại: " + data.SoDienThoai, body, true);
        e.Graphics.DrawLine(Pens.Gray, x, y, x + width, y);
        y += 12;
        Write("PHIẾU SỐ KHÁM", heading, true);
        Write(p.Phieu.SoThuTu.ToString(), large, true);
        foreach (var text in new[]
        {
            p.BenhNhan.HoTen,
            "Ngày sinh: " + Formatters.Ngay(p.BenhNhan.NgaySinh),
            "Bác sĩ: " + p.TenBacSi,
            "Ngày khám: " + Formatters.Ngay(p.Phieu.NgayKham),
            "Mã lượt: " + p.Phieu.MaPhieuKham,
            p.Phieu.UuTien ? "ƯU TIÊN" : "",
            "Vui lòng theo dõi tại màn hình chờ."
        }

        )
        {
            Write(text, body);
        }

        _index++;
        e.HasMorePages = _index < _tickets.Count;
    }

    protected override void OnEndPrint(PrintEventArgs e)
    {
        base.OnEndPrint(e);
        // Xem trước/cancel không được coi là đã in. Đây là ghi nhận lệnh in hoàn tất, không cảm biến giấy.
        if (!_preview && !e.Cancel && _index == _tickets.Count && _index > 0)
            Ui.Run(() => InAnService.MarkTicketsPrinted(_tickets.Select(t => t.LuotKham.Phieu.Id)));
    }
}
