using OpenQA.Selenium;
using VanPhongDienTu.Tests.Pages;

namespace VanPhongDienTu.Tests.Tests;

public class LoginPageTests : BaseTest
{
    [Test]
    [Description("TC01 - Mo trang dang nhap va kiem tra cac phan tu chinh")]
    public void TC01_OpenLoginPage_ShouldDisplayLoginForm()
    {
        new LoginPage(Driver).Open();

        Assert.That(Driver.Title, Is.EqualTo("Đăng nhập"));
        Assert.That(Driver.Url, Does.Contain("/Login"));
        Assert.That(Driver.FindElement(LoginPage.UsernameInput).GetAttribute("placeholder"), Is.EqualTo("Tên đăng nhập"));
        Assert.That(Driver.FindElement(LoginPage.PasswordInput).GetAttribute("placeholder"), Is.EqualTo("Mật khẩu"));
        Assert.That(Driver.FindElement(LoginPage.LoginButton).GetAttribute("value"), Is.EqualTo("Đăng nhập"));
        Assert.That(Driver.FindElement(LoginPage.Heading).Text, Is.EqualTo("Không chỉ là một giải pháp quản lý"));
        Assert.That(Driver.FindElement(LoginPage.ForgotPasswordLink).Displayed, Is.True);
    }

    [Test]
    [Description("TC02 - Dang nhap khi bo trong ten dang nhap")]
    public void TC02_LoginWithEmptyUsername_ShouldShowUsernameRequiredError()
    {
        var loginPage = new LoginPage(Driver).Open();
        loginPage.ClickLogin();

        Assert.That(loginPage.GetErrorText(), Is.EqualTo("Bạn chưa nhập tên đăng nhập"));
        Assert.That(Driver.Url, Does.Contain("/Login"));
    }

    [Test]
    [Description("TC03 - Dang nhap khi bo trong mat khau")]
    public void TC03_LoginWithEmptyPassword_ShouldShowPasswordRequiredError()
    {
        var loginPage = new LoginPage(Driver).Open();
        loginPage.EnterUsername("testuser");
        loginPage.ClickLogin();

        Assert.That(loginPage.GetErrorText(), Is.EqualTo("Bạn chưa nhập mật khẩu"));
        Assert.That(Driver.Url, Does.Contain("/Login"));
    }

    [Test]
    [Description("TC04 - Dang nhap voi tai khoan hoac mat khau khong dung")]
    public void TC04_LoginWithInvalidCredentials_ShouldShowInvalidAccountError()
    {
        var loginPage = new LoginPage(Driver).Open();
        loginPage.EnterUsername("invalid_user_xyz");
        loginPage.EnterPassword("wrong_password_xyz");
        loginPage.ClickLogin();

        Assert.That(loginPage.GetErrorText(), Is.EqualTo("Tài khoản hoặc mật khẩu không đúng."));
        Assert.That(Driver.Url, Does.Contain("/Login"));
    }

    [Test]
    [Description("TC05 - Tick checkbox Giu toi luon dang nhap")]
    public void TC05_ToggleKeepMeSignedIn_ShouldCheckPersistentCheckbox()
    {
        var loginPage = new LoginPage(Driver).Open();

        Assert.That(loginPage.IsKeepMeSignedInChecked(), Is.False);
        loginPage.ToggleKeepMeSignedIn();
        Assert.That(loginPage.IsKeepMeSignedInChecked(), Is.True);
    }

    [Test]
    [Description("TC06 - Chuyen sang trang quen mat khau")]
    public void TC06_ClickForgotPassword_ShouldOpenGetPassPage()
    {
        var loginPage = new LoginPage(Driver).Open();
        loginPage.ClickForgotPassword();

        Assert.That(Driver.Url, Does.Contain("/Login/GetPass").Or.Contain("/Login/Getpass"));
        Assert.That(Driver.Title, Is.EqualTo("Lấy lại mật khẩu"));
        Assert.That(Driver.FindElement(ForgotPasswordPage.CaptchaInput).GetAttribute("placeholder"), Is.EqualTo("Mã bảo mật"));
        Assert.That(Driver.FindElement(ForgotPasswordPage.EmailInput).GetAttribute("placeholder"), Is.EqualTo("Địa chỉ Email"));
        Assert.That(Driver.FindElement(ForgotPasswordPage.SubmitButton).GetAttribute("value"), Is.EqualTo("Cập nhật"));
        Assert.That(Driver.FindElement(ForgotPasswordPage.CaptchaImage).Displayed, Is.True);
    }

    [Test]
    [Description("TC09 - Link dang nhap bang e-mail UTC tro toi Google OAuth")]
    public void TC09_GoogleLoginLink_ShouldPointToGoogleOAuth()
    {
        new LoginPage(Driver).Open();
        var href = Driver.FindElement(LoginPage.GoogleLoginLink).GetAttribute("href") ?? string.Empty;

        Assert.That(Driver.FindElement(LoginPage.GoogleLoginLink).Text.Trim(), Is.EqualTo("Đăng nhập bằng e-mail UTC"));
        Assert.That(href, Does.Contain("accounts.google.com"));
        Assert.That(href, Does.Contain("oauth2"));
        Assert.That(href, Does.Contain("vanphongdientu.utc.edu.vn"));
    }

    [Test]
    [Description("TC10 - Link Trung tam tro giup va Y kien phan hoi")]
    public void TC10_FooterLinks_ShouldPointToHelpCenterAndFeedbackMail()
    {
        new LoginPage(Driver).Open();
        var help = Driver.FindElement(LoginPage.HelpCenterLink);
        var feedback = Driver.FindElement(LoginPage.FeedbackLink);

        Assert.That(help.Text.Trim(), Is.EqualTo("Trung tâm trợ giúp"));
        Assert.That(help.GetAttribute("href"), Does.StartWith("http://hotrokythuat.utc.edu.vn"));
        Assert.That(help.GetAttribute("target"), Is.EqualTo("_blank"));
        Assert.That(feedback.Text.Trim(), Is.EqualTo("Ý kiến phản hồi"));
        Assert.That(feedback.GetAttribute("href"), Is.EqualTo("mailto:hotrokythuat@utc.edu.vn"));
        Assert.That(Driver.FindElement(LoginPage.Copyright).Text, Does.Contain("Trường ĐH Giao Thông Vận Tải"));
    }
}
