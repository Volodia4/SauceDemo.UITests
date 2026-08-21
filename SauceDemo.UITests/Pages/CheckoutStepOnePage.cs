using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.UITests.Pages;

public class CheckoutStepOnePage
{
    private IWebDriver _driver;

    public CheckoutStepOnePage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By firstNameInput = By.CssSelector("[data-test='firstName']");
    private By lastNameInput = By.CssSelector("[data-test='lastName']");
    private By postalCodeInput = By.CssSelector("[data-test='postalCode']");
    private By errorMessage = By.CssSelector("[data-test='error']");
    private By cancelBtn = By.CssSelector("[data-test='cancel']");
    private By continueBtn = By.CssSelector("[data-test='continue']");

    public void EnterCheckoutInfo(string firstName, string lastName, string postalCode)
    {
        _driver.FindElement(firstNameInput).SendKeys(firstName);
        _driver.FindElement(lastNameInput).SendKeys(lastName);
        _driver.FindElement(postalCodeInput).SendKeys(postalCode);
        _driver.FindElement(continueBtn).Click();
    }

    public bool IsErrorDisplayed()
    {
        return _driver.FindElements(errorMessage).Count > 0;
    }

    public string GetErrorMessage()
    {
        return _driver.FindElement(errorMessage).Text;
    }

    public void CancelClick()
    {
        _driver.FindElement(cancelBtn).Click();
    }

    public bool IsPageLoaded()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(d => d.Url.EndsWith("/checkout-step-one.html"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
