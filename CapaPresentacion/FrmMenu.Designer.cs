namespace BimManager.Client.WipApp
{
    partial class FrmMenu
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuMantenedor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTipoDocumentoSunat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTipoDocumentoIdentidad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProyecto = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrespuestoCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPresupuesto = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContrato = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSunat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComprobanteBusqueda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComprobanteEnvio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComunicacionBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResumenDiario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResumenContingencia = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMantenedor,
            this.editMenu,
            this.viewMenu,
            this.mnuSunat});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(843, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mnuMantenedor
            // 
            this.mnuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTipoDocumentoSunat,
            this.mnuTipoDocumentoIdentidad,
            this.mnuCliente,
            this.mnuProyecto,
            this.mnuPrespuestoCategoria,
            this.toolStripSeparator5,
            this.mnuExit});
            this.mnuMantenedor.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.mnuMantenedor.Name = "mnuMantenedor";
            this.mnuMantenedor.Size = new System.Drawing.Size(118, 24);
            this.mnuMantenedor.Text = "Mantenedores";
            // 
            // mnuTipoDocumentoSunat
            // 
            this.mnuTipoDocumentoSunat.Name = "mnuTipoDocumentoSunat";
            this.mnuTipoDocumentoSunat.Size = new System.Drawing.Size(314, 26);
            this.mnuTipoDocumentoSunat.Text = "Tipo de Documento Sunat";
            this.mnuTipoDocumentoSunat.Click += new System.EventHandler(this.mnuTipoDocumentoSunat_Click);
            // 
            // mnuTipoDocumentoIdentidad
            // 
            this.mnuTipoDocumentoIdentidad.Name = "mnuTipoDocumentoIdentidad";
            this.mnuTipoDocumentoIdentidad.Size = new System.Drawing.Size(314, 26);
            this.mnuTipoDocumentoIdentidad.Text = "Tipo de Documento de Identidad";
            this.mnuTipoDocumentoIdentidad.Click += new System.EventHandler(this.mnuTipoDocumentoIdentidad_Click);
            // 
            // mnuCliente
            // 
            this.mnuCliente.Name = "mnuCliente";
            this.mnuCliente.Size = new System.Drawing.Size(314, 26);
            this.mnuCliente.Text = "Cliente";
            this.mnuCliente.Click += new System.EventHandler(this.mnuCliente_Click);
            // 
            // mnuProyecto
            // 
            this.mnuProyecto.Name = "mnuProyecto";
            this.mnuProyecto.Size = new System.Drawing.Size(314, 26);
            this.mnuProyecto.Text = "Proyecto";
            this.mnuProyecto.Click += new System.EventHandler(this.mnuProyecto_Click);
            // 
            // mnuPrespuestoCategoria
            // 
            this.mnuPrespuestoCategoria.Name = "mnuPrespuestoCategoria";
            this.mnuPrespuestoCategoria.Size = new System.Drawing.Size(314, 26);
            this.mnuPrespuestoCategoria.Text = "Presupuesto Categoría";
            this.mnuPrespuestoCategoria.Click += new System.EventHandler(this.mnuPrespuestoCategoria_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(311, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(314, 26);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPresupuesto,
            this.mnuContrato});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(109, 24);
            this.editMenu.Text = "Movimientos";
            // 
            // mnuPresupuesto
            // 
            this.mnuPresupuesto.Name = "mnuPresupuesto";
            this.mnuPresupuesto.Size = new System.Drawing.Size(178, 26);
            this.mnuPresupuesto.Text = "Presupuestos";
            this.mnuPresupuesto.Click += new System.EventHandler(this.mnuPresupuesto_Click);
            // 
            // mnuContrato
            // 
            this.mnuContrato.Name = "mnuContrato";
            this.mnuContrato.Size = new System.Drawing.Size(178, 26);
            this.mnuContrato.Text = "Contratos";
            this.mnuContrato.Click += new System.EventHandler(this.mnuContrato_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(86, 24);
            this.viewMenu.Text = "Consultas";
            // 
            // mnuSunat
            // 
            this.mnuSunat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuComprobanteBusqueda,
            this.mnuComprobanteEnvio,
            this.mnuComunicacionBaja,
            this.mnuResumenDiario,
            this.mnuResumenContingencia});
            this.mnuSunat.Name = "mnuSunat";
            this.mnuSunat.Size = new System.Drawing.Size(60, 24);
            this.mnuSunat.Text = "Sunat";
            // 
            // mnuComprobanteBusqueda
            // 
            this.mnuComprobanteBusqueda.Name = "mnuComprobanteBusqueda";
            this.mnuComprobanteBusqueda.Size = new System.Drawing.Size(389, 26);
            this.mnuComprobanteBusqueda.Text = "Búsqueda de Comprobantes";
            this.mnuComprobanteBusqueda.Click += new System.EventHandler(this.mnuComprobanteBusqueda_Click);
            // 
            // mnuComprobanteEnvio
            // 
            this.mnuComprobanteEnvio.Name = "mnuComprobanteEnvio";
            this.mnuComprobanteEnvio.Size = new System.Drawing.Size(389, 26);
            this.mnuComprobanteEnvio.Text = "Envío Masivo a SUNAT";
            this.mnuComprobanteEnvio.Click += new System.EventHandler(this.mnuComprobanteEnvio_Click);
            // 
            // mnuComunicacionBaja
            // 
            this.mnuComunicacionBaja.Name = "mnuComunicacionBaja";
            this.mnuComunicacionBaja.Size = new System.Drawing.Size(389, 26);
            this.mnuComunicacionBaja.Text = "Comunicación de Baja";
            this.mnuComunicacionBaja.Click += new System.EventHandler(this.mnuComunicacionBaja_Click);
            // 
            // mnuResumenDiario
            // 
            this.mnuResumenDiario.Name = "mnuResumenDiario";
            this.mnuResumenDiario.Size = new System.Drawing.Size(389, 26);
            this.mnuResumenDiario.Text = "Resumen diario de boletas y notas asociadas";
            this.mnuResumenDiario.Click += new System.EventHandler(this.mnuResumenDiario_Click);
            // 
            // mnuResumenContingencia
            // 
            this.mnuResumenContingencia.Name = "mnuResumenContingencia";
            this.mnuResumenContingencia.Size = new System.Drawing.Size(389, 26);
            this.mnuResumenContingencia.Text = "Resumen de Contingencia";
            this.mnuResumenContingencia.Click += new System.EventHandler(this.mnuResumenContingencia_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 532);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 558);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Solución BimManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuCliente;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenedor;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuTipoDocumentoIdentidad;
		private System.Windows.Forms.ToolStripMenuItem mnuTipoDocumentoSunat;
		private System.Windows.Forms.ToolStripMenuItem mnuProyecto;
		private System.Windows.Forms.ToolStripMenuItem mnuPrespuestoCategoria;
        private System.Windows.Forms.ToolStripMenuItem mnuPresupuesto;
        private System.Windows.Forms.ToolStripMenuItem mnuContrato;
        private System.Windows.Forms.ToolStripMenuItem mnuSunat;
        private System.Windows.Forms.ToolStripMenuItem mnuComprobanteBusqueda;
        private System.Windows.Forms.ToolStripMenuItem mnuComprobanteEnvio;
        private System.Windows.Forms.ToolStripMenuItem mnuComunicacionBaja;
        private System.Windows.Forms.ToolStripMenuItem mnuResumenDiario;
        private System.Windows.Forms.ToolStripMenuItem mnuResumenContingencia;
    }
}



