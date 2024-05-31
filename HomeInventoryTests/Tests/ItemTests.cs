using HomeInventoryTests.Methods;

namespace HomeInventoryTests.Tests
{
    [TestFixture, Order(3)]
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
            _driver.CreateItem(location, itemName);
            var expectedElement = _driver.FindElement(By.XPath($"/html/body/div/div/div[6]/div[1]/div[2]/section[1]/div[1]/header/div/div[2]/h1"));
            Assert.That(expectedElement.Text.Equals(itemName));
        }
        [Test, Order(2)]
        [TestCase("2")]
        public void ChangeQuantityTest(string quantity)
        {
            _driver.ChangeQuantity();
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
