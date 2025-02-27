using OpenQA.Selenium;

namespace SauceDemoTests.Pages
{
    public class CartPage : BasePage
    {
        private readonly By checkoutButton = By.Id("checkout");

        public CartPage(IWebDriver driver) : base(driver) { }

        public void ProceedToCheckout()
        {
            Driver.FindElement(checkoutButton).Click();
        }
    }
}
