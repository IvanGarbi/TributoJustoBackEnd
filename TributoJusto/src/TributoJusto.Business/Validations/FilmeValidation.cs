using FluentValidation;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Validations
{
    public class FilmeValidation : AbstractValidator<Filme>
    {
        public FilmeValidation()
        {
            RuleFor(x => x.Writer)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(250)
                .WithMessage("O {PropertyName} deve ter menos que 250 caracteres.");

            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(50)
                .WithMessage("O {PropertyName} deve ter menos que 50 caracteres.");

            RuleFor(x => x.Year)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(4)
                .WithMessage("O {PropertyName} deve ter menos que 4 caracteres.");

            RuleFor(x => x.Genre)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(50)
                .WithMessage("O {PropertyName} deve ter menos que 50 caracteres.");

            RuleFor(x => x.Director)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(50)
                .WithMessage("O {PropertyName} deve ter menos que 50 caracteres.");

            RuleFor(x => x.Actors)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(250)
                .WithMessage("O {PropertyName} deve ter menos que 250 caracteres.");

            RuleFor(x => x.Plot)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(500)
                .WithMessage("O {PropertyName} deve ter menos que 500 caracteres.");

            RuleFor(x => x.Country)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(50)
                .WithMessage("O {PropertyName} deve ter menos que 50 caracteres.");

            RuleFor(x => x.ImdbRating)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(4)
                .WithMessage("O {PropertyName} deve ter menos que 4 caracteres.");
        }
    }
}
