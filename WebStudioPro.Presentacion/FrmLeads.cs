using System;
using System.Data;
using System.Windows.Forms;
using WebStudioPro.Presentacion.DAL;
using WebStudioPro.Presentacion.Entities;

namespace WebStudioPro.Presentacion
{
    public partial class FrmLeads : Form
    {
        private readonly LeadDAL _leadDal = new LeadDAL();
        private int _idLeadSeleccionado = 0;

        public FrmLeads()
        {
            InitializeComponent();
        }

        private void FrmLeads_Load(object sender, EventArgs e)
        {
            ConfigurarCombos();
            CargarLeads();
        }

        private void ConfigurarCombos()
        {
            cboTipoCliente.Items.AddRange(new object[] { "Nuevo", "Recurrente", "Referido" });
            cboFuente.Items.AddRange(new object[] { "Facebook", "Instagram", "Web", "WhatsApp", "Referido" });
            cboMoneda.Items.AddRange(new object[] { "PEN", "USD" });
            cboEstado.Items.AddRange(new object[] { "Nuevo", "En Proceso", "Cerrado", "Perdido" });

            cboFiltroEstado.Items.AddRange(new object[] { "Todos", "Nuevo", "En Proceso", "Cerrado", "Perdido" });
            cboFiltroEstado.SelectedIndex = 0;

            if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;
        }

        private void CargarLeads()
        {
            string filtro = txtBuscar.Text.Trim();
            string estado = cboFiltroEstado.Text == "Todos" ? string.Empty : cboFiltroEstado.Text;

            dgvLeads.DataSource = _leadDal.Listar(filtro, estado);
            dgvLeads.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void LimpiarFormulario()
        {
            _idLeadSeleccionado = 0;
            txtNombre.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtInteres.Clear();
            txtNotas.Clear();
            cboTipoCliente.SelectedIndex = -1;
            cboFuente.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            cboPais.SelectedIndex = -1;
            cboEstado.SelectedIndex = 0;
            dgvSeguimientos.DataSource = null;
        }

        private Lead ObtenerLeadDelFormulario()
        {
            return new Lead
            {
                IdLead          = _idLeadSeleccionado,
                Nombre          = txtNombre.Text.Trim(),
                Email           = txtEmail.Text.Trim(),
                Telefono        = txtTelefono.Text.Trim(),
                TipoCliente     = cboTipoCliente.Text,
                Fuente          = cboFuente.Text,
                Interes         = txtInteres.Text.Trim(),
                MonedaPreferida = cboMoneda.Text,
                Pais            = cboPais.Text,
                EstadoLead      = cboEstado.Text,
                Notas           = txtNotas.Text.Trim()
            };
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa el nombre del lead.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            var lead = ObtenerLeadDelFormulario();

            if (_idLeadSeleccionado == 0)
            {
                int nuevoId = _leadDal.Insertar(lead);
                _idLeadSeleccionado = nuevoId;
            }
            else
            {
                _leadDal.Actualizar(lead);
            }

            CargarLeads();
            MessageBox.Show("Lead guardado correctamente.", "Leads",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvLeads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvLeads.Rows[e.RowIndex];

            _idLeadSeleccionado = Convert.ToInt32(fila.Cells["IdLead"].Value);
            txtNombre.Text      = fila.Cells["Nombre"].Value?.ToString();
            txtEmail.Text       = fila.Cells["Email"].Value?.ToString();
            txtTelefono.Text    = fila.Cells["Telefono"].Value?.ToString();
            cboTipoCliente.Text = fila.Cells["TipoCliente"].Value?.ToString();
            cboFuente.Text      = fila.Cells["Fuente"].Value?.ToString();
            txtInteres.Text     = fila.Cells["Interes"].Value?.ToString();
            cboMoneda.Text      = fila.Cells["MonedaPreferida"].Value?.ToString();
            cboPais.Text        = fila.Cells["Pais"].Value?.ToString();
            cboEstado.Text      = fila.Cells["EstadoLead"].Value?.ToString();
            txtNotas.Text       = fila.Cells["Notas"].Value?.ToString();

            CargarSeguimientos();
        }

        private void CargarSeguimientos()
        {
            if (_idLeadSeleccionado <= 0)
            {
                dgvSeguimientos.DataSource = null;
                return;
            }

            dgvSeguimientos.DataSource = _leadDal.ListarSeguimientos(_idLeadSeleccionado);
            dgvSeguimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnAgregarSeguimiento_Click(object sender, EventArgs e)
        {
            if (_idLeadSeleccionado <= 0)
            {
                MessageBox.Show("Selecciona primero un lead.", "Leads",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cboTipoContacto.Text))
            {
                MessageBox.Show("Selecciona un tipo de contacto.", "Seguimientos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LeadSeguimiento seg = new LeadSeguimiento
            {
                IdLead         = _idLeadSeleccionado,
                FechaContacto  = DateTime.Now,
                TipoContacto   = cboTipoContacto.Text,
                Detalle        = txtDetalleSeguimiento.Text.Trim(),
                UsuarioRegistro = "admin"
            };

            _leadDal.InsertarSeguimiento(seg);
            txtDetalleSeguimiento.Clear();
            CargarSeguimientos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idLeadSeleccionado <= 0)
                return;

            DialogResult r = MessageBox.Show("¿Seguro que deseas eliminar este lead?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                _leadDal.Eliminar(_idLeadSeleccionado);
                LimpiarFormulario();
                CargarLeads();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarLeads();
        }

        private void btnCotizarLead_Click(object sender, EventArgs e)
        {
            if (_idLeadSeleccionado <= 0)
            {
                MessageBox.Show("Selecciona un lead primero.", "Leads",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Lead lead = ObtenerLeadDelFormulario();

            using (var frm = new FrmCotizador(lead))
            {
                frm.ShowDialog();
            }
        }
    }
}
