namespace BimManager.Client.WipApp
{
    partial class FrmContratoPagoRegistrar
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
            this.DtpPagoFecha = new System.Windows.Forms.DateTimePicker();
            this.TbImporte = new BimManager.Client.WipApp.Controls.CustomTextBox();
            this.LbCelular = new System.Windows.Forms.Label();
            this.TbNumeroOperacion = new System.Windows.Forms.TextBox();
            this.CbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.LbApellido2 = new System.Windows.Forms.Label();
            this.LbApellido1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BnGuardar = new System.Windows.Forms.Button();
            this.BnCancelar = new System.Windows.Forms.Button();
            this.LbOpcion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbSerie = new System.Windows.Forms.TextBox();
            this.CbTipoComprobantePago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GbDatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbDatos
            // 
            this.GbDatos.Controls.Add(this.DtpPagoFecha);
            this.GbDatos.Controls.Add(this.TbImporte);
            this.GbDatos.Controls.Add(this.LbCelular);
            this.GbDatos.Controls.Add(this.TbNumeroOperacion);
            this.GbDatos.Controls.Add(this.CbCuentaBancaria);
            this.GbDatos.Controls.Add(this.LbApellido2);
            this.GbDatos.Controls.Add(this.LbApellido1);
            this.GbDatos.Controls.Add(this.label2);
            this.GbDatos.Location = new System.Drawing.Point(8, 36);
            this.GbDatos.Name = "GbDatos";
            this.GbDatos.Size = new System.Drawing.Size(790, 86);
            this.GbDatos.TabIndex = 1;
            this.GbDatos.TabStop = false;
            this.GbDatos.Text = "Datos del Pago :";
            // 
            // DtpPagoFecha
            // 
            this.DtpPagoFecha.CustomFormat = "dddd dd/MM/yyyy";
            this.DtpPagoFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpPagoFecha.Location = new System.Drawing.Point(406, 52);
            this.DtpPagoFecha.Name = "DtpPagoFecha";
            this.DtpPagoFecha.Size = new System.Drawing.Size(178, 24);
            this.DtpPagoFecha.TabIndex = 16;
            // 
            // TbImporte
            // 
            this.TbImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbImporte.Location = new System.Drawing.Point(683, 52);
            this.TbImporte.MaxLength = 50;
            this.TbImporte.Name = "TbImporte";
            this.TbImporte.Size = new System.Drawing.Size(100, 24);
            this.TbImporte.TabIndex = 13;
            this.TbImporte.TipoCaracteres = BimManager.Client.WipApp.Controls.CustomTextBox.TipoInput.SoloNumeros;
            // 
            // LbCelular
            // 
            this.LbCelular.AutoSize = true;
            this.LbCelular.Location = new System.Drawing.Point(613, 55);
            this.LbCelular.Name = "LbCelular";
            this.LbCelular.Size = new System.Drawing.Size(66, 17);
            this.LbCelular.TabIndex = 12;
            this.LbCelular.Text = "Importe :";
            // 
            // TbNumeroOperacion
            // 
            this.TbNumeroOperacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbNumeroOperacion.Location = new System.Drawing.Point(126, 52);
            this.TbNumeroOperacion.MaxLength = 20;
            this.TbNumeroOperacion.Name = "TbNumeroOperacion";
            this.TbNumeroOperacion.Size = new System.Drawing.Size(178, 24);
            this.TbNumeroOperacion.TabIndex = 9;
            // 
            // CbCuentaBancaria
            // 
            this.CbCuentaBancaria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbCuentaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCuentaBancaria.FormattingEnabled = true;
            this.CbCuentaBancaria.Location = new System.Drawing.Point(126, 20);
            this.CbCuentaBancaria.Name = "CbCuentaBancaria";
            this.CbCuentaBancaria.Size = new System.Drawing.Size(658, 25);
            this.CbCuentaBancaria.TabIndex = 1;
            // 
            // LbApellido2
            // 
            this.LbApellido2.AutoSize = true;
            this.LbApellido2.Location = new System.Drawing.Point(314, 55);
            this.LbApellido2.Name = "LbApellido2";
            this.LbApellido2.Size = new System.Drawing.Size(88, 17);
            this.LbApellido2.TabIndex = 10;
            this.LbApellido2.Text = "Fecha Pago :";
            // 
            // LbApellido1
            // 
            this.LbApellido1.AutoSize = true;
            this.LbApellido1.Location = new System.Drawing.Point(23, 55);
            this.LbApellido1.Name = "LbApellido1";
            this.LbApellido1.Size = new System.Drawing.Size(99, 17);
            this.LbApellido1.TabIndex = 8;
            this.LbApellido1.Text = "Nº Operación :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cuenta Bancaria :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(806, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pagos - Registro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnGuardar
            // 
            this.BnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnGuardar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnGuardar.Image = global::BimManager.Client.WipApp.Properties.Resources.Guardar;
            this.BnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnGuardar.Location = new System.Drawing.Point(574, 219);
            this.BnGuardar.Name = "BnGuardar";
            this.BnGuardar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnGuardar.Size = new System.Drawing.Size(110, 31);
            this.BnGuardar.TabIndex = 3;
            this.BnGuardar.Text = "Guardar";
            this.BnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnGuardar.UseVisualStyleBackColor = true;
            this.BnGuardar.Click += new System.EventHandler(this.BnGuardar_Click);
            // 
            // BnCancelar
            // 
            this.BnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnCancelar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnCancelar.Image = global::BimManager.Client.WipApp.Properties.Resources.Cancelar;
            this.BnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnCancelar.Location = new System.Drawing.Point(688, 219);
            this.BnCancelar.Name = "BnCancelar";
            this.BnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnCancelar.Size = new System.Drawing.Size(110, 31);
            this.BnCancelar.TabIndex = 4;
            this.BnCancelar.Text = "Cancelar";
            this.BnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnCancelar.UseVisualStyleBackColor = true;
            this.BnCancelar.Click += new System.EventHandler(this.BnCancelar_Click);
            // 
            // LbOpcion
            // 
            this.LbOpcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LbOpcion.BackColor = System.Drawing.SystemColors.Highlight;
            this.LbOpcion.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbOpcion.ForeColor = System.Drawing.Color.White;
            this.LbOpcion.Location = new System.Drawing.Point(5, 219);
            this.LbOpcion.Name = "LbOpcion";
            this.LbOpcion.Size = new System.Drawing.Size(381, 30);
            this.LbOpcion.TabIndex = 2;
            this.LbOpcion.Text = "OPCIÓN : NUEVO / EDITAR / BUSCAR";
            this.LbOpcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TbSerie);
            this.groupBox1.Controls.Add(this.CbTipoComprobantePago);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(8, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 84);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Comprobante de Pago :";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(126, 51);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(658, 24);
            this.textBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cliente :";
            // 
            // TbSerie
            // 
            this.TbSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSerie.Location = new System.Drawing.Point(365, 20);
            this.TbSerie.MaxLength = 20;
            this.TbSerie.Name = "TbSerie";
            this.TbSerie.Size = new System.Drawing.Size(81, 24);
            this.TbSerie.TabIndex = 9;
            // 
            // CbTipoComprobantePago
            // 
            this.CbTipoComprobantePago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbTipoComprobantePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTipoComprobantePago.FormattingEnabled = true;
            this.CbTipoComprobantePago.Location = new System.Drawing.Point(126, 20);
            this.CbTipoComprobantePago.Name = "CbTipoComprobantePago";
            this.CbTipoComprobantePago.Size = new System.Drawing.Size(178, 25);
            this.CbTipoComprobantePago.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Serie :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tipo Comprob. :";
            // 
            // FrmContratoPagoRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 258);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BnCancelar);
            this.Controls.Add(this.BnGuardar);
            this.Controls.Add(this.LbOpcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GbDatos);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContratoPagoRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pagos - Registro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCliente_FormClosing);
            this.Load += new System.EventHandler(this.FrmContratoPagoRegistrar_Load);
            this.GbDatos.ResumeLayout(false);
            this.GbDatos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbNumeroOperacion;
        private System.Windows.Forms.ComboBox CbCuentaBancaria;
        private System.Windows.Forms.Label LbApellido2;
        private System.Windows.Forms.Label LbApellido1;
        private Controls.CustomTextBox TbImporte;
        private System.Windows.Forms.Label LbCelular;
        private System.Windows.Forms.Button BnGuardar;
        private System.Windows.Forms.Button BnCancelar;
        private System.Windows.Forms.Label LbOpcion;
        private System.Windows.Forms.DateTimePicker DtpPagoFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbSerie;
        private System.Windows.Forms.ComboBox CbTipoComprobantePago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}