using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class NhomThuocRepository
{
    public static NhomThuoc Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        TenNhom = DbSession.Text(r, "TenNhom")
    };
    public static NhomThuoc? Get(DbSession s, int id) => s.Query("SELECT * FROM NhomThuoc WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<NhomThuoc> All(DbSession s) => s.Query("SELECT * FROM NhomThuoc ORDER BY Id", Map);
    public static int Insert(DbSession s, NhomThuoc x) => s.Insert("INSERT INTO NhomThuoc(TenNhom) VALUES(@TenNhom)", ("@TenNhom", x.TenNhom));
    public static void Update(DbSession s, NhomThuoc x)
    {
        if (s.Execute("UPDATE NhomThuoc SET TenNhom=@TenNhom WHERE Id=@Id", ("@TenNhom", x.TenNhom), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }
}
