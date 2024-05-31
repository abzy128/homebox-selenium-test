using HomeInventoryTests.Methods;
namespace HomeInventoryTests.Tests
{
    [TestFixture, Order(2)]
    public class AuthTests
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
        }
        [Test, Order(1)]
        [TestCase("randomMail@mail.com", "SomeAdam", "pass0303")]
        public void TestRegistration(string email, string name, string password)
        {
            _driver.RegisterToWebsite(email, name, password);
            var expectedURL = _testSettings.WebsiteURL;
            var actualURL = _driver.Url;
            Assert.That(expectedURL.Equals(actualURL));
        }
        [Test, Order(2)]
        [TestCase("randomMail@mail.com", "pass0303")]
        public void TestLogin(string email, string password)
        {
            _driver.LoginToWebsite(email, password);
            var expectedURL = _testSettings.WebsiteURL + "home";
            var actualURL = _driver.Url;
            Assert.That(expectedURL.Equals(actualURL));
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
