using HomeInventoryTests.Methods;

namespace HomeInventoryTests.Tests
{
    [TestFixture, Order(5)]
    public class ProfileTests
    {
        private ChromeDriver _driver;
        private TestSettings _testSettings;

        [OneTimeSetUp]
        public void Setup()
        {
            _testSettings = TestSettingLoader.Load();
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.LoginToWebsite("randomMail@mail.com", "pass0303");
        }
        [Test, Order(1)]
        public void ProfilePageTest()
        {
            _driver.Navigate().GoToUrl(_testSettings.WebsiteURL + "profile");
            Thread.Sleep(500);
            var currencySelector = _driver.FindElement(By.XPath("/html/body/div[1]/div/div[6]/div[1]/div[2]/div[3]/div[3]/div[2]/div/div[1]/select"));
            currencySelector.SendKeys("k");
            currencySelector.SendKeys(Keys.Enter);
            Thread.Sleep(500);
            var currencyExample = _driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/div[3]/div[3]/div[2]/div/p"));
            var text = currencyExample.Text;
            Assert.That(text, Does.Contain("KZT"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
