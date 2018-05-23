using System;
using System.IO.MemoryMappedFiles;
using System.Threading;
using OpenQA.Selenium;

namespace ICT22May01
{
    public class CreateNew
    {
        private IWebDriver driver;
        private string timeString = "Time";
        private string inputCode = "Morgan123";
        private string inputDes = "MorganHello";
        private string btnCreateNewXpath = "//*[@id=\"container\"]/p/a";
        private string materialXpath = "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]";
        private string lastPageXpath = "//*[@id=\"tmsGrid\"]/div[4]/a[4]";
        private string ulXpath = "//*[@id=\"tmsGrid\"]/div[4]/ul";
        private string tableXpth = "//*[@id=\"tmsGrid\"]/div[3]/table/tbody";
        private string previousPageXpath = "//*[@id=\"tmsGrid\"]/div[4]/a[2]";
        
        IWebElement BtnCreateNew => driver.FindElement(By.XPath(btnCreateNewXpath));
        


        public CreateNew(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void ClickCreateNewBtn()
        {
            BtnCreateNew.Click();
        }

        public void FillUpInfoForm()
        {
            
            //select Time from DDL
            //click Material
            driver.FindElement(By.XPath(materialXpath))
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
        }

        public void CheckForRecord()
        {
            //go to the last page and click 
            driver.FindElement(By.XPath(lastPageXpath)).Click();
            Thread.Sleep(2000);

            //get the maxmun value of the page:
            //get the text of ul
            var ul = driver.FindElement(By.XPath(ulXpath));
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
                    = driver.FindElement(By.XPath(tableXpth))
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
                IWebElement pageElement = driver.FindElement(By.XPath(previousPageXpath));
                pageElement.Click();
            }

        }
    }
}