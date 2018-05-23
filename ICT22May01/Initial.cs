using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ICT22May01
{
    public class Initial
    {
        private IWebDriver driver;
        private string url = "http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f";

        public Initial(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void GoToUrlAndMaxWindow()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
    }
}