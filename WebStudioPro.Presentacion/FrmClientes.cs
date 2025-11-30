using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WebStudioPro.Presentacion.DAL;

namespace WebStudioPro.Presentacion
{
    public partial class FrmClientes : Form
    {
        private readonly ClienteDAL _clienteDal = new ClienteDAL();
        private int _idSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = false;

            this.Load += FrmClientes_Load;
            dgvClientes.CellClick += dgvClientes_CellClick;
        }

        // ==================== LOAD ====================
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ConfigurarGrid();
            CargarClientes();
            LimpiarFormulario();
        }

        // ==================== COMBOS ====================
        private class Opcion
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }

        private void CargarCombos()
        {
            // --- País (solo Sudamérica) ---
            var paises = new List<Opcion>
            {
                new Opcion { Text = "Perú",      Value = "PE" },
                new Opcion { Text = "Ecuador",   Value = "EC" },
                new Opcion { Text = "Uruguay",   Value = "UY" },
                new Opcion { Text = "Argentina", Value = "AR" },
                new Opcion { Text = "Chile",     Value = "CL" },
                new Opcion { Text = "Colombia",  Value = "CO" },
                new Opcion { Text = "Bolivia",   Value = "BO" },
                new Opcion { Text = "Paraguay",  Value = "PY" },
                new Opcion { Text = "Venezuela", Value = "VE" },
                new Opcion { Text = "Guyana",    Value = "GY" },
                new Opcion { Text = "Surinam",   Value = "SR" },
                new Opcion { Text = "Brasil",    Value = "BR" }
            };

            cboPais.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPais.DisplayMember = "Text";
            cboPais.ValueMember = "Value";
            cboPais.DataSource = paises;
            cboPais.SelectedValue = "PE";

            // Moneda
            cboMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMoneda.Items.Clear();
            cboMoneda.Items.AddRange(new object[] { "PEN", "USD" });
            cboMoneda.SelectedItem = "PEN";

            // País -> Moneda
            cboPais.SelectedValueChanged += (s, e) =>
            {
                var pais = cboPais.SelectedValue?.ToString();
                cboMoneda.SelectedItem = (pais == "PE") ? "PEN" : "USD";
            };

            // Tipo de documento
            cboTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoDoc.Items.Clear();
            cboTipoDoc.Items.AddRange(new object[] { "DNI", "RUC", "CI", "CUIT", "RUT" });
            cboTipoDoc.SelectedIndex = 0;
        }

        // ==================== GRID ====================
        private void ConfigurarGrid()
        {
            dgvClientes.Columns.Clear();

            // Id oculto
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdCliente",
                HeaderText = "Id",
                DataPropertyName = "IdCliente",
                Visible = false
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTipoDoc",
                HeaderText = "Tipo Doc",
                DataPropertyName = "TipoDocumento"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDocumento",
                HeaderText = "Documento",
                DataPropertyName = "Documento"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTelefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCorreo",
                HeaderText = "Correo",
                DataPropertyName = "Correo"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMoneda",
                HeaderText = "Moneda",
                DataPropertyName = "Moneda"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPais",
                HeaderText = "País",
                DataPropertyName = "Pais"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRegistro",
                HeaderText = "Registro",
                DataPropertyName = "FechaRegistro",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        //  CARGAR DATOS 
        private void CargarClientes(string filtro = "")
        {
            dgvClientes.DataSource = _clienteDal.Listar(filtro);

            if (lblRegistros != null)
                lblRegistros.Text = $"{dgvClientes.Rows.Count} registros";
        }

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;

            txtNombre.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();

            if (cboTipoDoc.Items.Count > 0)
                cboTipoDoc.SelectedIndex = 0;

            if (cboPais.DataSource != null)
                cboPais.SelectedValue = "PE";

            cboMoneda.SelectedItem = "PEN";

            txtNombre.Focus();
        }

        //  BOTONES 
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa el nombre del cliente.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idSeleccionado == 0)
            {
                // INSERTAR
                _clienteDal.Insertar(
                    txtNombre.Text.Trim(),
                    cboTipoDoc.Text,
                    txtDocumento.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    cboMoneda.Text,
                    cboPais.Text,
                    DateTime.Now
                );

                MessageBox.Show("Cliente registrado correctamente.",
                    "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ACTUALIZAR
                _clienteDal.Actualizar(
                    _idSeleccionado,
                    txtNombre.Text.Trim(),
                    cboTipoDoc.Text,
                    txtDocumento.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    cboMoneda.Text,
                    cboPais.Text
                );

                MessageBox.Show("Cliente actualizado correctamente.",
                    "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarClientes();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cliente de la lista.",
                    "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show("¿Seguro que deseas eliminar este cliente?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                _clienteDal.Eliminar(_idSeleccionado);
                CargarClientes();
                LimpiarFormulario();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes(txtBuscar.Text.Trim());
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exportar se implementará en la siguiente fase (Excel/CSV).",
                "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //  GRID: seleccionar fila 
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvClientes.Rows[e.RowIndex];

            _idSeleccionado = Convert.ToInt32(fila.Cells["colIdCliente"].Value);

            txtNombre.Text = fila.Cells["colNombre"].Value?.ToString();
            cboTipoDoc.Text = fila.Cells["colTipoDoc"].Value?.ToString();
            txtDocumento.Text = fila.Cells["colDocumento"].Value?.ToString();
            txtTelefono.Text = fila.Cells["colTelefono"].Value?.ToString();
            txtCorreo.Text = fila.Cells["colCorreo"].Value?.ToString();
            cboMoneda.Text = fila.Cells["colMoneda"].Value?.ToString();
            cboPais.Text = fila.Cells["colPais"].Value?.ToString();
        }
    }
}

