using TributoJusto.Business.Interfaces.Repository;
using TributoJusto.Business.Models;
using TributoJusto.Data.Context;

namespace TributoJusto.Data.Repository
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(TributoJustoDbContext context) : base(context)
        {

        }
    }
}
