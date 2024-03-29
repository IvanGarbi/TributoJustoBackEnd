﻿using TributoJusto.Business.Interfaces.Notification;
using TributoJusto.Business.Interfaces.Repository;
using TributoJusto.Business.Interfaces.Services;
using TributoJusto.Business.Models;
using TributoJusto.Business.Notifications;
using TributoJusto.Business.Validations;

namespace TributoJusto.Business.Services
{
    public class FavoritoService : Service, IFavoritoService
    {
        private readonly IFavoritoRepository _favoritoRepository;

        public FavoritoService(IFavoritoRepository favoritoRepository,
                              INotificador notificador) : base(notificador)
        {
            _favoritoRepository = favoritoRepository;
        }

        public async Task Create(Favorito favorito)
        {
            var validator = new FavoritoValidation();
            var resultValidation = validator.Validate(favorito);

            if (!resultValidation.IsValid)
            {
                foreach (var error in resultValidation.Errors)
                {
                    _notificador.AdicionarNotificacao(new Notificacao(error.ErrorMessage, error.PropertyName));
                }

                return;
            }

            await _favoritoRepository.Create(favorito);
        }

        public async Task Delete(Guid id)
        {
            var favoritoDb = await _favoritoRepository.GetById(id);

            if (favoritoDb == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Nenhum favorito identificado."));
                return;
            }

            await _favoritoRepository.Delete(id);
        }

        public async void Dispose()
        {
            _favoritoRepository?.Dispose();
        }
    }
}
