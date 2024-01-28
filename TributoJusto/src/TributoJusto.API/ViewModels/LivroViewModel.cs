using System.ComponentModel.DataAnnotations;

namespace TributoJusto.API.ViewModels
{
    public class LivroViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CurrencyCode { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Saleability { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Country { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CountrySale { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Authors { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Categories { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get; set; }
    }
}
