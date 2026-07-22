using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.UITests.Core;

public class BaseTest
{
    protected IWebDriver driver;
    protected string downloadPath;

    [SetUp]
    public void Setup()
    {
        downloadPath = Path.Combine(Directory.GetCurrentDirectory(),"Downloads");
        if (!Directory.Exists(downloadPath))
        {
            Directory.CreateDirectory(downloadPath);
        }
        
        var options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", downloadPath);
        options.AddUserProfilePreference("download.prompt_for_download", false);
        options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
        
        driver = new ChromeDriver(options);
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

        if (Directory.Exists(downloadPath))
        {
            Directory.Delete(downloadPath, true);
        }
    }
}
