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
        inventoryPage.AddToCartClick();
        inventoryPage.CartLinkClick();
        
        CartPage cartPage = new CartPage(driver);
        cartPage.RemoveFromCartClick();
        Assert.That(cartPage.IsItemsInCart(), Is.False);
    }
}
