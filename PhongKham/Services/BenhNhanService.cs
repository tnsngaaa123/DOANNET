using System.Text.RegularExpressions;
using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class BenhNhanService
{
    public static void ValidateCanCuoc(string cccd)
    {
        if (cccd.Length != 12 || cccd.Any(c => c < '0' || c > '9'))
            throw new NghiepVuException("CCCD bắt buộc đúng 12 chữ số.");
    }

    internal static void Validate(BenhNhan x)
    {
        x.CanCuocCongDan = x.CanCuocCongDan.Trim();
        x.HoTen = x.HoTen.Trim();
        x.SoDienThoai = x.SoDienThoai.Trim();
        ValidateCanCuoc(x.CanCuocCongDan);
        if (x.HoTen.Length < 2 || x.HoTen.Length > 150 || x.NgaySinh.Date > DateTime.Today || x.NgaySinh.Year < 1900 || !new[]
        {
            TrangThai.Nam,
            TrangThai.Nu,
            TrangThai.Khac
        }.Contains(x.GioiTinh))
            throw new NghiepVuException("Kiểm tra họ tên, ngày sinh và giới tính.");
        if (x.SoDienThoai != "" && !Regex.IsMatch(x.SoDienThoai, @"^[0-9]{9,11}$"))
            throw new NghiepVuException("Số điện thoại cần 9–11 chữ số hoặc để trống.");
    }

    internal static int Create(DbSession s, BenhNhan x)
    {
        Validate(x);
        if (BenhNhanRepository.ByCanCuoc(s, x.CanCuocCongDan) is not null)
            throw new NghiepVuException("CCCD đã tồn tại trong hồ sơ. Không tạo hồ sơ trùng.");
        x.Id = 0;
        x.MaBenhNhan = "";
        x.NgayTao = DateTime.Now;
        x.Id = BenhNhanRepository.Insert(s, x);
        x.MaBenhNhan = "BN" + x.Id.ToString("D6");
        BenhNhanRepository.Update(s, x);
        return x.Id;
    }

    public static int Create(BenhNhan x) => Db.InTransaction(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        return Create(s, x);
    });
    public static BenhNhan? FindCanCuoc(string cccd) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        ValidateCanCuoc(cccd);
        return BenhNhanRepository.ByCanCuoc(s, cccd);
    });
    public static List<BenhNhan> List(string q = "", DateTime? from = null, DateTime? to = null) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan, Roles.BacSi);
        if (from.HasValue && to.HasValue && from.Value.Date > to.Value.Date)
            throw new NghiepVuException("Từ ngày không được sau đến ngày.");
        return BenhNhanRepository.Search(s, q, from, to);
    });
    public static BenhNhan Get(int id) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan, Roles.BacSi);
        return BenhNhanRepository.Get(s, id) ?? throw new NghiepVuException("Không tìm thấy hồ sơ.");
    });
    public static List<LichSuKhamRow> History(int patient) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan, Roles.BacSi);
        return PhieuKhamRepository.History(s, patient).Select(p => new LichSuKhamRow { PhieuKhamId = p.Id, NgayKham = p.NgayKham, TenBacSi = NguoiDungRepository.Get(s, p.BacSiId)?.HoTen ?? "", TrieuChung = p.TrieuChung, ChanDoan = p.ChanDoan, KetQua = p.KetQua, LoiDan = p.LoiDan }).ToList();
    });
    public static PhieuKhamChiTiet HistoryDetail(int id) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan, Roles.BacSi);
        return KhamBenhService.Detail(s, id);
    });
}
