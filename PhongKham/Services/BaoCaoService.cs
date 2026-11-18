using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class BaoCaoService 
{


public static (DateTime From, DateTime Until) ThoiGian(KyBaoCao kind, DateTime day, int year, int month, int quarter) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
internal static List<NgayThongKeRow> ReadRows(DbSession s, DateTime from, DateTime until) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static BaoCaoData Get(KyBaoCao kind, DateTime day, int year, int month, int quarter) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
