namespace PhongKham.Models;

public sealed class LoThuoc
{
    public int Id
    {
        get; set;
    }
    public int ThuocId
    {
        get; set;
    }
    public string SoLo { get; set; } = "";
    public DateTime HanSuDung { get; set; } = DateTime.Today;
    public int SoLuongNhap
    {
        get; set;
    }
    public int SoLuongTon
    {
        get; set;
    }
    public DateTime NgayNhap { get; set; } = DateTime.Now;
    public int NguoiNhapId
    {
        get; set;
    }
}