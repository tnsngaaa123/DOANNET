using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class ThanhToanService
{
    public static List<LuotKhamRow> Waiting() => Db.Run(s =>
    {
        AuthService.Require(s, Roles.ThuNgan);
        return PhieuKhamRepository.List(s, state: TrangThai.ChoThanhToan).OrderBy(x => x.Phieu.NgayTao).ToList();
    });
    public static PhieuKhamChiTiet VisitDetail(int id) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.ThuNgan);
        return KhamBenhService.Detail(s, id);
    });
    public static List<ThanhToanRow> Paid(DateTime? day = null, string method = "", string q = "") => Db.Run(s =>
    {
        AuthService.Require(s, Roles.ThuNgan);
        if (method != "" && method is not (TrangThai.TienMat or TrangThai.ChuyenKhoan))
            throw new NghiepVuException("Hình thức không hợp lệ.");
        return HoaDonRepository.Paid(s, day, method, q);
    });
    public static List<ThanhToanRow> History(int patient) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.ThuNgan);
        if (BenhNhanRepository.Get(s, patient) is null)
            throw new NghiepVuException("Không tìm thấy bệnh nhân.");
        return HoaDonRepository.Paid(s, null, "", "", patient);
    });

    internal static HoaDonChiTiet Detail(DbSession s, int bill)
    {
        var h = HoaDonRepository.Get(s, bill) ?? throw new NghiepVuException("Không tìm thấy biên lai.");
        return new HoaDonChiTiet
        {
            HoaDon = h,
            LuotKham = KhamBenhService.Detail(s, h.PhieuKhamId),
            TenNguoiThu = NguoiDungRepository.Get(s, h.NguoiThuId)?.HoTen ?? ""
        };
    }

    public static HoaDonChiTiet Detail(int bill) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.ThuNgan);
        return Detail(s, bill);
    });
    public static TinhTienKetQua Calculate(long fee, long drugs, decimal discount, bool percent, string method, long given)
    {
        if (fee < 0 || fee > 1000000000 || drugs < 0 || discount < 0 || (percent && discount > 100) || method is not (TrangThai.TienMat or TrangThai.ChuyenKhoan))
            throw new NghiepVuException("Kiểm tra tiền khám, giảm giá và hình thức thanh toán.");
        long gross = checked(fee + drugs);
        decimal reduction = Math.Round(percent ? gross * discount / 100 : discount, 0, MidpointRounding.AwayFromZero);
        if (reduction > gross)
            throw new NghiepVuException("Giảm giá vượt tổng tiền.");
        long off = (long)reduction;
        long total = gross - off;
        long received = method == TrangThai.ChuyenKhoan ? total : given;
        if (received < total)
            throw new NghiepVuException("Tiền khách đưa chưa đủ.");
        return new TinhTienKetQua
        {
            TienKham = fee,
            TienThuoc = drugs,
            GiamGia = off,
            TongThu = total,
            TienKhachDua = received,
            TienThua = received - total
        };
    }

    public static int Pay(int id, long fee, decimal discount, bool percent, string method, long given) => Db.InTransaction(s =>
    {
        var actor = AuthService.Require(s, Roles.ThuNgan);
        var p = KhamBenhService.RequireVisit(s, id);
        if (p.TrangThai != TrangThai.ChoThanhToan || HoaDonRepository.ByVisit(s, id) is not null)
            throw new NghiepVuException("Bệnh nhân không còn chờ thanh toán hoặc đã thanh toán.");
        var d = DonThuocRepository.ByVisit(s, id);
        var lines = d is null ? new List<ChiTietDonThuoc>() : DonThuocRepository.Lines(s, d.Id);
        foreach (var x in lines)
            if (x.SoLuong > ThuocService.Available(s, x.ThuocId, id))
                throw new NghiepVuException("Số lượng thuốc đã thay đổi, cần kiểm tra trước khi thu tiền.");
        var t = Calculate(fee, lines.Sum(x => checked((long)x.SoLuong * x.DonGia)), discount, percent, method, given);
        var h = new HoaDon
        {
            PhieuKhamId = id,
            NguoiThuId = actor.Id,
            TienKham = t.TienKham,
            TienThuoc = t.TienThuoc,
            GiamGia = t.GiamGia,
            TongThu = t.TongThu,
            TienKhachDua = t.TienKhachDua,
            TienThua = t.TienThua,
            HinhThuc = method
        };
        h.Id = HoaDonRepository.Insert(s, h);
        h.MaHoaDon = ChungTuCodes.BienLai(h.NgayThanhToan, h.Id);
        HoaDonRepository.Update(s, h);
        p.TrangThai = lines.Count == 0 ? TrangThai.HoanTat : TrangThai.ChoXuatThuoc;
        PhieuKhamRepository.Update(s, p);
        return h.Id;
    });
}
