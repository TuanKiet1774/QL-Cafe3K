CREATE DATABASE QLcafe;
USE QLcafe;

-- Tạo bảng nhân viên
CREATE TABLE NHANVIEN(
MaNV VARCHAR(10) CONSTRAINT pk_nv PRIMARY KEY,
HoNV NVARCHAR(10),
TenNV NVARCHAR(30),
NgaySinh DATE,
GioiTinh NVARCHAR(5),
DiaChi NVARCHAR(100),
SoDT VARCHAR(10),
ChucVu NVARCHAR(50),
NgayLamViec DATE,
LuongGio MONEY,
SoTK VARCHAR(20)
)

-- Tạo bảng ca làm việc
CREATE TABLE CALAMVIEC (
MaCa VARCHAR(10) CONSTRAINT pk_clv PRIMARY KEY,
TenCa NVARCHAR(20),
GioBatDau TIME,
GioKetThuc TIME
)

-- Tạo bảng lương ca
CREATE TABLE LUONGCA( 
Thang SMALLINT, 
Nam SMALLINT,
MaNV1 VARCHAR(10),
MaNV2 VARCHAR(10),
MaNV3 VARCHAR(10),
MaCa VARCHAR(10),
CONSTRAINT fk_lc_nv1 FOREIGN KEY(MaNV1) REFERENCES        NHANVIEN(MaNV),
CONSTRAINT fk_lc_nv2 FOREIGN KEY(MaNV2) REFERENCES NHANVIEN(MaNV),
CONSTRAINT fk_lc_nv3 FOREIGN KEY(MaNV3) REFERENCES NHANVIEN(MaNV),
CONSTRAINT fk_lc_ca FOREIGN KEY(MaCa) REFERENCES CALAMVIEC(MaCa),
CONSTRAINT pk_lc PRIMARY KEY(Thang, Nam, MaCa)
)

-- Tạo bảng khách hàng 
CREATE TABLE KHACHHANG(
MaKH VARCHAR(10) CONSTRAINT pk_kh PRIMARY KEY,
HoKH NVARCHAR(10),
TenKH NVARCHAR(30),
DiaChi NVARCHAR(50) null,
SoDT VARCHAR(10)
)

-- Tạo bảng nhà cung cấp
CREATE TABLE NHACUNGCAP(
MaNCC VARCHAR(10) CONSTRAINT pk_ncc PRIMARY KEY,
TenNCC NVARCHAR(50),
SDT VARCHAR(20),
DiaChi NVARCHAR(100),
Email VARCHAR(50) null,
)

-- Tạo bảng loại mặt hàng
CREATE TABLE LOAIMATHANG(
MaLoai VARCHAR(10) CONSTRAINT pk_lmh PRIMARY KEY,
TenLoai NVARCHAR(30)
)

-- Tạo bảng mặt hàng
CREATE TABLE MATHANG( 
MaMH VARCHAR(10) CONSTRAINT pk_mh PRIMARY KEY,
TenMH NVARCHAR(30),
MaLoai VARCHAR(10) CONSTRAINT fk_mh_lmh FOREIGN KEY(MaLoai) REFERENCES LOAIMATHANG(MaLoai),
MaNCC VARCHAR(10) CONSTRAINT fk_mh_ncc FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC),
SoLuong INT,
DonVi NVARCHAR(10),
NgSX DATE null,
HSD DATE null,
DonGia MONEY
)

-- Tạo bảng ăn uống
CREATE TABLE ANUONG(
MaMon VARCHAR(10) CONSTRAINT pk_au PRIMARY KEY,
TenMon NVARCHAR(30),
MaLoai VARCHAR(10) CONSTRAINT fk_au_lmh FOREIGN KEY(MaLoai) REFERENCES LOAIMATHANG(MaLoai),
MoTa NVARCHAR(100) null,
Size NVARCHAR(10) null, 
GiaTien MONEY,
DonVi NVARCHAR(10)
)

-- Tạo bảng hóa đơn nhập
CREATE TABLE HOADONNHAP(
MaHDN VARCHAR(10) CONSTRAINT pk_hdn PRIMARY KEY,
MaNCC VARCHAR(10) CONSTRAINT fk_hdn_ncc FOREIGN KEY(MaNCC) REFERENCES NHACUNGCAP(MaNCC),         
NgayNhap DATE,
TongTien MONEY
)

-- Tạo bảng chi tiết nhập
CREATE TABLE CHITIETNHAP(
MaHDN VARCHAR(10) CONSTRAINT fk_ctn_hdn FOREIGN KEY(MaHDN) REFERENCES HOADONNHAP(MaHDN),
MaMH VARCHAR(10) CONSTRAINT fk_ctn_mh FOREIGN KEY(MaMH) REFERENCES MATHANG(MaMH),
DonGia MONEY,
SoLuong INT
CONSTRAINT pk_ctn PRIMARY KEY(MaHDN, MaMH)
)

-- Tạo bảng hóa đơn
CREATE TABLE HOADON(
MaHD VARCHAR(10) CONSTRAINT pk_hd PRIMARY KEY,          
MaNV VARCHAR(10) CONSTRAINT fk_hd_nv FOREIGN KEY(MaNV) REFERENCES NHANVIEN(MaNV),
MaKH VARCHAR(10) CONSTRAINT fk_hd_kh FOREIGN KEY(MaKH)
REFERENCES KHACHHANG(MaKH),
Ngay DATETIME,
GiamGia DECIMAL(4,2), 
TongTien MONEY
)

-- Tạo bảng chi tiết hóa đơn
CREATE TABLE CHITIETHOADON(
MaHD VARCHAR(10) CONSTRAINT fk_cthd_hd FOREIGN KEY(MaHD) REFERENCES HOADON(MaHD),
MaMon VARCHAR(10) CONSTRAINT fk_cthd_au FOREIGN KEY(MaMon) REFERENCES ANUONG(MaMon),
DonGia MONEY,
SoLuong INT,
CONSTRAINT pk_cthd PRIMARY KEY(MaHD, MaMon)
)


-- Bảng NHANVIEN
INSERT INTO NHANVIEN(MaNV, HoNV, TenNV, NgaySinh, GioiTinh, DiaChi, SoDT, ChucVu, NgayLamViec, LuongGio, SoTK)
VALUES
('NV001', N'Cao', N'Linh Hà', '2004/12/17', N'Nữ', N'Ninh Hòa', '0375864841', N'Thu ngân', '2023/12/28', 27000, '106876852361'),
('NV002', N'Huỳnh', N'Minh Bảo', '2002/06/30', N'Nam', N'Diên Khánh', '0333535953', N'Thu ngân', '2023/12/28', 30000, '105976342200'),
('NV003', N'Vĩnh', N'Thuận', '2004/08/31', N'Nam', N'Nha Trang', '0702782954', N'Phục vụ', '2023/12/30', 25000, '106876450361'),
('NV004', N'Phạm', N'Tuấn Kiệt', '2004/07/17', N'Nam', N'Diên Khánh', '0333535952', N'Phục vụ', '2023/12/31', 20000, '104333345661'),
('NV005', N'Nguyễn', N'Hiểu Quyên', '2004/10/17', N'Nữ', N'Diên Sơn', '0333979996', N'Pha chế', '2024/01/03', 21000, '103678345661'),
('NV006', N'Nguyễn', N'Hồ Thanh Bình', '2004/04/02', N'Nữ', N'Ninh Hòa', '0703569857', N'Pha chế', '2024/01/04', 21000, '102876345661')

-- Bảng CALAMVIEC
INSERT INTO CALAMVIEC(MaCa, TenCa, GioBatDau, GioKetThuc)
VALUES
('CA01', N'Sáng', '07:00:00', '12:00:00'),
('CA02', N'Trưa', '12:30:00', '16:30:00'),
('CA03', N'Tối', '17:00:00', '22:00:00')

-- Bảng LUONGCA
INSERT INTO LUONGCA(Thang, Nam, MaNV1, MaNV2, MaNV3, MaCa ) VALUES     
(1, 2024, 'NV001', 'NV003', 'NV005', 'CA01'),
(1, 2024, 'NV002', 'NV004', 'NV006', 'CA02'),
(1, 2024, 'NV001', 'NV004', 'NV005', 'CA03'),
(2, 2024, 'NV001', 'NV003', 'NV005', 'CA01'),
(2, 2024, 'NV002', 'NV004', 'NV006', 'CA02'),
(2, 2024, 'NV001', 'NV003', 'NV005', 'CA03'),
(3, 2024, 'NV001', 'NV004', 'NV006', 'CA01'),
(3, 2024, 'NV002', 'NV003', 'NV005', 'CA02'),
(3, 2024, 'NV001', 'NV004', 'NV006', 'CA03'),
(4, 2024, 'NV001', 'NV003', 'NV006', 'CA01'),
(4, 2024, 'NV002', 'NV004', 'NV005', 'CA02'),
(4, 2024, 'NV001', 'NV003', 'NV006', 'CA03'),
(5, 2024, 'NV001', 'NV004', 'NV005', 'CA01'),
(5, 2024, 'NV002', 'NV003', 'NV006', 'CA02'),
(5, 2024, 'NV001', 'NV004', 'NV005', 'CA03'),
(6, 2024, 'NV001', 'NV003', 'NV006', 'CA01'),
(6, 2024, 'NV002', 'NV004', 'NV005', 'CA02'),
(6, 2024, 'NV001', 'NV003', 'NV006', 'CA03'),
(7, 2024, 'NV001', 'NV004', 'NV005', 'CA01'),
(7, 2024, 'NV002', 'NV003', 'NV006', 'CA02'),
(7, 2024, 'NV001', 'NV004', 'NV005', 'CA03'),
(8, 2024, 'NV001', 'NV003', 'NV006', 'CA01'),
(8, 2024, 'NV002', 'NV004', 'NV005', 'CA02'),
(8, 2024, 'NV001', 'NV003', 'NV006', 'CA03'),
(9, 2024, 'NV001', 'NV004', 'NV005', 'CA01'),
(9, 2024, 'NV002', 'NV003', 'NV006', 'CA02'),
(9, 2024, 'NV001', 'NV004', 'NV005', 'CA03'),
(10, 2024, 'NV001', 'NV003', 'NV006', 'CA01'),
(10, 2024, 'NV002', 'NV004', 'NV005', 'CA02'),
(10, 2024, 'NV001', 'NV003', 'NV006', 'CA03'),
(11, 2024, 'NV001', 'NV004', 'NV005', 'CA01'),
(11, 2024, 'NV002', 'NV003', 'NV006', 'CA02'),
(11, 2024, 'NV001', 'NV004', 'NV005', 'CA03'),
(12, 2024, 'NV001', 'NV003', 'NV006', 'CA01'),
(12, 2024, 'NV002', 'NV004', 'NV005', 'CA02'),
(12, 2024, 'NV001', 'NV003', 'NV006', 'CA03')

-- Bảng KHACHHANG
INSERT INTO KHACHHANG(MaKH, HoKH, TenKH, DiaChi, SoDT)
VALUES
('KH001', N'Nguyễn', N'Thanh Tùng', N'21 Vĩnh Phương', '0333535987'),
('KH002', N'Bùi', N'Thúy An', N'Diên Khánh', '0222535987'),
('KH003', N'Nguyễn', N'Thanh Long', N'Diên An', '0212535987'),
('KH004', N'Hoàng', N'Thị Hoa', N'07 Nguyễn Đình Chiểu', '0556535987'),
('KH005', N'Trần', N'Minh Khang', N'Diên Sơn', '0789535987'),
('KH006', N'Võ', N'Mạnh Hùng', N'30 Lê Hồng Phong', '0405535987'),
('KH007', N'Trần', N'Thanh Tâm', N'17 Trần Phú', '0304535987')

-- Bảng NHACUNGCAP
INSERT INTO NHACUNGCAP(MaNCC, TenNCC, SDT, DiaChi, Email) 
VALUES
('NCC01', N'Trái Cây Nhập Khẩu Deli Fruit', '0328028779', N'1 Lý Tự Trọng, Diên Khánh', 'Info79.deli@gmail.com'), 
('NCC02', N'Thực Phẩm Sạch A-Z', '0916510044', N'37 Nguyễn Bỉnh Khiêm, Nha Trang', NULL), 
('NCC03', N'Công Ty TNHH CSCOFFEE ', '0987850763', N'50B Yersin, Nha Trang', 'cscoffee@gmail.com'),
('NCC04', N'Đại Lý Tạp Hóa Nha Trang', '0263583990', N' 127 Ngô Gia Tự, Nha Trang', 'dailymygoi79@gmail.com'),
('NCC05', N'Đại Lý Sữa Quốc Phong', '0903553542', N'Vĩnh Trung, Nha Trang', 'quocphongco@gmail.com'),
('NCC06', N'Lò Bánh Mì Kim Thành', '0914074469', N'07 Hồng Bàng, Nha Trang', NULL),
('NCC07', N'Đại Lý Bia - Nước Ngọt Sáu Lợt', '0383909497', N'Vĩnh Thạnh, Nha Trang', NULL)

-- Bảng LOAIMATHANG
INSERT INTO LOAIMATHANG(MaLoai, TenLoai) 
VALUES
('DOAN', N'Đồ Ăn'),
('DOUONG', N'Thức Uống'),
('NGLI', N'Nguyên Liệu')

-- Bảng MATHANG
INSERT INTO MATHANG(MaMH, TenMH, MaLoai, MaNCC, SoLuong, DonVi, NgSX, HSD, DonGia) 
VALUES
('MH001', N'Bột Cafe', 'NGLI', 'NCC03', 10, N'Kg', '2024/02/17', '2024/07/17', 85000), 
('MH002', N'Cafe Gói', 'NGLI', 'NCC03', 50, N'Hộp', '2023/11/27', '2026/12/27', 55000),
('MH003', N'Sữa Ông Thọ', 'NGLI', 'NCC05', 80, N'Lon', '2024/01/31', '2025/07/31', 24000),
('MH004', N'Cam', 'NGLI', 'NCC01', 10, N'Kg', '2024/04/30', NULL, 14000),
('MH005', N'Cà Rốt', 'NGLI', 'NCC01', 5, N'Kg', '2024/05/12', NULL, 32000),
('MH006', N'Dưa Hấu', 'NGLI', 'NCC01', 12, N'Kg', '2024/04/30', NULL, 20000),
('MH007', N'Bơ', 'NGLI', 'NCC01', 7, N'Kg', '2024/05/12', NULL, 34000),
('MH008', N'Dừa', 'NGLI', 'NCC01', 9, N'Kg', '2024/05/10', NULL, 38000),
('MH009', N'Chanh', 'NGLI', 'NCC01', 6, N'Kg', '2024/05/07', NULL, 15000),
('MH010', N'Chanh Dây', 'NGLI', 'NCC01', 7, N'Kg', '2024/05/10', NULL, 28000),
('MH011', N'Mì Chua Cay 3 Miền', 'DOAN', 'NCC04', 5, N'Thùng', '2024/03/14', '2024/09/14', 120000),
('MH012', N'Trứng Gà', 'DOAN', 'NCC02', 5, N'Vỉ', '2024/05/10', NULL, 20000),
('MH013', N'Bánh Mỳ', 'DOAN', 'NCC06', 20, N'Ổ', '2024/05/10', NULL, 4000),
('MH014', N'Đá Bi', 'NGLI', 'NCC07', 10, N'Bao', NULL, NULL, 25000),
('MH015', N'7Up', 'DOUONG', 'NCC07', 9, N'Thùng', '2024/03/14', '2025/03/14', 212000),
('MH016', N'Pepsi', 'DOUONG', 'NCC07', 8, N'Thùng', '2024/02/11', '2025/01/11', 120000),
('MH017', N'Coca Cola', 'DOUONG', 'NCC07', 10, N'Thùng', '2024/04/19', '2025/04/19', 220000),
('MH018', N'Number 1', 'DOUONG', 'NCC07', 6, N'Thùng', '2024/02/11', '2025/02/11', 208000),
('MH019', N'Trà Xanh 0 Độ', 'DOUONG', 'NCC07', 7, N'Thùng', '2024/01/25', '2025/04/25', 220000),
('MH020', N'Milo', 'DOUONG', 'NCC07', 5, N'Thùng', '2024/04/20', '2024/12/20', 270000),
('MH021', N'Milo Bột', 'NGLI', 'NCC05', 20, N'Gói', '2024/04/25', '2024/12/25', 3000),
('MH022', N'Vinamilk', 'DOUONG', 'NCC05', 5, N'Thùng', '2024/01/25', '2025/04/25', 243000),
('MH023', N'Xúc Xích', 'DOAN', 'NCC04', 10, N'Gói', '2024/03/14', '2024/09/14', 20000)

-- Bảng ANUONG
INSERT INTO ANUONG(MaMon, TenMon, MaLoai, MoTa, Size, GiaTien, DonVi) 
VALUES
('M001', N'Cafe Đen', 'DOUONG', N'Cafe, Đường, Đá', NULL, 10000, N'Ly'),
('M002', N'Cafe Cốt Dừa', 'DOUONG', N'Cafe, Dừa, Sữa, Đá', NULL, 17000, N'Ly'),
('M003', N'Cafe Sữa', 'DOUONG', N'Cafe, Sữa Đặc, Đá', NULL, 15000,	N'Ly'),
('M004', N'Nước Ép Cam', 'DOUONG', N'Cam, Đường, Đá', NULL, 15000, N'Ly'),
('M005', N'Sinh Tố Cà Rốt', 'DOUONG', N'Cà Rốt, Sữa Đặc, Đá', NULL, 15000, N'Ly'),
('M006', N'Nước Ép Dưa Hấu', 'DOUONG', N'Dưa Hấu, Đường, Đá', NULL, 17000, N'Ly'),
('M007', N'Sữa Đá Chanh', 'DOUONG', N'Chanh, Sữa Đặc, Đá', NULL, 15000, N'Ly'),
('M008', N'Chanh Dây Sữa', 'DOUONG', N'Chanh Dây, Sữa Đặc, Đá', NULL, 15000, N'Ly'),
('M009', N'Sinh Tố Bơ', 'DOUONG', N'Bơ, Sữa Đặc, Đá', NULL, 20000, N'Ly'),
('M010', N'Dừa Tươi', 'DOUONG', N'Dừa Trái', NULL, 17000, N'Trái'),
('M011', N'Milo Dầm', 'DOUONG', N'Milo Bột, Sữa Đặc, Đá', NULL, 17000, N'Ly'),
('M012', N'Sữa Milo/Vinamilk', 'DOUONG', N'Milo Bột, Sữa Đặc, Đá', NULL, 10000, N'Hộp'),
('M013', N'Mì Gói', 'DOAN', N'Mì Gói, Trứng, Xúc Xích, Giá Đỗ', N'Nhỏ', 20000, N'Tô'),
('M014', N'Mì Gói Đặc Biệt', 'DOAN', N'Mì Gói, 2 Trứng, Xúc Xích, Giá Đỗ', N'Lớn', 25000, N'Tô'),
('M015', N'Bánh Mỳ', 'DOAN', N'Trứng, Xúc Xích, Bánh Mỳ', N'Nhỏ', 12000, N'Ổ'),
('M016', N'Bánh Mỳ Đặc Biệt', 'DOAN', N'2 Trứng, Xúc Xích, Bánh Mỳ', N'Lớn', 15000, N'Ổ'),
('M017', N'Ốp La', 'DOAN', N'Trứng, Xúc Xích, Bánh Mỳ', N'Nhỏ', 15000, N'Phần'),
('M018', N'Ốp La Đặc Biệt', 'DOAN', N'2 Trứng, Xúc Xích, Bánh Mỳ', N'Lớn', 20000, N'Phần'),
('M019', N'7Up', 'DOUONG', NULL, NULL, 10000, N'Lon'),
('M020', N'Pepsi', 'DOUONG', NULL, NULL, 10000, N'Lon'),
('M021', N'Coca Cola', 'DOUONG', NULL, NULL, 10000, N'Lon'),
('M022', N'Number 1', 'DOUONG', NULL, NULL, 10000, N'Lon'),
('M023', N'Trà Xanh 0 Độ', 'DOUONG', NULL, NULL, 10000, N'Chai')

-- Bảng HOADONNHAP
INSERT INTO HOADONNHAP(MaHDN, MaNCC, NgayNhap, TongTien)
VALUES
('HDN001', 'NCC01', '2023/12/09', 954000),
('HDN002', 'NCC01', '2023/12/11', 517000),  
('HDN003', 'NCC02', '2023/12/21', 200000), 
('HDN004', 'NCC03', '2023/12/29', 1020000), 
('HDN005', 'NCC01', '2024/01/05', 1150000), 
('HDN006', 'NCC03', '2024/01/07', 890000),
('HDN007', 'NCC04', '2024/01/07', 1240000),
('HDN008', 'NCC05', '2024/01/11', 480000),
('HDN009', 'NCC05', '2024/01/28', 1395000),
('HDN010', 'NCC06', '2024/02/15', 120000),
('HDN011', 'NCC07', '2024/02/18', 1568000),
('HDN012', 'NCC01', '2024/03/09', 288000),
('HDN013', 'NCC07', '2024/03/21', 2420000),
('HDN014', 'NCC07', '2024/03/21', 2557000)

-- Bảng CHITIETNHAP
INSERT INTO CHITIETNHAP(MaHDN, MaMH, DonGia, SoLuong) 
VALUES
('HDN001', 'MH004', 14000, 27),
('HDN001', 'MH005', 32000, 18),
('HDN002', 'MH008', 38000, 15),
('HDN003', 'MH012', 20000, 10),
('HDN004', 'MH001', 85000, 12),
('HDN005', 'MH007', 34000, 25),
('HDN005', 'MH009', 15000, 20),
('HDN006', 'MH001', 85000, 4),
('HDN006', 'MH002', 55000, 10),
('HDN007', 'MH011', 120000, 9),
('HDN007', 'MH023', 20000, 8),
('HDN008', 'MH003', 24000, 20),
('HDN009', 'MH021', 3000, 60),
('HDN009', 'MH022', 243000, 5),
('HDN010', 'MH013', 4000, 30),
('HDN011', 'MH015', 212000, 4),
('HDN011', 'MH016', 120000, 6),
('HDN012', 'MH006', 20000, 6),
('HDN012', 'MH010', 28000, 6),
('HDN013', 'MH017', 220000, 6),
('HDN013', 'MH019', 220000, 5),
('HDN014', 'MH020', 270000, 5),
('HDN014', 'MH018', 208000, 4),
('HDN014', 'MH014', 25000, 15)

-- Bảng HOADON
INSERT INTO HOADON(MaHD, MaNV, MaKH, Ngay, GiamGia, TongTien) 
VALUES
('HD0001', 'NV001', 'KH001', '2024/01/18', 0.1, 32000),
('HD0002', 'NV001', 'KH002', '2024/01/20', 0, 30000),
('HD0003', 'NV002', 'KH003', '2024/02/03', 0, 40000),
('HD0004', 'NV001', 'KH002', '2024/02/14', 0.05, 34000),
('HD0005', 'NV002', 'KH004', '2024/02/16', 0, 27000),
('HD0006', 'NV002', 'KH001', '2024/02/21', 0, 15000),
('HD0007', 'NV002', 'KH005', '2024/03/11', 0, 30000),
('HD0008', 'NV001', 'KH006', '2024/03/21', 0, 40000),
('HD0009', 'NV002', 'KH002', '2024/04/05', 0.1, 54000),
('HD0010', 'NV001', 'KH006', '2024/04/15', 0, 45000),
('HD0011', 'NV001', 'KH007', '2024/04/16', 0, 30000)


-- Bảng CHITIETHOADON
INSERT INTO CHITIETHOADON(MaHD, MaMon, DonGia, SoLuong) 
VALUES
('HD0001', 'M003', 15000, 1),
('HD0001', 'M006', 17000, 1),
('HD0002', 'M018', 20000, 1),
('HD0002', 'M021', 10000, 1),
('HD0003', 'M009', 20000, 2),
('HD0004', 'M015', 12000, 2),
('HD0005', 'M001', 10000, 1),
('HD0005', 'M010', 17000, 1),
('HD0006', 'M004', 15000, 1),
('HD0007', 'M012', 10000, 3),
('HD0008', 'M009', 20000, 2),
('HD0009', 'M013', 20000, 1),
('HD0009', 'M011', 17000, 2),
('HD0010', 'M005', 15000, 3),
('HD0011', 'M008', 15000, 2)

--TRUY VẤN ĐƠN GIẢN
--1. Cho biết thông tin các nhân viên của quán (mã, học tên, ngày sinh, giới tính)
SELECT nv.MaNV AS 'Mã Nhân Viên', nv.HoNV + '  ' + nv.TenNV AS 'Họ Tên', nv.NgaySinh AS 'Ngày sinh', nv.GioiTinh AS 'Giới tính' 
FROM NHANVIEN nv
--2. Cho biết các món có trong thực đơn của quán (tên món, giá tiền)
SELECT au.TenMon AS 'Tên Món', au.GiaTien AS 'Giá Tiền' 
FROM ANUONG au
--3. Cho biết mã, tên và số điện thoại của các nhà cung cấp
SELECT ncc.MaNCC AS 'Mã nhà cung cấp', ncc.TenNCC AS 'Nhà cung cấp', ncc.SDT AS 'Số điện thoại' 
FROM NHACUNGCAP ncc


--Câu lệnh truy vấn với Aggregate Functions
--1. Cho biết có bao nhiêu nhân viên nữ đang làm tại quán
SELECT COUNT(*) AS 'Số nhân viên nữ' 
FROM NHANVIEN 
WHERE GioiTinh LIKE N'Nữ'
--2. Cho biết tổng số tiền của các hóa đơn vào tháng 2 năm 2024
SELECT SUM(TongTien) AS 'Tổng số tiền vào 2/2024' 
FROM HOADON hd 
WHERE MONTH(Ngay) = 02 AND  YEAR(Ngay) = 2024 
--3. Cho biết món nào đắt nhất quán 
SELECT au.TenMon AS 'Tên món ăn có giá tiền thấp nhất' 
FROM ANUONG au 
WHERE GiaTien = (SELECT MIN(GiaTien) FROM ANUONG)
--4. Cho biết có bao nhiêu mặt hàng là nguyên liệu
SELECT COUNT(*) AS 'Số nguyên liệu' 
FROM MATHANG mh
WHERE mh.MaLoai = 'NGLI'
--5. Cho biết giá tiền trung bình các món của quán
SELECT AVG(au.GiaTien) AS 'Giá tiền trung bình' 
FROM ANUONG au
--6. Cho biết thông tin hóa đơn nhập có TongTien lớn nhất
SELECT hdn.MaHDN AS 'Mã hóa đơn nhập', hdn.MaNCC AS 'Mã nhà cung cấp', hdn.NgayNhap AS 'Ngày nhập' 
FROM HOADONNHAP hdn
WHERE TongTien = ( SELECT MAX(TongTien) FROM HOADONNHAP)
--7. Cho biết lương của nhân viên trong tháng 7 năm 2024
SELECT nv.MaNV AS 'Mã Nhân Viên', nv.HoNV + '  ' + nv.TenNV AS 'Họ Tên', SUM((DATEDIFF(HOUR, GioBatDau, GioKetThuc)) * nv.LuongGio * 30) AS 'Lương tháng 7'
FROM NHANVIEN nv 
INNER JOIN LUONGCA lc ON nv.MaNV = lc.MaNV1 OR nv.MaNV = lc.MaNV2 OR nv.MaNV = lc.MaNV3
INNER JOIN CALAMVIEC clv ON clv.MaCa = lc.MaCa
WHERE lc.Thang = 7 AND lc.Nam = 2024
GROUP BY nv.MaNV, nv.HoNV, nv.TenNV


--Câu lệnh truy  vấn với mệnh đề Having
--1. Cho biết thông tin của những khách hàng đến quán mua nước đúng 1 lần (họ tên, địa chỉ, số điện thoại)
SELECT kh.HoKH + '  ' + kh.TenKH AS 'Khách hàng', kh.DiaChi AS 'Địa chỉ', kh.SoDT AS 'Số điện thoại' 
FROM KHACHHANG kh JOIN HOADON hd ON kh.MaKH = hd.MaKH 
GROUP BY HoKH, TenKH, DiaChi, SoDT
HAVING COUNT(hd.MaKH) = 1
--2. Cho biết thông tin của nhà cung cấp duy nhất 1 sản phẩm (tên, địa chỉ, số điện thoại)
SELECT ncc.TenNCC AS 'Nhà cung cấp', ncc.SDT AS 'Số điện thoại' , ncc.DiaChi AS 'Địa chỉ'
FROM NHACUNGCAP ncc JOIN MATHANG mh ON ncc.MaNCC = mh.MaNCC 
GROUP BY TenNCC, SDT, DiaChi
HAVING COUNT(mh.MaNCC) = 1
--3. Cho biết danh sách khách hàng đã gọi ít nhất 2 món khác nhau của quán
SELECT kh.HoKH + '  ' + kh.TenKH AS 'Khách hàng', kh.DiaChi AS 'Địa chỉ', kh.SoDT AS 'Số điện thoại' 
FROM KHACHHANG kh 
JOIN HOADON hd ON kh.MaKH = hd.MaKH
JOIN CHITIETHOADON cthd ON cthd.MaHD = hd.MaHD 
GROUP BY HoKH, TenKH, DiaChi, SoDT
HAVING COUNT(DISTINCT cthd.MaMon) >= 2
--4. Cho biết danh sách khách hàng đã gọi đồ uống và số lượng đồ uống của họ
SELECT kh.MaKH AS 'Mã Số', kh.HoKH + '  ' + kh.TenKH AS 'Khách hàng', kh.DiaChi AS 'Địa chỉ', kh.SoDT AS 'Số điện thoại', COUNT(au.MaMon) AS 'Số lượng đồ uống' 
FROM KHACHHANG kh 
JOIN HOADON hd ON kh.MaKH = hd.MaKH
JOIN CHITIETHOADON cthd ON cthd.MaHD = hd.MaHD 
JOIN ANUONG au ON cthd.MaMon = au.MaMon
WHERE au.MaLoai = 'DOUONG'
GROUP BY kh.MaKH, kh.HoKH, kh.TenKH, kh.DiaChi, kh.SoDT
HAVING COUNT(au.MaMon) > 0
--5. Danh sách khách hàng đã gọi đồ uống với tổng tiền chi trả vượt quá 20.000
SELECT kh.MaKH AS 'Mã Số', kh.HoKH + '  ' + kh.TenKH AS 'Khách hàng', kh.DiaChi AS 'Địa chỉ', kh.SoDT AS 'Số điện thoại', SUM(cthd.DonGia * cthd.SoLuong) AS 'Tổng tiền đồ uống'
FROM KHACHHANG kh 
JOIN HOADON hd ON kh.MaKH = hd.MaKH
JOIN CHITIETHOADON cthd ON cthd.MaHD = hd.MaHD 
JOIN ANUONG au ON cthd.MaMon = au.MaMon
WHERE au.MaLoai = 'DOAN'
GROUP BY kh.MaKH, kh.HoKH, kh.TenKH, kh.DiaChi, kh.SoDT
HAVING SUM(cthd.DonGia * cthd.SoLuong) >= 20000


--Câu lệnh truy vấn lớn nhất/ nhỏ nhất
--1. Cho biết danh sách nhân viên lớn tuổi nhất quán
SELECT * 
FROM NHANVIEN nv
WHERE DATEDIFF(YEAR, nv.NgaySinh, GETDATE()) = (SELECT MAX(DATEDIFF(YEAR, NgaySinh, GETDATE())) FROM NHANVIEN)
--2. Cho biết danh sách nhân lương có lương giờ thấp nhất
SELECT * 
FROM NHANVIEN nv
WHERE nv.LuongGio = (SELECT MIN(LuongGio) FROM NHANVIEN)
--3. Cho biết ca làm việc có thời gian dài nhất
SELECT clv.MaCa AS 'Mã ca', clv.TenCa AS 'Ca làm', clv.GioBatDau AS 'Vào ca', clv.GioKetThuc AS 'Tan ca', DATEDIFF (MINUTE, clv.GioBatDau, clv.GioKetThuc) AS 'Thời gian làm (phút)' 
FROM CALAMVIEC clv WHERE DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc) = (SELECT MAX(DATEDIFF(MINUTE, GioBatDau, GioKetThuc)) FROM CALAMVIEC)


--Câu lệnh truy vấn Không/chưa có (Not In và Left/right join)
--1. Cho biết danh sách những khách hàng không mua hàng vào tháng 2
SELECT DISTINCT kh.MaKH AS 'Mã Số', kh.HoKH + ' ' + kh.TenKH AS 'Khách hàng', kh.DiaChi AS 'Địa chỉ', kh.SoDT AS 'Số điện thoại'
FROM KHACHHANG kh LEFT JOIN HOADON hd ON kh.MaKH = hd.MaKH AND MONTH(hd.Ngay) = 2 
WHERE hd.MaKH IS NULL
--2. Cho biết tất cả các hóa đơn mà các nhân viên thu ngân của quán đã tạo
SELECT hd.MaHD AS 'Mã hóa đơn', hd.Ngay AS 'Ngày', nv.MaNV AS 'Mã nhân viên', nv.TenNV AS 'Nhân viên'
FROM HOADON hd RIGHT JOIN NHANVIEN nv ON nv.MaNV = hd.MaNV WHERE nv.ChucVu LIKE N'Thu ngân'
--3. Danh sách các món ăn không xuất hiện ở bất cứ hóa đơn nào
SELECT au.MaMon AS 'Mã món', au.TenMon AS'Tên món' FROM ANUONG au WHERE MaMon NOT IN (SELECT MaMon FROM CHITIETHOADON)
--4. Danh sách các nhà cung cấp không cung cấp các mặt hàng có mã loại DOAN và DOUONG
SELECT ncc.MaNCC AS 'Mã số', ncc.TenNCC AS 'Nhà cung cấp', ncc.SDT AS 'Số điện thoại', ncc.DiaChi AS 'Địa chỉ'
FROM NHACUNGCAP ncc
WHERE ncc.MaNCC NOT IN (SELECT DISTINCT mh.MaNCC FROM MATHANG mh WHERE mh.MaLoai IN ('DOAN', 'DOUONG'))
--5. Cho biết danh sách khách hàng chưa có bất kỳ hóa đơn nào
SELECT MaKH AS 'Mã số ', HoKH+' '+TenKH AS 'Khách hàng', DiaChi AS 'Địa chỉ', SoDT AS 'Số điện thoại' 
FROM KHACHHANG
WHERE MaKH NOT IN (SELECT DISTINCT MaKH FROM HOADON)


--Câu lệnh truy vấn Hợp, Giao, Trừ
--1. Lấy danh sách thông tin nhân viên và khách hàng
SELECT HoNV + '  ' + TenNV AS 'Họ và tên', 'Nhân viên' AS 'Vai trò' 
FROM NHANVIEN
UNION
SELECT HoKH + '  ' + TenKH AS 'Họ và tên', 'Khách hàng' AS 'Vai trò' 
FROM KHACHHANG
--2. Danh sách các mặt hàng có đơn vị không phải ‘Thùng’
SELECT TenMH AS 'Mặt hàng' FROM MATHANG
EXCEPT
SELECT TenMH AS 'Mặt hàng' 
FROM MATHANG 
WHERE DonVi LIKE N'Thùng'
--3. Cho biết danh sách nhà cung cấp vừa cung cấp mặt hàng đồ uống và nguyên liệu
SELECT ncc.MaNCC AS 'Mã số' , ncc.TenNCC AS 'Nhà cung cấp', ncc.SDT AS 'Số điện thoại', ncc.DiaChi AS 'Địa chỉ'
FROM NHACUNGCAP ncc JOIN MATHANG mh ON ncc.MaNCC = mh.MaNCC WHERE mh.MaLoai LIKE 'DOUONG'
INTERSECT
SELECT ncc.MaNCC AS 'Mã số' , ncc.TenNCC AS 'Nhà cung cấp', ncc.SDT AS 'Số điện thoại' , ncc.DiaChi AS 'Địa chỉ'
FROM NHACUNGCAP ncc JOIN MATHANG mh ON ncc.MaNCC = mh.MaNCC WHERE mh.MaLoai LIKE 'NGLI'


--Câu lệnh truy vấn sử dụng phép Chia
--1. Cho biết tên món có tham gia vào tất cả các hóa đơn
SELECT DISTINCT au.TenMon AS 'Món ăn thương hiệu' 
FROM ANUONG au INNER JOIN CHITIETHOADON cthd ON cthd.MaMon = au.MaMon
WHERE NOT EXISTS 
	(SELECT * FROM HOADON hd 
	WHERE NOT EXISTS 
		(SELECT * FROM CHITIETHOADON cthd2 
		WHERE hd.MaHD = cthd2.MaHD AND cthd2.MaMon = cthd.MaMon))
--2. Cho biết đơn hàng mua tất cả các món của quán
SELECT DISTINCT * 
FROM HOADON hd INNER JOIN CHITIETHOADON cthd ON hd.MaHD = cthd.MaHD
WHERE NOT EXISTS 
	(SELECT * FROM ANUONG au 
	WHERE NOT EXISTS 
		(SELECT * FROM CHITIETHOADON cthd2 
		WHERE au.MaMon = cthd2.MaMon AND cthd2.MaHD = cthd.MaHD))


--Câu lệnh truy vấn Update, Delete
--1. Xóa món trong thực đơn
DELETE FROM ANUONG WHERE MaMon = ' M020'
--2. Xóa mặt hàng đã nhập
DELETE FROM CHITIETNHAP WHERE MaMH = 'MH011'
DELETE FROM MATHANG WHERE MaMH = 'MH011'
--3. Cập nhật nhà cung cấp
UPDATE NHACUNGCAP SET DiaChi = N'10 Lạc Long Quân' WHERE MaNCC = 'NCC01'
--4. Cập nhật giờ làm 
UPDATE CALAMVIEC SET GioBatDau = '12:00:00', GioKetThuc = '16:00:00' WHERE MaCa = 'CA02'
--5. Cập nhật lương giờ
UPDATE NHANVIEN SET LuongGio = 21000 WHERE MaNV IN ('NV003', 'NV004');
UPDATE NHANVIEN SET LuongGio = 22000 WHERE MaNV IN ('NV005', 'NV006');
--6. Cập nhật mặt hàng
UPDATE MATHANG SET DonGia = 16000 WHERE MaMH = 'MH004'
UPDATE MATHANG SET DonVi = N'Trái' WHERE MaMH = 'MH008'
UPDATE MATHANG SET SoLuong = 40  WHERE MaMH = 'MH013'
--7. Xóa thông tin khách hàng
DELETE FROM KHACHHANG WHERE MaKH = 'KH008'


--Thủ tục 
--1. Thủ tục thêm thông nhân viên mới
CREATE PROC ThemNhanVien(
@MaNV varchar(10),
@HoNV nvarchar(10),
@TenNV nvarchar(30),
@NgaySinh date,
@GioiTinh nvarchar(5),
@DiaChi nvarchar(100),
@SoDT varchar(10),
@ChucVu nvarchar(50),
@NgayLamViec date,
@LuongGio money,
@SoTK varchar(20)
) AS
BEGIN 
INSERT INTO NHANVIEN (MaNV, HoNV, TenNV, NgaySinh, GioiTinh, DiaChi, SoDT, ChucVu, NgayLamViec, LuongGio, SoTK)
VALUES (@MaNV,@HoNV,@TenNV,@NgaySinh,@GioiTinh,@DiaChi,@SoDT,@ChucVu,@NgayLamViec,@LuongGio,@SoTK)
END
--Ví dụ minh họa
EXEC ThemNhanVien 'NV007', N'Diep', N'Ngọc Song','2003/06/17', N'Nam', N'33/18 Ngô Quyền', '0246813579', N'Phục Vụ','2024/05/01', 15000, '104030345661' 
--2. Thủ tục thêm thông tin khách hàng mới
CREATE PROC ThemKhachHang(
@MaKH varchar(10),
@HoKH nvarchar(10),
@TenKH nvarchar(30),
@DiaChi nvarchar(50) NULL,
@SoDT varchar(10)
) AS
BEGIN 
INSERT INTO KHACHHANG(MaKH, HoKH, TenKH, DiaChi, SoDT)
VALUES (@MaKH, @HoKH, @TenKH, @DiaChi, @SoDT)
END
--Ví dụ minh họa
EXEC ThemKhachHang 'KH014', N'Phạm', N'Minh Phương', NULL, 0983909248
--3. Thủ tục cập nhật thông tin chà cung cấp
CREATE PROC CapNhatThongTinNhaCungCap(
@MaNCC varchar(10),
@TenNCC nvarchar(50),
@SDT varchar(20),
@DiaChi nvarchar(100),
@Email varchar(50) null
) AS
BEGIN
UPDATE NHACUNGCAP
SET TenNCC = @TenNCC , SDT = @SDT, DiaChi = @DiaChi, Email = @Email
WHERE MaNCC = @MaNCC
END
--Ví dụ minh họa
EXEC CapNhatThongTinNhaCungCap 'NCC01', N'Trái Cây Nhập Khẩu Deli Fruit', '0328028779', N'Diên An, Diên Khánh', 'DeliFruit.DienKhanh@gmail.com'
--4. Thủ tục tính tổng số mặt hàng của một nhà cung cấp nào đó
CREATE PROC TongMatHang (@MaNCC varchar(10))
AS
BEGIN
DECLARE @TenNCC nvarchar(50);
DECLARE @SDT varchar(10);
DECLARE @DiaChi nvarchar(100);
DECLARE @TongSoLuong int;
SELECT @TenNCC = ncc.TenNCC, @SDT = ncc.SDT, @DiaChi = ncc.DiaChi, @TongSoLuong = COUNT(mh.MaMH)
FROM NHACUNGCAP ncc INNER JOIN MATHANG mh ON mh.MaNCC = ncc.MaNCC 
WHERE ncc.MaNCC = @MaNCC
GROUP BY ncc.TenNCC, ncc.SDT, ncc.DiaChi;
SELECT 'Tên Nhà Cung Cấp' = @TenNCC, 'Số Điện Thoại' = @SDT, 'Địa Chỉ' = @DiaChi, 'Tổng Số Lượng Mặt Hàng' = @TongSoLuong;
END
--Ví dụ minh họa
EXEC TongMatHang @MaNCC = 'NCC01'
--5. Thủ tục cập nhật lương giờ của nhân viên
CREATE PROC CapNhatLuongGio
	@MaNV VARCHAR(10),
	@LuongGioMoi MONEY
AS
BEGIN
	UPDATE NHANVIEN
	SET LuongGio = @LuongGioMoi
	WHERE MaNV = @MaNV;
END;
--Ví dụ minh họa
EXEC CapNhatLuongGio 'NV005', 23000;


--Hàm
--1. Hàm tính lương tháng của nhân viên 
CREATE FUNCTION TinhLuongNhanVien(@Thang int, @Nam int)
RETURNS TABLE
AS
RETURN
(
SELECT nv.MaNV as 'Mã', nv.HoNV + ' ' + nv.TenNV as 'Họ tên', SUM((DATEDIFF(HOUR, clv.GioBatDau, clv.GioKetThuc)) * nv.LuongGio * 30) as 'Lương tháng'
FROM NHANVIEN nv 
INNER JOIN LUONGCA lc ON nv.MaNV = lc.MaNV1 OR nv.MaNV = lc.MaNV2 OR nv.MaNV = lc.MaNV3
INNER JOIN CALAMVIEC clv ON clv.MaCa = lc.MaCa
WHERE lc.Thang = @Thang AND lc.Nam = @Nam
GROUP BY nv.MaNV, nv.HoNV, nv.TenNV
)
--Ví dụ minh họa
SELECT * FROM TinhLuongNhanVien(7, 2024);
--2. Hàm tính tổng tiền hóa đơn theo tháng và năm
CREATE FUNCTION TongTienHoaDonTheoThang (@Thang INT, @Nam INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @TongTien MONEY;
	SELECT @TongTien = SUM(TongTien)
	FROM HOADON
	WHERE MONTH(Ngay) = @Thang AND YEAR(Ngay) = @Nam;
	RETURN @TongTien;
END
--Ví dụ minh họa Tính tổng tiền hóa đơn tháng 5/2023
SELECT dbo.TongTienHoaDonTheoThang(5, 2023) AS 'Tổng tiền tháng 5/2023';
--3. Hàm tính tổng doanh thu theo nhân viên
CREATE FUNCTION TinhTongDoanhThuTheoNhanVien (@MaNV VARCHAR(10) )
RETURNS MONEY
AS
BEGIN
	DECLARE @TongDoanhThu MONEY;
	SELECT @TongDoanhThu = SUM(HD.TongTien)
	FROM HOADON HD
	JOIN NHANVIEN NV ON HD.MaNV = NV.MaNV
	WHERE NV.MaNV = @MaNV;
	RETURN @TongDoanhThu;
END;
--Ví dụ minh họa
SELECT dbo.TinhTongDoanhThuTheoNhanVien('NV001') AS 'Tổng doanh thu của NV001';

-- 4. Hàm tính tổng số tiền hóa đơn nhập
CREATE FUNCTION TongTienHoaDonNhap (@MaHDN VARCHAR(10))
RETURNS MONEY
AS
BEGIN
    DECLARE @TotalMoney MONEY;
    DECLARE @Result MONEY;
    SELECT @TotalMoney = SUM(DonGia * SoLuong)
    FROM CHITIETNHAP
    WHERE MaHDN = @MaHDN;
 IF @TotalMoney IS NULL
    BEGIN
        SET @Result = 0;
    END
  ELSE
    BEGIN
        SET @Result = @TotalMoney;
    END
    RETURN @Result;
END
 --Ví dụ minh họa
 SELECT dbo.TongTienHoaDonNhap('HDN004') AS 'Tổng Tiền';
-- 5. Viết hàm hiển thị mã khách hàng, tên khách hàng và số hóa đơn của khách hàng trong năm 2024
CREATE FUNCTION KhachHang_SoHD()
RETURNS TABLE
AS
RETURN
    SELECT KH.MaKH, KH.HoKH, KH.TenKH, COUNT(HD.MaHD) AS SoHoaDon
    FROM KHACHHANG KH
    LEFT JOIN HOADON HD ON KH.MaKH = HD.MaKH
    WHERE YEAR(HD.Ngay) = 2024
    GROUP BY KH.MaKH, KH.HoKH, KH.TenKH
GO
 --Ví dụ minh họa
SELECT * FROM fn_KhachHang_SoHD();


--Trigger
--1. Trigger kiểm tra mặt hàng còn hạn sử dụng hay không
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'trg_KiemTraHSD' AND TYPE = 'TR') DROP TRIGGER trg_KiemTraHSD

CREATE TRIGGER trg_KiemTraHSD
ON MATHANG
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON
    IF EXISTS (SELECT 1 FROM inserted WHERE HSD IS NOT NULL AND HSD < GETDATE())
    BEGIN PRINT('Mặt hàng đã hết hạn sử dụng');
    ROLLBACK TRANSACTION;
    END
END
--2. Trigger Kiểm tra một món nào đó có trong Menu hay không
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'trg_KiemtraMenu' AND TYPE = 'TR') DROP TRIGGER trg_KiemtraMenu

CREATE TRIGGER trg_KiemtraMenu
ON ANUONG
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON
    IF EXISTS (SELECT 1 FROM inserted i LEFT JOIN ANUONG au ON i.MaMon = au.MaMon WHERE au.MaMon IS NULL)
    BEGIN PRINT ('Món ăn không tồn tại trong menu');
    ROLLBACK TRANSACTION;
    END
END
--3. Trigger kiểm tra số tuổi của nhân viên có hợp lệ hay không, biết số tuổi hợp lệ là từ 18 tuổi trở lên
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'trg_KiemtraTuoiNhanVien' AND TYPE = 'TR') DROP TRIGGER trg_KiemtraTuoiNhanVien

CREATE TRIGGER trg_KiemtraTuoiNhanVien
ON NHANVIEN
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM inserted WHERE DATEDIFF(YEAR, NgaySinh, GETDATE()) < 18)
    BEGIN 
		PRINT ('Số tuổi của nhân viên không hợp lệ (phải từ 18 tuổi trở lên)');
        ROLLBACK TRANSACTION
    END
END
--4. Trigger cập nhật tổng tiền của một hóa đơn nhập mỗi khi có thay đổi trong chi tiết nhập.
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'trg_CapNhatTongTien' AND TYPE = 'TR') DROP TRIGGER trg_CapNhatTongTien

CREATE TRIGGER trg_CapNhatTongTien
ON CHITIETNHAP
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MaHDN varchar(10)
    SELECT @MaHDN = MaHDN FROM inserted
    IF @MaHDN IS NULL
    BEGIN
        SELECT @MaHDN = MaHDN FROM deleted
    END
    UPDATE HOADONNHAP SET TongTien = ( SELECT SUM(ctn.DonGia * ctn.SoLuong) FROM CHITIETNHAP ctn WHERE ctn.MaHDN = @MaHDN)
    WHERE HOADONNHAP.MaHDN = @MaHDN
END
--5. Kiểm tra số lượng mặt hàng trước khi thêm vào bảng CHITIETHOADON
IF EXISTS (SELECT NAME FROM SYSOBJECTS WHERE NAME = 'trg_KiemtraSoLuongCTHD' AND TYPE = 'TR') DROP TRIGGER trg_KiemtraSoLuongCTHD

CREATE TRIGGER trg_KiemtraSoLuongCTHD
ON CHITIETHOADON
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON
    IF EXISTS (
        SELECT 1 
        FROM INSERTED i
        JOIN MATHANG mh ON i.MaMon = mh.MaMH
        WHERE i.SoLuong > mh.SoLuong
    )
    BEGIN
        PRINT ('Không đủ số lượng mặt hàng trong kho.');
        ROLLBACK TRANSACTION
    END
END

--User: ChuQuan
--Tạo login
USE master
GO
CREATE LOGIN ChuQuan
	WITH PASSWORD = N'ChuQuan123',
	CHECK_EXPIRATION = OFF,
	CHECK_POLICY = OFF
GO
--Tạo user ChuQuan trong QLcafe
USE QLcafe
GO
CREATE USER ChuQuan FOR LOGIN ChuQuan
GO
--Cấp quyền quản trị CSDL cho ChuQuan
ALTER ROLE db_owner ADD MEMBER ChuQuan

--User: QuanLi
--Tạo Login
USE master
GO
CREATE LOGIN QuanLi
	WITH PASSWORD = N'QuanLi123',
	CHECK_EXPIRATION = OFF,
	CHECK_POLICY = OFF
GO
-- Tạo user QuanLi trong QLcafe
USE QLcafe
GO
CREATE USER QuanLi FOR LOGIN QuanLi
GO

--User: NhanVien
--Tạo login
USE master
GO
CREATE LOGIN NhanVien
	WITH PASSWORD = N'NhanVien123',
	CHECK_EXPIRATION = OFF,
	CHECK_POLICY = OFF
GO
--Tạo user NhanVien trong QLcafe
USE QLcafe
GO
CREATE USER NhanVien FOR LOGIN NhanVien
GO

--Phân quyền cho bảng NHANVIEN
USE QLcafe
GO

GRANT SELECT ON NHANVIEN TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON NHANVIEN TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON NHANVIEN TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON NHANVIEN TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON NHANVIEN TO QuanLi
GO
GRANT INSERT ON NHANVIEN TO QuanLi
GO
GRANT UPDATE ON NHANVIEN TO QuanLi
GO

GRANT SELECT ON NHANVIEN TO NhanVien
GO

-- Phân quyền cho bảng CALAMVIEC
USE QLcafe
GO

GRANT SELECT ON CALAMVIEC TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON CALAMVIEC TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON CALAMVIEC TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON CALAMVIEC TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON CALAMVIEC TO QuanLi
GO
GRANT INSERT ON CALAMVIEC TO QuanLi
GO
GRANT UPDATE ON CALAMVIEC TO QuanLi
GO
GRANT DELETE ON CALAMVIEC TO QuanLi
GO

GRANT SELECT ON CALAMVIEC TO NhanVien
GO

-- Phân quyền cho bảng LUONGCA
USE QLcafe
GO

GRANT SELECT ON LUONGCA TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON LUONGCA TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON LUONGCA TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON LUONGCA TO ChuQuan WITH GRANT OPTION

GRANT SELECT ON LUONGCA TO QuanLi
GO

GRANT SELECT ON LUONGCA TO NhanVien
GO

-- Phân quyền cho bảng KHACHHANG
USE QLcafe
GO

GRANT SELECT ON KHACHHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON KHACHHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON KHACHHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON KHACHHANG TO ChuQuan WITH GRANT OPTION

GRANT SELECT ON KHACHHANG TO QuanLi
GO
GRANT INSERT ON KHACHHANG TO QuanLi
GO
GRANT UPDATE ON KHACHHANG TO QuanLi
GO
GRANT DELETE ON KHACHHANG TO QuanLi
GO

GRANT SELECT ON KHACHHANG TO NhanVien
GO
GRANT INSERT ON KHACHHANG TO NhanVien
GO
GRANT UPDATE ON KHACHHANG TO NhanVien
GO

-- Phân quyền cho bảng NHACUNGCAP
USE QLcafe
GO

GRANT SELECT ON NHACUNGCAP TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON NHACUNGCAP TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON NHACUNGCAP TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON NHACUNGCAP TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON NHACUNGCAP TO QuanLi
GO

GRANT SELECT ON NHACUNGCAP TO NhanVien
GO

-- Phân quyền cho bảng LOAIMATHANG
USE QLcafe
GO

GRANT SELECT ON LOAIMATHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON LOAIMATHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON LOAIMATHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON LOAIMATHANG TO ChuQuan WITH GRANT OPTION
GO 

GRANT SELECT ON LOAIMATHANG TO QuanLi
GO

GRANT SELECT ON LOAIMATHANG TO NhanVien
GO

-- Phân quyền cho bảng MATHANG
USE QLcafe
GO

GRANT SELECT ON MATHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON MATHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON MATHANG TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON MATHANG TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON MATHANG TO QuanLi
GO

GRANT SELECT ON MATHANG TO NhanVien
GO

-- Phân quyền cho bảng ANUONG
USE QLcafe
GO

GRANT SELECT ON ANUONG TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON ANUONG TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON ANUONG TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON ANUONG TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON ANUONG TO QuanLi
GO

GRANT SELECT ON ANUONG TO NhanVien
GO

-- Phân quyền cho bảng HOADONNHAP
USE QLcafe
GO

GRANT SELECT ON HOADONNHAP TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON HOADONNHAP TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON HOADONNHAP TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON HOADONNHAP TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON HOADONNHAP TO QuanLi
GO
GRANT INSERT ON HOADONNHAP TO QuanLi
GO
GRANT UPDATE ON HOADONNHAP TO QuanLi
GO
GRANT DELETE ON HOADONNHAP TO QuanLi
GO

GRANT SELECT ON HOADONNHAP TO NhanVien
GO

-- Phân quyền cho bảng CHITIETNHAP
USE QLcafe
GO

GRANT SELECT ON CHITIETNHAP TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON CHITIETNHAP TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON CHITIETNHAP TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON CHITIETNHAP TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON CHITIETNHAP TO QuanLi
GO
GRANT INSERT ON CHITIETNHAP TO QuanLi
GO
GRANT UPDATE ON CHITIETNHAP TO QuanLi
GO
GRANT DELETE ON CHITIETNHAP TO QuanLi
GO

GRANT SELECT ON CHITIETNHAP TO NhanVien
GO

-- Phân quyền cho bảng HOADON
USE QLcafe
GO

GRANT SELECT ON HOADON TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON HOADON TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON HOADON TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON HOADON TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON HOADON TO QuanLi
GO
GRANT INSERT ON HOADON TO QuanLi
GO
GRANT UPDATE ON HOADON TO QuanLi
GO

GRANT SELECT ON HOADON TO NhanVien
GO
GRANT INSERT ON HOADON TO NhanVien
GO
GRANT UPDATE ON HOADON TO NhanVien
GO

-- Phân quyền cho bảng CHITIETHOADON
USE QLcafe
GO

GRANT SELECT ON CHITIETHOADON TO ChuQuan WITH GRANT OPTION
GO
GRANT INSERT ON CHITIETHOADON TO ChuQuan WITH GRANT OPTION
GO
GRANT UPDATE ON CHITIETHOADON TO ChuQuan WITH GRANT OPTION
GO
GRANT DELETE ON CHITIETHOADON TO ChuQuan WITH GRANT OPTION
GO

GRANT SELECT ON CHITIETHOADON TO QuanLi
GO
GRANT INSERT ON CHITIETHOADON TO QuanLi
GO
GRANT UPDATE ON CHITIETHOADON TO QuanLi
GO

GRANT SELECT ON CHITIETHOADON TO NhanVien
GO
GRANT INSERT ON CHITIETHOADON TO NhanVien
GO
GRANT UPDATE ON CHITIETHOADON TO NhanVien
GO
