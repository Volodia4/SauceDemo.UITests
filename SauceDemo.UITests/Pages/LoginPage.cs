using OpenQA.Selenium;

namespace SauceDemo.UITests.Pages;

public class LoginPage
{
    private IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        this._driver = driver;
    }
    
    private By usernameInput = By.Name("[data-test='username']");
    private By passwordInput = By.Name("[data-test='password']");
    private By loginButton = By.Name("[data-test='login-button']");
    private By errorMessage = By.Name("[data-test='error']");

    public void LoginAs(string username, string password)
    {
        _driver.FindElement(usernameInput).SendKeys(username);
        _driver.FindElement(passwordInput).SendKeys(password);
        _driver.FindElement(loginButton).Click();
    }

    public string GetErrorMessage()
    {
        return _driver.FindElement(errorMessage).Text;
    }
}
