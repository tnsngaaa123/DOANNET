namespace PhongKham.Models.Views;

public sealed class NgayThongKeRow
{
    public long TienKham { get; set; }
    public long TienThuoc { get; set; }
    public long GiamGia { get; set; }
    public DateTime Ngay
    {
        get; set;
    }
    public int SoLuot
    {
        get; set;
    }
    public long DoanhThu
    {
        get; set;
    }
}

public sealed class DashboardData
{
    public int LuotKhamHomNay
    {
        get; set;
    }
    public long DoanhThuHomNay
    {
        get; set;
    }
    public List<NgayThongKeRow> BayNgay { get; set; } = new();
}
