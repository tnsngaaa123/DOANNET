using System.Text.RegularExpressions;
using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class BenhNhanService 
{


public static void ValidateCanCuoc(string cccd) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static void Validate(BenhNhan x) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static int Create(DbSession s, BenhNhan x) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static int Create(BenhNhan x) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static BenhNhan? FindCanCuoc(string cccd) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static List<BenhNhan> List(string q = "", DateTime? from = null, DateTime? to = null) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static BenhNhan Get(int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static List<LichSuKhamRow> History(int patient) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static PhieuKhamChiTiet HistoryDetail(int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
