using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class HangDoiService 
{


public static List<LuotKhamRow> List(DateTime day, int? doctor = null, string q = "") { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static PhongChoData Room() { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static void Priority(int id, bool priority) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static void ChangeDoctor(int id, int doctor) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
