namespace PhongKham.Models.Views;

public sealed class ImportThuocRow
{
    public int DongExcel
    {
        get; set;
    }
    public ThemThuocInput Input { get; set; } = new();
    public string TenNhom { get; set; } = "";
    public string Loi { get; set; } = "";
    public string XuLy { get; set; } = "";
    public string MaThuoc => Input.Thuoc.MaThuoc;
    public string TenThuoc => Input.Thuoc.TenThuoc;
    public string DonViTinh => Input.Thuoc.DonViTinh;
    public long GiaBan => Input.Thuoc.GiaBan;
    public int SoLuong => Input.SoLuong;
    public DateTime HanSuDung => Input.HanSuDung;
    public bool HopLe => Loi == "";
}

public sealed class ImportThuocKetQua
{
    public int DongThanhCong
    {
        get; set;
    }
    public int DongLoi
    {
        get; set;
    }
    public int ThuocMoi
    {
        get; set;
    }
    public int LuotCongThem
    {
        get; set;
    }
    public int TongSoLuong
    {
        get; set;
    }
}
