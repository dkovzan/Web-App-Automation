using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace WPAutomation
{
    
    public class Base
    {
        public IWebDriver Driver { get; set; }

        public static IConfiguration Config => new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        public static readonly string Host = Config["host"];

        public static readonly string Env = Config["env"];

    }
}
