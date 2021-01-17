using CTTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace CTTest.StepDefinitions
{
    [Binding]
    public class SignupFeatureSteps: BaseStep
    {
        private readonly HomePage homePage = new HomePage(Driver);

        [Given(@"i am on home page")]
        public void GivenIAmOnHomePage()
        {
            Assert.IsTrue(Driver.Url == "http://testautomationpractice.blogspot.com/");
        }

        [When(
            @"i enter signup details as ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenIEnterSignupDetailsAs(string firstname, string lastName, string phone, string country, string city, string email,
            string gender, string day, string time)
        {
            homePage.FillForm(firstname,lastName,phone,country,city,email,gender,day,time);
        }

        [When(@"uploaded ""(.*)""")]
        public void WhenUploaded(string file)
        {
            homePage.UploadFile(file);
        }

        [When(@"i submit form")]
        public void WhenISubmitForm()
        {
            homePage.SubmitForm();
        }

        [Then(@"i should see ""(.*)"" message")]
        public void ThenIShouldSeeMessage(string error)
        {
            homePage.VerifyErrorMessage(error);
        }

        [When(@"i search for ""(.*)""")]
        public void WhenISearchFor(string text)
        {
            homePage.Search(text);
        }

        [Then(@"i should see results as ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenIShouldSeeResultsAs(string text1, string text2, string text3)
        {
            var exptexts = new string[] {text1, text2, text3};
            homePage.VerifySearchResults(exptexts);
        }
    }
}