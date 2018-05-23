using OpenQA.Selenium;

namespace ICT22May01
{
    public class PropertiesCollection
    {
        private string url = "http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f";
        public static IWebDriver driver { get; set; }
    }
}