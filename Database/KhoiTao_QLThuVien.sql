Create database QLThuVien

Use QLThuVien
go
Create table NhaXuatBan (
	MaNXB int not null,
	TenNXB nvarchar(50),
	DiaChi nvarchar(50),
	Email varchar(50),
	SDT int
)
alter table NhaXuatBan add primary key (MaNXB)

go
Create table TheLoai (
	MaTL int not null,
	TenTL nvarchar(50)
)
alter table TheLoai add primary key (MaTL)

go
Create table TacGia (
	MaTG int not null,
	TenTG nvarchar(50),
	Website varchar(50)
)
alter table TacGia add primary key (MaTG)

go Create table Ke(
	MaKe int not null,
	ChatLieu nvarchar(20),
	SLChua int,
	SLSach int
)
alter table Ke add primary key (MaKe)

go
Create table Sach(
	MaSach int not null,
	TenSach nvarchar(50),
	MaTL int,
	MaKe int,
	MaNXB int,
	MaTG int,
	NamXuatBan varchar(4)
)
alter table Sach add primary key(MaSach)
alter table Sach add foreign key(MaNXB) references NhaXuatBan (MaNXB)
alter table Sach add foreign key(MaTG) references TacGia (MaTG)
alter table Sach add foreign key(MaTL) references TheLoai (MaTL)
alter table Sach add foreign key(MaKe) references Ke (MaKe)

go 
Create table DocGia(
	MaDG int not null,
	HoTen nvarchar(50),
	GT nvarchar(5),
	NgaySinh date,
	DiaChi nvarchar(50),
	SDT int
)
alter table DocGia add primary key (MaDG)

go
Create table TaiKhoan (
	TenDangNhap varchar(20) not null,
	MatKhau varchar(20)
)
alter table TaiKhoan add primary key (TenDangNhap)

go
Create table NhanVien (
	MaNV int not null,
	HoTen nvarchar(50),
	NgaySinh date,
	GT nvarchar(50),
	SDT int,
	TenDangNhap varchar(20)
)
alter table NhanVien add primary key (MaNV)
alter table NhanVien add foreign key (TenDangNhap) references TaiKhoan (TenDangNhap)

go 
Create table MuonTra (
	MaMuonTra int not null,
	MaDG int,
	MaNV int,
	NgayMuon date
)
alter table MuonTra add primary key (MaMuonTra) 
alter table MuonTra add foreign key (MaDG) references DocGia (MaDG)
alter table MuonTra add foreign key (MaNV) references NhanVien (MaNV)

go
Create table CTMuonTra (
	MaMuonTra int,
	MaSach int,
	TrangThai nvarchar(10),
	NgayTra date
)
alter table CTMuonTra add foreign key (MaMuonTra) references MuonTra(MaMuonTra)
alter table CTMuonTra add foreign key (MaSach) references Sach(MaSach)

