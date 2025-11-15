
## Cấu trúc dự án

```
QLKS/
├── Models/              # Model - Chứa các entity classes
│   ├── Room.cs
│   ├── Customer.cs
│   ├── Booking.cs
│   ├── Service.cs
│   ├── Payment.cs
│   ├── User.cs
│   └── RoomType.cs
│
├── Views/               # View - Giao diện người dùng (WinForms)
│   ├── frmMain.cs       # Form chính
│   └── [Các form khác...]
│
├── Controllers/         # Controller - Xử lý logic nghiệp vụ
│   ├── RoomController.cs
│   ├── CustomerController.cs
│   ├── BookingController.cs
│   └── ServiceController.cs
│
├── DAL/                 # Data Access Layer - Truy xuất database
│   ├── DatabaseConnection.cs
│   ├── RoomDAL.cs
│   ├── CustomerDAL.cs
│   ├── BookingDAL.cs
│   └── ServiceDAL.cs
│
├── BLL/                 # Business Logic Layer (tùy chọn)
├── Utils/               # Utilities - Các hàm tiện ích
└── Resources/           # Tài nguyên (hình ảnh, icons, etc.)
```



###  Cấu hình Database
- Tạo database trong SQL Server
- Cập nhật connection string trong file `DatabaseConnection.cs`

```csharp
// Sửa connection string phù hợp với máy của bạn
private string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=QLKSDb;Integrated Security=True";
```

### Branch Strategy
- `main`: Branch chính, code ổn định
- `feature/ten-tinh-nang`: Branch cho từng tính năng mới

### Commit Message
```
[Type] Mô tả ngắn gọn

Type có thể là:
- feat: Thêm tính năng mới
- fix: Sửa lỗi
- docs: Cập nhật tài liệu
- style: Format code
- refactor: Tái cấu trúc code
```

### Workflow
1. Pull code mới nhất từ `dev`
2. Tạo branch mới từ `dev`: `git checkout -b feature/ten-tinh-nang`
3. Code và commit thường xuyên
4. Push lên GitHub: `git push origin feature/ten-tinh-nang`
5. Tạo Pull Request để merge vào `dev`
6. Review code và merge


## Lưu ý
- Không commit file `bin/`, `obj/`, `.vs/` lên Git
- Luôn pull code mới trước khi bắt đầu làm việc
- Test kỹ trước khi tạo Pull Request
- Viết comment rõ ràng cho code
- Tuân thủ naming convention của C#
