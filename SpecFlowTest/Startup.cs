
using FrameworkDemo.Config;
using FrameworkDemo.Driver;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using SpecFlowTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowTest
{
    
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton(ConfigReader.ReadConfig())
                .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
                .AddScoped<IPlaywrightDriverInitializer, PlaywrightDriverInitializer>()
                .AddScoped<IProductPage, ProductPage>()
                .AddScoped<IProductListPage, ProductListPage>();

            return services;
        }
    }
}
