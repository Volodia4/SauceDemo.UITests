using OpenQA.Selenium;

namespace SauceDemo.UITests.Pages;

public class InventoryItemPage
{
    private IWebDriver _driver;
    
    public  InventoryItemPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private By addToCartBtn = By.CssSelector("[data-test='add-to-cart']");
    private By backBtn = By.CssSelector("[data-test='back-to-products']");

    public void AddToCartClick()
    {
        _driver.FindElement(addToCartBtn).Click();
    }

    public void BackClick()
    {
        _driver.FindElement(backBtn).Click();
    }
}
