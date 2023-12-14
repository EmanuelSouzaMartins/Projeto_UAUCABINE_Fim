using ReaLTaiizor.Controls;
using ReaLTaiizor.Extension;
using System;
using System.CodeDom;
using UAUCABINE.App.Base;
using UAUCABINE.App.Models;
using UAUCABINE.Domain.Base;
using UAUCABINE.Domain.Entities;
using UAUCABINE.Service.Validators;

namespace UAUCABINE.App.Cadastros
{
    public partial class CadastroFesta : CadastroBase
    {
        //private List<FuncFestas> _funcFesta;
        //private List<EquipFesta> _equipFesta;

        private readonly IBaseService<Festa> _festaService;
        private readonly IBaseService<Funcionario> _funcionarioService;
        private readonly IBaseService<Equipamento> _equipamentosService;
        private readonly IBaseService<Cidade> _cidadeService;
        private readonly IBaseService<FuncFesta> _funcFestaService;
        private readonly IBaseService<EquipFesta> _equipFestaService;

        private List<FestaModel>? party;
        public CadastroFesta(IBaseService<Festa> festaService,
                             IBaseService<Funcionario> funcionarioService,
                             IBaseService<Equipamento> equipamentosService,
                             IBaseService<Cidade> cidadeService, IBaseService<FuncFesta> funcFestaService,
                             IBaseService<EquipFesta> equipFestaService)
        {
            _festaService = festaService;
            _funcionarioService = funcionarioService;
            _equipamentosService = equipamentosService;
            _cidadeService = cidadeService;
            _funcFestaService = funcFestaService;
            _equipFestaService = equipFestaService;

            //_funcFesta = new List<FuncFestas>();
            //_equipFesta = new List<EquipFesta>();

            InitializeComponent();
            CarregarCombo();
            CarregaCheckList();
            //CarregaGridItensVenda();
            //Novo();
        }

        private void CarregarCombo()
        {
            cboCidade.ValueMember = "Id";
            cboCidade.DisplayMember = "Nome";
            cboCidade.DataSource = _cidadeService.Get<CidadeModel>().ToList();

        }

        private void CarregaCheckList()
        {
            List<Funcionario> listaFuncio = _funcionarioService.Get<Funcionario>().ToList();

            foreach (Funcionario f in listaFuncio)
            {
                clbFunc.Items.Add($"{f.Id}-{f.Nome}");
            }

            List<Equipamento> listaEquip = _equipamentosService.Get<Equipamento>().ToList();

            foreach (Equipamento e in listaEquip)
            {
                clbEquip.Items.Add($"{e.Id}-{e.Nome}");
            }
        }

        private void PreencheObjeto(Festa festas)
        {
            festas.NomeSalao = txtNomeSalao.Text;
            festas.Rua = txtRua.Text;
            festas.Numero = int.Parse(txtNumero.Text);
            festas.Nome = txtNomeFesta.Text;

            if (DateTime.TryParse(txtDataIni.Text, out var horaIni))
            {
                festas.HoraIni = horaIni;
            }

            if (DateTime.TryParse(txtDataFim.Text, out var horaFim))
            {
                festas.HoraFim = horaFim;
            }

            if (int.TryParse(cboCidade.SelectedValue.ToString(), out var idCity))
            {
                var cidade = _cidadeService.GetById<Cidade>(idCity);
                festas.Cidade = cidade;
            }

            foreach (var item in clbFunc.CheckedItems)
            {
                int.TryParse(item.ToString().Split("-")[0], out var idFunc);

                var festaFunc = new FuncFesta
                {
                    Festa = festas,
                    Funcionario = _funcionarioService.GetById<Funcionario>(idFunc)

                };

                festas.Funcio.Add(festaFunc);
            }



            foreach (var item in clbEquip.CheckedItems)
            {
                int.TryParse(item.ToString().Split("-")[0], out var idEquip);

                var festaEquip = new EquipFesta
                {
                    Festa = festas,
                    Equipamentos = _equipamentosService.GetById<Equipamento>(idEquip)
                };

                festas.Equipa.Add(festaEquip);
            }


        }

        protected override void Salvar()
        {
            try
            {
                if (IsAlteracao)
                {
                    if (int.TryParse(txtId.Text, out var id))
                    {

                        Deletar(id);

                        var festa = new Festa();

                        PreencheObjeto(festa);
                        _festaService.Add<Festa, Festa, FestasValidator>(festa);

                        foreach (var festaFunc in festa.Funcio)
                        {
                            var f = new FuncFesta()
                            {
                                Funcionario = _funcionarioService.GetById<Funcionario>(festaFunc.Funcionario.Id),
                                Festa = _festaService.GetById<Festa>(festaFunc.Festa.Id)
                            };

                            _funcFestaService.Add<FuncFesta, FuncFesta, FuncFestaValidator>(f);
                        }

                        foreach (var festaEquipa in festa.Equipa)
                        {
                            var e = new EquipFesta()
                            {
                                Equipamentos = _equipamentosService.GetById<Equipamento>(festaEquipa.Equipamentos.Id),
                                Festa = _festaService.GetById<Festa>(festaEquipa.Festa.Id)
                            };

                            _equipFestaService.Add<EquipFesta, EquipFesta, EquipFestaValidator>(e);
                        }
                    }
                }
                else
                {
                    var festa = new Festa();

                    PreencheObjeto(festa);
                    _festaService.Add<Festa, Festa, FestasValidator>(festa);

                    foreach (var festaFunc in festa.Funcio)
                    {
                        var f = new FuncFesta()
                        {
                            Funcionario = _funcionarioService.GetById<Funcionario>(festaFunc.Funcionario.Id),
                            Festa = _festaService.GetById<Festa>(festaFunc.Festa.Id)
                        };

                        _funcFestaService.Add<FuncFesta, FuncFesta, FuncFestaValidator>(f);
                    }

                    foreach (var festaEquipa in festa.Equipa)
                    {
                        var e = new EquipFesta()
                        {
                            Equipamentos = _equipamentosService.GetById<Equipamento>(festaEquipa.Equipamentos.Id),
                            Festa = _festaService.GetById<Festa>(festaEquipa.Festa.Id)
                        };

                        _equipFestaService.Add<EquipFesta, EquipFesta, EquipFestaValidator>(e);
                    }


                }

                materialTabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"UAUCABINE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _festaService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"UAUCABINE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {

            var includes = new List<string>() { "Cidade" };
            party = _festaService.Get<FestaModel>(includes).ToList();
            dataGridViewConsulta.DataSource = party;
            dataGridViewConsulta.Columns["IdCidade"]!.Visible = false;
            // dataGridViewConsulta.Columns["IdFunc"]!.Visible = false;
            //dataGridViewConsulta.Columns["NomeFunc"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridViewConsulta.Columns["NomeEquip"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            int.TryParse(linha?.Cells["Id"].Value.ToString(), out var id);
            txtId.Text = linha?.Cells["Id"].Value.ToString();
            txtNomeFesta.Text = linha?.Cells["Nome"].Value.ToString();
            txtNomeSalao.Text = linha?.Cells["NomeSalao"].Value.ToString();
            txtRua.Text = linha?.Cells["Rua"].Value.ToString();
            txtNumero.Text = linha?.Cells["Numero"].Value.ToString();
            cboCidade.SelectedValue = linha?.Cells["IdCidade"].Value;
            txtDataIni.Text = DateTime.TryParse(linha?.Cells["HoraIni"].Value.ToString(), out var dataC)
               ? dataC.ToString("g")
               : "";

            txtDataFim.Text = DateTime.TryParse(linha?.Cells["HoraFim"].Value.ToString(), out var dataF)
               ? dataF.ToString("g")
               : "";


        }
    }
}
