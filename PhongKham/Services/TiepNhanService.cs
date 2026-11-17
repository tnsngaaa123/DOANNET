using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class TiepNhanService 
{


public static List<LuotKhamRow> List(string q = "") { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static int Save(BenhNhan input, int doctor, string type, bool priority) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static PhieuSoData Issue(int id) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
