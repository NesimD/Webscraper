namespace Webscraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var run = true;

            do { 
                ScraperConsole.IntroPage();

            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "A":
                        var searchTerm = ScraperConsole.SearchTerm();
                        ScraperConsole.Youtube(searchTerm);
                        run = ScraperConsole.ChooseOption();
                        break;
                case "B":
                        searchTerm = ScraperConsole.SearchTerm();
                        ScraperConsole.Job(searchTerm);
                        run = ScraperConsole.ChooseOption();
                        break;
                case "C":
                        searchTerm = ScraperConsole.SearchTerm();
                        ScraperConsole.Product(searchTerm);
                        run = ScraperConsole.ChooseOption();
                        break;
                case "":
                        Console.WriteLine("exiting Nesim's scraper");
                        run = false;
                        break;
                default:
                        Console.WriteLine("Input not recognised");
                        break;

            }
            } while (run);
        }
    }
}
