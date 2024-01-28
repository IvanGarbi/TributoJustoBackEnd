using AutoMapper;
using TributoJusto.API.ViewModels;
using TributoJusto.Business.Models;

namespace TributoJusto.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FilmeViewModel, Filme>().ReverseMap();
            CreateMap<LivroViewModel, Livro>().ReverseMap();
            CreateMap<FavoritoViewModel, Favorito>().ReverseMap();
        }
    }
}
