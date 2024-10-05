namespace CapaPresentacion
{
    partial class FrmCliente
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
			this.GbDatos = new System.Windows.Forms.GroupBox();
			this.TbDocumentoIdentidadNumero = new CapaPresentacion.Controls.CustomTextBox();
			this.TbEmail = new System.Windows.Forms.TextBox();
			this.TbCelular = new System.Windows.Forms.TextBox();
			this.LbEmail = new System.Windows.Forms.Label();
			this.LbCelular = new System.Windows.Forms.Label();
			this.TbApellido2 = new System.Windows.Forms.TextBox();
			this.TbApellido1 = new System.Windows.Forms.TextBox();
			this.TbNombres = new System.Windows.Forms.TextBox();
			this.CmbTipoDocumentoIdentidad = new System.Windows.Forms.ComboBox();
			this.LbApellido2 = new System.Windows.Forms.Label();
			this.LbApellido1 = new System.Windows.Forms.Label();
			this.LbNombres = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TbRazonSocial = new System.Windows.Forms.TextBox();
			this.LbRazonSocial = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.GbLista = new System.Windows.Forms.GroupBox();
			this.DgvCliente = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LbOpcion = new System.Windows.Forms.Label();
			this.BnGuardar = new System.Windows.Forms.Button();
			this.BnCancelar = new System.Windows.Forms.Button();
			this.BnNuevo = new System.Windows.Forms.Button();
			this.BnEditar = new System.Windows.Forms.Button();
			this.BnDeshabilitar = new System.Windows.Forms.Button();
			this.BnBuscar = new System.Windows.Forms.Button();
			this.BnSalir = new System.Windows.Forms.Button();
			this.BnFiltrar = new System.Windows.Forms.Button();
			this.BnConsultaAPI = new System.Windows.Forms.Button();
			this.GbDatos.SuspendLayout();
			this.GbLista.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgvCliente)).BeginInit();
			this.SuspendLayout();
			// 
			// GbDatos
			// 
			this.GbDatos.Controls.Add(this.BnConsultaAPI);
			this.GbDatos.Controls.Add(this.TbDocumentoIdentidadNumero);
			this.GbDatos.Controls.Add(this.TbEmail);
			this.GbDatos.Controls.Add(this.TbCelular);
			this.GbDatos.Controls.Add(this.LbEmail);
			this.GbDatos.Controls.Add(this.LbCelular);
			this.GbDatos.Controls.Add(this.TbApellido2);
			this.GbDatos.Controls.Add(this.TbApellido1);
			this.GbDatos.Controls.Add(this.TbNombres);
			this.GbDatos.Controls.Add(this.CmbTipoDocumentoIdentidad);
			this.GbDatos.Controls.Add(this.LbApellido2);
			this.GbDatos.Controls.Add(this.LbApellido1);
			this.GbDatos.Controls.Add(this.LbNombres);
			this.GbDatos.Controls.Add(this.label3);
			this.GbDatos.Controls.Add(this.label2);
			this.GbDatos.Controls.Add(this.TbRazonSocial);
			this.GbDatos.Controls.Add(this.LbRazonSocial);
			this.GbDatos.Location = new System.Drawing.Point(12, 47);
			this.GbDatos.Name = "GbDatos";
			this.GbDatos.Size = new System.Drawing.Size(958, 177);
			this.GbDatos.TabIndex = 1;
			this.GbDatos.TabStop = false;
			this.GbDatos.Text = "Datos del Cliente";
			// 
			// TbDocumentoIdentidadNumero
			// 
			this.TbDocumentoIdentidadNumero.Location = new System.Drawing.Point(547, 34);
			this.TbDocumentoIdentidadNumero.Name = "TbDocumentoIdentidadNumero";
			this.TbDocumentoIdentidadNumero.Size = new System.Drawing.Size(228, 28);
			this.TbDocumentoIdentidadNumero.TabIndex = 3;
			this.TbDocumentoIdentidadNumero.TipoCaracteres = CapaPresentacion.Controls.CustomTextBox.TipoInput.Todo;
			// 
			// TbEmail
			// 
			this.TbEmail.Location = new System.Drawing.Point(547, 140);
			this.TbEmail.MaxLength = 100;
			this.TbEmail.Name = "TbEmail";
			this.TbEmail.Size = new System.Drawing.Size(228, 28);
			this.TbEmail.TabIndex = 0;
			// 
			// TbCelular
			// 
			this.TbCelular.Location = new System.Drawing.Point(153, 140);
			this.TbCelular.MaxLength = 50;
			this.TbCelular.Name = "TbCelular";
			this.TbCelular.Size = new System.Drawing.Size(228, 28);
			this.TbCelular.TabIndex = 15;
			// 
			// LbEmail
			// 
			this.LbEmail.AutoSize = true;
			this.LbEmail.Location = new System.Drawing.Point(479, 143);
			this.LbEmail.Name = "LbEmail";
			this.LbEmail.Size = new System.Drawing.Size(62, 21);
			this.LbEmail.TabIndex = 16;
			this.LbEmail.Text = "Email :";
			// 
			// LbCelular
			// 
			this.LbCelular.AutoSize = true;
			this.LbCelular.Location = new System.Drawing.Point(75, 143);
			this.LbCelular.Name = "LbCelular";
			this.LbCelular.Size = new System.Drawing.Size(72, 21);
			this.LbCelular.TabIndex = 14;
			this.LbCelular.Text = "Celular :";
			// 
			// TbApellido2
			// 
			this.TbApellido2.Location = new System.Drawing.Point(547, 105);
			this.TbApellido2.MaxLength = 50;
			this.TbApellido2.Name = "TbApellido2";
			this.TbApellido2.Size = new System.Drawing.Size(228, 28);
			this.TbApellido2.TabIndex = 13;
			// 
			// TbApellido1
			// 
			this.TbApellido1.Location = new System.Drawing.Point(153, 105);
			this.TbApellido1.MaxLength = 50;
			this.TbApellido1.Name = "TbApellido1";
			this.TbApellido1.Size = new System.Drawing.Size(228, 28);
			this.TbApellido1.TabIndex = 11;
			// 
			// TbNombres
			// 
			this.TbNombres.Location = new System.Drawing.Point(153, 69);
			this.TbNombres.MaxLength = 100;
			this.TbNombres.Name = "TbNombres";
			this.TbNombres.Size = new System.Drawing.Size(622, 28);
			this.TbNombres.TabIndex = 9;
			// 
			// CmbTipoDocumentoIdentidad
			// 
			this.CmbTipoDocumentoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbTipoDocumentoIdentidad.FormattingEnabled = true;
			this.CmbTipoDocumentoIdentidad.Location = new System.Drawing.Point(153, 33);
			this.CmbTipoDocumentoIdentidad.Name = "CmbTipoDocumentoIdentidad";
			this.CmbTipoDocumentoIdentidad.Size = new System.Drawing.Size(228, 29);
			this.CmbTipoDocumentoIdentidad.TabIndex = 1;
			this.CmbTipoDocumentoIdentidad.SelectedIndexChanged += new System.EventHandler(this.CmbTipoDocumentoIdentidad_SelectedIndexChanged);
			// 
			// LbApellido2
			// 
			this.LbApellido2.AutoSize = true;
			this.LbApellido2.Location = new System.Drawing.Point(447, 108);
			this.LbApellido2.Name = "LbApellido2";
			this.LbApellido2.Size = new System.Drawing.Size(94, 21);
			this.LbApellido2.TabIndex = 12;
			this.LbApellido2.Text = "Apellido 2 :";
			// 
			// LbApellido1
			// 
			this.LbApellido1.AutoSize = true;
			this.LbApellido1.Location = new System.Drawing.Point(53, 108);
			this.LbApellido1.Name = "LbApellido1";
			this.LbApellido1.Size = new System.Drawing.Size(94, 21);
			this.LbApellido1.TabIndex = 10;
			this.LbApellido1.Text = "Apellido 1 :";
			// 
			// LbNombres
			// 
			this.LbNombres.AutoSize = true;
			this.LbNombres.Location = new System.Drawing.Point(60, 72);
			this.LbNombres.Name = "LbNombres";
			this.LbNombres.Size = new System.Drawing.Size(87, 21);
			this.LbNombres.TabIndex = 8;
			this.LbNombres.Text = "Nombres :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(411, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 21);
			this.label3.TabIndex = 2;
			this.label3.Text = "Nº Documento :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 21);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tipo Doc. Ident. :";
			// 
			// TbRazonSocial
			// 
			this.TbRazonSocial.Location = new System.Drawing.Point(153, 69);
			this.TbRazonSocial.MaxLength = 250;
			this.TbRazonSocial.Name = "TbRazonSocial";
			this.TbRazonSocial.Size = new System.Drawing.Size(622, 28);
			this.TbRazonSocial.TabIndex = 6;
			// 
			// LbRazonSocial
			// 
			this.LbRazonSocial.AutoSize = true;
			this.LbRazonSocial.Location = new System.Drawing.Point(32, 72);
			this.LbRazonSocial.Name = "LbRazonSocial";
			this.LbRazonSocial.Size = new System.Drawing.Size(115, 21);
			this.LbRazonSocial.TabIndex = 5;
			this.LbRazonSocial.Text = "Razón Social :";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Highlight;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(982, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mantenedor - Cliente";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GbLista
			// 
			this.GbLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GbLista.Controls.Add(this.DgvCliente);
			this.GbLista.Location = new System.Drawing.Point(12, 271);
			this.GbLista.Name = "GbLista";
			this.GbLista.Size = new System.Drawing.Size(958, 377);
			this.GbLista.TabIndex = 6;
			this.GbLista.TabStop = false;
			this.GbLista.Text = "Lista de Clientes";
			// 
			// DgvCliente
			// 
			this.DgvCliente.AllowUserToAddRows = false;
			this.DgvCliente.AllowUserToDeleteRows = false;
			this.DgvCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
			this.DgvCliente.Location = new System.Drawing.Point(12, 25);
			this.DgvCliente.MultiSelect = false;
			this.DgvCliente.Name = "DgvCliente";
			this.DgvCliente.ReadOnly = true;
			this.DgvCliente.RowHeadersWidth = 51;
			this.DgvCliente.RowTemplate.Height = 24;
			this.DgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DgvCliente.Size = new System.Drawing.Size(935, 338);
			this.DgvCliente.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Tipo Doc. Ident.";
			this.Column1.MinimumWidth = 6;
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 170;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Nº Documento";
			this.Column2.MinimumWidth = 6;
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 150;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Razón Social / Apellidos y Nombres";
			this.Column3.MinimumWidth = 6;
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 300;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Teléfono";
			this.Column4.MinimumWidth = 6;
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 125;
			// 
			// Column5
			// 
			this.Column5.HeaderText = "Email";
			this.Column5.MinimumWidth = 6;
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 200;
			// 
			// Column6
			// 
			this.Column6.HeaderText = "Activo";
			this.Column6.MinimumWidth = 6;
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 125;
			// 
			// LbOpcion
			// 
			this.LbOpcion.BackColor = System.Drawing.SystemColors.Highlight;
			this.LbOpcion.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LbOpcion.ForeColor = System.Drawing.Color.White;
			this.LbOpcion.Location = new System.Drawing.Point(12, 232);
			this.LbOpcion.Name = "LbOpcion";
			this.LbOpcion.Size = new System.Drawing.Size(381, 30);
			this.LbOpcion.TabIndex = 2;
			this.LbOpcion.Text = "OPCIÓN : NUEVO / EDITAR / BUSCAR";
			this.LbOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BnGuardar
			// 
			this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnGuardar.Location = new System.Drawing.Point(558, 230);
			this.BnGuardar.Name = "BnGuardar";
			this.BnGuardar.Size = new System.Drawing.Size(110, 35);
			this.BnGuardar.TabIndex = 3;
			this.BnGuardar.Text = "Guardar";
			this.BnGuardar.UseVisualStyleBackColor = true;
			this.BnGuardar.Click += new System.EventHandler(this.BnGuardar_Click);
			// 
			// BnCancelar
			// 
			this.BnCancelar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnCancelar.Location = new System.Drawing.Point(677, 230);
			this.BnCancelar.Name = "BnCancelar";
			this.BnCancelar.Size = new System.Drawing.Size(110, 35);
			this.BnCancelar.TabIndex = 4;
			this.BnCancelar.Text = "Cancelar";
			this.BnCancelar.UseVisualStyleBackColor = true;
			this.BnCancelar.Click += new System.EventHandler(this.BnCancelar_Click);
			// 
			// BnNuevo
			// 
			this.BnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnNuevo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnNuevo.Location = new System.Drawing.Point(12, 656);
			this.BnNuevo.Name = "BnNuevo";
			this.BnNuevo.Size = new System.Drawing.Size(110, 35);
			this.BnNuevo.TabIndex = 7;
			this.BnNuevo.Text = "Nuevo";
			this.BnNuevo.UseVisualStyleBackColor = true;
			this.BnNuevo.Click += new System.EventHandler(this.BnNuevo_Click);
			// 
			// BnEditar
			// 
			this.BnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnEditar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnEditar.Location = new System.Drawing.Point(128, 656);
			this.BnEditar.Name = "BnEditar";
			this.BnEditar.Size = new System.Drawing.Size(110, 35);
			this.BnEditar.TabIndex = 8;
			this.BnEditar.Text = "Editar";
			this.BnEditar.UseVisualStyleBackColor = true;
			this.BnEditar.Click += new System.EventHandler(this.BnEditar_Click);
			// 
			// BnDeshabilitar
			// 
			this.BnDeshabilitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnDeshabilitar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnDeshabilitar.Location = new System.Drawing.Point(244, 656);
			this.BnDeshabilitar.Name = "BnDeshabilitar";
			this.BnDeshabilitar.Size = new System.Drawing.Size(137, 35);
			this.BnDeshabilitar.TabIndex = 9;
			this.BnDeshabilitar.Text = "Deshabilitar";
			this.BnDeshabilitar.UseVisualStyleBackColor = true;
			this.BnDeshabilitar.Click += new System.EventHandler(this.BnDeshabilitar_Click);
			// 
			// BnBuscar
			// 
			this.BnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnBuscar.Location = new System.Drawing.Point(387, 656);
			this.BnBuscar.Name = "BnBuscar";
			this.BnBuscar.Size = new System.Drawing.Size(110, 35);
			this.BnBuscar.TabIndex = 10;
			this.BnBuscar.Text = "Buscar";
			this.BnBuscar.UseVisualStyleBackColor = true;
			this.BnBuscar.Click += new System.EventHandler(this.BnBuscar_Click);
			// 
			// BnSalir
			// 
			this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnSalir.Location = new System.Drawing.Point(860, 656);
			this.BnSalir.Name = "BnSalir";
			this.BnSalir.Size = new System.Drawing.Size(110, 35);
			this.BnSalir.TabIndex = 11;
			this.BnSalir.Text = "Salir";
			this.BnSalir.UseVisualStyleBackColor = true;
			this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
			// 
			// BnFiltrar
			// 
			this.BnFiltrar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnFiltrar.Location = new System.Drawing.Point(677, 230);
			this.BnFiltrar.Name = "BnFiltrar";
			this.BnFiltrar.Size = new System.Drawing.Size(110, 35);
			this.BnFiltrar.TabIndex = 5;
			this.BnFiltrar.Text = "Filtrar";
			this.BnFiltrar.UseVisualStyleBackColor = true;
			this.BnFiltrar.Click += new System.EventHandler(this.BnFiltrar_Click);
			// 
			// BnConsultaAPI
			// 
			this.BnConsultaAPI.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnConsultaAPI.Location = new System.Drawing.Point(781, 30);
			this.BnConsultaAPI.Name = "BnConsultaAPI";
			this.BnConsultaAPI.Size = new System.Drawing.Size(166, 35);
			this.BnConsultaAPI.TabIndex = 4;
			this.BnConsultaAPI.Text = "Consultar API";
			this.BnConsultaAPI.UseVisualStyleBackColor = true;
			this.BnConsultaAPI.Click += new System.EventHandler(this.BnConsultaAPI_Click);
			// 
			// FrmCliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 703);
			this.Controls.Add(this.BnFiltrar);
			this.Controls.Add(this.BnSalir);
			this.Controls.Add(this.BnBuscar);
			this.Controls.Add(this.BnDeshabilitar);
			this.Controls.Add(this.BnEditar);
			this.Controls.Add(this.BnNuevo);
			this.Controls.Add(this.BnCancelar);
			this.Controls.Add(this.BnGuardar);
			this.Controls.Add(this.LbOpcion);
			this.Controls.Add(this.GbLista);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GbDatos);
			this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmCliente";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Mantenedor - Cliente";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCliente_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCliente_FormClosed);
			this.Load += new System.EventHandler(this.FrmCliente_Load);
			this.GbDatos.ResumeLayout(false);
			this.GbDatos.PerformLayout();
			this.GbLista.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DgvCliente)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbNombres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbApellido2;
        private System.Windows.Forms.TextBox TbApellido1;
        private System.Windows.Forms.TextBox TbNombres;
        private System.Windows.Forms.ComboBox CmbTipoDocumentoIdentidad;
        private System.Windows.Forms.Label LbRazonSocial;
        private System.Windows.Forms.Label LbApellido2;
        private System.Windows.Forms.Label LbApellido1;
        private System.Windows.Forms.TextBox TbRazonSocial;
        private System.Windows.Forms.TextBox TbEmail;
        private System.Windows.Forms.TextBox TbCelular;
        private System.Windows.Forms.Label LbEmail;
        private System.Windows.Forms.Label LbCelular;
        private System.Windows.Forms.GroupBox GbLista;
        private System.Windows.Forms.Label LbOpcion;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnCancelar;
        private System.Windows.Forms.Button BnNuevo;
        private System.Windows.Forms.Button BnEditar;
        private System.Windows.Forms.Button BnDeshabilitar;
        private System.Windows.Forms.Button BnBuscar;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.Button BnFiltrar;
        private System.Windows.Forms.DataGridView DgvCliente;
        private Controls.CustomTextBox TbDocumentoIdentidadNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.Button BnConsultaAPI;
	}
}