using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TributoJusto.API.Controllers;
using TributoJusto.API.ViewModels;
using TributoJusto.Business.Interfaces.Notification;
using TributoJusto.Business.Notifications;

namespace TributoJusto.API.V1.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class FilmesController : MainController
    {
        public FilmesController(INotificador notificador) : base(notificador)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get(string nomeFilme)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = ""; // Substitua com sua chave de API do Google Books
                string apiUrl = $"http://www.omdbapi.com/?i=tt3896198&apikey={apiKey}&t={nomeFilme}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var responseObject = JsonSerializer.Deserialize<RootMovieObject>(result);

                    return CustomResponse(responseObject);
                }
                else
                {
                    _notificador.AdicionarNotificacao(new Notificacao("Ocorreu um erro ao consultar a API terceira de filmes"));
                    
                    return CustomResponse();
                }
            }
        }
    }
}
