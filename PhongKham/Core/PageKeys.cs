namespace PhongKham.Core;

public static class PageKeys
{
    public const string DangNhap = "dang-nhap";
    public const string TrangChu = "trang-chu";
    public const string TiepNhan = "tiep-nhan";
    public const string HangDoi = "hang-doi";
    public const string HoSoBenhNhan = "ho-so-benh-nhan";
    public const string PhongCho = "phong-cho";
    public const string DsChoKham = "ds-cho-kham";
    public const string PhieuKham = "phieu-kham";
    public const string KeDon = "ke-don";
    public const string ChoThanhToan = "cho-thanh-toan";
    public const string ThanhToan = "thanh-toan";
    public const string DaThanhToan = "da-thanh-toan";
    public const string XuatThuoc = "cho-lay-thuoc";
    public const string DanhMucThuoc = "danh-muc-thuoc";
    public const string SuaThongTinThuoc = "sua-thong-tin-thuoc";
    public const string ThemThuoc = "them-thuoc";
    public const string ThuocSapHetHan = "thuoc-sap-het-han";
    public const string ThuocSapHetHang = "thuoc-sap-het-hang";
    public const string QuanTri = "quan-tri";
}

public static class PageGroups
{
    public const string TongQuan = "Tổng quan", TiepNhan = "Tiếp nhận", KhamBenh = "Khám bệnh", DangKham = "Đang khám", ThuNgan = "Thu ngân", DuocKho = "Dược và Kho", QuanTri = "Quản trị";
    public static int OrderOf(string value) => Array.IndexOf(new[] { TongQuan, TiepNhan, KhamBenh, DangKham, ThuNgan, DuocKho, QuanTri }, value);
}