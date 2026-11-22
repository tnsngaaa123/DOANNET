using System.ComponentModel;
using System.Drawing.Printing;
using AppDialogs = PhongKham.Core.Dialogs;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Printing;

namespace PhongKham.Pages.Chung.Dialogs;

public sealed partial class InTaiLieuDialog : BaseForm
{
    private PrintDocument[] _documents = Array.Empty<PrintDocument>();
    private TapTaiLieuPrintDocument? _combinedPreview;
    private bool _printing;

    public InTaiLieuDialog() { InitializeComponent(); }

    public InTaiLieuDialog(PrintDocument[] documents) : this()
    {
        if (documents.Length == 0) throw new NghiepVuException("Không có tài liệu để in.");
        _documents = documents;
        foreach (var document in documents)
        {
            if (!document.PrinterSettings.IsValid)
                document.PrinterSettings = DefaultPrinter();
            if (!document.PrinterSettings.IsValid)
                throw new NghiepVuException("Windows chưa có máy in hợp lệ để xem trước. Hãy cài máy in rồi thử lại.");
        }
        _documentList.Items.AddRange(documents.Select(x => (object)(x is PhongKhamPrintDocument p ? p.Mau.TieuDe : x.DocumentName)).ToArray());

        _documentList.SelectedIndex = 0;
        _print.Text = "IN";
    }

    private static PrinterSettings DefaultPrinter()
    {
        var settings = new PrinterSettings();
        bool Virtual(string name) => new[] { "PDF", "XPS", "OneNote", "Fax" }.Any(x => name.Contains(x, StringComparison.OrdinalIgnoreCase));
        if (settings.IsValid && !Virtual(settings.PrinterName)) return settings;
        string? physical = PrinterSettings.InstalledPrinters.Cast<string>().FirstOrDefault(x => !Virtual(x));
        if (physical is not null) settings.PrinterName = physical;
        return settings;
    }

    private void _documentList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        int index = _documentList.SelectedIndex;
        if (index < 0) return;
        if (index < _documents.Length)
            _preview.Document = _documents[index];
        else
        {
            _combinedPreview ??= new TapTaiLieuPrintDocument(_documents.Cast<PhongKhamPrintDocument>().ToArray());
            _preview.Document = _combinedPreview;
        }
        _preview.StartPage = 0;
        _preview.AutoZoom = true;
        _preview.InvalidatePreview();
    }

    private void _print_Click(object? sender, EventArgs e)
    {
        try
        {
            var selected = PrintSelection.Indices(_documents.Length, _documentList.SelectedIndex).Select(i => _documents[i]).ToArray();
            _print.Enabled = _close.Enabled = _documentList.Enabled = false;
            _printing = true;
            UseWaitCursor = true;
            // Tránh bộ xem trước vẽ lại cùng PrintDocument trong lúc driver đang in.
            _preview.Document = null;
            // Bấm IN là lưu PDF ngay, kể cả khi hủy hộp chọn máy in sau đó.
            DateTime printedOn = DateTime.Now;
            foreach (var document in selected.OfType<PhongKhamPrintDocument>())
                PdfExporter.Export(document, printedOn);
            using var choose = new PrintDialog
            {
                Document = selected[0], PrinterSettings = DefaultPrinter(),
                UseEXDialog = true, AllowPrintToFile = false, AllowSomePages = false,
                AllowSelection = false, AllowCurrentPage = false
            };
            if (choose.ShowDialog(this) != DialogResult.OK) return;
            if (!choose.PrinterSettings.IsValid)
                throw new NghiepVuException("Máy in đã chọn không hợp lệ.");
            var printer = (PrinterSettings)choose.PrinterSettings.Clone();
            foreach (var document in selected)
            {
                if (!Submit(document, printer))
                    throw new NghiepVuException("Lệnh in đã bị hủy. Có thể bấm IN để thử lại.");
            }
            _printing = false;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception error) when (error is not OutOfMemoryException and not AccessViolationException)
        {
            Program.Log(error);
            AppDialogs.Warning("Chưa hoàn tất in. " + error.Message + "\nNghiệp vụ đã lưu vẫn được giữ. Kiểm tra máy in và thư mục lưu PDF rồi thử lại.");
        }
        finally
        {
            _printing = false;
            if (!IsDisposed)
            {
                _print.Enabled = _close.Enabled = _documentList.Enabled = true;
                UseWaitCursor = false;
                if (DialogResult != DialogResult.OK) _documentList_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }
    }

    private static bool Submit(PrintDocument document, PrinterSettings selected)
    {
        var pages = (PageSettings)document.DefaultPageSettings.Clone();
        var settings = (PrinterSettings)selected.Clone();
        settings.PrintToFile = false;
        pages.PrinterSettings = settings;
        document.PrinterSettings = settings;
        document.DefaultPageSettings = pages;
        document.PrintController = new PrintControllerWithStatusDialog(new StandardPrintController(), "Đang in tài liệu");
        bool ended = false, cancelled = false;
        void End(object? sender, PrintEventArgs args) { ended = true; cancelled = args.Cancel; }
        document.EndPrint += End;
        try { document.Print(); }
        finally { document.EndPrint -= End; }
        return ended && !cancelled;
    }

    private void _close_Click(object? sender, EventArgs e) => Close();

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (_printing) e.Cancel = true;
        base.OnFormClosing(e);
    }

    private void _previous_Click(object? sender, EventArgs e) => _preview.StartPage = Math.Max(0, _preview.StartPage - 1);
    private void _next_Click(object? sender, EventArgs e) => _preview.StartPage++;
    private void _preview_StartPageChanged(object? sender, EventArgs e)
    {
        _page.Text = "Trang " + (_preview.StartPage + 1);
        _previous.Enabled = _preview.StartPage > 0;
    }
}
    