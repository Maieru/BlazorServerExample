using Bussiness.Comuns;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.UI_Tests
{
    public class StudentPage
    {
        private readonly IWebDriver driver;
        private readonly string baseUri;

        public StudentPage()
        {
            driver = new ChromeDriver();
            baseUri = WebSites.RetrieveURI(EnumEnviroment.Local);
        }

        [Fact]
        public async Task EnterList()
        {
            driver.Navigate().GoToUrl(baseUri);
            await Task.Delay(1000);
            driver.Navigate().GoToUrl($"{baseUri}/ListStudent");

            Assert.True(driver.FindElements(By.XPath("/html/body/div[1]/main/article/div/div[1]/a")).Any());
        }

        ~StudentPage()
        {
            driver.Quit();
        }
    }
}
