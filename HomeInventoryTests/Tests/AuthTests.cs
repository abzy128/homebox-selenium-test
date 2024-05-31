using HomeInventoryTests.Methods;

namespace HomeInventoryTests.Tests;

[TestFixture]
[Order(2)]
public class AuthTests
{
    private ChromeDriver driver;
    private TestSettings testSettings;

    [OneTimeSetUp]
    public void Setup()
    {
        testSettings = TestSettingLoader.Load();
        driver = new ChromeDriver();
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    [Order(1)]
    [TestCase("randomMail@mail.com", "SomeAdam", "pass0303")]
    public void TestRegistration(string email, string name, string password)
    {
        driver.RegisterToWebsite(email, name, password);
        var expectedUrl = testSettings.WebsiteUrl;
        var actualUrl = driver.Url;
        Assert.That(expectedUrl, Is.EqualTo(actualUrl));
    }

    [Test]
    [Order(2)]
    [TestCase("randomMail@mail.com", "pass0303")]
    public void TestLogin(string email, string password)
    {
        driver.LoginToWebsite(email, password);
        var expectedUrl = testSettings.WebsiteUrl + "home" ?? throw new ArgumentException($"{email} + {password} were incorrect");
        var actualUrl = driver.Url;
        Assert.That(expectedUrl, Is.EqualTo(actualUrl));
    }
}