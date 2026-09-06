-- 1. Tạo Database
CREATE DATABASE QuanLyGioDay;
GO

USE QuanLyGioDay;
GO

-- 2. Tạo bảng KHOA
CREATE TABLE Khoa (
    MaKhoa NVARCHAR(20) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    DienThoai NVARCHAR(20)
);

-- 3. Tạo bảng BỘ MÔN
CREATE TABLE BoMon (
    MaBM NVARCHAR(20) PRIMARY KEY,
    TenBM NVARCHAR(100) NOT NULL,
    MaKhoa NVARCHAR(20) NOT NULL,
    DiaChi NVARCHAR(200),
    DienThoai NVARCHAR(20),
    CONSTRAINT FK_BoMon_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

-- 4. Tạo bảng TRÌNH ĐỘ
CREATE TABLE TrinhDo (
    MaTrinhDo NVARCHAR(20) PRIMARY KEY,
    TenTrinhDo NVARCHAR(100) NOT NULL
);

-- 5. Tạo bảng CHUYÊN NGÀNH
CREATE TABLE ChuyenNganh (
    MaChNganh NVARCHAR(20) PRIMARY KEY,
    TenChNganh NVARCHAR(100) NOT NULL
);

-- 6. Tạo bảng MÔN HỌC
CREATE TABLE MonHoc (
    MaMon NVARCHAR(20) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    SoTiet INT DEFAULT 0,
    MaKhoa NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_MonHoc_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

-- 7. Tạo bảng LỚP HỌC
CREATE TABLE LopHoc (
    MaLop NVARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa NVARCHAR(20) NOT NULL,
    SiSo INT DEFAULT 0,
    CONSTRAINT FK_LopHoc_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

-- 8. Tạo bảng GIÁO VIÊN
CREATE TABLE GiaoVien (
    MaGV NVARCHAR(20) PRIMARY KEY,
    TenGV NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(200),
    DienThoai NVARCHAR(20),
    MaKhoa NVARCHAR(20) NOT NULL,
    MaBM NVARCHAR(20) NOT NULL,
    MaTrinhDo NVARCHAR(20),
    MaChNganh NVARCHAR(20),
    LuongTiet DECIMAL(18, 2) DEFAULT 0,
    CONSTRAINT FK_GiaoVien_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa),
    CONSTRAINT FK_GiaoVien_BoMon FOREIGN KEY (MaBM) REFERENCES BoMon(MaBM),
    CONSTRAINT FK_GiaoVien_TrinhDo FOREIGN KEY (MaTrinhDo) REFERENCES TrinhDo(MaTrinhDo),
    CONSTRAINT FK_GiaoVien_ChuyenNganh FOREIGN KEY (MaChNganh) REFERENCES ChuyenNganh(MaChNganh)
);

-- 9. Tạo bảng GIÁO VIÊN - MÔN DẠY (Khóa chính phức hợp MaGV + MaMon)
CREATE TABLE GiaoVien_MonDay (
    MaGV NVARCHAR(20) NOT NULL,
    MaMon NVARCHAR(20) NOT NULL,
    GhiChu NVARCHAR(250),
    PRIMARY KEY (MaGV, MaMon),
    CONSTRAINT FK_GV_MonDay_GiaoVien FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV),
    CONSTRAINT FK_GV_MonDay_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- 10. Tạo bảng LỊCH DẠY (Khóa chính phức hợp MaLop + MaMon + KiHoc + NamHoc)
CREATE TABLE LichDay (
    MaLop NVARCHAR(20) NOT NULL,
    MaMon NVARCHAR(20) NOT NULL,
    MaGV NVARCHAR(20) NOT NULL,
    KiHoc NVARCHAR(10) NOT NULL,
    NamHoc NVARCHAR(20) NOT NULL,
    ThoiGianBD DATE,
    ThoiGianKT DATE,
    ThuDay1 NVARCHAR(20),
    CaDay1 NVARCHAR(20),
    ThuDay2 NVARCHAR(20),
    CaDay2 NVARCHAR(20),
    TienThi DECIMAL(18, 2) DEFAULT 0,
    TienDay DECIMAL(18, 2) DEFAULT 0,
    GhiChu NVARCHAR(250),
    PRIMARY KEY (MaLop, MaMon, KiHoc, NamHoc),
    CONSTRAINT FK_LichDay_LopHoc FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop),
    CONSTRAINT FK_LichDay_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon),
    CONSTRAINT FK_LichDay_GiaoVien FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV)
);
GO

-- =============================================
-- ĐỌC DỮ LIỆU MẪU (DATA TEST)
-- =============================================

-- Thêm Khoa
INSERT INTO Khoa VALUES 
('CNTT', N'Công nghệ thông tin', N'Tầng 3 - Nhà A1', '0243123456'),
('DTVT', N'Điện tử viễn thông', N'Tầng 2 - Nhà A2', '0243654321');

-- Thêm Bộ môn
INSERT INTO BoMon VALUES 
('BM_CNTT', N'Bộ môn Công nghệ phần mềm', 'CNTT', N'Nhà A1', '0988111222'),
('BM_HTTT', N'Bộ môn Hệ thống thông tin', 'CNTT', N'Nhà A1', '0988333444');

-- Thêm Trình độ & Chuyên ngành
INSERT INTO TrinhDo VALUES ('TS', N'Tiến sĩ'), ('THS', N'Thạc sĩ');
INSERT INTO ChuyenNganh VALUES ('CNPM', N'Công nghệ phần mềm'), ('KHMT', N'Khoa học máy tính');

-- Thêm Môn học
INSERT INTO MonHoc VALUES 
('LTPT', N'Lập trình phát triển phần mềm', 45, 'CNTT'),
('CSDL', N'Cơ sở dữ liệu', 60, 'CNTT');

-- Thêm Lớp học
INSERT INTO LopHoc VALUES 
('CNTT1', N'Lớp CNTT K62 1', 'CNTT', 50),
('CNTT2', N'Lớp CNTT K62 2', 'CNTT', 70);

-- Thêm Giáo viên
INSERT INTO GiaoVien VALUES 
('GV01', N'Nguyễn Văn A', '1985-05-20', N'Nam', N'Hà Nội', '0912345678', 'CNTT', 'BM_CNTT', 'THS', 'CNPM', 100000),
('GV02', N'Trần Thị B', '1990-10-12', N'Nữ', N'Hà Nội', '0987654321', 'CNTT', 'BM_HTTT', 'TS', 'KHMT', 120000);

-- Thêm Giáo viên - Môn dạy
INSERT INTO GiaoVien_MonDay VALUES 
('GV01', 'LTPT', N'Dạy lý thuyết'),
('GV02', 'CSDL', N'Dạy thực hành');

-- Thêm Lịch dạy
INSERT INTO LichDay VALUES 
('CNTT1', 'LTPT', 'GV01', '1', '2025-2026', '2026-09-01', '2026-12-15', N'Thứ 2', N'Ca 1', N'Thứ 4', N'Ca 2', 250000, 4500000, N'Học phòng A101');
GO