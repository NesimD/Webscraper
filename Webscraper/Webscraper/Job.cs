// We zetten de class "Job" in de namespace "Webscraper"
namespace Webscraper
{
    // We maken hier een internal class aan genaamd "Job"
    internal class Job
    {
        // Dit zijn de properties van de class "Job"
        // We gebruiken deze properties om de titels te maken in de CSV bestand en in het json bestand
        // We maken een public property aan genaamd "Title".
        // We maken voor de property "Title" ook een getter en setter aan.
        public string Title { get; set; }
        // We maken een public property aan genaamd "Company".
        // We maken voor de property "Company" ook een getter en setter aan.
        public string Company { get; set; }
        // We maken een public property aan genaamd "Location".
        // We maken voor de property "Location" ook een getter en setter aan.
        public string Location { get; set; }
        // We maken een public property aan genaamd "Keyword".
        // We maken voor de property "Keyword" ook een getter en setter aan.
        public string Keyword { get; set; }
        // We maken een public property aan genaamd "Link".
        // We maken voor de property "Link" ook een getter en setter aan.
        public string Link { get; set; }

        // We maken een constructor aan die als parameter title, company, location, keyword en link heeft
        // We maken een constructor aan omdat de constructor de objecten maakt
        public Job(string title, string company, string location, string keyword, string link)
        {
            // We zetten de waarde dat in de variable "title" staat. In de property "Title"
            this.Title = title;
            // We zetten de waarde dat in de variable "company" staat. In de property "Company"
            this.Company = company;
            // We zetten de waarde dat in de variable "location" staat. In de property "Location"
            this.Location = location;
            // We zetten de waarde dat in de variable "keyword" staat. In de property "Keyword"
            this.Keyword = keyword;
            // We zetten de waarde dat in de variable "link" staat. In de property "Link"
            this.Link = link;
        }
    }
}
