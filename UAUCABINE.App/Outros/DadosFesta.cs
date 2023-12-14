
using Microsoft.Extensions.DependencyInjection;
using UAUCABINE.App.Infra;

namespace UAUCABINE.App.Outros
{
    public partial class DadosFesta : UserControl
    {
        private int idFest;
        public DadosFesta(int idFesta)
        {
            InitializeComponent();
            idFest = idFesta;
        }


        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            var funcioEquip = new FuncioEquip(idFest);
            funcioEquip.ShowDialog();
        }

        private void DadosFesta_Load(object sender, EventArgs e)
        {

        }

        /* private void DadosFesta_Paint(object sender, PaintEventArgs e)
         {
             ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
         }*/
    }
}
