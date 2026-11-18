namespace PhongKham.Models.Views;

public sealed class PhongChoTongHopData
{
    public PhongChoData ChoKham { get; set; } = new();
    public PhongChoData ChoThanhToan { get; set; } = new();
    public PhongChoData ChoLayThuoc { get; set; } = new();
}
