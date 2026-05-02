using Allure.Net.Commons.Attributes;
using OpenQA.Selenium;
using TestShopProject.Models;
using TestShopProject.Utilities;

namespace TestShopProject.Pages;

public class RegisterPage(IWebDriver driver)
{
    private readonly By _genderCheckbox = By.XPath("//input[@id='gender-male']");
    private readonly By _firstNameInput = By.XPath("//input[@id='FirstName']");
    private readonly By _lastNameInput = By.XPath("//input[@id='LastName']");
    private readonly By _emailInput = By.XPath("//input[@id='Email']");
    private readonly By _passwordInput = By.XPath("//input[@id='Password']");
    private readonly By _confirmPasswordInput = By.XPath("//input[@id='ConfirmPassword']");
    private readonly By _registerButton = By.XPath("//input[@id='register-button']");

    [AllureStep("Заполнение формы регистрации данными пользователя: {0}")]
    public RegisterResultPage FillRegistrationInformation(UserData user)
    {
        ClickToMaleCheckbox();
        FillFirstName(user.FirstName);
        FillLastName(user.LastName);
        FillEmail(user.Email);
        FillPassword(user.Password);
        FillConfirmationPassword(user.Password);

        return CLickRegisterButton();
    }

    [AllureStep("Выбор пола (Male)")]
    public RegisterPage ClickToMaleCheckbox()
    {
        var checkbox = WaitHelpers.WaitUntilClickable(driver, _genderCheckbox);
        checkbox.Click();

        return this;
    }
    
    [AllureStep("Ввод имени: {0}")]
    public RegisterPage FillFirstName(string firstName)
    {
        var firstNameInput = WaitHelpers.WaitUntilVisible(driver, _firstNameInput);
        firstNameInput.SendKeys(firstName);

        return this;
    }
    
    [AllureStep("Ввод фамилии: {0}")]
    public RegisterPage FillLastName(string lastName)
    {
        var lastNameInput = WaitHelpers.WaitUntilVisible(driver, _lastNameInput);
        lastNameInput.SendKeys(lastName);

        return this;
    }
    
    [AllureStep("Ввод емэйла: {0}")]
    public RegisterPage FillEmail(string email)
    {
        var emailInput = WaitHelpers.WaitUntilVisible(driver, _emailInput);
        emailInput.SendKeys(email);

        return this;
    }
    
    [AllureStep("Ввод пароля: {0}")]
    public RegisterPage FillPassword(string password)
    {
        var passwordInput = WaitHelpers.WaitUntilVisible(driver, _passwordInput);
        passwordInput.SendKeys(password);

        return this;
    }
    
    [AllureStep("Повторный ввод пароля: {0}")]
    public RegisterPage FillConfirmationPassword(string password)
    {
        var confirmationPasswordInput = WaitHelpers.WaitUntilVisible(driver, _confirmPasswordInput);
        confirmationPasswordInput.SendKeys(password);

        return this;
    }
    
    [AllureStep("Нажатие наa кнопку 'Register' ")]
    public RegisterResultPage CLickRegisterButton()
    {
        var registerButton = WaitHelpers.WaitUntilClickable(driver, _registerButton);
        registerButton.Click();

        return new RegisterResultPage(driver);
    }

}