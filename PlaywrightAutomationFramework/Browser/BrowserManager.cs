using Microsoft.Playwright;
using PlaywrightAutomationFramework.Configuration;
namespace PlaywrightAutomationFramework.Browser;


public class BrowserManager: IAsyncDisposable
{
    private IPlaywright? _playwright; //_playwright -> null
    private IBrowser? _browser;//_browser -> null 
    private IBrowserContext? _context;//_IBrowserContext -> null 
    private IPage? _page;//_page -> null 

    public async Task<IBrowser> LaunchBrowserAsync()
    {
        if (_browser is not null)
        {
            return _browser;
        }

        _playwright = await Playwright.CreateAsync();

        _browser = await _playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = TestConfiguration.Headless
            });

        return _browser;
    }
    public async Task<IBrowserContext> CreateContextAsync()//CreateContextAsync() is a method that creates a new browser context.
    {
        if (_browser is null)
        {
            throw new InvalidOperationException(
                "Browser has not been initialized. Call LaunchBrowserAsync() before CreateContextAsync().");        }

        _context = await _browser.NewContextAsync();
        return _context;
    }

    public async Task<IPage> CreatePageAsync() //CreatePageAsync() is a method that creates a new page in the browser context.
    {
        if (_context is null)
        {
            throw new InvalidOperationException(
                "Browser context has not been initialized. Call CreateContextAsync() before CreatePageAsync().");
        }

        _page = await _context.NewPageAsync();
        return _page;
    }
        public async ValueTask DisposeAsync()
    {
        if (_page is not null)
            await _page.CloseAsync();

        if (_context is not null)
            await _context.CloseAsync();

        if (_browser is not null)
            await _browser.CloseAsync();

        _playwright?.Dispose();
    }
}