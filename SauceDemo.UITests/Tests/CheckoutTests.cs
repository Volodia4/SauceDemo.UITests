using OpenQA.Selenium.Support.UI;
using SauceDemo.UITests.Components;
using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class CheckoutTests : BaseTest
{
    private void GoToCheckoutPage()
    {
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartClick("Sauce Labs Backpack");
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.CheckoutClick();
    }
    
    [TestCase("","","","Error: First Name is required")]
    [TestCase("FirstName","","","Error: Last Name is required")]
    [TestCase("FirstName","LastName","","Error: Postal Code is required")]
    public void InputInfoErrorTest(string firstName, string lastName, string postalCode, string errorText)
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        
        stepOnePage.EnterCheckoutInfo(firstName, lastName, postalCode);
        Assert.That(stepOnePage.IsErrorDisplayed(), Is.True);
        Assert.That(stepOnePage.GetErrorMessage(), Is.EqualTo(errorText));
    }
    
    [Test]
    public void InputInfoSuccessTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo("FirstName", "LastName", "PostalCode");
        Assert.That(driver.Url, Does.EndWith("/checkout-step-two.html"));
    }
    
    [Test]
    public void CancelStepOneTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.CancelClick();
        Assert.That(driver.Url, Does.EndWith("/cart.html"));
    }
    
    [Test]
    public void CancelStepTwoTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo("FirstName", "LastName", "PostalCode");
        
        CheckoutStepTwoPage stepTwoPage = new CheckoutStepTwoPage(driver);
        stepTwoPage.CancelClick();
        Assert.That(driver.Url, Does.EndWith("/inventory.html"));
    }
    
    [Test]
    public void FinishClickTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo("FirstName", "LastName", "PostalCode");
        
        CheckoutStepTwoPage stepTwoPage = new CheckoutStepTwoPage(driver);
        stepTwoPage.FinishClick();
        Assert.That(driver.Url, Does.EndWith("/checkout-complete.html"));
    }
    
    [Test]
    public void BackClickTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo("FirstName", "LastName", "PostalCode");
        
        CheckoutStepTwoPage stepTwoPage = new CheckoutStepTwoPage(driver);
        stepTwoPage.FinishClick();
        
        CheckoutCompletePage completePage = new CheckoutCompletePage(driver);
        completePage.BackClick();
        Assert.That(driver.Url, Does.EndWith("/inventory.html"));
    }
    
    [Test]
    public void DownloadPdfTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo("FirstName", "LastName", "PostalCode");
        
        CheckoutStepTwoPage stepTwoPage = new CheckoutStepTwoPage(driver);
        stepTwoPage.FinishClick();

        if (Directory.Exists(downloadPath))
        {
            var oldFiles = Directory.GetFiles(downloadPath, "*.pdf");
            foreach (var oldFile in oldFiles)
            {
                File.Delete(oldFile);
            }
        }
        
        CheckoutCompletePage completePage = new CheckoutCompletePage(driver);
        completePage.GeneratePdfClick();

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        bool isFileDownloaded = wait.Until(d => Directory.GetFiles(downloadPath, "*.pdf").Length > 0);

        Assert.That(isFileDownloaded, Is.True);
    }
}
