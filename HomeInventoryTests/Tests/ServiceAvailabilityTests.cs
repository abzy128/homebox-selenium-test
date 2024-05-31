using System.Net;

namespace HomeInventoryTests.Tests;

[TestFixture]
[Order(1)]
public class ServiceAvailabilityTests(HttpClient httpClient, TestSettings testSettings)
{
    [OneTimeSetUp]
    public void Setup()
    {
        httpClient = new HttpClient();
        testSettings = TestSettingLoader.Load();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        httpClient.Dispose();
    }

    [Test]
    public async Task WebsiteAvailabilityTest()
    {
        var response = await httpClient.GetAsync(testSettings.WebsiteUrl);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}