using OpenQA.Selenium;

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
}
