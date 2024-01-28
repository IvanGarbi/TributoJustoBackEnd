using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TributoJusto.Business.Interfaces.Repository;
using TributoJusto.Business.Models;
using TributoJusto.Data.Context;

namespace TributoJusto.Data.Repository
{
    public class FavoritoRepository : Repository<Favorito>, IFavoritoRepository
    {
        public FavoritoRepository(TributoJustoDbContext context) : base(context)
        {

        }


        // por algum motivo se eu colocar .Include(z => z.Livro)..Include(m => m.Filme) não é retornado nada do banco... Por isso dividi em 2 métodos
        public async Task<IEnumerable<Favorito>> ReadExpressionFilme(Expression<Func<Favorito, bool>> predicateExpression)
        {
            return await DbSet.AsNoTracking()
                                .Where(predicateExpression)
                                .Include(z => z.Filme)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Favorito>> ReadExpressionLivro(Expression<Func<Favorito, bool>> predicateExpression)
        {
            return await DbSet.AsNoTracking()
                                .Where(predicateExpression)
                                .Include(y => y.Livro)
                                .ToListAsync();
        }
    }
}
