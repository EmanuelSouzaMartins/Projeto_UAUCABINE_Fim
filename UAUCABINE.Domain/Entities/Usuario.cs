
using UAUCABINE.Domain.Base;

namespace UAUCABINE.Domain.Entities
{
    public class Usuario : BaseEntity<int>
    {
        public Usuario() 
        { 

        }

        public Usuario(int id, string? login, string? senha, bool ativo) : base(id)
        {
            Login = login;
            Senha = senha;
            Ativo = ativo;
        }

        public string? Senha { get; set; }
        public string? Login { get; set; }
        public bool Ativo { get; set; }
    }
}
