using PhongKham.Data;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class DashboardService
{
    public static DashboardData Get(DateTime? selectedDay = null) => Db.Run(s =>
    {
        AuthService.Require(s);
        var end = (selectedDay ?? DateTime.Today).Date;
        if (end.Year < 1900 || end.Year > 9998)
            throw new PhongKham.Core.NghiepVuException("Chọn ngày từ năm 1900 đến 9998.");
        var rows = BaoCaoService.ReadRows(s, end.AddDays(-6), end.AddDays(1));

        return new DashboardData
        {
            LuotKhamHomNay = rows[^1].SoLuot,
            DoanhThuHomNay = rows[^1].DoanhThu,
            BayNgay = rows
        };
    });
}