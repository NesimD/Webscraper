// We zetten de class "Job" in de namespace "Webscraper"
namespace Webscraper
{
    // We maken hier een internal class aan genaamd "Youtube"
    internal class Youtube
    {
        // Dit zijn de properties van de class "Youtube"
        // We gebruiken deze properties om de titels te maken in de CSV bestand en in het json bestand
        // We maken een public property aan genaamd "Title".
        // We maken voor de property "Title" ook een getter en setter aan.
        public string Title { get; set; }
        // We maken een public property aan genaamd "Views".
        // We maken voor de property "Views" ook een getter en setter aan.
        public string Views { get; set; }
        // We maken een public property aan genaamd "Link".
        // We maken voor de property "Link" ook een getter en setter aan.
        public string Link { get; set; }
        // We maken een public property aan genaamd "Uploader".
        // We maken voor de property "Uploader" ook een getter en setter aan.
        public string Uploader { get; set; }

        // We maken een constructor aan die als parameter title, views en link heeft
        // We maken een constructor aan omdat de constructor de objecten maakt
        public Youtube(string title, string views, string link)
        {
            // We zetten de waarde dat in de variable "title" staat. In de property "Title"
            this.Title = title;
            // We zetten de waarde dat in de variable "views" staat. In de property "Views"
            this.Views = views;
            // We zetten de waarde dat in de variable "link" staat. In de property "Link"
            this.Link = link;
            // We zetten een lege waarde in de property "Link"
            this.Uploader = "";
        }
    }
}
