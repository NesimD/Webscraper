// importeren CsvHelper
using CsvHelper;
// importeren System.Globalization
using System.Globalization;
// importeren System.Text
using System.Text;

// We zetten de class "ExportToCsv" in de namespace "Webscraper"
namespace Webscraper
{
    // We maken hier een internal generic class aan genaamd "ExportToCsv"
    // De letter "T" bij de class naam. Betekent dat we een generic class maken.
    // We doen dit omdat we verschillende soorten objecten willen kunnen ontvangen
    internal class ExportToCsv<T>
    {
        // We maken een static methode aan genaamd "Export".
        // Deze methode heeft geen return, dit kan je zien omdat we void gebruiken als type.
        // De static methode "Export" heeft als paremeter "objects". dit is een lijst dat verschillende objecten kan binnen krijgen.
        // Vervolgens heeft het ook nog de parameter "fileName"
        // Deze methode schrijft alle objecten naar een Csv bestand
        public static void Export(List<T> objects, string fileName)
        {
            // We maken een StreamWriter aan het bestand te open.
            // We geven de variable "fileName", false, Encoding.UTF8 mee.
            // Dit doen we zodat we de naam van het bestand kunnen kiezen.
            // We geven ook false mee. Dit zorgt ervoor als het bestand bestaat dat het overschreven wordt.
            // We geven ook Encoding.UTF8 mee zodat we UTF8 characters kunnen weg schrijven naar het bestand
            using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                // We zeggen dat de data gesplits moet worden bij een komma
                writer.WriteLine("sep=,");
                // We maken een Csvwriter object aan en we geven als parameter writer en CultureInfo.InvariantCulture mee.
                // We doen dit zodat de Csvwriter object weet naar welke bestand hij moet schrijven en we vertellen met "CultureInfo.InvariantCulture" dat we niet culture afhankelijk zijn
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    // Schrijft alle objects naar een Csv bestand
                    csv.WriteRecords(objects);
                }
            }
        }
    }
}
