using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.UITests.Components;

public class FooterComponent
{
    private IWebDriver _driver;

    public FooterComponent(IWebDriver driver)
    {
        _driver = driver;
    }

    private By twitterBtn = By.CssSelector("[data-test='social-twitter']");
    private By facebookBtn = By.CssSelector("[data-test='social-facebook']");
    private By linkedinBtn = By.CssSelector("[data-test='social-linkedin']");

    public void TwitterClick()
    {
        _driver.FindElement(twitterBtn).Click();
    }

    public void FacebookClick()
    {
        _driver.FindElement(facebookBtn).Click();
    }

    public void LinkedinClick()
    {
        _driver.FindElement(linkedinBtn).Click();
    }

    public bool IsTwitterPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.Url.Contains("https://x.com/"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public bool IsFacebookPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.Url.Contains("https://www.facebook.com/"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public bool IsLinkedinPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.Url.Contains("https://www.linkedin.com/"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
