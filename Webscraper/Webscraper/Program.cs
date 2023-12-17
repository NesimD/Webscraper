// We zetten de class "Program" in de namespace "Webscraper"
namespace Webscraper
{
    // We maken hier een internal class aan genaamd "Program"
    internal class Program
    {
        // Maakt een entry point aan voor het programma
        static void Main(string[] args)
        {
            // We maken een variable aan genaamd "run" en we stoppen de waarde true in deze variable
            // We maken deze variable aan om de while te kunnen stoppen wanneer we het willen.
            var run = true;

            // We starten hier een do while loop
            // De code hieronder wordt al zeker 1 keer uit gevoerd
            // Vervolgens gaat de code in een loop blijven uitgevoerd worden tot de variable "run" false is
            do
            {
                // We tonen de intro page van de webscraper
                // We doen dit door de static methode "IntroPage" aan te roepen van de class "ScraperConsole"
                ScraperConsole.IntroPage();
                // De input van de gebruiker wordt omgevormd naar hoofdletters en wordt dan opgeslagen als een string in de variable "choice"
                string choice = Console.ReadLine().ToUpper();
                // We gebruiken een switch om te kiezen welke website we willen scrapen
                switch (choice)
                {
                    // Als de gebruiker een "A" ingeeft dan wordt aan de gebruiker gevraagd.
                    // Naar wat hij wilt zoeken op YouTube. Dan worden de 5 recente videos gescrapt met de zoekterm dat de gebruiker heeft ingeven.
                    // Welke 5 meest recente YouTube videos hij wilt scrapen op basis van een zoekterm
                    case "A":
                        // We vragen de gebruiker voor een zoekterm in te geven.
                        // Vervolgens zetten we de zoekterm dat de gebruiker ingegven heeft in de variable "searchTerm"
                        // We doen dit door de static methode "SearchTerm" op te roepen van de class "ScraperConsole"
                        var searchTerm = ScraperConsole.SearchTerm();
                        // We gaan dan de 5 meest recente Youtube videos scrapen op basis van de zoekterm dat de gebruiker ingeven heeft
                        // We doen dit door de static methode "Youtube" op te roepen van de class "ScraperConsole"
                        ScraperConsole.Youtube(searchTerm);
                        // Als we de Youtube videos gescrapt hebben dan.
                        // Vragen we aan de gebruiker dat hij een andere website wilt scrappen.
                        // We doen dit door de static methode "ChooseOption" op te roepen van de class "ScraperConsole"
                        run = ScraperConsole.ChooseOption();
                        // Break zorgt ervoor dat we uit de switch block gaan
                        break;
                    // Als de gebruiker een "B" ingeeft dan wordt aan de gebruiker gevraagd.
                    // Naar welke job hij wilt zoeken op ictjob.be. Dan worden de 5 nieuwste job vactures gescrapt met de zoekterm dat de gebruiker heeft ingeven.
                    // Welke 5 meest recente YouTube videos hij wilt scrapen op basis van een zoekterm
                    case "B":
                        // We vragen de gebruiker voor een zoekterm in te geven.
                        // Vervolgens zetten we de zoekterm dat de gebruiker ingegven heeft in de variable "searchTerm"
                        // We doen dit door de static methode "SearchTerm" op te roepen van de class "ScraperConsole"
                        searchTerm = ScraperConsole.SearchTerm();
                        // We gaan dan de 5 nieuwste job vactures scrapen op basis van de zoekterm dat de gebruiker ingeven heeft
                        // We doen dit door de static methode "Job" op te roepen van de class "ScraperConsole"
                        ScraperConsole.Job(searchTerm);
                        // Als we de job vacatures gescrapt hebben dan.
                        // Vragen we aan de gebruiker dat hij een andere website wilt scrappen.
                        // We doen dit door de static methode "ChooseOption" op te roepen van de class "ScraperConsole"
                        run = ScraperConsole.ChooseOption();
                        // Break zorgt ervoor dat we uit de switch block gaan
                        break;
                    // Als de gebruiker een "C" ingeeft dan wordt aan de gebruiker gevraagd.
                    // Naar welke product hij wilt zoeken op alternate.be en azerty.nl. Dan worden de 5 eerste producten gescrapt met de zoekterm dat de gebruiker heeft ingeven.
                    // Welke 5 meest recente YouTube videos hij wilt scrapen op basis van een zoekterm
                    case "C":
                        // We vragen de gebruiker voor een zoekterm in te geven.
                        // Vervolgens zetten we de zoekterm dat de gebruiker ingegven heeft in de variable "searchTerm"
                        // We doen dit door de static methode "SearchTerm" op te roepen van de class "ScraperConsole"
                        searchTerm = ScraperConsole.SearchTerm();
                        // We gaan dan de 5 eerste producten scrapen op beiden website. Op basis van de zoekterm dat de gebruiker ingeven heeft.
                        // We doen dit door de static methode "Product" op te roepen van de class "ScraperConsole"
                        ScraperConsole.Product(searchTerm);
                        // Als we de producten gescrapt hebben dan.
                        // Vragen we aan de gebruiker dat hij een andere website wilt scrappen.
                        // We doen dit door de static methode "ChooseOption" op te roepen van de class "ScraperConsole"
                        run = ScraperConsole.ChooseOption();
                        // Break zorgt ervoor dat we uit de switch block gaan
                        break;
                    // Als de gebruiker een enter klikt dan wordt de applicatie gestopt
                    case "":
                        // We printen "Exiting Nesim"s scraper in de console
                        Console.WriteLine("exiting Nesim's scraper");
                        // We zetten in de variable "run" de waarde false
                        // Hierdoor gaan we niet meer in de while loop
                        run = false;
                        // Break zorgt ervoor dat we uit de switch block gaan
                        break;
                    // Als de input van de gebruiker niet match met de cases hierboven dan wordt deze code block uitgevoerd
                    default:
                        // We printen "Input not recognised" in de console
                        Console.WriteLine("Input not recognised");
                        // Break zorgt ervoor dat we uit de switch block gaan
                        break;

                }
                // We blijven de code uitvoeren tot de waarde van de variable "run" false is
            } while (run);
        }
    }
}
