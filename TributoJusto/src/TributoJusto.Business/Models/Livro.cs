
namespace TributoJusto.Business.Models
{
    public class Livro : Entity
    {
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Saleability { get; set; }
        public string Country { get; set; }
        public string CountrySale { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Categories { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }

        public IEnumerable<Favorito> Favoritos { get; set; }
    }
}
