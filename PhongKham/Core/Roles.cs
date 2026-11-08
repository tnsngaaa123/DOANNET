namespace PhongKham.Core;

public static class Roles
{
    public const string Admin = "Admin", LeTan = "LeTan", BacSi = "BacSi", ThuNgan = "ThuNgan", DuocSi = "DuocSi";
    public static readonly string[] All =
    {
        Admin,
        LeTan,
        BacSi,
        ThuNgan,
        DuocSi
    };
    public static string TenHienThi(string role) => role switch
    {
        Admin => "Quản trị",
        LeTan => "Lễ tân",
        BacSi => "Bác sĩ",
        ThuNgan => "Thu ngân",
        DuocSi => "Dược sĩ",
        _ => role
    };
}