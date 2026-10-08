using OpenQA.Selenium;
using VanPhongDienTu.Tests.Helpers;

namespace VanPhongDienTu.Tests.Tests;

public abstract class BaseTest
{
    protected IWebDriver Driver = null!;

    [SetUp]
    public void SetUp()
    {
        Driver = DriverFactory.Create();
        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}
