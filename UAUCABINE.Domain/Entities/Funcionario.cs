using UAUCABINE.Domain.Base;

namespace UAUCABINE.Domain.Entities
{
    public class Funcionario : BaseEntity<int>
    {
        public Funcionario()
        {
        }

        public Funcionario(int id, string? nome, int? idade, string? cpf, string? sexo, Cidade? cidade) : base(id)
        {

            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Sexo = sexo;
            Cidade = cidade;

        }

        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? Cpf { get; set; }
        public string? Sexo { get; set; }
        public Cidade? Cidade { get; set; }
    }
}
