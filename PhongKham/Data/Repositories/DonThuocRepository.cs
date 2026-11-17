using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class DonThuocRepository
{
    public static DonThuoc Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        PhieuKhamId = DbSession.Int(r, "PhieuKhamId"),
        NgayKe = DbSession.Date(r, "NgayKe"),
        TrangThai = DbSession.Text(r, "TrangThai"),
        NgayXuat = DbSession.NullableDate(r, "NgayXuat"),
        NguoiXuatId = DbSession.NullableInt(r, "NguoiXuatId")
    };
    public static DonThuoc? Get(DbSession s, int id) => s.Query("SELECT * FROM DonThuoc WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<DonThuoc> All(DbSession s) => s.Query("SELECT * FROM DonThuoc ORDER BY Id", Map);
    public static int Insert(DbSession s, DonThuoc x) => s.Insert("INSERT INTO DonThuoc(PhieuKhamId,NgayKe,TrangThai,NgayXuat,NguoiXuatId) VALUES(@PhieuKhamId,@NgayKe,@TrangThai,@NgayXuat,@NguoiXuatId)", ("@PhieuKhamId", x.PhieuKhamId), ("@NgayKe", x.NgayKe), ("@TrangThai", x.TrangThai), ("@NgayXuat", x.NgayXuat), ("@NguoiXuatId", x.NguoiXuatId));
    public static void Update(DbSession s, DonThuoc x)
    {
        if (s.Execute("UPDATE DonThuoc SET PhieuKhamId=@PhieuKhamId,NgayKe=@NgayKe,TrangThai=@TrangThai,NgayXuat=@NgayXuat,NguoiXuatId=@NguoiXuatId WHERE Id=@Id", ("@PhieuKhamId", x.PhieuKhamId), ("@NgayKe", x.NgayKe), ("@TrangThai", x.TrangThai), ("@NgayXuat", x.NgayXuat), ("@NguoiXuatId", x.NguoiXuatId), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }

    public static DonThuoc? ByVisit(DbSession s, int id) => s.Query("SELECT * FROM DonThuoc WHERE PhieuKhamId=@id", Map, ("@id", id)).FirstOrDefault();
    public static ChiTietDonThuoc MapLine(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        DonThuocId = DbSession.Int(r, "DonThuocId"),
        ThuocId = DbSession.Int(r, "ThuocId"),
        SoLuong = DbSession.Int(r, "SoLuong"),
        DonGia = DbSession.Long(r, "DonGia"),
        LieuDung = DbSession.Text(r, "LieuDung"),
        Sang = DbSession.Double(r, "Sang"),
        Trua = DbSession.Double(r, "Trua"),
        Chieu = DbSession.Double(r, "Chieu"),
        Toi = DbSession.Double(r, "Toi"),
        SoNgay = DbSession.Int(r, "SoNgay"),
        ThoiDiemUong = DbSession.Text(r, "ThoiDiemUong")
    };
    public static List<ChiTietDonThuoc> Lines(DbSession s, int id) => s.Query("SELECT * FROM ChiTietDonThuoc WHERE DonThuocId=@id ORDER BY Id", MapLine, ("@id", id));
    public static int InsertLine(DbSession s, ChiTietDonThuoc x) => s.Insert("INSERT INTO ChiTietDonThuoc(DonThuocId,ThuocId,SoLuong,DonGia,LieuDung,Sang,Trua,Chieu,Toi,SoNgay,ThoiDiemUong) VALUES(@DonThuocId,@ThuocId,@SoLuong,@DonGia,@LieuDung,@Sang,@Trua,@Chieu,@Toi,@SoNgay,@ThoiDiemUong)", ("@DonThuocId", x.DonThuocId), ("@ThuocId", x.ThuocId), ("@SoLuong", x.SoLuong), ("@DonGia", x.DonGia), ("@LieuDung", x.LieuDung), ("@Sang", x.Sang), ("@Trua", x.Trua), ("@Chieu", x.Chieu), ("@Toi", x.Toi), ("@SoNgay", x.SoNgay), ("@ThoiDiemUong", x.ThoiDiemUong));
    public static void DeleteLines(DbSession s, int id) => s.Execute("DELETE FROM ChiTietDonThuoc WHERE DonThuocId=@id", ("@id", id));
    public static void Delete(DbSession s, int id)
    {
        DeleteLines(s, id);
        s.Execute("DELETE FROM DonThuoc WHERE Id=@id", ("@id", id));
    }

    public static int Reserved(DbSession s, int drug, int? exclude = null) => Convert.ToInt32(s.Scalar(@"SELECT COALESCE(SUM(c.SoLuong),0) FROM ChiTietDonThuoc c JOIN DonThuoc d ON d.Id=c.DonThuocId WHERE c.ThuocId=@id AND d.TrangThai='DaKe' AND (@exclude IS NULL OR d.PhieuKhamId<>@exclude)", ("@id", drug), ("@exclude", exclude)));
}
