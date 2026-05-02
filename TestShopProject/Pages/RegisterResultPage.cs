using Allure.Net.Commons.Attributes;
using OpenQA.Selenium;
using TestShopProject.Utilities;

namespace TestShopProject.Pages;

public class RegisterResultPage(IWebDriver driver)
{
    private readonly By _completeMessage = By.XPath("//div[@class='result']");
    private readonly By _continueButton = By.XPath("//input[@value='Continue']");
    
    public string GetCompleteMessage()
    {
        return driver.FindElement(_completeMessage).Text;
    }
    
    [AllureStep("Нажатие на кнопку 'Continue' ")]
    public MainPage CLickContinueButton()
    {
        var continueButton = WaitHelpers.WaitUntilClickable(driver, _continueButton);
        continueButton.Click();

        return new MainPage(driver);
    }
    
}