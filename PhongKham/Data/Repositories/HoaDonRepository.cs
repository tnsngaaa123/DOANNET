using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class HoaDonRepository
{
    public static HoaDon Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        MaHoaDon = DbSession.Text(r, "MaHoaDon"),
        PhieuKhamId = DbSession.Int(r, "PhieuKhamId"),
        NguoiThuId = DbSession.Int(r, "NguoiThuId"),
        NgayThanhToan = DbSession.Date(r, "NgayThanhToan"),
        TienKham = DbSession.Long(r, "TienKham"),
        TienThuoc = DbSession.Long(r, "TienThuoc"),
        GiamGia = DbSession.Long(r, "GiamGia"),
        TongThu = DbSession.Long(r, "TongThu"),
        TienKhachDua = DbSession.Long(r, "TienKhachDua"),
        TienThua = DbSession.Long(r, "TienThua"),
        HinhThuc = DbSession.Text(r, "HinhThuc")
    };
    public static HoaDon? Get(DbSession s, int id) => s.Query("SELECT * FROM HoaDon WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<HoaDon> All(DbSession s) => s.Query("SELECT * FROM HoaDon ORDER BY Id", Map);
    public static int Insert(DbSession s, HoaDon x) => s.Insert("INSERT INTO HoaDon(MaHoaDon,PhieuKhamId,NguoiThuId,NgayThanhToan,TienKham,TienThuoc,GiamGia,TongThu,TienKhachDua,TienThua,HinhThuc) VALUES(@MaHoaDon,@PhieuKhamId,@NguoiThuId,@NgayThanhToan,@TienKham,@TienThuoc,@GiamGia,@TongThu,@TienKhachDua,@TienThua,@HinhThuc)", ("@MaHoaDon", x.MaHoaDon), ("@PhieuKhamId", x.PhieuKhamId), ("@NguoiThuId", x.NguoiThuId), ("@NgayThanhToan", x.NgayThanhToan), ("@TienKham", x.TienKham), ("@TienThuoc", x.TienThuoc), ("@GiamGia", x.GiamGia), ("@TongThu", x.TongThu), ("@TienKhachDua", x.TienKhachDua), ("@TienThua", x.TienThua), ("@HinhThuc", x.HinhThuc));
    public static void Update(DbSession s, HoaDon x)
    {
        if (s.Execute("UPDATE HoaDon SET MaHoaDon=@MaHoaDon,PhieuKhamId=@PhieuKhamId,NguoiThuId=@NguoiThuId,NgayThanhToan=@NgayThanhToan,TienKham=@TienKham,TienThuoc=@TienThuoc,GiamGia=@GiamGia,TongThu=@TongThu,TienKhachDua=@TienKhachDua,TienThua=@TienThua,HinhThuc=@HinhThuc WHERE Id=@Id", ("@MaHoaDon", x.MaHoaDon), ("@PhieuKhamId", x.PhieuKhamId), ("@NguoiThuId", x.NguoiThuId), ("@NgayThanhToan", x.NgayThanhToan), ("@TienKham", x.TienKham), ("@TienThuoc", x.TienThuoc), ("@GiamGia", x.GiamGia), ("@TongThu", x.TongThu), ("@TienKhachDua", x.TienKhachDua), ("@TienThua", x.TienThua), ("@HinhThuc", x.HinhThuc), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }

    public static HoaDon? ByVisit(DbSession s, int visit) => s.Query("SELECT * FROM HoaDon WHERE PhieuKhamId=@id", Map, ("@id", visit)).FirstOrDefault();
    public static List<Models.Views.ThanhToanRow> Paid(DbSession s, DateTime? day, string method, string q, int? patient = null) => s.Query(@"
        SELECT h.*,p.BenhNhanId,b.HoTen,b.CanCuocCongDan,n.HoTen AS TenNguoiThu
        FROM HoaDon h JOIN PhieuKham p ON p.Id=h.PhieuKhamId
        JOIN BenhNhan b ON b.Id=p.BenhNhanId JOIN NguoiDung n ON n.Id=h.NguoiThuId
        WHERE (@day IS NULL OR date(h.NgayThanhToan)=@day)
          AND (@patient IS NULL OR p.BenhNhanId=@patient)
          AND (@method='' OR h.HinhThuc=@method)
          AND khong_dau(b.HoTen||' '||b.CanCuocCongDan||' '||h.MaHoaDon||' HD'||replace(p.NgayKham,'-','')||printf('%04d',p.Id)) LIKE @q
        ORDER BY h.NgayThanhToan DESC,h.Id DESC",
        r => new Models.Views.ThanhToanRow { HoaDon = Map(r), BenhNhanId = DbSession.Int(r, "BenhNhanId"), HoTen = DbSession.Text(r, "HoTen"), CanCuocCongDan = DbSession.Text(r, "CanCuocCongDan"), TenNguoiThu = DbSession.Text(r, "TenNguoiThu") },
        ("@day", day.HasValue ? Db.Day(day.Value) : null), ("@method", method), ("@patient", patient), ("@q", "%" + Db.KhongDau(q) + "%"));
}
