namespace BimManager.Client.WipApp
{
    partial class FrmTipoDocumentoSunat
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
            this.TbCodigoSunat = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.TbNombre = new System.Windows.Forms.TextBox();
            this.LbLongitudMinima = new System.Windows.Forms.Label();
            this.LbNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GbLista = new System.Windows.Forms.GroupBox();
            this.DgvTipoDocumentoSunat = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LbOpcion = new System.Windows.Forms.Label();
            this.BnGuardar = new System.Windows.Forms.Button();
            this.BnCancelar = new System.Windows.Forms.Button();
            this.BnNuevo = new System.Windows.Forms.Button();
            this.BnEditar = new System.Windows.Forms.Button();
            this.BnDeshabilitar = new System.Windows.Forms.Button();
            this.BnSalir = new System.Windows.Forms.Button();
            this.GbDatos.SuspendLayout();
            this.GbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTipoDocumentoSunat)).BeginInit();
            this.SuspendLayout();
            // 
            // GbDatos
            // 
            this.GbDatos.Controls.Add(this.TbCodigoSunat);
            this.GbDatos.Controls.Add(this.TbNombre);
            this.GbDatos.Controls.Add(this.LbLongitudMinima);
            this.GbDatos.Controls.Add(this.LbNombre);
            this.GbDatos.Location = new System.Drawing.Point(12, 47);
            this.GbDatos.Name = "GbDatos";
            this.GbDatos.Size = new System.Drawing.Size(536, 97);
            this.GbDatos.TabIndex = 1;
            this.GbDatos.TabStop = false;
            this.GbDatos.Text = "Datos del Tipo de Documento de Sunat";
            // 
            // TbCodigoSunat
            // 
            this.TbCodigoSunat.Location = new System.Drawing.Point(133, 57);
            this.TbCodigoSunat.MaxLength = 2;
            this.TbCodigoSunat.Name = "TbCodigoSunat";
            this.TbCodigoSunat.Size = new System.Drawing.Size(93, 28);
            this.TbCodigoSunat.TabIndex = 9;
            this.TbCodigoSunat.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // TbNombre
            // 
            this.TbNombre.Location = new System.Drawing.Point(132, 27);
            this.TbNombre.MaxLength = 50;
            this.TbNombre.Name = "TbNombre";
            this.TbNombre.Size = new System.Drawing.Size(389, 28);
            this.TbNombre.TabIndex = 7;
            // 
            // LbLongitudMinima
            // 
            this.LbLongitudMinima.AutoSize = true;
            this.LbLongitudMinima.Location = new System.Drawing.Point(28, 60);
            this.LbLongitudMinima.Name = "LbLongitudMinima";
            this.LbLongitudMinima.Size = new System.Drawing.Size(118, 21);
            this.LbLongitudMinima.TabIndex = 8;
            this.LbLongitudMinima.Text = "Código Sunat :";
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
            this.label1.Text = "Mantenedor - Tipo de Documento de Sunat";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GbLista
            // 
            this.GbLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbLista.Controls.Add(this.DgvTipoDocumentoSunat);
            this.GbLista.Location = new System.Drawing.Point(12, 196);
            this.GbLista.Name = "GbLista";
            this.GbLista.Size = new System.Drawing.Size(958, 452);
            this.GbLista.TabIndex = 6;
            this.GbLista.TabStop = false;
            this.GbLista.Text = "Lista de Tipos de Sunat";
            // 
            // DgvTipoDocumentoSunat
            // 
            this.DgvTipoDocumentoSunat.AllowUserToAddRows = false;
            this.DgvTipoDocumentoSunat.AllowUserToDeleteRows = false;
            this.DgvTipoDocumentoSunat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvTipoDocumentoSunat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTipoDocumentoSunat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column6});
            this.DgvTipoDocumentoSunat.Location = new System.Drawing.Point(12, 25);
            this.DgvTipoDocumentoSunat.MultiSelect = false;
            this.DgvTipoDocumentoSunat.Name = "DgvTipoDocumentoSunat";
            this.DgvTipoDocumentoSunat.ReadOnly = true;
            this.DgvTipoDocumentoSunat.RowHeadersWidth = 51;
            this.DgvTipoDocumentoSunat.RowTemplate.Height = 24;
            this.DgvTipoDocumentoSunat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTipoDocumentoSunat.Size = new System.Drawing.Size(935, 413);
            this.DgvTipoDocumentoSunat.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 170;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Código Sunat";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 150;
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
            // LbOpcion
            // 
            this.LbOpcion.BackColor = System.Drawing.SystemColors.Highlight;
            this.LbOpcion.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbOpcion.ForeColor = System.Drawing.Color.White;
            this.LbOpcion.Location = new System.Drawing.Point(12, 157);
            this.LbOpcion.Name = "LbOpcion";
            this.LbOpcion.Size = new System.Drawing.Size(246, 30);
            this.LbOpcion.TabIndex = 2;
            this.LbOpcion.Text = "OPCIÓN : NUEVO / EDITAR / BUSCAR";
            this.LbOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnGuardar
            // 
            this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnGuardar.Image = global::BimManager.Client.WipApp.Properties.Resources.Guardar;
            this.BnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnGuardar.Location = new System.Drawing.Point(321, 155);
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
            this.BnCancelar.Image = global::BimManager.Client.WipApp.Properties.Resources.Cancelar;
            this.BnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnCancelar.Location = new System.Drawing.Point(440, 155);
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
            this.BnNuevo.Image = global::BimManager.Client.WipApp.Properties.Resources.Nuevo;
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
            this.BnEditar.Image = global::BimManager.Client.WipApp.Properties.Resources.Editar;
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
            this.BnDeshabilitar.Image = global::BimManager.Client.WipApp.Properties.Resources.Anular;
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
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = global::BimManager.Client.WipApp.Properties.Resources.Cerrar;
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
            // FrmTipoDocumentoSunat
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
            this.Name = "FrmTipoDocumentoSunat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mantenedor - Tipo de Documento de Sunat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTipoDocumentoSunat_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTipoDocumentoSunat_FormClosed);
            this.Load += new System.EventHandler(this.FrmTipoDocumentoSunat_Load);
            this.GbDatos.ResumeLayout(false);
            this.GbDatos.PerformLayout();
            this.GbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTipoDocumentoSunat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbNombre;
        private Controls.CustomTextBox TbCodigoSunat;
        private System.Windows.Forms.TextBox TbNombre;
        private System.Windows.Forms.Label LbLongitudMinima;
        private System.Windows.Forms.GroupBox GbLista;
        private System.Windows.Forms.Label LbOpcion;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnCancelar;
        private System.Windows.Forms.Button BnNuevo;
        private System.Windows.Forms.Button BnEditar;
        private System.Windows.Forms.Button BnDeshabilitar;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.DataGridView DgvTipoDocumentoSunat;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
	}
}