using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TributoJusto.Business.Interfaces.Notification;
using TributoJusto.Business.Interfaces.Services;

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
