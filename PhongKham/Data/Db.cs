using System.Globalization;
using System.Text;
using Microsoft.Data.Sqlite;
using PhongKham.Core;

namespace PhongKham.Data;

public static class Db
{
    public static string DatabaseFile { get; private set; } = AppPaths.DatabaseFile;

    public static void ConfigureFile(string path) => DatabaseFile = Path.GetFullPath(path);
    public static string Day(DateTime value) => value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    public static string KhongDau(string? value)
    {
        var s = new StringBuilder();
        foreach (char c in (value ?? "").Normalize(NormalizationForm.FormD))
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                s.Append(c is 'đ' or 'Đ' ? 'd' : char.ToLowerInvariant(c));
        return s.ToString().Normalize(NormalizationForm.FormC);
    }

    public static SqliteConnection Open()
    {
        var c = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = DatabaseFile, ForeignKeys = true, DefaultTimeout = 5, Pooling = false }.ToString());
        try
        {
            c.Open();
            c.CreateFunction<string?, string>("khong_dau", KhongDau, isDeterministic: true);
            using var cmd = c.CreateCommand();
            cmd.CommandText = "PRAGMA foreign_keys=ON;PRAGMA busy_timeout=5000;";
            cmd.ExecuteNonQuery();
            return c;
        }
        catch
        {
            c.Dispose();
            throw;
        }
    }

    public static T Run<T>(Func<DbSession, T> work)
    {
        using var c = Open();
        return work(new DbSession(c));
    }

    public static void Run(Action<DbSession> work) => Run(s =>
    {
        work(s);
        return 0;
    });
    public static T InTransaction<T>(Func<DbSession, T> work)
    {
        using var c = Open();
        try
        {
            using var tx = c.BeginTransaction(deferred: false);
            try
            {
                var result = work(new DbSession(c, tx));
                tx.Commit();
                return result;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
        catch (SqliteException e) when (e.SqliteErrorCode is 19 or 5 or 6)
        {
            throw new NghiepVuException(e.SqliteErrorCode == 19 ? "Dữ liệu trùng, không hợp lệ hoặc đang được tham chiếu. Hãy tải lại." : "Cơ sở dữ liệu đang bận. Hãy thử lại.");
        }
        catch (OverflowException)
        {
            throw new NghiepVuException("Số lượng hoặc tiền vượt giới hạn lưu trữ.");
        }
    }

    public static void InTransaction(Action<DbSession> work) => InTransaction(s =>
    {
        work(s);
        return 0;
    });
}
