using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class HangDoiService
{
    public static List<LuotKhamRow> List(DateTime day, int? doctor = null, string q = "") => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        return PhieuKhamRepository.List(s, day, doctor, TrangThai.ChoKham, q);
    });
    public static PhongChoData Room() => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        var current = PhieuKhamRepository.List(s, state: TrangThai.DangKham).OrderByDescending(x => x.Phieu.GioGoi).FirstOrDefault();
        var waiting = PhieuKhamRepository.List(s, DateTime.Today, state: TrangThai.ChoKham);
        return new PhongChoData
        {
            SoDangKham = (current ?? waiting.FirstOrDefault())?.SoThuTu.ToString() ?? "—",
            DangCho = waiting
        };
    });
    public static void Priority(int id, bool priority) => Db.InTransaction(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        var p = KhamBenhService.RequireVisit(s, id);
        if (p.TrangThai != TrangThai.ChoKham)
            throw new NghiepVuException("Chỉ đổi ưu tiên khi còn chờ khám.");
        p.UuTien = priority;
        PhieuKhamRepository.Update(s, p);
    });
    public static void ChangeDoctor(int id, int doctor) => Db.InTransaction(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        var p = KhamBenhService.RequireVisit(s, id);
        var bs = NguoiDungRepository.Get(s, doctor);
        if (p.TrangThai != TrangThai.ChoKham || bs is null || bs.VaiTro != Roles.BacSi || !bs.TrangThai)
            throw new NghiepVuException("Chỉ đổi bác sĩ hợp lệ cho lượt chờ khám.");
        if (p.BacSiId != doctor)
        {
            p.BacSiId = doctor;
            p.SoThuTu = PhieuKhamRepository.NextNumber(s, p.NgayKham, doctor);
            p.DaInSoKham = false;
            p.InSoKhamLuc = null;
            PhieuKhamRepository.Update(s, p);
        }
    });
}
