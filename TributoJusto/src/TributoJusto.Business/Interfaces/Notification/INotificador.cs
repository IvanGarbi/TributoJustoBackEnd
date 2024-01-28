using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TributoJusto.Business.Notifications;

namespace TributoJusto.Business.Interfaces.Notification
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> GetNotificacoes();
        void AdicionarNotificacao(Notificacao notificacao);
    }
}
