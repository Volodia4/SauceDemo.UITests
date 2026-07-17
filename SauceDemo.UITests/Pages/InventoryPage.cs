using OpenQA.Selenium;

namespace SauceDemo.UITests.Pages;

public class InventoryPage
{
    private IWebDriver _driver;
    
    public InventoryPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By addToCartBtn = By.CssSelector("[data-test='add-to-cart-sauce-labs-backpack']");
    private By removeFromCartBtn = By.CssSelector("[data-test='remove-sauce-labs-backpack']");
    private By cartLinkBtn = By.CssSelector("[data-test='shopping-cart-link']");
    private By cartBadge = By.CssSelector("[data-test='shopping-cart-badge']");
    
    public void AddToCartClick()
    {
        _driver.FindElement(addToCartBtn).Click();
    }

    public void RemoveFromCartClick()
    {
        _driver.FindElement(removeFromCartBtn).Click();
    }

    public string GetAddToCartButtonText()
    {
        return _driver.FindElement(addToCartBtn).Text;
    }

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
