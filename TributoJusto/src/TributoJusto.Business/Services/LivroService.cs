using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TributoJusto.Business.Interfaces.Notification;
using TributoJusto.Business.Interfaces.Repository;
using TributoJusto.Business.Interfaces.Services;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Services
{
    public class LivroService : Service, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository,
                            INotificador notificador) : base(notificador)
        {
            _livroRepository = livroRepository;
        }

        public Task Create(Livro livro)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
