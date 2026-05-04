using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Allure.NUnit;
using TestShopProject.Core;
using TestShopProject.Pages;

namespace TestShopProject.Tests;

public class Negative
{

    [AllureNUnit]
    [AllureParentSuite("Web UI Tests")]
    [AllureSuite("User Management")]
    [AllureFeature("Registration")]
    public class Positive : BaseTest
    {
        [Test]
        [AllureName("Успешная регистрация нового пользователя")]
        [AllureDescription("Проверка создания аккаунта с валидными динамическими данными")]
        [AllureTag("Regression", "Smoke")]
        [AllureSeverity(SeverityLevel.critical)]
        public void SuccessRegistrationTest()
        {
            var start = new MainPage(Driver).ClickToRegisterButton()
                .FillRegistrationInformation(TestUser);

            Assert.That(start.GetCompleteMessage(), Is.EqualTo("Your registration completedd"));
        }
    }
}