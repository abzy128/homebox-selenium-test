using HomeInventoryTests.Methods;

namespace HomeInventoryTests.Tests;

[TestFixture]
[Order(5)]
public class ProfileTests
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
        driver.LoginToWebsite("randomMail@mail.com", "pass0303");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    [Order(1)]
    public void ProfilePageTest()
    {
        driver.Navigate().GoToUrl(testSettings.WebsiteUrl + "profile");
        Thread.Sleep(2000);
        var currencySelector =
            driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[6]/div[1]/div[2]/div[3]/div[3]/div[2]/div/div[1]/select"));
        currencySelector.SendKeys("k");
        currencySelector.SendKeys(Keys.Enter);
        Thread.Sleep(500);
        var currencyExample =
            driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/div[3]/div[3]/div[2]/div/p"));
        var text = currencyExample.Text;
        Assert.That(text, Does.Contain("KZT"));
    }
}