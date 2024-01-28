using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Interfaces.Services
{
    public interface IFilmeService : IDisposable
    {
        Task Create(Filme filme);
        Task Delete(Guid id);
    }
}
