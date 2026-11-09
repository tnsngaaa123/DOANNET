namespace PhongKham.Models;

public sealed class NguoiDung
{
    public int Id
    {
        get; set;
    }
    public string TenDangNhap { get; set; } = "";
    public string MatKhauHash { get; set; } = "";
    public string HoTen { get; set; } = "";
    public string VaiTro { get; set; } = "Admin";
    public bool TrangThai { get; set; } = true;
}