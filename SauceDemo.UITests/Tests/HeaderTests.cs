using SauceDemo.UITests.Components;
using SauceDemo.UITests.Core;
using SauceDemo.UITests.Pages;

namespace SauceDemo.UITests.Tests;

public class HeaderTests:BaseTest
{
    [Test]
    public void BurgerMenuOpenTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.BurgerMenuOpenClick();
        Assert.That(headerComponent.IsBurgerMenuOpen(), Is.True);
    }
    
    [Test]
    public void BurgerMenuCloseTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.BurgerMenuOpenClick();
        headerComponent.IsBurgerMenuOpen();
        headerComponent.BurgerMenuCloseClick();
        Assert.That(headerComponent.IsBurgerMenuClosed(), Is.True);
    }
    
    [Test]
    public void AllItemsClickTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.CartLinkClick();
        headerComponent.BurgerMenuOpenClick();
        headerComponent.IsBurgerMenuOpen();
        headerComponent.AllItemsClick();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        Assert.That(inventoryPage.IsPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");
    }
    
    [Test]
    public void AboutClickTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.BurgerMenuOpenClick();
        headerComponent.IsBurgerMenuOpen();
        headerComponent.AboutClick();
        Assert.That(headerComponent.IsAboutPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");
    }
    
    [Test]
    public void LogoutClickTest()
    {
        PerformDefaultLogin();
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        headerComponent.BurgerMenuOpenClick();
        headerComponent.IsBurgerMenuOpen();
        headerComponent.LogoutClick();
        
        LoginPage loginPage = new LoginPage(driver);
        Assert.That(loginPage.IsLoggedOut(), Is.True);
    }
    
    [Test]
    public void ResetClickTest()
    {
        PerformDefaultLogin();
        
        InventoryPage inventoryPage = new InventoryPage(driver);
        inventoryPage.AddToCartClick(config["Inventory:TargetItemName"]);
        
        HeaderComponent headerComponent = new HeaderComponent(driver);
        Assert.That(headerComponent.IsCartBadgeDisplayed(), Is.True);
        headerComponent.BurgerMenuOpenClick();
        headerComponent.IsBurgerMenuOpen();
        headerComponent.ResetClick();
        Assert.That(headerComponent.IsCartBadgeHidden(), Is.True);
    }
}
