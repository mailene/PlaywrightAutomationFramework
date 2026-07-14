using Microsoft.Playwright;
namespace PlaywrightAutomationFramework.Pages;

public abstract class BasePage
{
    protected readonly IPage Page; 
    //The constructor is also protected.
    protected BasePage(IPage page)
    {
        Page = page;
    }

    protected async Task ClickAsync(ILocator locator) 
    {
        if (locator is null)
        {
            throw new ArgumentNullException(nameof(locator));
        }
        Console.WriteLine("[INFO] Clicking element.");
        await locator.ClickAsync();
    }
    private async Task FillInternalAsync(
        ILocator locator,
        string text,
        bool sensitive)
    {
        if (locator is null)
            throw new ArgumentNullException(nameof(locator));

        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentNullException(nameof(text));

        Console.WriteLine(
            sensitive
                ? "[INFO] Entering sensitive data."
                : $"[INFO] Entering text: {text}");

        await locator.FillAsync(text);
    }
    protected async Task FillAsync(ILocator locator, string text)
    {
        await FillInternalAsync(locator, text, false);
    }
    protected async Task FillSensitiveAsync(ILocator locator, string text)
    {
        await FillInternalAsync(locator, text, true);
    }

    /// <summary>
    /// Captures a screenshot of the current browser page and saves it
    /// under the Screenshots/YYYY-MM-DD folder.
    /// </summary>
    protected async Task TakeScreenshotAsync(string fileName)
    {
        try
        {
            var dateFolder = DateTime.Now.ToString("yyyy-MM-dd");

            var screenshotFolder = Path.Combine("Screenshots", dateFolder);

            Directory.CreateDirectory(screenshotFolder);

            var path = Path.Combine(
                screenshotFolder,
                $"{fileName}_{DateTime.Now:HHmmss}.png");

            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = path
            });

            Console.WriteLine($"[INFO] Screenshot saved: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"[WARNING] Unable to capture screenshot. {ex.Message}");
        }
    }
}