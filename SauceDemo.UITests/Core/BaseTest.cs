using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Core;

public class BaseTest
{
    protected IWebDriver driver;
    protected string downloadPath;
    protected IConfigurationRoot config;
    
    protected void PerformDefaultLogin()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.LoginAs(config["Credentials:Username"], config["Credentials:Password"]);
    }

    [SetUp]
    public void Setup()
    {
        config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("testdata.json", optional: false, reloadOnChange: true)
            .Build();
        
        string browser = config["Browser"];
        bool isHeadless = bool.Parse(config["Headless"]);
        
        downloadPath = Path.Combine(Directory.GetCurrentDirectory(),"Downloads");
        if (!Directory.Exists(downloadPath))
        {
            Directory.CreateDirectory(downloadPath);
        }
        
        var options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", downloadPath);
        options.AddUserProfilePreference("download.prompt_for_download", false);
        options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);

        if (isHeadless)
        {
            options.AddArguments("--headless");
            options.AddArguments("--window-size=1920,1080");
        }

        if (browser.ToLower() == "chrome") driver = new ChromeDriver(options);
        else throw new Exception($"Browser {browser} not supported");
        
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(config["BaseURL"]);
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
