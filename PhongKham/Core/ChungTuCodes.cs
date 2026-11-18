using System.Globalization;
using PhongKham.Models;

namespace PhongKham.Core;

public static class ChungTuCodes
{
    public static string HoaDon(PhieuKham visit) => "HD" + visit.NgayKham.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + visit.Id.ToString("D4", CultureInfo.InvariantCulture);
    public static string DonThuoc(PhieuKham visit) => "DT" + visit.NgayKham.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + visit.Id.ToString("D4", CultureInfo.InvariantCulture);
    public static string BienLai(DateTime paidOn, int receiptId) => "BL" + paidOn.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + receiptId.ToString("D4", CultureInfo.InvariantCulture);
}