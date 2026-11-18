using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class CanhBaoThuocService 
{


public static MucCanhBao MauHanDung(DateTime expiry, DateTime? today = null) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static MucCanhBao MauSoLuong(int qty) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static bool DungLocHan(DateTime expiry, LocHanDung filter, DateTime? today = null) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static List<HanDungRow> HanDung(string q, LocHanDung filter) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static List<SoLuongThuocRow> SoLuong(string q, int? lessThan = null) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
