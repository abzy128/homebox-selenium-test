using HomeInventoryTests.Methods;

namespace HomeInventoryTests.Tests;

[TestFixture]
[Order(3)]
public class ItemTests(ChromeDriver driver, TestSettings testSettings)
{
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
    [TestCase("Offi", "randomItem")]
    public void CreateItemTest(string location, string itemName)
    {
        driver.CreateItem(location, itemName);
        var expectedElement =
            driver.FindElement(
                By.XPath("/html/body/div/div/div[6]/div[1]/div[2]/section[1]/div[1]/header/div/div[2]/h1"));
        Assert.That(expectedElement.Text, Is.EqualTo(itemName));
    }

    [Test]
    [Order(2)]
    [TestCase("2")]
    public void ChangeQuantityTest(string quantity)
    {
        driver.ChangeQuantity();
        var quantityElement =
            driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[6]/div[1]/div[2]/section[2]/div/div[1]/div[2]/div/dl/div[1]/dd"));
        Assert.That(quantityElement.Text, Is.EqualTo(quantity));
    }
}