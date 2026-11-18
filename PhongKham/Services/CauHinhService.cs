using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;

namespace PhongKham.Services;

public static class CauHinhService
{
    public static Dictionary<string, string> GetAll() => Db.Run(s =>
    {
        AuthService.Require(s, Roles.Admin);
        return CauHinhRepository.All(s);
    });
    public static string Get(string key) => Db.Run(s =>
    {
        AuthService.Require(s);
        return CauHinhRepository.Get(s, key);
    });
    public static long TienKham => Db.Run(s =>
    {
        AuthService.Require(s);
        return long.Parse(CauHinhRepository.Get(s, "TienKhamMacDinh", "150000"), System.Globalization.CultureInfo.InvariantCulture);
    });
    public static void Save(string name, string address, string phone, long fee) => Db.InTransaction(s =>
    {
        AuthService.Require(s, Roles.Admin);
        if (name.Trim().Length < 2 || name.Length > 150 || fee < 0 || fee > 1000000000)
            throw new NghiepVuException("Kiểm tra tên phòng khám và phí khám.");
        foreach (var x in new[]
        {
            ("TenPhongKham", name.Trim()),
            ("DiaChi", address.Trim()),
            ("SoDienThoai", phone.Trim()),
            ("TienKhamMacDinh", fee.ToString(System.Globalization.CultureInfo.InvariantCulture))
        }

        )
            CauHinhRepository.Set(s, x.Item1, x.Item2);
    });
}
