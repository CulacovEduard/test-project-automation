using Allure.Net.Commons.Attributes;
using OpenQA.Selenium;
using TestShopProject.Utilities;

namespace TestShopProject.Pages;

public class MainPage(IWebDriver driver)
{
    private readonly By _registerButton = By.XPath("//a[@class='ico-register']");

    [AllureStep("Нажатие на кнопку 'Register' ")]
    public RegisterPage ClickToRegisterButton()
    {
        var registerButton = WaitHelpers.WaitUntilClickable(driver, _registerButton);
        registerButton.Click();

        return new RegisterPage(driver);
    }
}