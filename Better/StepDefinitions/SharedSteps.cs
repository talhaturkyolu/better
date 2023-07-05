using Better.Pages;
using OpenQA.Selenium;

namespace Better.StepDefinitions
{
    [Binding, Scope(Tag = "BetterHelp")]
    public class SharedSteps
    {
        private readonly SharedPage _sharedPage;

        public SharedSteps(IWebDriver driver)
        {
            _sharedPage = new SharedPage(driver);
        }

        [When(@"I go to ""([^""]*)"" page in Better Help")]
        public void WhenIGoToPageInBetterHelp(string pageName)
        {
            _sharedPage.GoToPage(pageName);
        }
    }
}
