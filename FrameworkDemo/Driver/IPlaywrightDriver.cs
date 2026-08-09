using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.Driver
{
    public interface IPlaywrightDriver
    {
        Task<IPage> Page { get; }
        Task<IBrowser> Browser { get; }
        Task<IBrowserContext> BrowserContext { get; }
    }
}
