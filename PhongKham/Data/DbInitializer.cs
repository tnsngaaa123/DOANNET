using PhongKham.Core;
using PhongKham.Models;
using PhongKham.Data.Repositories;

namespace PhongKham.Data;

public static class DbInitializer
{
    public static string ReadSql(string file)
    {
        var a = typeof(DbInitializer).Assembly;
        string name = a.GetManifestResourceNames().Single(n => n.EndsWith(".Data." + file, StringComparison.Ordinal));
        using var stream = a.GetManifestResourceStream(name)!;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    public static void Initialize(bool withDemoData = true)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(Db.DatabaseFile)!);
        using (var c = Db.Open())
        {
            using var cmd = c.CreateCommand();
            cmd.CommandText = "PRAGMA journal_mode=WAL;";
            cmd.ExecuteScalar();
        }

        Db.InTransaction(s =>
        {
            int version = Convert.ToInt32(s.Scalar("PRAGMA user_version"));
            if (version == 1)
            {
                UpdateReceiptCodes(s);
                return;
            }
            if (version != 0 || Convert.ToInt32(s.Scalar("SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'")) != 0)
                throw new NghiepVuException("CSDL chưa được hỗ trợ; không có dữ liệu nào bị xóa.");
            s.Execute(ReadSql("Schema.sql"));
            var users = new[]
            {
                ("admin", "Quản trị viên", Roles.Admin, "Admin@123"),
                ("letan", "Lễ tân mẫu", Roles.LeTan, "LeTan@123"),
                ("bacsi1", "Bác sĩ mẫu 1", Roles.BacSi, "BacSi1@123"),
                ("bacsi2", "Bác sĩ mẫu 2", Roles.BacSi, "BacSi2@123"),
                ("thungan", "Thu ngân mẫu", Roles.ThuNgan, "ThuNgan@123"),
                ("duocsi", "Dược sĩ mẫu", Roles.DuocSi, "DuocSi@123")
            };
            foreach (var u in users)
                NguoiDungRepository.Insert(s, new NguoiDung { TenDangNhap = u.Item1, HoTen = u.Item2, VaiTro = u.Item3, MatKhauHash = PasswordHasher.Hash(u.Item4), TrangThai = true });
            s.Execute(ReadSql("Seed.sql"));
            if (withDemoData)
                DemoSeeder.Seed(s, DateTime.Today);
            s.Execute("PRAGMA user_version=1");
        });
    }

    private static void UpdateReceiptCodes(DbSession s)
    {
        foreach (var receipt in HoaDonRepository.All(s))
        {
            string code = ChungTuCodes.BienLai(receipt.NgayThanhToan, receipt.Id);
            if (receipt.MaHoaDon == code) continue;
            s.Execute("UPDATE HoaDon SET MaHoaDon=@code WHERE Id=@id", ("@code", code), ("@id", receipt.Id));
        }
    }
}
