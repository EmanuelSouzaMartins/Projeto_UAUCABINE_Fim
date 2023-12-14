
using ReaLTaiizor.Forms;
using UAUCABINE.Domain.Base;
using UAUCABINE.Domain.Entities;
using UAUCABINE.App.Models;
using UAUCABINE.App.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace UAUCABINE.App.Outros
{
    public partial class FuncioEquip : MaterialForm
    {
        public int idFest;

        private readonly IBaseService<FuncFesta> _funcFestaService;
        private readonly IBaseService<EquipFesta> _equipfestaService;

        List<FuncFestas> listaFunc = new List<FuncFestas>();
        List<EquiFesta> listaEquip = new List<EquiFesta>();


        public FuncioEquip(IBaseService<FuncFesta> funcFestaService, IBaseService<EquipFesta> equipfestaService)
        {
            InitializeComponent();
            _funcFestaService = funcFestaService;
            _equipfestaService = equipfestaService;
            CarregaGridFunc();
            CarregaGridEquip();
        }

        public FuncioEquip(int idFesta)
        {
            this.idFest = idFesta;
            InitializeComponent();
            _funcFestaService = ConfigureDI.ServicesProvider!.GetService<IBaseService<FuncFesta>>();
            _equipfestaService = ConfigureDI.ServicesProvider!.GetService<IBaseService<EquipFesta>>();
            CarregaGridFunc();
            CarregaGridEquip();
        }

        protected private void CarregaGridFunc()
        {

            listaFunc = _funcFestaService.Get<FuncFestas>(new List<string> { "Funcionario", "Festa" }).Where(x => x.Festa.Id == idFest).ToList();

            gridFunc.DataSource = listaFunc;
            gridFunc.Columns["Festa"]!.Visible = false;
            gridFunc.Columns["Funcionario"]!.Visible = false;
            gridFunc.Columns["NomeFuncio"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridFunc.Columns["Id"]!.Visible = false;
            gridFunc.Columns["NomeFuncio"]!.HeaderText = "Nome do funcionário";
        }

        protected private void CarregaGridEquip()
        {
            listaEquip = _equipfestaService.Get<EquiFesta>(new List<string> { "Equipamentos", "Festa" }).Where(x => x.Festa.Id == idFest).ToList();

            gridEquip.DataSource = listaEquip;
            gridEquip.Columns["Festa"]!.Visible = false;
            gridEquip.Columns["Equipamentos"]!.Visible = false;
            gridEquip.Columns["NomeEquip"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridEquip.Columns["Id"]!.Visible = false;
            gridEquip.Columns["NomeEquip"]!.HeaderText = "Nome do equipamento";
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
