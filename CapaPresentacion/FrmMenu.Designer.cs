namespace CapaPresentacion
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
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuPresupuesto = new System.Windows.Forms.ToolStripMenuItem();
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
            this.viewMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
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
            this.mnuMantenedor.Size = new System.Drawing.Size(95, 20);
            this.mnuMantenedor.Text = "Mantenedores";
            // 
            // mnuTipoDocumentoSunat
            // 
            this.mnuTipoDocumentoSunat.Name = "mnuTipoDocumentoSunat";
            this.mnuTipoDocumentoSunat.Size = new System.Drawing.Size(248, 22);
            this.mnuTipoDocumentoSunat.Text = "Tipo de Documento Sunat";
            this.mnuTipoDocumentoSunat.Click += new System.EventHandler(this.mnuTipoDocumentoSunat_Click);
            // 
            // mnuTipoDocumentoIdentidad
            // 
            this.mnuTipoDocumentoIdentidad.Name = "mnuTipoDocumentoIdentidad";
            this.mnuTipoDocumentoIdentidad.Size = new System.Drawing.Size(248, 22);
            this.mnuTipoDocumentoIdentidad.Text = "Tipo de Documento de Identidad";
            this.mnuTipoDocumentoIdentidad.Click += new System.EventHandler(this.mnuTipoDocumentoIdentidad_Click);
            // 
            // mnuCliente
            // 
            this.mnuCliente.Name = "mnuCliente";
            this.mnuCliente.Size = new System.Drawing.Size(248, 22);
            this.mnuCliente.Text = "Cliente";
            this.mnuCliente.Click += new System.EventHandler(this.mnuCliente_Click);
            // 
            // mnuProyecto
            // 
            this.mnuProyecto.Name = "mnuProyecto";
            this.mnuProyecto.Size = new System.Drawing.Size(248, 22);
            this.mnuProyecto.Text = "Proyecto";
            this.mnuProyecto.Click += new System.EventHandler(this.mnuProyecto_Click);
            // 
            // mnuPrespuestoCategoria
            // 
            this.mnuPrespuestoCategoria.Name = "mnuPrespuestoCategoria";
            this.mnuPrespuestoCategoria.Size = new System.Drawing.Size(248, 22);
            this.mnuPrespuestoCategoria.Text = "Presupuesto Categoría";
            this.mnuPrespuestoCategoria.Click += new System.EventHandler(this.mnuPrespuestoCategoria_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(245, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(248, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPresupuesto});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(89, 20);
            this.editMenu.Text = "Movimientos";
            // 
            // viewMenu
            // 
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(71, 20);
            this.viewMenu.Text = "Consultas";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // mnuPresupuesto
            // 
            this.mnuPresupuesto.Name = "mnuPresupuesto";
            this.mnuPresupuesto.Size = new System.Drawing.Size(180, 22);
            this.mnuPresupuesto.Text = "Presupuesto";
            this.mnuPresupuesto.Click += new System.EventHandler(this.mnuPresupuesto_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Solución DIESA";
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
    }
}



