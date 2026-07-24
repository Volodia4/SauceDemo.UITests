using SauceDemo.UITests.Components;
using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class CartTests:BaseTest
{
    [Test]
    public void RemoveFromCartTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartClick("Sauce Labs Backpack");
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.RemoveFromCartClick("Sauce Labs Backpack");
        Assert.That(cartPage.IsItemsInCart("Sauce Labs Backpack"), Is.False);
    }

    [Test]
    public void CheckoutTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.CheckoutClick();
        Assert.That(driver.Url, Does.EndWith("/checkout-step-one.html"));
    }
    
    [Test]
    public void ContinueShoppingTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.ContinueShoppingClick();
        Assert.That(driver.Url, Does.EndWith("/inventory.html"));
    }
    
    [Test]
    public void CartElementClickTest()
    {
        PerformDefaultLogin();
        
        InventoryItemPage inventoryItemPage = new InventoryItemPage(driver);
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartClick("Sauce Labs Backpack");
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.ItemNameClick("Sauce Labs Backpack");
        Assert.That(driver.Url, Does.Contain("/inventory-item.html"));
        Assert.That(inventoryItemPage.GetItemName(), Is.EqualTo("Sauce Labs Backpack"));
    }
}
