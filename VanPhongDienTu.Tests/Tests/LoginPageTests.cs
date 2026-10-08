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
}
