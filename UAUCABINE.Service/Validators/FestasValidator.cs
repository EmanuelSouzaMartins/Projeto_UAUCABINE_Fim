using FluentValidation;
using UAUCABINE.Domain.Entities;

namespace UAUCABINE.Service.Validators
{
    public class FestasValidator : AbstractValidator<Festa>
    {
        public FestasValidator() 
        {
            RuleFor(s => s.Nome)
                .NotEmpty().WithMessage("Por gentileza informe o nome da festa.")
                .NotNull().WithMessage("Por gentileza informe o nome da festa.");
            RuleFor(s => s.NomeSalao)
                .NotEmpty().WithMessage("Por gentileza informe o nome do salão.")
                .NotNull().WithMessage("Por gentileza informe o nome do salão.");
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Por gentileza informe a cidade.")
                .NotNull().WithMessage("Por gentileza informe a cidade.");
            RuleFor(nu => nu.Numero)
                .NotEmpty().WithMessage("Por gentileza informe o número do salão.")
                .NotNull().WithMessage("Por gentileza informe o número do salão.");
            RuleFor(hi => hi.HoraIni)
                .NotEmpty().WithMessage("Por gentileza informe que horas inicia o trabalho.")
                .NotNull().WithMessage("Por gentileza informe que horas inicia o trabalho.");
            RuleFor(hf => hf.HoraFim)
                .NotEmpty().WithMessage("Por gentileza informe que horas encerra o trabalho.")
                .NotNull().WithMessage("Por gentileza informe que horas encerra o trabalho.");
            RuleFor(f => f.Funcio)
                .NotEmpty().WithMessage("Por gentileza informe o funcionário.")
                .NotNull().WithMessage("Por gentileza informe o funcionário.");
            RuleFor(e => e.Equipa)
                .NotEmpty().WithMessage("Por gentileza informe o equipamento.")
                .NotNull().WithMessage("Por gentileza informe o equipamento.");

        }

    }

    public class FuncFestaValidator : AbstractValidator<FuncFesta>
    {
        public FuncFestaValidator()
        {
            RuleFor(s => s.Festa)
                .NotEmpty().WithMessage("Por gentileza informe a festa.")
                .NotNull().WithMessage("Por gentileza informe a festa.");

            RuleFor(e => e.Funcionario)
                .NotEmpty().WithMessage("Por gentileza informe o funcionário.")
                .NotNull().WithMessage("Por gentileza informe o funcionário.");
        }

    }

    public class EquipFestaValidator : AbstractValidator<EquipFesta>
    {
        public EquipFestaValidator()
        {
            RuleFor(s => s.Festa)
                .NotEmpty().WithMessage("Por gentileza informe a festa.")
                .NotNull().WithMessage("Por gentileza informe a festa.");

            RuleFor(e => e.Equipamentos)
                .NotEmpty().WithMessage("Por gentileza informe o equipamentos.")
                .NotNull().WithMessage("Por gentileza informe o equipamentos.");
        }
    }


}
