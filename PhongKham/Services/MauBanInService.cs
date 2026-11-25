using PhongKham.Core;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class MauBanInService
{
    private static List<string> Patient(PhieuKhamChiTiet visit) => new()
    {
        "Bệnh nhân: " + visit.BenhNhan.HoTen + "    |    Mã hồ sơ: " + visit.BenhNhan.MaBenhNhan,
        "CCCD: " + visit.BenhNhan.CanCuocCongDan,
        "Ngày sinh: " + Formatters.Ngay(visit.BenhNhan.NgaySinh) + "    |    Giới tính: " + TrangThai.TenHienThi(visit.BenhNhan.GioiTinh),
        "Bác sĩ: " + visit.TenBacSi,
        "Ngày khám: " + Formatters.Ngay(visit.Phieu.NgayKham) + "    |    Mã lượt khám: " + visit.Phieu.MaPhieuKham
    };

    private static List<string[]> Charges(PhieuKhamChiTiet visit, long fee)
    {
        var rows = new List<string[]> { new[] { "1", "Khám bệnh", "lượt", "1", Formatters.Tien(fee), Formatters.Tien(fee) } };
        int number = 2;
        foreach (var medicine in visit.CacThuoc)
            rows.Add(new[] { (number++).ToString(), medicine.TenThuoc, medicine.DonViTinh, medicine.SoLuong.ToString(), Formatters.Tien(medicine.DonGia), Formatters.Tien(medicine.ThanhTien) });
        return rows;
    }

    public static MauBanIn HoaDon(HoanTatKhamPrintData data)
    {
        long drugs = data.LuotKham.CacThuoc.Sum(x => x.ThanhTien);
        long total = checked(data.TienKham + drugs - data.GiamGia);
        return new MauBanIn
        {
            TieuDe = "HÓA ĐƠN KHÁM BỆNH",
            MaChungTu = ChungTuCodes.HoaDon(data.LuotKham.Phieu),
            TenFilePdf = "HOADON-" + ChungTuCodes.HoaDon(data.LuotKham.Phieu),
            SoThuTu = data.LuotKham.Phieu.SoThuTu,
            HuongDanCho = "Theo dõi tại màn hình chờ\nở quầy thanh toán.",
            TenPhongKham = data.TenPhongKham, DiaChi = data.DiaChi, SoDienThoai = data.SoDienThoai,
            ThongTin = Patient(data.LuotKham),
            Cot = new[] { "STT", "Nội dung / Tên thuốc", "ĐVT", "Số lượng", "Đơn giá", "Thành tiền" },
            TyLeCot = new float[] { 6, 36, 10, 10, 18, 20 },
            Dong = Charges(data.LuotKham, data.TienKham),
            TongKet = new() { "Tiền khám: " + Formatters.Tien(data.TienKham), "Tiền thuốc: " + Formatters.Tien(drugs), "Giảm giá: " + Formatters.Tien(data.GiamGia), "TỔNG CỘNG: " + Formatters.Tien(total) },
            GhiChu = "Vui lòng nộp hóa đơn tại quầy thanh toán để nhận biên lai.",
            ChuKyTrai = "Người bệnh", ChuKyPhai = "Người lập hóa đơn", TenNguoiLap = data.LuotKham.TenBacSi
        };
    }

    public static MauBanIn DonThuoc(HoanTatKhamPrintData data)
    {
        var visit = data.LuotKham;
        var info = Patient(visit);
        info.Add("Chẩn đoán: " + visit.Phieu.ChanDoan);
        info.Add("Dị ứng: " + (string.IsNullOrWhiteSpace(visit.BenhNhan.DiUng) ? "Chưa ghi nhận" : visit.BenhNhan.DiUng));
        return new MauBanIn
        {
            TieuDe = "ĐƠN THUỐC", MaChungTu = ChungTuCodes.DonThuoc(visit.Phieu),
            TenFilePdf = "DONTHUOC-" + ChungTuCodes.DonThuoc(visit.Phieu),
            SoThuTu = visit.Phieu.SoThuTu,
            HuongDanCho = "Theo dõi tại màn hình chờ\nở quầy lấy thuốc.",
            TenPhongKham = data.TenPhongKham, DiaChi = data.DiaChi, SoDienThoai = data.SoDienThoai,
            ThongTin = info,
            Cot = new[] { "STT", "Tên thuốc", "ĐVT", "Số lượng", "Liều dùng và thời gian sử dụng" },
            TyLeCot = new float[] { 6, 27, 9, 10, 48 },
            Dong = visit.CacThuoc.Select((x, i) => new[] { (i + 1).ToString(), x.TenThuoc, x.DonViTinh, x.SoLuong.ToString(), x.LieuDung + (x.LieuDung.Contains("ngày", StringComparison.OrdinalIgnoreCase) ? "" : "; dùng trong " + x.Dong.SoNgay + " ngày") }).ToList(),
            TongKet = new() { visit.CacThuoc.Count == 0 ? "Không kê thuốc cho lượt khám này." : "Số loại thuốc: " + visit.CacThuoc.Count },
            GhiChu = "Lời dặn: " + visit.Phieu.LoiDan + "\nSau khi thanh toán, mang đơn thuốc và biên lai đến quầy nhận thuốc.",
            ChuKyTrai = "Người bệnh", ChuKyPhai = "Bác sĩ kê đơn", TenNguoiLap = visit.TenBacSi
        };
    }

    public static MauBanIn BienLai(BienLaiData data)
    {
        var detail = data.ChiTiet;
        var bill = detail.HoaDon;
        var info = Patient(detail.LuotKham);
        info.Add("Mã hóa đơn: " + ChungTuCodes.HoaDon(detail.LuotKham.Phieu));
        info.Add("Thời điểm thanh toán: " + bill.NgayThanhToan.ToString("dd/MM/yyyy HH:mm:ss"));
        return new MauBanIn
        {
            TieuDe = "BIÊN LAI THANH TOÁN", MaChungTu = bill.MaHoaDon, NgayLap = bill.NgayThanhToan,
            TenFilePdf = "BIENLAI-" + bill.MaHoaDon,
            TenPhongKham = data.TenPhongKham, DiaChi = data.DiaChi, SoDienThoai = data.SoDienThoai,
            ThongTin = info,
            Cot = new[] { "STT", "Nội dung / Tên thuốc", "ĐVT", "Số lượng", "Đơn giá", "Thành tiền" },
            TyLeCot = new float[] { 6, 36, 10, 10, 18, 20 },
            Dong = Charges(detail.LuotKham, bill.TienKham),
            TongKet = new()
            {
                "Tiền khám: " + Formatters.Tien(bill.TienKham), "Tiền thuốc: " + Formatters.Tien(bill.TienThuoc),
                "Giảm giá: " + Formatters.Tien(bill.GiamGia), "TỔNG THANH TOÁN: " + Formatters.Tien(bill.TongThu),
                "Hình thức: " + TrangThai.TenHienThi(bill.HinhThuc), "Khách đưa: " + Formatters.Tien(bill.TienKhachDua), "Tiền thừa: " + Formatters.Tien(bill.TienThua)
            },
            GhiChu = "Vui lòng giữ biên lai để đối chiếu và nhận thuốc. Cảm ơn quý khách.",
            ChuKyTrai = "Người nộp tiền", ChuKyPhai = "Người thu tiền", TenNguoiLap = detail.TenNguoiThu
        };
    }

    public static MauBanIn DanhSach(DanhSachPrintData data) => new()
    {
        TieuDe = data.TieuDe.ToUpper(Formatters.Vietnamese), TenPhongKham = data.TenPhongKham,
        TenFilePdf = data.TieuDe.ToUpper(Formatters.Vietnamese),
        DiaChi = data.DiaChi, SoDienThoai = data.SoDienThoai, MoTa = data.MoTaBoLoc,
        Cot = data.Cot, Dong = data.Dong, TongKet = new() { "Tổng số dòng: " + data.Dong.Count },
        ChuKyTrai = "Người kiểm tra", ChuKyPhai = "Người lập danh sách", TenNguoiLap = data.NguoiLap
    };

    public static MauBanIn BaoCao(BaoCaoData data) => new()
    {
        TieuDe = "BÁO CÁO LƯỢT KHÁM VÀ DOANH THU", MaChungTu = "BC-" + data.TuNgay.ToString("yyyyMMdd") + "-" + data.DenNgay.ToString("yyyyMMdd"),
        KyBaoCao = data.Ky,
        TuNgayBaoCao = data.TuNgay,
        TenPhongKham = data.TenPhongKham, DiaChi = data.DiaChi, SoDienThoai = data.SoDienThoai,
        MoTa = data.TieuDe + " | Từ " + Formatters.Ngay(data.TuNgay) + " đến " + Formatters.Ngay(data.DenNgay),
        Cot = new[] { "Ngày", "Lượt khám", "Tiền khám", "Tiền thuốc", "Giảm giá", "Doanh thu (VNĐ)" },
        TyLeCot = new float[] { 15, 10, 18, 18, 17, 22 },
        Dong = data.CacNgay.Select(x => new[] { Formatters.Ngay(x.Ngay), x.SoLuot.ToString(), Formatters.Tien(x.TienKham), Formatters.Tien(x.TienThuoc), Formatters.Tien(x.GiamGia), Formatters.Tien(x.DoanhThu) }).ToList(),
        TongKet = new() { "TỔNG LƯỢT KHÁM: " + data.TongLuot, "Tiền khám: " + Formatters.Tien(data.TongTienKham), "Tiền thuốc: " + Formatters.Tien(data.TongTienThuoc), "Giảm giá: " + Formatters.Tien(data.TongGiamGia), "TỔNG DOANH THU: " + Formatters.Tien(data.TongDoanhThu) },
        ChuKyTrai = "Người kiểm tra", ChuKyPhai = "Người lập báo cáo", TenNguoiLap = data.NguoiLap
    };

}
