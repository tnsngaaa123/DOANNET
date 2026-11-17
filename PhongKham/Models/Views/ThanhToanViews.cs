namespace PhongKham.Models.Views;

public sealed class ThanhToanRow
{
    public int BenhNhanId
    {
        get; set;
    }
    public HoaDon HoaDon { get; set; } = new();
    public string HoTen { get; set; } = "";
    public string CanCuocCongDan { get; set; } = "";
    public string TenNguoiThu { get; set; } = "";
    public int Id => HoaDon.Id;
    public string MaHoaDon => HoaDon.MaHoaDon;
    public DateTime NgayThanhToan => HoaDon.NgayThanhToan;
    public long TienKham => HoaDon.TienKham;
    public long TienThuoc => HoaDon.TienThuoc;
    public long GiamGia => HoaDon.GiamGia;
    public long TongThu => HoaDon.TongThu;
    public string HinhThuc => HoaDon.HinhThuc;
}

public sealed class TinhTienKetQua
{
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
}

public sealed class HoaDonChiTiet
{
    public HoaDon HoaDon { get; set; } = new();
    public PhieuKhamChiTiet LuotKham { get; set; } = new();
    public string TenNguoiThu { get; set; } = "";
}
