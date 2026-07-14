using NUnit.Framework;
using PlaywrightAutomationFramework.Browser;
using PlaywrightAutomationFramework.Pages;
using PlaywrightAutomationFramework.TestData;





[TestFixture]//[TestFixture] is an attribute that marks this class as a test fixture. A test fixture is a class that contains tests.
public class LoginTests
{
     [Test]
    public async Task LaunchBrowser_Should_OpenChromium()
    {
        await using var browserManager = new BrowserManager();
        await browserManager.LaunchBrowserAsync();

        var page = await browserManager.CreatePageAsync();
        var loginPage = new LoginPage(page);
        var dashboardPage = new DashboardPage(page);

        await loginPage.NavigateAsync();

        await loginPage.LoginAsync(
            LoginData.ValidUsername,
            LoginData.ValidPassword);

        Assert.That(await dashboardPage.IsLoadedAsync());
    }

    public Task LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
    public Task NavigateAsync(string url)
    {
        throw new NotImplementedException();
    }
}