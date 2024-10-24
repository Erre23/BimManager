using CapaPresentacion.Controls;

namespace CapaPresentacion
{
    partial class FrmPrespuestoCategoriaBuscar
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
            this.LbNombres = new System.Windows.Forms.Label();
            this.TbNombre = new System.Windows.Forms.TextBox();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.BnBuscar = new System.Windows.Forms.Button();
            this.BnCerrar = new System.Windows.Forms.Button();
            this.BnSiguiente = new System.Windows.Forms.Button();
            this.GbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbDatos
            // 
            this.GbDatos.Controls.Add(this.LbNombres);
            this.GbDatos.Controls.Add(this.TbNombre);
            this.GbDatos.Location = new System.Drawing.Point(6, 33);
            this.GbDatos.Name = "GbDatos";
            this.GbDatos.Size = new System.Drawing.Size(782, 58);
            this.GbDatos.TabIndex = 1;
            this.GbDatos.TabStop = false;
            this.GbDatos.Text = "Dato de búsqueda";
            // 
            // LbNombres
            // 
            this.LbNombres.AutoSize = true;
            this.LbNombres.Location = new System.Drawing.Point(8, 26);
            this.LbNombres.Name = "LbNombres";
            this.LbNombres.Size = new System.Drawing.Size(79, 21);
            this.LbNombres.TabIndex = 0;
            this.LbNombres.Text = "Nombre :";
            // 
            // TbNombre
            // 
            this.TbNombre.Location = new System.Drawing.Point(78, 23);
            this.TbNombre.MaxLength = 250;
            this.TbNombre.Name = "TbNombre";
            this.TbNombre.Size = new System.Drawing.Size(695, 28);
            this.TbNombre.TabIndex = 1;
            // 
            // LbTitulo
            // 
            this.LbTitulo.BackColor = System.Drawing.SystemColors.Highlight;
            this.LbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LbTitulo.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulo.ForeColor = System.Drawing.Color.White;
            this.LbTitulo.Location = new System.Drawing.Point(0, 0);
            this.LbTitulo.Name = "LbTitulo";
            this.LbTitulo.Size = new System.Drawing.Size(797, 30);
            this.LbTitulo.TabIndex = 0;
            this.LbTitulo.Text = "Presupuesto Categoría - Buscar";
            this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnBuscar
            // 
            this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscar.Image = global::CapaPresentacion.Properties.Resources.Filtrar;
            this.BnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscar.Location = new System.Drawing.Point(438, 97);
            this.BnBuscar.Name = "BnBuscar";
            this.BnBuscar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscar.Size = new System.Drawing.Size(110, 35);
            this.BnBuscar.TabIndex = 3;
            this.BnBuscar.Text = "Buscar";
            this.BnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscar.UseVisualStyleBackColor = true;
            this.BnBuscar.Click += new System.EventHandler(this.BnBuscar_Click);
            // 
            // BnCerrar
            // 
            this.BnCerrar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnCerrar.Image = global::CapaPresentacion.Properties.Resources.Cerrar;
            this.BnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnCerrar.Location = new System.Drawing.Point(678, 97);
            this.BnCerrar.Name = "BnCerrar";
            this.BnCerrar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnCerrar.Size = new System.Drawing.Size(110, 35);
            this.BnCerrar.TabIndex = 6;
            this.BnCerrar.Text = "Cerrar";
            this.BnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnCerrar.UseVisualStyleBackColor = true;
            this.BnCerrar.Click += new System.EventHandler(this.BnCerrar_Click);
            // 
            // BnSiguiente
            // 
            this.BnSiguiente.Enabled = false;
            this.BnSiguiente.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSiguiente.Image = global::CapaPresentacion.Properties.Resources.foward;
            this.BnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSiguiente.Location = new System.Drawing.Point(554, 97);
            this.BnSiguiente.Name = "BnSiguiente";
            this.BnSiguiente.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSiguiente.Size = new System.Drawing.Size(118, 35);
            this.BnSiguiente.TabIndex = 5;
            this.BnSiguiente.Text = "Siguiente";
            this.BnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSiguiente.UseVisualStyleBackColor = true;
            this.BnSiguiente.Click += new System.EventHandler(this.BnSiguiente_Click);
            // 
            // FrmPrespuestoCategoriaBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 140);
            this.Controls.Add(this.BnSiguiente);
            this.Controls.Add(this.BnCerrar);
            this.Controls.Add(this.BnBuscar);
            this.Controls.Add(this.LbTitulo);
            this.Controls.Add(this.GbDatos);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrespuestoCategoriaBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Presupuesto Categoría - Buscar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrespuestoCategoriaBuscar_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrespuestoCategoriaModal_Load);
            this.GbDatos.ResumeLayout(false);
            this.GbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbDatos;
        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.Label LbNombres;
        private System.Windows.Forms.TextBox TbNombre;
        private System.Windows.Forms.Button BnBuscar;
        private System.Windows.Forms.Button BnCerrar;
        private System.Windows.Forms.Button BnSiguiente;
    }
}