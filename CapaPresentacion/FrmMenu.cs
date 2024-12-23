﻿using BimManager.Entidad;
using System;
using System.Windows.Forms;

namespace BimManager.Client.WipApp
{
	public partial class FrmMenu : FrmBase
    {
        public FrmMenu()

        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            var frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                this.Visible = true;
                this._usuario = frmLogin.GetUsuarioActual;
                frmLogin.Dispose();
            }
            else
            {
                frmLogin.Dispose();
                this.Close();
            }
		}

		private void mnuTipoDocumentoSunat_Click(object sender, EventArgs e)
		{
			var form = new FrmTipoDocumentoSunat((ToolStripMenuItem)sender);
			form.MdiParent = this;
			form.Show();
		}

		private void mnuTipoDocumentoIdentidad_Click(object sender, EventArgs e)
        {
            var form = new FrmTipoDocumentoIdentidad((ToolStripMenuItem)sender);
            form.MdiParent = this;
            form.Show();
        }

        private void mnuCliente_Click(object sender, EventArgs e)
        {
            var form = new FrmCliente((ToolStripMenuItem)sender);
            form.MdiParent = this;
            form.Show();
		}

		private void mnuProyecto_Click(object sender, EventArgs e)
		{
			var form = new FrmProyecto((ToolStripMenuItem)sender);
			form.MdiParent = this;
			form.Show();
		}

		private void mnuPrespuestoCategoria_Click(object sender, EventArgs e)
		{
			var form = new FrmPrespuestoCategoria((ToolStripMenuItem)sender);
			form.MdiParent = this;
			form.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuPresupuesto_Click(object sender, EventArgs e)
        {
            var form = new FrmPresupuesto((ToolStripMenuItem)sender, this._usuario);
            form.MdiParent = this;
            form.Show();
        }

        private void mnuContrato_Click(object sender, EventArgs e)
        {
            var form = new FrmContrato((ToolStripMenuItem)sender, this._usuario);
            form.MdiParent = this;
            form.Show();
        }

        private void mnuComprobanteBusqueda_Click(object sender, EventArgs e)
        {

        }

        private void mnuComprobanteEnvio_Click(object sender, EventArgs e)
        {

        }

        private void mnuComunicacionBaja_Click(object sender, EventArgs e)
        {

        }

        private void mnuResumenDiario_Click(object sender, EventArgs e)
        {

        }

        private void mnuResumenContingencia_Click(object sender, EventArgs e)
        {

        }
    }
}
