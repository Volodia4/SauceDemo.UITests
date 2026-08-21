using SauceDemo.UITests.Components;
using SauceDemo.UITests.Core;

namespace SauceDemo.UITests.Tests;

public class FooterTests:BaseTest
{
    [Test]
    public void TwitterClickTest()
    {
        PerformDefaultLogin();
        
        FooterComponent footerComponent = new FooterComponent(driver);
        footerComponent.TwitterClick();

        var tabs = driver.WindowHandles;
        driver.SwitchTo().Window(tabs[1]);
        Assert.That(footerComponent.IsTwitterPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");

        driver.Close();
        driver.SwitchTo().Window(tabs[0]);
    }
    
    [Test]
    public void FacebookClickTest()
    {
        PerformDefaultLogin();
        
        FooterComponent footerComponent = new FooterComponent(driver);
        footerComponent.FacebookClick();

        var tabs = driver.WindowHandles;
        driver.SwitchTo().Window(tabs[1]);
        Assert.That(footerComponent.IsFacebookPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");

        driver.Close();
        driver.SwitchTo().Window(tabs[0]);
    }
    
    [Test]
    public void LinkedinClickTest()
    {
        PerformDefaultLogin();
        
        FooterComponent footerComponent = new FooterComponent(driver);
        footerComponent.LinkedinClick();

        var tabs = driver.WindowHandles;
        driver.SwitchTo().Window(tabs[1]);
        Assert.That(footerComponent.IsLinkedinPageLoaded(), Is.True, $"URL did not match. Current: {driver.Url}");

        driver.Close();
        driver.SwitchTo().Window(tabs[0]);
    }
}
