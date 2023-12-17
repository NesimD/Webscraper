using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Webscraper
{
    internal class YoutubeScraper
    {
        private string Url = "https://www.youtube.com/";
        private string SearchTerm = "";
        private List<Youtube> Youtubes = [];

        public YoutubeScraper(string searchTerm)
        {
            this.SearchTerm = searchTerm;
        }

        public void Scrape()
        {
            List<string> channelNames = new List<string>();

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("--headless=new");

            IWebDriver driver = new ChromeDriver(driverService,options);
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2);
            
            var youtubePopup = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[6]/div[1]/ytd-button-renderer[1]/yt-button-shape/button"));
            youtubePopup.Click();

            var searchBar = driver.FindElement(By.XPath("//input[@id=\"search\"]"));
            Thread.Sleep(1000);
            searchBar.SendKeys(SearchTerm);
            searchBar.Submit();

            var titles = driver.FindElements(By.XPath("//*[@id=\"video-title\"]/yt-formatted-string"));
            var uploaders = driver.FindElements(By.XPath("//*[@id=\"text\"]/a"));
            var views = driver.FindElements(By.XPath("//*[@id=\"metadata-line\"]/span[1]"));
            var links = driver.FindElements(By.CssSelector("#video-title.ytd-video-renderer"));

            for (int i = 0; i < 5; i++)
            {
                Youtubes.Add(new Youtube(titles[i].Text,
                                         views[i].Text,
                                         links[i].GetAttribute("href")));
            }

            for (int x = 1;x < 10; x++)
            {
                if (uploaders[x].Text != "")
                {
                    channelNames.Add(uploaders[x].Text);
                }
            }

            for (var y = 0; y < 5; y++)
            {
                Youtubes[y].Uploader = channelNames[y];
            }

            driver.Quit();

            ExportToCsv<Youtube>.Export(Youtubes, "YoutubeVideos.csv");
            ExportToJson<Youtube>.Export(Youtubes, "YoutubeVideos.json");
        }

        public string GetURL()
        {
            return Url;
        }
        public List<Youtube> GetYoutubes()
        {
            return Youtubes;
        }
    }
}
