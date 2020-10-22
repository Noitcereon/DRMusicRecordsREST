using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UISeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string Directory = @"C:\Users\mtlau\source\repos\DRMusicRecordsREST\UISeleniumTest\Drivers\";
        //private static readonly string Directory = @"C:\Users\tba\source\repos\3_semester\DRMusicRecordsREST\UISeleniumTest\Drivers";


        private static IWebDriver _driver;
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _driver = new ChromeDriver(Directory);
            //_driver = new FirefoxDriver(Directory);
        }

        [ClassCleanup]
        public static void End()
        {
            _driver.Dispose();
        }
        [TestMethod]
        public void GetAllTest()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            Assert.AreEqual("DR Music Records", _driver.Title);

            IWebElement GetAllBtn = _driver.FindElement(By.Id("GetAllRecordsBtn"));
            IWebElement Content = _driver.FindElement(By.Id("GetAllUL"));
            
            Assert.AreEqual("",Content.Text);

            GetAllBtn.Click();

            Assert.AreNotEqual("",Content.Text);

        }
    }
}
