namespace PhongKham.Models.Views;

public sealed class LuotKhamRow
{
    public PhieuKham Phieu { get; set; } = new();
    public string HoTen { get; set; } = "";
    public string CanCuocCongDan { get; set; } = "";
    public DateTime NgaySinh
    {
        get; set;
    }
    public string TenBacSi { get; set; } = "";
    public int Id => Phieu.Id;
    public int SoThuTu => Phieu.SoThuTu;
    public string MaPhieuKham => Phieu.MaPhieuKham;
    public string TrangThai => Phieu.TrangThai;
    public bool UuTien => Phieu.UuTien;
    public bool DaInSoKham => Phieu.DaInSoKham;
}

public sealed class PhieuKhamChiTiet
{
    public PhieuKham Phieu { get; set; } = new();
    public BenhNhan BenhNhan { get; set; } = new();
    public string TenBacSi { get; set; } = "";
    public List<DongDonThuocRow> CacThuoc { get; set; } = new();
}

public sealed class LichSuKhamRow
{
    public int PhieuKhamId
    {
        get; set;
    }
    public DateTime NgayKham
    {
        get; set;
    }
    public string TenBacSi { get; set; } = "";
    public string TrieuChung { get; set; } = "";
    public string ChanDoan { get; set; } = "";
    public string KetQua { get; set; } = "";
    public string LoiDan { get; set; } = "";
}

public sealed class DongDonThuocRow
{
    public ChiTietDonThuoc Dong { get; set; } = new();
    public string TenThuoc { get; set; } = "";
    public string DonViTinh { get; set; } = "";
    public int ThuocId => Dong.ThuocId;
    public int SoLuong => Dong.SoLuong;
    public long DonGia => Dong.DonGia;
    public long ThanhTien => checked((long)Dong.SoLuong * Dong.DonGia);
    public string LieuDung => Dong.LieuDung;
}

public sealed class BatDauKhamKetQua
{
    public int PhieuKhamId
    {
        get; set;
    }
    public bool CoPhieuDangKham
    {
        get; set;
    }
}

public sealed class PhongChoData
{
    public string SoDangKham { get; set; } = "";
    public List<LuotKhamRow> DangCho { get; set; } = new();
}
