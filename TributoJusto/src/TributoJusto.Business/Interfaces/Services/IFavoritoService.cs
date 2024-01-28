using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Interfaces.Services
{
    public interface IFavoritoService : IDisposable
    {
        Task Create(Favorito favorito);
        Task Delete(Guid id);
    }
}
