namespace PhongKham.Models.Views;

public sealed class PhieuSoData
{
    public PhieuKhamChiTiet LuotKham { get; set; } = new();
    public string TenPhongKham { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
}

public sealed class BienLaiData
{
    public HoaDonChiTiet ChiTiet { get; set; } = new();
    public string TenPhongKham { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
}

public sealed class DanhSachPrintData
{
    public string DiaChi { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
    public string NguoiLap { get; set; } = "";
    public string TieuDe { get; set; } = "";
    public string TenPhongKham { get; set; } = "";
    public string MoTaBoLoc { get; set; } = "";
    public string[] Cot { get; set; } = Array.Empty<string>();
    public List<string[]> Dong { get; set; } = new();
}

public sealed class HoanTatKhamPrintData
{
    public PhieuKhamChiTiet LuotKham { get; set; } = new();
    public string TenPhongKham { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
    public long TienKham { get; set; }
    public bool DaThanhToan { get; set; }
    public long GiamGia { get; set; }
}

public sealed class MauBanIn
{
    public KyBaoCao? KyBaoCao { get; set; }
    public DateTime? TuNgayBaoCao { get; set; }
    public string TenFilePdf { get; set; } = "";
    public int? SoThuTu { get; set; }
    public string HuongDanCho { get; set; } = "";
    public string TieuDe { get; set; } = "";
    public string MaChungTu { get; set; } = "";
    public string TenPhongKham { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
    public string TrangThai { get; set; } = "";
    public string MoTa { get; set; } = "";
    public DateTime NgayLap { get; set; } = DateTime.Now;
    public List<string> ThongTin { get; set; } = new();
    public string[] Cot { get; set; } = Array.Empty<string>();
    public float[] TyLeCot { get; set; } = Array.Empty<float>();
    public List<string[]> Dong { get; set; } = new();
    public List<string> TongKet { get; set; } = new();
    public string GhiChu { get; set; } = "";
    public string ChuKyTrai { get; set; } = "Người nhận";
    public string ChuKyPhai { get; set; } = "Người lập";
    public string TenNguoiLap { get; set; } = "";
}
