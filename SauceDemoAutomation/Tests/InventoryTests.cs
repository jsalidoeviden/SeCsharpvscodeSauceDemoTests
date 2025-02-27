using OpenQA.Selenium;
using Xunit;
using SauceDemoTests.Driver;
using SauceDemoTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SauceDemoTests.Tests
{
    public class InventoryTests : IDisposable
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        public InventoryTests()
        {
            driver = WebDriverFactory.CreateDriver("chrome");
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);

            // Iniciar sesión
            loginPage.Navigate("https://www.saucedemo.com/");
            loginPage.Login("standard_user", "secret_sauce");
        }

        /// <summary> ✅ 1️⃣ Acceso a la página de inventario </summary>
        [Fact]
        public void VerifyInventoryPageLoads()
        {
            Assert.Contains("inventory.html", driver.Url);
        }

        /// <summary> ✅ 2️⃣ Intentar acceder a `inventory.html` sin login </summary>
        [Fact]
        public void AccessInventoryWithoutLogin()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");
            Assert.Contains("login.html", driver.Url);
        }

        /// <summary> ✅ 3️⃣ Acceso con usuario bloqueado </summary>
        [Fact]
        public void LoginWithLockedUser()
        {
            loginPage.Login("locked_out_user", "secret_sauce");
            Assert.Contains("Sorry, this user has been locked out", loginPage.GetErrorMessage());
        }

        /// <summary> ✅ 4️⃣ Verificar que todos los productos están listados </summary>
        [Fact]
        public void VerifyAllProductsAreDisplayed()
        {
            Assert.Equal(6, inventoryPage.GetProductCount());
        }

        /// <summary> ✅ 5️⃣ Abrir detalles de un producto </summary>
        [Fact]
        public void OpenProductDetails()
        {
            inventoryPage.OpenFirstProduct();
            Assert.Contains("inventory-item.html", driver.Url);
        }

        /// <summary> ✅ 6️⃣ Regresar a inventario desde la página de producto </summary>
        [Fact]
        public void ReturnToInventoryFromProductPage()
        {
            inventoryPage.OpenFirstProduct();
            inventoryPage.GoBackToInventory();
            Assert.Contains("inventory.html", driver.Url);
        }

        /// <summary> ✅ 7️⃣ Agregar un producto al carrito </summary>
        [Fact]
        public void AddItemToCart()
        {
            inventoryPage.AddFirstItemToCart();
            Assert.True(inventoryPage.IsItemAddedToCart());
        }

        /// <summary> ✅ 8️⃣ Eliminar un producto del carrito </summary>
        [Fact]
        public void RemoveItemFromCart()
        {
            inventoryPage.AddFirstItemToCart();
            inventoryPage.RemoveFirstItemFromCart();
            Assert.False(inventoryPage.IsItemAddedToCart());
        }

        /// <summary> ✅ 9️⃣ Agregar múltiples productos al carrito </summary>
        [Fact]
        public void AddMultipleItemsToCart()
        {
            inventoryPage.AddAllItemsToCart();
            Assert.Equal(6, inventoryPage.GetCartItemCount());
        }

        /// <summary> ✅ 🔟 Navegar al carrito </summary>
        [Fact]
        public void NavigateToCart()
        {
            inventoryPage.GoToCart();
            Assert.Contains("cart.html", driver.Url);
        }

        /// <summary> ✅ 11️⃣ Ordenar productos de menor a mayor precio </summary>
        [Fact]
        public void SortItemsByPriceLowToHigh()
        {
            inventoryPage.SortBy("Price (low to high)");
            List<decimal> prices = inventoryPage.GetProductPrices();
            Assert.True(prices.SequenceEqual(prices.OrderBy(p => p)));
        }

        /// <summary> ✅ 12️⃣ Ordenar productos de mayor a menor precio </summary>
        [Fact]
        public void SortItemsByPriceHighToLow()
        {
            inventoryPage.SortBy("Price (high to low)");
            List<decimal> prices = inventoryPage.GetProductPrices();
            Assert.True(prices.SequenceEqual(prices.OrderByDescending(p => p)));
        }

        /// <summary> ✅ 13️⃣ Ordenar productos alfabéticamente (A-Z) </summary>
        [Fact]
        public void SortItemsByNameAToZ()
        {
            inventoryPage.SortBy("Name (A to Z)");
            List<string> productNames = inventoryPage.GetProductNames();
            Assert.True(productNames.SequenceEqual(productNames.OrderBy(n => n)));
        }

        /// <summary> ✅ 14️⃣ Ordenar productos alfabéticamente (Z-A) </summary>
        [Fact]
        public void SortItemsByNameZToA()
        {
            inventoryPage.SortBy("Name (Z to A)");
            List<string> productNames = inventoryPage.GetProductNames();
            Assert.True(productNames.SequenceEqual(productNames.OrderByDescending(n => n)));
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
