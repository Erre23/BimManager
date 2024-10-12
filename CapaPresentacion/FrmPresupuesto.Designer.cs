namespace CapaPresentacion
{
    partial class FrmPresupuesto
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
			this.LbTitulo = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.TbCreadoPor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.DtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			this.DtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.TbEstado = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TbNumeroPresupuesto = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.TbNumeroDocumento = new CapaPresentacion.Controls.CustomTextBox();
			this.BnBuscarCliente = new System.Windows.Forms.Button();
			this.CbTipoDocumentoIdentidad = new System.Windows.Forms.ComboBox();
			this.TbCliente = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.CbProyectoNombre = new System.Windows.Forms.ComboBox();
			this.TbProyectoArea = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.BnAgregarProyecto = new System.Windows.Forms.Button();
			this.TbProyectoDireccion = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.GbCategorias = new System.Windows.Forms.GroupBox();
			this.BnNuevo = new System.Windows.Forms.Button();
			this.BnBuscar = new System.Windows.Forms.Button();
			this.BnAnular = new System.Windows.Forms.Button();
			this.BnSalir = new System.Windows.Forms.Button();
			this.BnGuardar = new System.Windows.Forms.Button();
			this.BnCancelar = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
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
			this.LbTitulo.Size = new System.Drawing.Size(928, 37);
			this.LbTitulo.TabIndex = 0;
			this.LbTitulo.Text = "Registro de Presupuesto";
			this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.TbCreadoPor);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.DtpFechaHasta);
			this.groupBox1.Controls.Add(this.DtpFechaDesde);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.TbEstado);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.TbNumeroPresupuesto);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(9, 41);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(707, 137);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos del Presupuesto";
			// 
			// TbCreadoPor
			// 
			this.TbCreadoPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbCreadoPor.Location = new System.Drawing.Point(139, 98);
			this.TbCreadoPor.Name = "TbCreadoPor";
			this.TbCreadoPor.ReadOnly = true;
			this.TbCreadoPor.Size = new System.Drawing.Size(556, 30);
			this.TbCreadoPor.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(46, 101);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(115, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Creado Por :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(448, 66);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Al :";
			// 
			// DtpFechaHasta
			// 
			this.DtpFechaHasta.CustomFormat = "dddd dd/MM/yyyy";
			this.DtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.DtpFechaHasta.Location = new System.Drawing.Point(480, 63);
			this.DtpFechaHasta.Name = "DtpFechaHasta";
			this.DtpFechaHasta.Size = new System.Drawing.Size(215, 30);
			this.DtpFechaHasta.TabIndex = 7;
			// 
			// DtpFechaDesde
			// 
			this.DtpFechaDesde.CustomFormat = "dddd dd/MM/yyyy";
			this.DtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.DtpFechaDesde.Location = new System.Drawing.Point(139, 63);
			this.DtpFechaDesde.Name = "DtpFechaDesde";
			this.DtpFechaDesde.Size = new System.Drawing.Size(215, 30);
			this.DtpFechaDesde.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 66);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(151, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Vigencia Desde :";
			// 
			// TbEstado
			// 
			this.TbEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbEstado.Location = new System.Drawing.Point(480, 25);
			this.TbEstado.Name = "TbEstado";
			this.TbEstado.ReadOnly = true;
			this.TbEstado.Size = new System.Drawing.Size(215, 30);
			this.TbEstado.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(415, 28);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Estado :";
			// 
			// TbNumeroPresupuesto
			// 
			this.TbNumeroPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbNumeroPresupuesto.Location = new System.Drawing.Point(139, 25);
			this.TbNumeroPresupuesto.Name = "TbNumeroPresupuesto";
			this.TbNumeroPresupuesto.ReadOnly = true;
			this.TbNumeroPresupuesto.Size = new System.Drawing.Size(215, 30);
			this.TbNumeroPresupuesto.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 28);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "N° Presupuesto :";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.TbNumeroDocumento);
			this.groupBox2.Controls.Add(this.BnBuscarCliente);
			this.groupBox2.Controls.Add(this.CbTipoDocumentoIdentidad);
			this.groupBox2.Controls.Add(this.TbCliente);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(9, 183);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(826, 98);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Datos del Cliente";
			// 
			// TbNumeroDocumento
			// 
			this.TbNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbNumeroDocumento.Location = new System.Drawing.Point(480, 25);
			this.TbNumeroDocumento.Name = "TbNumeroDocumento";
			this.TbNumeroDocumento.Size = new System.Drawing.Size(215, 30);
			this.TbNumeroDocumento.TabIndex = 3;
			this.TbNumeroDocumento.TipoCaracteres = CapaPresentacion.Controls.CustomTextBox.TipoInput.Todo;
			this.TbNumeroDocumento.TextChanged += new System.EventHandler(this.TbNumeroDocumento_TextChanged);
			// 
			// BnBuscarCliente
			// 
			this.BnBuscarCliente.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnBuscarCliente.Location = new System.Drawing.Point(701, 24);
			this.BnBuscarCliente.Name = "BnBuscarCliente";
			this.BnBuscarCliente.Size = new System.Drawing.Size(117, 28);
			this.BnBuscarCliente.TabIndex = 4;
			this.BnBuscarCliente.Text = "Buscar";
			this.BnBuscarCliente.UseVisualStyleBackColor = true;
			this.BnBuscarCliente.Click += new System.EventHandler(this.BnBuscarCliente_Click);
			// 
			// CbTipoDocumentoIdentidad
			// 
			this.CbTipoDocumentoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbTipoDocumentoIdentidad.FormattingEnabled = true;
			this.CbTipoDocumentoIdentidad.Location = new System.Drawing.Point(139, 25);
			this.CbTipoDocumentoIdentidad.Name = "CbTipoDocumentoIdentidad";
			this.CbTipoDocumentoIdentidad.Size = new System.Drawing.Size(215, 31);
			this.CbTipoDocumentoIdentidad.TabIndex = 1;
			this.CbTipoDocumentoIdentidad.SelectedIndexChanged += new System.EventHandler(this.CbTipoDocumentoIdentidad_SelectedIndexChanged);
			// 
			// TbCliente
			// 
			this.TbCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbCliente.Location = new System.Drawing.Point(139, 60);
			this.TbCliente.Name = "TbCliente";
			this.TbCliente.ReadOnly = true;
			this.TbCliente.Size = new System.Drawing.Size(679, 30);
			this.TbCliente.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(76, 63);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "Cliente :";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(407, 28);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(89, 23);
			this.label9.TabIndex = 2;
			this.label9.Text = "N° Doc. :";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(55, 28);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(103, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "Tipo Doc. :";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.CbProyectoNombre);
			this.groupBox3.Controls.Add(this.TbProyectoArea);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.BnAgregarProyecto);
			this.groupBox3.Controls.Add(this.TbProyectoDireccion);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(9, 285);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox3.Size = new System.Drawing.Size(826, 130);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Datos del Proyecto";
			// 
			// CbProyectoNombre
			// 
			this.CbProyectoNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbProyectoNombre.FormattingEnabled = true;
			this.CbProyectoNombre.Location = new System.Drawing.Point(139, 24);
			this.CbProyectoNombre.Name = "CbProyectoNombre";
			this.CbProyectoNombre.Size = new System.Drawing.Size(556, 31);
			this.CbProyectoNombre.TabIndex = 1;
			this.CbProyectoNombre.SelectedIndexChanged += new System.EventHandler(this.CbProyectoNombre_SelectedIndexChanged);
			// 
			// TbProyectoArea
			// 
			this.TbProyectoArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbProyectoArea.Location = new System.Drawing.Point(139, 95);
			this.TbProyectoArea.Name = "TbProyectoArea";
			this.TbProyectoArea.ReadOnly = true;
			this.TbProyectoArea.Size = new System.Drawing.Size(215, 30);
			this.TbProyectoArea.TabIndex = 6;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(88, 98);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(61, 23);
			this.label11.TabIndex = 5;
			this.label11.Text = "Área :";
			// 
			// BnAgregarProyecto
			// 
			this.BnAgregarProyecto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnAgregarProyecto.Location = new System.Drawing.Point(701, 22);
			this.BnAgregarProyecto.Name = "BnAgregarProyecto";
			this.BnAgregarProyecto.Size = new System.Drawing.Size(117, 28);
			this.BnAgregarProyecto.TabIndex = 2;
			this.BnAgregarProyecto.Text = "Agregar";
			this.BnAgregarProyecto.UseVisualStyleBackColor = true;
			// 
			// TbProyectoDireccion
			// 
			this.TbProyectoDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbProyectoDireccion.Location = new System.Drawing.Point(139, 60);
			this.TbProyectoDireccion.Name = "TbProyectoDireccion";
			this.TbProyectoDireccion.ReadOnly = true;
			this.TbProyectoDireccion.Size = new System.Drawing.Size(679, 30);
			this.TbProyectoDireccion.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(61, 63);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 3;
			this.label7.Text = "Dirección :";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(66, 27);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 23);
			this.label8.TabIndex = 0;
			this.label8.Text = "Nombre :";
			// 
			// GbCategorias
			// 
			this.GbCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GbCategorias.Location = new System.Drawing.Point(9, 422);
			this.GbCategorias.Name = "GbCategorias";
			this.GbCategorias.Size = new System.Drawing.Size(912, 221);
			this.GbCategorias.TabIndex = 4;
			this.GbCategorias.TabStop = false;
			this.GbCategorias.Text = "Categorias";
			// 
			// BnNuevo
			// 
			this.BnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnNuevo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnNuevo.Location = new System.Drawing.Point(9, 649);
			this.BnNuevo.Name = "BnNuevo";
			this.BnNuevo.Size = new System.Drawing.Size(117, 28);
			this.BnNuevo.TabIndex = 5;
			this.BnNuevo.Text = "Nuevo";
			this.BnNuevo.UseVisualStyleBackColor = true;
			this.BnNuevo.Click += new System.EventHandler(this.BnNuevo_Click);
			// 
			// BnBuscar
			// 
			this.BnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnBuscar.Location = new System.Drawing.Point(132, 649);
			this.BnBuscar.Name = "BnBuscar";
			this.BnBuscar.Size = new System.Drawing.Size(117, 28);
			this.BnBuscar.TabIndex = 6;
			this.BnBuscar.Text = "Buscar";
			this.BnBuscar.UseVisualStyleBackColor = true;
			this.BnBuscar.Click += new System.EventHandler(this.BnBuscar_Click);
			// 
			// BnAnular
			// 
			this.BnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnAnular.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnAnular.Location = new System.Drawing.Point(255, 649);
			this.BnAnular.Name = "BnAnular";
			this.BnAnular.Size = new System.Drawing.Size(117, 28);
			this.BnAnular.TabIndex = 7;
			this.BnAnular.Text = "Anular";
			this.BnAnular.UseVisualStyleBackColor = true;
			this.BnAnular.Click += new System.EventHandler(this.BnAnular_Click);
			// 
			// BnSalir
			// 
			this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BnSalir.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnSalir.Location = new System.Drawing.Point(804, 649);
			this.BnSalir.Name = "BnSalir";
			this.BnSalir.Size = new System.Drawing.Size(117, 28);
			this.BnSalir.TabIndex = 10;
			this.BnSalir.Text = "Salir";
			this.BnSalir.UseVisualStyleBackColor = true;
			this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
			// 
			// BnGuardar
			// 
			this.BnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnGuardar.Location = new System.Drawing.Point(378, 649);
			this.BnGuardar.Name = "BnGuardar";
			this.BnGuardar.Size = new System.Drawing.Size(117, 28);
			this.BnGuardar.TabIndex = 8;
			this.BnGuardar.Text = "Guardar";
			this.BnGuardar.UseVisualStyleBackColor = true;
			this.BnGuardar.Click += new System.EventHandler(this.BnGuardar_Click);
			// 
			// BnCancelar
			// 
			this.BnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BnCancelar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnCancelar.Location = new System.Drawing.Point(501, 649);
			this.BnCancelar.Name = "BnCancelar";
			this.BnCancelar.Size = new System.Drawing.Size(117, 28);
			this.BnCancelar.TabIndex = 9;
			this.BnCancelar.Text = "Cancelar";
			this.BnCancelar.UseVisualStyleBackColor = true;
			this.BnCancelar.Click += new System.EventHandler(this.BnCancelar_Click);
			// 
			// FrmPresupuesto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(928, 684);
			this.Controls.Add(this.BnCancelar);
			this.Controls.Add(this.BnGuardar);
			this.Controls.Add(this.BnSalir);
			this.Controls.Add(this.BnAnular);
			this.Controls.Add(this.BnBuscar);
			this.Controls.Add(this.BnNuevo);
			this.Controls.Add(this.GbCategorias);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.LbTitulo);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmPresupuesto";
			this.Text = "Registro de Presupuesto";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPresupuesto_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPresupuesto_FormClosed);
			this.Load += new System.EventHandler(this.FrmPresupuesto_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbNumeroPresupuesto;
        private System.Windows.Forms.DateTimePicker DtpFechaHasta;
        private System.Windows.Forms.DateTimePicker DtpFechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbCreadoPor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TbCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BnBuscarCliente;
        private System.Windows.Forms.ComboBox CbTipoDocumentoIdentidad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BnAgregarProyecto;
        private System.Windows.Forms.TextBox TbProyectoDireccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TbProyectoArea;
        private System.Windows.Forms.Label label11;
        private Controls.CustomTextBox TbNumeroDocumento;
        private System.Windows.Forms.ComboBox CbProyectoNombre;
        private System.Windows.Forms.GroupBox GbCategorias;
        private System.Windows.Forms.Button BnNuevo;
        private System.Windows.Forms.Button BnBuscar;
        private System.Windows.Forms.Button BnAnular;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnCancelar;
    }
}