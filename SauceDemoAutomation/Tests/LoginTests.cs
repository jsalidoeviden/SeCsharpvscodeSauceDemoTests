using OpenQA.Selenium;
using Xunit;
using SauceDemoTests.Driver;
using SauceDemoTests.Pages;
using System;

namespace SauceDemoTests.Tests
{
    public class LoginTests : IDisposable
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginTests()
        {
            driver = WebDriverFactory.CreateDriver("chrome");
            loginPage = new LoginPage(driver);
            loginPage.Navigate("https://www.saucedemo.com/");
        }

        /// <summary> ✅ 1️⃣ Login exitoso con usuario estándar </summary>
        [Fact]
        public void LoginWithValidUser()
        {
            loginPage.Login("standard_user", "secret_sauce");
            Assert.Contains("inventory", driver.Url);
        }

        /// <summary> ✅ 2️⃣ Login con usuario bloqueado </summary>
        [Fact]
        public void LoginWithLockedUser()
        {
            loginPage.Login("locked_out_user", "secret_sauce");
            Assert.Contains("locked out", loginPage.GetErrorMessage());
        }

        /// <summary> ✅ 3️⃣ Login con usuario con problemas de rendimiento </summary>
        [Fact]
        public void LoginWithPerformanceUser()
        {
            loginPage.Login("performance_glitch_user", "secret_sauce");
            Assert.Contains("inventory", driver.Url);
        }

        /// <summary> ✅ 4️⃣ Login con usuario de errores visuales </summary>
        [Fact]
        public void LoginWithVisualUser()
        {
            loginPage.Login("visual_user", "secret_sauce");
            Assert.Contains("inventory", driver.Url);
        }

        /// <summary> ✅ 5️⃣ Login con usuario incorrecto </summary>
        [Fact]
        public void LoginWithInvalidUser()
        {
            loginPage.Login("invalid_user", "secret_sauce");
            Assert.Contains("Username and password do not match", loginPage.GetErrorMessage());
        }

        /// <summary> ✅ 6️⃣ Login con contraseña incorrecta </summary>
        [Fact]
        public void LoginWithWrongPassword()
        {
            loginPage.Login("standard_user", "wrong_password");
            Assert.Contains("Username and password do not match", loginPage.GetErrorMessage());
        }

        /// <summary> ✅ 7️⃣ Login con usuario y contraseña vacíos </summary>
        [Fact]
        public void LoginWithEmptyFields()
        {
            loginPage.Login("", "");
            Assert.Contains("Username is required", loginPage.GetErrorMessage());
        }

        /// <summary> ✅ 8️⃣ Login solo con usuario (sin contraseña) </summary>
        [Fact]
        public void LoginWithOnlyUsername()
        {
            loginPage.Login("standard_user", "");
            Assert.Contains("Password is required", loginPage.GetErrorMessage());
        }

        /// <summary> ✅ 9️⃣ Login solo con contraseña (sin usuario) </summary>
        [Fact]
        public void LoginWithOnlyPassword()
        {
            loginPage.Login("", "secret_sauce");
            Assert.Contains("Username is required", loginPage.GetErrorMessage());
        }

        /// <summary> ✅ 🔟 Login con usuario en mayúsculas </summary>
        [Fact]
        public void LoginWithUppercaseUsername()
        {
            loginPage.Login("STANDARD_USER", "secret_sauce");
            Assert.Contains("Username and password do not match", loginPage.GetErrorMessage());
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
