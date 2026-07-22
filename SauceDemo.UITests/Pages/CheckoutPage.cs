using OpenQA.Selenium;

namespace SauceDemo.UITests.Pages;

public class CheckoutPage
{
    private IWebDriver _driver;

    public CheckoutPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By firstNameInput = By.CssSelector("[data-test='firstName']");
    private By lastNameInput = By.CssSelector("[data-test='lastName']");
    private By postalCodeInput = By.CssSelector("[data-test='postalCode']");
    private By errorMessage = By.CssSelector("[data-test='error']");
    private By cancelBtn = By.CssSelector("[data-test='cancel']");
    private By continueBtn = By.CssSelector("[data-test='continue']");
    private By finishBtn = By.CssSelector("[data-test='finish']");

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

    public void FinishClick()
    {
        _driver.FindElement(finishBtn).Click();
    }
}
