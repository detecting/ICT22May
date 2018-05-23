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
            IWebDriver driver=new ChromeDriver();
            //SetUp--Initial
            Initial initial=new Initial(driver);
            initial.GoToUrlAndMaxWindow();

            //LoginPage
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginOk();

            //HomePage
            HomePage homePage = new HomePage(driver);
            homePage.Validate();
            homePage.ClickAdministration();
            homePage.ClickTimeAndMaterial();
            //CreateNewPage
            CreateNew createNew=new CreateNew(driver);
            createNew.ClickCreateNewBtn();
            createNew.FillUpInfoForm();
            createNew.CheckForRecord();

            //Teardown--close
//            driver.Close();
        }
    }
}