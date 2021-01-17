using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CTTest.Pages
{
    public class HomePage
    {
        private readonly RemoteWebDriver _driver;

        public HomePage(RemoteWebDriver driver) => _driver = driver;

        IWebElement Frame_form => _driver.FindElementById("frame-one1434677811");


        IWebElement FirstName => _driver.FindElementByCssSelector("#RESULT_TextField-1");
        IWebElement LastName => _driver.FindElementByCssSelector("#RESULT_TextField-2");
        IWebElement Phone => _driver.FindElementByCssSelector("#RESULT_TextField-3");
        IWebElement Country => _driver.FindElementByCssSelector("#RESULT_TextField-4");
        IWebElement City => _driver.FindElementByCssSelector("#RESULT_TextField-5");
        IWebElement Email => _driver.FindElementByCssSelector("#RESULT_TextField-6");
        IList<IWebElement> Gender => _driver.FindElementsByCssSelector("#q26");

        IList<IWebElement> Day => _driver.FindElementsByCssSelector("#q15 > table:nth-child(3)");
        IWebElement Time => _driver.FindElementByCssSelector("#RESULT_RadioButton-9");
        IWebElement UploadFiles => _driver.FindElementById("RESULT_FileUpload-10");
        IWebElement SubmitButton => _driver.FindElementById("FSsubmit");
        IWebElement ErrorMessage => _driver.FindElementByCssSelector(".titlewrapper > .title");

        IWebElement SearchBox => _driver.FindElementById("Wikipedia1_wikipedia-search-input");
        IWebElement SearchButton => _driver.FindElementById("wikipedia-search-button");

        IList<IWebElement> SearchResults => _driver.FindElementsById("Wikipedia1_wikipedia-search-results");


        public void FillForm(
            string firstName,
            string lastName,
            string phone,
            string country,
            string city,
            string email,
            string gender,
            string day,
            string time
        )
        {
            _driver.SwitchTo().Frame(Frame_form);
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Phone.SendKeys(phone);
            Country.SendKeys(country);
            City.SendKeys(city);
            Email.SendKeys(email);
            SelectGender(gender);
            Day.FirstOrDefault(ee => ee.Text == day)?.Click();
            new SelectElement(Time).SelectByText(time);
        }

        public void UploadFile(string file)
        {
            UploadFiles.SendKeys(file);
        }

        public void SubmitForm()
        {
            SubmitButton.Click();
        }

        public void SelectGender(string value)
        {

            foreach (var text in Gender)
            {
                if (value == text.Text)
                {
                    text.Click();
                }
            }
        }

        public void VerifyErrorMessage(string actual)
        {
            Assert.AreEqual(actual, ErrorMessage.Text);
        }

        public void Search(string value)
        {
            SearchBox.SendKeys(value);
            SearchButton.Click();
        }


        public void VerifySearchResults(string[] values)
        {
            var texts = SearchResults.Select(ee => ee.Text).ToList();
            
            foreach (var value in values)
            {
                Assert.IsTrue(texts.Contains(value));
            }
        }

    }
}
