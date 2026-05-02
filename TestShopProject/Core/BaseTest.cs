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
    protected IWebDriver Driver;
    protected TestSettings Settings;
    protected UserData TestUser;

    [SetUp]
    public void Setup()
    {
        Settings = ConfigReader.LoadSettings();
        TestUser = DataGenerator.GenerateUser();

        switch (Settings.browser.ToLower())
        {
            case "chrome":
                Driver = new ChromeDriver();
                break;
            case "firefox":
                Driver = new FirefoxDriver();
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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                byte[] content = ((ITakesScreenshot)Driver).GetScreenshot().AsByteArray;
                AllureApi.AddAttachment("Screenshot on Failure", "image/png", content);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}