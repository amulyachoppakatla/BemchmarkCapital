using System;
using Microsoft.Extensions.Configuration;

namespace CTTest.Utils
{
    public class Config
    {
        private static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            return config;
        }

        public static string GetTestSetting(string key)
        {
            var config = InitConfiguration();
            var value = config[key];
            if (string.IsNullOrEmpty(value))
                throw new Exception(
                    $"Given key : {key} doesn't exist in app settings.");
            return value;
        }
    }
}