using PhongKham.Models.Views;
using PhongKham.Services;
namespace PhongKham.Printing;
public sealed class DonThuocPrintDocument : PhongKhamPrintDocument
{
    public DonThuocPrintDocument(HoanTatKhamPrintData data) : base(MauBanInService.DonThuoc(data), "DonThuoc") { }
}
