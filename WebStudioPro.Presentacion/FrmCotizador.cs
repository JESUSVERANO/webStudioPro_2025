using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using WebStudioPro.Presentacion.DAL;
using WebStudioPro.Presentacion.Entities;
using Ent = WebStudioPro.Presentacion.Entities;



namespace WebStudioPro.Presentacion
{
    public partial class FrmCotizador : Form
    {
        private readonly BindingSource _bsCoti = new BindingSource();

        // DALs (solo una vez cada uno)
        private readonly CotizacionDAL _cotDal = new CotizacionDAL();
        private readonly ProyectoDAL _proyDal = new ProyectoDAL();
        private readonly ClienteDAL _cliDal = new ClienteDAL();

        // Variables de cálculo en memoria
        private decimal _totalCalculado = 0m;
        private string _tiempoCalculado = "";
        private int? _idLeadOrigen = null;   // Lead origen (puede ser null)

        public FrmCotizador()
        {
            InitializeComponent();
            this.Load += FrmCotizador_Load;
        }

        public FrmCotizador(Lead lead) : this()
        {
            if (lead != null)
            {
                _idLeadOrigen = lead.IdLead;

                // Prellenar moneda si el lead tiene preferencia
                if (!string.IsNullOrWhiteSpace(lead.MonedaPreferida))
                {
                    int idx = cboMoneda.Items.IndexOf(lead.MonedaPreferida);
                    if (idx >= 0)
                        cboMoneda.SelectedIndex = idx;
                }

                // Usar el interés del lead como nombre de proyecto sugerido
                if (!string.IsNullOrWhiteSpace(lead.Interes))
                {
                    txtNombreProyecto.Text = lead.Interes;
                }
            }
        }

        //  LOAD 
        private void FrmCotizador_Load(object sender, EventArgs e)
        {
            ConfigurarCombos();
            ConfigurarGrid();
            LimpiarResultado();

            dgvCotizaciones.DataSource = _bsCoti;
            CargarCotizaciones();

            ActualizarVisibilidadProductos();
            CargarClientesParaProyecto();
        }

        //  Cargar clientes para poder crear proyecto desde cotizador
        private void CargarClientesParaProyecto()
        {
            var dt = _cliDal.Listar();

            cboClienteProyecto.DisplayMember = "Nombre";
            cboClienteProyecto.ValueMember = "IdCliente";
            cboClienteProyecto.DataSource = dt;

            if (dt.Rows.Count > 0)
                cboClienteProyecto.SelectedIndex = 0;
        }

        //  CONFIGURACIÓN 

        private void ConfigurarCombos()
        {
            cboTipoWeb.Items.Clear();
            cboTipoWeb.Items.AddRange(new object[]
            {
                "Landing",
                "Corporativa",
                "E-commerce",
                "Personalizada"
            });

            cboMoneda.Items.Clear();
            cboMoneda.Items.AddRange(new object[]
            {
                "PEN",
                "USD"
            });

            // valores por defecto
            if (cboTipoWeb.Items.Count > 0)
                cboTipoWeb.SelectedIndex = 0;

            if (cboMoneda.Items.Count > 0)
                cboMoneda.SelectedIndex = 0;

            nudPaginas.Minimum = 1;
            nudPaginas.Maximum = 50;
            nudPaginas.Value = 3;

            nudProductos.Minimum = 0;
            nudProductos.Maximum = 10000;
            nudProductos.Value = 0;
        }

        private void ConfigurarGrid()
        {
            dgvCotizaciones.AutoGenerateColumns = false;
            dgvCotizaciones.Columns.Clear();

            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "IdCotizacion",
                Visible = false
            });
            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTipoWeb",
                HeaderText = "Tipo Web",
                DataPropertyName = "TipoWeb"
            });
            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPaginas",
                HeaderText = "Páginas",
                DataPropertyName = "Paginas"
            });
            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductos",
                HeaderText = "Productos",
                DataPropertyName = "Productos"
            });
            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colExtras",
                HeaderText = "Extras",
                DataPropertyName = "Extras"
            });
            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMoneda",
                HeaderText = "Moneda",
                DataPropertyName = "Moneda"
            });
            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total",
                DataPropertyName = "Total",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.00" }
            });
            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTiempo",
                HeaderText = "Tiempo estimado",
                DataPropertyName = "TiempoEstimado"
            });
            dgvCotizaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvCotizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCotizaciones.ReadOnly = true;
            dgvCotizaciones.AllowUserToAddRows = false;
            dgvCotizaciones.AllowUserToDeleteRows = false;
            dgvCotizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCotizaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        //  CARGAR DESDE BD 

        private void CargarCotizaciones()
        {
            var lista = _cotDal.Listar();
            _bsCoti.DataSource = lista;
        }

        //  LÓGICA DE CÁLCULO 

        private decimal PrecioBase(string tipo)
        {
            return tipo == "Landing" ? 400m :
                   tipo == "Corporativa" ? 700m :
                   tipo == "E-commerce" ? 1500m : 900m;
        }

        private string ObtenerExtrasTexto()
        {
            var extras = new List<string>();
            if (chkDominio.Checked) extras.Add("Dominio");
            if (chkHosting.Checked) extras.Add("Hosting");
            if (chkSEO.Checked) extras.Add("SEO");
            if (chkChatbot.Checked) extras.Add("Chatbot");
            if (chkTienda.Checked) extras.Add("Tienda");

            return extras.Count == 0 ? "Ninguno" : string.Join(", ", extras);
        }

        private void LimpiarResultado()
        {
            lblTotal.Text = "Total: -";
            lblTiempo.Text = "Tiempo estimado: -";
            btnGuardarCotizacion.Enabled = false;
            _totalCalculado = 0m;
            _tiempoCalculado = "";
        }

        //  EVENTOS DE CONTROLES 

        private void cboTipoWeb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadProductos();
        }

        private void ActualizarVisibilidadProductos()
        {
            bool esEcommerce = (cboTipoWeb.Text == "E-commerce");

            nudProductos.Visible = esEcommerce;
            if (!esEcommerce)
                nudProductos.Value = 0;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboTipoWeb.Text) ||
                string.IsNullOrWhiteSpace(cboMoneda.Text))
            {
                MessageBox.Show("Selecciona el tipo de web y la moneda.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tipo = cboTipoWeb.Text;
            decimal total = PrecioBase(tipo);

            // Costo por páginas
            total += (int)nudPaginas.Value * 80m;

            // Extra por productos si es E-commerce
            if (tipo == "E-commerce")
                total += (int)nudProductos.Value * 5m;

            // Extras
            if (chkDominio.Checked) total += 50m;
            if (chkHosting.Checked) total += 120m;
            if (chkSEO.Checked) total += 180m;
            if (chkChatbot.Checked) total += 100m;
            if (chkTienda.Checked) total += 150m;

            // Tiempo estimado según tipo
            string tiempo;
            if (tipo == "Landing") tiempo = "1–2 semanas";
            else if (tipo == "Corporativa") tiempo = "2–3 semanas";
            else if (tipo == "E-commerce") tiempo = "3–5 semanas";
            else tiempo = "3–4 semanas"; // Personalizada

            _totalCalculado = total;
            _tiempoCalculado = tiempo;

            lblTotal.Text = $"{cboMoneda.Text} {total:0.00}";
            lblTiempo.Text = $"Tiempo estimado: {tiempo}";

            btnGuardarCotizacion.Enabled = true;
        }

        private void btnGuardarCotizacion_Click(object sender, EventArgs e)
        {
            if (!btnGuardarCotizacion.Enabled)
                return;

            if (_totalCalculado <= 0m)
            {
                MessageBox.Show("Primero calcula la cotización.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Armar la cotización
            var dto = new Ent.Cotizacion
            {
                IdLead = _idLeadOrigen,
                IdCliente = Convert.ToInt32(cboClienteProyecto.SelectedValue),

                TipoWeb = cboTipoWeb.Text,
                Paginas = (int)nudPaginas.Value,
                Productos = (cboTipoWeb.Text == "E-commerce") ? (int)nudProductos.Value : 0,
                Extras = ObtenerExtrasTexto(),
                Moneda = cboMoneda.Text,
                Total = _totalCalculado,
                TiempoEstimado = _tiempoCalculado,
                Fecha = DateTime.Now
            };

            // 2. Guardar cotización
            int nuevoId = _cotDal.Insertar(dto);

            MessageBox.Show("Cotización guardada en la BD (ID: " + nuevoId + ").",
                "Cotizador", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Preguntar si se quiere crear también un proyecto
            var r = MessageBox.Show(
                "¿Deseas crear también un proyecto con esta cotización?",
                "Proyectos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                if (cboClienteProyecto.SelectedValue == null ||
                    string.IsNullOrWhiteSpace(txtNombreProyecto.Text))
                {
                    MessageBox.Show("Selecciona un cliente y un nombre de proyecto.",
                        "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // 4. Crear proyecto a partir de la cotización
                    var proy = new Proyecto
                    {
                        IdCliente = Convert.ToInt32(cboClienteProyecto.SelectedValue),
                        Nombre = txtNombreProyecto.Text.Trim(),
                        TipoWeb = dto.TipoWeb,
                        Estado = "Nuevo",
                        FechaInicio = DateTime.Now,
                        FechaEntrega = null,
                        Monto = dto.Total,
                        Moneda = dto.Moneda,
                        Extras = dto.Extras,
                        Notas = $"Proyecto generado desde cotización #{nuevoId}"
                    };

                    _proyDal.Insertar(proy);

                    MessageBox.Show("Proyecto creado correctamente.",
                        "Proyectos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // 5. Refrescar grilla y limpiar
            CargarCotizaciones();
            LimpiarResultado();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
