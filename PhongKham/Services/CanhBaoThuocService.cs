using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class CanhBaoThuocService
{
    public static MucCanhBao MauHanDung(DateTime expiry, DateTime? today = null)
    {
        var day = (today ?? DateTime.Today).Date;
        return expiry.Date < day ? MucCanhBao.Red : expiry.Date <= day.AddMonths(3) ? MucCanhBao.Orange : expiry.Date <= day.AddMonths(6) ? MucCanhBao.Yellow : MucCanhBao.Green;
    }

    public static MucCanhBao MauSoLuong(int qty) => qty <= 1000 ? MucCanhBao.Red : qty <= 3000 ? MucCanhBao.Orange : qty <= 5000 ? MucCanhBao.Yellow : MucCanhBao.Green;
    public static bool DungLocHan(DateTime expiry, LocHanDung filter, DateTime? today = null)
    {
        var day = (today ?? DateTime.Today).Date;
        return filter switch
        {
            LocHanDung.TatCa => true,
            LocHanDung.DaHetHan => expiry.Date < day,
            LocHanDung.DuoiBaThang => expiry.Date >= day && expiry.Date < day.AddMonths(3),
            LocHanDung.DuoiSauThang => expiry.Date >= day && expiry.Date < day.AddMonths(6),
            _ => false
        };
    }

    public static List<HanDungRow> HanDung(string q, LocHanDung filter) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.DuocSi);
        var drugs = ThuocRepository.Search(s, q).ToDictionary(t => t.Id);
        var groups = NhomThuocRepository.All(s).ToDictionary(g => g.Id, g => g.TenNhom);
        return LoThuocRepository.All(s).Where(l => l.SoLuongTon > 0 && drugs.ContainsKey(l.ThuocId) && DungLocHan(l.HanSuDung, filter)).OrderBy(l => l.HanSuDung).Select(l => new HanDungRow { LoThuocId = l.Id, ThuocId = l.ThuocId, MaThuoc = drugs[l.ThuocId].MaThuoc, TenThuoc = drugs[l.ThuocId].TenThuoc, DonViTinh = drugs[l.ThuocId].DonViTinh, SoLo = l.SoLo, TenNhom = groups[drugs[l.ThuocId].NhomThuocId], HanSuDung = l.HanSuDung, SoLuongTon = l.SoLuongTon }).ToList();
    });
    public static List<SoLuongThuocRow> SoLuong(string q, int? lessThan = null) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.DuocSi);
        if (lessThan is not (null or 5000 or 3000 or 1000))
            throw new NghiepVuException("Bộ lọc số lượng không hợp lệ.");
        return ThuocRepository.Search(s, q).Select(t => new SoLuongThuocRow { ThuocId = t.Id, TenThuoc = t.TenThuoc, DonViTinh = t.DonViTinh, SoLuongCon = LoThuocRepository.Remaining(s, t.Id) }).Where(t => lessThan is null || t.SoLuongCon < lessThan).OrderBy(t => t.SoLuongCon).ThenBy(t => t.TenThuoc).ToList();
    });
}
