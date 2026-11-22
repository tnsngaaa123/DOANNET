using PhongKham.Models.Views;
using PhongKham.Services;
namespace PhongKham.Printing;
public sealed class BaoCaoPrintDocument : PhongKhamPrintDocument
{
    public BaoCaoPrintDocument(BaoCaoData data) : base(MauBanInService.BaoCao(data), "BaoCao", true) { }
}
