using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.UITests.Pages;

public class InventoryPage
{
    private IWebDriver _driver;
    
    public InventoryPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By sortDropdown = By.CssSelector("[data-test='product-sort-container']");
    private By itemNames = By.CssSelector("[data-test='inventory-item-name']");
    private By itemPrices = By.CssSelector("[data-test='inventory-item-price']");
    
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

    public bool IsRemoveButtonDisplayed(string itemName)
    {
        By specificButtonText = By.XPath($"//div[text()='{itemName}']/ancestor::div[@class='inventory_item']//button[text()='Remove']");
        return _driver.FindElements(specificButtonText).Count > 0;
    }
    
    public void ItemNameClick(string itemName)
    {
        By specificItemName = By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemName}']");
        _driver.FindElement(specificItemName).Click();
    }

    public void SelectSortOption(string sortOption)
    {
        var select = new SelectElement(_driver.FindElement(sortDropdown));
        select.SelectByText(sortOption);
    }

    public List<string> GetItemNames()
    {
        var elements = _driver.FindElements(itemNames);
        return elements.Select(e => e.Text).ToList();
    }

    public List<decimal> GetItemPrices()
    {
        var elements = _driver.FindElements(itemPrices);
        return elements.Select(e => decimal.Parse(e.Text.Replace("$", ""), CultureInfo.InvariantCulture)).ToList();
    }

    public bool IsPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(d => d.Url.EndsWith("/inventory.html"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
