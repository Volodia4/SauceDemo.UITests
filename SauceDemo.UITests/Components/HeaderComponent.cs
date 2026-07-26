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
    }

    public void BurgerMenuCloseClick()
    {
        _driver.FindElement(burgerMenuCloseBtn).Click();
    }

    public void AllItemsClick()
    {
        _driver.FindElement(allItemsBtn).Click();
    }

    public void AboutClick()
    {
        _driver.FindElement(aboutBtn).Click();
    }

    public void LogoutClick()
    {
        _driver.FindElement(logoutBtn).Click();
    }

    public void ResetClick()
    {
        _driver.FindElement(resetBtn).Click();
    }

    public bool IsBurgerMenuOpen()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.FindElement(By.CssSelector(".bm-menu-wrap")).GetAttribute("aria-hidden") != "true");
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public bool IsBurgerMenuClosed()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.FindElement(By.CssSelector(".bm-menu-wrap")).GetAttribute("aria-hidden") == "true");
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
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
