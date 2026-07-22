using OpenQA.Selenium;

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
}
