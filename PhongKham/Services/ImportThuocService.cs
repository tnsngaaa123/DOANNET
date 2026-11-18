using System.Globalization;
using System.Text;
using ExcelDataReader;
using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class ImportThuocService 
{
public static readonly string[] Columns =
    {
        "MaThuoc",
        "TenThuoc",
        "DonViTinh",
        "NhomThuoc",
        "GiaBan",
        "SoLuong",
        "HanSuDung"
    };

static ImportThuocService()  { }
public static List<ImportThuocRow> Preview(string path) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
private static bool TryDate(object? value, out DateTime date) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
public static ImportThuocKetQua Add(IReadOnlyList<ImportThuocRow> rows) { throw new PhongKham.Core.NghiepVuException("Chức năng chưa được bật ở mốc này."); }
}
