namespace PhongKham.Models;

public sealed class ChiTietDonThuoc
{
    public int Id
    {
        get; set;
    }
    public int DonThuocId
    {
        get; set;
    }
    public int ThuocId
    {
        get; set;
    }
    public int SoLuong
    {
        get; set;
    }
    public long DonGia
    {
        get; set;
    }
    public string LieuDung { get; set; } = "";
    public double Sang
    {
        get; set;
    }
    public double Trua
    {
        get; set;
    }
    public double Chieu
    {
        get; set;
    }
    public double Toi
    {
        get; set;
    }
    public int SoNgay { get; set; } = 1;
    public string ThoiDiemUong { get; set; } = "SauAn";

}