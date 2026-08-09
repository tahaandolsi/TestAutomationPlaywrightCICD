using ApplicationTestDemo.Fixture;
using ApplicationTestDemo.Pages;
using FrameworkDemo.Config;
using FrameworkDemo.Driver;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationTestDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddSingleton(ConfigReader.ReadConfig())
            .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
            .AddScoped<IPlaywrightDriverInitializer, PlaywrightDriverInitializer>()
            .AddScoped<IProductPage, ProductPage>()
            .AddScoped<IProductListPage, ProductListPage>()
            .AddScoped<ITestFixtureBase, TestFixtureBase>();



        }
    }
}
