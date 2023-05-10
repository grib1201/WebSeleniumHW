using OpenQA.Selenium;

namespace WebSeleniumHW.Pages
{
    public abstract class BasePage
    {
        private IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        protected IWebElement FindElementByXpath(string xPath) => _driver.FindElement(By.XPath(xPath));

        protected IReadOnlyList<IWebElement> FindElementsByXpath(string xPath) => _driver.FindElements(By.XPath(xPath));

    }
}
