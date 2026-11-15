namespace PhongKham.Models;

public sealed class BenhNhan
{
    public int Id
    {
        get; set;
    }
    public string MaBenhNhan { get; set; } = "";
    public string CanCuocCongDan { get; set; } = "";
    public string HoTen { get; set; } = "";
    public DateTime NgaySinh { get; set; } = DateTime.Today;
    public string GioiTinh { get; set; } = "Khac";
    public string SoDienThoai { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public string TienSuBenh { get; set; } = "";
    public string DiUng { get; set; } = "";
    public DateTime NgayTao { get; set; } = DateTime.Now;
    
    
    
}