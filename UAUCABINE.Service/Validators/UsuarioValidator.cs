using FluentValidation;
using UAUCABINE.Domain.Entities;

namespace UAUCABINE.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator() 
        {
            RuleFor( u=> u.Login)
                .NotEmpty().WithMessage("Por gentileza informe o login do usuário")
                .NotNull().WithMessage("Por gentileza informe o login do usuário");
            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Por gentileza informe a senha do usuário")
                .NotNull().WithMessage("Por gentileza informe a senha do usuário");
            
        }
    }
}
