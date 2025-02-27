using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SauceDemoTests.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly By productItems = By.ClassName("inventory_item");
        private readonly By firstProductLink = By.ClassName("inventory_item_name");
        private readonly By backToProductsButton = By.Id("back-to-products");
        private readonly By firstItemAddToCart = By.XPath("(//button[contains(text(),'Add to cart')])[1]");
        private readonly By firstItemRemoveFromCart = By.XPath("(//button[contains(text(),'Remove')])[1]");
        private readonly By cartBadge = By.ClassName("shopping_cart_badge");
        private readonly By cartIcon = By.ClassName("shopping_cart_link");
        private readonly By sortDropdown = By.ClassName("product_sort_container");
        private readonly By productPrices = By.ClassName("inventory_item_price");
        private readonly By productNames = By.ClassName("inventory_item_name");
        private readonly By addToCartButtons = By.XPath("//button[contains(text(),'Add to cart')]");

        public InventoryPage(IWebDriver driver) : base(driver) { }

        public int GetProductCount()
        {
            return Driver.FindElements(productItems).Count;
        }

        public void OpenFirstProduct()
        {
            Driver.FindElement(firstProductLink).Click();
        }

        public void GoBackToInventory()
        {
            Driver.FindElement(backToProductsButton).Click();
        }

        public void AddFirstItemToCart()
        {
            Driver.FindElement(firstItemAddToCart).Click();
        }

        public void RemoveFirstItemFromCart()
        {
            Driver.FindElement(firstItemRemoveFromCart).Click();
        }

        public void AddAllItemsToCart()
        {
            var buttons = Driver.FindElements(addToCartButtons);
            foreach (var button in buttons)
            {
                button.Click();
            }
        }

        public bool IsItemAddedToCart()
        {
            return Driver.FindElements(cartBadge).Count > 0;
        }

        public int GetCartItemCount()
        {
            return int.Parse(Driver.FindElement(cartBadge).Text);
        }

        public void GoToCart()
        {
            Driver.FindElement(cartIcon).Click();
        }

        public void SortBy(string option)
        {
            var dropdown = Driver.FindElement(sortDropdown);
            dropdown.SendKeys(option);
        }

        public List<decimal> GetProductPrices()
        {
            return Driver.FindElements(productPrices)
                         .Select(e => decimal.Parse(e.Text.Replace("$", "")))
                         .ToList();
        }

        public List<string> GetProductNames()
        {
            return Driver.FindElements(productNames)
                         .Select(e => e.Text)
                         .ToList();
        }
    }
}
