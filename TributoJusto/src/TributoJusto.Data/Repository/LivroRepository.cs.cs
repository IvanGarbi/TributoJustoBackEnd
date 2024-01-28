using TributoJusto.Business.Interfaces.Repository;
using TributoJusto.Business.Models;
using TributoJusto.Data.Context;

namespace TributoJusto.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(TributoJustoDbContext context) : base(context)
        {

        }
    }
}
