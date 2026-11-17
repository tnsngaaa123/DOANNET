using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class ThanhToanService 
{


public static List<LuotKhamRow> Waiting() { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static PhieuKhamChiTiet VisitDetail(int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static List<ThanhToanRow> Paid(DateTime? day = null, string method = "", string q = "") { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static List<ThanhToanRow> History(int patient) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static HoaDonChiTiet Detail(DbSession s, int bill) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static HoaDonChiTiet Detail(int bill) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static TinhTienKetQua Calculate(long fee, long drugs, decimal discount, bool percent, string method, long given) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static int Pay(int id, long fee, decimal discount, bool percent, string method, long given) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
