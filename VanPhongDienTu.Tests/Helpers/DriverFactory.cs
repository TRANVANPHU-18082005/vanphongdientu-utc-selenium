using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace VanPhongDienTu.Tests.Helpers;

public static class DriverFactory
{
    public static IWebDriver Create()
    {
        var browser = (Environment.GetEnvironmentVariable("BROWSER") ?? "chrome").ToLowerInvariant();
        var headless = string.Equals(Environment.GetEnvironmentVariable("HEADLESS"), "true", StringComparison.OrdinalIgnoreCase);

        return browser switch
        {
            "edge" => CreateEdge(headless),
            _ => CreateChrome(headless)
        };
    }

    private static IWebDriver CreateChrome(bool headless)
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--disable-notifications");
        if (headless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
        }

        return new ChromeDriver(options);
    }

    private static IWebDriver CreateEdge(bool headless)
    {
        var options = new EdgeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--no-sandbox");
        if (headless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
        }

        return new EdgeDriver(options);
    }
}
