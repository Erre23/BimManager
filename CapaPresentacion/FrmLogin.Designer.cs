namespace CapaPresentacion
{
    partial class FrmLogin
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
			this.label2 = new System.Windows.Forms.Label();
			this.TbPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BnIngresar = new System.Windows.Forms.Button();
			this.BnSalir = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.TbUsername = new CapaPresentacion.Controls.CustomTextBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(47, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Username :";
			// 
			// TbPassword
			// 
			this.TbPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TbPassword.Location = new System.Drawing.Point(160, 116);
			this.TbPassword.Name = "TbPassword";
			this.TbPassword.PasswordChar = '*';
			this.TbPassword.Size = new System.Drawing.Size(348, 30);
			this.TbPassword.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(53, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Password :";
			// 
			// BnIngresar
			// 
			this.BnIngresar.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnIngresar.Location = new System.Drawing.Point(160, 171);
			this.BnIngresar.Name = "BnIngresar";
			this.BnIngresar.Size = new System.Drawing.Size(146, 31);
			this.BnIngresar.TabIndex = 9;
			this.BnIngresar.Text = "Ingresar";
			this.BnIngresar.UseVisualStyleBackColor = true;
			this.BnIngresar.Click += new System.EventHandler(this.BnIngresar_Click);
			// 
			// BnSalir
			// 
			this.BnSalir.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BnSalir.Location = new System.Drawing.Point(312, 171);
			this.BnSalir.Name = "BnSalir";
			this.BnSalir.Size = new System.Drawing.Size(146, 31);
			this.BnSalir.TabIndex = 10;
			this.BnSalir.Text = "Salir";
			this.BnSalir.UseVisualStyleBackColor = true;
			this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.Highlight;
			this.label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(570, 36);
			this.label5.TabIndex = 11;
			this.label5.Text = "Inicio de Sesión";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TbUsername
			// 
			this.TbUsername.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TbUsername.Location = new System.Drawing.Point(160, 68);
			this.TbUsername.MaxLength = 50;
			this.TbUsername.Name = "TbUsername";
			this.TbUsername.Size = new System.Drawing.Size(348, 30);
			this.TbUsername.TabIndex = 3;
			this.TbUsername.TipoCaracteres = CapaPresentacion.Controls.CustomTextBox.TipoInput.Todo;
			// 
			// FrmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 219);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.BnSalir);
			this.Controls.Add(this.BnIngresar);
			this.Controls.Add(this.TbPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TbUsername);
			this.Controls.Add(this.label2);
			this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmLogin";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private Controls.CustomTextBox TbUsername;
        private System.Windows.Forms.TextBox TbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BnIngresar;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.Label label5;
    }
}