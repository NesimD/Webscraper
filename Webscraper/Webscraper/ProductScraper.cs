using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Webscraper
{
    internal class ProductScraper
    {
        private string FirstSite = "https://alternate.be/";
        private string SecondSite = "https://azerty.nl/";
        private string SearchTerm;
        private List<Product> ProductsAlternate = [];
        private List<Product> ProductsAzerty = [];

        public ProductScraper(string searchTerm)
        {
            this.SearchTerm = searchTerm;
        }

        public void Scrape()
        {
            List<double> prices = new List<double>();

            // Alternate
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("--headless=new");

            IWebDriver driverAlternate = new ChromeDriver(driverService, options);
            driverAlternate.Navigate().GoToUrl(FirstSite);
            driverAlternate.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var searchBarAlternate = driverAlternate.FindElement(By.XPath("//*[@id=\"searchbar-md\"]/form/div/input"));
            searchBarAlternate.SendKeys(SearchTerm);
            searchBarAlternate.Submit();

            SelectElement selectAlternate = new SelectElement(driverAlternate.FindElement(By.XPath("//*[@id=\"s\"]")));
            selectAlternate.SelectByText("Prijs oplopend");

            var titlesAlternate = driverAlternate.FindElements(By.ClassName("product-name"));
            var pricesAlternate = driverAlternate.FindElements(By.ClassName("price"));
            var stocksAlternate = driverAlternate.FindElements(By.ClassName("delivery-info"));
            SelectElement specs = new SelectElement(driverAlternate.FindElement(By.XPath("//*[@id=\"s\"]")));
            var unorderLists = driverAlternate.FindElements(By.ClassName("product-info"));

            for (int i = 0; i < 5; i++)
            {
                ProductsAlternate.Add(new Product(titlesAlternate[i].Text,
                                         Convert.ToDouble(pricesAlternate[i].Text.Substring(2)),
                                         stocksAlternate[i].Text,
                                         unorderLists[i].Text,
                                         "not define"));
            }

            driverAlternate.Quit();

            // Azerty
            IWebDriver driverAzerty = new ChromeDriver(driverService, options);
            driverAzerty.Navigate().GoToUrl(SecondSite);
            driverAzerty.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

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
