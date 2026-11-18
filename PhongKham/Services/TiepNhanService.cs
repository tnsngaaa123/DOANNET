using PhongKham.Core;
using PhongKham.Data;
using PhongKham.Data.Repositories;
using PhongKham.Models;
using PhongKham.Models.Views;

namespace PhongKham.Services;

public static class TiepNhanService
{
    public static List<LuotKhamRow> List(string q = "") => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        return PhieuKhamRepository.List(s, DateTime.Today, q: q).OrderByDescending(x => x.Id).ToList();
    });
    public static int Save(BenhNhan input, int doctor, string type, bool priority) => Db.InTransaction(s =>
    {
        var actor = AuthService.Require(s, Roles.LeTan);
        BenhNhanService.ValidateCanCuoc(input.CanCuocCongDan.Trim());
        var person = BenhNhanRepository.ByCanCuoc(s, input.CanCuocCongDan.Trim());
        var bs = NguoiDungRepository.Get(s, doctor);
        if (bs is null || bs.VaiTro != Roles.BacSi || !bs.TrangThai)
            throw new NghiepVuException("Chọn bác sĩ đang hoạt động.");
        if (type is not (TrangThai.KhamMoi or TrangThai.TaiKham))
            throw new NghiepVuException("Loại khám không hợp lệ.");
        if (person is null)
        {
            BenhNhanService.Create(s, input);
            person = input;
        }
        
        var pending = PhieuKhamRepository.All(s).FirstOrDefault(p => p.BenhNhanId == person.Id && p.NgayKham.Date == DateTime.Today && p.TrangThai is TrangThai.ChoKham or TrangThai.DangKham or TrangThai.ChoThanhToan or TrangThai.ChoXuatThuoc);
        if (pending is not null)
            throw new NghiepVuException("Bệnh nhân đang có lượt chưa hoàn tất hôm nay. Hãy dùng lượt đang có trong danh sách.");
        var p = new PhieuKham
        {
            BenhNhanId = person.Id,
            BacSiId = doctor,
            NguoiTiepNhanId = actor.Id,
            NgayKham = DateTime.Today,
            SoThuTu = PhieuKhamRepository.NextNumber(s, DateTime.Today, doctor),
            TrangThai = TrangThai.ChoKham,
            LoaiKham = type,
            UuTien = priority
        };
        p.Id = PhieuKhamRepository.Insert(s, p);
        p.MaPhieuKham = "PK" + DateTime.Today.ToString("yyMMdd") + p.Id.ToString("D4");
        PhieuKhamRepository.Update(s, p);
        return p.Id;
    });
    
    public static PhieuSoData Issue(int id) => Db.Run(s =>
    {
        AuthService.Require(s, Roles.LeTan);
        var p = KhamBenhService.RequireVisit(s, id);
        if (p.TrangThai != TrangThai.ChoKham)
            throw new NghiepVuException("Bệnh nhân không còn chờ khám.");
        return InAnService.Ticket(s, id);
    });
}
