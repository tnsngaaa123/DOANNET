namespace PhongKham.Models;

public sealed class DonThuoc
{
    public int Id
    {
        get; set;
    }
    public int PhieuKhamId
    {
        get; set;
    }
    public DateTime NgayKe { get; set; } = DateTime.Now;
    public string TrangThai { get; set; } = "DaKe";
    
    
    public DateTime? NgayXuat
    {
        get; set;
    }
    public int? NguoiXuatId
    {
        get; set;
    }

}