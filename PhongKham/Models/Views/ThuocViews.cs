namespace PhongKham.Models.Views;

public sealed class GoiYThuoc
{
    public int ThuocId
    {
        get; set;
    }
    public string MaThuoc { get; set; } = "";
    public string TenThuoc { get; set; } = "";
    public string DonViTinh { get; set; } = "";
    public int NhomThuocId
    {
        get; set;
    }
    public long GiaBan
    {
        get; set;
    }
    public int SoLuongCon
    {
        get; set;
    }

    public override string ToString() => MaThuoc + " — " + TenThuoc;
}

public sealed class ThuocRow
{
    public Thuoc Thuoc { get; set; } = new();
    public string TenNhom { get; set; } = "";
    public int SoLuongCon
    {
        get; set;
    }
    public int Id => Thuoc.Id;
    public string MaThuoc => Thuoc.MaThuoc;
    public string TenThuoc => Thuoc.TenThuoc;
    public string DonViTinh => Thuoc.DonViTinh;
    public long GiaBan => Thuoc.GiaBan;
}

public sealed class ThemThuocInput
{
    public Thuoc Thuoc { get; set; } = new();
    public int SoLuong
    {
        get; set;
    }
    public DateTime HanSuDung
    {
        get; set;
    }
}

public sealed class KetQuaThemThuoc
{
    public int ThuocId
    {
        get; set;
    }
    public string TenThuoc { get; set; } = "";
    public int SoLuongThem
    {
        get; set;
    }
    public int SoLuongCon
    {
        get; set;
    }
    public bool LaThuocMoi
    {
        get; set;
    }
}

public sealed class HanDungRow
{
    public string TenNhom { get; set; } = "";
    public string DonViTinh { get; set; } = "";
    public int LoThuocId
    {
        get; set;
    }
    public int ThuocId
    {
        get; set;
    }
    public string MaThuoc { get; set; } = "";
    public string TenThuoc { get; set; } = "";
    public string SoLo { get; set; } = "";
    public DateTime HanSuDung
    {
        get; set;
    }
    public int SoLuongTon
    {
        get; set;
    }
    public int SoLuongDaHetHan => HanSuDung.Date < DateTime.Today ? SoLuongTon : 0;
    public string NgayConLai => HanSuDung.Date < DateTime.Today ? "Hết hạn" : (HanSuDung.Date - DateTime.Today).Days + " ngày";
}

public sealed class SoLuongThuocRow
{
    public int ThuocId
    {
        get; set;
    }
    public string TenThuoc { get; set; } = "";
    public string DonViTinh { get; set; } = "";
    public int SoLuongCon
    {
        get; set;
    }
}

public sealed class KetQuaXuatThuocRow
{
    public string TenThuoc { get; set; } = "";
    public string DonViTinh { get; set; } = "";
    public int SoLuongDaXuat
    {
        get; set;
    }
    public int SoLuongCon
    {
        get; set;
    }
}
