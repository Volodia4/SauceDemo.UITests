using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class InventoryTests:BaseTest
{
    private void Login()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.LoginAs("standard_user","secret_sauce");
    }
    
    [Test]
    public void AddToCartTest()
    {
        Login();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        CartPage cartPage = new CartPage(driver);
        
        inventoryPage.AddToCartClick();
        string cartBadgeText = inventoryPage.GetCartBadgeText();
        Assert.That(cartBadgeText,Is.EqualTo("1"));
        
        inventoryPage.CartLinkClick();
        string cartElementText = cartPage.GetCartElementText();
        Assert.That(cartElementText, Is.EqualTo("Sauce Labs Backpack"));
    }
}
