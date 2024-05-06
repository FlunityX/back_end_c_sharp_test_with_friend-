
-- Tạo bảng TAIKHOAN
CREATE TABLE TAIKHOAN
(
    USERNAME NVARCHAR(20) PRIMARY KEY NOT NULL,
    PASS_WORD NVARCHAR(100) NOT NULL
);

-- Tạo bảng TACGIA
CREATE TABLE TACGIA
(
    MATG CHAR(7) PRIMARY KEY NOT NULL,
    TENTG NVARCHAR(40) NOT NULL,
    NAMSINH DATE,
    NAMMAT DATE,
    QUEQUAN NVARCHAR(20)
);

-- Tạo bảng LINHVUC
CREATE TABLE LINHVUC
(
    TENLINHVUC NVARCHAR(30) PRIMARY KEY NOT NULL
);

-- Tạo bảng LOAISACH
CREATE TABLE LOAISACH
(
    TENLOAISACH NVARCHAR(30) PRIMARY KEY NOT NULL
);

-- Tạo bảng NHAXUATBAN
CREATE TABLE NHAXUATBAN
(
    TENNHAXUATBAN NVARCHAR(50) PRIMARY KEY NOT NULL
);

-- Tạo bảng SACH
CREATE TABLE SACH
(
    MASACH CHAR(7) PRIMARY KEY NOT NULL,
    TENSACH NVARCHAR(100) NOT NULL,
    MATG CHAR(7) NOT NULL,
    TENLINHVUC NVARCHAR(30) NOT NULL,
    TENLOAISACH NVARCHAR(30) NOT NULL,
    GIAMUA INT CHECK (GIAMUA >= 0),
    GIABIA INT CHECK (GIABIA >= 0),
    LANTAIBAN INT CHECK (LANTAIBAN >= 0),
    TENNHAXUATBAN NVARCHAR(50) NOT NULL,
    
    FOREIGN KEY (MATG) REFERENCES TACGIA(MATG),
    FOREIGN KEY (TENLINHVUC) REFERENCES LINHVUC(TENLINHVUC),
    FOREIGN KEY (TENLOAISACH) REFERENCES LOAISACH(TENLOAISACH),
    FOREIGN KEY (TENNHAXUATBAN) REFERENCES NHAXUATBAN(TENNHAXUATBAN)
);


-- Tạo bảng HOADON
CREATE TABLE HOADON
(
    MAHOADON CHAR(7) PRIMARY KEY NOT NULL,
    TENKHACHHANG NVARCHAR(50) NOT NULL,
    NGAYLAP DATETIME DEFAULT GETDATE(),
    TONGTIEN DECIMAL(10, 2) CHECK (TONGTIEN >= 0)
);

-- Tạo bảng CHITIETHOADON
CREATE TABLE CHITIETHOADON
(
    MAHOADON CHAR(7) NOT NULL,
    MASACH CHAR(7) NOT NULL,
    SOLUONG INT CHECK (SOLUONG >= 1),
    GIATIEN INT CHECK (GIATIEN >= 0),
    THANHTIEN INT CHECK (THANHTIEN >= 0),
    PRIMARY KEY (MAHOADON, MASACH),
    FOREIGN KEY (MAHOADON) REFERENCES HOADON(MAHOADON),
    FOREIGN KEY (MASACH) REFERENCES SACH(MASACH)
);
-- Chèn dữ liệu vào bảng TACGIA
INSERT INTO TACGIA (MATG, TENTG, NAMSINH, NAMMAT, QUEQUAN)
VALUES ('TG001', N'Nguyễn Nhật Ánh', '1980-01-01', '2022-05-01', N'Hà Nội'),
       ('TG002', N'Trác Phong', '1985-06-15', NULL, N'Hà Nội'),
       ('TG003', N'Nguyễn Du', '1765-11-05', '1820-07-16', N'Thái Bình'),
       ('TG004', N'Hồ Biểu Chánh', '1906-02-09', '1937-11-26', N'Hà Nội'),
       ('TG005', N'Hồ Xuân Hương', '1772-01-01', '1822-03-22', N'Thăng Long'),
       ('TG006', N'Tô Hoài', '1920-08-04', '2014-02-06', N'Nam Định'),
       ('TG007', N'Nam Cao', '1915-07-16', '1951-12-19', N'Nam Định'),
       ('TG008', N'Ngô Tất Tố', '1932-07-20', '2007-11-05', N'Thái Bình'),
       ('TG009', N'Vũ Trọng Phụng', '1912-10-01', '1939-10-07', N'Hà Nội'),
       ('TG010', N'Nguyễn Huy Tưởng', '1912-01-01', '1985-01-01', N'Hải Dương'),
       ('TG011', N'Nguyễn Quang Sáng', '1912-03-19', '1942-01-01', N'Nam Định'),
       ('TG012', N'Trần Đăng Khoa', '1918-01-01', '1995-01-01', N'Nam Định'),
       ('TG013', N'Bảo Ninh', '1952-10-18', NULL, N'Thái Nguyên'),
       ('TG014', N'Nguyễn Ngọc Tư', '1961-05-01', NULL, N'Hà Nội'),
       ('TG015', N'Bùi Anh Tuấn', '1973-01-01', NULL, N'Hà Nội');
-- Chèn dữ liệu vào bảng TAIKHOAN
INSERT INTO TAIKHOAN (USERNAME, PASS_WORD)
VALUES ('johnsmith', 'password123'),
       ('marydoe', 'abc123'),
       ('johndoe', 'doe456'),
       ('janedoe', 'janedoe789'),
       ('smithjohn', 'johnsmith123'),
       ('admin', 'adminpass'),
       ('user1', 'userpass1'),
       ('user2', 'userpass2'),
       ('user3', 'userpass3'),
       ('user4', 'userpass4'),
       ('user5', 'userpass5'),
       ('user6', 'userpass6'),
       ('user7', 'userpass7'),
       ('user8', 'userpass8'),
       ('user9', 'userpass9');
INSERT INTO LINHVUC (TENLINHVUC)
VALUES (N'Văn học'),
       (N'Khoa học'),
       (N'Lịch sử'),
       (N'Tâm lý'),
       (N'Toán học'),
       (N'Thể thao'),
       (N'Âm nhạc'),
       (N'Du lịch'),
       (N'Nấu ăn'),
       (N'Kinh doanh'),
       (N'Nghệ thuật'),
       (N'Thiên văn'),
       (N'Địa lý'),
       (N'Huyền học'),
       (N'Lập trình');
-- Chèn dữ liệu vào bảng LOAISACH
INSERT INTO LOAISACH (TENLOAISACH)
VALUES (N'Tiểu thuyết'),
       (N'Kỹ thuật'),
       (N'Lịch sử'),
       (N'Tâm lý học'),
       (N'Toán học'),
       (N'Hướng dẫn'),
       (N'Âm nhạc'),
       (N'Du lịch'),
       (N'Nấu ăn'),
       (N'Kinh doanh'),
       (N'Nghệ thuật'),
       (N'Thiên văn'),
       (N'Địa lý'),
       (N'Huyền học'),
       (N'Lập trình');
-- Chèn dữ liệu vào bảng NHAXUATBAN
INSERT INTO NHAXUATBAN (TENNHAXUATBAN)
VALUES (N'Nhà xuất bản ABC'),
       (N'Nhà xuất bản XYZ'),
       (N'Nhà xuất bản XYZABC'),
       (N'Nhà xuất bản XYZ123'),
       (N'Nhà xuất bản QRS'),
       (N'Nhà xuất bản XYZQRS'),
       (N'Nhà xuất bản MNO'),
       (N'Nhà xuất bản MNOXYZ'),
       (N'Nhà xuất bản NOP'),
       (N'Nhà xuất bản LMN'),
       (N'Nhà xuất bản LMNXYZ'),
       (N'Nhà xuất bản JKL'),
       (N'Nhà xuất bản JKLXYZ'),
       (N'Nhà xuất bản GHI'),
       (N'Nhà xuất bản GHIXYZ');
INSERT INTO SACH (MASACH, TENSACH, MATG, TENLINHVUC, TENLOAISACH, GIAMUA, GIABIA, LANTAIBAN, TENNHAXUATBAN)
VALUES ('S001', N'Tiếng gọi từ biển cả', 'TG001', N'Văn học', N'Tiểu thuyết', 150000, 200000, 10, N'Nhà xuất bản ABC'),
       ('S002', N'Bí mật của lão Hạc', 'TG002', N'Văn học', N'Tiểu thuyết', 160000, 210000, 8, N'Nhà xuất bản XYZ'),
       ('S003', N'Truyện Kiều', 'TG003', N'Văn học', N'Tiểu thuyết', 100000, 150000, 15, N'Nhà xuất bản XYZABC'),
       ('S004', N'Số đỏ', 'TG004', N'Văn học', N'Tiểu thuyết', 120000, 170000, 12, N'Nhà xuất bản XYZ123'),
       ('S005', N'Cô gái đến từ hôm qua', 'TG005', N'Văn học', N'Tiểu thuyết', 130000, 180000, 14, N'Nhà xuất bản QRS'),
       ('S006', N'Hồi ký của một geisha', 'TG006', N'Văn học', N'Tiểu thuyết', 140000, 190000, 16, N'Nhà xuất bản XYZQRS'),
       ('S007', N'Nghìn lẻ một đêm', 'TG007', N'Văn học', N'Tiểu thuyết', 110000, 160000, 11, N'Nhà xuất bản MNO'),
       ('S008', N'Nhà giả kim', 'TG008', N'Văn học', N'Tiểu thuyết', 125000, 175000, 13, N'Nhà xuất bản MNOXYZ'),
       ('S009', N'Lão Hạc', 'TG009', N'Văn học', N'Tiểu thuyết', 115000, 165000, 17, N'Nhà xuất bản NOP'),
       ('S010', N'Những người khốn khổ', 'TG010', N'Văn học', N'Tiểu thuyết', 105000, 155000, 9, N'Nhà xuất bản LMN'),
       ('S011', N'Nhật ký trong tù', 'TG011', N'Văn học', N'Tiểu thuyết', 135000, 185000, 18, N'Nhà xuất bản LMNXYZ'),
       ('S012', N'Chí Phèo', 'TG012', N'Văn học', N'Tiểu thuyết', 145000, 195000, 19, N'Nhà xuất bản JKL'),
       ('S013', N'Vợ nhặt', 'TG013', N'Văn học', N'Tiểu thuyết', 155000, 205000, 20, N'Nhà xuất bản JKLXYZ'),
       ('S014', N'Chuyện cổ tích dành cho người lớn', 'TG014', N'Văn học', N'Tiểu thuyết', 165000, 215000, 21, N'Nhà xuất bản GHI'),
       ('S015', N'Bình Ngô đại cáo', 'TG015', N'Văn học', N'Tiểu thuyết', 175000, 225000, 22, N'Nhà xuất bản GHIXYZ');
	   -- Chèn dữ liệu vào bảng HOADON
INSERT INTO HOADON (MAHOADON, TENKHACHHANG, TONGTIEN)
VALUES ('HD001', N'Nguyễn Văn A', 500000),
       ('HD002', N'Nguyễn Thị B', 600000),
       ('HD003', N'Trần Văn C', 700000),
       ('HD004', N'Lê Thị D', 800000),
       ('HD005', N'Phạm Văn E', 900000),
       ('HD006', N'Hoàng Thị F', 1000000),
       ('HD007', N'Trần Văn G', 1100000),
       ('HD008', N'Nguyễn Thị H', 1200000),
       ('HD009', N'Lê Văn I', 1300000),
       ('HD010', N'Hoàng Văn K', 1400000),
       ('HD011', N'Trần Thị L', 1500000),
       ('HD012', N'Nguyễn Văn M', 1600000),
       ('HD013', N'Lê Thị N', 1700000),
       ('HD014', N'Phạm Văn O', 1800000),
       ('HD015', N'Trần Thị P', 1900000);

INSERT INTO CHITIETHOADON (MAHOADON, MASACH, SOLUONG, GIATIEN, THANHTIEN)
VALUES ('HD001', 'S001', 2, 200000, 400000),
       ('HD002', 'S002', 3, 250000, 750000),
       ('HD003', 'S003', 4, 300000, 1200000),
       ('HD004', 'S004', 5, 350000, 1750000),
       ('HD005', 'S005', 6, 400000, 2400000),
       ('HD006', 'S006', 7, 450000, 3150000),
       ('HD007', 'S007', 8, 500000, 4000000),
       ('HD008', 'S008', 9, 550000, 4950000),
       ('HD009', 'S009', 10, 600000, 6000000),
       ('HD010', 'S010', 11, 650000, 7150000),
       ('HD011', 'S011', 12, 700000, 8400000),
       ('HD012', 'S012', 13, 750000, 9750000),
       ('HD013', 'S013', 14, 800000, 11200000),
       ('HD014', 'S014', 15, 850000, 12750000),
       ('HD015', 'S015', 16, 900000, 14400000);
	   select * from LOAISACH