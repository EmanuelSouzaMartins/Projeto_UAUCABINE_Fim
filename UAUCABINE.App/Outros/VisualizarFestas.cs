using ReaLTaiizor.Forms;
using UAUCABINE.Domain.Base;
using UAUCABINE.Domain.Entities;

namespace UAUCABINE.App.Outros
{
    public partial class VisualizarFestas : MaterialForm
    {

        private readonly IBaseService<Festa> _festaService;
        public VisualizarFestas(IBaseService<Festa> festaService)
        {
            _festaService = festaService;
            InitializeComponent();
            CarregaEventos();
        }

        private void CarregaEventos()
        {
            var festas = _festaService.Get<Festa>(new List<string> { "Cidade" });
            foreach (var festa in festas)
            {
                DadosFesta fest = new DadosFesta(festa.Id);
                fest.lblNomeFesta.Text = festa.Nome;
                fest.lblDataIni.Text = festa.HoraIni.ToString("dd/MM/yyyy HH:mm:ss");
                fest.lblDataFim.Text = festa.HoraFim.ToString("dd/MM/yyyy HH:mm:ss");
                fest.lblSalao.Text = festa.NomeSalao;
                fest.lblCidade.Text = festa.Cidade!.Nome;
                fest.lblNumero.Text = festa.Numero.ToString();
                fest.lblRua.Text = festa.Rua;


                flowLayoutPanel1.Controls.Add(fest);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, flowLayoutPanel1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
    }
}
