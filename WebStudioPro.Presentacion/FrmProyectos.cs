using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WebStudioPro.Presentacion.DAL;
using WebStudioPro.Presentacion.Entities;   

namespace WebStudioPro.Presentacion
{
    public partial class FrmProyectos : Form
    {

        private readonly ProyectoDAL _proyDal = new ProyectoDAL();
        private readonly ClienteDAL _cliDal = new ClienteDAL();

        private int _idProyectoSeleccionado = 0;

        public FrmProyectos()
        {
            InitializeComponent();

            dgvProyectos.AutoGenerateColumns = false;

            this.Load += FrmProyectos_Load;
            dgvProyectos.CellClick += dgvProyectos_CellClick;
        }

        // LOAD 
        private void FrmProyectos_Load(object sender, EventArgs e)
        {
            ConfigurarCombos();
            ConfigurarGrid();
            CargarClientesEnCombo();
            CargarProyectos();
            LimpiarFormulario();
        }

        //  COMBOS

        private void ConfigurarCombos()
        {
            // Tipo de web
            cboTipoWeb.Items.Clear();
            cboTipoWeb.Items.AddRange(new object[]
            {
                "Landing",
                "Corporativa",
                "E-commerce",
                "Personalizada"
            });

            // Estado
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[]
            {
                "Nuevo",
                "En Proceso",
                "Entregado",
                "Pausado"
            });

            // Moneda
            cboMoneda.Items.Clear();
            cboMoneda.Items.AddRange(new object[]
            {
                "PEN",
                "USD"
            });

            // Extras 
            clbExtras.Items.Clear();
            clbExtras.Items.AddRange(new object[]
            {
                "Dominio",
                "Hosting",
                "SEO",
                "Chatbot",
                "Tienda"
            });

            // NumericUpDown
            nudMonto.DecimalPlaces = 2;
            nudMonto.Maximum = 1000000;
            nudMonto.Minimum = 0;
        }

        private void CargarClientesEnCombo()
        {
            
            DataTable dtCli = _cliDal.Listar();

            cboCliente.DisplayMember = "Nombre";
            cboCliente.ValueMember = "IdCliente";
            cboCliente.DataSource = dtCli;

            if (dtCli.Rows.Count > 0)
                cboCliente.SelectedIndex = 0;
        }

        // GRID 

        private void ConfigurarGrid()
        {
            dgvProyectos.Columns.Clear();

            // 
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdProyecto",
                HeaderText = "IdProyecto",
                DataPropertyName = "IdProyecto",
                Visible = false
            });

            // IdCliente 
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdCliente",
                HeaderText = "IdCliente",
                DataPropertyName = "IdCliente",
                Visible = false
            });

            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCliente",
                HeaderText = "Cliente",
                DataPropertyName = "ClienteNombre"
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Proyecto",
                DataPropertyName = "Nombre"
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTipo",
                HeaderText = "Tipo",
                DataPropertyName = "TipoWeb"
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "Estado"
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colInicio",
                HeaderText = "Inicio",
                DataPropertyName = "FechaInicio",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEntrega",
                HeaderText = "Entrega",
                DataPropertyName = "FechaEntrega",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMonto",
                HeaderText = "Monto",
                DataPropertyName = "Monto",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.00" }
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMoneda",
                HeaderText = "Moneda",
                DataPropertyName = "Moneda"
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colExtras",
                HeaderText = "Extras",
                DataPropertyName = "Extras"
            });

            dgvProyectos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProyectos.ReadOnly = true;
            dgvProyectos.AllowUserToAddRows = false;
            dgvProyectos.AllowUserToDeleteRows = false;
            dgvProyectos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProyectos.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        // CARGA DE DATOS 

        private void CargarProyectos()
        {
            dgvProyectos.DataSource = _proyDal.Listar();   
        }

        private void LimpiarFormulario()
        {
            _idProyectoSeleccionado = 0;

            if (cboCliente.Items.Count > 0)
                cboCliente.SelectedIndex = 0;

            txtNombreProyecto.Clear();
            cboTipoWeb.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;

            dtpInicio.Value = DateTime.Today;
            dtpEntrega.Value = DateTime.Today.AddDays(15);

            nudMonto.Value = 0;
            txtNotas.Clear();

            for (int i = 0; i < clbExtras.Items.Count; i++)
                clbExtras.SetItemChecked(i, false);
        }

        // EXTRAS 

        private string ObtenerExtrasSeleccionados()
        {
            var lista = clbExtras
                .CheckedItems
                .OfType<object>()
                .Select(x => x.ToString())
                .ToList();

            return string.Join(";", lista);
        }

        private void MarcarExtrasDesdeTexto(string extras)
        {
            for (int i = 0; i < clbExtras.Items.Count; i++)
                clbExtras.SetItemChecked(i, false);

            if (string.IsNullOrWhiteSpace(extras))
                return;

            var partes = extras.Split(';');

            for (int i = 0; i < clbExtras.Items.Count; i++)
            {
                string texto = clbExtras.Items[i].ToString();
                if (partes.Any(p => string.Equals(texto, p.Trim(), StringComparison.OrdinalIgnoreCase)))
                    clbExtras.SetItemChecked(i, true);
            }
        }

        // BOTONES 

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            cboEstado.SelectedItem = "Nuevo";
            cboMoneda.SelectedItem = "PEN";
        }

        
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //  VALIDACIÓN BÁSICA 
            if (cboCliente.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtNombreProyecto.Text) ||
                string.IsNullOrWhiteSpace(cboTipoWeb.Text) ||
                string.IsNullOrWhiteSpace(cboEstado.Text) ||
                string.IsNullOrWhiteSpace(cboMoneda.Text))
            {
                MessageBox.Show("Completa Cliente, Nombre, Tipo, Estado y Moneda.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  CAPTURAR DATOS 
            int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
            string nombre = txtNombreProyecto.Text.Trim();
            string tipoWeb = cboTipoWeb.Text;
            string estado = cboEstado.Text;
            DateTime fechaInicio = dtpInicio.Value.Date;
            DateTime fechaEntrega = dtpEntrega.Value.Date;
            decimal monto = nudMonto.Value;
            string moneda = cboMoneda.Text;
            string extras = ObtenerExtrasSeleccionados();
            string notas = txtNotas.Text.Trim();

            if (_idProyectoSeleccionado == 0)
            {
                // INSERTAR
                var dto = new Proyecto
                {
                    IdCliente = idCliente,
                    Nombre = nombre,
                    TipoWeb = tipoWeb,
                    Estado = estado,
                    FechaInicio = fechaInicio,
                    FechaEntrega = fechaEntrega,
                    Monto = monto,
                    Moneda = moneda,
                    Extras = extras,
                    Notas = notas
                };

                int nuevoId = _proyDal.Insertar(dto);

                MessageBox.Show("Proyecto registrado correctamente.",
                    "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ACTUALIZAR
                var dto = new Proyecto
                {
                    IdProyecto = _idProyectoSeleccionado,
                    IdCliente = idCliente,
                    Nombre = nombre,
                    TipoWeb = tipoWeb,
                    Estado = estado,
                    FechaInicio = fechaInicio,
                    FechaEntrega = fechaEntrega,
                    Monto = monto,
                    Moneda = moneda,
                    Extras = extras,
                    Notas = notas
                };

                _proyDal.Actualizar(dto);

                MessageBox.Show("Proyecto actualizado correctamente.",
                    "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarProyectos();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idProyectoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un proyecto de la lista.",
                    "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show("¿Seguro que deseas eliminar este proyecto?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                _proyDal.Eliminar(_idProyectoSeleccionado);
                CargarProyectos();
                LimpiarFormulario();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarProyectos();
        }

        //  GRID CLICK 

        private void dgvProyectos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvProyectos.Rows[e.RowIndex];

            _idProyectoSeleccionado = Convert.ToInt32(fila.Cells["colIdProyecto"].Value);

            int idCliente = Convert.ToInt32(fila.Cells["colIdCliente"].Value);
            cboCliente.SelectedValue = idCliente;

            txtNombreProyecto.Text = fila.Cells["colNombre"].Value?.ToString();
            cboTipoWeb.Text = fila.Cells["colTipo"].Value?.ToString();
            cboEstado.Text = fila.Cells["colEstado"].Value?.ToString();

            if (fila.Cells["colInicio"].Value != DBNull.Value)
                dtpInicio.Value = Convert.ToDateTime(fila.Cells["colInicio"].Value);

            if (fila.Cells["colEntrega"].Value != DBNull.Value)
                dtpEntrega.Value = Convert.ToDateTime(fila.Cells["colEntrega"].Value);

            if (fila.Cells["colMonto"].Value != DBNull.Value)
                nudMonto.Value = Convert.ToDecimal(fila.Cells["colMonto"].Value);

            cboMoneda.Text = fila.Cells["colMoneda"].Value?.ToString();

            string extras = fila.Cells["colExtras"].Value?.ToString();
            MarcarExtrasDesdeTexto(extras);

            // Notas viene en el DataTable, no como columna visible
            var drv = fila.DataBoundItem as DataRowView;
            if (drv != null && drv.Row.Table.Columns.Contains("Notas"))
            {
                txtNotas.Text = drv["Notas"] != DBNull.Value ? drv["Notas"].ToString() : "";
            }
        }
    }
}
