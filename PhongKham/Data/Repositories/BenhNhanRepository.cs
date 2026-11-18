using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class BenhNhanRepository
{
    public static BenhNhan Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        MaBenhNhan = DbSession.Text(r, "MaBenhNhan"),
        CanCuocCongDan = DbSession.Text(r, "CanCuocCongDan"),
        HoTen = DbSession.Text(r, "HoTen"),
        NgaySinh = DbSession.Date(r, "NgaySinh"),
        GioiTinh = DbSession.Text(r, "GioiTinh"),
        SoDienThoai = DbSession.Text(r, "SoDienThoai"),
        DiaChi = DbSession.Text(r, "DiaChi"),
        TienSuBenh = DbSession.Text(r, "TienSuBenh"),
        DiUng = DbSession.Text(r, "DiUng"),
        NgayTao = DbSession.Date(r, "NgayTao")
    };
    public static BenhNhan? Get(DbSession s, int id) => s.Query("SELECT * FROM BenhNhan WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<BenhNhan> All(DbSession s) => s.Query("SELECT * FROM BenhNhan ORDER BY Id", Map);
    public static int Insert(DbSession s, BenhNhan x) => s.Insert("INSERT INTO BenhNhan(MaBenhNhan,CanCuocCongDan,HoTen,NgaySinh,GioiTinh,SoDienThoai,DiaChi,TienSuBenh,DiUng,NgayTao) VALUES(@MaBenhNhan,@CanCuocCongDan,@HoTen,@NgaySinh,@GioiTinh,@SoDienThoai,@DiaChi,@TienSuBenh,@DiUng,@NgayTao)", ("@MaBenhNhan", x.MaBenhNhan), ("@CanCuocCongDan", x.CanCuocCongDan), ("@HoTen", x.HoTen), ("@NgaySinh", Db.Day(x.NgaySinh)), ("@GioiTinh", x.GioiTinh), ("@SoDienThoai", x.SoDienThoai), ("@DiaChi", x.DiaChi), ("@TienSuBenh", x.TienSuBenh), ("@DiUng", x.DiUng), ("@NgayTao", x.NgayTao));
    public static void Update(DbSession s, BenhNhan x)
    {
        if (s.Execute("UPDATE BenhNhan SET MaBenhNhan=@MaBenhNhan,CanCuocCongDan=@CanCuocCongDan,HoTen=@HoTen,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,SoDienThoai=@SoDienThoai,DiaChi=@DiaChi,TienSuBenh=@TienSuBenh,DiUng=@DiUng,NgayTao=@NgayTao WHERE Id=@Id", ("@MaBenhNhan", x.MaBenhNhan), ("@CanCuocCongDan", x.CanCuocCongDan), ("@HoTen", x.HoTen), ("@NgaySinh", Db.Day(x.NgaySinh)), ("@GioiTinh", x.GioiTinh), ("@SoDienThoai", x.SoDienThoai), ("@DiaChi", x.DiaChi), ("@TienSuBenh", x.TienSuBenh), ("@DiUng", x.DiUng), ("@NgayTao", x.NgayTao), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }

    public static BenhNhan? ByCanCuoc(DbSession s, string cccd) => s.Query("SELECT * FROM BenhNhan WHERE CanCuocCongDan=@cccd", Map, ("@cccd", cccd)).FirstOrDefault();
    public static List<BenhNhan> Search(DbSession s, string q, DateTime? from = null, DateTime? to = null) =>
        s.Query(@"SELECT * FROM BenhNhan
            WHERE khong_dau(HoTen||' '||CanCuocCongDan||' '||MaBenhNhan) LIKE @q
              AND (@from IS NULL OR NgayTao>=@from)
              AND (@end IS NULL OR NgayTao<@end)
            ORDER BY NgayTao DESC,Id DESC", Map,
            ("@q", "%" + Db.KhongDau(q) + "%"),
            ("@from", from?.Date), ("@end", to?.Date.AddDays(1)));
}
