using UAUCABINE.App.Base;
using UAUCABINE.Domain.Base;
using UAUCABINE.Domain.Entities;
using UAUCABINE.Service.Validators;

namespace UAUCABINE.App.Cadastros
{
    public partial class CadastroEquipamentos : CadastroBase
    {

        private readonly IBaseService<Equipamento> _equipamentosService;

        private List<Equipamento>? equipamentos;

        public CadastroEquipamentos(IBaseService<Equipamento> equipamentosService)
        {
            _equipamentosService = equipamentosService;
            InitializeComponent();
        }

        private void PreencheObjeto(Equipamento equipamentos)
        {
            equipamentos.Nome = txtNomeEquip.Text;
        }

        protected override void Salvar()
        {
            try
            {
                if (IsAlteracao)
                {
                    if (int.TryParse(txtId.Text, out var id))
                    {
                        var equipamentos = _equipamentosService.GetById<Equipamento>(id);
                        PreencheObjeto(equipamentos);
                        equipamentos = _equipamentosService.Update<Equipamento, Equipamento, EquipamentosValidator>(equipamentos);
                    }
                }
                else
                {
                    var equipamentos = new Equipamento();
                    PreencheObjeto(equipamentos);
                    _equipamentosService.Add<Equipamento, Equipamento, EquipamentosValidator>(equipamentos);
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
                _equipamentosService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"UAUCABINE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            equipamentos = _equipamentosService.Get<Equipamento>().ToList();
            dataGridViewConsulta.DataSource = equipamentos;
            dataGridViewConsulta.Columns["Nome"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            txtId.Text = linha?.Cells["Id"].Value.ToString();
            txtNomeEquip.Text = linha?.Cells["Nome"].Value.ToString();
        }
    }
}
