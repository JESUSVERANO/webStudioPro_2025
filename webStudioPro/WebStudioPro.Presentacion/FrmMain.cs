using System;
using System.Windows.Forms;
using WebStudioPro.Presentacion.Entities;   // 👈 IMPORTANTE

namespace WebStudioPro.Presentacion
{
    public partial class FrmMain : Form
    {
        private readonly Usuario _usuarioActual;

        // Constructor usado desde el login
        public FrmMain(Usuario usuario) : this()
        {
            _usuarioActual = usuario;

            if (_usuarioActual != null && !string.IsNullOrWhiteSpace(_usuarioActual.Nombre))
            {
                this.Text = $"WebStudio PRO - Bienvenido, {_usuarioActual.Nombre}";
            }
        }

        // Constructor sin parámetros (necesario para el diseñador)
        public FrmMain()
        {
            InitializeComponent();
        }

        // 🔥 ESTE MÉTODO ES EL QUE FALTABA
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Opcional: Maximizar al abrir
            this.WindowState = FormWindowState.Maximized;

            // Opcional: Mensaje en la barra de título si no vino usuario
            if (_usuarioActual == null)
            {
                this.Text = "WebStudio PRO - Panel Principal";
            }
        }

        private void OpenChild(Form child)
        {
            child.MdiParent = this;
            child.WindowState = FormWindowState.Maximized;
            child.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmClientes());
        }

        private void cotizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmCotizador());
        }

        private void proyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmProyectos());
        }

        private void portafolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmPortafolio());
        }

        private void blogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmBlog());
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmReporteClientes());
        }

        private void menuPrincipal_FontChanged(object sender, EventArgs e)
        {
            // Evento autogenerado, no se usa
        }

        private void leadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmLeads();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
