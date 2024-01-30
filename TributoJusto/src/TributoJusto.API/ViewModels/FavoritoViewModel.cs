
namespace TributoJusto.API.ViewModels
{
    public class FavoritoViewModel
    {
        public Guid? FilmeId { get; set; }
        public Guid? LivroId { get; set; }
        public Guid UsuarioId { get; set; }

        public LivroViewModel LivroViewModel { get; set; }
        public FilmeViewModel FilmeViewModel { get; set; }
    }
}
