using System.Drawing.Printing;
using PhongKham.Models.Views;
namespace PhongKham.Printing;
public class PhongKhamPrintDocument : PrintDocument
{
    public MauBanIn Mau { get; }
    public string ThuMuc { get; }
    private int _row;
    public PhongKhamPrintDocument(MauBanIn data, string folder, bool landscape=false)
    {
        Mau=data; ThuMuc=folder; DocumentName=data.MaChungTu;
        DefaultPageSettings.PaperSize=new PaperSize("A4",827,1169);
        DefaultPageSettings.Landscape=landscape;
    }
    internal void BeginPreviewPart(PrintEventArgs e) => OnBeginPrint(e);
    internal void DrawPreviewPart(PrintPageEventArgs e) => OnPrintPage(e);
    protected override void OnBeginPrint(PrintEventArgs e) { base.OnBeginPrint(e); _row=0; }
    protected override void OnPrintPage(PrintPageEventArgs e)
    {
        if(e.Graphics is null)return;
        using var font=new Font("Segoe UI",10F); using var title=new Font("Segoe UI",16F,FontStyle.Bold);
        float y=e.MarginBounds.Top; var g=e.Graphics;
        g.DrawString(Mau.TenPhongKham,title,Brushes.DarkGreen,e.MarginBounds.Left,y); y+=32;
        g.DrawString(Mau.TieuDe,title,Brushes.Black,e.MarginBounds.Left,y); y+=32;
        g.DrawString(Mau.MaChungTu,font,Brushes.Black,e.MarginBounds.Left,y); y+=28;
        while(_row<Mau.Dong.Count && y+30<e.MarginBounds.Bottom)
        { g.DrawString(string.Join(" | ",Mau.Dong[_row++]),font,Brushes.Black,new RectangleF(e.MarginBounds.Left,y,e.MarginBounds.Width,28)); y+=30; }
        e.HasMorePages=_row<Mau.Dong.Count;
    }
}
