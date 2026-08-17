using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
    private By burgerMenuOpenBtn = By.Id("react-burger-menu-btn");
    private By burgerMenuCloseBtn = By.Id("react-burger-cross-btn");
    private By allItemsBtn = By.CssSelector("[data-test='inventory-sidebar-link']");
    private By aboutBtn = By.CssSelector("[data-test='about-sidebar-link']");
    private By logoutBtn = By.CssSelector("[data-test='logout-sidebar-link']");
    private By resetBtn = By.CssSelector("[data-test='reset-sidebar-link']");

    private void ClickThroughJs(By locator)
    {
        var element = _driver.FindElement(locator);
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
    }

    public void CartLinkClick()
    {
        _driver.FindElement(cartLinkBtn).Click();
    }

    public bool IsCartBadgeDisplayed()
    {
        return _driver.FindElements(cartBadge).Count > 0;
    }

    public bool IsCartBadgeHidden()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.FindElements(cartBadge).Count == 0);
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
    
    public string GetCartBadgeText()
    {
        return _driver.FindElement(cartBadge).Text;
    }

    public void BurgerMenuOpenClick()
    {
        _driver.FindElement(burgerMenuOpenBtn).Click();

        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(d => d.FindElement(burgerMenuCloseBtn).Displayed);
    }

    public void BurgerMenuCloseClick()
    {
        ClickThroughJs(burgerMenuCloseBtn);
    }

    public void AllItemsClick()
    {
        ClickThroughJs(allItemsBtn);
    }

    public void AboutClick()
    {
        ClickThroughJs(aboutBtn);
    }

    public void LogoutClick()
    {
        ClickThroughJs(logoutBtn);
    }

    public void ResetClick()
    {
        ClickThroughJs(resetBtn);
    }

    public bool IsBurgerMenuOpen()
    {
        return _driver.FindElement(By.CssSelector(".bm-menu-wrap")).GetAttribute("aria-hidden") != "true";
    }

    public bool IsBurgerMenuClosed()
    {
        return _driver.FindElement(By.CssSelector(".bm-menu-wrap")).GetAttribute("aria-hidden") == "true";
    }

    public bool IsAboutPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.Url == "https://saucelabs.com/");
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
