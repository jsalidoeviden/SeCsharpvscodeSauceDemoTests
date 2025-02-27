using OpenQA.Selenium;

namespace SauceDemoTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By usernameField = By.Id("user-name");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("login-button");
        private readonly By errorMessage = By.CssSelector("[data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Login(string username, string password)
        {
            Driver.FindElement(usernameField).Clear();
            Driver.FindElement(usernameField).SendKeys(username);

            Driver.FindElement(passwordField).Clear();
            Driver.FindElement(passwordField).SendKeys(password);

            Driver.FindElement(loginButton).Click();
        }

        public string GetErrorMessage()
        {
            try
            {
                return Driver.FindElement(errorMessage).Text;
            }
            catch (NoSuchElementException)
            {
                return "";
            }
        }
    }
}
