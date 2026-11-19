using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class BaoCaoService
{
    public static (DateTime From, DateTime Until) ThoiGian(KyBaoCao kind, DateTime day, int year, int month, int quarter)
    {
        if (kind == KyBaoCao.Ngay)
        {
            if (day.Year < 1900 || day.Year > 9998)
                throw new NghiepVuException("Chọn ngày từ năm 1900 đến 9998.");
            return (day.Date, day.Date.AddDays(1));
        }
        if (year < 1900 || year > 9998)
            throw new NghiepVuException("Chọn năm từ 1900 đến 9998.");
        if (kind == KyBaoCao.Thang)
        {
            if (month < 1 || month > 12) throw new NghiepVuException("Tháng phải từ 1 đến 12.");
            var first = new DateTime(year, month, 1);
            return (first, first.AddMonths(1));
        }
        if (kind == KyBaoCao.Quy)
        {
            if (quarter < 1 || quarter > 4) throw new NghiepVuException("Quý phải từ 1 đến 4.");
            var first = new DateTime(year, (quarter - 1) * 3 + 1, 1);
            return (first, first.AddMonths(3));
        }
        if (kind == KyBaoCao.Nam)
            return (new DateTime(year, 1, 1), new DateTime(year + 1, 1, 1));
        throw new NghiepVuException("Kỳ báo cáo không hợp lệ.");
    }

    internal static List<NgayThongKeRow> ReadRows(DbSession s, DateTime from, DateTime until)
    {
        var visits = s.Query("SELECT NgayKham AS Ngay, COUNT(*) AS SoLuot FROM PhieuKham WHERE NgayKham>=@from AND NgayKham<@until GROUP BY NgayKham",
            r => new NgayThongKeRow { Ngay = DbSession.Date(r, "Ngay"), SoLuot = DbSession.Int(r, "SoLuot") },
            ("@from", Db.Day(from)), ("@until", Db.Day(until))).ToDictionary(x => x.Ngay.Date);
        var receipts = s.Query("SELECT date(NgayThanhToan) AS Ngay, SUM(TienKham) AS TienKham, SUM(TienThuoc) AS TienThuoc, SUM(GiamGia) AS GiamGia, SUM(TongThu) AS DoanhThu FROM HoaDon WHERE NgayThanhToan>=@from AND NgayThanhToan<@until GROUP BY date(NgayThanhToan)",
            r => new NgayThongKeRow { Ngay = DbSession.Date(r, "Ngay"), TienKham = DbSession.Long(r, "TienKham"), TienThuoc = DbSession.Long(r, "TienThuoc"), GiamGia = DbSession.Long(r, "GiamGia"), DoanhThu = DbSession.Long(r, "DoanhThu") },
            ("@from", Db.Day(from)), ("@until", Db.Day(until))).ToDictionary(x => x.Ngay.Date);
        var rows = new List<NgayThongKeRow>();
        for (DateTime day = from.Date; day < until; day = day.AddDays(1))
        {
            var row = receipts.GetValueOrDefault(day) ?? new NgayThongKeRow { Ngay = day };
            row.SoLuot = visits.GetValueOrDefault(day)?.SoLuot ?? 0;
            rows.Add(row);
        }
        return rows;
    }

    public static BaoCaoData Get(KyBaoCao kind, DateTime day, int year, int month, int quarter) => Db.Run(s =>
    {
        var actor = AuthService.Require(s, Roles.LeTan, Roles.ThuNgan);
        var range = ThoiGian(kind, day, year, month, quarter);
        string title = kind switch
        {
            KyBaoCao.Ngay => "Báo cáo ngày " + range.From.ToString("dd/MM/yyyy"),
            KyBaoCao.Thang => "Báo cáo tháng " + month + "/" + year,
            KyBaoCao.Quy => "Báo cáo quý " + quarter + "/" + year,
            _ => "Báo cáo năm " + year
        };
        return new BaoCaoData
        {
            Ky = kind,
            TieuDe = title,
            TuNgay = range.From,
            DenNgay = range.Until.AddDays(-1),
            CacNgay = ReadRows(s, range.From, range.Until),
            TenPhongKham = CauHinhRepository.Get(s, "TenPhongKham"),
            DiaChi = CauHinhRepository.Get(s, "DiaChi"),
            SoDienThoai = CauHinhRepository.Get(s, "SoDienThoai"),
            NguoiLap = actor.HoTen
        };
    });
}
