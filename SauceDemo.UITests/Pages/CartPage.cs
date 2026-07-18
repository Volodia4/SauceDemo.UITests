using OpenQA.Selenium;

namespace SauceDemo.UITests.Pages;

public class CartPage
{
    private IWebDriver _driver;
    
    public CartPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By cartElementName = By.CssSelector("[data-test='inventory-item-name']");
    private By removeFromCartBtn = By.CssSelector("[data-test='remove-sauce-labs-backpack']");
    private By inventoryItem = By.CssSelector("[data-test='inventory-item']");
    private By checkoutBtn = By.CssSelector("[data-test='checkout']");
    private By continueShoppingBtn = By.CssSelector("[data-test='continue-shopping']");
    
    public string GetCartElementText()
    {
        return _driver.FindElement(cartElementName).Text;
    }
    
    public void RemoveFromCartClick()
    {
        _driver.FindElement(removeFromCartBtn).Click();
    }
    
    public bool IsItemsInCart()
    {
        return _driver.FindElements(inventoryItem).Count > 0;
    }

    public void CheckoutClick()
    {
        _driver.FindElement(checkoutBtn).Click();
    }
    
    public void ContinueShoppingClick()
    {
        _driver.FindElement(continueShoppingBtn).Click();
    }

    public void ItemNameClick()
    {
        _driver.FindElement(cartElementName).Click();
    }
}
