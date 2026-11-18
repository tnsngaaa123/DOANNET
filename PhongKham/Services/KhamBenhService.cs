using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class KhamBenhService
{
    internal static PhieuKham RequireVisit(DbSession s, int id) => PhieuKhamRepository.Get(s, id) ?? throw new NghiepVuException("Không tìm thấy lượt khám.");
    internal static List<DongDonThuocRow> Rows(DbSession s, int id)
    {
        var d = DonThuocRepository.ByVisit(s, id);
        if (d is null)
            return new();
        return DonThuocRepository.Lines(s, d.Id).Select(x =>
        {
            var t = ThuocRepository.Get(s, x.ThuocId)!;
            return new DongDonThuocRow
            {
                Dong = x,
                TenThuoc = t.TenThuoc,
                DonViTinh = t.DonViTinh
            };
        }).ToList();
    }

    internal static PhieuKhamChiTiet Detail(DbSession s, int id)
    {
        var p = RequireVisit(s, id);
        return new PhieuKhamChiTiet
        {
            Phieu = p,
            BenhNhan = BenhNhanRepository.Get(s, p.BenhNhanId)!,
            TenBacSi = NguoiDungRepository.Get(s, p.BacSiId)?.HoTen ?? "",
            CacThuoc = Rows(s, id)
        };
    }

    private static PhieuKham? Active(DbSession s, NguoiDung actor) => PhieuKhamRepository.All(s).Where(p => p.TrangThai == TrangThai.DangKham && (actor.VaiTro == Roles.Admin || p.BacSiId == actor.Id)).OrderByDescending(p => p.GioGoi).FirstOrDefault();
    public static PhieuKham? Active() => Db.Run(s => Active(s, AuthService.Require(s, Roles.BacSi)));
    public static List<LuotKhamRow> Waiting() => Db.Run(s =>
    {
        var actor = AuthService.Require(s, Roles.BacSi);
        return PhieuKhamRepository.List(s, DateTime.Today, actor.VaiTro == Roles.Admin ? null : actor.Id, TrangThai.ChoKham);
    });
    public static BatDauKhamKetQua Next() => Db.InTransaction(s =>
    {
        var actor = AuthService.Require(s, Roles.BacSi);
        var active = Active(s, actor);
        if (active is not null)
            return new BatDauKhamKetQua
            {
                PhieuKhamId = active.Id,
                CoPhieuDangKham = true
            };
        var row = PhieuKhamRepository.List(s, DateTime.Today, actor.VaiTro == Roles.Admin ? null : actor.Id, TrangThai.ChoKham).FirstOrDefault() ?? throw new NghiepVuException("Không có bệnh nhân chờ khám.");
        var p = row.Phieu;
        p.TrangThai = TrangThai.DangKham;
        p.GioGoi = DateTime.Now;
        PhieuKhamRepository.Update(s, p);
        return new BatDauKhamKetQua
        {
            PhieuKhamId = p.Id
        };
    });
    internal static PhieuKham CanEdit(DbSession s, int id)
    {
        var actor = AuthService.Require(s, Roles.BacSi);
        var p = RequireVisit(s, id);
        if (p.TrangThai != TrangThai.DangKham || (actor.VaiTro != Roles.Admin && p.BacSiId != actor.Id))
            throw new NghiepVuException("Chỉ sửa phiếu đang khám của bác sĩ đăng nhập.");
        return p;
    }

    public static PhieuKhamChiTiet Get(int id) => Db.Run(s =>
    {
        var actor = AuthService.Require(s, Roles.BacSi);
        var d = Detail(s, id);
        if (actor.VaiTro != Roles.Admin && d.Phieu.BacSiId != actor.Id)
            throw new NghiepVuException("Lượt khám không thuộc bác sĩ đăng nhập.");
        return d;
    });
    public static void Save(int id, string symptoms, string diagnosis, string result, string advice, bool complete = false) => Db.InTransaction(s =>
    {
        var p = CanEdit(s, id);
        if (new[]
        {
            symptoms,
            diagnosis,
            result,
            advice
        }.Any(x => x.Length > 10000))
            throw new NghiepVuException("Nội dung khám quá dài.");
        if (complete && (string.IsNullOrWhiteSpace(symptoms) || string.IsNullOrWhiteSpace(diagnosis)))
            throw new NghiepVuException("Hoàn tất cần triệu chứng và chẩn đoán.");
        p.TrieuChung = symptoms.Trim();
        p.ChanDoan = diagnosis.Trim();
        p.KetQua = result.Trim();
        p.LoiDan = advice.Trim();
        if (complete)
        {
            p.TrangThai = TrangThai.ChoThanhToan;
            p.GioHoanTat = DateTime.Now;
        }

        PhieuKhamRepository.Update(s, p);
    });
}
