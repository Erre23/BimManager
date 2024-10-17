namespace CapaPresentacion
{
    partial class FrmPresupuestoAnular
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
            this.BnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TbMotivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbAnuladoPor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TbNumeroPresupuesto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.LbTitulo.Size = new System.Drawing.Size(723, 41);
            this.LbTitulo.TabIndex = 0;
            this.LbTitulo.Text = "Anulación de Presupuesto";
            this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnCancelar
            // 
            this.BnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnCancelar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnCancelar.Location = new System.Drawing.Point(599, 288);
            this.BnCancelar.Name = "BnCancelar";
            this.BnCancelar.Size = new System.Drawing.Size(117, 31);
            this.BnCancelar.TabIndex = 8;
            this.BnCancelar.Text = "Salir";
            this.BnCancelar.UseVisualStyleBackColor = true;
            this.BnCancelar.Click += new System.EventHandler(this.BnSalir_Click);
            // 
            // BnAceptar
            // 
            this.BnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnAceptar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnAceptar.Location = new System.Drawing.Point(476, 288);
            this.BnAceptar.Name = "BnAceptar";
            this.BnAceptar.Size = new System.Drawing.Size(117, 31);
            this.BnAceptar.TabIndex = 7;
            this.BnAceptar.Text = "Aceptar";
            this.BnAceptar.UseVisualStyleBackColor = true;
            this.BnAceptar.Click += new System.EventHandler(this.BnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbMotivo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TbAnuladoPor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TbNumeroPresupuesto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(701, 224);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Anulación";
            // 
            // TbMotivo
            // 
            this.TbMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMotivo.Location = new System.Drawing.Point(138, 93);
            this.TbMotivo.Multiline = true;
            this.TbMotivo.Name = "TbMotivo";
            this.TbMotivo.Size = new System.Drawing.Size(556, 124);
            this.TbMotivo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Motivo :";
            // 
            // TbAnuladoPor
            // 
            this.TbAnuladoPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbAnuladoPor.Location = new System.Drawing.Point(139, 59);
            this.TbAnuladoPor.Name = "TbAnuladoPor";
            this.TbAnuladoPor.ReadOnly = true;
            this.TbAnuladoPor.Size = new System.Drawing.Size(556, 28);
            this.TbAnuladoPor.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Anulado Por :";
            // 
            // TbNumeroPresupuesto
            // 
            this.TbNumeroPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbNumeroPresupuesto.Location = new System.Drawing.Point(139, 25);
            this.TbNumeroPresupuesto.Name = "TbNumeroPresupuesto";
            this.TbNumeroPresupuesto.ReadOnly = true;
            this.TbNumeroPresupuesto.Size = new System.Drawing.Size(215, 28);
            this.TbNumeroPresupuesto.TabIndex = 1;
            this.TbNumeroPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° Presupuesto :";
            // 
            // FrmPresupuestoAnular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 327);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BnAceptar);
            this.Controls.Add(this.BnCancelar);
            this.Controls.Add(this.LbTitulo);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPresupuestoAnular";
            this.Text = "Anulación de Presupuesto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPresupuestoAnular_FormClosing);
            this.Load += new System.EventHandler(this.FrmPresupuestoAnular_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.Button BnCancelar;
        private System.Windows.Forms.Button BnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TbAnuladoPor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbNumeroPresupuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbMotivo;
        private System.Windows.Forms.Label label2;
    }
}