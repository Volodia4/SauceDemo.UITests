using SauceDemo.UITests.Components;
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
        inventoryPage.AddToCartClick(config["Inventory:TargetItemName"]);
        Assert.That(inventoryPage.IsRemoveButtonDisplayed(config["Inventory:TargetItemName"]), Is.True);
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        Assert.That(headerComponent.IsCartBadgeDisplayed(), Is.True);
        Assert.That(headerComponent.GetCartBadgeText(), Is.EqualTo("1"));
        
        CartPage cartPage = new CartPage(driver);
        headerComponent.CartLinkClick();
        Assert.That(cartPage.IsItemsInCart(config["Inventory:TargetItemName"]), Is.True);
    }

    [Test]
    public void RemoveFromCartTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        
        inventoryPage.AddToCartClick(config["Inventory:TargetItemName"]);
        inventoryPage.RemoveFromCartClick(config["Inventory:TargetItemName"]);
        Assert.That(inventoryPage.IsAddButtonDisplayed(config["Inventory:TargetItemName"]), Is.True);
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        Assert.That(headerComponent.IsCartBadgeDisplayed(), Is.False);
    }
    
    [Test]
    public void SortItemsByNameAToZTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.SelectSortOption(config["Inventory:SortOptionAZ"]);
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
        inventoryPage.SelectSortOption(config["Inventory:SortOptionZA"]);
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
        inventoryPage.SelectSortOption(config["Inventory:SortOptionLoHi"]);
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
        inventoryPage.SelectSortOption(config["Inventory:SortOptionHiLo"]);
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
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.ItemNameClick(config["Inventory:TargetItemName"]);
        
        InventoryItemPage inventoryItemPage = new InventoryItemPage(driver);
        Assert.That(inventoryItemPage.IsPageLoaded(), Is.True);
        Assert.That(inventoryItemPage.GetItemName(), Is.EqualTo(config["Inventory:TargetItemName"]));
    }
}
