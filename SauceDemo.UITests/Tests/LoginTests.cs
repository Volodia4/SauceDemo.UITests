using System.Text.Json;
using SauceDemo.UITests.Core;
using SauceDemo.UITests.Models;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class LoginTests:BaseTest
{
    [Test]
    public void ValidLoginTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.LoginAs(config["Credentials:Username"], config["Credentials:Password"]);
    }

    public static IEnumerable<TestCaseData> GetLoginData()
    {
        string json = File.ReadAllText("testdata.json");
        var rootData = JsonSerializer.Deserialize<TestDataRoot>(json);

        foreach (var data in rootData.InvalidLogins)
        {
            yield return new TestCaseData(data.Username, data.Password, data.ExpectedError);
        }
    }
    
    [Test, TestCaseSource(nameof(GetLoginData))]
    public void InvalidLoginTests(string username, string password, string expectedError)
    {
        LoginPage loginPage = new LoginPage(driver);
        
        loginPage.LoginAs(username, password);
        string actualError = loginPage.GetErrorMessage();
        
        Assert.That(actualError, Is.EqualTo(expectedError), $"Error message did not match. Current: {actualError}");
    }
}
