namespace CapaPresentacion
{
    partial class FrmProyecto
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
            this.GbDatos_Proyecto = new System.Windows.Forms.GroupBox();
            this.CbDistrito = new System.Windows.Forms.ComboBox();
            this.CbProvincia = new System.Windows.Forms.ComboBox();
            this.CbDepartamento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbDireccionReferencia = new System.Windows.Forms.TextBox();
            this.TbDireccion = new System.Windows.Forms.TextBox();
            this.TbNombre = new System.Windows.Forms.TextBox();
            this.LbApellido2 = new System.Windows.Forms.Label();
            this.LbApellido1 = new System.Windows.Forms.Label();
            this.LbNombres = new System.Windows.Forms.Label();
            this.TbDocumentoIdentidadNumero = new CapaPresentacion.Controls.CustomTextBox();
            this.CmbTipoDocumentoIdentidad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GbLista = new System.Windows.Forms.GroupBox();
            this.DgvProyecto = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.GbDatos_Cliente = new System.Windows.Forms.GroupBox();
            this.BnBuscarCliente = new System.Windows.Forms.Button();
            this.TbCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GbDatos_Proyecto.SuspendLayout();
            this.GbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProyecto)).BeginInit();
            this.GbDatos_Cliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbDatos_Proyecto
            // 
            this.GbDatos_Proyecto.Controls.Add(this.CbDistrito);
            this.GbDatos_Proyecto.Controls.Add(this.CbProvincia);
            this.GbDatos_Proyecto.Controls.Add(this.CbDepartamento);
            this.GbDatos_Proyecto.Controls.Add(this.label6);
            this.GbDatos_Proyecto.Controls.Add(this.label5);
            this.GbDatos_Proyecto.Controls.Add(this.label4);
            this.GbDatos_Proyecto.Controls.Add(this.TbDireccionReferencia);
            this.GbDatos_Proyecto.Controls.Add(this.TbDireccion);
            this.GbDatos_Proyecto.Controls.Add(this.TbNombre);
            this.GbDatos_Proyecto.Controls.Add(this.LbApellido2);
            this.GbDatos_Proyecto.Controls.Add(this.LbApellido1);
            this.GbDatos_Proyecto.Controls.Add(this.LbNombres);
            this.GbDatos_Proyecto.Location = new System.Drawing.Point(12, 149);
            this.GbDatos_Proyecto.Name = "GbDatos_Proyecto";
            this.GbDatos_Proyecto.Size = new System.Drawing.Size(947, 177);
            this.GbDatos_Proyecto.TabIndex = 1;
            this.GbDatos_Proyecto.TabStop = false;
            this.GbDatos_Proyecto.Text = "Datos del Proyecto";
            // 
            // CbDistrito
            // 
            this.CbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDistrito.FormattingEnabled = true;
            this.CbDistrito.Location = new System.Drawing.Point(742, 131);
            this.CbDistrito.Name = "CbDistrito";
            this.CbDistrito.Size = new System.Drawing.Size(199, 29);
            this.CbDistrito.TabIndex = 17;
            // 
            // CbProvincia
            // 
            this.CbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProvincia.FormattingEnabled = true;
            this.CbProvincia.Location = new System.Drawing.Point(448, 131);
            this.CbProvincia.Name = "CbProvincia";
            this.CbProvincia.Size = new System.Drawing.Size(199, 29);
            this.CbProvincia.TabIndex = 16;
            this.CbProvincia.SelectedIndexChanged += new System.EventHandler(this.CbProvincia_SelectedIndexChanged);
            // 
            // CbDepartamento
            // 
            this.CbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDepartamento.FormattingEnabled = true;
            this.CbDepartamento.Location = new System.Drawing.Point(152, 131);
            this.CbDepartamento.Name = "CbDepartamento";
            this.CbDepartamento.Size = new System.Drawing.Size(199, 29);
            this.CbDepartamento.TabIndex = 15;
            this.CbDepartamento.SelectedIndexChanged += new System.EventHandler(this.CbDepartamento_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(663, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "Distrito :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Provincia :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Departamento :";
            // 
            // TbDireccionReferencia
            // 
            this.TbDireccionReferencia.Location = new System.Drawing.Point(153, 95);
            this.TbDireccionReferencia.MaxLength = 50;
            this.TbDireccionReferencia.Name = "TbDireccionReferencia";
            this.TbDireccionReferencia.Size = new System.Drawing.Size(788, 28);
            this.TbDireccionReferencia.TabIndex = 11;
            // 
            // TbDireccion
            // 
            this.TbDireccion.Location = new System.Drawing.Point(153, 61);
            this.TbDireccion.MaxLength = 50;
            this.TbDireccion.Name = "TbDireccion";
            this.TbDireccion.Size = new System.Drawing.Size(788, 28);
            this.TbDireccion.TabIndex = 9;
            // 
            // TbNombre
            // 
            this.TbNombre.Location = new System.Drawing.Point(153, 25);
            this.TbNombre.MaxLength = 100;
            this.TbNombre.Name = "TbNombre";
            this.TbNombre.Size = new System.Drawing.Size(788, 28);
            this.TbNombre.TabIndex = 7;
            // 
            // LbApellido2
            // 
            this.LbApellido2.AutoSize = true;
            this.LbApellido2.Location = new System.Drawing.Point(14, 96);
            this.LbApellido2.Name = "LbApellido2";
            this.LbApellido2.Size = new System.Drawing.Size(132, 21);
            this.LbApellido2.TabIndex = 10;
            this.LbApellido2.Text = "Dir. Referencia :";
            // 
            // LbApellido1
            // 
            this.LbApellido1.AutoSize = true;
            this.LbApellido1.Location = new System.Drawing.Point(56, 64);
            this.LbApellido1.Name = "LbApellido1";
            this.LbApellido1.Size = new System.Drawing.Size(90, 21);
            this.LbApellido1.TabIndex = 8;
            this.LbApellido1.Text = "Dirección :";
            // 
            // LbNombres
            // 
            this.LbNombres.AutoSize = true;
            this.LbNombres.Location = new System.Drawing.Point(67, 28);
            this.LbNombres.Name = "LbNombres";
            this.LbNombres.Size = new System.Drawing.Size(79, 21);
            this.LbNombres.TabIndex = 6;
            this.LbNombres.Text = "Nombre :";
            // 
            // TbDocumentoIdentidadNumero
            // 
            this.TbDocumentoIdentidadNumero.Location = new System.Drawing.Point(546, 27);
            this.TbDocumentoIdentidadNumero.Name = "TbDocumentoIdentidadNumero";
            this.TbDocumentoIdentidadNumero.Size = new System.Drawing.Size(228, 28);
            this.TbDocumentoIdentidadNumero.TabIndex = 3;
            this.TbDocumentoIdentidadNumero.TipoCaracteres = CapaPresentacion.Controls.CustomTextBox.TipoInput.Todo;
            // 
            // CmbTipoDocumentoIdentidad
            // 
            this.CmbTipoDocumentoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoDocumentoIdentidad.FormattingEnabled = true;
            this.CmbTipoDocumentoIdentidad.Location = new System.Drawing.Point(152, 26);
            this.CmbTipoDocumentoIdentidad.Name = "CmbTipoDocumentoIdentidad";
            this.CmbTipoDocumentoIdentidad.Size = new System.Drawing.Size(228, 29);
            this.CmbTipoDocumentoIdentidad.TabIndex = 1;
            this.CmbTipoDocumentoIdentidad.SelectedIndexChanged += new System.EventHandler(this.CmbTipoDocumentoIdentidad_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nº Documento :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo Doc. Ident. :";
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
            this.label1.Text = "Mantenedor - Proyecto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GbLista
            // 
            this.GbLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbLista.Controls.Add(this.DgvProyecto);
            this.GbLista.Location = new System.Drawing.Point(12, 366);
            this.GbLista.Name = "GbLista";
            this.GbLista.Size = new System.Drawing.Size(958, 282);
            this.GbLista.TabIndex = 6;
            this.GbLista.TabStop = false;
            this.GbLista.Text = "Lista de Proyectos";
            // 
            // DgvProyecto
            // 
            this.DgvProyecto.AllowUserToAddRows = false;
            this.DgvProyecto.AllowUserToDeleteRows = false;
            this.DgvProyecto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProyecto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column6});
            this.DgvProyecto.Location = new System.Drawing.Point(12, 25);
            this.DgvProyecto.MultiSelect = false;
            this.DgvProyecto.Name = "DgvProyecto";
            this.DgvProyecto.ReadOnly = true;
            this.DgvProyecto.RowHeadersWidth = 51;
            this.DgvProyecto.RowTemplate.Height = 24;
            this.DgvProyecto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProyecto.Size = new System.Drawing.Size(935, 243);
            this.DgvProyecto.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 170;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Dirección";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Dir. Referencia";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Distrito";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Provincia";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Departamento";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Cliente";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 125;
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
            this.LbOpcion.Location = new System.Drawing.Point(12, 334);
            this.LbOpcion.Name = "LbOpcion";
            this.LbOpcion.Size = new System.Drawing.Size(381, 30);
            this.LbOpcion.TabIndex = 2;
            this.LbOpcion.Text = "OPCIÓN : NUEVO / EDITAR / BUSCAR";
            this.LbOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnGuardar
            // 
            this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnGuardar.Image = global::CapaPresentacion.Properties.Resources.Guardar;
            this.BnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnGuardar.Location = new System.Drawing.Point(724, 332);
            this.BnGuardar.Name = "BnGuardar";
            this.BnGuardar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnGuardar.Size = new System.Drawing.Size(110, 35);
            this.BnGuardar.TabIndex = 3;
            this.BnGuardar.Text = "Guardar";
            this.BnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnGuardar.UseVisualStyleBackColor = true;
            this.BnGuardar.Click += new System.EventHandler(this.BnGuardar_Click);
            // 
            // BnCancelar
            // 
            this.BnCancelar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnCancelar.Image = global::CapaPresentacion.Properties.Resources.Cancelar;
            this.BnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnCancelar.Location = new System.Drawing.Point(843, 332);
            this.BnCancelar.Name = "BnCancelar";
            this.BnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnCancelar.Size = new System.Drawing.Size(110, 35);
            this.BnCancelar.TabIndex = 4;
            this.BnCancelar.Text = "Cancelar";
            this.BnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnCancelar.UseVisualStyleBackColor = true;
            this.BnCancelar.Click += new System.EventHandler(this.BnCancelar_Click);
            // 
            // BnNuevo
            // 
            this.BnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnNuevo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnNuevo.Image = global::CapaPresentacion.Properties.Resources.Nuevo;
            this.BnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnNuevo.Location = new System.Drawing.Point(12, 656);
            this.BnNuevo.Name = "BnNuevo";
            this.BnNuevo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnNuevo.Size = new System.Drawing.Size(110, 35);
            this.BnNuevo.TabIndex = 7;
            this.BnNuevo.Text = "Nuevo";
            this.BnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnNuevo.UseVisualStyleBackColor = true;
            this.BnNuevo.Click += new System.EventHandler(this.BnNuevo_Click);
            // 
            // BnEditar
            // 
            this.BnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnEditar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnEditar.Image = global::CapaPresentacion.Properties.Resources.Editar;
            this.BnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnEditar.Location = new System.Drawing.Point(128, 656);
            this.BnEditar.Name = "BnEditar";
            this.BnEditar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnEditar.Size = new System.Drawing.Size(110, 35);
            this.BnEditar.TabIndex = 8;
            this.BnEditar.Text = "Editar";
            this.BnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnEditar.UseVisualStyleBackColor = true;
            this.BnEditar.Click += new System.EventHandler(this.BnEditar_Click);
            // 
            // BnDeshabilitar
            // 
            this.BnDeshabilitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnDeshabilitar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnDeshabilitar.Image = global::CapaPresentacion.Properties.Resources.Anular;
            this.BnDeshabilitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnDeshabilitar.Location = new System.Drawing.Point(244, 656);
            this.BnDeshabilitar.Name = "BnDeshabilitar";
            this.BnDeshabilitar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnDeshabilitar.Size = new System.Drawing.Size(137, 35);
            this.BnDeshabilitar.TabIndex = 9;
            this.BnDeshabilitar.Text = "Deshabilitar";
            this.BnDeshabilitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnDeshabilitar.UseVisualStyleBackColor = true;
            this.BnDeshabilitar.Click += new System.EventHandler(this.BnDeshabilitar_Click);
            // 
            // BnBuscar
            // 
            this.BnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscar.Image = global::CapaPresentacion.Properties.Resources.Buscar;
            this.BnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscar.Location = new System.Drawing.Point(387, 656);
            this.BnBuscar.Name = "BnBuscar";
            this.BnBuscar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscar.Size = new System.Drawing.Size(110, 35);
            this.BnBuscar.TabIndex = 10;
            this.BnBuscar.Text = "Buscar";
            this.BnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscar.UseVisualStyleBackColor = true;
            this.BnBuscar.Click += new System.EventHandler(this.BnBuscar_Click);
            // 
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = global::CapaPresentacion.Properties.Resources.Cerrar;
            this.BnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSalir.Location = new System.Drawing.Point(860, 656);
            this.BnSalir.Name = "BnSalir";
            this.BnSalir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSalir.Size = new System.Drawing.Size(110, 35);
            this.BnSalir.TabIndex = 11;
            this.BnSalir.Text = "Salir";
            this.BnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSalir.UseVisualStyleBackColor = true;
            this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
            // 
            // BnFiltrar
            // 
            this.BnFiltrar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnFiltrar.Image = global::CapaPresentacion.Properties.Resources.Filtrar;
            this.BnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnFiltrar.Location = new System.Drawing.Point(843, 332);
            this.BnFiltrar.Name = "BnFiltrar";
            this.BnFiltrar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnFiltrar.Size = new System.Drawing.Size(110, 35);
            this.BnFiltrar.TabIndex = 5;
            this.BnFiltrar.Text = "Filtrar";
            this.BnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnFiltrar.UseVisualStyleBackColor = true;
            this.BnFiltrar.Click += new System.EventHandler(this.BnFiltrar_Click);
            // 
            // GbDatos_Cliente
            // 
            this.GbDatos_Cliente.Controls.Add(this.BnBuscarCliente);
            this.GbDatos_Cliente.Controls.Add(this.TbDocumentoIdentidadNumero);
            this.GbDatos_Cliente.Controls.Add(this.TbCliente);
            this.GbDatos_Cliente.Controls.Add(this.label11);
            this.GbDatos_Cliente.Controls.Add(this.label2);
            this.GbDatos_Cliente.Controls.Add(this.CmbTipoDocumentoIdentidad);
            this.GbDatos_Cliente.Controls.Add(this.label3);
            this.GbDatos_Cliente.Location = new System.Drawing.Point(12, 35);
            this.GbDatos_Cliente.Name = "GbDatos_Cliente";
            this.GbDatos_Cliente.Size = new System.Drawing.Size(947, 103);
            this.GbDatos_Cliente.TabIndex = 12;
            this.GbDatos_Cliente.TabStop = false;
            this.GbDatos_Cliente.Text = "Datos del Cliente";
            // 
            // BnBuscarCliente
            // 
            this.BnBuscarCliente.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscarCliente.Image = global::CapaPresentacion.Properties.Resources.Buscar;
            this.BnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscarCliente.Location = new System.Drawing.Point(780, 22);
            this.BnBuscarCliente.Name = "BnBuscarCliente";
            this.BnBuscarCliente.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscarCliente.Size = new System.Drawing.Size(161, 35);
            this.BnBuscarCliente.TabIndex = 6;
            this.BnBuscarCliente.Text = "Buscar Cliente";
            this.BnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscarCliente.UseVisualStyleBackColor = true;
            this.BnBuscarCliente.Click += new System.EventHandler(this.BnBuscarCliente_Click);
            // 
            // TbCliente
            // 
            this.TbCliente.Location = new System.Drawing.Point(153, 65);
            this.TbCliente.MaxLength = 250;
            this.TbCliente.Name = "TbCliente";
            this.TbCliente.Size = new System.Drawing.Size(788, 28);
            this.TbCliente.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(74, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 21);
            this.label11.TabIndex = 4;
            this.label11.Text = "Cliente :";
            // 
            // FrmProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.GbDatos_Cliente);
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
            this.Controls.Add(this.GbDatos_Proyecto);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mantenedor - Proyecto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProyecto_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCliente_FormClosed);
            this.Load += new System.EventHandler(this.FrmProyecto_Load);
            this.GbDatos_Proyecto.ResumeLayout(false);
            this.GbDatos_Proyecto.PerformLayout();
            this.GbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProyecto)).EndInit();
            this.GbDatos_Cliente.ResumeLayout(false);
            this.GbDatos_Cliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbDatos_Proyecto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbNombres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbDireccionReferencia;
        private System.Windows.Forms.TextBox TbDireccion;
        private System.Windows.Forms.TextBox TbNombre;
        private System.Windows.Forms.ComboBox CmbTipoDocumentoIdentidad;
        private System.Windows.Forms.Label LbApellido2;
        private System.Windows.Forms.Label LbApellido1;
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
        private System.Windows.Forms.DataGridView DgvProyecto;
        private Controls.CustomTextBox TbDocumentoIdentidadNumero;
		private System.Windows.Forms.GroupBox GbDatos_Cliente;
		private System.Windows.Forms.TextBox TbCliente;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox CbDistrito;
		private System.Windows.Forms.ComboBox CbProvincia;
		private System.Windows.Forms.ComboBox CbDepartamento;
		private System.Windows.Forms.Button BnBuscarCliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
	}
}