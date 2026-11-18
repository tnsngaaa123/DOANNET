using PhongKham.Core;
using PhongKham.Data.Repositories;
using PhongKham.Models;

namespace PhongKham.Data;

internal static class DemoSeeder
{
    public static void Seed(DbSession s, DateTime today)
    {
        var medicines = CreateMedicines(s, today);
        string[] names = {
            "Nguyễn Minh An", "Trần Thị Mai", "Lê Hoàng Nam", "Phạm Ngọc Hân",
            "Võ Thanh Bình", "Đặng Thu Hà", "Bùi Quốc Huy", "Đỗ Minh Châu",
            "Hồ Gia Bảo", "Ngô Thanh Trúc", "Dương Tuấn Kiệt", "Vũ Thị Lan",
            "Lý Khánh Linh", "Trịnh Đức Long"
        };
        var patients = new List<BenhNhan>();
        for (int i = 0; i < names.Length; i++)
        {
            var patient = new BenhNhan
            {
                CanCuocCongDan = "099" + (i + 1).ToString("D9"),
                HoTen = names[i],
                NgaySinh = new DateTime(1975 + i * 2, (i % 12) + 1, 10),
                GioiTinh = i % 2 == 0 ? TrangThai.Nam : TrangThai.Nu,
                SoDienThoai = "0000000000",
                DiaChi = "Địa chỉ minh họa, TP. Hồ Chí Minh",
                TienSuBenh = "Thông tin minh họa",
                DiUng = "Chưa ghi nhận (mẫu)",
                NgayTao = today.AddDays(-30).AddMinutes(i)
            };
            patient.Id = BenhNhanRepository.Insert(s, patient);
            patient.MaBenhNhan = "BN" + patient.Id.ToString("D6");
            BenhNhanRepository.Update(s, patient);
            patients.Add(patient);
        }
        int patientIndex = 0;
        int[] counts = { 4, 3, 5 };
        for (int dayIndex = 0; dayIndex < counts.Length; dayIndex++)
            for (int j = 0; j < counts[dayIndex]; j++)
            {
                DateTime day = today.AddDays(dayIndex - 3);
                int doctor = patientIndex % 2 == 0 ? 3 : 4;
                var visit = CreateVisit(s, patients[patientIndex], doctor, day, j, true);
                CompleteHistory(s, visit, medicines[patientIndex % 14], medicines[(patientIndex + 3) % 14]);
                patientIndex++;
            }
        CreateVisit(s, patients[0], 3, today, 0, false);
        CreateVisit(s, patients[12], 3, today, 1, false);
        CreateVisit(s, patients[13], 3, today, 2, false);
        CauHinhRepository.Set(s, "DuLieuMauNgayTao", Db.Day(today));
    }

    private static List<Thuoc> CreateMedicines(DbSession s, DateTime today)
    {
        var catalog = new[] {
            ("Paracetamol",1,"viên",2000L), ("Ibuprofen",1,"viên",2500L),
            ("Vitamin C",3,"viên",1000L), ("Vitamin B complex",3,"viên",1500L),
            ("Kẽm gluconat",3,"viên",2000L), ("Loratadin",5,"viên",2500L),
            ("Cetirizin",5,"viên",2000L), ("Omeprazol",4,"viên",3000L),
            ("Simethicon",4,"viên",2000L), ("Diosmectit",4,"gói",4500L),
            ("Oresol",4,"gói",3000L), ("Natri clorid",5,"chai",5000L),
            ("Acetylcystein",5,"gói",3500L), ("Bromhexin",5,"viên",1500L),
            ("Ambroxol",5,"viên",2500L), ("Dextromethorphan",5,"viên",2000L),
            ("Berberin",4,"viên",1000L), ("Loperamid",4,"viên",1500L),
            ("Diclofenac",1,"viên",2000L), ("Clotrimazol",6,"tuýp",15000L)
        };
        var random = new Random(20261108);
        var shuffled = catalog.OrderBy(_ => random.Next()).ToList();
        var result = new List<Thuoc>();
        for (int i = 0; i < shuffled.Count; i++)
        {
            var item = shuffled[i];
            var medicine = new Thuoc { MaThuoc = "MT" + (i + 1).ToString("D3"), TenThuoc = item.Item1, NhomThuocId = item.Item2, DonViTinh = item.Item3, GiaBan = item.Item4 };
            medicine.Id = ThuocRepository.Insert(s, medicine);
            DateTime expiry = i == 19 ? today.AddDays(-10)
                : i >= 17 ? today.AddMonths(i - 16)
                : i >= 14 ? today.AddMonths(i - 10)
                : today.AddMonths(12 + i % 5);
            int quantity = (i + 1) * 400;
            var lot = new LoThuoc { ThuocId = medicine.Id, SoLo = "MAU" + (i + 1).ToString("D3"), HanSuDung = expiry, SoLuongNhap = quantity, SoLuongTon = quantity, NgayNhap = today.AddDays(-30), NguoiNhapId = 6 };
            lot.Id = LoThuocRepository.Insert(s, lot);
            BienDongKhoRepository.Insert(s, new BienDongKho { LoThuocId = lot.Id, SoLuong = quantity, Loai = TrangThai.Nhap, ThamChieu = "MAU:THUOC:" + medicine.Id, NguoiThucHienId = 6, ThoiGian = lot.NgayNhap });
            result.Add(medicine);
        }
        return result;
    }

    private static PhieuKham CreateVisit(DbSession s, BenhNhan patient, int doctor, DateTime day, int position, bool completed)
    {
        DateTime time = day.Date.AddHours(8).AddMinutes(position * 20);
        string[] symptoms = { "Đau đầu và mệt mỏi", "Ho khan, đau rát họng", "Đầy bụng, khó tiêu", "Hắt hơi, sổ mũi" };
        string[] diagnoses = { "Đau đầu", "Viêm họng", "Rối loạn tiêu hóa", "Viêm mũi dị ứng" };
        int example = (patient.Id - 1) % symptoms.Length;
        var visit = new PhieuKham
        {
            BenhNhanId = patient.Id,
            BacSiId = doctor,
            NguoiTiepNhanId = 2,
            NgayKham = day.Date,
            SoThuTu = PhieuKhamRepository.NextNumber(s, day, doctor),
            NgayTao = time,
            LoaiKham = !completed && patient.Id == 1 ? TrangThai.TaiKham : TrangThai.KhamMoi,
            UuTien = !completed && position == 0,
            TrangThai = completed ? TrangThai.HoanTat : TrangThai.ChoKham,
            DaInSoKham = completed,
            InSoKhamLuc = completed ? time.AddMinutes(1) : null,
            GioGoi = completed ? time.AddMinutes(2) : null,
            GioHoanTat = completed ? time.AddMinutes(15) : null,
            TrieuChung = completed ? symptoms[example] : "",
            ChanDoan = completed ? diagnoses[example] : "",
            KetQua = completed ? "Tỉnh táo, sinh hiệu ổn định, điều trị ngoại trú." : "",
            LoiDan = completed ? "Uống thuốc theo đơn, nghỉ ngơi và tái khám khi triệu chứng chưa giảm." : ""
        };
        visit.Id = PhieuKhamRepository.Insert(s, visit);
        visit.MaPhieuKham = "PK" + day.ToString("yyMMdd") + visit.Id.ToString("D4");
        PhieuKhamRepository.Update(s, visit);
        return visit;
    }

    private static void CompleteHistory(DbSession s, PhieuKham visit, Thuoc first, Thuoc second)
    {
        var prescription = new DonThuoc { PhieuKhamId = visit.Id, NgayKe = visit.NgayTao.AddMinutes(10), TrangThai = TrangThai.DaXuat, NgayXuat = visit.NgayTao.AddMinutes(25), NguoiXuatId = 6 };
        prescription.Id = DonThuocRepository.Insert(s, prescription);
        long medicineTotal = 0;
        foreach (var medicine in new[] { first, second })
        {
            const int quantity = 2;
            DonThuocRepository.InsertLine(s, new ChiTietDonThuoc { DonThuocId = prescription.Id, ThuocId = medicine.Id, SoLuong = quantity, DonGia = medicine.GiaBan, LieuDung = "Sáng 1 " + medicine.DonViTinh + ", tối 1 " + medicine.DonViTinh + " sau ăn; dùng trong 1 ngày", Sang = 1, Toi = 1, SoNgay = 1, ThoiDiemUong = TrangThai.SauAn });
            var lot = LoThuocRepository.All(s).Single(l => l.ThuocId == medicine.Id);
            lot.SoLuongTon -= quantity;
            LoThuocRepository.Update(s, lot);
            BienDongKhoRepository.Insert(s, new BienDongKho { LoThuocId = lot.Id, SoLuong = -quantity, Loai = TrangThai.Xuat, ThamChieu = "DT:" + prescription.Id, NguoiThucHienId = 6, ThoiGian = prescription.NgayXuat!.Value });
            medicineTotal += quantity * medicine.GiaBan;
        }
        var bill = new HoaDon { PhieuKhamId = visit.Id, NguoiThuId = 5, NgayThanhToan = visit.NgayTao.AddMinutes(20), TienKham = 150000, TienThuoc = medicineTotal, TongThu = 150000 + medicineTotal, TienKhachDua = 150000 + medicineTotal, HinhThuc = visit.Id % 2 == 0 ? TrangThai.TienMat : TrangThai.ChuyenKhoan };
        bill.Id = HoaDonRepository.Insert(s, bill);
        bill.MaHoaDon = ChungTuCodes.BienLai(bill.NgayThanhToan, bill.Id);
        HoaDonRepository.Update(s, bill);
    }
}
