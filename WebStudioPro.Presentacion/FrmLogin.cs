using System;
using System.Windows.Forms;
using WebStudioPro.Presentacion.DAL;
using WebStudioPro.Presentacion.Entities;

namespace WebStudioPro.Presentacion
{
    public partial class FrmLogin : Form
    {
        private readonly LoginDAL _loginDal = new LoginDAL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;

            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                lblMensaje.Text = "Ingresa usuario y clave.";
                txtUsuario.Focus();
                return;
            }

            try
            {
                Usuario u = _loginDal.Login(usuario, clave);

                if (u == null)
                {
                    lblMensaje.Text = "Usuario o clave incorrectos.";
                    txtClave.SelectAll();
                    txtClave.Focus();
                    return;
                }

                // Login correcto -> abrir menú principal
                this.Hide();
                using (FrmMain frm = new FrmMain(u))
                {
                    frm.ShowDialog();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al iniciar sesión:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
