using System.Drawing.Printing;

namespace PhongKham.Printing;
public sealed class TapTaiLieuPrintDocument : PrintDocument
{
    private readonly PhongKhamPrintDocument[] _parts;
    private int _index;

    public TapTaiLieuPrintDocument(PhongKhamPrintDocument[] parts)
    {
        _parts = parts;
        DocumentName = "Hóa đơn và đơn thuốc";
        if (parts.Length > 0)
        {
            PrinterSettings = parts[0].PrinterSettings;
            DefaultPageSettings = (PageSettings)parts[0].DefaultPageSettings.Clone();
        }
    }

    protected override void OnBeginPrint(PrintEventArgs e)
    {
        base.OnBeginPrint(e);
        _index = 0;
        if (_parts.Length == 0) { e.Cancel = true; return; }
        foreach (var part in _parts) part.BeginPreviewPart(e);
    }

    protected override void OnQueryPageSettings(QueryPageSettingsEventArgs e)
    {
        if (_index < _parts.Length)
        {
            e.PageSettings = (PageSettings)_parts[_index].DefaultPageSettings.Clone();
            e.PageSettings.PrinterSettings = PrinterSettings;
        }
        base.OnQueryPageSettings(e);
    }

    protected override void OnPrintPage(PrintPageEventArgs e)
    {
        if (_index >= _parts.Length) { e.HasMorePages = false; return; }
        _parts[_index].DrawPreviewPart(e);
        if (!e.HasMorePages) _index++;
        e.HasMorePages = _index < _parts.Length;
    }
}
