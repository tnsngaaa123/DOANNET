namespace PhongKham.Data.Repositories;

public static class CauHinhRepository
{
    public static string Get(DbSession s, string key, string fallback = "")
    {
        object? value = s.Scalar("SELECT GiaTri FROM CauHinh WHERE Khoa=@key", ("@key", key));
        return value is null or DBNull ? fallback : Convert.ToString(value) ?? fallback;
    }

    public static void Set(DbSession s, string key, string value) => s.Execute("INSERT INTO CauHinh(Khoa,GiaTri) VALUES(@key,@value) ON CONFLICT(Khoa) DO UPDATE SET GiaTri=excluded.GiaTri", ("@key", key), ("@value", value));
    public static Dictionary<string, string> All(DbSession s) => s.Query("SELECT Khoa,GiaTri FROM CauHinh", r => new KeyValuePair<string, string>(DbSession.Text(r, "Khoa"), DbSession.Text(r, "GiaTri"))).ToDictionary(x => x.Key, x => x.Value);
}
