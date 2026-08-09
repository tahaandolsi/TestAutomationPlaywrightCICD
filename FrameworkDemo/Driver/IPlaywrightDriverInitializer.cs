using FrameworkDemo.Config;
using Microsoft.Playwright;

namespace FrameworkDemo.Driver
{
    public interface IPlaywrightDriverInitializer
    {
        Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetEdgeDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetWebKitDriverAsync(TestSettings testSettings);
    }
}