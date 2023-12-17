namespace Webscraper
{
    internal class ScraperConsole
    {
        public static void IntroPage()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Welcome to Nesim's Webscraper");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Which website do you wish to scrape:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Type A to scrape Youtube");
            Console.WriteLine("Type B to scrape Jobsite.be");
            Console.WriteLine("Type C to check price of a certain item");
            Console.WriteLine("Press enter to exit");
            Console.WriteLine(" ");
            Console.Write("Enter choice: ");
        }

        public static string SearchTerm()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Please enter a search term");
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine();
            Console.Write("Search Term: ");
            string searchTerm = Console.ReadLine();

            while (searchTerm == "")
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("You haven't enter a search term");
                Console.WriteLine("Please enter a search term");
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine();
                Console.Write("Search Term: ");
                searchTerm = Console.ReadLine();
            }

            return searchTerm;
        }

        public static bool ChooseOption()
        {
            Console.WriteLine("Do you want to scrape another website? (y/n)");
            var input = Console.ReadLine().ToUpper();

            if (input == "Y")
            {
                return true;
            }
            return false;
        }

        public static void Youtube(string searchTerm)
        {
            Console.Clear();
            YoutubeScraper youtubeScraper = new YoutubeScraper(searchTerm);

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Scraping {youtubeScraper.GetURL()}");
            Console.WriteLine("Please wait...");
            Console.WriteLine("-------------------------------------------------------");

            youtubeScraper.Scrape();

            Console.Clear();

            var youtubes = youtubeScraper.GetYoutubes();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Youtube Video {i+1}");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Youtube Title: {youtubes[i].Title}");
                Console.WriteLine($"Uploader: {youtubes[i].Uploader}");
                Console.WriteLine($"Views: {youtubes[i].Views}");
                Console.WriteLine($"Youtube Link: {youtubes[i].Link}");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }
        }

        public static void Job(string searchTerm)
        {
            Console.Clear();
            JobScraper jobScraper = new JobScraper(searchTerm);

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Scraping {jobScraper.GetURL()}");
            Console.WriteLine("Please wait...");
            Console.WriteLine("-------------------------------------------------------");

            jobScraper.Scrape();

            Console.Clear();

            var jobs = jobScraper.GetJobs();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Job Vacture {i+1}");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Title: {jobs[i].Title}");
                Console.WriteLine($"Company: {jobs[i].Company}");
                Console.WriteLine($"Keywords: {jobs[i].Keyword}");
                Console.WriteLine($"Link: {jobs[i].Link}");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }
        }

        public static void Product(string searchTerm)
        {
            Console.Clear();
            ProductScraper productScraper = new ProductScraper(searchTerm);

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Scraping {productScraper.GetFirstURL()} and {productScraper.GetSecondURL()}");
            Console.WriteLine("Please wait...");
            Console.WriteLine("-------------------------------------------------------");

            productScraper.Scrape();

            Console.Clear();

            var productsAlternate = productScraper.GetAlternateProducts();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Alternate product {i+1}");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Title: {productsAlternate[i].Title}");
                Console.WriteLine($"Price: {productsAlternate[i].Price}");
                Console.WriteLine($"Stock: {productsAlternate[i].Stock}");
                Console.WriteLine($"Specifications: {productsAlternate[i].Spec}");
                Console.WriteLine($"DeliveryTime: {productsAlternate[i].DeliveryTime}");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }


            var productsAzerty = productScraper.GetAzertyProducts();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Azerty product {i+1}");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Title: {productsAzerty[i].Title}");
                Console.WriteLine($"Price: {productsAzerty[i].Price}");
                Console.WriteLine($"Stock: {productsAzerty[i].Stock}");
                Console.WriteLine($"Specifications: {productsAzerty[i].Spec}");
                Console.WriteLine($"DeliveryTime: {productsAzerty[i].DeliveryTime}");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }
            
            Console.WriteLine($"{productsAlternate[0].CheapestProduct} is the cheapest on {productsAlternate[0].CheapestPriceWebsite} for {productsAlternate[0].CheapestPrice} euro");
        }
    }
}
