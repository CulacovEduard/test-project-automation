using Microsoft.Extensions.Configuration;
using TestShopProject.Models;

namespace TestShopProject.Utilities;

public static class ConfigReader
{
    public static TestSettings LoadSettings()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("/Users/eduardculacov/RiderProjects/TestShopProject/TestShopProject/Core/config.json", optional: false);

        var config = builder.Build();

        return config.Get<TestSettings>();
    }
}