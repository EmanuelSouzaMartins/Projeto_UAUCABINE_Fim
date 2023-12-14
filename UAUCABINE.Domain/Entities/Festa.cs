using System.Text.Json.Serialization;
using UAUCABINE.Domain.Base;

namespace UAUCABINE.Domain.Entities
{
    public class Festa : BaseEntity<int>
    {
        public Festa() 
        {
            Funcio = new List<FuncFesta>();
            Equipa = new List<EquipFesta>();
        }

        public Festa(int id, string? nomeSalao, Cidade? cidade, string? rua, int? numero, DateTime horaIni, DateTime horaFim, List<FuncFesta> funcio, List<EquipFesta> equipa) : base(id)
        {

            NomeSalao = nomeSalao;
            Cidade = cidade;
            Rua = rua;
            Numero = numero;
            HoraIni = horaIni;
            HoraFim = horaFim;
            Funcio = funcio;
            Equipa = equipa;

        }
        public string Nome { get; set; }
        public string? NomeSalao { get; set; }
        public Cidade? Cidade { get; set; }
        public string? Rua { get; set; }
        public int? Numero { get; set; }
        public DateTime HoraIni { get; set; }
        public DateTime HoraFim { get; set; }
        public virtual List<FuncFesta> Funcio { get; set; }
        public virtual List<EquipFesta> Equipa { get; set; }
    }


    public class FuncFesta : BaseEntity<int>
    {
        public FuncFesta() 
        {

        }

        public FuncFesta(int id, Funcionario? funcionario, Festa? festa) : base(id) 
        {
            Festa = festa;
            Funcionario = funcionario;
        }

        public virtual Funcionario? Funcionario { get; set; }
        public Festa? Festa { get; set; }    
    }

    public class EquipFesta : BaseEntity<int>
    {
        public EquipFesta()
        {

        }

        public EquipFesta(int id, Equipamento? equipamentos, Festa? festa) : base(id)
        {
            Festa = festa;
            Equipamentos = equipamentos;            
        }

        public Festa? Festa { get; set; }
        public Equipamento? Equipamentos { get; set; }        

    }
}
