# Test case – Văn phòng điện tử UTC

**Ứng dụng:** [https://vanphongdientu.utc.edu.vn](https://vanphongdientu.utc.edu.vn)  
**Phạm vi:** trang Đăng nhập và trang Lấy lại mật khẩu (các màn công khai, không cần tài khoản thật)  
**Công cụ tự động hóa:** Selenium WebDriver + NUnit, ngôn ngữ C#

Locator lấy trực tiếp từ HTML của website (không dùng XPath tuyệt đối).

## Locators

### Trang đăng nhập (`/Login`)

| Phần tử | Locator | Giá trị HTML |
| --- | --- | --- |
| Form | `form[action='/Login']` | `method="post"` |
| Tên đăng nhập | `name="username"` | `placeholder="Tên đăng nhập"` |
| Mật khẩu | `name="userpwd"` | `placeholder="Mật khẩu"` |
| Giữ tôi luôn đăng nhập | `id="persistent"` / `label.check` | checkbox ẩn, click nhãn |
| Nút Đăng nhập | `input.submit_login` | `value="Đăng nhập"` |
| Đăng nhập bằng e-mail UTC | `a.button` | Google OAuth |
| Quên mật khẩu | `div.helps a` | `href="/Login/GetPass"` |
| Thông báo lỗi | `div.error` | text thay đổi theo case |
| Tiêu đề | `h1` | Không chỉ là một giải pháp quản lý |
| Trung tâm trợ giúp | footer `a[href='http://hotrokythuat.utc.edu.vn']` | `target="_blank"` |
| Ý kiến phản hồi | footer `a[href^='mailto:']` | `mailto:hotrokythuat@utc.edu.vn` |

### Trang lấy lại mật khẩu (`/Login/GetPass`)

| Phần tử | Locator | Giá trị HTML |
| --- | --- | --- |
| Form | `form[action='/Login/Getpass']` | `method="post"` |
| Ảnh captcha | `img[src='/login/index/captcha']` | |
| Mã bảo mật | `name="captcha"` | `placeholder="Mã bảo mật"` |
| Email | `name="email"` | `placeholder="Địa chỉ Email"` |
| Nút Cập nhật | `input[type='submit'][value='Cập nhật']` | |
| Trở lại đăng nhập | `div.helps a` | `href="/Login"` |
| Thông báo lỗi | `div.error` | ví dụ: Mã bảo mật không chính xác |

## Danh sách test case

| ID | Tên | Tiền điều kiện | Các bước | Dữ liệu | Kết quả mong đợi |
| --- | --- | --- | --- | --- | --- |
| TC01 | Mở trang đăng nhập | Có kết nối Internet | 1. Mở `/Login` | — | Title = `Đăng nhập`. Có ô username, password, nút Đăng nhập, heading, link quên mật khẩu |
| TC02 | Đăng nhập bỏ trống tên đăng nhập | Đang ở `/Login` | 1. Để trống username và password 2. Bấm Đăng nhập | username= rỗng, password= rỗng | `div.error` = `Bạn chưa nhập tên đăng nhập`. Vẫn ở `/Login` |
| TC03 | Đăng nhập bỏ trống mật khẩu | Đang ở `/Login` | 1. Nhập username 2. Để trống password 3. Bấm Đăng nhập | username=`testuser`, password= rỗng | `div.error` = `Bạn chưa nhập mật khẩu`. Vẫn ở `/Login` |
| TC04 | Đăng nhập sai tài khoản/mật khẩu | Đang ở `/Login` | 1. Nhập username sai 2. Nhập password sai 3. Bấm Đăng nhập | username=`invalid_user_xyz`, password=`wrong_password_xyz` | `div.error` = `Tài khoản hoặc mật khẩu không đúng.` Vẫn ở `/Login` |
| TC05 | Tick Giữ tôi luôn đăng nhập | Đang ở `/Login` | 1. Click `label.check` | — | Checkbox `#persistent` chuyển sang trạng thái selected |
| TC06 | Chuyển sang trang quên mật khẩu | Đang ở `/Login` | 1. Click `Bạn quên mật khẩu đăng nhập ?` | — | URL chứa `/Login/GetPass`. Title = `Lấy lại mật khẩu`. Có captcha, email, nút Cập nhật |
| TC07 | Gửi form quên mật khẩu với captcha sai | Đang ở `/Login/GetPass` | 1. Nhập captcha giả 2. Nhập email 3. Bấm Cập nhật | captcha=`0000`, email=`abc@utc.edu.vn` | `div.error` = `Mã bảo mật không chính xác` |
| TC08 | Trở lại đăng nhập từ trang quên mật khẩu | Đang ở `/Login/GetPass` | 1. Click `Trở lại đăng nhập?` | — | Quay về `/Login`, ô username hiển thị |
| TC09 | Link đăng nhập bằng e-mail UTC | Đang ở `/Login` | 1. Đọc `href` của `a.button` | — | `href` chứa `accounts.google.com` và `oauth2` |
| TC10 | Link trợ giúp và phản hồi | Đang ở `/Login` | 1. Đọc `href`/`target` footer | — | Trợ giúp = `http://hotrokythuat.utc.edu.vn` (`_blank`). Phản hồi = `mailto:hotrokythuat@utc.edu.vn` |

## Ghi chú

- Không tự động hóa đăng nhập thành công vì không dùng tài khoản thật của nhà trường.
- Thông báo lỗi được xác nhận bằng cách thao tác thật trên website trước khi viết script.
