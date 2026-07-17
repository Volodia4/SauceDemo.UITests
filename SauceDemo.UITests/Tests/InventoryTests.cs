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
        Assert.That(inventoryPage.IsCartBadgeDisplayed(), Is.True);
        Assert.That(inventoryPage.GetCartBadgeText(), Is.EqualTo("1"));

        inventoryPage.CartLinkClick();
        Assert.That(cartPage.GetCartElementText(), Is.EqualTo("Sauce Labs Backpack"));
    }

    [Test]
    public void RemoveFromCartTest()
    {
        Login();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        
        inventoryPage.AddToCartClick();
        inventoryPage.RemoveFromCartClick();
        Assert.That(inventoryPage.IsCartBadgeDisplayed(), Is.False);
        Assert.That(inventoryPage.GetAddToCartButtonText(), Is.EqualTo("Add to cart"));
    }
}
