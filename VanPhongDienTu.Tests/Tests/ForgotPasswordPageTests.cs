using VanPhongDienTu.Tests.Pages;

namespace VanPhongDienTu.Tests.Tests;

public class ForgotPasswordPageTests : BaseTest
{
    [Test]
    [Description("TC07 - Gui form quen mat khau voi captcha sai")]
    public void TC07_SubmitForgotPasswordWithInvalidCaptcha_ShouldShowError()
    {
        var forgotPasswordPage = new ForgotPasswordPage(Driver).Open();
        forgotPasswordPage.EnterCaptcha("0000");
        forgotPasswordPage.EnterEmail("abc@utc.edu.vn");
        forgotPasswordPage.ClickSubmit();

        Assert.That(forgotPasswordPage.GetErrorText(), Is.EqualTo("Mã bảo mật không chính xác"));
    }

    [Test]
    [Description("TC08 - Tro lai dang nhap tu trang quen mat khau")]
    public void TC08_ClickBackToLogin_ShouldReturnToLoginPage()
    {
        var forgotPasswordPage = new ForgotPasswordPage(Driver).Open();
        forgotPasswordPage.ClickBackToLogin();

        Assert.That(Driver.Url, Does.Contain("/Login"));
        Assert.That(Driver.Title, Is.EqualTo("Đăng nhập"));
        Assert.That(Driver.FindElement(LoginPage.UsernameInput).Displayed, Is.True);
        Assert.That(Driver.FindElement(LoginPage.LoginButton).Displayed, Is.True);
    }
}
