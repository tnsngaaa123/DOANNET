using System.Drawing.Printing;
using PhongKham.Models.Views;

namespace PhongKham.Printing;

public class PhongKhamPrintDocument : PrintDocument
{
    internal void BeginPreviewPart(PrintEventArgs e) => OnBeginPrint(e);
    internal void DrawPreviewPart(PrintPageEventArgs e) => OnPrintPage(e);
    public MauBanIn Mau { get; }
    public string ThuMuc { get; }
    private int _page, _introIndex, _row, _rowLine, _closingIndex;
    private bool _signed, _tableStarted;
    private List<string> _intro = new();
    private List<(string Text, bool Bold)> _closing = new();
    private List<List<string>>? _rowLines;
    private bool _prepared;
    private static readonly Color Green = Color.FromArgb(21, 128, 61);

    public PhongKhamPrintDocument(MauBanIn data, string folder, bool landscape = false)
    {
        ArgumentNullException.ThrowIfNull(data);
        if (data.Dong.Count > 0 && data.Cot.Length == 0)
            throw new ArgumentException("Bảng in cần có tiêu đề cột.", nameof(data));
        if (data.TyLeCot.Length > 0 && (data.TyLeCot.Length != data.Cot.Length || data.TyLeCot.Any(x => !float.IsFinite(x) || x <= 0)))
            throw new ArgumentException("Độ rộng các cột in không hợp lệ.", nameof(data));
        Mau = data;
        ThuMuc = folder;
        DocumentName = string.IsNullOrWhiteSpace(data.MaChungTu) ? data.TieuDe : data.MaChungTu;
        DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
        DefaultPageSettings.Margins = new Margins(50, 50, 45, 45);
        DefaultPageSettings.Landscape = landscape;
    }

    protected override void OnBeginPrint(PrintEventArgs e)
    {
        base.OnBeginPrint(e);
        _page = _introIndex = _row = _rowLine = _closingIndex = 0;
        _signed = _tableStarted = _prepared = false;
        _intro.Clear(); _closing.Clear(); _rowLines = null;
    }

    private static List<string> Wrap(Graphics g, string text, Font font, float width)
    {
        var lines = new List<string>();
        foreach (string paragraph in (text ?? "").Replace("\r", "").Split('\n'))
        {
            string rest = paragraph;
            if (rest.Length == 0) lines.Add("");
            while (rest.Length > 0)
            {
                int low = 1, high = rest.Length, count = 1;
                while (low <= high)
                {
                    int middle = low + (high - low) / 2;
                    if (g.MeasureString(rest[..middle], font).Width <= width)
                    { count = middle; low = middle + 1; }
                    else high = middle - 1;
                }
                if (count < rest.Length)
                {
                    int space = rest.LastIndexOf(' ', count - 1, count);
                    if (space > 0) count = space;
                }
                lines.Add(rest[..count]);
                rest = rest[count..].TrimStart();
            }
        }
        return lines;
    }

    private float Header(Graphics g, Rectangle bounds, Font body, Font bold)
    {
        float y = bounds.Top;
        using var green = new SolidBrush(Green);
        using var white = new SolidBrush(Color.White);
        g.FillRectangle(green, bounds.Left, y, 38, 38);
        g.FillRectangle(white, bounds.Left + 16, y + 7, 6, 24);
        g.FillRectangle(white, bounds.Left + 7, y + 16, 24, 6);
        using var clinic = new Font("Segoe UI", 13, FontStyle.Bold);
        float queueWidth = Mau.SoThuTu.HasValue ? Math.Min(250, bounds.Width * .38f) : 0;
        float clinicWidth = bounds.Width - 52 - (queueWidth > 0 ? queueWidth + 14 : 0);
        float clinicHeight = g.MeasureString(Mau.TenPhongKham, clinic, (int)clinicWidth).Height;
        g.DrawString(Mau.TenPhongKham, clinic, green, new RectangleF(bounds.Left + 50, y, clinicWidth, clinicHeight + 2));
        string brand = "QUẢN LÝ KHÁM BỆNH & ĐƠN THUỐC";
        float brandHeight = g.MeasureString(brand, body, (int)clinicWidth).Height;
        g.DrawString(brand, body, Brushes.DimGray, new RectangleF(bounds.Left + 50, y + clinicHeight + 3, clinicWidth, brandHeight + 3));
        float queueHeight = 0;
        if (Mau.SoThuTu.HasValue)
        {
            using var queueFont = new Font("Segoe UI", 16, FontStyle.Bold);
            using var right = new StringFormat { Alignment = StringAlignment.Far };
            string number = "STT: " + Mau.SoThuTu.Value;
            float numberHeight = g.MeasureString(number, queueFont, (int)queueWidth).Height + 3;
            g.DrawString(number, queueFont, green, new RectangleF(bounds.Right - queueWidth, y, queueWidth, numberHeight), right);
            float hintHeight = g.MeasureString(Mau.HuongDanCho, body, (int)queueWidth).Height + 4;
            g.DrawString(Mau.HuongDanCho, body, Brushes.Black, new RectangleF(bounds.Right - queueWidth, y + numberHeight + 2, queueWidth, hintHeight), right);
            queueHeight = numberHeight + hintHeight + 6;
        }
        y += Math.Max(46, Math.Max(clinicHeight + brandHeight + 10, queueHeight));
        using var rule = new Pen(Green, 2);
        g.DrawLine(rule, bounds.Left, y, bounds.Right, y);
        y += 12;
        using var title = new Font("Segoe UI", 15, FontStyle.Bold);
        using var center = new StringFormat { Alignment = StringAlignment.Center };
        float titleHeight = g.MeasureString(Mau.TieuDe, title, bounds.Width).Height;
        g.DrawString(Mau.TieuDe, title, green, new RectangleF(bounds.Left, y, bounds.Width, titleHeight + 3), center);
        y += titleHeight + 5;
        string identity = (Mau.MaChungTu == "" ? "" : "Số: " + Mau.MaChungTu + "    |    ") + "Lập lúc: " + Mau.NgayLap.ToString("dd/MM/yyyy HH:mm");
        foreach (var line in Wrap(g, identity, body, bounds.Width))
        { g.DrawString(line, body, Brushes.DimGray, bounds.Left, y); y += body.GetHeight(g) + 3; }
        return y + 10;
    }

    protected override void OnPrintPage(PrintPageEventArgs e)
    {
        base.OnPrintPage(e);
        if (e.Graphics is null) return;
        var g = e.Graphics;
        var bounds = e.MarginBounds;
        using var body = new Font("Segoe UI", 9);
        using var bold = new Font("Segoe UI", 10, FontStyle.Bold);
        using var small = new Font("Segoe UI", 8);
        float step = body.GetHeight(g) + 5;
        float bottom = bounds.Bottom - 35;
        float y = Header(g, bounds, body, bold);
        if (!_prepared)
        {
            var intro = new List<string>
            {
                "Địa chỉ: " + (string.IsNullOrWhiteSpace(Mau.DiaChi) ? "Chưa cập nhật" : Mau.DiaChi),
                "Điện thoại: " + (string.IsNullOrWhiteSpace(Mau.SoDienThoai) ? "Chưa cập nhật" : Mau.SoDienThoai)
            };
            if (Mau.MoTa.Length > 0) intro.Add(Mau.MoTa);
            intro.AddRange(Mau.ThongTin);
            foreach (var paragraph in intro) _intro.AddRange(Wrap(g, paragraph, body, bounds.Width));
            foreach (var paragraph in Mau.TongKet)
                foreach (var line in Wrap(g, paragraph, bold, bounds.Width)) _closing.Add((line, true));
            if (Mau.GhiChu.Length > 0)
            {
                _closing.Add(("", false));
                foreach (var line in Wrap(g, Mau.GhiChu, body, bounds.Width)) _closing.Add((line, false));
            }
            _prepared = true;
        }
        while (_introIndex < _intro.Count && y + step <= bottom)
        { g.DrawString(_intro[_introIndex++], body, Brushes.Black, bounds.Left, y); y += step; }
        bool tableDone = _row >= Mau.Dong.Count;
        if (_introIndex == _intro.Count)
        {
            y += 9;
            if (Mau.Cot.Length > 0 && (!tableDone || !_tableStarted))
            {
                float total = Mau.TyLeCot.Length == Mau.Cot.Length ? Mau.TyLeCot.Sum() : Mau.Cot.Length;
                var widths = Enumerable.Range(0, Mau.Cot.Length).Select(i => bounds.Width * (Mau.TyLeCot.Length == Mau.Cot.Length ? Mau.TyLeCot[i] : 1) / total).ToArray();
                var headers = Enumerable.Range(0, Mau.Cot.Length).Select(i => Wrap(g, Mau.Cot[i], body, widths[i] - 12)).ToList();
                float headerHeight = headers.Max(h => h.Count) * step + 12;
                if (y + headerHeight + step + 12 <= bottom)
                {
                    float x = bounds.Left;
                    using var headerBrush = new SolidBrush(Color.FromArgb(232, 244, 237));
                    for (int i = 0; i < headers.Count; i++)
                    {
                        g.FillRectangle(headerBrush, x, y, widths[i], headerHeight);
                        g.DrawRectangle(Pens.Silver, x, y, widths[i], headerHeight);
                        for (int j = 0; j < headers[i].Count; j++) g.DrawString(headers[i][j], body, Brushes.Black, x + 6, y + 6 + j * step);
                        x += widths[i];
                    }
                    y += headerHeight;
                    float tableTop = y;
                    _tableStarted = true;
                    if (Mau.Dong.Count == 0)
                    { g.DrawString("Không có dữ liệu.", body, Brushes.DimGray, bounds.Left + 6, y + 6); y += step + 15; }
                    while (_row < Mau.Dong.Count)
                    {
                        if (_rowLines is null)
                            _rowLines = Enumerable.Range(0, Mau.Cot.Length).Select(i => Wrap(g, i < Mau.Dong[_row].Length ? Mau.Dong[_row][i] : "", body, widths[i] - 12)).ToList();
                        int totalLines = _rowLines.Max(l => l.Count);
                        int remaining = totalLines - _rowLine;
                        int available = (int)((bottom - y - 12) / step);
                        if (available < 1) break;
                        if (_rowLine == 0 && remaining > available && y > tableTop && remaining <= (int)((bottom - tableTop - 12) / step)) break;
                        int take = Math.Min(remaining, available);
                        float height = take * step + 12;
                        x = bounds.Left;
                        for (int i = 0; i < Mau.Cot.Length; i++)
                        {
                            if (_row % 2 == 1) g.FillRectangle(Brushes.WhiteSmoke, x, y, widths[i], height);
                            g.DrawRectangle(Pens.Silver, x, y, widths[i], height);
                            for (int j = 0; j < take && _rowLine + j < _rowLines[i].Count; j++)
                                g.DrawString(_rowLines[i][_rowLine + j], body, Brushes.Black, x + 6, y + 6 + j * step);
                            x += widths[i];
                        }
                        y += height;
                        _rowLine += take;
                        if (_rowLine == totalLines) { _row++; _rowLine = 0; _rowLines = null; }
                    }
                }
            }
            tableDone = _row >= Mau.Dong.Count && (Mau.Cot.Length == 0 || _tableStarted);
            if (tableDone)
            {
                y += 12;
                while (_closingIndex < _closing.Count)
                {
                    var line = _closing[_closingIndex];
                    var font = line.Bold ? bold : body;
                    float height = font.GetHeight(g) + 6;
                    if (y + height > bottom) break;
                    g.DrawString(line.Text, font, Brushes.Black, bounds.Left, y);
                    y += height;
                    _closingIndex++;
                }
                float half = bounds.Width / 2;
                float signatureNameHeight = Math.Max(22, g.MeasureString(Mau.TenNguoiLap, body, (int)half - 12).Height + 4);
                float signatureHeight = 70 + signatureNameHeight;
                if (_closingIndex == _closing.Count && !_signed && y + signatureHeight <= bottom)
                {
                    using var center = new StringFormat { Alignment = StringAlignment.Center };
                    g.DrawString(Mau.ChuKyTrai, bold, Brushes.Black, new RectangleF(bounds.Left, y + 8, half, 24), center);
                    g.DrawString(Mau.ChuKyPhai, bold, Brushes.Black, new RectangleF(bounds.Left + half, y + 8, half, 24), center);
                    g.DrawString("(Ký và ghi rõ họ tên)", small, Brushes.DimGray, new RectangleF(bounds.Left, y + 32, half, 20), center);
                    g.DrawString("(Ký và ghi rõ họ tên)", small, Brushes.DimGray, new RectangleF(bounds.Left + half, y + 32, half, 20), center);
                    g.DrawString(Mau.TenNguoiLap, body, Brushes.Black, new RectangleF(bounds.Left + half + 6, y + 67, half - 12, signatureNameHeight), center);
                    _signed = true;
                }
            }
        }
        g.DrawLine(Pens.Silver, bounds.Left, bounds.Bottom - 24, bounds.Right, bounds.Bottom - 24);
        g.DrawString("PhongKham • " + Mau.MaChungTu, small, Brushes.DimGray, bounds.Left, bounds.Bottom - 18);
        string pageText = "Trang " + (++_page);
        float pageWidth = g.MeasureString(pageText, small).Width;
        g.DrawString(pageText, small, Brushes.DimGray, bounds.Right - pageWidth, bounds.Bottom - 18);
        e.HasMorePages = _introIndex < _intro.Count || !tableDone || _closingIndex < _closing.Count || !_signed;
    }
}
