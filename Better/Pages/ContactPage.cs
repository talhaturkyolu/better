using Better.Support;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Better.Pages
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;
        private readonly WebControls _webControls;

        #region By Definitions
        private static By RadioButtonByValue(string radioButtonValue) => By.XPath($"//form[@id = 'contact-form']//input[@value = \"{radioButtonValue}\"]");
        private static By InputBoxByIdValue(string id) => By.XPath($"//div[contains(@class, 'form-group')]//input[@id = '{id}']");
        private static By TextAreaByIdValue(string id) => By.XPath($"//div[contains(@class, 'form-group')]//textarea[@id = '{id}']");
        private static By SubmitButton => By.XPath($"//div[contains(@class, 'form-group')]//button[@type='submit']");
        #endregion

        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
            _webControls = new WebControls(driver);
        }

        #region Actions
        public void ClickRadioButton(string radioButtonValue)
        {
            _driver.FindElement(By.XPath("//button[@id= 'cookie-banner-accept-all']")).Click();
           
            _webControls.WaitForElementToBeClickable(RadioButtonByValue(radioButtonValue));
           _driver.FindElement(RadioButtonByValue(radioButtonValue)).Click();
            //_driver.FindElement(By.XPath("//button[@id= 'cookie-settings-allow-all']")).Click();
        }

        public void ClickButton(string buttonName)
        {
            
            switch (buttonName.ToLower())
            {
                case "submit":
                    _driver.FindElement(SubmitButton).Click();
                    break;
                default: throw new Exception($"Unknown input box or text area: {buttonName}");
            }
        }

        public void EnterIntoInputBox(string textValue, string inputBox)
        {
            switch (inputBox.ToLower())
            {
                case "first-name":
                case "last-name":
                case "email":
                    _driver.FindElement(InputBoxByIdValue(inputBox)).SendKeys(textValue);
                    break;
                case "message":
                    _driver.FindElement(TextAreaByIdValue(inputBox)).SendKeys(textValue);
                    break;
                default: throw new Exception($"Unknown input box or text area: {inputBox}");
            }
        }
        #endregion

        #region Assertions
        public void AssertRadioButton(string radioButtonValue)
        {
            Assert.IsTrue(_webControls.DoesElementExist(RadioButtonByValue(radioButtonValue)), $"{radioButtonValue} does not exist");
        }
        #endregion

    }
}
