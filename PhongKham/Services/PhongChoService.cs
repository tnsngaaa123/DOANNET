using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class PhongChoService
{
    public static PhongChoTongHopData Get() => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan, Roles.BacSi, Roles.ThuNgan, Roles.DuocSi);
        var waiting = PhieuKhamRepository.List(s, DateTime.Today, state: TrangThai.ChoKham);
        var active = PhieuKhamRepository.List(s, state: TrangThai.DangKham)
            .OrderByDescending(x => x.Phieu.GioGoi).FirstOrDefault();
        var payment = PhieuKhamRepository.List(s, state: TrangThai.ChoThanhToan)
            .OrderBy(x => x.Phieu.GioHoanTat).ThenBy(x => x.SoThuTu).ToList();
        var pickup = PhieuKhamRepository.List(s, state: TrangThai.ChoXuatThuoc)
            .OrderBy(x => x.Phieu.NgayTao).ThenBy(x => x.SoThuTu).ToList();
        return new PhongChoTongHopData
        {
            ChoKham = new PhongChoData { SoDangKham = (active ?? waiting.FirstOrDefault())?.SoThuTu.ToString() ?? "—", DangCho = waiting },
            ChoThanhToan = new PhongChoData { SoDangKham = payment.FirstOrDefault()?.SoThuTu.ToString() ?? "—", DangCho = payment },
            ChoLayThuoc = new PhongChoData { SoDangKham = pickup.FirstOrDefault()?.SoThuTu.ToString() ?? "—", DangCho = pickup }
        };
    });
}