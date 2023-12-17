namespace Webscraper
{
    internal class Product
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Stock { get; set; }
        public string Spec { get; set; }
        public string DeliveryTime { get; set; }
        public string CheapestProduct { get; set; }
        public double CheapestPrice { get; set; }
        public string CheapestPriceWebsite { get; set; }

        public Product(string title, double price, string stock, string spec, string deliveryTime)
        {
            this.Title = title;
            this.Price = price;
            this.Stock = stock;
            this.Spec = spec;
            this.DeliveryTime = deliveryTime;
        }
    }
}
