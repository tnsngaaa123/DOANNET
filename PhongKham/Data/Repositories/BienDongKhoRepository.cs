using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class BienDongKhoRepository
{
    public static BienDongKho Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        LoThuocId = DbSession.Int(r, "LoThuocId"),
        SoLuong = DbSession.Int(r, "SoLuong"),
        Loai = DbSession.Text(r, "Loai"),
        ThamChieu = DbSession.Text(r, "ThamChieu"),
        NguoiThucHienId = DbSession.Int(r, "NguoiThucHienId"),
        ThoiGian = DbSession.Date(r, "ThoiGian")
    };
    public static BienDongKho? Get(DbSession s, int id) => s.Query("SELECT * FROM BienDongKho WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<BienDongKho> All(DbSession s) => s.Query("SELECT * FROM BienDongKho ORDER BY Id", Map);
    public static int Insert(DbSession s, BienDongKho x) => s.Insert("INSERT INTO BienDongKho(LoThuocId,SoLuong,Loai,ThamChieu,NguoiThucHienId,ThoiGian) VALUES(@LoThuocId,@SoLuong,@Loai,@ThamChieu,@NguoiThucHienId,@ThoiGian)", ("@LoThuocId", x.LoThuocId), ("@SoLuong", x.SoLuong), ("@Loai", x.Loai), ("@ThamChieu", x.ThamChieu), ("@NguoiThucHienId", x.NguoiThucHienId), ("@ThoiGian", x.ThoiGian));
    public static void Update(DbSession s, BienDongKho x)
    {
        if (s.Execute("UPDATE BienDongKho SET LoThuocId=@LoThuocId,SoLuong=@SoLuong,Loai=@Loai,ThamChieu=@ThamChieu,NguoiThucHienId=@NguoiThucHienId,ThoiGian=@ThoiGian WHERE Id=@Id", ("@LoThuocId", x.LoThuocId), ("@SoLuong", x.SoLuong), ("@Loai", x.Loai), ("@ThamChieu", x.ThamChieu), ("@NguoiThucHienId", x.NguoiThucHienId), ("@ThoiGian", x.ThoiGian), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }
}
