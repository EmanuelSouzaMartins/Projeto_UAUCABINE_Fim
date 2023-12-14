using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using ReaLTaiizor.Forms;
using UAUCABINE.App.Models;
using UAUCABINE.Domain.Base;
using UAUCABINE.Domain.Entities;
using UAUCABINE.Service.Validators;

namespace UAUCABINE.App.Outros
{
    public partial class Login : MaterialForm
    {
        private readonly IBaseService<Usuario> _usuarioService;


        public Login(IBaseService<Usuario> usuarioService)
        {
            _usuarioService = usuarioService;
            InitializeComponent();

        }

        /*foreach (var user in usuarios)
                    {
                        if (user.Login == txtLogin.Text && user.Senha == txtSenha.Text)//encontrei um usuário
                        {
                            DialogResult = DialogResult.OK;
                            Close();
        //FormDoFuncio form = new FormDoFuncio();
        //form.ShowDialog();
        procs = 1;


                        }
                        else
                        {
                            if (user.Login == "admin" && user.Senha == "admin")
                            {
                                DialogResult = DialogResult.OK;
                                Close();
    procs = 1;
                            }
                        }*/



        private void btnOk_Click(object sender, EventArgs e)
        {
            
            var usuarios = _usuarioService.Get<UsuarioModel>().ToList();

            if (!usuarios.Any())
            {
                if (txtLogin.Text == "admin" && txtSenha.Text == "admin")
                {
                    var user = new Usuario
                    {
                        Ativo = true,
                        Login = "admin",
                        Senha = "admin"
                    };
                    _usuarioService.Add<Usuario, Usuario, UsuarioValidator>(user);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado!", "UAUCABINE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                string proc = "0";
                foreach (var user in usuarios)
                {
                    if (user.Login == txtLogin.Text && user.Senha == txtSenha.Text)
                    {
                        proc = "1";
                        DialogResult = DialogResult.OK;
                        Close();
                        break;
                    }
                    else
                    {
                        proc = "0";
                    }
                }

                if (proc == "0")
                {
                    MessageBox.Show("Usuário não encontrado!", "UAUCABINE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            txtLogin.Clear();
            txtSenha.Clear();
  
    }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


    }
}
