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
    private By removeFromCartBtn = By.CssSelector("[data-test='remove-sauce-labs-backpack']");
    private By inventoryItem = By.CssSelector("[data-test='inventory-item']");
    
    public string GetCartElementText()
    {
        return _driver.FindElement(cartElementHeader).Text;
    }
    
    public void RemoveFromCartClick()
    {
        _driver.FindElement(removeFromCartBtn).Click();
    }
    
    public bool IsItemsInCart()
    {
        return _driver.FindElements(inventoryItem).Count > 0;
    }
}
