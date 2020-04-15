Use QLThuVien
go
Insert into NhaXuatBan values 
(1000, N'Nhà xuất bản Kim Đồng', N'55 Quang Trung, Hai Bà Trưng, Hà Nội', 'kimdong@hn.vnn.vn', 12131),
(1001, N'Nhà xuất bản Trẻ', N'Phường 7, Quận 3, Thành phố Hồ Chí Minh', 'hopthubandoc@nxbtre.com.vn', 12131),
(1002, N'Nhà xuất bản Tổng hợp thành phố Hồ Chí Minh', N'62 Nguyễn Thị Minh Khai, Phường Đa Kao', 'tonghop@nxbhcm.com.vn', 3112),
(1003, N'Nhà xuất bản chính trị quốc gia sự thật', N'Số 6/86 Duy Tân, Cầu Giấy, Hà Nội; ', 'suthat@nxbctqg.vn', 1234),
(1004, N'Nhà xuất bản giáo dục', N'81 Trần Hưng Đạo, Hà Nội', 'nxbgg@gmail.com', 123),
(1005, N'Nhà xuất bản Hội Nhà văn', N'Số 65 Nguyễn Du, Hà Nội', 'nxbhnv@gmai.com', 123)

go
Insert into TheLoai values
(1, N'Chính trị – pháp luật'),
(2, N'Khoa học công nghệ – Kinh tế'),
(3, N'Văn hóa xã hội – Lịch sử'),
(4, N'Văn học nghệ thuật'),
(5, N'Giáo trình'),
(6, N'Truyện, tiểu thuyết'),
(7, N'Tâm lý, tâm linh, tôn giáo'),
(8, N'Sách thiếu nhi')

go 
Insert into TacGia values 
(1501, N'Nguyễn Nhật Ánh', 'NguyenNhatAnh.com.vn'),
(1502, N'Trang Hạ', 'HaTrang.com.vn'),
(1503, N'Nguyễn Phong Việt', 'Websitetacgia.com'),
(1504, N'Huấn Hoa Hồng', 'CoLamCoAn.com.vn'),
(1505, N'Anh Khang', 'Websitetacgia.com')

go
Insert into Ke values
(1, 'Gỗ', 50, 0),
(2, 'Gỗ', 50, 0),
(3, 'Gỗ', 100, 0),
(4, 'Gỗ', 100, 0),
(5, 'Gỗ', 100, 0),
(6, 'Gỗ', 100, 0)


go 
Insert into TaiKhoan values 
('admin', 'admin')

go 
Insert into NhanVien values 
(1, N'Nguyễn Việt Long', '19991210', N'Nam', 099892, 'admin')

go
Insert into DocGia values 
(101, N'Nguyễn Văn A', N'Nam', '20000101', N'Hà Nội', 232421)