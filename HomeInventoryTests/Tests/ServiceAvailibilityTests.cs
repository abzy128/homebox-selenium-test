using System.Net;

namespace HomeInventoryTests.Tests;

[TestFixture]
public class ServiceAvailibilityTests
{
    private HttpClient _httpClient;
    private TestSettings _testSettings;
    [OneTimeSetUp]
    public void Setup()
    {
        _httpClient = new();
        _testSettings = TestSettingLoader.Load();
    }

    [Test]
    public async Task WebsiteAvailibilityTest()
    {
        var response = await _httpClient.GetAsync(_testSettings.WebsiteURL);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    [OneTimeTearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
    }
}