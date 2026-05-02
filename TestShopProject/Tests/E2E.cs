using TestShopProject.Core;
using TestShopProject.Pages;

namespace TestShopProject.Tests;

public class E2E : BaseTest
{
    [Test]
    public void RegisterTest()
    {
        var start = new MainPage(Driver).ClickToRegisterButton();
    }
}