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
}
