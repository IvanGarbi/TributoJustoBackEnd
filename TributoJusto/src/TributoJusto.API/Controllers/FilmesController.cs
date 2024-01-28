using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TributoJusto.API.ViewModels;
using TributoJusto.Business.Interfaces.Repository;

namespace TributoJusto.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class FilmesController : MainController
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;

        public FilmesController(IFilmeRepository filmeRepository,
                                IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

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

        [HttpGet("Favorito/{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Get(Guid id)
        {
            return CustomResponse(_mapper.Map<FilmeViewModel>(await _filmeRepository.ReadById(id)));
        }

        [HttpPost("Favoritar/{id:guid}")]
        public async Task<IActionResult> Post(string nomeFilme)
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
