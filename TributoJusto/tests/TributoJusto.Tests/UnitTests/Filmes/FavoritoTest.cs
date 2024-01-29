using TributoJusto.Business.Validations;
using TributoJusto.Tests.UnitTests.Fixtures;

namespace TributoJusto.Tests.UnitTests.Favoritos
{
    [Collection(nameof(FavoritoCollection))]
    public class FavoritoTests
    {
        private readonly FavoritoTestsFixture _FavoritoTestsFixture;

        public FavoritoTests(FavoritoTestsFixture FavoritoTestsFixture)
        {
            _FavoritoTestsFixture = FavoritoTestsFixture;
        }

        [Fact(DisplayName = "Novo Favorito Válido")]
        [Trait("Categoria", "Favorito Fixture Tests")]
        public void Favorito_NewFavorito_MustBeValid()
        {
            // Arrange
            var favorito = _FavoritoTestsFixture.CriarFavoritoValido();

            // Act
            var result = new FavoritoValidation().Validate(favorito);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact(DisplayName = "Novo Favorito Inválido")]
        [Trait("Categoria", "Favorito Fixture Tests")]
        public void Favorito_NewFavorito_MustBeInvalid()
        {
            // Arrange
            var favorito = _FavoritoTestsFixture.CriarFavoritoInvalido();

            // Act
            var result = new FavoritoValidation().Validate(favorito);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Equal(2, result.Errors.Count);
        }
    }
}
