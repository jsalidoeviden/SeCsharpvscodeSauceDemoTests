using OpenQA.Selenium;
using Xunit;
using SauceDemoTests.Driver;
using SauceDemoTests.Pages;
using System;

namespace SauceDemoTests.Tests
{
    public class CartTests : IDisposable
    {
        private IWebDriver driver;
        private CartPage cartPage;
        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        public CartTests()
        {
            driver = WebDriverFactory.CreateDriver("chrome");
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            cartPage = new CartPage(driver);

            // Iniciar sesión
            loginPage.Navigate("https://www.saucedemo.com/");
            loginPage.Login("standard_user", "secret_sauce");

            // Ir al inventario y agregar un producto
            inventoryPage.AddFirstItemToCart();
            inventoryPage.GoToCart();
        }

        [Fact]
        public void ProceedToCheckout()
        {
            // Verificar que estamos en la página del carrito
            Assert.Contains("cart.html", driver.Url);

            // Proceder al checkout
            cartPage.ProceedToCheckout();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
