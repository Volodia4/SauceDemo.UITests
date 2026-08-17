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
        inventoryPage.AddToCartClick(config["Inventory:TargetItemName"]);
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.RemoveFromCartClick(config["Inventory:TargetItemName"]);
        Assert.That(cartPage.IsItemsInCart(config["Inventory:TargetItemName"]), Is.False);
    }

    [Test]
    public void CheckoutTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.CheckoutClick();
        
        CheckoutStepOnePage checkoutStepOnePage = new CheckoutStepOnePage(driver);
        Assert.That(checkoutStepOnePage.IsPageLoaded(), Is.True);
    }
    
    [Test]
    public void ContinueShoppingTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.ContinueShoppingClick();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        Assert.That(inventoryPage.IsPageLoaded(), Is.True);
    }
    
    [Test]
    public void CartElementClickTest()
    {
        PerformDefaultLogin();
        
        InventoryItemPage inventoryItemPage = new InventoryItemPage(driver);
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartClick(config["Inventory:TargetItemName"]);
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.ItemNameClick(config["Inventory:TargetItemName"]);
        Assert.That(inventoryItemPage.IsPageLoaded(), Is.True);
        Assert.That(inventoryItemPage.GetItemName(), Is.EqualTo(config["Inventory:TargetItemName"]));
    }
}
