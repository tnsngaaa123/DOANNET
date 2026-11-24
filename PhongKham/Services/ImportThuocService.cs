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
    static ImportThuocService() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
    public static List<ImportThuocRow> Preview(string path)
    {
        if (!string.Equals(Path.GetExtension(path), ".xlsx", StringComparison.OrdinalIgnoreCase))
            throw new NghiepVuException("Chỉ nhận file Excel .xlsx.");
        return Db.Run(s =>
        {
            AuthService.Require(s, Roles.DuocSi);
            try
            {
                using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                if (!reader.Read())
                    throw new NghiepVuException("File không có tiêu đề.");
                var headers = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string key = Convert.ToString(reader.GetValue(i), CultureInfo.InvariantCulture)?.Trim() ?? "";
                    if (key != "" && !headers.TryAdd(key, i))
                        throw new NghiepVuException("Tiêu đề trùng: " + key);
                }

                var missing = Columns.Where(c => !headers.ContainsKey(c)).ToList();
                if (missing.Count > 0)
                    throw new NghiepVuException("Thiếu cột: " + string.Join(", ", missing));
                var groups = NhomThuocRepository.All(s);
                var seen = ThuocRepository.All(s).Select(t => t.MaThuoc).ToHashSet(StringComparer.OrdinalIgnoreCase);
                var rows = new List<ImportThuocRow>();
                int number = 1;
                while (reader.Read())
                {
                    if (++number > 10001)
                        throw new NghiepVuException("Mỗi lần thêm tối đa 10.000 dòng.");
                    object? Cell(string name) => reader.GetValue(headers[name]);
                    string Text(string name) => Convert.ToString(Cell(name), CultureInfo.InvariantCulture)?.Trim() ?? "";
                    if (Columns.All(c => Text(c) == ""))
                        continue;
                    var row = new ImportThuocRow
                    {
                        DongExcel = number,
                        TenNhom = Text("NhomThuoc")
                    };
                    var t = new Thuoc
                    {
                        MaThuoc = Text("MaThuoc"),
                        TenThuoc = Text("TenThuoc"),

                        DonViTinh = Text("DonViTinh"),
                        NhomThuocId = groups.FirstOrDefault(g => string.Equals(g.TenNhom, Text("NhomThuoc"), StringComparison.OrdinalIgnoreCase))?.Id ?? 0
                    };
                    row.Input = new ThemThuocInput
                    {
                        Thuoc = t
                    };
                    row.XuLy = seen.Contains(t.MaThuoc) ? "Cộng thêm số lượng" : "Thêm thuốc mới";
                    seen.Add(t.MaThuoc);
                    bool dateOk = TryDate(Cell("HanSuDung"), out DateTime expiry);
                    if (!long.TryParse(Text("GiaBan"), NumberStyles.Integer, CultureInfo.InvariantCulture, out long price) || !int.TryParse(Text("SoLuong"), NumberStyles.Integer, CultureInfo.InvariantCulture, out int quantity) || !dateOk)
                        row.Loi = "Giá/số lượng phải là số nguyên; hạn dùng là ngày hợp lệ (dd/MM/yyyy).";
                    else
                    {
                        t.GiaBan = price;
                        row.Input.SoLuong = quantity;
                        row.Input.HanSuDung = expiry.Date;
                        try
                        {
                            ThuocService.Validate(s, row.Input);
                        }
                        catch (NghiepVuException e)
                        {
                            row.Loi = e.Message;
                        }
                    }

                    rows.Add(row);
                }

                return rows;
            }
            catch (NghiepVuException)
            {
                throw;
            }
            catch (Exception e) when (e is IOException or InvalidDataException or ArgumentException or ExcelDataReader.Exceptions.ExcelReaderException or System.Xml.XmlException)
            {
                throw new NghiepVuException("Không đọc được Excel: " + e.Message);
            }
        });
    }

    private static bool TryDate(object? value, out DateTime date)
    {
        if (value is DateTime d)
        {
            date = d;
            return true;
        }

        if (value is double number)
        {
            try
            {
                date = DateTime.FromOADate(number);
                return true;
            }
            catch (ArgumentException)
            {
                date = default;
                return false;
            }
        }

        return DateTime.TryParseExact(Convert.ToString(value, CultureInfo.InvariantCulture)?.Trim(), new[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd", "yyyy-MM-dd HH:mm:ss" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    }

    public static ImportThuocKetQua Add(IReadOnlyList<ImportThuocRow> rows) => Db.InTransaction(s =>
    {
        var actor = AuthService.Require(s, Roles.DuocSi);
        if (!rows.Any(x => x.HopLe))
            throw new NghiepVuException("Chưa có dòng hợp lệ để thêm thuốc.");
        var result = new ImportThuocKetQua
        {
            DongLoi = rows.Count(x => !x.HopLe)
        };
        foreach (var row in rows.Where(x => x.HopLe))
        {
            var added = ThuocService.Add(s, row.Input, actor);
            result.DongThanhCong++;
            result.TongSoLuong = checked(result.TongSoLuong + added.SoLuongThem);
            if (added.LaThuocMoi)
                result.ThuocMoi++;
            else
                result.LuotCongThem++;
        }

        return result;
    });
}
