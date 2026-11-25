using System.Drawing.Printing;
using System.Text;
using PhongKham.Core;

namespace PhongKham.Printing;

public static class PdfExporter
{
    public const string PrinterName = "Microsoft Print to PDF";

    public static string Export(PhongKhamPrintDocument document, DateTime printedOn)
    {
        bool available = PrinterSettings.InstalledPrinters.Cast<string>()
            .Any(x => string.Equals(x, PrinterName, StringComparison.OrdinalIgnoreCase));
        if (!available)
            throw new InvalidPrinterException(new PrinterSettings { PrinterName = PrinterName });
        string folder = Path.Combine(AppPaths.PdfDirectory, document.ThuMuc);
        Directory.CreateDirectory(folder);
        string stem = PdfFileNames.Document(document.Mau, printedOn);
        string path = PdfFileNames.AvailablePath(folder, stem);
        var originalPrinter = document.PrinterSettings;
        var originalPage = document.DefaultPageSettings;
        var originalController = document.PrintController;
        try
        {
            var pdfPrinter = new PrinterSettings { PrinterName = PrinterName, PrintToFile = true, PrintFileName = path };
            var page = (PageSettings)originalPage.Clone();
            page.PrinterSettings = pdfPrinter;
            document.PrinterSettings = pdfPrinter;
            document.DefaultPageSettings = page;
            document.PrintController = new StandardPrintController();
            document.Print();
        }
        finally
        {
            document.PrinterSettings = originalPrinter;
            document.DefaultPageSettings = originalPage;
            document.PrintController = originalController;
        }
        for (int attempt = 0; attempt < 50; attempt++)
        {
            try
            {
                if (File.Exists(path))
                {
                    using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    if (stream.Length > 8)
                    {
                        var start = new byte[5];
                        stream.ReadExactly(start);
                        int length = (int)Math.Min(1024, stream.Length);
                        stream.Seek(-length, SeekOrigin.End);
                        var end = new byte[length];
                        stream.ReadExactly(end);
                        if (Encoding.ASCII.GetString(start) == "%PDF-" && Encoding.ASCII.GetString(end).Contains("%%EOF"))
                            return path;
                    }
                }
            }
            catch (IOException) { }
            System.Threading.Thread.Sleep(100);
        }
        throw new IOException("Windows chưa hoàn tất file PDF: " + path);
    }
}
