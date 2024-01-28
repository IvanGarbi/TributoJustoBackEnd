using FluentValidation;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Validations
{
    public class FavoritoValidation : AbstractValidator<Favorito>
    {
        public FavoritoValidation()
        {
            RuleFor(x => x.UsuarioId)
                .NotNull()
                .WithMessage("O {PropertyName} deve ser informado.");
        }
    }
}
