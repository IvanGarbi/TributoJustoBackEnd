using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TributoJusto.Business.Models;

namespace TributoJusto.Business.Validations
{
    public class LivroValidation : AbstractValidator<Livro>
    {
        public LivroValidation()
        {
            RuleFor(x => x.Amount)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Não é possível ter quantidade negativa.");

            RuleFor(x => x.CurrencyCode)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(10)
                .WithMessage("O {PropertyName} deve ter menos que 10 caracteres.");

            RuleFor(x => x.Saleability)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(20)
                .WithMessage("O {PropertyName} deve ter menos que 20 caracteres.");

            RuleFor(x => x.Country)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(50)
                .WithMessage("O {PropertyName} deve ter menos que 50 caracteres.");

            RuleFor(x => x.CountrySale)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(250)
                .WithMessage("O {PropertyName} deve ter menos que 250 caracteres.");

            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(100)
                .WithMessage("O {PropertyName} deve ter menos que 100 caracteres.");

            RuleFor(x => x.Authors)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(150)
                .WithMessage("O {PropertyName} deve ter menos que 150 caracteres.");

            RuleFor(x => x.Categories)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(100)
                .WithMessage("O {PropertyName} deve ter menos que 100 caracteres.");

            RuleFor(x => x.Publisher)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .MaximumLength(50)
                .WithMessage("O {PropertyName} deve ter menos que 50 caracteres.");

            RuleFor(x => x.PageCount)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Não é possível ter quantidade negativa.");

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("O {PropertyName} deve ser informado.");
        }
    }
}