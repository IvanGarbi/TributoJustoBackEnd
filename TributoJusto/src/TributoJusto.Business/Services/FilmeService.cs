using TributoJusto.Business.Interfaces.Notification;
using TributoJusto.Business.Interfaces.Repository;
using TributoJusto.Business.Interfaces.Services;
using TributoJusto.Business.Models;
using TributoJusto.Business.Notifications;
using TributoJusto.Business.Validations;

namespace TributoJusto.Business.Services
{
    public class FilmeService : Service, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository,
                            INotificador notificador) : base(notificador)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task Create(Filme filme)
        {
            var validator = new FilmeValidation();
            var resultValidation = validator.Validate(filme);

            if (!resultValidation.IsValid)
            {
                foreach (var error in resultValidation.Errors)
                {
                    _notificador.AdicionarNotificacao(new Notificacao(error.ErrorMessage, error.PropertyName));
                }

                return;
            }

            await _filmeRepository.Create(filme);
        }

        public async Task Delete(Guid id)
        {
            var filmeDb = await _filmeRepository.GetById(id);

            if (filmeDb == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Nenhum filme identificado."));
                return;
            }

            await _filmeRepository.Delete(id);
        }

        public async void Dispose()
        {
            _filmeRepository?.Dispose();
        }
    }
}
