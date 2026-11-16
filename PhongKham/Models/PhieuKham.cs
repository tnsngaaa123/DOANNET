namespace PhongKham.Models;

public sealed class PhieuKham
{
    public int Id
    {
        get; set;
    }
    public string MaPhieuKham { get; set; } = "";
    
    public int BenhNhanId
    {
        get; set;
    }
    public int BacSiId
    {
        get; set;
    }
    public int NguoiTiepNhanId
    {
        get; set;
    }

    public DateTime NgayKham { get; set; } = DateTime.Today;
    public int SoThuTu
    {
        get; set;
    }

    public string LoaiKham { get; set; } = "KhamMoi";
    public bool UuTien
    {
        get; set;
    }

    public string TrangThai { get; set; } = "ChoKham";
    public bool DaInSoKham
    {
        get; set;
    }
    public DateTime? InSoKhamLuc
    {
        get; set;
    }

    public string TrieuChung { get; set; } = "";
    public string ChanDoan { get; set; } = "";
    public string KetQua { get; set; } = "";
    public string LoiDan { get; set; } = "";
    public DateTime NgayTao { get; set; } = DateTime.Now;
    
    public DateTime? GioGoi
    {
        get; set;
    }
    public DateTime? GioHoanTat
    {
        get; set;
    }

}