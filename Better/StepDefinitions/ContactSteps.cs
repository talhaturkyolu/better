using Better.Pages;
using OpenQA.Selenium;

namespace Better.StepDefinitions
{
    [Binding, Scope(Tag = "ContactTest")]
    public class ContactSteps
    {
        private readonly ContactPage _contactPage;

        public ContactSteps(IWebDriver driver)
        {
            _contactPage = new ContactPage(driver);
        }

        #region Given
        #endregion

        #region When
        [When(@"I click ""([^""]*)"" in the Contact page")]
        public void WhenIClickInTheContactPage(string radioButtons)
        {
            _contactPage.ClickRadioButton(radioButtons);
        }

        [When(@"I enter ""([^""]*)"" into ""([^""]*)"" input box")]
        public void WhenIEnterIntoInputBox(string textValue, string inputBox)
        {
            _contactPage.EnterIntoInputBox(textValue, inputBox);
        }

        [When(@"I click ""([^""]*)"" button in the Contact page")]
        public void WhenIClickButtonInTheContactPage(string buttonName)
        {
            _contactPage.ClickButton(buttonName);
        }
        #endregion

        #region Then
        [Then(@"Verify radio buttons are exist:")]
        public void ThenVerifyRadioButtonsAreExist(Table table)
        {
            foreach(TableRow row in table.Rows)
            {
                _contactPage.AssertRadioButton(row["radioButtons"]);
            }
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}