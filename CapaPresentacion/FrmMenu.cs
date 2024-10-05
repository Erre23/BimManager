using CapaEntidad;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
	public partial class FrmMenu : Form
    {
        public FrmMenu()

        {
            InitializeComponent();
        }

        private Usuario _currentUsuario;

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            var frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                this.Visible = true;
                this._currentUsuario = frmLogin.GetUsuarioActual;
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

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
