using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class KhamBenhService 
{


internal static PhieuKham RequireVisit(DbSession s, int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static List<DongDonThuocRow> Rows(DbSession s, int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static PhieuKhamChiTiet Detail(DbSession s, int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
private static PhieuKham? Active(DbSession s, NguoiDung actor) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static PhieuKham? Active() { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static List<LuotKhamRow> Waiting() { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static BatDauKhamKetQua Next() { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static PhieuKham CanEdit(DbSession s, int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static PhieuKhamChiTiet Get(int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static void Save(int id, string symptoms, string diagnosis, string result, string advice, bool complete = false) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
