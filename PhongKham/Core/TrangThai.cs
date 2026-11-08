namespace PhongKham.Core;

public static class TrangThai
{
    public const string ChoKham = "ChoKham";
    public const string DangKham = "DangKham";
    public const string ChoThanhToan = "ChoThanhToan";
    public const string ChoXuatThuoc = "ChoXuatThuoc";
    public const string HoanTat = "HoanTat";
    public const string DaKe = "DaKe";
    public const string DaXuat = "DaXuat";
    public const string DaThanhToan = "DaThanhToan";
    public const string KhamMoi = "KhamMoi";
    public const string TaiKham = "TaiKham";
    public const string TienMat = "TienMat";
    public const string ChuyenKhoan = "ChuyenKhoan";
    public const string Nhap = "Nhap";
    public const string Xuat = "Xuat";
    public const string Nam = "Nam";
    public const string Nu = "Nu";
    public const string Khac = "Khac";
    public const string TruocAn = "TruocAn";
    public const string SauAn = "SauAn";
    public const string TrongBuaAn = "TrongBuaAn";
    public const string KhongQuyDinh = "KhongQuyDinh";
    public static string TenHienThi(string value) => value switch
    {
        "ChoKham" => "Chờ khám",
        "DangKham" => "Đang khám",
        "ChoThanhToan" => "Chờ thanh toán",
        "ChoXuatThuoc" => "Chờ lấy thuốc",
        "HoanTat" => "Hoàn tất",
        "DaKe" => "Đang kê",
        "DaXuat" => "Đã xuất",
        "DaThanhToan" => "Đã thanh toán",
        "KhamMoi" => "Khám mới",
        "TaiKham" => "Tái khám",
        "TienMat" => "Tiền mặt",
        "ChuyenKhoan" => "Chuyển khoản",
        "Nhap" => "Thêm thuốc",
        "Xuat" => "Xuất thuốc",
        "Nam" => "Nam",
        "Nu" => "Nữ",
        "Khac" => "Khác",
        "TruocAn" => "Trước ăn",
        "SauAn" => "Sau ăn",
        "TrongBuaAn" => "Trong bữa ăn",
        "KhongQuyDinh" => "Không quy định",
        _ => value
    };
}