using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TributoJusto.Business.Interfaces.Notification;

namespace TributoJusto.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Erros = new List<string>();
        protected readonly INotificador _notificador;

        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            List<string> erros = new List<string>();
            erros.AddRange(_notificador.GetNotificacoes().Select(x => x.Mensagem));

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Erros", erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool OperacaoValida()
        {

            return !_notificador.TemNotificacao();
        }

        protected void AdicionarErroProcessamento(string erro)
        {

            _notificador.AdicionarNotificacao(new Business.Notifications.Notificacao(erro));
        }
    }
}



