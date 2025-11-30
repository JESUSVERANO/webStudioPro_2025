using System;

namespace WebStudioPro.Presentacion
{
    partial class FrmCotizador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboTipoWeb = new System.Windows.Forms.ComboBox();
            this.nudPaginas = new System.Windows.Forms.NumericUpDown();
            this.nudProductos = new System.Windows.Forms.NumericUpDown();
            this.chkDominio = new System.Windows.Forms.CheckBox();
            this.chkSEO = new System.Windows.Forms.CheckBox();
            this.chkHosting = new System.Windows.Forms.CheckBox();
            this.chkChatbot = new System.Windows.Forms.CheckBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCopiarResumen = new System.Windows.Forms.Button();
            this.btnGuardarCotizacion = new System.Windows.Forms.Button();
            this.dgvCotizaciones = new System.Windows.Forms.DataGridView();
            this.colTipoWeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaginas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.chkTienda = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.cboClienteProyecto = new System.Windows.Forms.ComboBox();
            this.labelNombreProyecto = new System.Windows.Forms.Label();
            this.txtNombreProyecto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoWeb
            // 
            this.cboTipoWeb.FormattingEnabled = true;
            this.cboTipoWeb.Location = new System.Drawing.Point(140, 46);
            this.cboTipoWeb.Name = "cboTipoWeb";
            this.cboTipoWeb.Size = new System.Drawing.Size(121, 21);
            this.cboTipoWeb.TabIndex = 0;
            this.cboTipoWeb.SelectedIndexChanged += new System.EventHandler(this.cboTipoWeb_SelectedIndexChanged);
            // 
            // nudPaginas
            // 
            this.nudPaginas.Location = new System.Drawing.Point(140, 88);
            this.nudPaginas.Name = "nudPaginas";
            this.nudPaginas.Size = new System.Drawing.Size(120, 20);
            this.nudPaginas.TabIndex = 1;
            // 
            // nudProductos
            // 
            this.nudProductos.Location = new System.Drawing.Point(140, 129);
            this.nudProductos.Name = "nudProductos";
            this.nudProductos.Size = new System.Drawing.Size(120, 20);
            this.nudProductos.TabIndex = 2;
            // 
            // chkDominio
            // 
            this.chkDominio.AutoSize = true;
            this.chkDominio.Location = new System.Drawing.Point(143, 173);
            this.chkDominio.Name = "chkDominio";
            this.chkDominio.Size = new System.Drawing.Size(64, 17);
            this.chkDominio.TabIndex = 3;
            this.chkDominio.Text = "Dominio";
            this.chkDominio.UseVisualStyleBackColor = true;
            // 
            // chkSEO
            // 
            this.chkSEO.AutoSize = true;
            this.chkSEO.Location = new System.Drawing.Point(352, 173);
            this.chkSEO.Name = "chkSEO";
            this.chkSEO.Size = new System.Drawing.Size(48, 17);
            this.chkSEO.TabIndex = 4;
            this.chkSEO.Text = "SEO";
            this.chkSEO.UseVisualStyleBackColor = true;
            // 
            // chkHosting
            // 
            this.chkHosting.AutoSize = true;
            this.chkHosting.Location = new System.Drawing.Point(249, 173);
            this.chkHosting.Name = "chkHosting";
            this.chkHosting.Size = new System.Drawing.Size(62, 17);
            this.chkHosting.TabIndex = 5;
            this.chkHosting.Text = "Hosting";
            this.chkHosting.UseVisualStyleBackColor = true;
            // 
            // chkChatbot
            // 
            this.chkChatbot.AutoSize = true;
            this.chkChatbot.Location = new System.Drawing.Point(443, 172);
            this.chkChatbot.Name = "chkChatbot";
            this.chkChatbot.Size = new System.Drawing.Size(64, 17);
            this.chkChatbot.TabIndex = 6;
            this.chkChatbot.Text = "ChatBot";
            this.chkChatbot.UseVisualStyleBackColor = true;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(19, 350);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 8;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo de Web";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Páginas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Productos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Extras:";
            // 
            // btnCopiarResumen
            // 
            this.btnCopiarResumen.Location = new System.Drawing.Point(202, 350);
            this.btnCopiarResumen.Name = "btnCopiarResumen";
            this.btnCopiarResumen.Size = new System.Drawing.Size(127, 23);
            this.btnCopiarResumen.TabIndex = 15;
            this.btnCopiarResumen.Text = "Copiar para enviar";
            this.btnCopiarResumen.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCotizacion
            // 
            this.btnGuardarCotizacion.Location = new System.Drawing.Point(104, 350);
            this.btnGuardarCotizacion.Name = "btnGuardarCotizacion";
            this.btnGuardarCotizacion.Size = new System.Drawing.Size(92, 23);
            this.btnGuardarCotizacion.TabIndex = 16;
            this.btnGuardarCotizacion.Text = "Guardar";
            this.btnGuardarCotizacion.UseVisualStyleBackColor = true;
            this.btnGuardarCotizacion.Click += new System.EventHandler(this.btnGuardarCotizacion_Click);
            // 
            // dgvCotizaciones
            // 
            this.dgvCotizaciones.AllowUserToAddRows = false;
            this.dgvCotizaciones.AllowUserToDeleteRows = false;
            this.dgvCotizaciones.AllowUserToResizeColumns = false;
            this.dgvCotizaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCotizaciones.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCotizaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCotizaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipoWeb,
            this.colPaginas,
            this.colProductos,
            this.colExtras,
            this.colMonedad,
            this.colTotal,
            this.colFecha});
            this.dgvCotizaciones.EnableHeadersVisualStyles = false;
            this.dgvCotizaciones.Location = new System.Drawing.Point(-3, 389);
            this.dgvCotizaciones.MultiSelect = false;
            this.dgvCotizaciones.Name = "dgvCotizaciones";
            this.dgvCotizaciones.ReadOnly = true;
            this.dgvCotizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCotizaciones.Size = new System.Drawing.Size(900, 260);
            this.dgvCotizaciones.TabIndex = 17;
            // 
            // colTipoWeb
            // 
            this.colTipoWeb.HeaderText = "Tipo Web";
            this.colTipoWeb.Name = "colTipoWeb";
            this.colTipoWeb.ReadOnly = true;
            // 
            // colPaginas
            // 
            this.colPaginas.HeaderText = "Páginas";
            this.colPaginas.Name = "colPaginas";
            this.colPaginas.ReadOnly = true;
            // 
            // colProductos
            // 
            this.colProductos.HeaderText = "Productos";
            this.colProductos.Name = "colProductos";
            this.colProductos.ReadOnly = true;
            // 
            // colExtras
            // 
            this.colExtras.HeaderText = "Extras";
            this.colExtras.Name = "colExtras";
            this.colExtras.ReadOnly = true;
            // 
            // colMonedad
            // 
            this.colMonedad.HeaderText = "Moneda";
            this.colMonedad.Name = "colMonedad";
            this.colMonedad.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(101, 312);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(28, 13);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "- - - -";
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tiempo estimado";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(399, 312);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(28, 13);
            this.lblTiempo.TabIndex = 21;
            this.lblTiempo.Text = "- - - -";
            // 
            // chkTienda
            // 
            this.chkTienda.AutoSize = true;
            this.chkTienda.Location = new System.Drawing.Point(537, 172);
            this.chkTienda.Name = "chkTienda";
            this.chkTienda.Size = new System.Drawing.Size(59, 17);
            this.chkTienda.TabIndex = 22;
            this.chkTienda.Text = "Tienda";
            this.chkTienda.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Moneda";
            // 
            // cboMoneda
            // 
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(140, 217);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 24;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(16, 252);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(42, 13);
            this.labelCliente.TabIndex = 25;
            this.labelCliente.Text = "Cliente:";
            // 
            // cboClienteProyecto
            // 
            this.cboClienteProyecto.FormattingEnabled = true;
            this.cboClienteProyecto.Location = new System.Drawing.Point(140, 249);
            this.cboClienteProyecto.Name = "cboClienteProyecto";
            this.cboClienteProyecto.Size = new System.Drawing.Size(250, 21);
            this.cboClienteProyecto.TabIndex = 26;
            // 
            // labelNombreProyecto
            // 
            this.labelNombreProyecto.AutoSize = true;
            this.labelNombreProyecto.Location = new System.Drawing.Point(16, 282);
            this.labelNombreProyecto.Name = "labelNombreProyecto";
            this.labelNombreProyecto.Size = new System.Drawing.Size(103, 13);
            this.labelNombreProyecto.TabIndex = 27;
            this.labelNombreProyecto.Text = "Nombre de proyecto";
            // 
            // txtNombreProyecto
            // 
            this.txtNombreProyecto.Location = new System.Drawing.Point(140, 279);
            this.txtNombreProyecto.Name = "txtNombreProyecto";
            this.txtNombreProyecto.Size = new System.Drawing.Size(250, 20);
            this.txtNombreProyecto.TabIndex = 28;
            // 
            // FrmCotizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 657);
            this.Controls.Add(this.txtNombreProyecto);
            this.Controls.Add(this.labelNombreProyecto);
            this.Controls.Add(this.cboClienteProyecto);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkTienda);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCotizaciones);
            this.Controls.Add(this.btnGuardarCotizacion);
            this.Controls.Add(this.btnCopiarResumen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.chkChatbot);
            this.Controls.Add(this.chkHosting);
            this.Controls.Add(this.chkSEO);
            this.Controls.Add(this.chkDominio);
            this.Controls.Add(this.nudProductos);
            this.Controls.Add(this.nudPaginas);
            this.Controls.Add(this.cboTipoWeb);
            this.Name = "FrmCotizador";
            this.Text = "Cotizador WebStudio PRO";
            ((System.ComponentModel.ISupportInitialize)(this.nudPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipoWeb;
        private System.Windows.Forms.NumericUpDown nudPaginas;
        private System.Windows.Forms.NumericUpDown nudProductos;
        private System.Windows.Forms.CheckBox chkDominio;
        private System.Windows.Forms.CheckBox chkSEO;
        private System.Windows.Forms.CheckBox chkHosting;
        private System.Windows.Forms.CheckBox chkChatbot;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCopiarResumen;
        private System.Windows.Forms.Button btnGuardarCotizacion;
        private System.Windows.Forms.DataGridView dgvCotizaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.CheckBox chkTienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoWeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaginas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExtras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox cboClienteProyecto;
        private System.Windows.Forms.Label labelNombreProyecto;
        private System.Windows.Forms.TextBox txtNombreProyecto;
    }
}
