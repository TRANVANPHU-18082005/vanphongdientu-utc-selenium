using OpenQA.Selenium;
using VanPhongDienTu.Tests.Config;
using VanPhongDienTu.Tests.Helpers;

namespace VanPhongDienTu.Tests.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;

    public static readonly By UsernameInput = By.Name("username");
    public static readonly By PasswordInput = By.Name("userpwd");
    public static readonly By PersistentCheckbox = By.Id("persistent");
    public static readonly By PersistentLabel = By.CssSelector("label.check");
    public static readonly By LoginButton = By.CssSelector("input.submit_login");
    public static readonly By GoogleLoginLink = By.CssSelector("a.button");
    public static readonly By ForgotPasswordLink = By.CssSelector("div.helps a");
    public static readonly By HelpCenterLink = By.CssSelector("div.footer a[href='http://hotrokythuat.utc.edu.vn']");
    public static readonly By FeedbackLink = By.CssSelector("div.footer a[href^='mailto:']");
    public static readonly By ErrorMessage = By.CssSelector("div.error");
    public static readonly By Heading = By.CssSelector("h1");
    public static readonly By Caption = By.CssSelector(".caption span");
    public static readonly By Copyright = By.CssSelector(".footer .left span.a");
    public static readonly By LoginForm = By.CssSelector("form[action='/Login']");

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public LoginPage Open()
    {
        _driver.Navigate().GoToUrl(TestSettings.LoginUrl);
        WaitHelpers.WaitVisible(_driver, UsernameInput);
        return this;
    }

    public LoginPage EnterUsername(string username)
    {
        var input = WaitHelpers.WaitVisible(_driver, UsernameInput);
        input.Clear();
        input.SendKeys(username);
        return this;
    }

    public LoginPage EnterPassword(string password)
    {
        var input = WaitHelpers.WaitVisible(_driver, PasswordInput);
        input.Clear();
        input.SendKeys(password);
        return this;
    }

    public LoginPage ClickLogin()
    {
        WaitHelpers.WaitVisible(_driver, LoginButton).Click();
        return this;
    }

    public LoginPage ToggleKeepMeSignedIn()
    {
        WaitHelpers.WaitVisible(_driver, PersistentLabel).Click();
        return this;
    }

    public bool IsKeepMeSignedInChecked()
    {
        return _driver.FindElement(PersistentCheckbox).Selected;
    }

    public string GetErrorText()
    {
        return WaitHelpers.WaitVisible(_driver, ErrorMessage).Text.Trim();
    }

    public ForgotPasswordPage ClickForgotPassword()
    {
        WaitHelpers.WaitVisible(_driver, ForgotPasswordLink).Click();
        WaitHelpers.WaitUrlContains(_driver, "/Login/GetPass");
        return new ForgotPasswordPage(_driver);
    }
}
