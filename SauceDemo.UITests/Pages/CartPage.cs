using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.UITests.Pages;

public class CartPage
{
    private IWebDriver _driver;
    
    public CartPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By checkoutBtn = By.CssSelector("[data-test='checkout']");
    private By continueShoppingBtn = By.CssSelector("[data-test='continue-shopping']");
    
    public void ItemNameClick(string itemName)
    {
        By specificItemName = By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemName}']");
        _driver.FindElement(specificItemName).Click();
    }
    
    public bool IsItemsInCart(string itemName)
    {
        By specificItemName = By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemName}']");
        return _driver.FindElements(specificItemName).Count > 0;
    }
    
    public void RemoveFromCartClick(string itemName)
    {
        By specificRemoveBtn = By.XPath($"//div[text()='{itemName}']/ancestor::div[@class='cart_item']//button[text()='Remove']");
        _driver.FindElement(specificRemoveBtn).Click();
    }

    public void CheckoutClick()
    {
        _driver.FindElement(checkoutBtn).Click();
    }
    
    public void ContinueShoppingClick()
    {
        _driver.FindElement(continueShoppingBtn).Click();
    }

    public bool IsPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.Url.EndsWith("/cart.html"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
