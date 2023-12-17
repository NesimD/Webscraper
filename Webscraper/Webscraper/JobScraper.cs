using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Webscraper
{
    internal class JobScraper
    {
        private string Url = "https://www.ictjob.be/nl/";
        private string SearchTerm = "";
        private List<Job> Jobs = [];

        public JobScraper(string searchTerm)
        {
            this.SearchTerm = searchTerm;
        }

        public void Scrape()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");
            options.AddArgument("--disable-blink-features=AutomationControlled");

            IWebDriver driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var searchBar = driver.FindElement(By.XPath("//*[@id=\"keywords-input\"]"));
            searchBar.SendKeys(SearchTerm);
            searchBar.Submit();

            Thread.Sleep(1000);
            var dateButton = driver.FindElement(By.XPath("//*[@id=\"sort-by-date\"]"));
            dateButton.Click();

            Thread.Sleep(500);
            var titles = driver.FindElements(By.XPath("//*[@class=\"job-title\"]"));
            var companies = driver.FindElements(By.ClassName("job-company"));
            var locations = driver.FindElements(By.CssSelector("span[itemprop=\"addressLocality\"]"));
            var keywords = driver.FindElements(By.ClassName("job-keywords"));
            var links = driver.FindElements(By.CssSelector("a[itemprop=\"title\"]"));

            for (int i = 0; i < 5; i++)
            {
                Jobs.Add(new Job(titles[i].Text,
                                 companies[i].Text,
                                 locations[i].Text,
                                 keywords[i].Text,
                                 links[i].GetAttribute("href")));
            }

            driver.Quit();

            ExportToCsv<Job>.Export(Jobs, "Jobs.csv");
            ExportToJson<Job>.Export(Jobs, "Jobs.json");
        }

        public List<Job> GetJobs() 
        {
            return Jobs;
        }

        public string GetURL()
        {
            return Url;
        }
    }
}
