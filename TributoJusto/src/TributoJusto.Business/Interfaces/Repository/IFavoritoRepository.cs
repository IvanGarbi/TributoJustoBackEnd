using System.Linq.Expressions;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Interfaces.Repository
{
    public interface IFavoritoRepository : IRepository<Favorito>
    {
        Task<IEnumerable<Favorito>> ReadExpressionFilme(Expression<Func<Favorito, bool>> predicateExpression);
        Task<IEnumerable<Favorito>> ReadExpressionLivro(Expression<Func<Favorito, bool>> predicateExpression);
    }
}
