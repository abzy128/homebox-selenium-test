using HomeInventoryTests.Methods;

namespace HomeInventoryTests.Tests;

[TestFixture]
[Order(4)]
public class MainPageTests
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
    public void TotalItemsTest()
    {
        driver.Navigate().GoToUrl(testSettings.WebsiteUrl + "home");
        Thread.Sleep(2000);
        var totalItemsElement =
            driver.FindElement(
                By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/div/section[1]/div/div[2]/div/div[2]"));
        var text = totalItemsElement.Text;
        Assert.That(text, Is.Not.EqualTo("0"));
    }

    [Test]
    [Order(2)]
    public void TotalLocationTest()
    {
        var totalLocationElement =
            driver.FindElement(
                By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/div/section[1]/div/div[3]/div/div[2]"));
        var text = totalLocationElement.Text;
        Assert.That(text, Is.Not.EqualTo("0"));
    }

    [Test]
    [Order(3)]
    public void TotalLabelsTest()
    {
        var totalLabelsElement =
            driver.FindElement(
                By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/div/section[1]/div/div[4]/div/div[2]"));
        var text = totalLabelsElement.Text;
        Assert.That(text, Is.Not.EqualTo("0"));
    }
}