using TributoJusto.Business.Validations;
using TributoJusto.Tests.UnitTests.Fixtures;

namespace TributoJusto.Tests.UnitTests.Filmes
{
    [Collection(nameof(FilmeCollection))]
    public class FilmeTests
    {
        private readonly FilmeTestsFixture _FilmeTestsFixture;

        public FilmeTests(FilmeTestsFixture FilmeTestsFixture)
        {
            _FilmeTestsFixture = FilmeTestsFixture;
        }

        [Fact(DisplayName = "Novo Filme Válido")]
        [Trait("Categoria", "Filme Fixture Tests")]
        public void Filme_NewFilme_MustBeValid()
        {
            // Arrange
            var filme = _FilmeTestsFixture.CriarFilmeValido();

            // Act
            var result = new FilmeValidation().Validate(filme);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact(DisplayName = "Novo Filme Inválido")]
        [Trait("Categoria", "Filme Fixture Tests")]
        public void Filme_NewFilme_MustBeInvalid()
        {
            // Arrange
            var filme = _FilmeTestsFixture.CriarFilmeInvalido();

            // Act
            var result = new FilmeValidation().Validate(filme);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Equal(9, result.Errors.Count);
        }
    }
}
