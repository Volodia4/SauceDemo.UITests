using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class CheckoutTests:BaseTest
{
    private void Login()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.LoginAs("standard_user", "secret_sauce");
    }
    
    private void GoToCheckoutPage()
    {
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.CheckoutClick();
    }
    
    [TestCase("","","","Error: First Name is required")]
    [TestCase("FirstName","","","Error: Last Name is required")]
    [TestCase("FirstName","LastName","","Error: Postal Code is required")]
    public void InputInfoErrorTest(string firstName, string lastName, string postalCode, string errorText)
    {
        Login();
        GoToCheckoutPage();
        
        CheckoutPage checkoutPage = new CheckoutPage(driver);
        
        checkoutPage.EnterCheckoutInfo(firstName,lastName,postalCode);
        Assert.That(checkoutPage.IsErrorDisplayed(), Is.True);
        Assert.That(checkoutPage.GetErrorMessage(), Is.EqualTo(errorText));
    }
    
    [Test]
    public void InputInfoSuccessTest()
    {
        Login();
        GoToCheckoutPage();
        
        CheckoutPage checkoutPage = new CheckoutPage(driver);
        checkoutPage.EnterCheckoutInfo("FirstName","LastName","PostalCode");
        Assert.That(driver.Url, Does.EndWith("/checkout-step-two.html"));
    }
    
    [Test]
    public void CancelStepOneTest()
    {
        Login();
        GoToCheckoutPage();
        
        CheckoutPage checkoutPage = new CheckoutPage(driver);
        checkoutPage.CancelClick();
        Assert.That(driver.Url, Does.EndWith("/cart.html"));
    }
    
    [Test]
    public void CancelStepTwoTest()
    {
        Login();
        GoToCheckoutPage();
        
        CheckoutPage checkoutPage = new CheckoutPage(driver);
        checkoutPage.EnterCheckoutInfo("FirstName","LastName","PostalCode");
        checkoutPage.CancelClick();
        Assert.That(driver.Url, Does.EndWith("/inventory.html"));
    }
    
    [Test]
    public void FinishClickTest()
    {
        Login();
        GoToCheckoutPage();
        
        CheckoutPage checkoutPage = new CheckoutPage(driver);
        checkoutPage.EnterCheckoutInfo("FirstName","LastName","PostalCode");
        checkoutPage.FinishClick();
        Assert.That(driver.Url, Does.EndWith("/checkout-complete.html"));
    }
}
