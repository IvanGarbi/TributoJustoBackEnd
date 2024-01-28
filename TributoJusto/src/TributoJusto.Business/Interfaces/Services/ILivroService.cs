using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Interfaces.Services
{
    public interface ILivroService : IDisposable
    {
        Task Create(Livro livro);
        Task Delete(Guid id);
    }
}
