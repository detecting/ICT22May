using OpenQA.Selenium;

namespace ICT22May01
{
    public class LoginPage
    {
        private IWebDriver driver;
        private string userNameId = "UserName";
        private string passwd = "Password";
        private string btnClickXpath = "//*[@id=\"loginForm\"]/form/div[3]/input[1]";

        //Identify the web elements
        IWebElement TxtUserName => driver.FindElement(By.Id(userNameId));
        IWebElement TxtPassword => driver.FindElement(By.Id(passwd));
        IWebElement BtnClick => driver.FindElement(By.XPath(btnClickXpath));

        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void LoginOk()
        {
            //input user and passwd and submit
            TxtUserName.SendKeys("ray");
            TxtPassword.SendKeys("123123");
            BtnClick.Click();
        }
    }
}