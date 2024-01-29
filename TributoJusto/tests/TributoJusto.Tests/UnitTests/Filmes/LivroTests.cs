using TributoJusto.Business.Validations;
using TributoJusto.Tests.UnitTests.Fixtures;

namespace TributoJusto.Tests.UnitTests.Livros
{
    [Collection(nameof(LivroCollection))]
    public class LivroTests
    {
        private readonly LivroTestsFixture _LivroTestsFixture;

        public LivroTests(LivroTestsFixture LivroTestsFixture)
        {
            _LivroTestsFixture = LivroTestsFixture;
        }

        [Fact(DisplayName = "Novo Livro Válido")]
        [Trait("Categoria", "Livro Fixture Tests")]
        public void Livro_NewLivro_MustBeValid()
        {
            // Arrange
            var livro = _LivroTestsFixture.CriarLivroValido();

            // Act
            var result = new LivroValidation().Validate(livro);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact(DisplayName = "Novo Livro Inválido")]
        [Trait("Categoria", "Livro Fixture Tests")]
        public void Livro_NewLivro_MustBeInvalid()
        {
            // Arrange
            var livro = _LivroTestsFixture.CriarLivroInvalido();

            // Act
            var result = new LivroValidation().Validate(livro);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Equal(2, result.Errors.Count);
        }
    }
}
