using TributoJusto.Business.Models;

namespace TributoJusto.Business.Interfaces.Services
{
    public interface ILivroService : IDisposable
    {
        Task Create(Livro livro);
        Task Delete(Guid id);
    }
}
