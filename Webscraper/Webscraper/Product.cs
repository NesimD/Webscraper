// We zetten de class "Job" in de namespace "Webscraper"
namespace Webscraper
{
    // We maken hier een internal class aan genaamd "Product"
    internal class Product
    {
        // Dit zijn de properties van de class "Product"
        // We gebruiken deze properties om de titels te maken in de CSV bestand en in het json bestand
        // We maken een public property aan genaamd "Title".
        // We maken voor de property "Title" ook een getter en setter aan.
        public string Title { get; set; }
        // We maken een public property aan genaamd "Price".
        // We maken voor de property "Price" ook een getter en setter aan.
        public double Price { get; set; }
        // We maken een public property aan genaamd "Stock".
        // We maken voor de property "Stock" ook een getter en setter aan.
        public string Stock { get; set; }
        // We maken een public property aan genaamd "Spec".
        // We maken voor de property "Spec" ook een getter en setter aan.
        public string Spec { get; set; }
        // We maken een public property aan genaamd "DeliveryTime".
        // We maken voor de property "DeliveryTime" ook een getter en setter aan.
        public string DeliveryTime { get; set; }
        // We maken een public property aan genaamd "CheapestProduct".
        // We maken voor de property "CheapestProduct" ook een getter en setter aan.
        public string CheapestProduct { get; set; }
        // We maken een public property aan genaamd "CheapestPrice".
        // We maken voor de property "CheapestPrice" ook een getter en setter aan.
        public double CheapestPrice { get; set; }
        // We maken een public property aan genaamd "CheapestPriceWebsite".
        // We maken voor de property "CheapestPriceWebsite" ook een getter en setter aan.
        public string CheapestPriceWebsite { get; set; }

        // We maken een constructor aan die als parameter title, price, stock, spec en deliveryTime heeft
        // We maken een constructor aan omdat de constructor de objecten maakt
        public Product(string title, double price, string stock, string spec, string deliveryTime)
        {
            // We zetten de waarde dat in de variable "title" staat. In de property "Title"
            this.Title = title;
            // We zetten de waarde dat in de variable "price" staat. In de property "Price"
            this.Price = price;
            // We zetten de waarde dat in de variable "stock" staat. In de property "Stock"
            this.Stock = stock;
            // We zetten de waarde dat in de variable "spec" staat. In de property "Spec"
            this.Spec = spec;
            // We zetten de waarde dat in de variable "deliveryTime" staat. In de property "DeliveryTime"
            this.DeliveryTime = deliveryTime;
        }
    }
}
