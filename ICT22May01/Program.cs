using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace ICT22May01
{
    class Program
    {
        static void Main(string[] args)
        {
            string tabOfWindow = "Dashboard - Dispatching System";
            string inputCode = "Morgan123";
            string inputDes = "MorganHello";
            string timeString = "Time";

            //initial
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();

            //Identify the web elements
            IWebElement TxtUserName = driver.FindElement(By.Id("UserName"));
            IWebElement TxtPassword = driver.FindElement(By.Id("Password"));
            IWebElement BtnClick = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));

            //input user and passwd and submit
            TxtUserName.SendKeys("ray");
            TxtPassword.SendKeys("123123");
            BtnClick.Click();

            //check the tab of window
            if (driver.Title == tabOfWindow)
            {
                Console.WriteLine("PASS: Tab of Window is correct!");
            }
            else
            {
                Console.WriteLine("Fail: Tab of Window is wrong!");
            }

            //waiting for thr page!
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Create a new Time and Material item
            // Click Adminstration>>Click Time and Materials>>Click Create New >> Create a valid data >> Validate the item is created.
            IWebElement LinkAdminstration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            LinkAdminstration.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement LinkTimenMaterials =
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            LinkTimenMaterials.Click();
            IWebElement BtnCreateNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            BtnCreateNew.Click();

            //select Time from DDL
            //click Material
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"))
                .Click();
            //wait and select Time
            Thread.Sleep(1000);
            for (int i = 1; i <= 2; i++)
            {
                IWebElement webElement = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[" + i + "]"));
                if (webElement.Text == timeString)
                {
                    webElement.Click();
                }
            }

//            driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")).Click();
/*
            new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(
                    By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")));
            driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")).Click();
*/

            // fill the infor form:
            //input code
            driver.FindElement(By.Id("Code")).SendKeys(inputCode);
            //input des
            driver.FindElement(By.Id("Description")).SendKeys(inputDes);
            //submit
            driver.FindElement(By.Id("SaveButton")).Click();

            //Validate that the item created is on the table
            //wait
            Thread.Sleep(1000);

            //go to the last page and click 
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
            Thread.Sleep(3000);

            /*Console.WriteLine(webElement.GetAttribute("data-page"));*/
            //get the maxmun value of the page:
            //get the text of ul
            var ul = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/ul"));
            string pageNumber = ul.Text;

            //split pageNumber into string arr
            string[] arrPage = pageNumber.Split(Environment.NewLine.ToCharArray());

            //browser each page from last page to the first page
            for (int i = 1; i < int.Parse(arrPage[arrPage.Length - 1]); i++)
            {
                //the current page number
                int pageNow = int.Parse(arrPage[arrPage.Length - 1]) - i + 1;
                Thread.Sleep(1000);

                //get the table and tr location 
                var trs
                    = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody"))
                        .FindElements(By.TagName("tr"));

                // go through all the tr in table
                foreach (var tr in trs)
                {
                    //get td in this tr
                    var tds = tr.FindElements(By.TagName("td"));

                    //get the text of each td and conpare to what you want
                    foreach (var td in tds)
                    {
                        string tdString = td.Text;
                        if (tdString == "Morgan123")
                        {
                            Console.WriteLine("PASS----Find the input Code on page :" + pageNow);
                        }
                    }
                }

                //go to the previous page
                IWebElement pageElement = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[2]"));
                pageElement.Click();
            }

            //closr the browser
            driver.Close();
        }
    }
}
