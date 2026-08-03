using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class LoginTests:BaseTest
{
    [Test]
    public void ValidLoginTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.LoginAs("standard_user", "secret_sauce");
    }
    
    [TestCase("locked_out_user", "secret_sauce", "Epic sadface: Sorry, this user has been locked out")]
    [TestCase("standard_user", "wrong_sauce", "Epic sadface: Username and password do not match any user in this service")]
    [TestCase("", "", "Epic sadface: Username is required")]
    public void InvalidLoginTests(string username, string password, string expectedError)
    {
        LoginPage loginPage = new LoginPage(driver);
        
        loginPage.LoginAs(username, password);
        string actualError = loginPage.GetErrorMessage();
        Assert.That(actualError, Is.EqualTo(expectedError));
    }
}
