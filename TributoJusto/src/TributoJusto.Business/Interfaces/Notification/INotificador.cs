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
