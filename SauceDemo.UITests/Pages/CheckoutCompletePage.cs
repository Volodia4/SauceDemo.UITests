using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.UITests.Pages;

public class CheckoutCompletePage
{
    private IWebDriver _driver;

    public CheckoutCompletePage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By backBtn = By.CssSelector("[data-test='back-to-products']");
    private By generatePdfBtn = By.CssSelector("[data-test='generate-pdf-order']");

    public void BackClick()
    {
        _driver.FindElement(backBtn).Click();
    }

    public void GeneratePdfClick()
    {
        _driver.FindElement(generatePdfBtn).Click();
    }

    public bool IsPdfDownloaded(string downloadPath)
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            return wait.Until(d => Directory.GetFiles(downloadPath, "*.pdf").Length > 0);
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public bool IsPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.Url.EndsWith("/checkout-complete.html"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
