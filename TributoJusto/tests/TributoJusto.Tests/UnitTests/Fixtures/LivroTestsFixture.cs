using TributoJusto.Business.Models;

namespace TributoJusto.Tests.UnitTests.Fixtures
{
    [CollectionDefinition(nameof(LivroCollection))]
    public class LivroCollection : ICollectionFixture<LivroTestsFixture>
    { }
    public class LivroTestsFixture : IDisposable
    {
        public Livro CriarLivroValido()
        {
            var livro = new Livro()
            {
                Id = Guid.NewGuid(),
                Amount = 1,
                Authors = "J.K. Rowling",
                Categories = "Juvenile Fiction",
                Country = "BR",
                CountrySale = "BR",
                CurrencyCode = "BRL",
                Description = "Você está compartilhando os pensamentos e emoções do Lorde das Trevas. " +
                              "O diretor acha que é desaconselhável que isto continue a acontecer. E quer que eu lhe ensine como fechar a mente ao Lorde das Trevas.' " +
                              "Tempos sombrios se abateram sobre Hogwarts. Depois do ataque dos Dementadores ao seu primo Dudley, Harry Potter sabe que Voldemort fará tudo para encontrá-lo. " +
                              "Muitos negam o retorno do Lorde das Trevas, mas Harry não está sozinho: uma ordem secreta se reúne no Largo Grimmauld para fazer frente às forças sombrias. " +
                              "Harry precisa permitir que o professor Snape o ensine a se proteger dos vorazes ataques de Voldemort à sua mente. Mas eles estão ficando cada vez mais fortes, e o tempo de Harry está acabando...",
                PageCount = 997,
                Publisher = "Pottermore Publishing",
                Saleability = "FOR_SALE",
                Title = "Harry Potter e a Ordem da Fênix"
            };

            return livro;
        }

        public Livro CriarLivroInvalido()
        {
            var livro = new Livro()
            {
                Id = Guid.NewGuid(),
                Amount = 0,
                Authors = "",
                Categories = "",
                Country = "",
                CountrySale = "",
                CurrencyCode = "",
                Description = "",
                PageCount = 0,
                Publisher = "",
                Saleability = "",
                Title = ""
            };

            return livro;
        }

        public void Dispose()
        {

        }
    }
}
