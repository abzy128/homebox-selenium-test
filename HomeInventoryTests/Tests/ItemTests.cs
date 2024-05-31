using HomeInventoryTests.Methods;

namespace HomeInventoryTests.Tests
{
    [TestFixture, Order(2)]
    public class ItemTests
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
        [TestCase("Offi", "randomItem")]
        public void CreateItemTest(string location, string itemName)
        {
            _driver.Navigate().GoToUrl(_testSettings.WebsiteURL);
            Thread.Sleep(500);
            var createItemButton = _driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[2]/div/div/div[2]/div/div/label"));
            createItemButton.Click();
            Thread.Sleep(500);
            var itemNameButton = _driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[2]/div/div/div[2]/div/div/ul/li[1]/button"));
            Thread.Sleep(100);
            itemNameButton.Click();
            Thread.Sleep(500);
            var locationInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/form/div[1]/div/input"));
            locationInput.SendKeys(Keys.Enter);
            var itemNameInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/form/div[2]/input"));
            var submitButton = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/form/div[5]/div/button"));
            locationInput.SendKeys(location);
            itemNameInput.SendKeys(itemName);
            submitButton.Click();
            Thread.Sleep(500);
            var expectedElement = _driver.FindElement(By.XPath($"/html/body/div/div/div[6]/div[1]/div[2]/section[1]/div[1]/header/div/div[2]/h1"));
            Assert.That(expectedElement.Text.Equals(itemName));
        }
        [Test, Order(2)]
        [TestCase("2")]
        public void ChangeQuantityTest(string quantity)
        {
            var changeQuantityButton = _driver.FindElement(By.XPath("/html/body/div[1]/div/div[6]/div[1]/div[2]/section[2]/div/div[1]/div[2]/div/dl/div[1]/dd/span/button[2]"));
            changeQuantityButton.Click();
            Thread.Sleep(500);
            var quantityElement = _driver.FindElement(By.XPath("/html/body/div[1]/div/div[6]/div[1]/div[2]/section[2]/div/div[1]/div[2]/div/dl/div[1]/dd"));
            Assert.That(quantityElement.Text.Equals(quantity));
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
