using System.Text.Json;
using SauceDemo.UITests.Components;
using SauceDemo.UITests.Core;
using SauceDemo.UITests.Models;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class CheckoutTests : BaseTest
{
    private void GoToCheckoutPage()
    {
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartClick(config["Inventory:TargetItemName"]);
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.CheckoutClick();
    }

    public static IEnumerable<TestCaseData> GetCheckoutInputData()
    {
        string json = File.ReadAllText("testdata.json");
        var rootData = JsonSerializer.Deserialize<TestDataRoot>(json);
        
        foreach (var data in rootData.InvalidCheckoutInputData)
        {
            yield return new TestCaseData(data.FirstName, data.LastName, data.PostalCode, data.ErrorText);
        }
    }
    
    [Test, TestCaseSource(nameof(GetCheckoutInputData))]
    public void InputInfoErrorTest(string firstName, string lastName, string postalCode, string errorText)
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        
        stepOnePage.EnterCheckoutInfo(firstName, lastName, postalCode);
        Assert.That(stepOnePage.IsErrorDisplayed(), Is.True);
        Assert.That(stepOnePage.GetErrorMessage(), Is.EqualTo(errorText), $"Error message did not match. Current: {stepOnePage.GetErrorMessage()}");
    }
    
    [Test]
    public void InputInfoSuccessTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo(
            config["ValidCheckoutInputData:FirstName"],
            config["ValidCheckoutInputData:LastName"],
            config["ValidCheckoutInputData:PostalCode"]
            );
        
        CheckoutStepTwoPage checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
        Assert.That(checkoutStepTwoPage.IsPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");
    }
    
    [Test]
    public void CancelStepOneTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.CancelClick();
        
        CartPage cartPage = new CartPage(driver);
        Assert.That(cartPage.IsPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");
    }
    
    [Test]
    public void CancelStepTwoTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo(
            config["ValidCheckoutInputData:FirstName"],
            config["ValidCheckoutInputData:LastName"],
            config["ValidCheckoutInputData:PostalCode"]
        );
        
        CheckoutStepTwoPage stepTwoPage = new CheckoutStepTwoPage(driver);
        stepTwoPage.CancelClick();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        Assert.That(inventoryPage.IsPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");
    }
    
    [Test]
    public void FinishClickTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo(
            config["ValidCheckoutInputData:FirstName"],
            config["ValidCheckoutInputData:LastName"],
            config["ValidCheckoutInputData:PostalCode"]
        );
        
        CheckoutStepTwoPage stepTwoPage = new CheckoutStepTwoPage(driver);
        stepTwoPage.FinishClick();
        
        CheckoutCompletePage completePage = new CheckoutCompletePage(driver);
        Assert.That(completePage.IsPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");
    }
    
    [Test]
    public void BackClickTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
        
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo(
            config["ValidCheckoutInputData:FirstName"],
            config["ValidCheckoutInputData:LastName"],
            config["ValidCheckoutInputData:PostalCode"]
        );
        
        CheckoutStepTwoPage stepTwoPage = new CheckoutStepTwoPage(driver);
        stepTwoPage.FinishClick();
        
        CheckoutCompletePage completePage = new CheckoutCompletePage(driver);
        completePage.BackClick();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        Assert.That(inventoryPage.IsPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");
    }
    
    [Test]
    public void DownloadPdfTest()
    {
        PerformDefaultLogin();
        GoToCheckoutPage();
    
        CheckoutStepOnePage stepOnePage = new CheckoutStepOnePage(driver);
        stepOnePage.EnterCheckoutInfo(
            config["ValidCheckoutInputData:FirstName"],
            config["ValidCheckoutInputData:LastName"],
            config["ValidCheckoutInputData:PostalCode"]
        );
    
        CheckoutStepTwoPage stepTwoPage = new CheckoutStepTwoPage(driver);
        stepTwoPage.FinishClick();

        CheckoutCompletePage completePage = new CheckoutCompletePage(driver);
        completePage.GeneratePdfClick();
        Assert.That(completePage.IsPdfDownloaded(downloadPath), Is.True);
    }
}
