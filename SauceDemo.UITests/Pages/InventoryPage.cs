using OpenQA.Selenium;

namespace SauceDemo.UITests.Pages;

public class InventoryPage
{
    private IWebDriver _driver;
    
    public InventoryPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By cartLinkBtn = By.CssSelector("[data-test='shopping-cart-link']");
    private By cartBadge = By.CssSelector("[data-test='shopping-cart-badge']");
    
    public void AddToCartClick(string itemName)
    {
        By specificAddBtn = By.XPath($"//div[text()='{itemName}']/ancestor::div[@class='inventory_item']//button[text()='Add to cart']");
        _driver.FindElement(specificAddBtn).Click();
    }

    public void RemoveFromCartClick(string itemName)
    {
        By specificRemoveBtn = By.XPath($"//div[text()='{itemName}']/ancestor::div[@class='inventory_item']//button[text()='Remove']");
        _driver.FindElement(specificRemoveBtn).Click();
    }

    public bool IsAddButtonDisplayed(string itemName)
    {
        By specificButtonText = By.XPath($"//div[text()='{itemName}']/ancestor::div[@class='inventory_item']//button[text()='Add to cart']");
        return _driver.FindElements(specificButtonText).Count > 0;
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
