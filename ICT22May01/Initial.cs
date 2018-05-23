using OpenQA.Selenium.Chrome;

namespace ICT22May01
{
    public class Initial
    {
        public void InitialBrowser(string url)
        {
            PropertiesCollection.driver = new ChromeDriver();
            //open the url   
            PropertiesCollection.driver.Navigate().GoToUrl(url);
            //max the windows
            PropertiesCollection.driver.Manage().Window.Maximize();
        }
    }
}