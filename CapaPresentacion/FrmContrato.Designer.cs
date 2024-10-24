namespace CapaPresentacion
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
            this.LbTitulo = new System.Windows.Forms.Label();
            this.BnCancelar = new System.Windows.Forms.Button();
            this.BnGuardar = new System.Windows.Forms.Button();
            this.BnSalir = new System.Windows.Forms.Button();
            this.BnAnular = new System.Windows.Forms.Button();
            this.BnBuscar = new System.Windows.Forms.Button();
            this.BnNuevo = new System.Windows.Forms.Button();
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
            this.LbTitulo.Size = new System.Drawing.Size(1006, 41);
            this.LbTitulo.TabIndex = 1;
            this.LbTitulo.Text = "Registro de Contrato";
            this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnCancelar
            // 
            this.BnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnCancelar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnCancelar.Image = global::CapaPresentacion.Properties.Resources.Cancelar;
            this.BnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnCancelar.Location = new System.Drawing.Point(497, 686);
            this.BnCancelar.Name = "BnCancelar";
            this.BnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnCancelar.Size = new System.Drawing.Size(117, 31);
            this.BnCancelar.TabIndex = 16;
            this.BnCancelar.Text = "Cancelar";
            this.BnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnCancelar.UseVisualStyleBackColor = true;
            // 
            // BnGuardar
            // 
            this.BnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnGuardar.Image = global::CapaPresentacion.Properties.Resources.Guardar;
            this.BnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnGuardar.Location = new System.Drawing.Point(374, 686);
            this.BnGuardar.Name = "BnGuardar";
            this.BnGuardar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnGuardar.Size = new System.Drawing.Size(117, 31);
            this.BnGuardar.TabIndex = 15;
            this.BnGuardar.Text = "Guardar";
            this.BnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnGuardar.UseVisualStyleBackColor = true;
            // 
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = global::CapaPresentacion.Properties.Resources.Cerrar;
            this.BnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSalir.Location = new System.Drawing.Point(883, 686);
            this.BnSalir.Name = "BnSalir";
            this.BnSalir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSalir.Size = new System.Drawing.Size(117, 31);
            this.BnSalir.TabIndex = 17;
            this.BnSalir.Text = "Salir";
            this.BnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSalir.UseVisualStyleBackColor = true;
            // 
            // BnAnular
            // 
            this.BnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnAnular.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnAnular.Image = global::CapaPresentacion.Properties.Resources.Anular;
            this.BnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnAnular.Location = new System.Drawing.Point(251, 686);
            this.BnAnular.Name = "BnAnular";
            this.BnAnular.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnAnular.Size = new System.Drawing.Size(117, 31);
            this.BnAnular.TabIndex = 14;
            this.BnAnular.Text = "Anular";
            this.BnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnAnular.UseVisualStyleBackColor = true;
            // 
            // BnBuscar
            // 
            this.BnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscar.Image = global::CapaPresentacion.Properties.Resources.Buscar;
            this.BnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscar.Location = new System.Drawing.Point(128, 686);
            this.BnBuscar.Name = "BnBuscar";
            this.BnBuscar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscar.Size = new System.Drawing.Size(117, 31);
            this.BnBuscar.TabIndex = 13;
            this.BnBuscar.Text = "Buscar";
            this.BnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscar.UseVisualStyleBackColor = true;
            // 
            // BnNuevo
            // 
            this.BnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BnNuevo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnNuevo.Image = global::CapaPresentacion.Properties.Resources.Nuevo;
            this.BnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnNuevo.Location = new System.Drawing.Point(5, 686);
            this.BnNuevo.Name = "BnNuevo";
            this.BnNuevo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnNuevo.Size = new System.Drawing.Size(117, 31);
            this.BnNuevo.TabIndex = 12;
            this.BnNuevo.Text = "Nuevo";
            this.BnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnNuevo.UseVisualStyleBackColor = true;
            // 
            // FrmContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.BnCancelar);
            this.Controls.Add(this.BnGuardar);
            this.Controls.Add(this.BnSalir);
            this.Controls.Add(this.BnAnular);
            this.Controls.Add(this.BnBuscar);
            this.Controls.Add(this.BnNuevo);
            this.Controls.Add(this.LbTitulo);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmContrato";
            this.Text = "Registro de Contrato";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.Button BnCancelar;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.Button BnAnular;
        private System.Windows.Forms.Button BnBuscar;
        private System.Windows.Forms.Button BnNuevo;
    }
}