CREATE TABLE NguoiDung(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TenDangNhap TEXT NOT NULL DEFAULT '' COLLATE NOCASE UNIQUE,
    MatKhauHash TEXT NOT NULL DEFAULT '',
    HoTen TEXT NOT NULL DEFAULT '',
    VaiTro TEXT NOT NULL DEFAULT '' CHECK ((VaiTro IN ('Admin','LeTan','BacSi','ThuNgan','DuocSi'))),
    TrangThai INTEGER NOT NULL CHECK ((TrangThai IN (0,1)))
);

CREATE TABLE BenhNhan(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MaBenhNhan TEXT NOT NULL DEFAULT '' COLLATE NOCASE UNIQUE,
    CanCuocCongDan TEXT NOT NULL DEFAULT '' COLLATE NOCASE UNIQUE CHECK ((length(CanCuocCongDan)=12 AND CanCuocCongDan NOT GLOB '*[^0-9]*')),
    HoTen TEXT NOT NULL DEFAULT '',
    NgaySinh TEXT NOT NULL CHECK ((length(NgaySinh)=10 AND date(NgaySinh,'+0 days') IS NOT NULL AND date(NgaySinh,'+0 days')=NgaySinh)),
    GioiTinh TEXT NOT NULL DEFAULT '' CHECK ((GioiTinh IN ('Nam','Nu','Khac'))),
    SoDienThoai TEXT NOT NULL DEFAULT '',
    DiaChi TEXT NOT NULL DEFAULT '',
    TienSuBenh TEXT NOT NULL DEFAULT '',
    DiUng TEXT NOT NULL DEFAULT '',
    NgayTao TEXT NOT NULL CHECK ((length(NgayTao)=19 AND datetime(NgayTao,'+0 seconds') IS NOT NULL AND datetime(NgayTao,'+0 seconds')=NgayTao))
);

CREATE TABLE PhieuKham(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MaPhieuKham TEXT NOT NULL DEFAULT '' COLLATE NOCASE UNIQUE,
    BenhNhanId INTEGER NOT NULL REFERENCES BenhNhan(Id) ON DELETE RESTRICT CHECK ((typeof(BenhNhanId)='integer')),
    BacSiId INTEGER NOT NULL REFERENCES NguoiDung(Id) ON DELETE RESTRICT CHECK ((typeof(BacSiId)='integer')),
    NguoiTiepNhanId INTEGER NOT NULL REFERENCES NguoiDung(Id) ON DELETE RESTRICT CHECK ((typeof(NguoiTiepNhanId)='integer')),
    NgayKham TEXT NOT NULL CHECK ((length(NgayKham)=10 AND date(NgayKham,'+0 days') IS NOT NULL AND date(NgayKham,'+0 days')=NgayKham)),
    SoThuTu INTEGER NOT NULL CHECK (typeof(SoThuTu)='integer' AND SoThuTu>=1),
    LoaiKham TEXT NOT NULL DEFAULT '' CHECK ((LoaiKham IN ('KhamMoi','TaiKham'))),
    UuTien INTEGER NOT NULL CHECK ((UuTien IN (0,1))),
    TrangThai TEXT NOT NULL DEFAULT '' CHECK ((TrangThai IN ('ChoKham','DangKham','ChoThanhToan','ChoXuatThuoc','HoanTat'))),
    DaInSoKham INTEGER NOT NULL CHECK ((DaInSoKham IN (0,1))),
    InSoKhamLuc TEXT CHECK ((InSoKhamLuc IS NULL OR (length(InSoKhamLuc)=19 AND datetime(InSoKhamLuc,'+0 seconds') IS NOT NULL AND datetime(InSoKhamLuc,'+0 seconds')=InSoKhamLuc))),
    TrieuChung TEXT NOT NULL DEFAULT '',
    ChanDoan TEXT NOT NULL DEFAULT '',
    KetQua TEXT NOT NULL DEFAULT '',
    LoiDan TEXT NOT NULL DEFAULT '',
    NgayTao TEXT NOT NULL CHECK ((length(NgayTao)=19 AND datetime(NgayTao,'+0 seconds') IS NOT NULL AND datetime(NgayTao,'+0 seconds')=NgayTao)),
    GioGoi TEXT CHECK ((GioGoi IS NULL OR (length(GioGoi)=19 AND datetime(GioGoi,'+0 seconds') IS NOT NULL AND datetime(GioGoi,'+0 seconds')=GioGoi))),
    GioHoanTat TEXT CHECK ((GioHoanTat IS NULL OR (length(GioHoanTat)=19 AND datetime(GioHoanTat,'+0 seconds') IS NOT NULL AND datetime(GioHoanTat,'+0 seconds')=GioHoanTat))),
    CHECK((DaInSoKham=0 AND InSoKhamLuc IS NULL) OR (DaInSoKham=1 AND InSoKhamLuc IS NOT NULL))
);

CREATE TABLE NhomThuoc(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TenNhom TEXT NOT NULL DEFAULT '' COLLATE NOCASE UNIQUE
);

CREATE TABLE Thuoc(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MaThuoc TEXT NOT NULL DEFAULT '' COLLATE NOCASE UNIQUE,
    TenThuoc TEXT NOT NULL DEFAULT '',
    DonViTinh TEXT NOT NULL DEFAULT '',
    NhomThuocId INTEGER NOT NULL REFERENCES NhomThuoc(Id) ON DELETE RESTRICT CHECK ((typeof(NhomThuocId)='integer')),
    GiaBan INTEGER NOT NULL CHECK ((typeof(GiaBan)='integer' AND GiaBan>=0))
);

CREATE TABLE LoThuoc(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ThuocId INTEGER NOT NULL REFERENCES Thuoc(Id) ON DELETE RESTRICT CHECK ((typeof(ThuocId)='integer')),
    SoLo TEXT NOT NULL DEFAULT '' COLLATE NOCASE UNIQUE,
    HanSuDung TEXT NOT NULL CHECK ((length(HanSuDung)=10 AND date(HanSuDung,'+0 days') IS NOT NULL AND date(HanSuDung,'+0 days')=HanSuDung)),
    SoLuongNhap INTEGER NOT NULL CHECK ((typeof(SoLuongNhap)='integer' AND SoLuongNhap>=1)),
    SoLuongTon INTEGER NOT NULL CHECK ((typeof(SoLuongTon)='integer' AND SoLuongTon>=0)),
    NgayNhap TEXT NOT NULL CHECK ((length(NgayNhap)=19 AND datetime(NgayNhap,'+0 seconds') IS NOT NULL AND datetime(NgayNhap,'+0 seconds')=NgayNhap)),
    NguoiNhapId INTEGER NOT NULL REFERENCES NguoiDung(Id) ON DELETE RESTRICT CHECK ((typeof(NguoiNhapId)='integer')),
    CHECK(SoLuongTon<=SoLuongNhap)
);

CREATE TABLE DonThuoc(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    PhieuKhamId INTEGER NOT NULL REFERENCES PhieuKham(Id) ON DELETE RESTRICT CHECK ((typeof(PhieuKhamId)='integer')),
    NgayKe TEXT NOT NULL CHECK ((length(NgayKe)=19 AND datetime(NgayKe,'+0 seconds') IS NOT NULL AND datetime(NgayKe,'+0 seconds')=NgayKe)),
    TrangThai TEXT NOT NULL DEFAULT '' CHECK ((TrangThai IN ('DaKe','DaXuat'))),
    NgayXuat TEXT CHECK ((NgayXuat IS NULL OR (length(NgayXuat)=19 AND datetime(NgayXuat,'+0 seconds') IS NOT NULL AND datetime(NgayXuat,'+0 seconds')=NgayXuat))),
    NguoiXuatId INTEGER REFERENCES NguoiDung(Id) ON DELETE RESTRICT CHECK ((NguoiXuatId IS NULL OR (typeof(NguoiXuatId)='integer'))),
    UNIQUE(PhieuKhamId),
    CHECK(TrangThai<>'DaXuat' OR (NgayXuat IS NOT NULL AND NguoiXuatId IS NOT NULL))
);

CREATE TABLE ChiTietDonThuoc(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    DonThuocId INTEGER NOT NULL REFERENCES DonThuoc(Id) ON DELETE RESTRICT CHECK ((typeof(DonThuocId)='integer')),
    ThuocId INTEGER NOT NULL REFERENCES Thuoc(Id) ON DELETE RESTRICT CHECK ((typeof(ThuocId)='integer')),
    SoLuong INTEGER NOT NULL CHECK ((typeof(SoLuong)='integer' AND SoLuong>=1)),
    DonGia INTEGER NOT NULL CHECK ((typeof(DonGia)='integer' AND DonGia>=0)),
    LieuDung TEXT NOT NULL DEFAULT '',
    Sang REAL NOT NULL CHECK ((Sang>=0 AND Sang<=10000)),
    Trua REAL NOT NULL CHECK ((Trua>=0 AND Trua<=10000)),
    Chieu REAL NOT NULL CHECK ((Chieu>=0 AND Chieu<=10000)),
    Toi REAL NOT NULL CHECK ((Toi>=0 AND Toi<=10000)),
    SoNgay INTEGER NOT NULL CHECK ((typeof(SoNgay)='integer' AND SoNgay>=1)),
    ThoiDiemUong TEXT NOT NULL DEFAULT '' CHECK ((ThoiDiemUong IN ('TruocAn','SauAn','TrongBuaAn','KhongQuyDinh'))),
    UNIQUE(DonThuocId,ThuocId)
);

CREATE TABLE HoaDon(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MaHoaDon TEXT NOT NULL DEFAULT '' COLLATE NOCASE UNIQUE,
    PhieuKhamId INTEGER NOT NULL REFERENCES PhieuKham(Id) ON DELETE RESTRICT CHECK ((typeof(PhieuKhamId)='integer')),
    NguoiThuId INTEGER NOT NULL REFERENCES NguoiDung(Id) ON DELETE RESTRICT CHECK ((typeof(NguoiThuId)='integer')),
    NgayThanhToan TEXT NOT NULL CHECK ((length(NgayThanhToan)=19 AND datetime(NgayThanhToan,'+0 seconds') IS NOT NULL AND datetime(NgayThanhToan,'+0 seconds')=NgayThanhToan)),
    TienKham INTEGER NOT NULL CHECK ((typeof(TienKham)='integer' AND TienKham>=0)),
    TienThuoc INTEGER NOT NULL CHECK ((typeof(TienThuoc)='integer' AND TienThuoc>=0)),
    GiamGia INTEGER NOT NULL CHECK ((typeof(GiamGia)='integer' AND GiamGia>=0)),
    TongThu INTEGER NOT NULL CHECK ((typeof(TongThu)='integer' AND TongThu>=0)),
    TienKhachDua INTEGER NOT NULL CHECK ((typeof(TienKhachDua)='integer' AND TienKhachDua>=0)),
    TienThua INTEGER NOT NULL CHECK ((typeof(TienThua)='integer' AND TienThua>=0)),
    HinhThuc TEXT NOT NULL DEFAULT '' CHECK ((HinhThuc IN ('TienMat','ChuyenKhoan'))),
    UNIQUE(PhieuKhamId),
    CHECK(TongThu=TienKham+TienThuoc-GiamGia AND TienKhachDua>=TongThu AND TienThua=TienKhachDua-TongThu)
);

CREATE TABLE BienDongKho(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    LoThuocId INTEGER NOT NULL REFERENCES LoThuoc(Id) ON DELETE RESTRICT CHECK ((typeof(LoThuocId)='integer')),
    SoLuong INTEGER NOT NULL CHECK ((typeof(SoLuong)='integer')),
    Loai TEXT NOT NULL DEFAULT '' CHECK ((Loai IN ('Nhap','Xuat'))),
    ThamChieu TEXT NOT NULL DEFAULT '',
    NguoiThucHienId INTEGER NOT NULL REFERENCES NguoiDung(Id) ON DELETE RESTRICT CHECK ((typeof(NguoiThucHienId)='integer')),
    ThoiGian TEXT NOT NULL CHECK ((length(ThoiGian)=19 AND datetime(ThoiGian,'+0 seconds') IS NOT NULL AND datetime(ThoiGian,'+0 seconds')=ThoiGian)),
    CHECK((Loai='Nhap' AND SoLuong>0) OR (Loai='Xuat' AND SoLuong<0))
);

CREATE TABLE CauHinh(
    Khoa TEXT PRIMARY KEY NOT NULL DEFAULT '',
    GiaTri TEXT NOT NULL DEFAULT ''
);

CREATE UNIQUE INDEX UX_STT ON PhieuKham(NgayKham,BacSiId,SoThuTu);

CREATE UNIQUE INDEX UX_DangKham ON PhieuKham(BacSiId) WHERE TrangThai='DangKham';

CREATE INDEX IX_TiepNhan ON PhieuKham(NgayKham,NgayTao);

CREATE INDEX IX_HangDoi ON PhieuKham(NgayKham,BacSiId,TrangThai);

CREATE INDEX IX_LichSu ON PhieuKham(BenhNhanId,NgayKham);

CREATE INDEX IX_FEFO ON LoThuoc(ThuocId,HanSuDung,Id);

CREATE INDEX IX_ChiTietThuoc ON ChiTietDonThuoc(ThuocId,DonThuocId);

CREATE INDEX IX_ThanhToan ON HoaDon(NgayThanhToan,HinhThuc);
