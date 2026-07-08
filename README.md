1. Bài báo cáo viết như này

Tên đề tài: Hệ thống thi trắc nghiệm online Client–Server

Nội dung chính báo cáo:

Giới thiệu đề tài
Ứng dụng giúp sinh viên làm bài thi trắc nghiệm online.
Admin quản lý câu hỏi, đề thi, xem kết quả.
Server xử lý đăng nhập, câu hỏi, lưu điểm.
Client gửi yêu cầu qua mạng bằng TCP Socket.
Công nghệ sử dụng
C# WinForms
SQL Server / LocalDB
TCP Socket
Client–Server model
Chức năng hệ thống
Đăng nhập / đăng ký
Phân quyền Admin / Sinh viên
Sinh viên chọn đề thi, làm bài, nộp bài
Lưu kết quả vào database
Admin thêm/sửa/xóa câu hỏi
Admin xem thống kê kết quả
Mô hình hoạt động
Client gửi lệnh: LOGIN|admin|123
Server nhận lệnh, xử lý database
Server trả kết quả về Client
Client hiển thị lên giao diện
Database
Users
Exams
Questions
ExamResults
Demo
Chạy Server trước
Chạy Client
Login Admin
Thêm câu hỏi / xem kết quả
Login User
Làm bài / nộp bài / xem lịch sử
Kết luận
Hệ thống dùng được cho mô hình thi nội bộ.
Có socket thật, có database thật.
Có thể mở rộng multi-client nhiều sinh viên cùng làm.
