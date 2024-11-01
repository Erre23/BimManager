namespace BimManager.Client.WipApp
{
    partial class FrmEmailEnviar
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
            this.TbEmail = new System.Windows.Forms.TextBox();
            this.LbEmail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BnSalir = new System.Windows.Forms.Button();
            this.BnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbEmail
            // 
            this.TbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbEmail.Location = new System.Drawing.Point(16, 74);
            this.TbEmail.MaxLength = 100;
            this.TbEmail.Name = "TbEmail";
            this.TbEmail.Size = new System.Drawing.Size(623, 28);
            this.TbEmail.TabIndex = 2;
            // 
            // LbEmail
            // 
            this.LbEmail.AutoSize = true;
            this.LbEmail.Location = new System.Drawing.Point(12, 43);
            this.LbEmail.Name = "LbEmail";
            this.LbEmail.Size = new System.Drawing.Size(627, 21);
            this.LbEmail.TabIndex = 1;
            this.LbEmail.Text = "Ingrese la dirección de correo electrónico, si es más de uno sepárelos con coma \"" +
    ",\"";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(652, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enviar datos de Comprobante de Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = global::BimManager.Client.WipApp.Properties.Resources.Cerrar;
            this.BnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSalir.Location = new System.Drawing.Point(530, 113);
            this.BnSalir.Name = "BnSalir";
            this.BnSalir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSalir.Size = new System.Drawing.Size(110, 35);
            this.BnSalir.TabIndex = 4;
            this.BnSalir.Text = "Salir";
            this.BnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSalir.UseVisualStyleBackColor = true;
            this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
            // 
            // BnEnviar
            // 
            this.BnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnEnviar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnEnviar.Image = global::BimManager.Client.WipApp.Properties.Resources.Enviar;
            this.BnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnEnviar.Location = new System.Drawing.Point(414, 113);
            this.BnEnviar.Name = "BnEnviar";
            this.BnEnviar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnEnviar.Size = new System.Drawing.Size(110, 35);
            this.BnEnviar.TabIndex = 3;
            this.BnEnviar.Text = "Enviar";
            this.BnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnEnviar.UseVisualStyleBackColor = true;
            this.BnEnviar.Click += new System.EventHandler(this.BnEnviar_Click);
            // 
            // FrmEmailEnviar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 160);
            this.Controls.Add(this.TbEmail);
            this.Controls.Add(this.LbEmail);
            this.Controls.Add(this.BnSalir);
            this.Controls.Add(this.BnEnviar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmEmailEnviar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Enviar datos de Comprobante de Pago";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEmailEnviar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbEmail;
        private System.Windows.Forms.Label LbEmail;
        private System.Windows.Forms.Button BnEnviar;
        private System.Windows.Forms.Button BnSalir;
	}
}