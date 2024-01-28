using System.ComponentModel.DataAnnotations;

namespace TributoJusto.API.ViewModels
{
    public class FilmeViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Year { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Director { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Writer { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Actors { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Plot { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Country { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ImdbRating { get; set; }
    }
}
