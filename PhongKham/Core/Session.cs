using PhongKham.Models;

namespace PhongKham.Core;

public static class Session
{
    private static NguoiDung? _user;
    public static NguoiDung? CurrentUser => _user is null ? null : Copy(_user);
    public static bool IsAuthenticated => _user is not null;
    public static bool IsAdmin => _user?.VaiTro == Roles.Admin;

    public static void Start(NguoiDung user)
    {
        if (!user.TrangThai || !Roles.All.Contains(user.VaiTro))
            throw new NghiepVuException("Tài khoản không hợp lệ hoặc đã khóa.");
        _user = Copy(user);
    }

    public static void Clear() => _user = null;
    public static bool HasRole(params string[] roles) => _user is not null && (IsAdmin || roles.Length == 0 || roles.Contains(_user.VaiTro));
    private static NguoiDung Copy(NguoiDung x) => new()
    {
        Id = x.Id,
        TenDangNhap = x.TenDangNhap,
        HoTen = x.HoTen,
        VaiTro = x.VaiTro,
        TrangThai = x.TrangThai
    };
}