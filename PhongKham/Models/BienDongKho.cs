namespace PhongKham.Models;

public sealed class BienDongKho
{
    public int Id
    {
        get; set;
    }
    public int LoThuocId
    {
        get; set;
    }
    public int SoLuong
    {
        get; set;
    }
    public string Loai { get; set; } = "Nhap";
    public string ThamChieu { get; set; } = "";
    public int NguoiThucHienId
    {
        get; set;
    }
    public DateTime ThoiGian { get; set; } = DateTime.Now;
}