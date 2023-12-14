using Microsoft.VisualBasic.ApplicationServices;
using ReaLTaiizor.Controls;
using UAUCABINE.App.Base;
using UAUCABINE.App.Models;
using UAUCABINE.Domain.Base;
using UAUCABINE.Domain.Entities;
using UAUCABINE.Service.Validators;

namespace UAUCABINE.App.Cadastros
{
    public partial class CadastroFuncionario : CadastroBase
    {
        private readonly IBaseService<Funcionario> _funcionarioService;
        private readonly IBaseService<Cidade> _cidadeService;
        private readonly IBaseService<Usuario> _usuarioService;

        private List<FuncionariosModel>? funcionario;
        public CadastroFuncionario(IBaseService<Funcionario> funcionarioService, IBaseService<Cidade> cidadeService, IBaseService<Usuario> usuarioService)
        {
            _funcionarioService = funcionarioService;
            _cidadeService = cidadeService;
            _usuarioService = usuarioService;
            InitializeComponent();
            CarregarCombo();
        }

        private void CarregarCombo()
        {
            cboCidade.ValueMember = "Id";
            cboCidade.DisplayMember = "Nome";
            cboCidade.DataSource = _cidadeService.Get<CidadeModel>().ToList();
        }

        private void PreencheObjeto(Funcionario funcionario)
        {
            funcionario.Nome = txtNomeFunc.Text;
            funcionario.Idade = int.Parse(txtIdade.Text);
            funcionario.Cpf = txtCpf.Text;
            funcionario.Sexo = cboSexo.Text;

            if (int.TryParse(cboCidade.SelectedValue.ToString(), out var idCity))
            {
                var cidade = _cidadeService.GetById<Cidade>(idCity);
                funcionario.Cidade = cidade;
            }

            var user = new Usuario
            {
                Ativo = true,
                Login = txtCpf.Text,
                Senha = "UAUCABINE"
            };
            _usuarioService.Add<Usuario, Usuario, UsuarioValidator>(user);

        }

        protected override void Salvar()
        {
            try
            {
                if (IsAlteracao)
                {
                    if (int.TryParse(txtId.Text, out var id))
                    {
                        var funcionario = _funcionarioService.GetById<Funcionario>(id);
                        PreencheObjeto(funcionario);
                        _funcionarioService.Update<Funcionario, Funcionario, FuncionarioValidator>(funcionario);
                    }
                }
                else
                {
                    var funcionario = new Funcionario();
                    PreencheObjeto(funcionario);
                    _funcionarioService.Add<Funcionario, Funcionario, FuncionarioValidator>(funcionario);
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
                _funcionarioService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"UAUCABINE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            funcionario = _funcionarioService.Get<FuncionariosModel>(new[] { "Cidade" }).ToList();
            dataGridViewConsulta.DataSource = funcionario;
            dataGridViewConsulta.Columns["NomeCidade"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewConsulta.Columns["IdCidade"]!.Visible = false;
        }

        protected override void CarregaRegistro(DataGridViewRow? linha)
        {
            txtId.Text = linha?.Cells["Id"].Value.ToString();
            txtNomeFunc.Text = linha?.Cells["Nome"].Value.ToString();
            cboCidade.SelectedValue = linha?.Cells["IdCidade"].Value;
            txtCpf.Text = linha?.Cells["Cpf"].Value.ToString();
            txtIdade.Text = linha?.Cells["Idade"].Value.ToString();
            cboSexo.SelectedValue = linha?.Cells["Sexo"].Value;
        }
    }
}
