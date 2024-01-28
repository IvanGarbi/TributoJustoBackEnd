using TributoJusto.Business.Interfaces.Notification;
using TributoJusto.Business.Interfaces.Repository;
using TributoJusto.Business.Interfaces.Services;
using TributoJusto.Business.Models;
using TributoJusto.Business.Notifications;
using TributoJusto.Business.Validations;

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

        public async Task Create(Livro livro)
        {
            var validator = new LivroValidation();
            var resultValidation = validator.Validate(livro);

            if (!resultValidation.IsValid)
            {
                foreach (var error in resultValidation.Errors)
                {
                    _notificador.AdicionarNotificacao(new Notificacao(error.ErrorMessage, error.PropertyName));
                }

                return;
            }

            await _livroRepository.Create(livro);
        }

        public async Task Delete(Guid id)
        {
            var livroDb = await _livroRepository.GetById(id);

            if (livroDb == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Nenhum livro identificado."));
                return;
            }

            await _livroRepository.Delete(id);
        }

        public async void Dispose()
        {
            _livroRepository?.Dispose();
        }
    }
}
