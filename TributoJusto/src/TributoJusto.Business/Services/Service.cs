using TributoJusto.Business.Interfaces.Notification;

namespace TributoJusto.Business.Services
{
    public class Service
    {
        protected readonly INotificador _notificador;

        public Service(INotificador notificador)
        {
            _notificador = notificador;
        }
    }
}
