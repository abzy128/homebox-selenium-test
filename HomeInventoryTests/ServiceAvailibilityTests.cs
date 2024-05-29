using System.Net;

namespace HomeInventoryTests;

public class ServiceAvailibilityTests
{
    private HttpClient _httpClient;
    [OneTimeSetUp]
    public void Setup()
    {
        _httpClient = new();
    }

    [Test]
    public async Task Test1()
    {
        var response = await _httpClient.GetAsync("http://abzy-server:3100/");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}