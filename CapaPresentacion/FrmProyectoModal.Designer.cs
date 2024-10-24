namespace CapaPresentacion
{
    partial class FrmProyectoModal
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LbOpcion = new System.Windows.Forms.Label();
            this.BnGuardar = new System.Windows.Forms.Button();
            this.BnCancelar = new System.Windows.Forms.Button();
            this.GbDatos_Cliente = new System.Windows.Forms.GroupBox();
            this.TbDocumentoIdentidadTipo = new CapaPresentacion.Controls.CustomTextBox();
            this.TbDocumentoIdentidadNumero = new CapaPresentacion.Controls.CustomTextBox();
            this.TbCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GbDatos_Proyecto.SuspendLayout();
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
            this.GbDatos_Proyecto.TabIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(971, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mantenedor - Proyecto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbOpcion
            // 
            this.LbOpcion.BackColor = System.Drawing.SystemColors.Highlight;
            this.LbOpcion.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbOpcion.ForeColor = System.Drawing.Color.White;
            this.LbOpcion.Location = new System.Drawing.Point(12, 334);
            this.LbOpcion.Name = "LbOpcion";
            this.LbOpcion.Size = new System.Drawing.Size(381, 30);
            this.LbOpcion.TabIndex = 1;
            this.LbOpcion.Text = "OPCIÓN : NUEVO / EDITAR / BUSCAR";
            this.LbOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnGuardar
            // 
            this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnGuardar.Image = global::CapaPresentacion.Properties.Resources.Guardar;
            this.BnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnGuardar.Location = new System.Drawing.Point(731, 332);
            this.BnGuardar.Name = "BnGuardar";
            this.BnGuardar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnGuardar.Size = new System.Drawing.Size(110, 35);
            this.BnGuardar.TabIndex = 2;
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
            this.BnCancelar.Location = new System.Drawing.Point(850, 332);
            this.BnCancelar.Name = "BnCancelar";
            this.BnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnCancelar.Size = new System.Drawing.Size(110, 35);
            this.BnCancelar.TabIndex = 3;
            this.BnCancelar.Text = "Cancelar";
            this.BnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnCancelar.UseVisualStyleBackColor = true;
            this.BnCancelar.Click += new System.EventHandler(this.BnCancelar_Click);
            // 
            // GbDatos_Cliente
            // 
            this.GbDatos_Cliente.Controls.Add(this.TbDocumentoIdentidadTipo);
            this.GbDatos_Cliente.Controls.Add(this.TbDocumentoIdentidadNumero);
            this.GbDatos_Cliente.Controls.Add(this.TbCliente);
            this.GbDatos_Cliente.Controls.Add(this.label11);
            this.GbDatos_Cliente.Controls.Add(this.label2);
            this.GbDatos_Cliente.Controls.Add(this.label3);
            this.GbDatos_Cliente.Location = new System.Drawing.Point(12, 35);
            this.GbDatos_Cliente.Name = "GbDatos_Cliente";
            this.GbDatos_Cliente.Size = new System.Drawing.Size(947, 103);
            this.GbDatos_Cliente.TabIndex = 5;
            this.GbDatos_Cliente.TabStop = false;
            this.GbDatos_Cliente.Text = "Datos del Cliente";
            // 
            // TbDocumentoIdentidadTipo
            // 
            this.TbDocumentoIdentidadTipo.Location = new System.Drawing.Point(152, 27);
            this.TbDocumentoIdentidadTipo.Name = "TbDocumentoIdentidadTipo";
            this.TbDocumentoIdentidadTipo.ReadOnly = true;
            this.TbDocumentoIdentidadTipo.Size = new System.Drawing.Size(228, 28);
            this.TbDocumentoIdentidadTipo.TabIndex = 1;
            this.TbDocumentoIdentidadTipo.TipoCaracteres = CapaPresentacion.Controls.CustomTextBox.TipoInput.Todo;
            // 
            // TbDocumentoIdentidadNumero
            // 
            this.TbDocumentoIdentidadNumero.Location = new System.Drawing.Point(546, 27);
            this.TbDocumentoIdentidadNumero.Name = "TbDocumentoIdentidadNumero";
            this.TbDocumentoIdentidadNumero.ReadOnly = true;
            this.TbDocumentoIdentidadNumero.Size = new System.Drawing.Size(228, 28);
            this.TbDocumentoIdentidadNumero.TabIndex = 3;
            this.TbDocumentoIdentidadNumero.TipoCaracteres = CapaPresentacion.Controls.CustomTextBox.TipoInput.Todo;
            // 
            // TbCliente
            // 
            this.TbCliente.Location = new System.Drawing.Point(153, 65);
            this.TbCliente.MaxLength = 250;
            this.TbCliente.Name = "TbCliente";
            this.TbCliente.ReadOnly = true;
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
            // FrmProyectoModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 376);
            this.Controls.Add(this.GbDatos_Cliente);
            this.Controls.Add(this.BnCancelar);
            this.Controls.Add(this.BnGuardar);
            this.Controls.Add(this.LbOpcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GbDatos_Proyecto);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProyectoModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mantenedor - Proyecto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProyecto_FormClosing);
            this.Load += new System.EventHandler(this.FrmProyecto_Load);
            this.GbDatos_Proyecto.ResumeLayout(false);
            this.GbDatos_Proyecto.PerformLayout();
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
        private System.Windows.Forms.Label LbApellido2;
        private System.Windows.Forms.Label LbApellido1;
        private System.Windows.Forms.Label LbOpcion;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnCancelar;
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
        private Controls.CustomTextBox TbDocumentoIdentidadTipo;
    }
}