using CsvHelper;
using System.Globalization;
using System.Text;

namespace Webscraper
{
    internal class ExportToCsv<T>
    {
        public static void Export(List<T> objects, string fileName)
        {
            // Create a StreamWriter to write to a file
            using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                // Create a CsvWriter with the comma delimiter
                writer.WriteLine("sep=,");
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    // Write the records to the file
                    csv.WriteRecords(objects);
                }
            }
        }
    }
}
