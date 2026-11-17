using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class LoThuocRepository
{
    public static LoThuoc Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        ThuocId = DbSession.Int(r, "ThuocId"),
        SoLo = DbSession.Text(r, "SoLo"),
        HanSuDung = DbSession.Date(r, "HanSuDung"),
        SoLuongNhap = DbSession.Int(r, "SoLuongNhap"),
        SoLuongTon = DbSession.Int(r, "SoLuongTon"),
        NgayNhap = DbSession.Date(r, "NgayNhap"),
        NguoiNhapId = DbSession.Int(r, "NguoiNhapId")
    };
    public static LoThuoc? Get(DbSession s, int id) => s.Query("SELECT * FROM LoThuoc WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<LoThuoc> All(DbSession s) => s.Query("SELECT * FROM LoThuoc ORDER BY Id", Map);
    public static int Insert(DbSession s, LoThuoc x) => s.Insert("INSERT INTO LoThuoc(ThuocId,SoLo,HanSuDung,SoLuongNhap,SoLuongTon,NgayNhap,NguoiNhapId) VALUES(@ThuocId,@SoLo,@HanSuDung,@SoLuongNhap,@SoLuongTon,@NgayNhap,@NguoiNhapId)", ("@ThuocId", x.ThuocId), ("@SoLo", x.SoLo), ("@HanSuDung", Db.Day(x.HanSuDung)), ("@SoLuongNhap", x.SoLuongNhap), ("@SoLuongTon", x.SoLuongTon), ("@NgayNhap", x.NgayNhap), ("@NguoiNhapId", x.NguoiNhapId));
    public static void Update(DbSession s, LoThuoc x)
    {
        if (s.Execute("UPDATE LoThuoc SET ThuocId=@ThuocId,SoLo=@SoLo,HanSuDung=@HanSuDung,SoLuongNhap=@SoLuongNhap,SoLuongTon=@SoLuongTon,NgayNhap=@NgayNhap,NguoiNhapId=@NguoiNhapId WHERE Id=@Id", ("@ThuocId", x.ThuocId), ("@SoLo", x.SoLo), ("@HanSuDung", Db.Day(x.HanSuDung)), ("@SoLuongNhap", x.SoLuongNhap), ("@SoLuongTon", x.SoLuongTon), ("@NgayNhap", x.NgayNhap), ("@NguoiNhapId", x.NguoiNhapId), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }

    public static int Remaining(DbSession s, int drug) => Convert.ToInt32(s.Scalar("SELECT COALESCE(SUM(SoLuongTon),0) FROM LoThuoc WHERE ThuocId=@id AND HanSuDung>=@today", ("@id", drug), ("@today", Db.Day(DateTime.Today))));
    public static List<LoThuoc> Sellable(DbSession s, int drug) => s.Query("SELECT * FROM LoThuoc WHERE ThuocId=@id AND SoLuongTon>0 AND HanSuDung>=@today ORDER BY HanSuDung,Id", Map, ("@id", drug), ("@today", Db.Day(DateTime.Today)));
    public static void Deduct(DbSession s, int id, int qty)
    {
        if (s.Execute("UPDATE LoThuoc SET SoLuongTon=SoLuongTon-@q WHERE Id=@id AND SoLuongTon>=@q AND HanSuDung>=@today", ("@id", id), ("@q", qty), ("@today", Db.Day(DateTime.Today))) != 1)
            throw new NghiepVuException("Thuốc không còn đủ hoặc đã hết hạn.");
    }
}
