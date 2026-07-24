using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class InventoryItemTests:BaseTest
{
    [Test]
    public void AddToCartTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.ItemNameClick("Sauce Labs Backpack");
        
        InventoryItemPage inventoryItemPage = new InventoryItemPage(driver);
        inventoryItemPage.AddToCartClick();
        Assert.That(inventoryItemPage.IsRemovingBtnDisplayed(), Is.True);
        Assert.That(inventoryItemPage.IsCartBadgeDisplayed(), Is.True);
        Assert.That(inventoryItemPage.GetCartBadgeText(), Is.EqualTo("1"));
    }

    [Test]
    public void RemoveFromCartTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.ItemNameClick("Sauce Labs Backpack");
        
        InventoryItemPage inventoryItemPage = new InventoryItemPage(driver);
        inventoryItemPage.AddToCartClick();
        inventoryItemPage.RemoveFromCartClick();
        Assert.That(inventoryItemPage.IsAddingBtnDisplayed(), Is.True);
        Assert.That(inventoryItemPage.IsCartBadgeDisplayed(), Is.False);
    }
    
    [Test]
    public void BackClickTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.ItemNameClick("Sauce Labs Backpack");
        
        InventoryItemPage inventoryItemPage = new InventoryItemPage(driver);
        inventoryItemPage.BackClick();
        Assert.That(driver.Url, Does.EndWith("/inventory.html"));
    }
}
