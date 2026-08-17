using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.UITests.Pages;

public class CheckoutStepTwoPage
{
    private IWebDriver _driver;

    public CheckoutStepTwoPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By cancelBtn = By.CssSelector("[data-test='cancel']");
    private By finishBtn = By.CssSelector("[data-test='finish']");

    public void CancelClick()
    {
        _driver.FindElement(cancelBtn).Click();
    }

    public void FinishClick()
    {
        _driver.FindElement(finishBtn).Click();
    }

    public bool IsPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.Url.EndsWith("/checkout-step-two.html"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
