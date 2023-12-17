using Newtonsoft.Json;

namespace Webscraper
{
    internal class ExportToJson<T>
    {
        public static void Export(List<T> objects, string fileName)
        {
            string stringjson = JsonConvert.SerializeObject(objects, Formatting.Indented);
            File.WriteAllText(fileName, stringjson);
        }
    }
}
