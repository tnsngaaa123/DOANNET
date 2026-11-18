namespace PhongKham.Models.Views;

public enum KyBaoCao { Ngay, Thang, Quy, Nam }

public sealed class BaoCaoData
{
    public KyBaoCao Ky { get; set; }
    public string TieuDe { get; set; } = "";
    public string TenPhongKham { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
    public string NguoiLap { get; set; } = "";
    public DateTime TuNgay { get; set; }
    public DateTime DenNgay { get; set; }
    public List<NgayThongKeRow> CacNgay { get; set; } = new();
    public int TongLuot => CacNgay.Sum(x => x.SoLuot);
    public long TongTienKham => CacNgay.Sum(x => x.TienKham);
    public long TongTienThuoc => CacNgay.Sum(x => x.TienThuoc);
    public long TongGiamGia => CacNgay.Sum(x => x.GiamGia);
    public long TongDoanhThu => CacNgay.Sum(x => x.DoanhThu);
}
