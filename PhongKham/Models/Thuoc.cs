namespace PhongKham.Models;

public sealed class Thuoc
{
    public int Id
    {
        get; set;
    }
    public string MaThuoc { get; set; } = "";
    public string TenThuoc { get; set; } = "";
    public string DonViTinh { get; set; } = "viên";
    public int NhomThuocId
    {
        get; set;
    }
    public long GiaBan
    {
        get; set;
    }
}