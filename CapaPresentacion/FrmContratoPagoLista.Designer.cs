namespace BimManager.Client.WipApp
{
    partial class FrmContratoPagoLista
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.DgvContratoPago = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enviarASUNATMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultaCdrASunatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerDatosCDRMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparadorObservacion = new System.Windows.Forms.ToolStripSeparator();
            this.DocumentoXmlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentoPdfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CdrXmlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparadorEmail = new System.Windows.Forms.ToolStripSeparator();
            this.enviarEmailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BnAnular = new System.Windows.Forms.Button();
            this.BnNuevo = new System.Windows.Forms.Button();
            this.BnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvContratoPago)).BeginInit();
            this.CmsOpciones.SuspendLayout();
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
            this.LbTitulo.Size = new System.Drawing.Size(1241, 34);
            this.LbTitulo.TabIndex = 0;
            this.LbTitulo.Text = "Pagos";
            this.LbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvContratoPago
            // 
            this.DgvContratoPago.AllowUserToAddRows = false;
            this.DgvContratoPago.AllowUserToDeleteRows = false;
            this.DgvContratoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvContratoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvContratoPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.DgvContratoPago.Location = new System.Drawing.Point(9, 43);
            this.DgvContratoPago.MultiSelect = false;
            this.DgvContratoPago.Name = "DgvContratoPago";
            this.DgvContratoPago.RowHeadersWidth = 51;
            this.DgvContratoPago.RowTemplate.Height = 24;
            this.DgvContratoPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvContratoPago.Size = new System.Drawing.Size(1224, 422);
            this.DgvContratoPago.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cta. Bancaria";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nº Operación";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Fecha";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Importe S/";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "T. Comprobante";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Serie-Correlativo";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Estado";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Nota De Crédito";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 150;
            // 
            // CmsOpciones
            // 
            this.CmsOpciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarASUNATMenuItem,
            this.ConsultaCdrASunatMenuItem,
            this.VerDatosCDRMenuItem,
            this.SeparadorObservacion,
            this.DocumentoXmlMenuItem,
            this.DocumentoPdfMenuItem,
            this.CdrXmlMenuItem,
            this.SeparadorEmail,
            this.enviarEmailMenuItem});
            this.CmsOpciones.Name = "CmsOpciones";
            this.CmsOpciones.Size = new System.Drawing.Size(393, 198);
            // 
            // enviarASUNATMenuItem
            // 
            this.enviarASUNATMenuItem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarASUNATMenuItem.Image = global::BimManager.Client.WipApp.Properties.Resources.Enviar;
            this.enviarASUNATMenuItem.Name = "enviarASUNATMenuItem";
            this.enviarASUNATMenuItem.Size = new System.Drawing.Size(392, 26);
            this.enviarASUNATMenuItem.Text = "Enviar a SUNAT";
            this.enviarASUNATMenuItem.Click += new System.EventHandler(this.enviarASUNATMenuItem_Click);
            // 
            // ConsultaCdrASunatMenuItem
            // 
            this.ConsultaCdrASunatMenuItem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsultaCdrASunatMenuItem.Image = global::BimManager.Client.WipApp.Properties.Resources.Pagos;
            this.ConsultaCdrASunatMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ConsultaCdrASunatMenuItem.Name = "ConsultaCdrASunatMenuItem";
            this.ConsultaCdrASunatMenuItem.Size = new System.Drawing.Size(392, 26);
            this.ConsultaCdrASunatMenuItem.Text = "Consultar CDR a SUNAT";
            this.ConsultaCdrASunatMenuItem.Click += new System.EventHandler(this.ConsultaCdrASunatMenuItem_Click);
            // 
            // VerDatosCDRMenuItem
            // 
            this.VerDatosCDRMenuItem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerDatosCDRMenuItem.Image = global::BimManager.Client.WipApp.Properties.Resources.Filtrar;
            this.VerDatosCDRMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VerDatosCDRMenuItem.Name = "VerDatosCDRMenuItem";
            this.VerDatosCDRMenuItem.Size = new System.Drawing.Size(392, 26);
            this.VerDatosCDRMenuItem.Text = "Ver datos de la CDR";
            this.VerDatosCDRMenuItem.Click += new System.EventHandler(this.VerDatosCDRMenuItem_Click);
            // 
            // SeparadorObservacion
            // 
            this.SeparadorObservacion.Name = "SeparadorObservacion";
            this.SeparadorObservacion.Size = new System.Drawing.Size(389, 6);
            // 
            // DocumentoXmlMenuItem
            // 
            this.DocumentoXmlMenuItem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentoXmlMenuItem.Image = global::BimManager.Client.WipApp.Properties.Resources.XML;
            this.DocumentoXmlMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DocumentoXmlMenuItem.Name = "DocumentoXmlMenuItem";
            this.DocumentoXmlMenuItem.Size = new System.Drawing.Size(392, 26);
            this.DocumentoXmlMenuItem.Text = "Descargar XML del documento";
            this.DocumentoXmlMenuItem.Click += new System.EventHandler(this.DocumentoXmlMenuItem_Click);
            // 
            // DocumentoPdfMenuItem
            // 
            this.DocumentoPdfMenuItem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentoPdfMenuItem.Image = global::BimManager.Client.WipApp.Properties.Resources.PDF;
            this.DocumentoPdfMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DocumentoPdfMenuItem.Name = "DocumentoPdfMenuItem";
            this.DocumentoPdfMenuItem.Size = new System.Drawing.Size(392, 26);
            this.DocumentoPdfMenuItem.Text = "Descargar PDF del documento";
            this.DocumentoPdfMenuItem.Click += new System.EventHandler(this.DocumentoPdfMenuItem_Click);
            // 
            // CdrXmlMenuItem
            // 
            this.CdrXmlMenuItem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CdrXmlMenuItem.Image = global::BimManager.Client.WipApp.Properties.Resources.XML;
            this.CdrXmlMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CdrXmlMenuItem.Name = "CdrXmlMenuItem";
            this.CdrXmlMenuItem.Size = new System.Drawing.Size(392, 26);
            this.CdrXmlMenuItem.Text = "Descargar XML de la CDR";
            this.CdrXmlMenuItem.Click += new System.EventHandler(this.CdrXmlMenuItem_Click);
            // 
            // SeparadorEmail
            // 
            this.SeparadorEmail.Name = "SeparadorEmail";
            this.SeparadorEmail.Size = new System.Drawing.Size(389, 6);
            // 
            // enviarEmailMenuItem
            // 
            this.enviarEmailMenuItem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarEmailMenuItem.Image = global::BimManager.Client.WipApp.Properties.Resources.Mail;
            this.enviarEmailMenuItem.Name = "enviarEmailMenuItem";
            this.enviarEmailMenuItem.Size = new System.Drawing.Size(392, 26);
            this.enviarEmailMenuItem.Text = "Enviar Correo con datos del comprobante";
            this.enviarEmailMenuItem.Click += new System.EventHandler(this.enviarEmailMenuItem_Click);
            // 
            // BnAnular
            // 
            this.BnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnAnular.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnAnular.Image = global::BimManager.Client.WipApp.Properties.Resources.Anular;
            this.BnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnAnular.Location = new System.Drawing.Point(113, 475);
            this.BnAnular.Name = "BnAnular";
            this.BnAnular.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnAnular.Size = new System.Drawing.Size(98, 30);
            this.BnAnular.TabIndex = 11;
            this.BnAnular.Text = "Anular";
            this.BnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnAnular.UseVisualStyleBackColor = true;
            // 
            // BnNuevo
            // 
            this.BnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnNuevo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnNuevo.Image = global::BimManager.Client.WipApp.Properties.Resources.Nuevo;
            this.BnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnNuevo.Location = new System.Drawing.Point(9, 475);
            this.BnNuevo.Name = "BnNuevo";
            this.BnNuevo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnNuevo.Size = new System.Drawing.Size(98, 30);
            this.BnNuevo.TabIndex = 10;
            this.BnNuevo.Text = "Nuevo";
            this.BnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnNuevo.UseVisualStyleBackColor = true;
            // 
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = global::BimManager.Client.WipApp.Properties.Resources.Cerrar;
            this.BnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSalir.Location = new System.Drawing.Point(1135, 475);
            this.BnSalir.Name = "BnSalir";
            this.BnSalir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSalir.Size = new System.Drawing.Size(98, 30);
            this.BnSalir.TabIndex = 9;
            this.BnSalir.Text = "Salir";
            this.BnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSalir.UseVisualStyleBackColor = true;
            this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
            // 
            // FrmContratoPagoLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 512);
            this.Controls.Add(this.BnAnular);
            this.Controls.Add(this.BnNuevo);
            this.Controls.Add(this.DgvContratoPago);
            this.Controls.Add(this.BnSalir);
            this.Controls.Add(this.LbTitulo);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmContratoPagoLista";
            this.Text = "Pagos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmContratoPagoLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvContratoPago)).EndInit();
            this.CmsOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.Button BnSalir;
		private System.Windows.Forms.DataGridView DgvContratoPago;
        private System.Windows.Forms.Button BnNuevo;
        private System.Windows.Forms.Button BnAnular;
        private System.Windows.Forms.ContextMenuStrip CmsOpciones;
        private System.Windows.Forms.ToolStripMenuItem enviarASUNATMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsultaCdrASunatMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparadorObservacion;
        private System.Windows.Forms.ToolStripMenuItem DocumentoXmlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentoPdfMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CdrXmlMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparadorEmail;
        private System.Windows.Forms.ToolStripMenuItem enviarEmailMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ToolStripMenuItem VerDatosCDRMenuItem;
    }
}