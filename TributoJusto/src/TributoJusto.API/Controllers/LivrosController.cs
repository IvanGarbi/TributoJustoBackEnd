using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TributoJusto.API.ViewModels;

namespace TributoJusto.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class LivrosController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> Get(string nomeLivro)
        {
            using (HttpClient client = new HttpClient())
            {

                //string searchTerm = "Harry Potter";
                string searchTerm = nomeLivro;

                string apiKey = ""; // Substitua com sua chave de API do Google Books
                string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={searchTerm}&key={apiKey}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var responseObject = JsonSerializer.Deserialize<RootBookObject>(result);

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
