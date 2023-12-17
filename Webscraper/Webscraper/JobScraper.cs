// Importeren OpenQA.Selenium.Chrome
using OpenQA.Selenium.Chrome;
// Importeren OpenQA.Selenium
using OpenQA.Selenium;

// We zetten de class "JobScraper" in de namespace "Webscraper"
namespace Webscraper
{
    // We maken hier een internal class aan genaamd "JobScraper"
    internal class JobScraper
    {
        // Dit zijn de properties van de class "JobScraper"
        // We maken een private property aan genaamd "Url" en we zetten de waarde "https://www.ictjob.be/nl/" in de property
        private string Url = "https://www.ictjob.be/nl/";
        // We maken een private property aan genaamd "SearchTerm" en we zetten een waarde lege waarde in de property
        private string SearchTerm = "";
        // We maken een private property aan genaamd "Jobs"
        // Deze property bevat een lege lijst en er kunnen alleen maar objecten van de class "Job" in de lijst gezet worden
        // We doen dit zodat we meteen alle objecten naar een csv bestand kunnen weg schrijven
        private List<Job> Jobs = [];

        // We maken een constructor aan die als parameter searchTerm heeft
        // We maken een constructor aan omdat de constructor de objecten maakt
        // We doen dit ook zodat we de zoekterm van de gebruiker binnen krijgen en dan op het zoekterm kunnen gaan zoeken
        public JobScraper(string searchTerm)
        {
            // We zetten de waarde dat in de variable "searchTerm" staat. In de property "SearchTerm"
            this.SearchTerm = searchTerm;
        }

        // We maken een methode aan genaamd "Scrape"
        // Als we deze methode oproepen, wordt er data van Youtube gescrapt
        public void Scrape()
        {
            // We maken een driver service aan en zetten de driver service in de variable "driverService"
            var driverService = ChromeDriverService.CreateDefaultService();
            // We zeggen dat de prompt van selenium verborgen moet worden
            // We doen dit zodat onze console schoon blijft
            driverService.HideCommandPromptWindow = true;

            // We maken een new ChromeOptions object aan genaamd "options"
            // We doen dit zodat de chrome browser niet geopent wordt tijdens het scrapen
            // Maar ook zodat de scraper niet gedecteert wordt door ictjobs.be hun bot detection
            ChromeOptions options = new ChromeOptions();
            // Zorgt ervoor dat de browser niet geopent wordt tijdens het scrapen
            options.AddArgument("--headless=new");
            // Deze twee lijnen zorgt ervoor dat de scraper niet gedecteert wordt door ictjobs.be hun bot detection
            // We voorkomen dit door een user agent header te gebruiken. Dit zorgt ervoor dat de bot detection denkt dat het een echt browser is
            options.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");
            // Dit disabled automationcontrol hierdoor wordt de scraper dus ook niet gedecteerd door de bot detection
            options.AddArgument("--disable-blink-features=AutomationControlled");

            // We maken een driver aan en we geven de service en options mee als parameter
            IWebDriver driver = new ChromeDriver(driverService, options);
            // We gaan naar de website
            driver.Navigate().GoToUrl(Url);
            // We wachten 2 seconden nadat de website geopend is
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // We zoeken naar de element van de searchbar op de ictjob door xpath
            var searchBar = driver.FindElement(By.XPath("//*[@id=\"keywords-input\"]"));
            // We typen de zoekterm in de searchbar
            searchBar.SendKeys(SearchTerm);
            // we zoeken naar de zoekterm (Dit is net als je enter klikt op een searchbar)
            searchBar.Submit();

            // We wachten 1 seconden
            Thread.Sleep(1000);
            // We zoeken de element van de knop "datum" op ictjob
            var dateButton = driver.FindElement(By.XPath("//*[@id=\"sort-by-date\"]"));
            // We klikken op de knop, we doen dit zodat we de nieuwste job vacatures krijgen
            dateButton.Click();

            // We wachten 0,5 seconden
            Thread.Sleep(500);
            // We zoeken naar de element van de title van de job vacature
            var titles = driver.FindElements(By.XPath("//*[@class=\"job-title\"]"));
            // We zoeken naar de element van het bedrijf van de job vacature
            var companies = driver.FindElements(By.ClassName("job-company"));
            // We zoeken naar de element van het location van de job vacature
            var locations = driver.FindElements(By.CssSelector("span[itemprop=\"addressLocality\"]"));
            // We zoeken naar de element van de keywords van de job vacature
            var keywords = driver.FindElements(By.ClassName("job-keywords"));
            // We zoeken naar de element van de link van de job vacature
            var links = driver.FindElements(By.CssSelector("a[itemprop=\"title\"]"));

            // We maken een for loop die 5 keer gaat loopen
            for (int i = 0; i < 5; i++)
            {
                // We maken een Job object aan en we geven de title, company, location, keywords en de link van de job vacature mee in de parameter
                Jobs.Add(new Job(titles[i].Text,
                                 companies[i].Text,
                                 locations[i].Text,
                                 keywords[i].Text,
                                 links[i].GetAttribute("href")));
            }
            // We sluiten de driver af
            driver.Quit();

            // We exporteren alle objects naar een csv bestand met de naam "Jobs.csv"
            ExportToCsv<Job>.Export(Jobs, "Jobs.csv");
            // We vormen alle objects naar een json formaat en we schrijven dan deze json string naar een json bestand met de naam "Jobs.json"
            ExportToJson<Job>.Export(Jobs, "Jobs.json");
        }

        // Dit is de getter van de property dat de lijst "Jobs" bevat
        public List<Job> GetJobs() 
        {
            // We return de de lijst Jobs
            return Jobs;
        }

        // Dit is de getter van de property "Url"
        public string GetURL()
        {
            // We return de Url
            return Url;
        }
    }
}
