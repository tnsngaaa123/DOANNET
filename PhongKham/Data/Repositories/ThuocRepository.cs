using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class ThuocRepository
{
    public static Thuoc Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        MaThuoc = DbSession.Text(r, "MaThuoc"),
        TenThuoc = DbSession.Text(r, "TenThuoc"),

        DonViTinh = DbSession.Text(r, "DonViTinh"),
        NhomThuocId = DbSession.Int(r, "NhomThuocId"),
        GiaBan = DbSession.Long(r, "GiaBan")
    };
    public static Thuoc? Get(DbSession s, int id) => s.Query("SELECT * FROM Thuoc WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<Thuoc> All(DbSession s) => s.Query("SELECT * FROM Thuoc ORDER BY Id", Map);
    public static int Insert(DbSession s, Thuoc x) => s.Insert("INSERT INTO Thuoc(MaThuoc,TenThuoc,DonViTinh,NhomThuocId,GiaBan) VALUES(@MaThuoc,@TenThuoc,@DonViTinh,@NhomThuocId,@GiaBan)", ("@MaThuoc", x.MaThuoc), ("@TenThuoc", x.TenThuoc), ("@DonViTinh", x.DonViTinh), ("@NhomThuocId", x.NhomThuocId), ("@GiaBan", x.GiaBan));
    public static void Update(DbSession s, Thuoc x)
    {
        if (s.Execute("UPDATE Thuoc SET MaThuoc=@MaThuoc,TenThuoc=@TenThuoc,DonViTinh=@DonViTinh,NhomThuocId=@NhomThuocId,GiaBan=@GiaBan WHERE Id=@Id", ("@MaThuoc", x.MaThuoc), ("@TenThuoc", x.TenThuoc), ("@DonViTinh", x.DonViTinh), ("@NhomThuocId", x.NhomThuocId), ("@GiaBan", x.GiaBan), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }

    public static Thuoc? ByCode(DbSession s, string code) => s.Query("SELECT * FROM Thuoc WHERE MaThuoc=@code", Map, ("@code", code)).FirstOrDefault();
    public static List<Thuoc> Search(DbSession s, string q) => s.Query("SELECT * FROM Thuoc WHERE khong_dau(MaThuoc||' '||TenThuoc) LIKE @q ORDER BY TenThuoc", Map, ("@q", "%" + Db.KhongDau(q) + "%"));
}
