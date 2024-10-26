namespace BimManager.Client.WipApp
{
    partial class FrmPresupuestoBuscar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.GbDatosBusqueda = new System.Windows.Forms.GroupBox();
            this.CbProyectoNombre = new System.Windows.Forms.ComboBox();
            this.LbProyecto = new System.Windows.Forms.Label();
            this.TbNumeroDocumento = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.CbEstado = new System.Windows.Forms.ComboBox();
            this.BnBuscarCliente = new System.Windows.Forms.Button();
            this.LbAl = new System.Windows.Forms.Label();
            this.CbTipoDocumentoIdentidad = new System.Windows.Forms.ComboBox();
            this.TbCliente = new System.Windows.Forms.TextBox();
            this.DtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.LbCliente = new System.Windows.Forms.Label();
            this.DtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.LbDocumentoIdentidadNumero = new System.Windows.Forms.Label();
            this.LbDesde = new System.Windows.Forms.Label();
            this.LbTipoDocumentoIdentidad = new System.Windows.Forms.Label();
            this.LbEstado = new System.Windows.Forms.Label();
            this.TbNumeroPresupuesto = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.LbPresupuesto = new System.Windows.Forms.Label();
            this.GbResultados = new System.Windows.Forms.GroupBox();
            this.DgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.RbNumeroPresupuesto = new System.Windows.Forms.RadioButton();
            this.RbBusquedaDetallada = new System.Windows.Forms.RadioButton();
            this.BnBuscar = new System.Windows.Forms.Button();
            this.BnAceptar = new System.Windows.Forms.Button();
            this.BnSalir = new System.Windows.Forms.Button();
            this.GbDatosBusqueda.SuspendLayout();
            this.GbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPresupuesto)).BeginInit();
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
            this.LbTitulo.Size = new System.Drawing.Size(968, 34);
            this.LbTitulo.TabIndex = 0;
            this.LbTitulo.Text = "Búsqueda de Presupuesto";
            this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GbDatosBusqueda
            // 
            this.GbDatosBusqueda.Controls.Add(this.CbProyectoNombre);
            this.GbDatosBusqueda.Controls.Add(this.LbProyecto);
            this.GbDatosBusqueda.Controls.Add(this.TbNumeroDocumento);
            this.GbDatosBusqueda.Controls.Add(this.CbEstado);
            this.GbDatosBusqueda.Controls.Add(this.BnBuscarCliente);
            this.GbDatosBusqueda.Controls.Add(this.LbAl);
            this.GbDatosBusqueda.Controls.Add(this.CbTipoDocumentoIdentidad);
            this.GbDatosBusqueda.Controls.Add(this.TbCliente);
            this.GbDatosBusqueda.Controls.Add(this.DtpFechaHasta);
            this.GbDatosBusqueda.Controls.Add(this.LbCliente);
            this.GbDatosBusqueda.Controls.Add(this.DtpFechaDesde);
            this.GbDatosBusqueda.Controls.Add(this.LbDocumentoIdentidadNumero);
            this.GbDatosBusqueda.Controls.Add(this.LbDesde);
            this.GbDatosBusqueda.Controls.Add(this.LbTipoDocumentoIdentidad);
            this.GbDatosBusqueda.Controls.Add(this.LbEstado);
            this.GbDatosBusqueda.Controls.Add(this.TbNumeroPresupuesto);
            this.GbDatosBusqueda.Controls.Add(this.LbPresupuesto);
            this.GbDatosBusqueda.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbDatosBusqueda.Location = new System.Drawing.Point(9, 73);
            this.GbDatosBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.GbDatosBusqueda.Name = "GbDatosBusqueda";
            this.GbDatosBusqueda.Padding = new System.Windows.Forms.Padding(4);
            this.GbDatosBusqueda.Size = new System.Drawing.Size(847, 180);
            this.GbDatosBusqueda.TabIndex = 4;
            this.GbDatosBusqueda.TabStop = false;
            this.GbDatosBusqueda.Text = "Datos del Búsqueda";
            // 
            // CbProyectoNombre
            // 
            this.CbProyectoNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProyectoNombre.FormattingEnabled = true;
            this.CbProyectoNombre.Location = new System.Drawing.Point(139, 146);
            this.CbProyectoNombre.Name = "CbProyectoNombre";
            this.CbProyectoNombre.Size = new System.Drawing.Size(556, 25);
            this.CbProyectoNombre.TabIndex = 16;
            // 
            // LbProyecto
            // 
            this.LbProyecto.AutoSize = true;
            this.LbProyecto.Location = new System.Drawing.Point(61, 150);
            this.LbProyecto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProyecto.Name = "LbProyecto";
            this.LbProyecto.Size = new System.Drawing.Size(73, 17);
            this.LbProyecto.TabIndex = 15;
            this.LbProyecto.Text = "Proyecto :";
            // 
            // TbNumeroDocumento
            // 
            this.TbNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbNumeroDocumento.Location = new System.Drawing.Point(480, 86);
            this.TbNumeroDocumento.Name = "TbNumeroDocumento";
            this.TbNumeroDocumento.Size = new System.Drawing.Size(215, 24);
            this.TbNumeroDocumento.TabIndex = 11;
            this.TbNumeroDocumento.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.Todo;
            this.TbNumeroDocumento.TextChanged += new System.EventHandler(this.TbNumeroDocumento_TextChanged);
            // 
            // CbEstado
            // 
            this.CbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbEstado.FormattingEnabled = true;
            this.CbEstado.Location = new System.Drawing.Point(139, 56);
            this.CbEstado.Name = "CbEstado";
            this.CbEstado.Size = new System.Drawing.Size(215, 25);
            this.CbEstado.TabIndex = 7;
            // 
            // BnBuscarCliente
            // 
            this.BnBuscarCliente.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscarCliente.Image = global::BimManager.Client.WipApp.Properties.Resources.Buscar;
            this.BnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscarCliente.Location = new System.Drawing.Point(701, 83);
            this.BnBuscarCliente.Name = "BnBuscarCliente";
            this.BnBuscarCliente.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscarCliente.Size = new System.Drawing.Size(139, 28);
            this.BnBuscarCliente.TabIndex = 12;
            this.BnBuscarCliente.Text = "Buscar Cliente";
            this.BnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscarCliente.UseVisualStyleBackColor = true;
            this.BnBuscarCliente.Click += new System.EventHandler(this.BnBuscarCliente_Click);
            // 
            // LbAl
            // 
            this.LbAl.AutoSize = true;
            this.LbAl.Location = new System.Drawing.Point(448, 31);
            this.LbAl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbAl.Name = "LbAl";
            this.LbAl.Size = new System.Drawing.Size(27, 17);
            this.LbAl.TabIndex = 4;
            this.LbAl.Text = "Al :";
            // 
            // CbTipoDocumentoIdentidad
            // 
            this.CbTipoDocumentoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTipoDocumentoIdentidad.FormattingEnabled = true;
            this.CbTipoDocumentoIdentidad.Location = new System.Drawing.Point(139, 86);
            this.CbTipoDocumentoIdentidad.Name = "CbTipoDocumentoIdentidad";
            this.CbTipoDocumentoIdentidad.Size = new System.Drawing.Size(215, 25);
            this.CbTipoDocumentoIdentidad.TabIndex = 9;
            this.CbTipoDocumentoIdentidad.SelectedIndexChanged += new System.EventHandler(this.CbTipoDocumentoIdentidad_SelectedIndexChanged);
            // 
            // TbCliente
            // 
            this.TbCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCliente.Location = new System.Drawing.Point(139, 116);
            this.TbCliente.Name = "TbCliente";
            this.TbCliente.ReadOnly = true;
            this.TbCliente.Size = new System.Drawing.Size(556, 24);
            this.TbCliente.TabIndex = 14;
            // 
            // DtpFechaHasta
            // 
            this.DtpFechaHasta.CustomFormat = "dddd dd/MM/yyyy";
            this.DtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaHasta.Location = new System.Drawing.Point(480, 28);
            this.DtpFechaHasta.Name = "DtpFechaHasta";
            this.DtpFechaHasta.Size = new System.Drawing.Size(215, 24);
            this.DtpFechaHasta.TabIndex = 5;
            // 
            // LbCliente
            // 
            this.LbCliente.AutoSize = true;
            this.LbCliente.Location = new System.Drawing.Point(75, 119);
            this.LbCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbCliente.Name = "LbCliente";
            this.LbCliente.Size = new System.Drawing.Size(57, 17);
            this.LbCliente.TabIndex = 13;
            this.LbCliente.Text = "Cliente :";
            // 
            // DtpFechaDesde
            // 
            this.DtpFechaDesde.CustomFormat = "dddd dd/MM/yyyy";
            this.DtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaDesde.Location = new System.Drawing.Point(139, 28);
            this.DtpFechaDesde.Name = "DtpFechaDesde";
            this.DtpFechaDesde.Size = new System.Drawing.Size(215, 24);
            this.DtpFechaDesde.TabIndex = 3;
            // 
            // LbDocumentoIdentidadNumero
            // 
            this.LbDocumentoIdentidadNumero.AutoSize = true;
            this.LbDocumentoIdentidadNumero.Location = new System.Drawing.Point(407, 90);
            this.LbDocumentoIdentidadNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbDocumentoIdentidadNumero.Name = "LbDocumentoIdentidadNumero";
            this.LbDocumentoIdentidadNumero.Size = new System.Drawing.Size(66, 17);
            this.LbDocumentoIdentidadNumero.TabIndex = 10;
            this.LbDocumentoIdentidadNumero.Text = "N° Doc. :";
            // 
            // LbDesde
            // 
            this.LbDesde.AutoSize = true;
            this.LbDesde.Location = new System.Drawing.Point(77, 31);
            this.LbDesde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbDesde.Name = "LbDesde";
            this.LbDesde.Size = new System.Drawing.Size(55, 17);
            this.LbDesde.TabIndex = 2;
            this.LbDesde.Text = "Desde :";
            // 
            // LbTipoDocumentoIdentidad
            // 
            this.LbTipoDocumentoIdentidad.AutoSize = true;
            this.LbTipoDocumentoIdentidad.Location = new System.Drawing.Point(55, 90);
            this.LbTipoDocumentoIdentidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbTipoDocumentoIdentidad.Name = "LbTipoDocumentoIdentidad";
            this.LbTipoDocumentoIdentidad.Size = new System.Drawing.Size(76, 17);
            this.LbTipoDocumentoIdentidad.TabIndex = 8;
            this.LbTipoDocumentoIdentidad.Text = "Tipo Doc. :";
            // 
            // LbEstado
            // 
            this.LbEstado.AutoSize = true;
            this.LbEstado.Location = new System.Drawing.Point(74, 59);
            this.LbEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbEstado.Name = "LbEstado";
            this.LbEstado.Size = new System.Drawing.Size(59, 17);
            this.LbEstado.TabIndex = 6;
            this.LbEstado.Text = "Estado :";
            // 
            // TbNumeroPresupuesto
            // 
            this.TbNumeroPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbNumeroPresupuesto.Location = new System.Drawing.Point(139, 28);
            this.TbNumeroPresupuesto.Name = "TbNumeroPresupuesto";
            this.TbNumeroPresupuesto.Size = new System.Drawing.Size(215, 24);
            this.TbNumeroPresupuesto.TabIndex = 1;
            this.TbNumeroPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbNumeroPresupuesto.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // LbPresupuesto
            // 
            this.LbPresupuesto.AutoSize = true;
            this.LbPresupuesto.Location = new System.Drawing.Point(16, 31);
            this.LbPresupuesto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbPresupuesto.Name = "LbPresupuesto";
            this.LbPresupuesto.Size = new System.Drawing.Size(113, 17);
            this.LbPresupuesto.TabIndex = 0;
            this.LbPresupuesto.Text = "N° Presupuesto :";
            // 
            // GbResultados
            // 
            this.GbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbResultados.Controls.Add(this.DgvPresupuesto);
            this.GbResultados.Location = new System.Drawing.Point(9, 260);
            this.GbResultados.Name = "GbResultados";
            this.GbResultados.Size = new System.Drawing.Size(952, 331);
            this.GbResultados.TabIndex = 6;
            this.GbResultados.TabStop = false;
            this.GbResultados.Text = "Resultados :";
            // 
            // DgvPresupuesto
            // 
            this.DgvPresupuesto.AllowUserToAddRows = false;
            this.DgvPresupuesto.AllowUserToDeleteRows = false;
            this.DgvPresupuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPresupuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column13,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.DgvPresupuesto.Location = new System.Drawing.Point(6, 23);
            this.DgvPresupuesto.MultiSelect = false;
            this.DgvPresupuesto.Name = "DgvPresupuesto";
            this.DgvPresupuesto.RowHeadersWidth = 51;
            this.DgvPresupuesto.RowTemplate.Height = 24;
            this.DgvPresupuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPresupuesto.Size = new System.Drawing.Size(940, 299);
            this.DgvPresupuesto.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "N° Presup.";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 90;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Estado";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Vigente Desde";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Vigente Hasta";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cliente";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Proyecto";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column6.HeaderText = "Area Total";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column7.HeaderText = "Area Techada";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 90;
            // 
            // Column8
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column8.HeaderText = "N° Pisos";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Plan";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 90;
            // 
            // Column10
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column10.HeaderText = "Costo x M2";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 80;
            // 
            // Column11
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column11.HeaderText = "Plazo (días)";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Width = 90;
            // 
            // Column12
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column12.HeaderText = "Imp. Total S/";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Width = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Buscar Por :";
            // 
            // RbNumeroPresupuesto
            // 
            this.RbNumeroPresupuesto.AutoSize = true;
            this.RbNumeroPresupuesto.Location = new System.Drawing.Point(152, 44);
            this.RbNumeroPresupuesto.Name = "RbNumeroPresupuesto";
            this.RbNumeroPresupuesto.Size = new System.Drawing.Size(141, 21);
            this.RbNumeroPresupuesto.TabIndex = 2;
            this.RbNumeroPresupuesto.TabStop = true;
            this.RbNumeroPresupuesto.Text = "Nº de Presupuesto";
            this.RbNumeroPresupuesto.UseVisualStyleBackColor = true;
            this.RbNumeroPresupuesto.CheckedChanged += new System.EventHandler(this.RbNumeroPresupuesto_CheckedChanged);
            // 
            // RbBusquedaDetallada
            // 
            this.RbBusquedaDetallada.AutoSize = true;
            this.RbBusquedaDetallada.Location = new System.Drawing.Point(339, 44);
            this.RbBusquedaDetallada.Name = "RbBusquedaDetallada";
            this.RbBusquedaDetallada.Size = new System.Drawing.Size(131, 21);
            this.RbBusquedaDetallada.TabIndex = 3;
            this.RbBusquedaDetallada.TabStop = true;
            this.RbBusquedaDetallada.Text = "Rango de Fechas";
            this.RbBusquedaDetallada.UseVisualStyleBackColor = true;
            this.RbBusquedaDetallada.CheckedChanged += new System.EventHandler(this.RbBusquedaDetallada_CheckedChanged);
            // 
            // BnBuscar
            // 
            this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscar.Image = global::BimManager.Client.WipApp.Properties.Resources.Buscar;
            this.BnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscar.Location = new System.Drawing.Point(863, 223);
            this.BnBuscar.Name = "BnBuscar";
            this.BnBuscar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscar.Size = new System.Drawing.Size(98, 30);
            this.BnBuscar.TabIndex = 5;
            this.BnBuscar.Text = "Buscar";
            this.BnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscar.UseVisualStyleBackColor = true;
            this.BnBuscar.Click += new System.EventHandler(this.BnBuscar_Click);
            // 
            // BnAceptar
            // 
            this.BnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnAceptar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnAceptar.Image = global::BimManager.Client.WipApp.Properties.Resources.Confirmar;
            this.BnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnAceptar.Location = new System.Drawing.Point(760, 596);
            this.BnAceptar.Name = "BnAceptar";
            this.BnAceptar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnAceptar.Size = new System.Drawing.Size(98, 30);
            this.BnAceptar.TabIndex = 7;
            this.BnAceptar.Text = "Aceptar";
            this.BnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnAceptar.UseVisualStyleBackColor = true;
            this.BnAceptar.Click += new System.EventHandler(this.BnAceptar_Click);
            // 
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = global::BimManager.Client.WipApp.Properties.Resources.Cerrar;
            this.BnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSalir.Location = new System.Drawing.Point(864, 596);
            this.BnSalir.Name = "BnSalir";
            this.BnSalir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSalir.Size = new System.Drawing.Size(98, 30);
            this.BnSalir.TabIndex = 8;
            this.BnSalir.Text = "Salir";
            this.BnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSalir.UseVisualStyleBackColor = true;
            this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
            // 
            // FrmPresupuestoBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 633);
            this.Controls.Add(this.RbBusquedaDetallada);
            this.Controls.Add(this.RbNumeroPresupuesto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BnBuscar);
            this.Controls.Add(this.BnAceptar);
            this.Controls.Add(this.BnSalir);
            this.Controls.Add(this.GbResultados);
            this.Controls.Add(this.GbDatosBusqueda);
            this.Controls.Add(this.LbTitulo);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPresupuestoBuscar";
            this.Text = "Búsqueda de Presupuesto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPresupuesto_Load);
            this.GbDatosBusqueda.ResumeLayout(false);
            this.GbDatosBusqueda.PerformLayout();
            this.GbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPresupuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.GroupBox GbDatosBusqueda;
        private System.Windows.Forms.Label LbPresupuesto;
        private System.Windows.Forms.Label LbEstado;
        private BimManager.Client.WipApp.Controls.CustomTextBox TbNumeroPresupuesto;
        private System.Windows.Forms.DateTimePicker DtpFechaHasta;
        private System.Windows.Forms.DateTimePicker DtpFechaDesde;
        private System.Windows.Forms.Label LbDesde;
        private System.Windows.Forms.Label LbAl;
        private System.Windows.Forms.TextBox TbCliente;
        private System.Windows.Forms.Label LbCliente;
        private System.Windows.Forms.Label LbDocumentoIdentidadNumero;
        private System.Windows.Forms.Label LbTipoDocumentoIdentidad;
        private System.Windows.Forms.Button BnBuscarCliente;
        private System.Windows.Forms.ComboBox CbTipoDocumentoIdentidad;
        private System.Windows.Forms.Label LbProyecto;
        private Controls.CustomTextBox TbNumeroDocumento;
        private System.Windows.Forms.ComboBox CbProyectoNombre;
        private System.Windows.Forms.GroupBox GbResultados;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.Button BnAceptar;
		private System.Windows.Forms.DataGridView DgvPresupuesto;
        private System.Windows.Forms.ComboBox CbEstado;
        private System.Windows.Forms.Button BnBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton RbNumeroPresupuesto;
        private System.Windows.Forms.RadioButton RbBusquedaDetallada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}