# Kiểm thử Selenium – Văn phòng điện tử UTC

Project NUnit + Selenium WebDriver (C#) cho website [vanphongdientu.utc.edu.vn](https://vanphongdientu.utc.edu.vn).

## Yêu cầu

- .NET 8 SDK
- Google Chrome (mặc định) hoặc Microsoft Edge
- Kết nối Internet tới `vanphongdientu.utc.edu.vn`

## Chạy test

```bash
dotnet test VanPhongDienTu.Tests.sln
```

Headless:

```bash
set HEADLESS=true
dotnet test VanPhongDienTu.Tests.sln
```

Dùng Edge:

```bash
set BROWSER=edge
dotnet test VanPhongDienTu.Tests.sln
```

## Cấu trúc

- `docs/TestCases.md` – bộ test case và locator lấy từ HTML thật của web
- `VanPhongDienTu.Tests/Pages` – Page Object (Login, Forgot Password)
- `VanPhongDienTu.Tests/Tests` – script Selenium, mỗi test case một method

## Git

- Commit đầu: khởi tạo project
- Mỗi test case sau đó là một commit riêng
