namespace Webscraper
{
    internal class Youtube
    {
        public string Title { get; set; }
        public string Views { get; set; }
        public string Link { get; set; }
        public string Uploader { get; set; }

        public Youtube(string title, string views, string link)
        {
            this.Title = title;
            this.Views = views;
            this.Link = link;
            Uploader = "";
        }
    }
}
