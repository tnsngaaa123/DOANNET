using System.Globalization;
using Microsoft.Data.Sqlite;

namespace PhongKham.Data;

public sealed class DbSession
{
    private readonly SqliteConnection _connection;
    private readonly SqliteTransaction? _transaction;
    public DbSession(SqliteConnection connection, SqliteTransaction? transaction = null)
    {
        _connection = connection;
        _transaction = transaction;
    }

    private SqliteCommand Command(string sql, (string Name, object? Value)[] values)
    {
        var cmd = _connection.CreateCommand();
        cmd.Transaction = _transaction;
        cmd.CommandText = sql;
        foreach (var item in values)
        {
            object value = item.Value switch
            {
                null => DBNull.Value,
                bool b => b ? 1 : 0,
                DateTime d => d.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                _ => item.Value
            };
            cmd.Parameters.AddWithValue(item.Name, value);
        }

        return cmd;
    }

    public int Execute(string sql, params (string Name, object? Value)[] values)
    {
        using var cmd = Command(sql, values);
        return cmd.ExecuteNonQuery();
    }

    public object? Scalar(string sql, params (string Name, object? Value)[] values)
    {
        using var cmd = Command(sql, values);
        return cmd.ExecuteScalar();
    }

    public List<T> Query<T>(string sql, Func<SqliteDataReader, T> map, params (string Name, object? Value)[] values)
    {
        using var cmd = Command(sql, values);
        using var reader = cmd.ExecuteReader();
        var result = new List<T>();
        while (reader.Read())
            result.Add(map(reader));
        return result;
    }

    public int Insert(string sql, params (string Name, object? Value)[] values)
    {
        Execute(sql, values);
        return checked(Convert.ToInt32(Scalar("SELECT last_insert_rowid()")));
    }

    public static string Text(SqliteDataReader r, string name) => r[name] is DBNull ? "" : Convert.ToString(r[name], CultureInfo.InvariantCulture) ?? "";
    public static int Int(SqliteDataReader r, string name) => Convert.ToInt32(r[name], CultureInfo.InvariantCulture);
    public static int? NullableInt(SqliteDataReader r, string name) => r[name] is DBNull ? null : Int(r, name);
    public static long Long(SqliteDataReader r, string name) => Convert.ToInt64(r[name], CultureInfo.InvariantCulture);
    public static double Double(SqliteDataReader r, string name) => Convert.ToDouble(r[name], CultureInfo.InvariantCulture);
    public static bool Bool(SqliteDataReader r, string name) => Int(r, name) != 0;
    public static DateTime Date(SqliteDataReader r, string name) => DateTime.Parse(Text(r, name), CultureInfo.InvariantCulture);
    public static DateTime? NullableDate(SqliteDataReader r, string name) => r[name] is DBNull ? null : Date(r, name);
}
