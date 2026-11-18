using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class NguoiDungRepository
{
    public static NguoiDung Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        TenDangNhap = DbSession.Text(r, "TenDangNhap"),
        MatKhauHash = DbSession.Text(r, "MatKhauHash"),
        HoTen = DbSession.Text(r, "HoTen"),
        VaiTro = DbSession.Text(r, "VaiTro"),
        TrangThai = DbSession.Bool(r, "TrangThai")
    };
    public static NguoiDung? Get(DbSession s, int id) => s.Query("SELECT * FROM NguoiDung WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<NguoiDung> All(DbSession s) => s.Query("SELECT * FROM NguoiDung ORDER BY Id", Map);
    public static int Insert(DbSession s, NguoiDung x) => s.Insert("INSERT INTO NguoiDung(TenDangNhap,MatKhauHash,HoTen,VaiTro,TrangThai) VALUES(@TenDangNhap,@MatKhauHash,@HoTen,@VaiTro,@TrangThai)", ("@TenDangNhap", x.TenDangNhap), ("@MatKhauHash", x.MatKhauHash), ("@HoTen", x.HoTen), ("@VaiTro", x.VaiTro), ("@TrangThai", x.TrangThai));
    public static void Update(DbSession s, NguoiDung x)
    {
        if (s.Execute("UPDATE NguoiDung SET TenDangNhap=@TenDangNhap,MatKhauHash=@MatKhauHash,HoTen=@HoTen,VaiTro=@VaiTro,TrangThai=@TrangThai WHERE Id=@Id", ("@TenDangNhap", x.TenDangNhap), ("@MatKhauHash", x.MatKhauHash), ("@HoTen", x.HoTen), ("@VaiTro", x.VaiTro), ("@TrangThai", x.TrangThai), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }

    public static NguoiDung? ByLogin(DbSession s, string login) => s.Query("SELECT * FROM NguoiDung WHERE TenDangNhap=@login", Map, ("@login", login)).FirstOrDefault();
    public static List<NguoiDung> Doctors(DbSession s) => s.Query("SELECT * FROM NguoiDung WHERE VaiTro='BacSi' AND TrangThai=1 ORDER BY HoTen", Map);
}
