using FluentValidation;
using UAUCABINE.Domain.Entities;

namespace UAUCABINE.Service.Validators
{
    public class EquipamentosValidator : AbstractValidator<Equipamento>
    {
        public EquipamentosValidator() 
        {
            RuleFor(e => e.Nome)
                 .NotEmpty().WithMessage("Por gentileza informe o nome do equipamento.")
                 .NotNull().WithMessage("Por gentileza informe o nome do equipamento.");

        }
    }
}
