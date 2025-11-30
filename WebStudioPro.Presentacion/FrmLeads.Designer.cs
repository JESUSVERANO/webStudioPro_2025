namespace WebStudioPro.Presentacion
{
    partial class FrmLeads
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboFuente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCotizarLead = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.grpLista = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboFiltroEstado = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvLeads = new System.Windows.Forms.DataGridView();
            this.grpSeguimientos = new System.Windows.Forms.GroupBox();
            this.btnAgregarSeguimiento = new System.Windows.Forms.Button();
            this.txtDetalleSeguimiento = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboTipoContacto = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvSeguimientos = new System.Windows.Forms.DataGridView();
            this.grpDatos.SuspendLayout();
            this.grpLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeads)).BeginInit();
            this.grpSeguimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.cboPais);
            this.grpDatos.Controls.Add(this.label10);
            this.grpDatos.Controls.Add(this.cboMoneda);
            this.grpDatos.Controls.Add(this.label9);
            this.grpDatos.Controls.Add(this.cboEstado);
            this.grpDatos.Controls.Add(this.label8);
            this.grpDatos.Controls.Add(this.txtNotas);
            this.grpDatos.Controls.Add(this.label7);
            this.grpDatos.Controls.Add(this.txtInteres);
            this.grpDatos.Controls.Add(this.label6);
            this.grpDatos.Controls.Add(this.cboFuente);
            this.grpDatos.Controls.Add(this.label5);
            this.grpDatos.Controls.Add(this.cboTipoCliente);
            this.grpDatos.Controls.Add(this.label4);
            this.grpDatos.Controls.Add(this.txtTelefono);
            this.grpDatos.Controls.Add(this.label3);
            this.grpDatos.Controls.Add(this.txtEmail);
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.Controls.Add(this.btnCotizarLead);
            this.grpDatos.Controls.Add(this.btnEliminar);
            this.grpDatos.Controls.Add(this.btnGuardar);
            this.grpDatos.Controls.Add(this.btnNuevo);
            this.grpDatos.Location = new System.Drawing.Point(12, 12);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(430, 320);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del lead";
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Items.AddRange(new object[] {
            "Perú",
            "Ecuador",
            "Chile",
            "Colombia",
            "Bolivia",
            "Argentina",
            "México",
            "Otro"});
            this.cboPais.Location = new System.Drawing.Point(285, 96);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(125, 21);
            this.cboPais.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "País";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(285, 69);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(125, 21);
            this.cboMoneda.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(236, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Moneda";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(90, 96);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(129, 21);
            this.cboEstado.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Estado:";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(90, 189);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotas.Size = new System.Drawing.Size(320, 60);
            this.txtNotas.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Notas:";
            // 
            // txtInteres
            // 
            this.txtInteres.Location = new System.Drawing.Point(90, 162);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.Size = new System.Drawing.Size(320, 20);
            this.txtInteres.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Interés:";
            // 
            // cboFuente
            // 
            this.cboFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuente.FormattingEnabled = true;
            this.cboFuente.Location = new System.Drawing.Point(285, 42);
            this.cboFuente.Name = "cboFuente";
            this.cboFuente.Size = new System.Drawing.Size(125, 21);
            this.cboFuente.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Fuente:";
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCliente.FormattingEnabled = true;
            this.cboTipoCliente.Location = new System.Drawing.Point(90, 42);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Size = new System.Drawing.Size(129, 21);
            this.cboTipoCliente.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipo cliente:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(285, 123);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(125, 20);
            this.txtTelefono.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Teléfono:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(90, 123);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(129, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "E-mail:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(90, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(320, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre:";
            // 
            // btnCotizarLead
            // 
            this.btnCotizarLead.Location = new System.Drawing.Point(335, 265);
            this.btnCotizarLead.Name = "btnCotizarLead";
            this.btnCotizarLead.Size = new System.Drawing.Size(75, 23);
            this.btnCotizarLead.TabIndex = 13;
            this.btnCotizarLead.Text = "Cotizar lead";
            this.btnCotizarLead.UseVisualStyleBackColor = true;
            this.btnCotizarLead.Click += new System.EventHandler(this.btnCotizarLead_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(238, 265);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(140, 265);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(42, 265);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grpLista
            // 
            this.grpLista.Controls.Add(this.lblTotal);
            this.grpLista.Controls.Add(this.btnBuscar);
            this.grpLista.Controls.Add(this.cboFiltroEstado);
            this.grpLista.Controls.Add(this.label12);
            this.grpLista.Controls.Add(this.txtBuscar);
            this.grpLista.Controls.Add(this.label11);
            this.grpLista.Controls.Add(this.dgvLeads);
            this.grpLista.Location = new System.Drawing.Point(448, 12);
            this.grpLista.Name = "grpLista";
            this.grpLista.Size = new System.Drawing.Size(520, 320);
            this.grpLista.TabIndex = 1;
            this.grpLista.TabStop = false;
            this.grpLista.Text = "Leads registrados";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(399, 53);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(96, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "0 registros mostr.";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(439, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(69, 23);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboFiltroEstado
            // 
            this.cboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroEstado.FormattingEnabled = true;
            this.cboFiltroEstado.Location = new System.Drawing.Point(288, 21);
            this.cboFiltroEstado.Name = "cboFiltroEstado";
            this.cboFiltroEstado.Size = new System.Drawing.Size(133, 21);
            this.cboFiltroEstado.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(239, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Estado:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(64, 21);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(160, 20);
            this.txtBuscar.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Buscar:";
            // 
            // dgvLeads
            // 
            this.dgvLeads.AllowUserToAddRows = false;
            this.dgvLeads.AllowUserToDeleteRows = false;
            this.dgvLeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeads.Location = new System.Drawing.Point(18, 78);
            this.dgvLeads.MultiSelect = false;
            this.dgvLeads.Name = "dgvLeads";
            this.dgvLeads.ReadOnly = true;
            this.dgvLeads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeads.Size = new System.Drawing.Size(490, 226);
            this.dgvLeads.TabIndex = 18;
            this.dgvLeads.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeads_CellClick);
            // 
            // grpSeguimientos
            // 
            this.grpSeguimientos.Controls.Add(this.btnAgregarSeguimiento);
            this.grpSeguimientos.Controls.Add(this.txtDetalleSeguimiento);
            this.grpSeguimientos.Controls.Add(this.label15);
            this.grpSeguimientos.Controls.Add(this.cboTipoContacto);
            this.grpSeguimientos.Controls.Add(this.label14);
            this.grpSeguimientos.Controls.Add(this.dgvSeguimientos);
            this.grpSeguimientos.Location = new System.Drawing.Point(12, 338);
            this.grpSeguimientos.Name = "grpSeguimientos";
            this.grpSeguimientos.Size = new System.Drawing.Size(956, 220);
            this.grpSeguimientos.TabIndex = 2;
            this.grpSeguimientos.TabStop = false;
            this.grpSeguimientos.Text = "Seguimientos";
            // 
            // btnAgregarSeguimiento
            // 
            this.btnAgregarSeguimiento.Location = new System.Drawing.Point(853, 27);
            this.btnAgregarSeguimiento.Name = "btnAgregarSeguimiento";
            this.btnAgregarSeguimiento.Size = new System.Drawing.Size(86, 46);
            this.btnAgregarSeguimiento.TabIndex = 21;
            this.btnAgregarSeguimiento.Text = "Agregar";
            this.btnAgregarSeguimiento.UseVisualStyleBackColor = true;
            this.btnAgregarSeguimiento.Click += new System.EventHandler(this.btnAgregarSeguimiento_Click);
            // 
            // txtDetalleSeguimiento
            // 
            this.txtDetalleSeguimiento.Location = new System.Drawing.Point(288, 27);
            this.txtDetalleSeguimiento.Multiline = true;
            this.txtDetalleSeguimiento.Name = "txtDetalleSeguimiento";
            this.txtDetalleSeguimiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalleSeguimiento.Size = new System.Drawing.Size(559, 46);
            this.txtDetalleSeguimiento.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(236, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Detalle:";
            // 
            // cboTipoContacto
            // 
            this.cboTipoContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoContacto.FormattingEnabled = true;
            this.cboTipoContacto.Items.AddRange(new object[] {
            "Llamada",
            "WhatsApp",
            "Correo",
            "Reunión",
            "Otro"});
            this.cboTipoContacto.Location = new System.Drawing.Point(99, 27);
            this.cboTipoContacto.Name = "cboTipoContacto";
            this.cboTipoContacto.Size = new System.Drawing.Size(121, 21);
            this.cboTipoContacto.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Tipo contacto:";
            // 
            // dgvSeguimientos
            // 
            this.dgvSeguimientos.AllowUserToAddRows = false;
            this.dgvSeguimientos.AllowUserToDeleteRows = false;
            this.dgvSeguimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeguimientos.Location = new System.Drawing.Point(21, 83);
            this.dgvSeguimientos.MultiSelect = false;
            this.dgvSeguimientos.Name = "dgvSeguimientos";
            this.dgvSeguimientos.ReadOnly = true;
            this.dgvSeguimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeguimientos.Size = new System.Drawing.Size(918, 121);
            this.dgvSeguimientos.TabIndex = 22;
            // 
            // FrmLeads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 570);
            this.Controls.Add(this.grpSeguimientos);
            this.Controls.Add(this.grpLista);
            this.Controls.Add(this.grpDatos);
            this.Name = "FrmLeads";
            this.Text = "Leads";
            this.Load += new System.EventHandler(this.FrmLeads_Load);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpLista.ResumeLayout(false);
            this.grpLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeads)).EndInit();
            this.grpSeguimientos.ResumeLayout(false);
            this.grpSeguimientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboFuente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipoCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCotizarLead;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox grpLista;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboFiltroEstado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvLeads;
        private System.Windows.Forms.GroupBox grpSeguimientos;
        private System.Windows.Forms.Button btnAgregarSeguimiento;
        private System.Windows.Forms.TextBox txtDetalleSeguimiento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboTipoContacto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvSeguimientos;
    }
}
