using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.UITests.Pages;

public class InventoryItemPage
{
    private IWebDriver _driver;
    
    public  InventoryItemPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By addToCartBtn = By.CssSelector("[data-test='add-to-cart']");
    private By removeFromCartBtn = By.CssSelector("[data-test='remove']");
    private By backBtn = By.CssSelector("[data-test='back-to-products']");
    private By itemName = By.CssSelector("[data-test='inventory-item-name']");

    public void AddToCartClick()
    {
        _driver.FindElement(addToCartBtn).Click();
    }

    public void RemoveFromCartClick()
    {
        _driver.FindElement(removeFromCartBtn).Click();
    }

    public bool IsAddingBtnDisplayed()
    {
        return _driver.FindElements(addToCartBtn).Count > 0;
    }
    
    public bool IsRemovingBtnDisplayed()
    {
        return _driver.FindElements(removeFromCartBtn).Count > 0;
    }

    public void BackClick()
    {
        _driver.FindElement(backBtn).Click();
    }

    public string GetItemName()
    {
        return _driver.FindElement(itemName).Text;
    }

    public bool IsPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(d => d.Url.Contains("/inventory-item.html"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
