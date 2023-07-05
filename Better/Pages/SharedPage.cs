using OpenQA.Selenium;

namespace Better.Pages
{
    public class SharedPage
    {

        private readonly IWebDriver _driver;

        #region By Definitions
        #endregion

        public SharedPage (IWebDriver driver)
        {
            _driver = driver;
        }

        #region Actions
        public void GoToPage(string pageName)
        {
            switch (pageName.ToLower())
            {
                case "contact":                  
                    _driver.Navigate().GoToUrl("https://www.betterhelp.com/contact/");
                    break;
                default: throw new Exception($"Unknown page: {pageName}");
            }
        }
        #endregion

        #region Assertions
        #endregion
    }
}
