
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
VALUES ('TG001', 'Nguyễn Nhật Ánh', '1980-01-01', '2022-05-01', 'Hà Nội'),
       ('TG002', 'Trác Phong', '1985-06-15', NULL, 'Hà Nội'),
       ('TG003', 'Nguyễn Du', '1765-11-05', '1820-07-16', 'Thái Bình'),
       ('TG004', 'Hồ Biểu Chánh', '1906-02-09', '1937-11-26', 'Hà Nội'),
       ('TG005', 'Hồ Xuân Hương', '1772-01-01', '1822-03-22', 'Thăng Long'),
       ('TG006', 'Tô Hoài', '1920-08-04', '2014-02-06', 'Nam Định'),
       ('TG007', 'Nam Cao', '1915-07-16', '1951-12-19', 'Nam Định'),
       ('TG008', 'Ngô Tất Tố', '1932-07-20', '2007-11-05', 'Thái Bình'),
       ('TG009', 'Vũ Trọng Phụng', '1912-10-01', '1939-10-07', 'Hà Nội'),
       ('TG010', 'Nguyễn Huy Tưởng', '1912-01-01', '1985-01-01', 'Hải Dương'),
       ('TG011', 'Nguyễn Quang Sáng', '1912-03-19', '1942-01-01', 'Nam Định'),
       ('TG012', 'Trần Đăng Khoa', '1918-01-01', '1995-01-01', 'Nam Định'),
       ('TG013', 'Bảo Ninh', '1952-10-18', NULL, 'Thái Nguyên'),
       ('TG014', 'Nguyễn Ngọc Tư', '1961-05-01', NULL, 'Hà Nội'),
       ('TG015', 'Bùi Anh Tuấn', '1973-01-01', NULL, 'Hà Nội');
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
VALUES ('Văn học'),
       ('Khoa học'),
       ('Lịch sử'),
       ('Tâm lý'),
       ('Toán học'),
       ('Thể thao'),
       ('Âm nhạc'),
       ('Du lịch'),
       ('Nấu ăn'),
       ('Kinh doanh'),
       ('Nghệ thuật'),
       ('Thiên văn'),
       ('Địa lý'),
       ('Huyền học'),
       ('Lập trình');
-- Chèn dữ liệu vào bảng LOAISACH
INSERT INTO LOAISACH (TENLOAISACH)
VALUES ('Tiểu thuyết'),
       ('Kỹ thuật'),
       ('Lịch sử'),
       ('Tâm lý học'),
       ('Toán học'),
       ('Hướng dẫn'),
       ('Âm nhạc'),
       ('Du lịch'),
       ('Nấu ăn'),
       ('Kinh doanh'),
       ('Nghệ thuật'),
       ('Thiên văn'),
       ('Địa lý'),
       ('Huyền học'),
       ('Lập trình');
-- Chèn dữ liệu vào bảng NHAXUATBAN
INSERT INTO NHAXUATBAN (TENNHAXUATBAN)
VALUES ('Nhà xuất bản ABC'),
       ('Nhà xuất bản XYZ'),
       ('Nhà xuất bản XYZABC'),
       ('Nhà xuất bản XYZ123'),
       ('Nhà xuất bản QRS'),
       ('Nhà xuất bản XYZQRS'),
       ('Nhà xuất bản MNO'),
       ('Nhà xuất bản MNOXYZ'),
       ('Nhà xuất bản NOP'),
       ('Nhà xuất bản LMN'),
       ('Nhà xuất bản LMNXYZ'),
       ('Nhà xuất bản JKL'),
       ('Nhà xuất bản JKLXYZ'),
       ('Nhà xuất bản GHI'),
       ('Nhà xuất bản GHIXYZ');
INSERT INTO SACH (MASACH, TENSACH, MATG, TENLINHVUC, TENLOAISACH, GIAMUA, GIABIA, LANTAIBAN, TENNHAXUATBAN)
VALUES ('S001', 'Tiếng gọi từ biển cả', 'TG001', 'Văn học', 'Tiểu thuyết', 150000, 200000, 10, 'Nhà xuất bản ABC'),
       ('S002', 'Bí mật của lão Hạc', 'TG002', 'Văn học', 'Tiểu thuyết', 160000, 210000, 8, 'Nhà xuất bản XYZ'),
       ('S003', 'Truyện Kiều', 'TG003', 'Văn học', 'Tiểu thuyết', 100000, 150000, 15, 'Nhà xuất bản XYZABC'),
       ('S004', 'Số đỏ', 'TG004', 'Văn học', 'Tiểu thuyết', 120000, 170000, 12, 'Nhà xuất bản XYZ123'),
       ('S005', 'Cô gái đến từ hôm qua', 'TG005', 'Văn học', 'Tiểu thuyết', 130000, 180000, 14, 'Nhà xuất bản QRS'),
       ('S006', 'Hồi ký của một geisha', 'TG006', 'Văn học', 'Tiểu thuyết', 140000, 190000, 16, 'Nhà xuất bản XYZQRS'),
       ('S007', 'Nghìn lẻ một đêm', 'TG007', 'Văn học', 'Tiểu thuyết', 110000, 160000, 11, 'Nhà xuất bản MNO'),
       ('S008', 'Nhà giả kim', 'TG008', 'Văn học', 'Tiểu thuyết', 125000, 175000, 13, 'Nhà xuất bản MNOXYZ'),
       ('S009', 'Lão Hạc', 'TG009', 'Văn học', 'Tiểu thuyết', 115000, 165000, 17, 'Nhà xuất bản NOP'),
       ('S010', 'Những người khốn khổ', 'TG010', 'Văn học', 'Tiểu thuyết', 105000, 155000, 9, 'Nhà xuất bản LMN'),
       ('S011', 'Nhật ký trong tù', 'TG011', 'Văn học', 'Tiểu thuyết', 135000, 185000, 18, 'Nhà xuất bản LMNXYZ'),
       ('S012', 'Chí Phèo', 'TG012', 'Văn học', 'Tiểu thuyết', 145000, 195000, 19, 'Nhà xuất bản JKL'),
       ('S013', 'Vợ nhặt', 'TG013', 'Văn học', 'Tiểu thuyết', 155000, 205000, 20, 'Nhà xuất bản JKLXYZ'),
       ('S014', 'Chuyện cổ tích dành cho người lớn', 'TG014', 'Văn học', 'Tiểu thuyết', 165000, 215000, 21, 'Nhà xuất bản GHI'),
       ('S015', 'Bình Ngô đại cáo', 'TG015', 'Văn học', 'Tiểu thuyết', 175000, 225000, 22, 'Nhà xuất bản GHIXYZ');
	   -- Chèn dữ liệu vào bảng HOADON
INSERT INTO HOADON (MAHOADON, TENKHACHHANG, TONGTIEN)
VALUES ('HD001', 'Nguyễn Văn A', 500000),
       ('HD002', 'Nguyễn Thị B', 600000),
       ('HD003', 'Trần Văn C', 700000),
       ('HD004', 'Lê Thị D', 800000),
       ('HD005', 'Phạm Văn E', 900000),
       ('HD006', 'Hoàng Thị F', 1000000),
       ('HD007', 'Trần Văn G', 1100000),
       ('HD008', 'Nguyễn Thị H', 1200000),
       ('HD009', 'Lê Văn I', 1300000),
       ('HD010', 'Hoàng Văn K', 1400000),
       ('HD011', 'Trần Thị L', 1500000),
       ('HD012', 'Nguyễn Văn M', 1600000),
       ('HD013', 'Lê Thị N', 1700000),
       ('HD014', 'Phạm Văn O', 1800000),
       ('HD015', 'Trần Thị P', 1900000);

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