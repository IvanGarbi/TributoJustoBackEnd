using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TributoJusto.API.Controllers;
using TributoJusto.API.ViewModels;
using TributoJusto.Business.Interfaces.Notification;
using TributoJusto.Business.Interfaces.Repository;
using TributoJusto.Business.Interfaces.Services;
using TributoJusto.Business.Models;

namespace TributoJusto.API.V1.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class FavoritoController : MainController
    {
        private readonly IFavoritoRepository _favoritoRepository;
        private readonly IFavoritoService _favoritoService;
        private readonly IFilmeService _filmeService;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly INotificador _notificador;

        public FavoritoController(IFavoritoRepository favoritoRepository,
                                  IFavoritoService favoritoService,
                                  ILivroService livroService,
                                  UserManager<IdentityUser> userManager,
                                  IFilmeService filmeService,
                                  INotificador notificador,
                                  IMapper mapper) : base(notificador)
        {
            _favoritoRepository = favoritoRepository;
            _favoritoService = favoritoService;
            _filmeService = filmeService;
            _livroService = livroService;
            _mapper = mapper;
            _userManager = userManager;
            _notificador = notificador;
        }

        [HttpGet("Favoritos/{usuarioId:guid}")]
        public async Task<ActionResult<FavoritoViewModel>> Get(Guid usuarioId)
        {
            var filmesFavoritos = await _favoritoRepository.ReadExpressionFilme(x => x.UsuarioId == usuarioId);
            var livrosFavoritos = await _favoritoRepository.ReadExpressionLivro(x => x.UsuarioId == usuarioId);

            List<Favorito> favoritos = new List<Favorito>();

            favoritos.AddRange(filmesFavoritos);
            favoritos.AddRange(livrosFavoritos);

            var favoritosViewModel = _mapper.Map<IEnumerable<FavoritoViewModel>>(favoritos);


            return CustomResponse(favoritosViewModel);
        }

        [HttpPost("FavoritarFilme")]
        public async Task<IActionResult> Post([FromBody] FilmeViewModel filmeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(filmeViewModel);
            }

            var filme = _mapper.Map<Filme>(filmeViewModel);

            await _filmeService.Create(filme);

            if (!OperacaoValida())
            {
                foreach (var error in _notificador.GetNotificacoes())
                {
                    ModelState.AddModelError(error.Propriedade, error.Mensagem);
                }

                return CustomResponse(filmeViewModel);
            }

            Favorito favorito = new Favorito()
            {
                FilmeId = filme.Id,
                UsuarioId = Guid.Parse(_userManager.GetUserId(User))
            };

            await _favoritoService.Create(favorito);

            if (!OperacaoValida())
            {
                foreach (var error in _notificador.GetNotificacoes())
                {
                    ModelState.AddModelError(error.Propriedade, error.Mensagem);
                }

                return CustomResponse(filmeViewModel);
            }

            return CustomResponse();
        }

        [HttpPost("FavoritarLivro")]
        public async Task<IActionResult> Post([FromBody] LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(livroViewModel);
            }

            var livro = _mapper.Map<Livro>(livroViewModel);

            await _livroService.Create(livro);

            if (!OperacaoValida())
            {
                foreach (var error in _notificador.GetNotificacoes())
                {
                    ModelState.AddModelError(error.Propriedade, error.Mensagem);
                }

                return CustomResponse(livroViewModel);
            }

            Favorito favorito = new Favorito()
            {
                LivroId = livro.Id,
                UsuarioId = Guid.Parse(_userManager.GetUserId(User))
            };

            await _favoritoService.Create(favorito);

            if (!OperacaoValida())
            {
                foreach (var error in _notificador.GetNotificacoes())
                {
                    ModelState.AddModelError(error.Propriedade, error.Mensagem);
                }

                return CustomResponse(livroViewModel);
            }

            return CustomResponse();
        }

        [HttpDelete("Deletar/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var favoritoDb = await _favoritoRepository.GetById(id);

            if (favoritoDb == null)
            {
                _notificador.AdicionarNotificacao(new Business.Notifications.Notificacao("Nenhum favorito encontrado"));

                return CustomResponse();
            }

            if (favoritoDb.FilmeId.HasValue)
            {
                await _filmeService.Delete(favoritoDb.FilmeId.Value);

            }
            else
            {
                await _livroService.Delete(favoritoDb.LivroId.Value);
            }

            return CustomResponse();
        }
    }
}
