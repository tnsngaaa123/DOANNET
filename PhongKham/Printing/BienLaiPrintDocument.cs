using PhongKham.Models.Views;
using PhongKham.Services;
namespace PhongKham.Printing;
public sealed class BienLaiPrintDocument : PhongKhamPrintDocument
{
    public BienLaiPrintDocument(BienLaiData data) : base(MauBanInService.BienLai(data), "BienLai") { }
}
