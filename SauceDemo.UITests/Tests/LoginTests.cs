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
    
    [Test]
    public void LockedOutUserTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        
        loginPage.LoginAs("locked_out_user", "secret_sauce");
        
        string actualError =  loginPage.GetErrorMessage();
        
        Assert.That(actualError, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    }
}
