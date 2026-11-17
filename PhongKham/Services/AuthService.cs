using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;

namespace PhongKham.Services;

public static class AuthService
{
    public static NguoiDung Login(string login, string password)
    {
        Session.Clear();
        var x = Db.Run(s => NguoiDungRepository.ByLogin(s, login.Trim()));
        if (x is null || !x.TrangThai || !PasswordHasher.Verify(password, x.MatKhauHash))
            throw new NghiepVuException("Tên đăng nhập, mật khẩu sai hoặc tài khoản đã khóa.");
        Session.Start(x);
        return Session.CurrentUser!;
    }

    internal static NguoiDung Require(DbSession s, params string[] roles)
    {
        var x = NguoiDungRepository.Get(s, Session.CurrentUser?.Id ?? 0);
        if (x is null || !x.TrangThai)
            throw new NghiepVuException("Phiên đăng nhập không hợp lệ. Hãy đăng nhập lại.");
        if (x.VaiTro != Roles.Admin && roles.Length > 0 && !roles.Contains(x.VaiTro))
            throw new NghiepVuException("Bạn không có quyền thực hiện chức năng này.");
        return x;
    }

    public static void ValidatePassword(string text)
    {
        if (text.Length < 8 || text.Length > 128 || !text.Any(char.IsLetter) || !text.Any(char.IsDigit))
            throw new NghiepVuException("Mật khẩu cần 8–128 ký tự, có chữ và số.");
    }

    public static void ChangePassword(string current, string next, string confirm)
    {
        ValidatePassword(next);
        if (next != confirm)
            throw new NghiepVuException("Mật khẩu xác nhận không khớp.");
        Db.InTransaction(s =>
        {
            var x = Require(s);
            if (!PasswordHasher.Verify(current, x.MatKhauHash))
                throw new NghiepVuException("Mật khẩu hiện tại không đúng.");
            x.MatKhauHash = PasswordHasher.Hash(next);
            NguoiDungRepository.Update(s, x);
        });
    }
}
