using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Better.Support
{
    public class WebControls
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WebControls(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        #region Waits
        public void WaitForElementToBeClickable(By by)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitFor(TimeSpan timeSpan)
        {
            Task.Delay(timeSpan).Wait();
        }
        #endregion

        #region helper methods
        public bool DoesElementExist(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion
    }
}
