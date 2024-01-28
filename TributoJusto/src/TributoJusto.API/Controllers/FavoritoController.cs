using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TributoJusto.API.ViewModels;
using TributoJusto.Business.Interfaces.Repository;

namespace TributoJusto.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class FavoritoController : MainController
    {
        private readonly IFavoritoRepository _favoritoRepository;
        private readonly IMapper _mapper;

        public FavoritoController(IFavoritoRepository favoritoRepository,
                                IMapper mapper)
        {
            _favoritoRepository = favoritoRepository;
            _mapper = mapper;
        }

        [HttpGet("Favoritos/{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Get(Guid usuarioId)
        {
            return CustomResponse(_mapper.Map<FilmeViewModel>(await _favoritoRepository.ReadById(usuarioId)));
        }
    }
}
