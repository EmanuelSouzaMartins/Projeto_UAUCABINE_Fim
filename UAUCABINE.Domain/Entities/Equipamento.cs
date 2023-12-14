using UAUCABINE.Domain.Base;

namespace UAUCABINE.Domain.Entities
{
    public class Equipamento : BaseEntity<int>
    {
        public Equipamento() 
        {

        }
        public Equipamento(int id, string? nome) : base (id) 
        {
            Nome = nome;
        }

        public string? Nome { get; set; }
    }
}
