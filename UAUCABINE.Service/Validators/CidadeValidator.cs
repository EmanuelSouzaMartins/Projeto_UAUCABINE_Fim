using FluentValidation;
using UAUCABINE.Domain.Entities;

namespace UAUCABINE.Service.Validators
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator() 
        { 
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por gentileza informe o nome da cidade.")
                .NotNull().WithMessage("Por gentileza informe o nome da cidade.");
            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Por gentileza informe o estado da cidade.")
                .NotNull().WithMessage("Por gentileza informe o estado da cidade.");

        }
    }
}
