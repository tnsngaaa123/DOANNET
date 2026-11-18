using System.Text.RegularExpressions;
using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;

namespace PhongKham.Services;

public static class NguoiDungService
{
    public static List<NguoiDung> Doctors() => Db.Run(s =>
    {
        AuthService.Require(s);
        return NguoiDungRepository.Doctors(s).Select(x => new NguoiDung { Id = x.Id, HoTen = x.HoTen, VaiTro = x.VaiTro, TrangThai = x.TrangThai }).ToList();
    });
    public static List<NguoiDung> All() => Db.Run(s =>
    {
        AuthService.Require(s, Roles.Admin);
        var rows = NguoiDungRepository.All(s);
        foreach (var x in rows)
            x.MatKhauHash = "";
        return rows;
    });
    public static int Save(NguoiDung x, string password = "") => Db.InTransaction(s =>
    {
        var actor = AuthService.Require(s, Roles.Admin);
        x.TenDangNhap = x.TenDangNhap.Trim();
        x.HoTen = x.HoTen.Trim();
        if (!Regex.IsMatch(x.TenDangNhap, @"^[a-zA-Z0-9_.-]{2,40}$") || x.HoTen.Length < 2 || x.HoTen.Length > 150 || !Roles.All.Contains(x.VaiTro))
            throw new NghiepVuException("Kiểm tra tên đăng nhập, họ tên và vai trò.");
        var old = x.Id == 0 ? null : NguoiDungRepository.Get(s, x.Id) ?? throw new NghiepVuException("Tài khoản không tồn tại.");
        if (old is not null)
        {
            if (x.Id == actor.Id && (!x.TrangThai || x.VaiTro != Roles.Admin))
                throw new NghiepVuException("Không tự khóa hoặc bỏ vai trò Admin của mình.");
            if (old.VaiTro == Roles.Admin && old.TrangThai && (!x.TrangThai || x.VaiTro != Roles.Admin) && !NguoiDungRepository.All(s).Any(u => u.Id != x.Id && u.VaiTro == Roles.Admin && u.TrangThai))
                throw new NghiepVuException("Phải giữ ít nhất một Admin hoạt động.");
            x.MatKhauHash = old.MatKhauHash;
        }

        if (old is null || password != "")
        {
            AuthService.ValidatePassword(password);
            x.MatKhauHash = PasswordHasher.Hash(password);
        }

        if (old is null)
            return NguoiDungRepository.Insert(s, x);
        NguoiDungRepository.Update(s, x);
        return x.Id;
    });
    public static void ResetPassword(int id, string password)
    {
        AuthService.ValidatePassword(password);
        Db.InTransaction(s =>
        {
            AuthService.Require(s, Roles.Admin);
            var x = NguoiDungRepository.Get(s, id) ?? throw new NghiepVuException("Tài khoản không tồn tại.");
            x.MatKhauHash = PasswordHasher.Hash(password);
            NguoiDungRepository.Update(s, x);
        });
    }
}
