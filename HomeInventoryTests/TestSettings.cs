using System.Text.Json;

namespace HomeInventoryTests;

public static class TestSettingLoader
{
    private static TestSettings? _testSettings;

    public static TestSettings Load()
    {
        if (_testSettings != null)
            return _testSettings;
        var json = File.ReadAllText("testSettings.json");
        _testSettings = JsonSerializer.Deserialize<TestSettings>(json) ??
                        throw new Exception("testSettings.json file is empty or invalid");
        return _testSettings;
    }
}

public class TestSettings
{
    public required string WebsiteUrl { get; init; }
}