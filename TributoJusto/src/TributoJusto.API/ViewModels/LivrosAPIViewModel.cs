namespace TributoJusto.API.ViewModels
{
    public class RootBookObject
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
        //public Guid Id { get; set; } = Guid.NewGuid();
        public VolumeInfo volumeInfo { get; set; }
        public AccessInfo accessInfo { get; set; }
        public SaleInfo saleInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public string[] categories { get; set; }
        public string publisher { get; set; }
        public int pageCount { get; set; }
        public string description { get; set; }
    }

    public class AccessInfo
    {
        public string country { get; set; }
    }

    public class SaleInfo
    {
        public string country { get; set; }
        public RetailPrice retailPrice { get; set; }
        public string saleability { get; set; }
    }

    public class RetailPrice
    {
        public decimal amount { get; set; }
        public string currencyCode { get; set; }
    }
}
