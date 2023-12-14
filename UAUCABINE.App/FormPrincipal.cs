using UAUCABINE.App.Cadastros;
using UAUCABINE.App.Models;
using UAUCABINE.App.Infra;
using UAUCABINE.App.Outros;
using UAUCABINE.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;
using UAUCABINE.Domain.Base;
using Microsoft.VisualBasic.Logging;


namespace UAUCABINE.App
{
    public partial class FormPrincipal : MaterialForm
    {

        public FormPrincipal()
        {
            InitializeComponent();
            CarregaLogin();
        }

        private void CarregaLogin()
        {
            var login = ConfigureDI.ServicesProvider!.GetService<Login>();
            if (login.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(0);
            }

        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
            }
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exibeformulario<CadastroCidade>();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exibeformulario<CadastroFuncionario>();
        }

        private void equipamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exibeformulario<CadastroEquipamentos>();
        }

        private void festasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exibeformulario<CadastroFesta>();
        }

        private void festasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Exibeformulario<VisualizarFestas>();
        }

        private void Exibeformulario<TFormlario>() where TFormlario : Form
        {
            var cad = ConfigureDI.ServicesProvider!.GetService<TFormlario>();
            if (cad != null && !cad.IsDisposed)
            {
                cad.MdiParent = this;
                cad.Show();
            }
        }
    }
}
