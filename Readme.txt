Cấu trúc thư mục gồm trong bài nộp của nhóm em gồm:
+ source: gồm mã nguồn trong thư mục PM711 và cơ sở dữ liệu Quanly711.sql
+ documents: gồm 2 thư mục
	- Báo cáo cũ: chứa các tài liệu của đồ án cũ (do đồ án cũ không yêu cầu viết báo cáo nên không có file báo cáo)
	- Báo cáo mới: chứa file baocao.docx và baocao.pdf
+ File Readme.txt
+ File danh gia - phan cong.docx

Điều kiện tiên quyết để chạy được phần mềm, máy tính cần phải cài:
+ Microsoft SQL Sever Managerment Studio
+ Visual Studio (phiên bản 2022 nếu được)

Các bước để chạy phần mềm:
+ B1: Vào Microsoft SQL Sever Managerment Studio
+ B2: Mở file Quanly711.sql trong thử mục Source lên
+ B3: Bấm Execute để tạo database
+ B4: Vào thư mục Source -> Vào thư mục PM711 -> Mở file QuanLy711.sln lên để chạy phần mềm.
+ B5: Vào file DataProvider.cs trong thư mục DAO, sửa lại "Data Source" của connectionString để phù hợp với máy thực thi phần mềm (hiện đang là "Data Source=.;")
+ B6: Bấm nút Start để chạy phần mềm
 
Các tài khoản có thể sử dụng để đăng nhập vào phần mềm:
+ Tài khoản quản lý: tien123 - tien123 (có thể truy cập vào trang doanh thu)
+ Tài khoản nhân viên: kiet123 - kiet123 (không thể truy cập vào trang doanh thu)

Lưu ý:
+ Tùy DPI của máy mà giao diện có thể bị thay đổi kích thước
+ Ở trang thanh toán có thể để trống mã khách hàng
+ Nếu như việc thêm hóa đơn không được thì có thể do ngày tháng của máy thực thi khác so với cấu trúc DMY của database