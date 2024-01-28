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
    public class FavoritoService : Service, IFavoritoService
    {
        private readonly IFavoritoRepository _favoritoRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IFilmeRepository _filmeRepository;

        public FavoritoService(IFavoritoRepository favoritoRepository,
                              ILivroRepository livroRepository,
                              IFilmeRepository filmeRepository,
                              INotificador notificador) : base(notificador)
        {
            _favoritoRepository = favoritoRepository;
            _livroRepository = livroRepository;
            _filmeRepository = filmeRepository;
        }

        public Task Create(Favorito favorito)
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
