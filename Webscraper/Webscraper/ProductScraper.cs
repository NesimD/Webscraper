// Importeren OpenQA.Selenium.Chrome
using OpenQA.Selenium.Chrome;
// Importeren Selenium
using OpenQA.Selenium;
// Importeren OpenQA.Selenium.Support.UI
using OpenQA.Selenium.Support.UI;

// We zetten de class "ExportToJson" in de namespace "ProductScraper"
namespace Webscraper
{
    // We maken hier een internal class aan genaamd "ProductScraper"
    internal class ProductScraper
    {
        // Dit zijn de properties van de class "ProductScraper"
        // We maken een private property aan genaamd "FirstSite" en "SecondSite" en we zetten de waarde "https://alternate.be/" in de property "firstSite"
        // en de waarde "https://azerty.nl/" in de property "secondSite"
        private string FirstSite = "https://alternate.be/";
        private string SecondSite = "https://azerty.nl/";
        // We maken een private property aan genaamd "SearchTerm"
        private string SearchTerm;
        // We maken een private property aan genaamd "ProductsAlternate"
        // Deze property bevat een lege lijst en er kunnen alleen maar objecten van de class "Product" in de lijst gezet worden
        // We doen dit zodat we meteen alle objecten naar een csv bestand kunnen weg schrijven
        private List<Product> ProductsAlternate = [];
        // We maken een private property aan genaamd "ProductsAzerty"
        // Deze property bevat een lege lijst en er kunnen alleen maar objecten van de class "Product" in de lijst gezet worden
        // We doen dit zodat we meteen alle objecten naar een csv bestand kunnen weg schrijven
        private List<Product> ProductsAzerty = [];

        // We maken een constructor aan die als parameter searchTerm heeft
        // We maken een constructor aan omdat de constructor de objecten maakt
        // We doen dit ook zodat we de zoekterm van de gebruiker binnen krijgen en dan op het zoekterm kunnen gaan zoeken
        public ProductScraper(string searchTerm)
        {
            // We zetten de waarde dat in de variable "searchTerm" staat. In de property "SearchTerm"
            this.SearchTerm = searchTerm;
        }

        // We maken een methode aan genaamd "Scrape"
        // Als we deze methode oproepen, wordt er data van Alternate en Azerty gescrapt
        public void Scrape()
        {
            // We maken een lijst aan genaamd "prices", die alleen maar doubles toelaat
            List<double> prices = new List<double>();

            // We maken een driver service aan en zetten de driver service in de variable "driverService"
            var driverService = ChromeDriverService.CreateDefaultService();
            // We zeggen dat de prompt van selenium verborgen moet worden
            // We doen dit zodat onze console schoon blijft
            driverService.HideCommandPromptWindow = true;

            // We maken een new ChromeOptions object aan genaamd "options"
            // We doen dit zodat de chrome browser niet geopent wordt tijdens het scrapen
            var options = new ChromeOptions();
            // Zorgt ervoor dat de browser niet geopent wordt tijdens het scrapen
            options.AddArgument("--headless=new");

            // We maken een driver aan en we geven de service en options mee als parameter
            IWebDriver driverAlternate = new ChromeDriver(driverService, options);
            // We gaan naar de website
            driverAlternate.Navigate().GoToUrl(FirstSite);
            // We wachten 2 seconden nadat de website geopend is
            driverAlternate.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // We zoeken naar de element van de searchbar op de alternate door xpath
            var searchBarAlternate = driverAlternate.FindElement(By.XPath("//*[@id=\"searchbar-md\"]/form/div/input"));
            // We typen de zoekterm in de searchbar
            searchBarAlternate.SendKeys(SearchTerm);
            // we zoeken naar de zoekterm (Dit is net als je enter klikt op een searchbar)
            searchBarAlternate.Submit();

            // We zoeken de element van de dropdown lijst 
            SelectElement selectAlternate = new SelectElement(driverAlternate.FindElement(By.XPath("//*[@id=\"s\"]")));
            // We zetten dat we producten willen zoeken op prijs oplopend
            selectAlternate.SelectByText("Prijs oplopend");

            // We zoeken naar de element van de title van het product
            var titlesAlternate = driverAlternate.FindElements(By.ClassName("product-name"));
            // We zoeken naar de element van de prijs van het product
            var pricesAlternate = driverAlternate.FindElements(By.ClassName("price"));
            // We zoeken naar de element van de stock van het product
            var stocksAlternate = driverAlternate.FindElements(By.ClassName("delivery-info"));
            // We zoeken naar de element van de ul van de specs
            SelectElement specs = new SelectElement(driverAlternate.FindElement(By.XPath("//*[@id=\"s\"]")));
            // We zetten de specs in de variable genaamd "unorderLists"
            var unorderLists = driverAlternate.FindElements(By.ClassName("product-info"));

            // We maken een for loop die 5 keer gaat loopen
            for (int i = 0; i < 5; i++)
            {
                // We maken een Product object aan en we geven de title, rpijs, stock, specs en de delivery time van het product mee in de parameter
                ProductsAlternate.Add(new Product(titlesAlternate[i].Text,
                                         Convert.ToDouble(pricesAlternate[i].Text.Substring(2)),
                                         stocksAlternate[i].Text,
                                         unorderLists[i].Text,
                                         "not define"));
            }
            // We sluiten de driver af
            driverAlternate.Quit();

            // We maken een driver service aan en zetten de driver service in de variable "driverService"
            IWebDriver driverAzerty = new ChromeDriver(driverService, options);
            // We gaan naar de website
            driverAzerty.Navigate().GoToUrl(SecondSite);
            // We wachten 2 seconden nadat de website geopend is
            driverAzerty.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // We wachten 1 seconden
            Thread.Sleep(1000);
            var azertyPopup = driverAzerty.FindElement(By.Id("CybotCookiebotDialogBodyButtonDecline"));
            azertyPopup.Click();
            
            var searchBarAzerty = driverAzerty.FindElement(By.Id("search"));
            searchBarAzerty.SendKeys(SearchTerm);
            searchBarAzerty.Submit();

            SelectElement selectAzerty = new SelectElement(driverAzerty.FindElement(By.ClassName("sorter-options")));
            selectAzerty.SelectByText("Prijs oplopend");

            Thread.Sleep(1000);
            var titlesAzerty = driverAzerty.FindElements(By.ClassName("product-item-link"));
            var pricesAzerty = driverAzerty.FindElements(By.ClassName("price"));
            var descriptionAzerty = driverAzerty.FindElements(By.ClassName("product-item-description"));
            var deliveryAzerty = driverAzerty.FindElements(By.ClassName("product-delivery-time"));

            for (int y = 0; y < pricesAzerty.Count(); y++)
            {
                if (pricesAzerty[y].Text != "")
                {
                    prices.Add(Convert.ToDouble(pricesAzerty[y].Text));
                }
            }

            for (int i = 0; i < 5; i++)
            {
                ProductsAzerty.Add(new Product(titlesAzerty[i].Text,
                                                prices[i],
                                                "not defined",
                                                descriptionAzerty[i].Text,
                                                deliveryAzerty[i].Text));
            }

            driverAzerty.Quit();

            if (ProductsAlternate[0].Price < ProductsAzerty[0].Price)
            {
                for (int x = 0; x < 5; x++)
                {
                    ProductsAlternate[x].CheapestPrice = ProductsAlternate[0].Price;
                    ProductsAlternate[x].CheapestPriceWebsite = FirstSite;
                    ProductsAlternate[x].CheapestProduct = ProductsAlternate[0].Title;

                    ProductsAzerty[x].CheapestPrice = ProductsAlternate[0].Price;
                    ProductsAzerty[x].CheapestPriceWebsite = FirstSite;
                    ProductsAzerty[x].CheapestProduct = ProductsAlternate[0].Title;
                }
            }
            else
            {
                for (int x = 0; x < 5; x++)
                {
                    ProductsAlternate[x].CheapestPrice = ProductsAzerty[0].Price;
                    ProductsAlternate[x].CheapestPriceWebsite = SecondSite;
                    ProductsAlternate[x].CheapestProduct = ProductsAzerty[0].Title;

                    ProductsAzerty[x].CheapestPrice = ProductsAzerty[0].Price;
                    ProductsAzerty[x].CheapestPriceWebsite = SecondSite;
                    ProductsAzerty[x].CheapestProduct = ProductsAzerty[0].Title;
                }
            }

            List<Product> products = new List<Product>();
            products.AddRange(ProductsAlternate);
            products.AddRange(ProductsAzerty);
            ExportToCsv<Product>.Export(products, "Products.csv");
            ExportToJson<Product>.Export(products, "Products.json");
        }

        public string GetFirstURL()
        {
            return FirstSite;
        }

        public string GetSecondURL()
        {
            return SecondSite;
        }

        public List<Product> GetAlternateProducts()
        {
            return ProductsAlternate;
        }

        public List<Product> GetAzertyProducts()
        {
            return ProductsAzerty;
        }
    }
}
