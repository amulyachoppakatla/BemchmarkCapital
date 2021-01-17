using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using CTTest.Utils;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace CTTest.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        public static RemoteWebDriver Driver;

        [BeforeScenario]
        public void InitialiseDriver()
        {
            Driver = Driver ?? StartDriver(Config.GetTestSetting("browser"));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
            Driver = null;
        }

        public static RemoteWebDriver StartDriver(string driverType)
        {
            RemoteWebDriver driver;

            switch (driverType)
            {
                case "chrome":
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    Console.WriteLine("Started on Chrome");
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    Console.WriteLine("Started on Firefox");
                    break;
                default:
                    throw new ConfigurationErrorsException("Browser app config was not set properly");
            }

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Config.GetTestSetting("base_url"));
            return driver;
        }
    }
}