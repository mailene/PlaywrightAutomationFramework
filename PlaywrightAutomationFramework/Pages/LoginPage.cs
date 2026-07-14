using Microsoft.Playwright;
using PlaywrightAutomationFramework.Configuration;
namespace PlaywrightAutomationFramework.Pages;

// "Pass this IPage object up to my parent class."
public class LoginPage : BasePage
{
    private const string Route = "/practice-test-login/";
    private ILocator UsernameTextBox => Page.Locator("#username");
    private ILocator PasswordTextBox => Page.Locator("#password");
    private ILocator LoginButton => Page.Locator("#login");
    public LoginPage(IPage page) : base(page) //"Pass this IPage object up to my parent class (BasePage)."
    {
        

    }

    /// <summary>
    /// Navigates to the login page.
    /// </summary>
    public async Task NavigateAsync()
    {

        await Page.GotoAsync($"{TestConfiguration.BaseUrl}{Route}");
    }

    /// <summary>
    /// Logs into the application using the supplied credentials.
    /// </summary>
    /// <param name="username">Application username.</param>
    /// <param name="password">Application password.</param>
    public async Task LoginAsync(string username, string password)
    {
        await FillAsync(UsernameTextBox, username);
        await FillAsync(PasswordTextBox, password);
        await ClickAsync(LoginButton);
    }
}