using Microsoft.Playwright;
namespace PlaywrightAutomationFramework.Pages;
public class DashboardPage : BasePage
{
    private ILocator LogoutButton => Page.GetByRole(AriaRole.Link, new() { Name = "Log out" });
    private ILocator SuccessMessage => Page.GetByRole(AriaRole.Heading, new() { Name = "Logged In Successfully" });


    public DashboardPage(IPage page) : base(page)
    {
    }

    public async Task<bool> IsLoadedAsync()
    {
        return await SuccessMessage.IsVisibleAsync();
    }

    public async Task LogoutAsync()
    {
        await ClickAsync(LogoutButton);
    }
}