using System;
using UAUCABINE.Domain.Entities;

namespace UAUCABINE.App.Models
{
    public class FestaModel
    {
        public FestaModel() 
        {
            Funcio = new List<FuncFesta>();
            Equipa = new List<EquipFesta>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? NomeSalao { get; set; }
        public string Cidade { get; set; }
        public int IdCidade { get; set; }
        public string? Rua { get; set; }
        public int? Numero { get; set; }
        public DateTime HoraIni { get; set; }
        public DateTime HoraFim { get; set; }
        public List<FuncFesta> Funcio { get; set; }
        public List<EquipFesta> Equipa { get; set; }
    }

    public class FuncFestas
    {
        public int Id { get; set; }
        public Funcionario? Funcionario { get; set; }
        public Festa? Festa { get; set; }
        public string NomeFuncio { get; set; }
    }

    public class EquiFesta
    {
        public int Id { get; set; }
        public Festa? Festa { get; set; }
        public Equipamento? Equipamentos { get; set; }
        public string NomeEquip { get; set; }
    }

}
