using OpenQA.Selenium;

namespace SauceDemoTests.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
