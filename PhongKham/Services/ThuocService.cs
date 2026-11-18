using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class ThuocService
{
    public static List<NhomThuoc> Groups() => Db.Run(s =>
    {
        AuthService.Require(s, Roles.DuocSi, Roles.BacSi);
        return NhomThuocRepository.All(s);
    });

    public static Thuoc Get(int id) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.DuocSi, Roles.BacSi);

        return ThuocRepository.Get(s, id)
            ?? throw new NghiepVuException("Không tìm thấy thuốc.");
    });

    internal static int Available(DbSession s, int drug, int? exclude = null) =>
        LoThuocRepository.Remaining(s, drug) - DonThuocRepository.Reserved(s, drug, exclude);

    public static int KhaDung(int drug, int? exclude = null) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.BacSi, Roles.DuocSi);
        return Available(s, drug, exclude);
    });

    public static List<ThuocRow> List(string q = "") => Db.Run(s =>
    {
        AuthService.Require(s, Roles.DuocSi);

        var groups = NhomThuocRepository.All(s);

        return ThuocRepository.Search(s, q)
            .Select(t => new ThuocRow
            {
                Thuoc = t,
                TenNhom = groups.First(g => g.Id == t.NhomThuocId).TenNhom,
                SoLuongCon = LoThuocRepository.Remaining(s, t.Id)
            })
            .ToList();
    });

    public static IReadOnlyList<GoiYThuoc> GoiY(string q, int? exclude = null) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.DuocSi, Roles.BacSi);

        if (q.Trim().Length < 2)
            return new List<GoiYThuoc>();

        return ThuocRepository.Search(s, q)
            .Take(12)
            .Select(t => new GoiYThuoc
            {
                ThuocId = t.Id,
                MaThuoc = t.MaThuoc,
                TenThuoc = t.TenThuoc,
                DonViTinh = t.DonViTinh,
                NhomThuocId = t.NhomThuocId,
                GiaBan = t.GiaBan,
                SoLuongCon = Available(s, t.Id, exclude)
            })
            .ToList();
    });

    internal static void Validate(DbSession s, ThemThuocInput x)
    {
        var t = x.Thuoc;

        if (t.MaThuoc.Trim().Length < 2 || t.MaThuoc.Length > 40
            || t.TenThuoc.Trim().Length < 2 || t.TenThuoc.Length > 150
            || t.DonViTinh.Trim().Length < 1 || t.DonViTinh.Length > 30
            || t.GiaBan < 0 || t.GiaBan > 1_000_000_000
            || NhomThuocRepository.Get(s, t.NhomThuocId) is null)
        {
            throw new NghiepVuException("Kiểm tra mã/tên, nhóm, đơn vị và giá bán.");
        }

        if (x.SoLuong < 1 || x.SoLuong > 1_000_000 || x.HanSuDung.Date < DateTime.Today)
        {
            throw new NghiepVuException("Số lượng cần 1–1.000.000 và thuốc phải còn hạn dùng.");
        }

        var existing = ThuocRepository.ByCode(s, t.MaThuoc.Trim());

        if (t.Id > 0 && (existing is null || existing.Id != t.Id))
        {
            throw new NghiepVuException("Mã thuốc không khớp thuốc đã chọn. Hãy chọn lại gợi ý.");
        }
    }

    internal static KetQuaThemThuoc Add(DbSession s, ThemThuocInput input, NguoiDung actor)
    {
        Validate(s, input);

        var source = input.Thuoc;
        var old = ThuocRepository.ByCode(s, source.MaThuoc.Trim());

        var t = new Thuoc
        {
            Id = old?.Id ?? 0,
            MaThuoc = source.MaThuoc.Trim(),
            TenThuoc = source.TenThuoc.Trim(),
            DonViTinh = source.DonViTinh.Trim(),
            NhomThuocId = source.NhomThuocId,
            GiaBan = source.GiaBan
        };

        if (old is null)
            t.Id = ThuocRepository.Insert(s, t);
        else
            ThuocRepository.Update(s, t);

        var lot = new LoThuoc
        {
            ThuocId = t.Id,
            HanSuDung = input.HanSuDung.Date,
            SoLuongNhap = input.SoLuong,
            SoLuongTon = input.SoLuong,
            NguoiNhapId = actor.Id
        };

        lot.Id = LoThuocRepository.Insert(s, lot);
        lot.SoLo = "LO" + lot.Id.ToString("D8");
        LoThuocRepository.Update(s, lot);

        BienDongKhoRepository.Insert(s, new BienDongKho
        {
            LoThuocId = lot.Id,
            SoLuong = input.SoLuong,
            Loai = TrangThai.Nhap,
            ThamChieu = "THUOC:" + t.Id,
            NguoiThucHienId = actor.Id
        });

        return new KetQuaThemThuoc
        {
            ThuocId = t.Id,
            TenThuoc = t.TenThuoc,
            SoLuongThem = input.SoLuong,
            SoLuongCon = LoThuocRepository.Remaining(s, t.Id),
            LaThuocMoi = old is null
        };
    }

    public static void UpdateInfo(Thuoc input) => Db.InTransaction(s =>
    {
        AuthService.Require(s, Roles.DuocSi);

        var old = ThuocRepository.Get(s, input.Id)
            ?? throw new NghiepVuException("Thuốc không còn tồn tại.");

        string code = input.MaThuoc.Trim();
        string name = input.TenThuoc.Trim();
        string unit = input.DonViTinh.Trim();

        if (code.Length < 2 || code.Length > 40
            || name.Length < 2 || name.Length > 150
            || unit.Length < 1 || unit.Length > 30
            || input.GiaBan < 0 || input.GiaBan > 1_000_000_000
            || NhomThuocRepository.Get(s, input.NhomThuocId) is null)
        {
            throw new NghiepVuException("Kiểm tra mã/tên, nhóm, đơn vị và giá bán.");
        }

        var duplicate = ThuocRepository.ByCode(s, code);

        if (duplicate is not null && duplicate.Id != old.Id)
            throw new NghiepVuException("Mã thuốc đã thuộc về thuốc khác.");

        old.MaThuoc = code;
        old.TenThuoc = name;
        old.DonViTinh = unit;
        old.NhomThuocId = input.NhomThuocId;
        old.GiaBan = input.GiaBan;

        ThuocRepository.Update(s, old);
    });

    public static KetQuaThemThuoc Add(ThemThuocInput input) => Db.InTransaction(s =>
        Add(s, input, AuthService.Require(s, Roles.DuocSi)));
}