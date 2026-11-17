using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class InAnService
{
    public static HoanTatKhamPrintData CompletedVisit(int id) => Db.Run(s =>
    {
        var actor = AuthService.Require(s, Roles.BacSi, Roles.ThuNgan);
        var visit = KhamBenhService.Detail(s, id);
        if (actor.VaiTro == Roles.BacSi && visit.Phieu.BacSiId != actor.Id)
            throw new NghiepVuException("Lượt khám không thuộc bác sĩ đăng nhập.");
        if (visit.Phieu.TrangThai is TrangThai.ChoKham or TrangThai.DangKham)
            throw new NghiepVuException("Hoàn tất khám trước khi xuất hóa đơn và đơn thuốc.");
        var receipt = HoaDonRepository.ByVisit(s, id);
        return new HoanTatKhamPrintData
        {
            LuotKham = visit,
            TenPhongKham = CauHinhRepository.Get(s, "TenPhongKham"),
            DiaChi = CauHinhRepository.Get(s, "DiaChi"),
            SoDienThoai = CauHinhRepository.Get(s, "SoDienThoai"),
            TienKham = receipt?.TienKham ?? long.Parse(CauHinhRepository.Get(s, "TienKhamMacDinh", "150000"), System.Globalization.CultureInfo.InvariantCulture),
            DaThanhToan = receipt is not null,
            GiamGia = receipt?.GiamGia ?? 0
        };
    });
    internal static PhieuSoData Ticket(DbSession s, int id) => new()
    {
        LuotKham = KhamBenhService.Detail(s, id),
        TenPhongKham = CauHinhRepository.Get(s, "TenPhongKham"),
        DiaChi = CauHinhRepository.Get(s, "DiaChi"),
        SoDienThoai = CauHinhRepository.Get(s, "SoDienThoai")
    };
    public static PhieuSoData Ticket(int id) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        return Ticket(s, id);
    });
    public static void MarkTicketsPrinted(IEnumerable<int> ids) => Db.InTransaction(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        foreach (int id in ids.Distinct())
        {
            var p = KhamBenhService.RequireVisit(s, id);
            if (!p.DaInSoKham)
            {
                p.DaInSoKham = true;
                p.InSoKhamLuc = DateTime.Now;
                PhieuKhamRepository.Update(s, p);
            }
        }
    });
    public static BienLaiData Receipt(int bill) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.ThuNgan);
        return new BienLaiData
        {
            ChiTiet = ThanhToanService.Detail(s, bill),
            TenPhongKham = CauHinhRepository.Get(s, "TenPhongKham"),
            DiaChi = CauHinhRepository.Get(s, "DiaChi"),
            SoDienThoai = CauHinhRepository.Get(s, "SoDienThoai")
        };
    });
}
