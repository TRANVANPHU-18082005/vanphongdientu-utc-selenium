using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using VanPhongDienTu.Tests.Config;

namespace VanPhongDienTu.Tests.Helpers;

public static class WaitHelpers
{
    public static IWebElement WaitVisible(IWebDriver driver, By locator)
    {
        var wait = new WebDriverWait(driver, TestSettings.DefaultTimeout);
        return wait.Until(d =>
        {
            var element = d.FindElement(locator);
            return element.Displayed ? element : null;
        })!;
    }

    public static bool WaitUrlContains(IWebDriver driver, string fragment)
    {
        var wait = new WebDriverWait(driver, TestSettings.DefaultTimeout);
        return wait.Until(d => d.Url.Contains(fragment, StringComparison.OrdinalIgnoreCase));
    }
}
