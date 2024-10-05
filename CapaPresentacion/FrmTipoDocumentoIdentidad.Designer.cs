namespace CapaPresentacion
{
    partial class FrmTipoDocumentoIdentidad
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
			this.ChkPersonaJuridica = new System.Windows.Forms.CheckBox();
			this.ChkAlfanumerico = new System.Windows.Forms.CheckBox();
			this.ChkLongitudExacta = new System.Windows.Forms.CheckBox();
			this.TbLongitudMaxima = new CapaPresentacion.Controls.CustomTextBox();
			this.TbLongitudMinima = new CapaPresentacion.Controls.CustomTextBox();
			this.TbNombre = new System.Windows.Forms.TextBox();
			this.LbLongitudMaxima = new System.Windows.Forms.Label();
			this.LbLongitudMinima = new System.Windows.Forms.Label();
			this.LbNombre = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.GbLista = new System.Windows.Forms.GroupBox();
			this.DgvTipoDocumentoIdentidad = new System.Windows.Forms.DataGridView();
			this.LbOpcion = new System.Windows.Forms.Label();
			this.BnGuardar = new System.Windows.Forms.Button();
			this.BnCancelar = new System.Windows.Forms.Button();
			this.BnNuevo = new System.Windows.Forms.Button();
			this.BnEditar = new System.Windows.Forms.Button();
			this.BnDeshabilitar = new System.Windows.Forms.Button();
			this.BnSalir = new System.Windows.Forms.Button();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ChkConsultaAPI = new System.Windows.Forms.CheckBox();
			this.GbDatos.SuspendLayout();
			this.GbLista.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgvTipoDocumentoIdentidad)).BeginInit();
			this.SuspendLayout();
			// 
			// GbDatos
			// 
			this.GbDatos.Controls.Add(this.ChkConsultaAPI);
			this.GbDatos.Controls.Add(this.ChkPersonaJuridica);
			this.GbDatos.Controls.Add(this.ChkAlfanumerico);
			this.GbDatos.Controls.Add(this.ChkLongitudExacta);
			this.GbDatos.Controls.Add(this.TbLongitudMaxima);
			this.GbDatos.Controls.Add(this.TbLongitudMinima);
			this.GbDatos.Controls.Add(this.TbNombre);
			this.GbDatos.Controls.Add(this.LbLongitudMaxima);
			this.GbDatos.Controls.Add(this.LbLongitudMinima);
			this.GbDatos.Controls.Add(this.LbNombre);
			this.GbDatos.Location = new System.Drawing.Point(12, 47);
			this.GbDatos.Name = "GbDatos";
			this.GbDatos.Size = new System.Drawing.Size(536, 166);
			this.GbDatos.TabIndex = 1;
			this.GbDatos.TabStop = false;
			this.GbDatos.Text = "Datos del Tipo de Documento de Identidad";
			// 
			// ChkPersonaJuridica
			// 
			this.ChkPersonaJuridica.AutoSize = true;
			this.ChkPersonaJuridica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkPersonaJuridica.Location = new System.Drawing.Point(197, 135);
			this.ChkPersonaJuridica.Name = "ChkPersonaJuridica";
			this.ChkPersonaJuridica.Size = new System.Drawing.Size(163, 25);
			this.ChkPersonaJuridica.TabIndex = 17;
			this.ChkPersonaJuridica.Text = "Persona Jurídica :";
			this.ChkPersonaJuridica.UseVisualStyleBackColor = true;
			// 
			// ChkAlfanumerico
			// 
			this.ChkAlfanumerico.AutoSize = true;
			this.ChkAlfanumerico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkAlfanumerico.Location = new System.Drawing.Point(32, 136);
			this.ChkAlfanumerico.Name = "ChkAlfanumerico";
			this.ChkAlfanumerico.Size = new System.Drawing.Size(140, 25);
			this.ChkAlfanumerico.TabIndex = 16;
			this.ChkAlfanumerico.Text = "Alfanumérico :";
			this.ChkAlfanumerico.UseVisualStyleBackColor = true;
			// 
			// ChkLongitudExacta
			// 
			this.ChkLongitudExacta.AutoSize = true;
			this.ChkLongitudExacta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkLongitudExacta.Location = new System.Drawing.Point(18, 65);
			this.ChkLongitudExacta.Name = "ChkLongitudExacta";
			this.ChkLongitudExacta.Size = new System.Drawing.Size(152, 25);
			this.ChkLongitudExacta.TabIndex = 15;
			this.ChkLongitudExacta.Text = "Logitud Exacta :";
			this.ChkLongitudExacta.UseVisualStyleBackColor = true;
			this.ChkLongitudExacta.CheckedChanged += new System.EventHandler(this.ChkLongitudExacta_CheckedChanged);
			// 
			// TbLongitudMaxima
			// 
			this.TbLongitudMaxima.Location = new System.Drawing.Point(428, 98);
			this.TbLongitudMaxima.MaxLength = 2;
			this.TbLongitudMaxima.Name = "TbLongitudMaxima";
			this.TbLongitudMaxima.Size = new System.Drawing.Size(93, 28);
			this.TbLongitudMaxima.TabIndex = 11;
			this.TbLongitudMaxima.TipoCaracteres = CapaPresentacion.Controls.CustomTextBox.TipoInput.SoloNumeros;
			// 
			// TbLongitudMinima
			// 
			this.TbLongitudMinima.Location = new System.Drawing.Point(132, 98);
			this.TbLongitudMinima.MaxLength = 2;
			this.TbLongitudMinima.Name = "TbLongitudMinima";
			this.TbLongitudMinima.Size = new System.Drawing.Size(93, 28);
			this.TbLongitudMinima.TabIndex = 9;
			this.TbLongitudMinima.TipoCaracteres = CapaPresentacion.Controls.CustomTextBox.TipoInput.SoloNumeros;
			this.TbLongitudMinima.TextChanged += new System.EventHandler(this.TbLongitudMinima_TextChanged);
			// 
			// TbNombre
			// 
			this.TbNombre.Location = new System.Drawing.Point(132, 27);
			this.TbNombre.MaxLength = 50;
			this.TbNombre.Name = "TbNombre";
			this.TbNombre.Size = new System.Drawing.Size(389, 28);
			this.TbNombre.TabIndex = 7;
			// 
			// LbLongitudMaxima
			// 
			this.LbLongitudMaxima.AutoSize = true;
			this.LbLongitudMaxima.Location = new System.Drawing.Point(320, 101);
			this.LbLongitudMaxima.Name = "LbLongitudMaxima";
			this.LbLongitudMaxima.Size = new System.Drawing.Size(124, 21);
			this.LbLongitudMaxima.TabIndex = 10;
			this.LbLongitudMaxima.Text = "Longitud Máx. :";
			// 
			// LbLongitudMinima
			// 
			this.LbLongitudMinima.AutoSize = true;
			this.LbLongitudMinima.Location = new System.Drawing.Point(33, 101);
			this.LbLongitudMinima.Name = "LbLongitudMinima";
			this.LbLongitudMinima.Size = new System.Drawing.Size(115, 21);
			this.LbLongitudMinima.TabIndex = 8;
			this.LbLongitudMinima.Text = "Longitud Mín :";
			// 
			// LbNombre
			// 
			this.LbNombre.AutoSize = true;
			this.LbNombre.Location = new System.Drawing.Point(62, 30);
			this.LbNombre.Name = "LbNombre";
			this.LbNombre.Size = new System.Drawing.Size(79, 21);
			this.LbNombre.TabIndex = 6;
			this.LbNombre.Text = "Nombre :";
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
			this.label1.Text = "Mantenedor - Tipo de Documento de Identidad";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GbLista
			// 
			this.GbLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GbLista.Controls.Add(this.DgvTipoDocumentoIdentidad);
			this.GbLista.Location = new System.Drawing.Point(12, 271);
			this.GbLista.Name = "GbLista";
			this.GbLista.Size = new System.Drawing.Size(958, 377);
			this.GbLista.TabIndex = 6;
			this.GbLista.TabStop = false;
			this.GbLista.Text = "Lista de Tipos de Documento de Identidad";
			// 
			// DgvTipoDocumentoIdentidad
			// 
			this.DgvTipoDocumentoIdentidad.AllowUserToAddRows = false;
			this.DgvTipoDocumentoIdentidad.AllowUserToDeleteRows = false;
			this.DgvTipoDocumentoIdentidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DgvTipoDocumentoIdentidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgvTipoDocumentoIdentidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column6});
			this.DgvTipoDocumentoIdentidad.Location = new System.Drawing.Point(12, 25);
			this.DgvTipoDocumentoIdentidad.MultiSelect = false;
			this.DgvTipoDocumentoIdentidad.Name = "DgvTipoDocumentoIdentidad";
			this.DgvTipoDocumentoIdentidad.ReadOnly = true;
			this.DgvTipoDocumentoIdentidad.RowHeadersWidth = 51;
			this.DgvTipoDocumentoIdentidad.RowTemplate.Height = 24;
			this.DgvTipoDocumentoIdentidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DgvTipoDocumentoIdentidad.Size = new System.Drawing.Size(935, 338);
			this.DgvTipoDocumentoIdentidad.TabIndex = 0;
			// 
			// LbOpcion
			// 
			this.LbOpcion.BackColor = System.Drawing.SystemColors.Highlight;
			this.LbOpcion.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LbOpcion.ForeColor = System.Drawing.Color.White;
			this.LbOpcion.Location = new System.Drawing.Point(12, 228);
			this.LbOpcion.Name = "LbOpcion";
			this.LbOpcion.Size = new System.Drawing.Size(246, 30);
			this.LbOpcion.TabIndex = 2;
			this.LbOpcion.Text = "OPCIÓN : NUEVO / EDITAR / BUSCAR";
			this.LbOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BnGuardar
			// 
			this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnGuardar.Location = new System.Drawing.Point(321, 226);
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
			this.BnCancelar.Location = new System.Drawing.Point(440, 226);
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
			this.Column2.HeaderText = "Longitud Exacta";
			this.Column2.MinimumWidth = 6;
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 150;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Longitud Mínima";
			this.Column3.MinimumWidth = 6;
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column3.Width = 150;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Longitud Máxima";
			this.Column4.MinimumWidth = 6;
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column4.Width = 150;
			// 
			// Column5
			// 
			this.Column5.HeaderText = "Alfanumérico";
			this.Column5.MinimumWidth = 6;
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column5.Width = 150;
			// 
			// Column7
			// 
			this.Column7.HeaderText = "Persona Jurídica";
			this.Column7.MinimumWidth = 6;
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column7.Width = 150;
			// 
			// Column8
			// 
			this.Column8.HeaderText = "Consulta API";
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
			this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column6.Width = 125;
			// 
			// ChkConsultaAPI
			// 
			this.ChkConsultaAPI.AutoSize = true;
			this.ChkConsultaAPI.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkConsultaAPI.Location = new System.Drawing.Point(383, 135);
			this.ChkConsultaAPI.Name = "ChkConsultaAPI";
			this.ChkConsultaAPI.Size = new System.Drawing.Size(138, 25);
			this.ChkConsultaAPI.TabIndex = 18;
			this.ChkConsultaAPI.Text = "Consulta API :";
			this.ChkConsultaAPI.UseVisualStyleBackColor = true;
			// 
			// FrmTipoDocumentoIdentidad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 703);
			this.Controls.Add(this.BnSalir);
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
			this.Name = "FrmTipoDocumentoIdentidad";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Mantenedor - Tipo de Documento de Identidad";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTipoDocumentoIdentidad_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTipoDocumentoIdentidad_FormClosed);
			this.Load += new System.EventHandler(this.FrmTipoDocumentoIdentidad_Load);
			this.GbDatos.ResumeLayout(false);
			this.GbDatos.PerformLayout();
			this.GbLista.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DgvTipoDocumentoIdentidad)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbNombre;
        private Controls.CustomTextBox TbLongitudMaxima;
        private Controls.CustomTextBox TbLongitudMinima;
        private System.Windows.Forms.TextBox TbNombre;
        private System.Windows.Forms.Label LbLongitudMaxima;
        private System.Windows.Forms.Label LbLongitudMinima;
        private System.Windows.Forms.GroupBox GbLista;
        private System.Windows.Forms.Label LbOpcion;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnCancelar;
        private System.Windows.Forms.Button BnNuevo;
        private System.Windows.Forms.Button BnEditar;
        private System.Windows.Forms.Button BnDeshabilitar;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.DataGridView DgvTipoDocumentoIdentidad;
        private System.Windows.Forms.CheckBox ChkLongitudExacta;
        private System.Windows.Forms.CheckBox ChkPersonaJuridica;
        private System.Windows.Forms.CheckBox ChkAlfanumerico;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.CheckBox ChkConsultaAPI;
	}
}