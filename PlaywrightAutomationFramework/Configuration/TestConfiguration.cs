using PlaywrightAutomationFramework.Enums;
namespace PlaywrightAutomationFramework.Configuration;


public static class TestConfiguration
{
    public static string BaseUrl => "https://example.com";

    public static bool Headless => false;

    public static BrowserType Browser => BrowserType.Chromium;
}