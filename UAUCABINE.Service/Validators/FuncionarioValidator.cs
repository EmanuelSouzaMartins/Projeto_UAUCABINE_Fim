using FluentValidation;
using UAUCABINE.Domain.Entities;

namespace UAUCABINE.Service.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator() 
        {

            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Por gentileza informe o nome do funcionário")
                .NotNull().WithMessage("Por gentileza informe o nome do funcionário");
            RuleFor(f => f.Idade)
                .NotEmpty().WithMessage("Por gentileza informe a idade do funcionário")
                .NotNull().WithMessage("Por gentileza informe a idade do funcionário");
            RuleFor(f => f.Cpf)
                .NotEmpty().WithMessage("Por gentileza informe o CPF do funcionário")
                .NotNull().WithMessage("Por gentileza informe o CPF do funcionário");
            RuleFor(f => f.Sexo)
                .NotEmpty().WithMessage("Por gentileza informe o sexo do funcionário")
                .NotNull().WithMessage("Por gentileza informe o sexo do funcionário");
            RuleFor(f => f.Cidade)
                .NotEmpty().WithMessage("Por gentileza informe a cidade do funcionário")
                .NotNull().WithMessage("Por gentileza informe a cidade do funcionário");
        }
    }
}
