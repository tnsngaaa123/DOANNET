using Microsoft.Data.Sqlite;
using PhongKham.Core;
using PhongKham.Models;

namespace PhongKham.Data.Repositories;

public static class PhieuKhamRepository
{
    public static PhieuKham Map(SqliteDataReader r) => new()
    {
        Id = DbSession.Int(r, "Id"),
        MaPhieuKham = DbSession.Text(r, "MaPhieuKham"),
        BenhNhanId = DbSession.Int(r, "BenhNhanId"),
        BacSiId = DbSession.Int(r, "BacSiId"),
        NguoiTiepNhanId = DbSession.Int(r, "NguoiTiepNhanId"),
        NgayKham = DbSession.Date(r, "NgayKham"),
        SoThuTu = DbSession.Int(r, "SoThuTu"),
        LoaiKham = DbSession.Text(r, "LoaiKham"),
        UuTien = DbSession.Bool(r, "UuTien"),
        TrangThai = DbSession.Text(r, "TrangThai"),
        DaInSoKham = DbSession.Bool(r, "DaInSoKham"),
        InSoKhamLuc = DbSession.NullableDate(r, "InSoKhamLuc"),
        TrieuChung = DbSession.Text(r, "TrieuChung"),
        ChanDoan = DbSession.Text(r, "ChanDoan"),
        KetQua = DbSession.Text(r, "KetQua"),
        LoiDan = DbSession.Text(r, "LoiDan"),
        NgayTao = DbSession.Date(r, "NgayTao"),
        GioGoi = DbSession.NullableDate(r, "GioGoi"),
        GioHoanTat = DbSession.NullableDate(r, "GioHoanTat")
    };
    public static PhieuKham? Get(DbSession s, int id) => s.Query("SELECT * FROM PhieuKham WHERE Id=@id", Map, ("@id", id)).FirstOrDefault();
    public static List<PhieuKham> All(DbSession s) => s.Query("SELECT * FROM PhieuKham ORDER BY Id", Map);
    public static int Insert(DbSession s, PhieuKham x) => s.Insert("INSERT INTO PhieuKham(MaPhieuKham,BenhNhanId,BacSiId,NguoiTiepNhanId,NgayKham,SoThuTu,LoaiKham,UuTien,TrangThai,DaInSoKham,InSoKhamLuc,TrieuChung,ChanDoan,KetQua,LoiDan,NgayTao,GioGoi,GioHoanTat) VALUES(@MaPhieuKham,@BenhNhanId,@BacSiId,@NguoiTiepNhanId,@NgayKham,@SoThuTu,@LoaiKham,@UuTien,@TrangThai,@DaInSoKham,@InSoKhamLuc,@TrieuChung,@ChanDoan,@KetQua,@LoiDan,@NgayTao,@GioGoi,@GioHoanTat)", ("@MaPhieuKham", x.MaPhieuKham), ("@BenhNhanId", x.BenhNhanId), ("@BacSiId", x.BacSiId), ("@NguoiTiepNhanId", x.NguoiTiepNhanId), ("@NgayKham", Db.Day(x.NgayKham)), ("@SoThuTu", x.SoThuTu), ("@LoaiKham", x.LoaiKham), ("@UuTien", x.UuTien), ("@TrangThai", x.TrangThai), ("@DaInSoKham", x.DaInSoKham), ("@InSoKhamLuc", x.InSoKhamLuc), ("@TrieuChung", x.TrieuChung), ("@ChanDoan", x.ChanDoan), ("@KetQua", x.KetQua), ("@LoiDan", x.LoiDan), ("@NgayTao", x.NgayTao), ("@GioGoi", x.GioGoi), ("@GioHoanTat", x.GioHoanTat));
    public static void Update(DbSession s, PhieuKham x)
    {
        if (s.Execute("UPDATE PhieuKham SET MaPhieuKham=@MaPhieuKham,BenhNhanId=@BenhNhanId,BacSiId=@BacSiId,NguoiTiepNhanId=@NguoiTiepNhanId,NgayKham=@NgayKham,SoThuTu=@SoThuTu,LoaiKham=@LoaiKham,UuTien=@UuTien,TrangThai=@TrangThai,DaInSoKham=@DaInSoKham,InSoKhamLuc=@InSoKhamLuc,TrieuChung=@TrieuChung,ChanDoan=@ChanDoan,KetQua=@KetQua,LoiDan=@LoiDan,NgayTao=@NgayTao,GioGoi=@GioGoi,GioHoanTat=@GioHoanTat WHERE Id=@Id", ("@MaPhieuKham", x.MaPhieuKham), ("@BenhNhanId", x.BenhNhanId), ("@BacSiId", x.BacSiId), ("@NguoiTiepNhanId", x.NguoiTiepNhanId), ("@NgayKham", Db.Day(x.NgayKham)), ("@SoThuTu", x.SoThuTu), ("@LoaiKham", x.LoaiKham), ("@UuTien", x.UuTien), ("@TrangThai", x.TrangThai), ("@DaInSoKham", x.DaInSoKham), ("@InSoKhamLuc", x.InSoKhamLuc), ("@TrieuChung", x.TrieuChung), ("@ChanDoan", x.ChanDoan), ("@KetQua", x.KetQua), ("@LoiDan", x.LoiDan), ("@NgayTao", x.NgayTao), ("@GioGoi", x.GioGoi), ("@GioHoanTat", x.GioHoanTat), ("@Id", x.Id)) != 1)
            throw new NghiepVuException("Dữ liệu không còn tồn tại. Hãy tìm lại.");
    }

    public static int NextNumber(DbSession s, DateTime day, int doctor)
    {
        string key = "STT_" + Db.Day(day) + "_" + doctor;
        int highest = Convert.ToInt32(s.Scalar("SELECT COALESCE(MAX(SoThuTu),0) FROM PhieuKham WHERE NgayKham=@d AND BacSiId=@b", ("@d", Db.Day(day)), ("@b", doctor)));
        int last = int.Parse(CauHinhRepository.Get(s, key, "0"), System.Globalization.CultureInfo.InvariantCulture);
        int next = checked(Math.Max(highest, last) + 1);
        CauHinhRepository.Set(s, key, next.ToString(System.Globalization.CultureInfo.InvariantCulture));
        return next;
    }

    public static List<PhieuKham> History(DbSession s, int patient) => s.Query("SELECT * FROM PhieuKham WHERE BenhNhanId=@id AND TrangThai IN ('ChoThanhToan','ChoXuatThuoc','HoanTat') ORDER BY NgayKham DESC,Id DESC", Map, ("@id", patient));
    public static List<Models.Views.LuotKhamRow> List(DbSession s, DateTime? day = null, int? doctor = null, string? state = null, string q = "") => s.Query(@"SELECT p.*,b.HoTen,b.CanCuocCongDan,b.NgaySinh,n.HoTen AS TenBacSi FROM PhieuKham p JOIN BenhNhan b ON b.Id=p.BenhNhanId JOIN NguoiDung n ON n.Id=p.BacSiId WHERE (@day IS NULL OR p.NgayKham=@day) AND (@doctor IS NULL OR p.BacSiId=@doctor) AND (@state IS NULL OR p.TrangThai=@state) AND khong_dau(b.HoTen||' '||b.CanCuocCongDan||' '||p.MaPhieuKham) LIKE @q ORDER BY p.UuTien DESC,p.SoThuTu,p.Id", r => new Models.Views.LuotKhamRow { Phieu = Map(r), HoTen = DbSession.Text(r, "HoTen"), CanCuocCongDan = DbSession.Text(r, "CanCuocCongDan"), NgaySinh = DbSession.Date(r, "NgaySinh"), TenBacSi = DbSession.Text(r, "TenBacSi") }, ("@day", day is null ? null : Db.Day(day.Value)), ("@doctor", doctor), ("@state", state), ("@q", "%" + Db.KhongDau(q) + "%"));
    public static void ChangeState(DbSession s, int id, string oldState, string next)
    {
        if (s.Execute("UPDATE PhieuKham SET TrangThai=@n WHERE Id=@id AND TrangThai=@o", ("@n", next), ("@id", id), ("@o", oldState)) != 1)
            throw new NghiepVuException("Lượt khám đã đổi trạng thái. Hãy tìm lại.");
    }
}
