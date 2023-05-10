using OpenQA.Selenium;

namespace WebSeleniumHW.Pages
{
    public class VacanciesPage:BasePage
    {
        // locators
        private string specializationsXpath = "//div[contains(@class, 'filter__item_tags-collections')]//span[@class='radio']/label";
        private string vacanciesXpath = "//div[@class='vacancies-list-item']/div[contains(@class, 'open')]";
        private string filterTagXpath = "//span[@class='vacancies-list__filter-tag__text']";

        string specializationTagBtnXpath(string text) => String.Format(specializationsXpath + "[text()='{0}']", text);
        string filterTagLabelXpath(string text) => String.Format(filterTagXpath + "[text()='{0}']", text);

        IReadOnlyCollection<IWebElement> Specializations { get; set; }

        public VacanciesPage(IWebDriver driver) : base(driver)
        {
            Specializations = driver.FindElements(By.XPath(specializationsXpath));
        }

        public List<string> GetListOfTags()
        {
            return Specializations.Select(x => x.Text).ToList();
        }

        private bool IsSpecializationTagVisible(string xPath) => FindElementByXpath(xPath).Displayed;

        private int GetCountOfVacancies() => FindElementsByXpath(vacanciesXpath).Count();

        private void ClickSpecializationBtn(string specName) => FindElementByXpath(specializationTagBtnXpath(specName)).Click();

        public void TypeNumberOfVancanciesForEachSpecialization(List<string> tagNames)
        {
            foreach (var tag in tagNames)
            {
                ClickSpecializationBtn(tag);

                int numberOfVacancies = 0;
                if (IsSpecializationTagVisible(filterTagLabelXpath(tag)))
                {
                    numberOfVacancies = GetCountOfVacancies();
                }
                Console.WriteLine($"Specialization: {tag}, number of vacancies: {numberOfVacancies}.");
            }
        }
    }
}
