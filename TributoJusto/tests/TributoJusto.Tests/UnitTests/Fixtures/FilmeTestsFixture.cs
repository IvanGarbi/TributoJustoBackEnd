using TributoJusto.Business.Models;

namespace TributoJusto.Tests.UnitTests.Fixtures
{
    [CollectionDefinition(nameof(FilmeCollection))]
    public class FilmeCollection : ICollectionFixture<FilmeTestsFixture>
    { }
    public class FilmeTestsFixture : IDisposable
    {
        public Filme CriarFilmeValido()
        {
            var filme = new Filme()
            {
                Id = Guid.NewGuid(),
                Country = "United States, China, Japan",
                Title = "Fast X",
                Actors = "Vin Diesel, Michelle Rodriguez, Jason Statham",
                Director = "Louis Leterrier, Justin Lin",
                Genre = "Action, Adventure, Crime",
                ImdbRating = "5.8",
                Plot = "Dom Toretto and his family are targeted by the vengeful son of drug kingpin Hernan Reyes.",
                Writer = "Dan Mazeau, Justin Lin, Zach Dean",
                Year = "2023"
            };

            return filme;
        }

        public Filme CriarFilmeInvalido()
        {
            var filme = new Filme()
            {
                Id = Guid.NewGuid(),
                Country = "",
                Title = "",
                Actors = "",
                Director = "",
                Genre = "",
                ImdbRating = "",
                Plot = "",
                Writer = "",
                Year = ""
            };

            return filme;
        }

        public void Dispose()
        {

        }
    }
}
