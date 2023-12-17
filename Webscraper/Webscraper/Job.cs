namespace Webscraper
{
    internal class Job
    {
        public string Title {  get; set; }
        public string Company {  get; set; }
        public string Location { get; set; }
        public string Keyword { get; set; }
        public string Link { get; set; }

        public Job(string title, string company, string location, string keyword, string link)
        {
            this.Title = title;
            this.Company = company;
            this.Location = location;
            this.Keyword = keyword;
            this.Link = link;
        }
    }
}
