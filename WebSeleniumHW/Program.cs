using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebSeleniumHW.Pages;

namespace WebSeleniumHW
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebDriver driver = new ChromeDriver();

            driver.Url= "https://jobs.devby.io/";

            List<string> tagNames = new List<string>();

            VacanciesPage vacanciesPage = new VacanciesPage(driver);
            tagNames.AddRange(vacanciesPage.GetListOfTags());

            vacanciesPage.TypeNumberOfVancanciesForEachSpecialization(tagNames);

            driver.Close();
        }
    }
}
