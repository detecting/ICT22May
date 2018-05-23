using System;
using OpenQA.Selenium;

namespace ICT22May01
{
    public class HomePage
    {
        private string tabOfWindow = "Dashboard - Dispatching System";

        private IWebDriver driver;
        private string linkAdminstrationXpath = "/html/body/div[3]/div/div/ul/li[5]/a";
        private string linkTimenMaterialsXpath = "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a";
        IWebElement LinkAdminstration => driver.FindElement(By.XPath(linkAdminstrationXpath));

        IWebElement LinkTimenMaterials =>
            driver.FindElement(By.XPath(linkTimenMaterialsXpath));


        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        //vilidate
        public void Validate()
        {
            //check the tab of window
            if (driver.Title == tabOfWindow)
            {
                Console.WriteLine("PASS: Tab of Window is correct!");
            }
            else
            {
                Console.WriteLine("Fail: Tab of Window is wrong!");
            }
        }

        public void ClickAdministration()
        {
            //Create a new Time and Material item
            LinkAdminstration.Click();
            //waiting for thr page!
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void ClickTimeAndMaterial()
        {
            LinkTimenMaterials.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}