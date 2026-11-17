using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class ThuocService 
{


public static List<NhomThuoc> Groups() { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static Thuoc Get(int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static int Available(DbSession s, int drug, int? exclude = null) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static int KhaDung(int drug, int? exclude = null) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static List<ThuocRow> List(string q = "") { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static IReadOnlyList<GoiYThuoc> GoiY(string q, int? exclude = null) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static void Validate(DbSession s, ThemThuocInput x) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static KetQuaThemThuoc Add(DbSession s, ThemThuocInput input, NguoiDung actor) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static void UpdateInfo(Thuoc input) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static KetQuaThemThuoc Add(ThemThuocInput input) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
