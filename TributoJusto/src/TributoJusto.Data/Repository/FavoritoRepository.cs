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
    }
}
