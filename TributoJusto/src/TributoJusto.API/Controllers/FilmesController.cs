using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TributoJusto.API.ViewModels;

namespace TributoJusto.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class FilmesController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> Get(string nomeFilme)
        {
            using (HttpClient client = new HttpClient())
            {

                //string searchTerm = "Fast";
                string searchTerm = nomeFilme;

                string apiKey = ""; // Substitua com sua chave de API do Google Books
                string apiUrl = $"http://www.omdbapi.com/?i=tt3896198&apikey={apiKey}&t={searchTerm}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var responseObject = JsonSerializer.Deserialize<RootMovieObject>(result);

                    return CustomResponse(responseObject);
                    // Aqui você pode processar os dados retornados conforme necessário
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
