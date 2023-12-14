using UAUCABINE.Domain.Entities;

namespace UAUCABINE.App.Models
{
    public class FuncionariosModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? Cpf { get; set; }
        public string? Sexo { get; set; }
        public int IdCidade { get; set; }
        public string NomeCidade { get; set; }
    }
}
