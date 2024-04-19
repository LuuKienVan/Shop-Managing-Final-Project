use master
go

if exists (select * from sysdatabases where name = 'QuanLy711')
	drop database QuanLy711
go

CREATE DATABASE QuanLy711
GO


USE QuanLy711
GO

CREATE TABLE NHANVIEN
(
  maNV VARCHAR(50) NOT NULL,
  tenNV NVARCHAR(50) NOT NULL,
  matKhau VARCHAR(50) NOT NULL,
  diaChi NVARCHAR(50) NOT NULL,
  sdtNV VARCHAR(20) NOT NULL,
  chucVu NVARCHAR(50) NOT NULL DEFAULT N'Nhân viên', -- Nhân viên || Quản lý
  PRIMARY KEY (maNV)
)
GO

CREATE TABLE KHACHHANG
(
  maKH VARCHAR(50) NOT NULL, 
  tenKH NVARCHAR(50) NOT NULL,
  sdtKH VARCHAR(20) NOT NULL,
  diemTichLuy INT NOT NULL,
  PRIMARY KEY (maKH) 
)
GO

CREATE TABLE NHACUNGCAP
(
  maNCC VARCHAR(50) NOT NULL, 
  tenNCC NVARCHAR(50) NOT NULL,
  sdtNCC VARCHAR(20) NOT NULL,
  diachiNCC NVARCHAR(50) NOT NULL,
  ratingNCC INT NOT NULL,
  cacSPCungCap NVARCHAR(50) NOT NULL,
  PRIMARY KEY (maNCC)
)

GO

CREATE TABLE SANPHAM
(
  maSP VARCHAR(50) NOT NULL,
  tenSP NVARCHAR(50) NOT NULL,
  soLuong INT NOT NULL,
  loai NVARCHAR(50) NOT NULL,
  hsd DATE NOT NULL,
  giaBan INT NOT NULL,
  giaNhap INT NOT NULL,
  maNCC VARCHAR(50) NOT NULL,
  PRIMARY KEY (maSP),
  FOREIGN KEY (maNCC) REFERENCES NHACUNGCAP(maNCC)
)

GO

CREATE TABLE HOADON
(
  maHD VARCHAR(50) NOT NULL,
  tongTien INT NOT NULL,
  tienKhachDua INT NOT NULL,
  tienThoi INT NOT NULL,
  ngayLapHD DATE NOT NULL DEFAULT GETDATE(),
  maKH VARCHAR(50) DEFAULT N'',
  maNV VARCHAR(50) NOT NULL,
  PRIMARY KEY (maHD),
  --FOREIGN KEY (maKH) REFERENCES KHACHHANG(maKH),
  FOREIGN KEY (maNV) REFERENCES NHANVIEN(maNV)
)

CREATE TABLE CHITIETHD
(
  maHD VARCHAR(50) NOT NULL,
  maSP VARCHAR(50) NOT NULL,
  soLuong INT NOT NULL,
  PRIMARY KEY (maHD,maSP),
  FOREIGN KEY (maHD) REFERENCES HOADON(maHD),
  FOREIGN KEY (maSP) REFERENCES SANPHAM(maSP)
)

GO

CREATE TABLE GIAMGIA
(
  maGiamGia VARCHAR(50) NOT NULL, 
  phamTram INT NOT NULL,
  ngayBatDau DATE NOT NULL,
  ngayKetThuc DATE NOT NULL,
  maSP VARCHAR(50) NOT NULL,
  PRIMARY KEY (maGiamGia),
  FOREIGN KEY (maSP) REFERENCES SANPHAM(maSP)
)
GO



insert into NHANVIEN values('tien123', N'Tiến', 'tien123', N'An Giang', '0961944816', N'Quản lý')
insert into NHANVIEN values('kiet123', N'Kiệt', 'kiet123', N'Tp Hồ Chí Minh', '0961944817', N'Nhân viên')
insert into NHANVIEN values('hung123', N'Hùng', 'hung123', N'Long An', '0961944818', N'Nhân viên')
insert into NHANVIEN values('linh123', N'Linh', 'linh123', N'Tp Hồ Chí Minh', '0961944819', N'Nhân viên')
insert into NHANVIEN values('phuong123', N'Phương', 'phuong123', N'Tiền Giang', '0961944826', N'Nhân viên')

insert into KHACHHANG values('KH001', N'An', '0123456789', 10)
insert into KHACHHANG values('KH002', N'Bảo', '0223456789', 30)
insert into KHACHHANG values('KH003', N'Hương', '0323456789', 50)
insert into KHACHHANG values('KH004', N'Thảo', '0423456789', 20)
insert into KHACHHANG values('KH005', N'Dũng', '0523456789', 5)
insert into KHACHHANG values('KH006', N'Anh', '0123456711', 10)
insert into KHACHHANG values('KH007', N'Ánh', '0223456722', 30)
insert into KHACHHANG values('KH008', N'Dương', '0323456733', 50)
insert into KHACHHANG values('KH009', N'Hùng', '0423456744', 20)
insert into KHACHHANG values('KH010', N'Trang', '0523456755', 5)
insert into KHACHHANG values('KH011', N'Yến', '0123456766', 10)
insert into KHACHHANG values('KH012', N'Nhân', '0223456777', 30)
insert into KHACHHANG values('KH013', N'Kiệt', '0323456788', 50)

insert into NHACUNGCAP values('NCC001', N'Coca', '0987654321', N'Long An', 5, N'Nước ngọt')
insert into NHACUNGCAP values('NCC002', N'Pepsi', '0987654312', N'Long An', 5, N'Nước ngọt')
insert into NHACUNGCAP values('NCC003', N'Chocopie', '0987653421', N'Long An', 5, N'Bánh')
insert into NHACUNGCAP values('NCC004', N'Hảo Hảo', '0987653521', N'Tp Hồ Chí Minh', 4, N'Mì')
insert into NHACUNGCAP values('NCC005', N'Marino', '0987653621', N'Tp Hồ Chí Minh', 5, N'Kem')
insert into NHACUNGCAP values('NCC006', N'FoodDeli', '0125478963', N'Bình Dương', 4, N'Trái cây')
insert into NHACUNGCAP values('NCC007', N'Letri', '0125478745', N'Bình Dương', 4, N'Đồ hộp')
insert into NHACUNGCAP values('NCC008', N'Vinamilk', '0123656569', N'Tây Ninh', 3, N'Sữa')
insert into NHACUNGCAP values('NCC009', N'Việt Tiến', '0125485236', N'Tp Hồ Chí Minh', 4, N'Đồ dùng học tập')
insert into NHACUNGCAP values('NCC010', N'CareB', '0124745123', N'Tp Hồ Chí Minh', 5, N'Đồ dùng cá nhân')
insert into NHACUNGCAP values('NCC011', N'Fami', '0125478587', N'Đồng Nai', 5, N'Sữa')
insert into NHACUNGCAP values('NCC012', N'Ô Vinh', '0125636963', N'Bình Dương', 4, N'Trà')
insert into NHACUNGCAP values('NCC013', N'Threen', '0124785412', N'Tp Hồ Chí Minh', 4, N'Cà phê')
insert into NHACUNGCAP values('NCC014', N'Abe', '0112365896', N'Tây Ninh', 5, N'Bánh mì')
insert into NHACUNGCAP values('NCC015', N'Omachi', '0225365874', N'Tp Hồ Chí Minh', 4, N'Mì')
insert into NHACUNGCAP values('NCC016', N'Osi', '0336254147', N'Tiền Giang', 4, N'Bánh')
insert into NHACUNGCAP values('NCC017', N'New Garden', '0448759632', N'Bình Dương', 5, N'Trái cây')
insert into NHACUNGCAP values('NCC018', N'Thanh Long', '0557841236', N'Tp Hồ Chí Minh', 5, N'Đồ dùng học tập')
insert into NHACUNGCAP values('NCC019', N'Sago', '066985632', N'Tp Hồ Chí Minh', 3, N'Đồ dùng cá nhân')
insert into NHACUNGCAP values('NCC020', N'Sanji', '01258746932', N'Đồng Nai', 4, N'Gia vị')

set dateformat DMY
insert into SANPHAM values('SP001', N'Nước Coca', 10, N'Nước uống', '10/10/2023', 10000, 8000, 'NCC001')
insert into SANPHAM values('SP002', N'Nước Pepsi', 10, N'Nước uống', '10/10/2023', 10000, 8000, 'NCC002')
insert into SANPHAM values('SP003', N'Bánh Chocopie', 10, N'Thức ăn', '10/10/2023', 6000, 3000, 'NCC003')
insert into SANPHAM values('SP004', N'Mì Hảo Hảo', 20, N'Thức ăn', '12/11/2023', 8000, 5000, 'NCC004')
insert into SANPHAM values('SP005', N'Kem Marino', 20, N'Thức ăn', '21/12/2022', 13000, 10000, 'NCC005')
insert into SANPHAM values('SP006', N'Trái chuối', 30, N'Thức ăn', '24/12/2022', 7000, 5000, 'NCC006')
insert into SANPHAM values('SP007', N'Cá hộp', 25, N'Thức ăn', '11/08/2023', 15000, 12000, 'NCC007')
insert into SANPHAM values('SP008', N'Sữa có đường', 50, N'Nước uống', '27/09/2023', 8000, 6000, 'NCC008')
insert into SANPHAM values('SP009', N'Bút bi', 100, N'Đồ dùng', '30/06/2024', 5000, 6000, 'NCC009')
insert into SANPHAM values('SP010', N'Bàn chải', 10, N'Đồ dùng', '13/03/2024', 20000, 15000, 'NCC010')
insert into SANPHAM values('SP011', N'Vở', 30, N'Đồ dùng', '30/06/2024', 10000, 7000, 'NCC009')
insert into SANPHAM values('SP012', N'Sữa không đường', 50, N'Nước uống', '27/09/2023', 7500, 5500, 'NCC008')
insert into SANPHAM values('SP013', N'Bò hộp', 15, N'Thức ăn', '11/08/2023', 15000, 12000, 'NCC007')
insert into SANPHAM values('SP014', N'Táo', 20, N'Thức ăn', '24/12/2022', 8000, 6000, 'NCC006')
insert into SANPHAM values('SP015', N'Kem chocolate', 10, N'Thức ăn', '23/12/2023', 13000, 10000, 'NCC005')
insert into SANPHAM values('SP016', N'Mì trộn Hảo Hảo', 20, N'Thức ăn', '12/11/2023', 8000, 5000, 'NCC004')
insert into SANPHAM values('SP017', N'Bánh quy', 25, N'Thức ăn', '10/10/2023', 6000, 3000, 'NCC003')
insert into SANPHAM values('SP018', N'Pepsi Zero', 10, N'Nước uống', '10/10/2023', 10000, 8000, 'NCC002')
insert into SANPHAM values('SP019', N'Coca Zero', 10, N'Nước uống', '10/10/2023', 10000, 8000, 'NCC001')
insert into SANPHAM values('SP020', N'Khẩu trang', 5, N'Đồ dùng', '02/07/2024', 25000, 20000, 'NCC010')
insert into SANPHAM values('SP021', N'Fami Canxi', 10, N'Nước uống', '18/06/2023', 10000, 8000, 'NCC011')
insert into SANPHAM values('SP022', N'Fami không đường', 15, N'Nước uống', '18/06/2023', 10000, 8000, 'NCC011')
insert into SANPHAM values('SP023', N'Trà đào', 20, N'Nước uống', '24/12/2022', 20000, 17000, 'NCC012')
insert into SANPHAM values('SP024', N'Trà vải', 25, N'Nước uống', '24/12/2022', 20000, 17000, 'NCC012')
insert into SANPHAM values('SP025', N'Cà phê sữa', 20, N'Nước uống', '20/12/2022', 25000, 20000, 'NCC013')
insert into SANPHAM values('SP026', N'Bạc xỉu', 15, N'Nước uống', '20/12/2022', 25000, 20000, 'NCC013')
insert into SANPHAM values('SP027', N'Bánh mì trứng', 10, N'Thức ăn', '23/12/2022', 15000, 12000, 'NCC014')
insert into SANPHAM values('SP028', N'Bánh mì thịt', 30, N'Thức ăn', '23/12/2022', 15000, 12000, 'NCC014')
insert into SANPHAM values('SP029', N'Bánh mì chả', 30, N'Thức ăn', '23/12/2022', 15000, 12000, 'NCC014')
insert into SANPHAM values('SP030', N'Mì gói Omachi', 35, N'Thức ăn', '02/01/2024', 5000, 2000, 'NCC015')
insert into SANPHAM values('SP031', N'Mì ly Omachi', 25, N'Thức ăn', '02/01/2024', 10000, 6000, 'NCC015')
insert into SANPHAM values('SP032', N'Bánh Osi cay', 20, N'Thức ăn', '22/02/2024', 25000, 20000, 'NCC016')
insert into SANPHAM values('SP033', N'Bánh Osi mặn', 15, N'Thức ăn', '22/02/2024', 25000, 20000, 'NCC016')
insert into SANPHAM values('SP034', N'Ổi', 15, N'Thức ăn', '25/12/2022', 8000, 6000, 'NCC017')
insert into SANPHAM values('SP035', N'Cam', 25, N'Thức ăn', '25/12/2022', 9000, 7000, 'NCC017')
insert into SANPHAM values('SP036', N'Xoài', 25, N'Thức ăn', '25/12/2022', 9000, 7000, 'NCC017')
insert into SANPHAM values('SP037', N'Thước kẻ', 35, N'Đồ dùng', '02/07/2025', 15000, 10000, 'NCC018')
insert into SANPHAM values('SP038', N'Sổ tay', 20, N'Đồ dùng', '02/07/2025', 25000, 20000, 'NCC018')
insert into SANPHAM values('SP039', N'Kem đánh răng', 40, N'Đồ dùng', '04/10/2023', 30000, 25000, 'NCC019')
insert into SANPHAM values('SP040', N'Dầu gội', 10, N'Đồ dùng', '04/10/2023', 40000, 37000, 'NCC019')
insert into SANPHAM values('SP041', N'Đường trắng', 25, N'Nguyên liệu', '06/08/2023', 15000, 10000, 'NCC020')
insert into SANPHAM values('SP042', N'Dầu ăn', 5, N'Nguyên liệu', '05/09/2023', 25000, 20000, 'NCC020')
insert into SANPHAM values('SP043', N'Bánh Snack', 15, N'Thức ăn', '21/12/2022', 15000, 10000, 'NCC020')


set dateformat DMY
--2021
insert into HOADON values('HD001', 40000, 40000, 0, '10/1/2021', 'KH001','tien123')
insert into HOADON values('HD002', 97000, 100000, 3000, '11/2/2021', 'KH002','kiet123')
insert into HOADON values('HD003', 90000, 100000, 10000, '12/3/2021', 'KH003','hung123')
insert into HOADON values('HD004', 89000, 90000, 1000, '13/4/2021', 'KH004','linh123')
insert into HOADON values('HD005', 47500, 50000, 2500, '14/5/2021', 'KH005','phuong123') 
insert into HOADON values('HD006', 40000, 40000, 0, '10/6/2021', 'KH001','tien123')
insert into HOADON values('HD007', 97000, 100000, 3000, '11/7/2021', 'KH002','kiet123')
insert into HOADON values('HD008', 90000, 100000, 10000, '12/8/2021', 'KH003','hung123')
insert into HOADON values('HD009', 89000, 90000, 1000, '13/9/2021', 'KH004','linh123')
insert into HOADON values('HD010', 47500, 50000, 2500, '14/10/2021', 'KH005','phuong123') 
insert into HOADON values('HD011', 89000, 90000, 1000, '13/11/2021', 'KH004','linh123')
insert into HOADON values('HD012', 47500, 50000, 2500, '14/12/2021', 'KH005','phuong123')
insert into HOADON values('HD013', 47500, 50000, 2500, '1/12/2021', 'KH013','phuong123') 
insert into HOADON values('HD014', 40000, 40000, 0, '5/1/2021', 'KH001','tien123')
insert into HOADON values('HD015', 97000, 100000, 3000, '12/1/2021', 'KH002','kiet123')
insert into HOADON values('HD016', 90000, 100000, 10000, '15/1/2021', 'KH003','hung123')
insert into HOADON values('HD017', 89000, 90000, 1000, '20/1/2021', 'KH004','linh123')
insert into HOADON values('HD018', 47500, 50000, 2500, '14/2/2021', 'KH005','phuong123') 
insert into HOADON values('HD019', 40000, 40000, 0, '21/2/2021', 'KH006','tien123')
insert into HOADON values('HD020', 97000, 100000, 3000, '25/2/2021', 'KH007','kiet123')
insert into HOADON values('HD021', 90000, 100000, 10000, '3/3/2021', 'KH008','hung123')
insert into HOADON values('HD022', 89000, 90000, 1000, '13/3/2021', 'KH009','linh123')
insert into HOADON values('HD023', 47500, 50000, 2500, '19/3/2021', 'KH010','phuong123') 
insert into HOADON values('HD024', 89000, 90000, 1000, '8/4/2021', 'KH011','linh123')
insert into HOADON values('HD025', 47500, 50000, 2500, '18/4/2021', 'KH012','phuong123') 
insert into HOADON values('HD026', 47500, 50000, 2500, '15/5/2021', 'KH013','phuong123') 
insert into HOADON values('HD027', 90000, 100000, 10000, '22/5/2021', 'KH008','hung123')
insert into HOADON values('HD028', 89000, 90000, 1000, '13/6/2021', 'KH009','linh123')
insert into HOADON values('HD029', 47500, 50000, 2500, '14/7/2021', 'KH010','phuong123') 
insert into HOADON values('HD030', 89000, 90000, 1000, '23/7/2021', 'KH011','linh123')
insert into HOADON values('HD031', 47500, 50000, 2500, '24/7/2021', 'KH012','phuong123') 
insert into HOADON values('HD032', 47500, 50000, 2500, '11/8/2021', 'KH013','phuong123') 
insert into HOADON values('HD033', 40000, 40000, 0, '23/8/2021', 'KH001','tien123')
insert into HOADON values('HD034', 97000, 100000, 3000, '12/9/2021', 'KH002','kiet123')
insert into HOADON values('HD035', 90000, 100000, 10000, '15/9/2021', 'KH003','hung123')
insert into HOADON values('HD036', 89000, 90000, 1000, '20/10/2021', 'KH004','linh123')
insert into HOADON values('HD037', 47500, 50000, 2500, '14/11/2021', 'KH005','phuong123') 
insert into HOADON values('HD038', 40000, 40000, 0, '21/11/2021', 'KH006','tien123')
insert into HOADON values('HD039', 97000, 100000, 3000, '25/11/2021', 'KH007','kiet123')
insert into HOADON values('HD039', 97000, 100000, 3000, '29/12/2021', 'KH007','kiet123')

insert into HOADON values('HD040', 40000, 40000, 0, '1/1/2022', 'KH001','tien123')
insert into HOADON values('HD041', 97000, 100000, 3000, '11/2/2022', 'KH002','kiet123')
insert into HOADON values('HD042', 90000, 100000, 10000, '12/3/2022', 'KH003','hung123')
insert into HOADON values('HD043', 89000, 90000, 1000, '13/4/2022', 'KH004','linh123')
insert into HOADON values('HD044', 47500, 50000, 2500, '14/5/2022', 'KH005','phuong123') 
insert into HOADON values('HD045', 40000, 40000, 0, '10/6/2022', 'KH006','tien123')
insert into HOADON values('HD046', 97000, 100000, 3000, '11/7/2022', 'KH007','kiet123')
insert into HOADON values('HD047', 90000, 100000, 10000, '12/8/2022', 'KH008','hung123')
insert into HOADON values('HD048', 89000, 90000, 1000, '13/9/2022', 'KH009','linh123')
insert into HOADON values('HD049', 47500, 50000, 2500, '14/10/2022', 'KH010','phuong123') 
insert into HOADON values('HD050', 89000, 90000, 1000, '13/11/2022', 'KH011','linh123')
insert into HOADON values('HD051', 47500, 50000, 2500, '14/12/2022', 'KH012','phuong123') 
insert into HOADON values('HD052', 47500, 50000, 2500, '1/12/2022', 'KH013','phuong123') 
insert into HOADON values('HD053', 40000, 40000, 0, '5/1/2022', 'KH001','tien123')
insert into HOADON values('HD054', 97000, 100000, 3000, '12/1/2022', 'KH002','kiet123')
insert into HOADON values('HD055', 90000, 100000, 10000, '15/1/2022', 'KH003','hung123')
insert into HOADON values('HD056', 89000, 90000, 1000, '20/1/2022', 'KH004','linh123')
insert into HOADON values('HD057', 47500, 50000, 2500, '14/2/2022', 'KH005','phuong123') 
insert into HOADON values('HD058', 40000, 40000, 0, '21/2/2022', 'KH006','tien123')
insert into HOADON values('HD059', 97000, 100000, 3000, '25/2/2022', 'KH007','kiet123')
insert into HOADON values('HD060', 90000, 100000, 10000, '3/3/2022', 'KH008','hung123')
insert into HOADON values('HD061', 89000, 90000, 1000, '13/3/2022', 'KH009','linh123')
insert into HOADON values('HD062', 47500, 50000, 2500, '19/3/2022', 'KH010','phuong123') 
insert into HOADON values('HD063', 89000, 90000, 1000, '8/4/2022', 'KH011','linh123')
insert into HOADON values('HD064', 47500, 50000, 2500, '18/4/2022', 'KH012','phuong123') 
insert into HOADON values('HD065', 47500, 50000, 2500, '15/5/2022', 'KH013','phuong123') 
insert into HOADON values('HD066', 90000, 100000, 10000, '22/5/2022', 'KH008','hung123')
insert into HOADON values('HD067', 89000, 90000, 1000, '13/6/2022', 'KH009','linh123')
insert into HOADON values('HD068', 47500, 50000, 2500, '14/7/2022', 'KH010','phuong123') 
insert into HOADON values('HD069', 89000, 90000, 1000, '23/7/2022', 'KH011','linh123')
insert into HOADON values('HD070', 47500, 50000, 2500, '24/7/2022', 'KH012','phuong123') 
insert into HOADON values('HD071', 47500, 50000, 2500, '11/8/2022', 'KH013','phuong123') 
insert into HOADON values('HD072', 40000, 40000, 0, '23/8/2022', 'KH001','tien123')
insert into HOADON values('HD073', 97000, 100000, 3000, '12/9/2022', 'KH002','kiet123')
insert into HOADON values('HD074', 90000, 100000, 10000, '15/9/2022', 'KH003','hung123')
insert into HOADON values('HD075', 89000, 90000, 1000, '20/10/2022', 'KH004','linh123')
insert into HOADON values('HD076', 47500, 50000, 2500, '14/11/2022', 'KH005','phuong123') 
insert into HOADON values('HD077', 40000, 40000, 0, '21/11/2022', 'KH006','tien123')
insert into HOADON values('HD078', 97000, 100000, 3000, '25/11/2022', 'KH007','kiet123')
insert into HOADON values('HD079', 97000, 100000, 3000, '29/12/2022', 'KH007','kiet123')
insert into HOADON values('HD080', 97000, 100000, 3000, '30/12/2022', 'KH007','tien123')


insert into CHITIETHD values('HD001', 'SP001', 2)
insert into CHITIETHD values('HD001', 'SP002', 2)
insert into CHITIETHD values('HD002', 'SP005', 4)
insert into CHITIETHD values('HD002', 'SP0010', 1)
insert into CHITIETHD values('HD002', 'SP0020', 1)
insert into CHITIETHD values('HD003', 'SP004', 5)
insert into CHITIETHD values('HD003', 'SP009', 10)
insert into CHITIETHD values('HD004', 'SP0011', 5)
insert into CHITIETHD values('HD004', 'SP0015', 3)
insert into CHITIETHD values('HD005', 'SP003', 5) 
insert into CHITIETHD values('HD005', 'SP0012', 1) 
insert into CHITIETHD values('HD005', 'SP0019', 1) 

set dateformat DMY
insert into GIAMGIA values('GG001', 50, '5/10/2022', '10/10/2022', 'SP001')
insert into GIAMGIA values('GG002', 20, '5/10/2022', '10/10/2022', 'SP002')
insert into GIAMGIA values('GG003', 30, '5/10/2022', '10/10/2022', 'SP003')
insert into GIAMGIA values('GG004', 40, '5/10/2022', '10/10/2022', 'SP004')
insert into GIAMGIA values('GG005', 10, '5/10/2022', '10/10/2022', 'SP005')

--TỰ ĐỘNG TĂNG MÃ
--@lastID là mã cuối cùng
--@prefix là tiền tố mã 'KH'
--@size là số lượng ký tự trong mã
GO
CREATE FUNCTION TANG_MA(@lastID VARCHAR(50), @prefix VARCHAR(3), @size int) 
RETURNS VARCHAR(50)
AS
	BEGIN 
		IF (@lastID = '') 
			SET @lastID = @prefix + REPLICATE (0, @size - LEN(@prefix))
		DECLARE @SO_NEXT int, @MA_NEXT VARCHAR(6) 
		SET @lastID = LTRIM(RTRIM(@lastID)) 
		SET @SO_NEXT = REPLACE(@lastID,@prefix,'')+1
		SET @size = @size - len(@prefix) 
		SET @MA_NEXT = @prefix + REPLICATE(0, @size - LEN(@prefix))
		SET @MA_NEXT = @prefix + RIGHT(REPLICATE(0, @size) + CONVERT (VARCHAR(MAX), @SO_NEXT), @size) 
		RETURN @MA_NEXT 
	END

--MAKH
GO
CREATE TRIGGER UPDATE_MAKH on KHACHHANG 
FOR INSERT 
AS
	BEGIN 
		DECLARE @lastID VARCHAR (5) 
		SET @lastID = (SELECT TOP 1 maKH from KHACHHANG order by maKH desc) 
		UPDATE KHACHHANG SET maKH = dbo.TANG_MA(@lastID, 'KH',5) where maKH = '' 
	END
--TEST
--insert into KHACHHANG values('', N'An', '0123456789', 10)
--select * from KHACHHANG

--MANCC
GO
CREATE TRIGGER UPDATE_MANCC on NHACUNGCAP 
FOR INSERT 
AS
	BEGIN 
		DECLARE @lastID VARCHAR (6) 
		SET @lastID = (SELECT TOP 1 maNCC from NHACUNGCAP order by maNCC desc) 
		UPDATE NHACUNGCAP SET maNCC = dbo.TANG_MA(@lastID, 'NCC',6) where maNCC = '' 
	END
--insert into NHACUNGCAP values('', N'Coca', '0987654321', N'Long An', 5, N'Nước ngọt')
--select * from NHACUNGCAP

--MASP
GO
CREATE TRIGGER UPDATE_MASP on SANPHAM 
FOR INSERT 
AS
	BEGIN 
		DECLARE @lastID VARCHAR (5) 
		SET @lastID = (SELECT TOP 1 maSP from SANPHAM order by maSP desc) 
		UPDATE SANPHAM SET maSP = dbo.TANG_MA(@lastID, 'SP',5) where maSP = '' 
	END
--insert into SANPHAM values('', N'Nước Coca', 10, N'Nước uống', '10/10/2023', 10000, 8000, 'NCC001')
--select * from SANPHAM

--MAHOADON
GO
CREATE TRIGGER UPDATE_MAHD on HOADON 
FOR INSERT 
AS
	BEGIN 
		DECLARE @lastID VARCHAR (5) 
		SET @lastID = (SELECT TOP 1 maHD from HOADON order by maHD desc) 
		UPDATE HOADON SET maHD = dbo.TANG_MA(@lastID, 'HD',5) where maHD = '' 
	END
--insert into HOADON values('', 'SP001', 2, 20000, 20000, 0, '10/10/2022', 'KH001')
--select * from HOADON

--MAGIAMGIA
GO
CREATE TRIGGER UPDATE_MAGG on GIAMGIA 
FOR INSERT 
AS
	BEGIN 
		DECLARE @lastID VARCHAR (5) 
		SET @lastID = (SELECT TOP 1 maGiamGia from GIAMGIA order by maGiamGia desc) 
		UPDATE GIAMGIA SET maGiamGia = dbo.TANG_MA(@lastID, 'GG',5) where maGiamGia = '' 
	END
--insert into GIAMGIA values('', 50, '5/10/2022', '10/10/2022', 'SP001')
--select * from GIAMGIA


select tenSP from dbo.SANPHAM
select maNV from dbo.NHANVIEN
select * from NHANVIEN
select * from KHACHHANG
select * from NHACUNGCAP
 
select * from HOADON
select * from CHITIETHD
select * from GIAMGIA


-- Tạo 7 hóa đơn random
GO
CREATE PROCEDURE random as
SELECT TOP 7 * FROM hoadon
ORDER BY NEWID()

-- EXEC random

-- lấy tiền từ tháng và năm tùy chọn
-- SELECT tongTien, ngayLapHD FROM HOADON WHERE MONTH(ngayLapHD) = 10 AND YEAR(ngayLapHD) = 2022

-- lấy tiền từ năm tùy chọn
-- SELECT tongTien, ngayLapHD FROM HOADON WHERE YEAR(ngayLapHD) = 2022

-- lấy tổng tiền của tháng và năm tùy chọn
-- SELECT sum(tongTien) as Tong FROM HOADON WHERE MONTH(ngayLapHD) = 10 AND YEAR(ngayLapHD) = 2022

-- lấy tổng tiền năm tùy chọn
-- SELECT sum(tongTien) as Tong FROM HOADON WHERE YEAR(ngayLapHD) = 2022

-- lấy ra các tháng
-- SELECT DISTINCT MONTH(ngayLapHD) as Thang FROM HOADON

-- lấy ra các năm
-- SELECT DISTINCT YEAR(ngayLapHD) as Nam FROM HOADON