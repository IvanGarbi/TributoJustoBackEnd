using TributoJusto.Business.Models;

namespace TributoJusto.Tests.UnitTests.Fixtures
{
    [CollectionDefinition(nameof(FavoritoCollection))]
    public class FavoritoCollection : ICollectionFixture<FavoritoTestsFixture>
    { }
    public class FavoritoTestsFixture : IDisposable
    {
        public Favorito CriarFavoritoValido()
        {
            var favorito = new Favorito()
            {
                Id = Guid.NewGuid(),
                UsuarioId = Guid.NewGuid(),
                FilmeId = Guid.NewGuid(),
                LivroId = null,
            };

            return favorito;
        }

        public Favorito CriarFavoritoInvalido()
        {
            var favorito = new Favorito()
            {
                Id = Guid.NewGuid(),
                UsuarioId = Guid.Empty,
                FilmeId = null,
                LivroId = null,
            };

            return favorito;
        }

        public void Dispose()
        {

        }
    }
}
