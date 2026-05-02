using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestShopProject.Utilities;

public class WaitHelpers
{
    public static IWebElement WaitUntilClickable(IWebDriver driver, By locator, int timeoutInSeconds = 30)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }
        
    public static IWebElement WaitUntilVisible(IWebDriver driver, By locator, int timeoutInSeconds = 30)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public static bool WaitUntilInvisibility(IWebDriver driver, By locator, int timeoutInSeconds = 30)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
    }

       
    public static IReadOnlyCollection<IWebElement> WaitUntilAllVisible(IWebDriver driver, By locator, int timeoutInSeconds = 30)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
    }

       
    public static bool WaitUntilUrlContains(IWebDriver driver, string fraction, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.UrlContains(fraction));
    }
}