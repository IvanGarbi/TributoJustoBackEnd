
namespace TributoJusto.Business.Models
{
    public class Filme : Entity
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Country { get; set; }
        public string ImdbRating { get; set; }

        public IEnumerable<Favorito> Favoritos { get; set; }
    }
}
