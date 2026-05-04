using Allure.Net.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestShopProject.Models;
using TestShopProject.Utilities;

namespace TestShopProject.Core;

public class BaseTest
{
    protected IWebDriver Driver = null!;
    protected TestSettings Settings = null!;
    protected UserData TestUser = null!;

    [SetUp]
    public void Setup()
    {
        Settings = ConfigReader.LoadSettings();
        TestUser = DataGenerator.GenerateUser();

        switch (Settings.browser.ToLower())
        {
            case "chrome":
                var chromeOptions = new ChromeOptions();
                
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GITHUB_ACTIONS")))
                {
                    chromeOptions.AddArgument("--headless=new");
                    chromeOptions.AddArgument("--no-sandbox");
                    chromeOptions.AddArgument("--disable-dev-shm-usage");
                    chromeOptions.AddArgument("--window-size=1920,1080");
                }

                Driver = new ChromeDriver(chromeOptions);
                break;

            case "firefox":
                var firefoxOptions = new FirefoxOptions();
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GITHUB_ACTIONS")))
                {
                    firefoxOptions.AddArgument("--headless");
                }
                Driver = new FirefoxDriver(firefoxOptions);
                break;

            default:
                Driver = new ChromeDriver();
                break;
        }

        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(Settings.base_url);
    }

    [TearDown]
    public void TearDown()
    {
        if (Driver != null)
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    byte[] content = ((ITakesScreenshot)Driver).GetScreenshot().AsByteArray;
                    AllureApi.AddAttachment("Screenshot on Failure", "image/png", content);
                }
            }
            finally
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}