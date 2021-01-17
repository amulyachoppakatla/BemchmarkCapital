using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CTTest.StepDefinitions
{
    public class BaseStep
    {
        protected static RemoteWebDriver Driver => Hooks.Driver;
       
        public void WaitForPageToLoad()
        {
            GenerateWebDriverWait().Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitForPageToLoad();
        }

        private WebDriverWait GenerateWebDriverWait(int seconds = 90)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }
    }
}
