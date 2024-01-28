using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TributoJusto.API.Controllers;
using TributoJusto.API.ViewModels;
using TributoJusto.Business.Interfaces.Notification;

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
                string searchTerm = nomeFilme;

                string apiKey = ""; // Substitua com sua chave de API do Google Books
                string apiUrl = $"http://www.omdbapi.com/?i=tt3896198&apikey={apiKey}&t={searchTerm}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var responseObject = JsonSerializer.Deserialize<RootMovieObject>(result);

                    return CustomResponse(responseObject);
                }
                else
                {
                    Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
                    return BadRequest();
                }
            }
        }
    }
}
