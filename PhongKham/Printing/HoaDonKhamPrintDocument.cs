using PhongKham.Models.Views;
using PhongKham.Services;
namespace PhongKham.Printing;
public sealed class HoaDonKhamPrintDocument : PhongKhamPrintDocument
{
    public HoaDonKhamPrintDocument(HoanTatKhamPrintData data) : base(MauBanInService.HoaDon(data), "HoaDon") { }
}
