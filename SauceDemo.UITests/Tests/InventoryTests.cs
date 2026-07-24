using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class InventoryTests:BaseTest
{
    [Test]
    public void AddToCartTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        CartPage cartPage = new CartPage(driver);
        
        inventoryPage.AddToCartClick("Sauce Labs Backpack"); 
        Assert.That(inventoryPage.IsCartBadgeDisplayed(), Is.True);
        Assert.That(inventoryPage.GetCartBadgeText(), Is.EqualTo("1"));

        inventoryPage.CartLinkClick();
        Assert.That(cartPage.IsItemsInCart("Sauce Labs Backpack"), Is.True);
    }

    [Test]
    public void RemoveFromCartTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        
        inventoryPage.AddToCartClick("Sauce Labs Backpack");
        inventoryPage.RemoveFromCartClick("Sauce Labs Backpack");
        Assert.That(inventoryPage.IsCartBadgeDisplayed(), Is.False);
        Assert.That(inventoryPage.IsAddButtonDisplayed("Sauce Labs Backpack"), Is.True);
    }
    
    [Test]
    public void SortItemsByNameAToZTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        
        inventoryPage.SelectSortOption("Name (A to Z)");
        List<string> actualNames = inventoryPage.GetItemNames();
        
        List<string> expectedNames = new List<string>(actualNames);
        expectedNames.Sort();
        Assert.That(actualNames, Is.EqualTo(expectedNames));
    }

    [Test]
    public void SortItemsByNameZToATest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        
        inventoryPage.SelectSortOption("Name (Z to A)");
        List<string> actualNames = inventoryPage.GetItemNames();
        
        List<string> expectedNames = new List<string>(actualNames);
        expectedNames.Sort();
        expectedNames.Reverse();
        Assert.That(actualNames, Is.EqualTo(expectedNames));
    }

    [Test]
    public void SortItemsByPriceLowToHighTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        
        inventoryPage.SelectSortOption("Price (low to high)");
        List<decimal> actualPrices = inventoryPage.GetItemPrices();
        
        List<decimal> expectedPrices = new List<decimal>(actualPrices);
        expectedPrices.Sort();
        Assert.That(actualPrices, Is.EqualTo(expectedPrices));
    }

    [Test]
    public void SortItemsByPriceHighToLowTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        
        inventoryPage.SelectSortOption("Price (high to low)");
        List<decimal> actualPrices = inventoryPage.GetItemPrices();
        
        List<decimal> expectedPrices = new List<decimal>(actualPrices);
        expectedPrices.Sort();
        expectedPrices.Reverse();
        Assert.That(actualPrices, Is.EqualTo(expectedPrices));
    }
    
    [Test]
    public void ItemNameClickTest()
    {
        PerformDefaultLogin();
        
        InventoryItemPage inventoryItemPage = new InventoryItemPage(driver);
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.ItemNameClick("Sauce Labs Backpack");
        Assert.That(driver.Url, Does.Contain("/inventory-item.html"));
        Assert.That(inventoryItemPage.GetItemName(), Is.EqualTo("Sauce Labs Backpack"));
    }
}
