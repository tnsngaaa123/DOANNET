using PhongKham.Models.Views;
using PhongKham.Services;
namespace PhongKham.Printing;
public sealed class DanhSachPrintDocument : PhongKhamPrintDocument
{
    public DanhSachPrintDocument(DanhSachPrintData data) : base(MauBanInService.DanhSach(data), "DanhSach", true) { }
}
