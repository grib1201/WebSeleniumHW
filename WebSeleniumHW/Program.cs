using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebSeleniumHW
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Url= "https://jobs.devby.io/";

            string specializationsXpath = "//div[contains(@class, 'filter__item_tags-collections')]//span[@class='radio']/label";
            string vacanciesXpath = "//div[@class='vacancies-list-item']/div[contains(@class, 'open')]";
            string filterTagXpath = "//span[@class='vacancies-list__filter-tag__text']";

            var specializations = driver.FindElements(By.XPath(specializationsXpath));
            
            List<string> tagNames = specializations.Select(x => x.Text).ToList();

            foreach (var tag in tagNames)
            {
                string specializationTagBtnXpath = String.Format(specializationsXpath + "[text()='{0}']", tag);
                string filterTagLabelXpath = String.Format(filterTagXpath + "[text()='{0}']", tag);
                driver.FindElement(By.XPath(specializationTagBtnXpath)).Click();
                var isSpecializationTagVisible = driver.FindElement(By.XPath(filterTagLabelXpath)).Displayed;

                int numberOfVacancies = 0;
                if (isSpecializationTagVisible)
                {
                    numberOfVacancies = driver.FindElements(By.XPath(vacanciesXpath)).Count();
                }
                Console.WriteLine($"Specialization: {tag}, number of vacancies: {numberOfVacancies}.");
            }

            driver.Close();
        }
    }
}
