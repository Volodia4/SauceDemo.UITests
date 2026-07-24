using OpenQA.Selenium;

namespace SauceDemo.UITests.Components;

public class HeaderComponent
{
    private IWebDriver _driver;
    
    public HeaderComponent(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By cartLinkBtn = By.CssSelector("[data-test='shopping-cart-link']");
    private By cartBadge = By.CssSelector("[data-test='shopping-cart-badge']");

    public void CartLinkClick()
    {
        _driver.FindElement(cartLinkBtn).Click();
    }

    public bool IsCartBadgeDisplayed()
    {
        return _driver.FindElements(cartBadge).Count > 0;
    }
    
    public string GetCartBadgeText()
    {
        return _driver.FindElement(cartBadge).Text;
    }
}
