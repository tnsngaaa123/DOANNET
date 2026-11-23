using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class XuatThuocService
{
    public static List<LuotKhamRow> Waiting() => Db.Run(s =>
    {
        AuthService.Require(s, Roles.DuocSi);
        return PhieuKhamRepository.List(s, state: TrangThai.ChoXuatThuoc).Where(x => HoaDonRepository.ByVisit(s, x.Id) is not null).ToList();
    });
    public static List<KetQuaXuatThuocRow> Dispense(int id) => Db.InTransaction(s =>
    {
        var actor = AuthService.Require(s, Roles.DuocSi);
        var p = KhamBenhService.RequireVisit(s, id);
        var d = DonThuocRepository.ByVisit(s, id);
        if (p.TrangThai != TrangThai.ChoXuatThuoc || d is null || d.TrangThai != TrangThai.DaKe || HoaDonRepository.ByVisit(s, id) is null)
            throw new NghiepVuException("Bệnh nhân chưa thanh toán hoặc thuốc đã được xuất.");
        var lines = DonThuocRepository.Lines(s, d.Id);
        if (lines.Count == 0)
            throw new NghiepVuException("Đơn không có thuốc.");
        var plan = new List<(int Lot, int Qty)>();
        foreach (var x in lines)
        {
            int left = x.SoLuong;
            foreach (var lot in LoThuocRepository.Sellable(s, x.ThuocId))
            {
                int take = Math.Min(left, lot.SoLuongTon);
                if (take > 0)
                    plan.Add((lot.Id, take));
                left -= take;
                if (left == 0)
                    break;
            }

            if (left > 0)
                throw new NghiepVuException("Không đủ thuốc còn hạn. Chưa có thuốc nào được trừ.");
        }

        foreach (var x in plan)
        {
            LoThuocRepository.Deduct(s, x.Lot, x.Qty);
            BienDongKhoRepository.Insert(s, new BienDongKho { LoThuocId = x.Lot, SoLuong = -x.Qty, Loai = TrangThai.Xuat, ThamChieu = "DT:" + d.Id, NguoiThucHienId = actor.Id });
        }

        d.TrangThai = TrangThai.DaXuat;
        d.NgayXuat = DateTime.Now;
        d.NguoiXuatId = actor.Id;
        DonThuocRepository.Update(s, d);
        p.TrangThai = TrangThai.HoanTat;
        PhieuKhamRepository.Update(s, p);
        return lines.Select(x =>
        {
            var t = ThuocRepository.Get(s, x.ThuocId)!;
            return new KetQuaXuatThuocRow
            {
                TenThuoc = t.TenThuoc,
                DonViTinh = t.DonViTinh,
                SoLuongDaXuat = x.SoLuong,
                SoLuongCon = LoThuocRepository.Remaining(s, x.ThuocId)
            };
        }).ToList();
    });
}
