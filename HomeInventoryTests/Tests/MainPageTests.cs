using HomeInventoryTests.Methods;

namespace HomeInventoryTests.Tests
{
    [TestFixture, Order(4)]
    public class MainPageTests
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
        public void TotalItemsTest()
        {
            _driver.Navigate().GoToUrl(_testSettings.WebsiteURL + "home");
            var totalItemsElement = _driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/div/section[1]/div/div[2]/div/div[2]"));
            var text = totalItemsElement.Text;
            Assert.That(text, Is.Not.EqualTo("0"));
        }
        [Test, Order(2)]
        public void TotalLocationTest()
        {
            var totalLocationElement = _driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/div/section[1]/div/div[3]/div/div[2]"));
            var text = totalLocationElement.Text;
            Assert.That(text, Is.Not.EqualTo("0"));
        }
        [Test, Order(3)]
        public void TotalLabelsTest()
        {
            var totalLabelsElement = _driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/div/section[1]/div/div[4]/div/div[2]"));
            var text = totalLabelsElement.Text;
            Assert.That(text, Is.Not.EqualTo("0"));
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
