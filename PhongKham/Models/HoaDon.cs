namespace PhongKham.Models;

public sealed class HoaDon
{
    public int Id
    {
        get; set;
    }
    public string MaHoaDon { get; set; } = "";
    public int PhieuKhamId
    {
        get; set;
    }
    public int NguoiThuId
    {
        get; set;
    }
    public DateTime NgayThanhToan { get; set; } = DateTime.Now;
    public long TienKham
    {
        get; set;
    }
    public long TienThuoc
    {
        get; set;
    }
    public long GiamGia
    {
        get; set;
    }
    public long TongThu
    {
        get; set;
    }
    public long TienKhachDua
    {
        get; set;
    }
    public long TienThua
    {
        get; set;
    }
    public string HinhThuc { get; set; } = "TienMat";
}