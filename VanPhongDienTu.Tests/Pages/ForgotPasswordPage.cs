using OpenQA.Selenium;
using VanPhongDienTu.Tests.Config;
using VanPhongDienTu.Tests.Helpers;

namespace VanPhongDienTu.Tests.Pages;

public class ForgotPasswordPage
{
    private readonly IWebDriver _driver;

    public static readonly By CaptchaImage = By.CssSelector("img[src='/login/index/captcha']");
    public static readonly By CaptchaInput = By.Name("captcha");
    public static readonly By EmailInput = By.Name("email");
    public static readonly By SubmitButton = By.CssSelector("input[type='submit'][value='Cập nhật']");
    public static readonly By BackToLoginLink = By.CssSelector("div.helps a");
    public static readonly By ErrorMessage = By.CssSelector("div.error");
    public static readonly By Logo = By.CssSelector("img.logo");
    public static readonly By Heading = By.CssSelector("h1");

    public ForgotPasswordPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public ForgotPasswordPage Open()
    {
        _driver.Navigate().GoToUrl(TestSettings.ForgotPasswordUrl);
        WaitHelpers.WaitVisible(_driver, CaptchaInput);
        return this;
    }

    public ForgotPasswordPage EnterCaptcha(string captcha)
    {
        var input = WaitHelpers.WaitVisible(_driver, CaptchaInput);
        input.Clear();
        input.SendKeys(captcha);
        return this;
    }

    public ForgotPasswordPage EnterEmail(string email)
    {
        var input = WaitHelpers.WaitVisible(_driver, EmailInput);
        input.Clear();
        input.SendKeys(email);
        return this;
    }

    public ForgotPasswordPage ClickSubmit()
    {
        WaitHelpers.WaitVisible(_driver, SubmitButton).Click();
        return this;
    }

    public string GetErrorText()
    {
        return WaitHelpers.WaitVisible(_driver, ErrorMessage).Text.Trim();
    }

    public LoginPage ClickBackToLogin()
    {
        WaitHelpers.WaitVisible(_driver, BackToLoginLink).Click();
        WaitHelpers.WaitVisible(_driver, LoginPage.UsernameInput);
        return new LoginPage(_driver);
    }
}
