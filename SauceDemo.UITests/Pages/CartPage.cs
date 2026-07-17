using OpenQA.Selenium;

namespace SauceDemo.UITests.Pages;

public class CartPage
{
    private IWebDriver _driver;
    
    public CartPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By cartElementHeader = By.CssSelector("[data-test='inventory-item-name']");
    
    public string GetCartElementText()
    {
        return _driver.FindElement(cartElementHeader).Text;
    }
}
