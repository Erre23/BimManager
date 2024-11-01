namespace BimManager.Client.WipApp
{
    partial class FrmContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContrato));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.BnCancelar = new System.Windows.Forms.Button();
            this.BnGuardar = new System.Windows.Forms.Button();
            this.BnSalir = new System.Windows.Forms.Button();
            this.BnAnular = new System.Windows.Forms.Button();
            this.BnBuscar = new System.Windows.Forms.Button();
            this.BnNuevo = new System.Windows.Forms.Button();
            this.BnPagos = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TbPlanNombre = new System.Windows.Forms.TextBox();
            this.TbPlanPlazo = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TbPlanPrecio = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.TbMontoTotal = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.GbCategorias = new System.Windows.Forms.GroupBox();
            this.DgvPresupuestoCategoria = new System.Windows.Forms.DataGridView();
            this.colSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntecedentes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TbProyectoNombre = new System.Windows.Forms.TextBox();
            this.TbProyectoPisos = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TbProyectoAreaTechada = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TbProyectoAreaTotal = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TbProyectoDireccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TbCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BnBuscarPresupuesto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TbPresupuestoNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TbMontoPagado = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbMontoFaltante = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TbContratoComentario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TbContratoUsuario = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.DtpFechaEstimadaEntrega = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.TbContratoEstado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TbContratoNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.GbCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPresupuestoCategoria)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbTitulo
            // 
            this.LbTitulo.BackColor = System.Drawing.SystemColors.Highlight;
            this.LbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbTitulo.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulo.ForeColor = System.Drawing.Color.White;
            this.LbTitulo.Location = new System.Drawing.Point(0, 0);
            this.LbTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbTitulo.Name = "LbTitulo";
            this.LbTitulo.Size = new System.Drawing.Size(1020, 34);
            this.LbTitulo.TabIndex = 0;
            this.LbTitulo.Text = "Registro de Contrato";
            this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnCancelar
            // 
            this.BnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnCancelar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BnCancelar.Image")));
            this.BnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnCancelar.Location = new System.Drawing.Point(530, 762);
            this.BnCancelar.Name = "BnCancelar";
            this.BnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnCancelar.Size = new System.Drawing.Size(102, 31);
            this.BnCancelar.TabIndex = 18;
            this.BnCancelar.Text = "Cancelar";
            this.BnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnCancelar.UseVisualStyleBackColor = true;
            this.BnCancelar.Click += new System.EventHandler(this.BnCancelar_Click);
            // 
            // BnGuardar
            // 
            this.BnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BnGuardar.Image")));
            this.BnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnGuardar.Location = new System.Drawing.Point(425, 762);
            this.BnGuardar.Name = "BnGuardar";
            this.BnGuardar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnGuardar.Size = new System.Drawing.Size(102, 31);
            this.BnGuardar.TabIndex = 17;
            this.BnGuardar.Text = "Guardar";
            this.BnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnGuardar.UseVisualStyleBackColor = true;
            this.BnGuardar.Click += new System.EventHandler(this.BnGuardar_Click);
            // 
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = ((System.Drawing.Image)(resources.GetObject("BnSalir.Image")));
            this.BnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSalir.Location = new System.Drawing.Point(912, 762);
            this.BnSalir.Name = "BnSalir";
            this.BnSalir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSalir.Size = new System.Drawing.Size(102, 31);
            this.BnSalir.TabIndex = 19;
            this.BnSalir.Text = "Salir";
            this.BnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSalir.UseVisualStyleBackColor = true;
            this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
            // 
            // BnAnular
            // 
            this.BnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnAnular.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnAnular.Image = ((System.Drawing.Image)(resources.GetObject("BnAnular.Image")));
            this.BnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnAnular.Location = new System.Drawing.Point(215, 762);
            this.BnAnular.Name = "BnAnular";
            this.BnAnular.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnAnular.Size = new System.Drawing.Size(102, 31);
            this.BnAnular.TabIndex = 15;
            this.BnAnular.Text = "Anular";
            this.BnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnAnular.UseVisualStyleBackColor = true;
            this.BnAnular.Click += new System.EventHandler(this.BnAnular_Click);
            // 
            // BnBuscar
            // 
            this.BnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BnBuscar.Image")));
            this.BnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscar.Location = new System.Drawing.Point(110, 762);
            this.BnBuscar.Name = "BnBuscar";
            this.BnBuscar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscar.Size = new System.Drawing.Size(102, 31);
            this.BnBuscar.TabIndex = 14;
            this.BnBuscar.Text = "Buscar";
            this.BnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscar.UseVisualStyleBackColor = true;
            this.BnBuscar.Click += new System.EventHandler(this.BnBuscar_Click);
            // 
            // BnNuevo
            // 
            this.BnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BnNuevo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("BnNuevo.Image")));
            this.BnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnNuevo.Location = new System.Drawing.Point(5, 762);
            this.BnNuevo.Name = "BnNuevo";
            this.BnNuevo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnNuevo.Size = new System.Drawing.Size(102, 31);
            this.BnNuevo.TabIndex = 13;
            this.BnNuevo.Text = "Nuevo";
            this.BnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnNuevo.UseVisualStyleBackColor = true;
            this.BnNuevo.Click += new System.EventHandler(this.BnNuevo_Click);
            // 
            // BnPagos
            // 
            this.BnPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnPagos.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnPagos.Image = global::BimManager.Client.WipApp.Properties.Resources.Pagos;
            this.BnPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnPagos.Location = new System.Drawing.Point(320, 762);
            this.BnPagos.Name = "BnPagos";
            this.BnPagos.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnPagos.Size = new System.Drawing.Size(102, 31);
            this.BnPagos.TabIndex = 16;
            this.BnPagos.Text = "Pagos";
            this.BnPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnPagos.UseVisualStyleBackColor = true;
            this.BnPagos.Click += new System.EventHandler(this.BnPagos_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TbPlanNombre);
            this.groupBox4.Controls.Add(this.TbPlanPlazo);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.TbPlanPrecio);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(698, 245);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(315, 114);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos del Plan";
            // 
            // TbPlanNombre
            // 
            this.TbPlanNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPlanNombre.Location = new System.Drawing.Point(107, 24);
            this.TbPlanNombre.Name = "TbPlanNombre";
            this.TbPlanNombre.ReadOnly = true;
            this.TbPlanNombre.Size = new System.Drawing.Size(202, 28);
            this.TbPlanNombre.TabIndex = 1;
            // 
            // TbPlanPlazo
            // 
            this.TbPlanPlazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPlanPlazo.Location = new System.Drawing.Point(107, 83);
            this.TbPlanPlazo.Name = "TbPlanPlazo";
            this.TbPlanPlazo.ReadOnly = true;
            this.TbPlanPlazo.Size = new System.Drawing.Size(106, 28);
            this.TbPlanPlazo.TabIndex = 5;
            this.TbPlanPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TbPlanPlazo.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.Todo;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 86);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 21);
            this.label16.TabIndex = 4;
            this.label16.Text = "Plazo (días) :";
            // 
            // TbPlanPrecio
            // 
            this.TbPlanPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPlanPrecio.Location = new System.Drawing.Point(107, 53);
            this.TbPlanPrecio.Name = "TbPlanPrecio";
            this.TbPlanPrecio.ReadOnly = true;
            this.TbPlanPrecio.Size = new System.Drawing.Size(106, 28);
            this.TbPlanPrecio.TabIndex = 3;
            this.TbPlanPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 56);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 21);
            this.label18.TabIndex = 2;
            this.label18.Text = "Precio m2 S/ :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(62, 26);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 21);
            this.label19.TabIndex = 0;
            this.label19.Text = "Plan :";
            // 
            // TbMontoTotal
            // 
            this.TbMontoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TbMontoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMontoTotal.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMontoTotal.Location = new System.Drawing.Point(162, 723);
            this.TbMontoTotal.Name = "TbMontoTotal";
            this.TbMontoTotal.ReadOnly = true;
            this.TbMontoTotal.Size = new System.Drawing.Size(155, 35);
            this.TbMontoTotal.TabIndex = 8;
            this.TbMontoTotal.Text = "0.00";
            this.TbMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TbMontoTotal.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 727);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(176, 28);
            this.label14.TabIndex = 7;
            this.label14.Text = "Monto Total S/ :";
            // 
            // GbCategorias
            // 
            this.GbCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbCategorias.Controls.Add(this.DgvPresupuestoCategoria);
            this.GbCategorias.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbCategorias.Location = new System.Drawing.Point(6, 366);
            this.GbCategorias.Name = "GbCategorias";
            this.GbCategorias.Size = new System.Drawing.Size(1008, 351);
            this.GbCategorias.TabIndex = 6;
            this.GbCategorias.TabStop = false;
            this.GbCategorias.Text = "Categorias";
            // 
            // DgvPresupuestoCategoria
            // 
            this.DgvPresupuestoCategoria.AllowUserToAddRows = false;
            this.DgvPresupuestoCategoria.AllowUserToDeleteRows = false;
            this.DgvPresupuestoCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvPresupuestoCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPresupuestoCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionar,
            this.colDescripcion,
            this.colObservaciones,
            this.colAntecedentes,
            this.colImporte});
            this.DgvPresupuestoCategoria.Location = new System.Drawing.Point(6, 23);
            this.DgvPresupuestoCategoria.MultiSelect = false;
            this.DgvPresupuestoCategoria.Name = "DgvPresupuestoCategoria";
            this.DgvPresupuestoCategoria.ReadOnly = true;
            this.DgvPresupuestoCategoria.RowHeadersWidth = 51;
            this.DgvPresupuestoCategoria.RowTemplate.Height = 24;
            this.DgvPresupuestoCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPresupuestoCategoria.Size = new System.Drawing.Size(996, 320);
            this.DgvPresupuestoCategoria.TabIndex = 0;
            // 
            // colSeleccionar
            // 
            this.colSeleccionar.HeaderText = "Seleccionar";
            this.colSeleccionar.MinimumWidth = 6;
            this.colSeleccionar.Name = "colSeleccionar";
            this.colSeleccionar.ReadOnly = true;
            this.colSeleccionar.Width = 125;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.MinimumWidth = 6;
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDescripcion.Width = 300;
            // 
            // colObservaciones
            // 
            this.colObservaciones.HeaderText = "Observacion";
            this.colObservaciones.MinimumWidth = 6;
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = true;
            this.colObservaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colObservaciones.Width = 300;
            // 
            // colAntecedentes
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAntecedentes.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAntecedentes.HeaderText = "Antecedentes";
            this.colAntecedentes.MinimumWidth = 6;
            this.colAntecedentes.Name = "colAntecedentes";
            this.colAntecedentes.ReadOnly = true;
            this.colAntecedentes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAntecedentes.Width = 125;
            // 
            // colImporte
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.colImporte.HeaderText = "Importe S/";
            this.colImporte.MinimumWidth = 6;
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            this.colImporte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colImporte.Width = 125;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TbProyectoNombre);
            this.groupBox3.Controls.Add(this.TbProyectoPisos);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.TbProyectoAreaTechada);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.TbProyectoAreaTotal);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.TbProyectoDireccion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 245);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(684, 114);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Proyecto";
            // 
            // TbProyectoNombre
            // 
            this.TbProyectoNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProyectoNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoNombre.Location = new System.Drawing.Point(128, 24);
            this.TbProyectoNombre.Name = "TbProyectoNombre";
            this.TbProyectoNombre.ReadOnly = true;
            this.TbProyectoNombre.Size = new System.Drawing.Size(548, 28);
            this.TbProyectoNombre.TabIndex = 1;
            // 
            // TbProyectoPisos
            // 
            this.TbProyectoPisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoPisos.Location = new System.Drawing.Point(576, 82);
            this.TbProyectoPisos.Name = "TbProyectoPisos";
            this.TbProyectoPisos.ReadOnly = true;
            this.TbProyectoPisos.Size = new System.Drawing.Size(100, 28);
            this.TbProyectoPisos.TabIndex = 9;
            this.TbProyectoPisos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbProyectoPisos.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(501, 85);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 21);
            this.label13.TabIndex = 8;
            this.label13.Text = "Nº Pisos :";
            // 
            // TbProyectoAreaTechada
            // 
            this.TbProyectoAreaTechada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoAreaTechada.Location = new System.Drawing.Point(376, 82);
            this.TbProyectoAreaTechada.Name = "TbProyectoAreaTechada";
            this.TbProyectoAreaTechada.ReadOnly = true;
            this.TbProyectoAreaTechada.Size = new System.Drawing.Size(100, 28);
            this.TbProyectoAreaTechada.TabIndex = 7;
            this.TbProyectoAreaTechada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbProyectoAreaTechada.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.Todo;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(237, 85);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 21);
            this.label12.TabIndex = 6;
            this.label12.Text = "Área Techada (m2) :";
            // 
            // TbProyectoAreaTotal
            // 
            this.TbProyectoAreaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoAreaTotal.Location = new System.Drawing.Point(128, 82);
            this.TbProyectoAreaTotal.Name = "TbProyectoAreaTotal";
            this.TbProyectoAreaTotal.ReadOnly = true;
            this.TbProyectoAreaTotal.Size = new System.Drawing.Size(100, 28);
            this.TbProyectoAreaTotal.TabIndex = 5;
            this.TbProyectoAreaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbProyectoAreaTotal.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 85);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 21);
            this.label11.TabIndex = 4;
            this.label11.Text = "Área Total (m2) :";
            // 
            // TbProyectoDireccion
            // 
            this.TbProyectoDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProyectoDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoDireccion.Location = new System.Drawing.Point(128, 53);
            this.TbProyectoDireccion.Name = "TbProyectoDireccion";
            this.TbProyectoDireccion.ReadOnly = true;
            this.TbProyectoDireccion.Size = new System.Drawing.Size(548, 28);
            this.TbProyectoDireccion.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Dirección :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nombre :";
            // 
            // TbCliente
            // 
            this.TbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCliente.Location = new System.Drawing.Point(128, 50);
            this.TbCliente.Name = "TbCliente";
            this.TbCliente.ReadOnly = true;
            this.TbCliente.Size = new System.Drawing.Size(873, 28);
            this.TbCliente.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Cliente :";
            // 
            // BnBuscarPresupuesto
            // 
            this.BnBuscarPresupuesto.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscarPresupuesto.Image = ((System.Drawing.Image)(resources.GetObject("BnBuscarPresupuesto.Image")));
            this.BnBuscarPresupuesto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscarPresupuesto.Location = new System.Drawing.Point(306, 18);
            this.BnBuscarPresupuesto.Name = "BnBuscarPresupuesto";
            this.BnBuscarPresupuesto.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscarPresupuesto.Size = new System.Drawing.Size(94, 29);
            this.BnBuscarPresupuesto.TabIndex = 2;
            this.BnBuscarPresupuesto.Text = "Buscar";
            this.BnBuscarPresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscarPresupuesto.UseVisualStyleBackColor = true;
            this.BnBuscarPresupuesto.Click += new System.EventHandler(this.BnBuscarPresupuesto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbPresupuestoNumero);
            this.groupBox1.Controls.Add(this.BnBuscarPresupuesto);
            this.groupBox1.Controls.Add(this.TbCliente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 159);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1008, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Presupuesto";
            // 
            // TbPresupuestoNumero
            // 
            this.TbPresupuestoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPresupuestoNumero.Location = new System.Drawing.Point(128, 21);
            this.TbPresupuestoNumero.Name = "TbPresupuestoNumero";
            this.TbPresupuestoNumero.ReadOnly = true;
            this.TbPresupuestoNumero.Size = new System.Drawing.Size(172, 28);
            this.TbPresupuestoNumero.TabIndex = 1;
            this.TbPresupuestoNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° Presupuesto :";
            // 
            // TbMontoPagado
            // 
            this.TbMontoPagado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TbMontoPagado.BackColor = System.Drawing.SystemColors.Control;
            this.TbMontoPagado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMontoPagado.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMontoPagado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TbMontoPagado.Location = new System.Drawing.Point(503, 723);
            this.TbMontoPagado.Name = "TbMontoPagado";
            this.TbMontoPagado.ReadOnly = true;
            this.TbMontoPagado.Size = new System.Drawing.Size(155, 35);
            this.TbMontoPagado.TabIndex = 10;
            this.TbMontoPagado.Text = "0.00";
            this.TbMontoPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TbMontoPagado.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 727);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Monto Pagado S/ :";
            // 
            // TbMontoFaltante
            // 
            this.TbMontoFaltante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TbMontoFaltante.BackColor = System.Drawing.SystemColors.Control;
            this.TbMontoFaltante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMontoFaltante.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMontoFaltante.ForeColor = System.Drawing.Color.Red;
            this.TbMontoFaltante.Location = new System.Drawing.Point(859, 723);
            this.TbMontoFaltante.Name = "TbMontoFaltante";
            this.TbMontoFaltante.ReadOnly = true;
            this.TbMontoFaltante.Size = new System.Drawing.Size(155, 35);
            this.TbMontoFaltante.TabIndex = 12;
            this.TbMontoFaltante.Text = "0.00";
            this.TbMontoFaltante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TbMontoFaltante.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(684, 727);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Monto Faltante S/ :";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TbContratoComentario);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.TbContratoUsuario);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.DtpFechaEstimadaEntrega);
            this.groupBox5.Controls.Add(this.DtpFechaInicio);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.TbContratoEstado);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.TbContratoNumero);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(6, 38);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(1008, 113);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos del Contrato";
            // 
            // TbContratoComentario
            // 
            this.TbContratoComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbContratoComentario.Location = new System.Drawing.Point(401, 83);
            this.TbContratoComentario.Name = "TbContratoComentario";
            this.TbContratoComentario.ReadOnly = true;
            this.TbContratoComentario.Size = new System.Drawing.Size(600, 28);
            this.TbContratoComentario.TabIndex = 11;
            this.TbContratoComentario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 86);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 21);
            this.label9.TabIndex = 10;
            this.label9.Text = "Comentario :";
            // 
            // TbContratoUsuario
            // 
            this.TbContratoUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbContratoUsuario.Location = new System.Drawing.Point(401, 52);
            this.TbContratoUsuario.Name = "TbContratoUsuario";
            this.TbContratoUsuario.ReadOnly = true;
            this.TbContratoUsuario.Size = new System.Drawing.Size(600, 28);
            this.TbContratoUsuario.TabIndex = 9;
            this.TbContratoUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(336, 55);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 21);
            this.label20.TabIndex = 8;
            this.label20.Text = "Usuario :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 85);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(149, 21);
            this.label15.TabIndex = 6;
            this.label15.Text = "Fec. Est. Entrega :";
            // 
            // DtpFechaEstimadaEntrega
            // 
            this.DtpFechaEstimadaEntrega.CustomFormat = "dddd dd/MM/yyyy";
            this.DtpFechaEstimadaEntrega.Enabled = false;
            this.DtpFechaEstimadaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaEstimadaEntrega.Location = new System.Drawing.Point(127, 82);
            this.DtpFechaEstimadaEntrega.Name = "DtpFechaEstimadaEntrega";
            this.DtpFechaEstimadaEntrega.Size = new System.Drawing.Size(177, 28);
            this.DtpFechaEstimadaEntrega.TabIndex = 7;
            // 
            // DtpFechaInicio
            // 
            this.DtpFechaInicio.CustomFormat = "dddd dd/MM/yyyy";
            this.DtpFechaInicio.Enabled = false;
            this.DtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaInicio.Location = new System.Drawing.Point(127, 52);
            this.DtpFechaInicio.Name = "DtpFechaInicio";
            this.DtpFechaInicio.Size = new System.Drawing.Size(177, 28);
            this.DtpFechaInicio.TabIndex = 5;
            this.DtpFechaInicio.Value = new System.DateTime(2024, 10, 27, 0, 0, 0, 0);
            this.DtpFechaInicio.ValueChanged += new System.EventHandler(this.DtpFechaInicio_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 55);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 21);
            this.label17.TabIndex = 4;
            this.label17.Text = "Fecha de Inicio :";
            // 
            // TbContratoEstado
            // 
            this.TbContratoEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbContratoEstado.Location = new System.Drawing.Point(401, 22);
            this.TbContratoEstado.Name = "TbContratoEstado";
            this.TbContratoEstado.ReadOnly = true;
            this.TbContratoEstado.Size = new System.Drawing.Size(177, 28);
            this.TbContratoEstado.TabIndex = 3;
            this.TbContratoEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Estado :";
            // 
            // TbContratoNumero
            // 
            this.TbContratoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbContratoNumero.Location = new System.Drawing.Point(127, 22);
            this.TbContratoNumero.Name = "TbContratoNumero";
            this.TbContratoNumero.ReadOnly = true;
            this.TbContratoNumero.Size = new System.Drawing.Size(177, 28);
            this.TbContratoNumero.TabIndex = 1;
            this.TbContratoNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "N° Contrato :";
            // 
            // FrmContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 800);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.TbMontoFaltante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TbMontoPagado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.TbMontoTotal);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.GbCategorias);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BnPagos);
            this.Controls.Add(this.BnCancelar);
            this.Controls.Add(this.BnGuardar);
            this.Controls.Add(this.BnSalir);
            this.Controls.Add(this.BnAnular);
            this.Controls.Add(this.BnBuscar);
            this.Controls.Add(this.BnNuevo);
            this.Controls.Add(this.LbTitulo);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmContrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Registro de Contrato";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmContrato_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmContrato_FormClosed);
            this.Load += new System.EventHandler(this.FrmContrato_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GbCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPresupuestoCategoria)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.Button BnCancelar;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.Button BnAnular;
        private System.Windows.Forms.Button BnBuscar;
        private System.Windows.Forms.Button BnNuevo;
        private System.Windows.Forms.Button BnPagos;
        private System.Windows.Forms.GroupBox groupBox4;
        private Controls.CustomTextBox TbPlanPlazo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TbPlanPrecio;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private Controls.CustomTextBox TbMontoTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox GbCategorias;
        private System.Windows.Forms.DataGridView DgvPresupuestoCategoria;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntecedentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.CustomTextBox TbProyectoPisos;
        private System.Windows.Forms.Label label13;
        private Controls.CustomTextBox TbProyectoAreaTechada;
        private System.Windows.Forms.Label label12;
        private Controls.CustomTextBox TbProyectoAreaTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TbProyectoDireccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BnBuscarPresupuesto;
        private System.Windows.Forms.TextBox TbCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TbPresupuestoNumero;
        private System.Windows.Forms.Label label1;
        private Controls.CustomTextBox TbMontoPagado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbProyectoNombre;
        private Controls.CustomTextBox TbMontoFaltante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbPlanNombre;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TbContratoNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbContratoEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker DtpFechaEstimadaEntrega;
        private System.Windows.Forms.DateTimePicker DtpFechaInicio;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TbContratoUsuario;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TbContratoComentario;
        private System.Windows.Forms.Label label9;
    }
}