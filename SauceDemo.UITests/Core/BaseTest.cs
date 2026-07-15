using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.UITests.Core;

public class BaseTest
{
    protected IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Navigate().GoToUrl("https://www.saucedemo.com");
    }

    [TearDown]
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
