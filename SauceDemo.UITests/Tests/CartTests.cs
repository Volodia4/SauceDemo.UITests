using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class CartTests:BaseTest
{
    private void Login()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.LoginAs("standard_user","secret_sauce");
    }

    [Test]
    public void RemoveFromCartTest()
    {
        Login();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartClick("Sauce Labs Backpack");
        inventoryPage.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.RemoveFromCartClick("Sauce Labs Backpack");
        Assert.That(cartPage.IsItemsInCart("Sauce Labs Backpack"), Is.False);
    }

    [Test]
    public void CheckoutTest()
    {
        Login();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.CheckoutClick();
        Assert.That(driver.Url, Does.EndWith("/checkout-step-one.html"));
    }
    
    [Test]
    public void ContinueShoppingTest()
    {
        Login();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.ContinueShoppingClick();
        Assert.That(driver.Url, Does.EndWith("/inventory.html"));
    }
    
    [Test]
    public void CartElementClickTest()
    {
        Login();
        
        InventoryItemPage inventoryItemPage = new InventoryItemPage(driver);
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartClick("Sauce Labs Backpack");
        inventoryPage.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.ItemNameClick("Sauce Labs Backpack");
        Assert.That(driver.Url, Does.Contain("/inventory-item.html"));
        Assert.That(inventoryItemPage.GetItemName(), Is.EqualTo("Sauce Labs Backpack"));
    }
}
