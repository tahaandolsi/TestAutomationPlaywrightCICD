using ApplicationTestDemo.Models;
using ApplicationTestDemo.Pages;
using AutoFixture.Xunit2;
using FrameworkDemo.Config;
using FrameworkDemo.Driver;
using Microsoft.Playwright;

namespace ApplicationTestDemo
{
    public class Tests 
    {

        private readonly IPlaywrightDriver _playwrightDriver;
        private readonly TestSettings _testSettings;
        private readonly IProductListPage _productListPage;
        private readonly IProductPage _productPage;


        public Tests(IPlaywrightDriver playwrightDriver, TestSettings testSettings, IProductListPage productListPage, IProductPage productPage)
        {
            _playwrightDriver = playwrightDriver;
            _testSettings = testSettings;
            _productListPage = productListPage;
            _productPage = productPage;
        }

        
        [Fact]
        public async Task LoginTest()
        {
            var page = await _playwrightDriver.Page;
            //await page.GotoAsync("http://eaapp.somee.com/");
            await page.GotoAsync(_testSettings.ApplicationUrl);

            await page.ClickAsync("text=Login");
            await page.GetByLabel("User Name").FillAsync("admin");
            await page.GetByLabel("Password").FillAsync("password");
            await page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Sign In" }).ClickAsync();
            await page.GetByRole(AriaRole.Link,new PageGetByRoleOptions {Name = "👥 Employees"}).ClickAsync();
           
        }
        [Fact]
        public async Task Test1()
        {
            var page = await _playwrightDriver.Page;

            await page.GotoAsync("http://eaapp.somee.com");

            await page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Login" }).ClickAsync();

            await page.GetByLabel("UserName").FillAsync("admin");

            await page.GetByLabel("Password").FillAsync("password");

            await page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Log in" }).ClickAsync();

            await page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Employee List" }).ClickAsync();
        }
        /*[Fact]
        public async Task Test3()
        {
            var page = await _playwightDriver.Page;
            await page.GotoAsync("http://localhost:33084/");
            await page.GetByRole(AriaRole.Link, new() { Name = "Product" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
            await page.GetByRole(AriaRole.Textbox, new() { Name = "Name" }).FillAsync("xx");
            await page.GetByRole(AriaRole.Textbox, new() { Name = "Description" }).FillAsync("des");
            await page.Locator("#Price").FillAsync("12"); 
            await page.GetByLabel("ProductType").SelectOptionAsync(new[] { "3" });
            await page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
            await page.Locator("tr:nth-child(49) > td:nth-child(6) > a:nth-child(2)").ClickAsync();
            await page.GetByText("xx").ClickAsync();
            await page.GetByRole(AriaRole.Heading, new() { Name = "Details" }).ClickAsync();

        }*/
        /*[Fact]
        public async Task Test2() {
            var page = await _playwrightDriver.Page;

            await page.GotoAsync("https://eaapp.somee.com");


            await _productListPage.CreateProductAsync();
           // await _productPage.CreateProductConcretData("Speaker", "Gaming Speaker", 2000, "2");
            await _productPage.ClickCreate();

            await _productListPage.ClickProductFromList("Speaker");

            // on verifier si ona click sur le details ou pas

            var element = _productListPage.IsProductCreated("Speaker");
            await Assertions.Expect(element).ToBeVisibleAsync();

        }*/

        /* [Theory]
         [InlineData("Speaker", "Gaming Speaker", 2000, "2")]
         [InlineData("USB", "USB 3.0", 300, "3")]
         [InlineData("Webcam", "Camera", 4000, "2")]
         [InlineData("Wires", "Wires for life", 1000, "2")]
         public async Task Test_WithInlineData(string name, string description, int price, string productType)
         {
             var page = await _playwrightDriver.Page;

             await page.GotoAsync("http://localhost:33084/");



             await _productListPage.CreateProductAsync();
            // await _productPage.CreateProductConcretData(name, description, price, productType);
             await _productPage.ClickCreate();

             await _productListPage.ClickProductFromList(name);


             var element = _productListPage.IsProductCreated(name);
             await Assertions.Expect(element).ToBeVisibleAsync();
         }
         */

        /* [Fact]
         public async Task TestWithConcreteTypes()
         {
             var page = await _playwrightDriver.Page;

             var product = new Product()
             {
                 Name = "Test Product",
                 Description = "Test Product Description",
                 Price = 1000,
                 ProductType = ProductType.CPU,
             };

             await page.GotoAsync("http://localhost:33084/");




             await _productListPage.CreateProductAsync();
             await _productPage.CreateProductConcretData(product);
             await _productPage.ClickCreate();

             await _productListPage.ClickProductFromList(product.Name);


             var element = _productListPage.IsProductCreated(product.Name);
             await Assertions.Expect(element).ToBeVisibleAsync();
         }*/
        [Theory(Skip = "Skipping local tests"), AutoData]
        public async Task TestWithAutoFixtureData(Product product)
        {
            var page = await _playwrightDriver.Page;


          await page.GotoAsync("http://ea_webapp:8000/");
          await Task.Delay(30000);

          await _productListPage.CreateProductAsync();
            await _productPage.CreateProduct(product);
            await _productPage.ClickCreate();

            await _productListPage.ClickProductFromList(product.Name);


            var element = _productListPage.IsProductCreated(product.Name);
            await Assertions.Expect(element).ToBeVisibleAsync();

        }
    }
}
