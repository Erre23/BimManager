namespace BimManager.Client.WipApp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TbUsuario = new System.Windows.Forms.TextBox();
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
            this.TbNumeroDocumento = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.BnBuscarCliente = new System.Windows.Forms.Button();
            this.CbTipoDocumentoIdentidad = new System.Windows.Forms.ComboBox();
            this.TbCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TbProyectoPisos = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TbProyectoAreaTechada = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TbProyectoAreaTotal = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.CbProyectoNombre = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BnAgregarProyecto = new System.Windows.Forms.Button();
            this.TbProyectoDireccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GbCategorias = new System.Windows.Forms.GroupBox();
            this.DgvPresupuestoCategoria = new System.Windows.Forms.DataGridView();
            this.colSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntecedentes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BnSalir = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TbPlanPlazo = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.CbPlan = new System.Windows.Forms.ComboBox();
            this.TbPlanPrecio = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.TbMontoTotal = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.BnCancelar = new System.Windows.Forms.Button();
            this.BnGuardar = new System.Windows.Forms.Button();
            this.BnAnular = new System.Windows.Forms.Button();
            this.BnBuscar = new System.Windows.Forms.Button();
            this.BnNuevo = new System.Windows.Forms.Button();
            this.TbComentario = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GbCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPresupuestoCategoria)).BeginInit();
            this.groupBox4.SuspendLayout();
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
            this.LbTitulo.Size = new System.Drawing.Size(1056, 34);
            this.LbTitulo.TabIndex = 0;
            this.LbTitulo.Text = "Registro de Presupuesto";
            this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbComentario);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.TbUsuario);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DtpFechaHasta);
            this.groupBox1.Controls.Add(this.DtpFechaDesde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TbEstado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TbNumeroPresupuesto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(551, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Presupuesto";
            // 
            // TbUsuario
            // 
            this.TbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbUsuario.Location = new System.Drawing.Point(119, 80);
            this.TbUsuario.Name = "TbUsuario";
            this.TbUsuario.ReadOnly = true;
            this.TbUsuario.Size = new System.Drawing.Size(426, 24);
            this.TbUsuario.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Usuario :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Al :";
            // 
            // DtpFechaHasta
            // 
            this.DtpFechaHasta.CustomFormat = "dddd dd/MM/yyyy";
            this.DtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaHasta.Location = new System.Drawing.Point(368, 51);
            this.DtpFechaHasta.Name = "DtpFechaHasta";
            this.DtpFechaHasta.Size = new System.Drawing.Size(177, 24);
            this.DtpFechaHasta.TabIndex = 7;
            // 
            // DtpFechaDesde
            // 
            this.DtpFechaDesde.CustomFormat = "dddd dd/MM/yyyy";
            this.DtpFechaDesde.Enabled = false;
            this.DtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaDesde.Location = new System.Drawing.Point(119, 51);
            this.DtpFechaDesde.Name = "DtpFechaDesde";
            this.DtpFechaDesde.Size = new System.Drawing.Size(177, 24);
            this.DtpFechaDesde.TabIndex = 5;
            this.DtpFechaDesde.Value = new System.DateTime(2024, 10, 27, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vigencia Desde :";
            // 
            // TbEstado
            // 
            this.TbEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbEstado.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbEstado.Location = new System.Drawing.Point(368, 21);
            this.TbEstado.Name = "TbEstado";
            this.TbEstado.ReadOnly = true;
            this.TbEstado.Size = new System.Drawing.Size(177, 25);
            this.TbEstado.TabIndex = 3;
            this.TbEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estado :";
            // 
            // TbNumeroPresupuesto
            // 
            this.TbNumeroPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbNumeroPresupuesto.Location = new System.Drawing.Point(119, 21);
            this.TbNumeroPresupuesto.Name = "TbNumeroPresupuesto";
            this.TbNumeroPresupuesto.ReadOnly = true;
            this.TbNumeroPresupuesto.Size = new System.Drawing.Size(177, 24);
            this.TbNumeroPresupuesto.TabIndex = 1;
            this.TbNumeroPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
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
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(568, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(482, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Cliente";
            // 
            // TbNumeroDocumento
            // 
            this.TbNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbNumeroDocumento.Location = new System.Drawing.Point(86, 51);
            this.TbNumeroDocumento.Name = "TbNumeroDocumento";
            this.TbNumeroDocumento.Size = new System.Drawing.Size(199, 24);
            this.TbNumeroDocumento.TabIndex = 3;
            this.TbNumeroDocumento.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.Todo;
            this.TbNumeroDocumento.TextChanged += new System.EventHandler(this.TbNumeroDocumento_TextChanged);
            // 
            // BnBuscarCliente
            // 
            this.BnBuscarCliente.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscarCliente.Image = global::BimManager.Client.WipApp.Properties.Resources.Buscar;
            this.BnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscarCliente.Location = new System.Drawing.Point(291, 51);
            this.BnBuscarCliente.Name = "BnBuscarCliente";
            this.BnBuscarCliente.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscarCliente.Size = new System.Drawing.Size(94, 26);
            this.BnBuscarCliente.TabIndex = 4;
            this.BnBuscarCliente.Text = "Buscar";
            this.BnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscarCliente.UseVisualStyleBackColor = true;
            this.BnBuscarCliente.Click += new System.EventHandler(this.BnBuscarCliente_Click);
            // 
            // CbTipoDocumentoIdentidad
            // 
            this.CbTipoDocumentoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTipoDocumentoIdentidad.FormattingEnabled = true;
            this.CbTipoDocumentoIdentidad.Location = new System.Drawing.Point(85, 21);
            this.CbTipoDocumentoIdentidad.Name = "CbTipoDocumentoIdentidad";
            this.CbTipoDocumentoIdentidad.Size = new System.Drawing.Size(200, 25);
            this.CbTipoDocumentoIdentidad.TabIndex = 1;
            this.CbTipoDocumentoIdentidad.SelectedIndexChanged += new System.EventHandler(this.CbTipoDocumentoIdentidad_SelectedIndexChanged);
            // 
            // TbCliente
            // 
            this.TbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCliente.Location = new System.Drawing.Point(86, 80);
            this.TbCliente.Name = "TbCliente";
            this.TbCliente.ReadOnly = true;
            this.TbCliente.Size = new System.Drawing.Size(389, 24);
            this.TbCliente.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cliente :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 54);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "N° Doc. :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tipo Doc. :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TbProyectoPisos);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.TbProyectoAreaTechada);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.TbProyectoAreaTotal);
            this.groupBox3.Controls.Add(this.CbProyectoNombre);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.BnAgregarProyecto);
            this.groupBox3.Controls.Add(this.TbProyectoDireccion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(9, 187);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(661, 111);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Proyecto";
            // 
            // TbProyectoPisos
            // 
            this.TbProyectoPisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoPisos.Location = new System.Drawing.Point(553, 81);
            this.TbProyectoPisos.Name = "TbProyectoPisos";
            this.TbProyectoPisos.Size = new System.Drawing.Size(100, 24);
            this.TbProyectoPisos.TabIndex = 10;
            this.TbProyectoPisos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbProyectoPisos.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            this.TbProyectoPisos.TextChanged += new System.EventHandler(this.TbProyectoPisos_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(482, 84);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "Nº Pisos :";
            // 
            // TbProyectoAreaTechada
            // 
            this.TbProyectoAreaTechada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoAreaTechada.Location = new System.Drawing.Point(367, 81);
            this.TbProyectoAreaTechada.Name = "TbProyectoAreaTechada";
            this.TbProyectoAreaTechada.ReadOnly = true;
            this.TbProyectoAreaTechada.Size = new System.Drawing.Size(100, 24);
            this.TbProyectoAreaTechada.TabIndex = 8;
            this.TbProyectoAreaTechada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbProyectoAreaTechada.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.Todo;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(230, 84);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "Área Techada (m2) :";
            // 
            // TbProyectoAreaTotal
            // 
            this.TbProyectoAreaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoAreaTotal.Location = new System.Drawing.Point(119, 81);
            this.TbProyectoAreaTotal.Name = "TbProyectoAreaTotal";
            this.TbProyectoAreaTotal.Size = new System.Drawing.Size(100, 24);
            this.TbProyectoAreaTotal.TabIndex = 6;
            this.TbProyectoAreaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbProyectoAreaTotal.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            this.TbProyectoAreaTotal.TextChanged += new System.EventHandler(this.TbProyectoAreaTotal_TextChanged);
            // 
            // CbProyectoNombre
            // 
            this.CbProyectoNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProyectoNombre.FormattingEnabled = true;
            this.CbProyectoNombre.Location = new System.Drawing.Point(119, 20);
            this.CbProyectoNombre.Name = "CbProyectoNombre";
            this.CbProyectoNombre.Size = new System.Drawing.Size(426, 25);
            this.CbProyectoNombre.TabIndex = 1;
            this.CbProyectoNombre.SelectedIndexChanged += new System.EventHandler(this.CbProyectoNombre_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 84);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Área Total (m2) :";
            // 
            // BnAgregarProyecto
            // 
            this.BnAgregarProyecto.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnAgregarProyecto.Image = global::BimManager.Client.WipApp.Properties.Resources.Add;
            this.BnAgregarProyecto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnAgregarProyecto.Location = new System.Drawing.Point(551, 21);
            this.BnAgregarProyecto.Name = "BnAgregarProyecto";
            this.BnAgregarProyecto.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnAgregarProyecto.Size = new System.Drawing.Size(104, 26);
            this.BnAgregarProyecto.TabIndex = 2;
            this.BnAgregarProyecto.Text = "Agregar";
            this.BnAgregarProyecto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnAgregarProyecto.UseVisualStyleBackColor = true;
            this.BnAgregarProyecto.Click += new System.EventHandler(this.BnAgregarProyecto_Click);
            // 
            // TbProyectoDireccion
            // 
            this.TbProyectoDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProyectoDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProyectoDireccion.Location = new System.Drawing.Point(119, 51);
            this.TbProyectoDireccion.Name = "TbProyectoDireccion";
            this.TbProyectoDireccion.ReadOnly = true;
            this.TbProyectoDireccion.Size = new System.Drawing.Size(535, 24);
            this.TbProyectoDireccion.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Dirección :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nombre :";
            // 
            // GbCategorias
            // 
            this.GbCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbCategorias.Controls.Add(this.DgvPresupuestoCategoria);
            this.GbCategorias.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbCategorias.Location = new System.Drawing.Point(9, 311);
            this.GbCategorias.Name = "GbCategorias";
            this.GbCategorias.Size = new System.Drawing.Size(1040, 431);
            this.GbCategorias.TabIndex = 4;
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
            this.DgvPresupuestoCategoria.RowHeadersWidth = 51;
            this.DgvPresupuestoCategoria.RowTemplate.Height = 24;
            this.DgvPresupuestoCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPresupuestoCategoria.Size = new System.Drawing.Size(1028, 400);
            this.DgvPresupuestoCategoria.TabIndex = 0;
            this.DgvPresupuestoCategoria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPresupuestoCategoria_CellContentClick);
            this.DgvPresupuestoCategoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvPresupuestoCategoria_KeyDown);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAntecedentes.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAntecedentes.HeaderText = "Antecedentes";
            this.colAntecedentes.MinimumWidth = 6;
            this.colAntecedentes.Name = "colAntecedentes";
            this.colAntecedentes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAntecedentes.Width = 125;
            // 
            // colImporte
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle4;
            this.colImporte.HeaderText = "Importe S/";
            this.colImporte.MinimumWidth = 6;
            this.colImporte.Name = "colImporte";
            this.colImporte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colImporte.Width = 125;
            // 
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = global::BimManager.Client.WipApp.Properties.Resources.Cerrar;
            this.BnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSalir.Location = new System.Drawing.Point(946, 794);
            this.BnSalir.Name = "BnSalir";
            this.BnSalir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSalir.Size = new System.Drawing.Size(102, 31);
            this.BnSalir.TabIndex = 11;
            this.BnSalir.Text = "Salir";
            this.BnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSalir.UseVisualStyleBackColor = true;
            this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(739, 756);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 23);
            this.label14.TabIndex = 12;
            this.label14.Text = "Monto Total S/ :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TbPlanPlazo);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.CbPlan);
            this.groupBox4.Controls.Add(this.TbPlanPrecio);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(679, 187);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(369, 111);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos del Plan";
            // 
            // TbPlanPlazo
            // 
            this.TbPlanPlazo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbPlanPlazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPlanPlazo.Location = new System.Drawing.Point(110, 81);
            this.TbPlanPlazo.Name = "TbPlanPlazo";
            this.TbPlanPlazo.ReadOnly = true;
            this.TbPlanPlazo.Size = new System.Drawing.Size(106, 24);
            this.TbPlanPlazo.TabIndex = 8;
            this.TbPlanPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TbPlanPlazo.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.Todo;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 84);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 17);
            this.label16.TabIndex = 7;
            this.label16.Text = "Plazo (días):";
            // 
            // CbPlan
            // 
            this.CbPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPlan.FormattingEnabled = true;
            this.CbPlan.Location = new System.Drawing.Point(110, 20);
            this.CbPlan.Name = "CbPlan";
            this.CbPlan.Size = new System.Drawing.Size(253, 25);
            this.CbPlan.TabIndex = 1;
            this.CbPlan.SelectedIndexChanged += new System.EventHandler(this.CbPlan_SelectedIndexChanged);
            // 
            // TbPlanPrecio
            // 
            this.TbPlanPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPlanPrecio.Location = new System.Drawing.Point(110, 51);
            this.TbPlanPrecio.Name = "TbPlanPrecio";
            this.TbPlanPrecio.ReadOnly = true;
            this.TbPlanPrecio.Size = new System.Drawing.Size(106, 24);
            this.TbPlanPrecio.TabIndex = 4;
            this.TbPlanPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 54);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 17);
            this.label18.TabIndex = 3;
            this.label18.Text = "Precio m2 S/ :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(67, 23);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 17);
            this.label19.TabIndex = 0;
            this.label19.Text = "Plan :";
            // 
            // TbMontoTotal
            // 
            this.TbMontoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMontoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMontoTotal.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMontoTotal.Location = new System.Drawing.Point(894, 752);
            this.TbMontoTotal.Name = "TbMontoTotal";
            this.TbMontoTotal.ReadOnly = true;
            this.TbMontoTotal.Size = new System.Drawing.Size(155, 30);
            this.TbMontoTotal.TabIndex = 13;
            this.TbMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TbMontoTotal.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // BnCancelar
            // 
            this.BnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnCancelar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnCancelar.Image = global::BimManager.Client.WipApp.Properties.Resources.Cancelar;
            this.BnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnCancelar.Location = new System.Drawing.Point(433, 794);
            this.BnCancelar.Name = "BnCancelar";
            this.BnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnCancelar.Size = new System.Drawing.Size(102, 31);
            this.BnCancelar.TabIndex = 10;
            this.BnCancelar.Text = "Cancelar";
            this.BnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnCancelar.UseVisualStyleBackColor = true;
            this.BnCancelar.Click += new System.EventHandler(this.BnCancelar_Click);
            // 
            // BnGuardar
            // 
            this.BnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnGuardar.Image = global::BimManager.Client.WipApp.Properties.Resources.Guardar;
            this.BnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnGuardar.Location = new System.Drawing.Point(326, 794);
            this.BnGuardar.Name = "BnGuardar";
            this.BnGuardar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnGuardar.Size = new System.Drawing.Size(102, 31);
            this.BnGuardar.TabIndex = 9;
            this.BnGuardar.Text = "Guardar";
            this.BnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnGuardar.UseVisualStyleBackColor = true;
            this.BnGuardar.Click += new System.EventHandler(this.BnGuardar_Click);
            // 
            // BnAnular
            // 
            this.BnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnAnular.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnAnular.Image = global::BimManager.Client.WipApp.Properties.Resources.Anular;
            this.BnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnAnular.Location = new System.Drawing.Point(221, 794);
            this.BnAnular.Name = "BnAnular";
            this.BnAnular.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnAnular.Size = new System.Drawing.Size(102, 31);
            this.BnAnular.TabIndex = 7;
            this.BnAnular.Text = "Anular";
            this.BnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnAnular.UseVisualStyleBackColor = true;
            this.BnAnular.Click += new System.EventHandler(this.BnAnular_Click);
            // 
            // BnBuscar
            // 
            this.BnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscar.Image = global::BimManager.Client.WipApp.Properties.Resources.Buscar;
            this.BnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscar.Location = new System.Drawing.Point(115, 794);
            this.BnBuscar.Name = "BnBuscar";
            this.BnBuscar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscar.Size = new System.Drawing.Size(102, 31);
            this.BnBuscar.TabIndex = 6;
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
            this.BnNuevo.Image = global::BimManager.Client.WipApp.Properties.Resources.Nuevo;
            this.BnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnNuevo.Location = new System.Drawing.Point(9, 794);
            this.BnNuevo.Name = "BnNuevo";
            this.BnNuevo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnNuevo.Size = new System.Drawing.Size(102, 31);
            this.BnNuevo.TabIndex = 5;
            this.BnNuevo.Text = "Nuevo";
            this.BnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnNuevo.UseVisualStyleBackColor = true;
            this.BnNuevo.Click += new System.EventHandler(this.BnNuevo_Click);
            // 
            // TbComentario
            // 
            this.TbComentario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbComentario.Location = new System.Drawing.Point(119, 109);
            this.TbComentario.Name = "TbComentario";
            this.TbComentario.ReadOnly = true;
            this.TbComentario.Size = new System.Drawing.Size(426, 24);
            this.TbComentario.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 113);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 17);
            this.label15.TabIndex = 10;
            this.label15.Text = "Comentario :";
            // 
            // FrmPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 833);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.TbMontoTotal);
            this.Controls.Add(this.label14);
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
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.GbCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPresupuestoCategoria)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox TbUsuario;
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
		private Controls.CustomTextBox TbProyectoPisos;
		private System.Windows.Forms.Label label13;
		private Controls.CustomTextBox TbProyectoAreaTechada;
		private System.Windows.Forms.Label label12;
		private Controls.CustomTextBox TbProyectoAreaTotal;
		private System.Windows.Forms.DataGridView DgvPresupuestoCategoria;
		private Controls.CustomTextBox TbMontoTotal;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox4;
		private Controls.CustomTextBox TbPlanPlazo;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox CbPlan;
		private System.Windows.Forms.TextBox TbPlanPrecio;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntecedentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.TextBox TbComentario;
        private System.Windows.Forms.Label label15;
    }
}