using BimManager.Client.WipApp.Controls;

namespace BimManager.Client.WipApp
{
    partial class FrmPrespuestoCategoriaModal
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
            this.TbPorcentaje = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.LbCelular = new System.Windows.Forms.Label();
            this.TbObservaciones = new System.Windows.Forms.TextBox();
            this.LbApellido1 = new System.Windows.Forms.Label();
            this.LbNombres = new System.Windows.Forms.Label();
            this.TbNombre = new System.Windows.Forms.TextBox();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.BnGuardar = new System.Windows.Forms.Button();
            this.BnCancelar = new System.Windows.Forms.Button();
            this.LbOpcion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TbCategoriaRaiz = new System.Windows.Forms.TextBox();
            this.GbDatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbDatos
            // 
            this.GbDatos.Controls.Add(this.TbPorcentaje);
            this.GbDatos.Controls.Add(this.LbCelular);
            this.GbDatos.Controls.Add(this.TbObservaciones);
            this.GbDatos.Controls.Add(this.LbApellido1);
            this.GbDatos.Controls.Add(this.LbNombres);
            this.GbDatos.Controls.Add(this.TbNombre);
            this.GbDatos.Location = new System.Drawing.Point(12, 93);
            this.GbDatos.Name = "GbDatos";
            this.GbDatos.Size = new System.Drawing.Size(782, 131);
            this.GbDatos.TabIndex = 0;
            this.GbDatos.TabStop = false;
            this.GbDatos.Text = "Datos de la Categoría";
            // 
            // TbPorcentaje
            // 
            this.TbPorcentaje.Location = new System.Drawing.Point(116, 94);
            this.TbPorcentaje.MaxLength = 50;
            this.TbPorcentaje.Name = "TbPorcentaje";
            this.TbPorcentaje.Size = new System.Drawing.Size(135, 28);
            this.TbPorcentaje.TabIndex = 5;
            this.TbPorcentaje.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // LbCelular
            // 
            this.LbCelular.AutoSize = true;
            this.LbCelular.Location = new System.Drawing.Point(12, 97);
            this.LbCelular.Name = "LbCelular";
            this.LbCelular.Size = new System.Drawing.Size(122, 21);
            this.LbCelular.TabIndex = 4;
            this.LbCelular.Text = "Porcentaje % :";
            // 
            // TbObservaciones
            // 
            this.TbObservaciones.Location = new System.Drawing.Point(116, 59);
            this.TbObservaciones.MaxLength = 50;
            this.TbObservaciones.Name = "TbObservaciones";
            this.TbObservaciones.Size = new System.Drawing.Size(657, 28);
            this.TbObservaciones.TabIndex = 3;
            // 
            // LbApellido1
            // 
            this.LbApellido1.AutoSize = true;
            this.LbApellido1.Location = new System.Drawing.Point(7, 62);
            this.LbApellido1.Name = "LbApellido1";
            this.LbApellido1.Size = new System.Drawing.Size(129, 21);
            this.LbApellido1.TabIndex = 2;
            this.LbApellido1.Text = "Observaciones :";
            // 
            // LbNombres
            // 
            this.LbNombres.AutoSize = true;
            this.LbNombres.Location = new System.Drawing.Point(47, 26);
            this.LbNombres.Name = "LbNombres";
            this.LbNombres.Size = new System.Drawing.Size(79, 21);
            this.LbNombres.TabIndex = 0;
            this.LbNombres.Text = "Nombre :";
            // 
            // TbNombre
            // 
            this.TbNombre.Location = new System.Drawing.Point(116, 23);
            this.TbNombre.MaxLength = 250;
            this.TbNombre.Name = "TbNombre";
            this.TbNombre.Size = new System.Drawing.Size(657, 28);
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
            this.LbTitulo.Size = new System.Drawing.Size(806, 30);
            this.LbTitulo.TabIndex = 4;
            this.LbTitulo.Text = "Presupuesto Categoría - ";
            this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnGuardar
            // 
            this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnGuardar.Image = global::BimManager.Client.WipApp.Properties.Resources.Guardar;
            this.BnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnGuardar.Location = new System.Drawing.Point(558, 230);
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
            this.BnCancelar.Image = global::BimManager.Client.WipApp.Properties.Resources.Cancelar;
            this.BnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnCancelar.Location = new System.Drawing.Point(677, 230);
            this.BnCancelar.Name = "BnCancelar";
            this.BnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnCancelar.Size = new System.Drawing.Size(110, 35);
            this.BnCancelar.TabIndex = 3;
            this.BnCancelar.Text = "Cancelar";
            this.BnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnCancelar.UseVisualStyleBackColor = true;
            this.BnCancelar.Click += new System.EventHandler(this.BnCancelar_Click);
            // 
            // LbOpcion
            // 
            this.LbOpcion.BackColor = System.Drawing.SystemColors.Highlight;
            this.LbOpcion.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbOpcion.ForeColor = System.Drawing.Color.White;
            this.LbOpcion.Location = new System.Drawing.Point(12, 232);
            this.LbOpcion.Name = "LbOpcion";
            this.LbOpcion.Size = new System.Drawing.Size(381, 30);
            this.LbOpcion.TabIndex = 1;
            this.LbOpcion.Text = "OPCIÓN : NUEVO / EDITAR / BUSCAR";
            this.LbOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbCategoriaRaiz);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 54);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categoría Raiz :";
            // 
            // TbCategoriaRaiz
            // 
            this.TbCategoriaRaiz.Location = new System.Drawing.Point(12, 23);
            this.TbCategoriaRaiz.MaxLength = 250;
            this.TbCategoriaRaiz.Name = "TbCategoriaRaiz";
            this.TbCategoriaRaiz.ReadOnly = true;
            this.TbCategoriaRaiz.Size = new System.Drawing.Size(761, 28);
            this.TbCategoriaRaiz.TabIndex = 0;
            // 
            // FrmPrespuestoCategoriaModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 277);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BnCancelar);
            this.Controls.Add(this.BnGuardar);
            this.Controls.Add(this.LbOpcion);
            this.Controls.Add(this.LbTitulo);
            this.Controls.Add(this.GbDatos);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrespuestoCategoriaModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Presupuesto Categoría - ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCliente_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrespuestoCategoriaModal_Load);
            this.GbDatos.ResumeLayout(false);
            this.GbDatos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbDatos;
        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.Label LbNombres;
        private System.Windows.Forms.TextBox TbObservaciones;
        private System.Windows.Forms.Label LbApellido1;
        private System.Windows.Forms.TextBox TbNombre;
        private CustomTextBox TbPorcentaje;
        private System.Windows.Forms.Label LbCelular;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnCancelar;
        private System.Windows.Forms.Label LbOpcion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TbCategoriaRaiz;
    }
}