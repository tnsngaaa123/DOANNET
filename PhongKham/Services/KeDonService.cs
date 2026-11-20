using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class KeDonService 
{


    public static int GoiYSoLuong(double sang, double trua, double chieu, double toi, int days)
    {
        var doses = new[]
        {
            sang,
            trua,
            chieu,
            toi
        };
        double total = doses.Sum() * days;
        if (doses.Any(x => !double.IsFinite(x) || x < 0 || x > 10000) || days < 1 || days > 365 || total > 1000000)
            throw new NghiepVuException("Kiểm tra liều và số ngày.");
        return checked((int)Math.Ceiling(total));
    }

    public static string GoiYLieuDung(ChiTietDonThuoc line, string unit)
    {
        var values = new[]
        {
            ("Sáng", line.Sang),
            ("Trưa", line.Trua),
            ("Chiều", line.Chieu),
            ("Tối", line.Toi)
        };
        string text = string.Join(", ", values.Where(x => x.Item2 > 0).Select(x => x.Item1 + " " + x.Item2.ToString("0.##", Formatters.Vietnamese) + " " + unit));
        return text + (line.ThoiDiemUong == TrangThai.KhongQuyDinh ? "" : " " + TrangThai.TenHienThi(line.ThoiDiemUong).ToLower(Formatters.Vietnamese))
                    + "; dùng trong " + line.SoNgay + " ngày";
    }

    public static void KiemTraSoLuongTheoLieu(ChiTietDonThuoc line)
    {
        int required = GoiYSoLuong(line.Sang, line.Trua, line.Chieu, line.Toi, line.SoNgay);
        if (required == 0)
            throw new NghiepVuException("Cần nhập ít nhất một liều trong ngày.");
        if (line.SoLuong != required)
            throw new NghiepVuException("Số lượng phải bằng " + required + " theo liều đã nhập trong " + line.SoNgay
                                        + " ngày. Hãy sửa số lượng hoặc bấm Gợi ý số lượng / liều.");
    }

    public static List<DongDonThuocRow> Load(int id) => KhamBenhService.Get(id).CacThuoc;

    public static void Save(int id, IReadOnlyList<ChiTietDonThuoc> lines) => Db.InTransaction(s =>
    {
        KhamBenhService.CanEdit(s, id);
        if (lines.GroupBy(x => x.ThuocId).Any(x => x.Count() > 1))
            throw new NghiepVuException("Mỗi thuốc chỉ một dòng trong đơn.");
        var old = DonThuocRepository.ByVisit(s, id);
        if (old is not null && old.TrangThai != TrangThai.DaKe)
            throw new NghiepVuException("Đơn đã xuất không được sửa.");
        foreach (var x in lines)
        {
            var t = ThuocRepository.Get(s, x.ThuocId);
            if (t is null)
                throw new NghiepVuException("Thuốc không tồn tại.");
            if (x.SoLuong <= 0 || x.SoLuong > 1000000 || x.SoNgay < 1 || x.SoNgay > 365 || new[]
                {
                    x.Sang,
                    x.Trua,
                    x.Chieu,
                    x.Toi
                }.Any(v => !double.IsFinite(v) || v < 0 || v > 10000) || !new[]
                {
                    TrangThai.TruocAn,
                    TrangThai.SauAn,
                    TrangThai.TrongBuaAn,
                    TrangThai.KhongQuyDinh
                }.Contains(x.ThoiDiemUong))
                throw new NghiepVuException("Số lượng, liều, số ngày hoặc thời điểm không hợp lệ.");
            KiemTraSoLuongTheoLieu(x);
            if (x.SoLuong > ThuocService.Available(s, x.ThuocId, id))
                throw new NghiepVuException(t.TenThuoc + " không đủ tồn khả dụng.");
            x.DonGia = t.GiaBan;
            if (string.IsNullOrWhiteSpace(x.LieuDung))
                x.LieuDung = GoiYLieuDung(x, t.DonViTinh);
            if (string.IsNullOrWhiteSpace(x.LieuDung))
                throw new NghiepVuException("Cần nhập liều dùng.");
        }

        if (lines.Count == 0)
        {
            if (old is not null)
                DonThuocRepository.Delete(s, old.Id);
            return;
        }

        var d = old ?? new DonThuoc
        {
            PhieuKhamId = id
        };
        if (d.Id == 0)
            d.Id = DonThuocRepository.Insert(s, d);
        DonThuocRepository.DeleteLines(s, d.Id);
        foreach (var x in lines)
        {
            x.DonThuocId = d.Id;
            DonThuocRepository.InsertLine(s, x);
        }
    });
}
