// importeren Newtonsoft.Json
using Newtonsoft.Json;

// We zetten de class "ExportToJson" in de namespace "Webscraper"
namespace Webscraper
{
    // We maken hier een internal generic class aan genaamd "ExportToJson"
    // De letter "T" bij de class naam. Betekent dat we een generic class maken.
    // We doen dit omdat we verschillende soorten objecten willen kunnen ontvangen
    internal class ExportToJson<T>
    {
        // We maken een static methode aan genaamd "Export".
        // Deze methode heeft geen return, dit kan je zien omdat we void gebruiken als type.
        // De static methode "Export" heeft als paremeter "objects". dit is een lijst dat verschillende objecten kan binnen krijgen.
        // Vervolgens heeft het ook nog de parameter "fileName"
        // Deze methode zet alle objecten om naar json en schrijft het naar een json bestand
        public static void Export(List<T> objects, string fileName)
        {
            // We vormen de objecten naar een json format en stoppen het in de variable "stringjson".
            // We geven "Formatting.Indented" als parameter mee zodat de json geformatteerd wordt met indents
            // Dit doen we omdat het meer leesbaar maakt
            string stringjson = JsonConvert.SerializeObject(objects, Formatting.Indented);
            // We schrijven de json naar een json bestand en we geven het bestand een naam
            File.WriteAllText(fileName, stringjson);
        }
    }
}
