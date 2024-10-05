using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPresupuesto : Form
    {
        ToolStripMenuItem _menu;
        public FrmPresupuesto(ToolStripMenuItem menu)
        {
            _menu = menu;
            _menu.Enabled = false;
            InitializeComponent();
            SetAccion(FormAccion.ninguno);
        }

        private FormAccion Accion;
        private Cliente CurrentCliente;

        public void Botones_Enabled(bool nuevo, bool editar, bool deshabilitar, bool buscar)
        {
        //    BnNuevo.Enabled = nuevo;
        //    BnEditar.Enabled = editar;
        //    BnDeshabilitar.Enabled = deshabilitar;
        //    BnBuscar.Enabled = buscar;
        }

        public void SetAccion(FormAccion accion)
        {
            this.Accion = accion;
            this.CurrentCliente = null;
            switch (this.Accion)
            {
                case FormAccion.ninguno:
                    Botones_Enabled(true, true, true, true);
                    break;
                case FormAccion.nuevo:
                    Botones_Enabled(false, false, false, false);
                    break;
                case FormAccion.editar:
                    Botones_Enabled(false, false, false, false);
                    break;
                case FormAccion.buscar:
                    Botones_Enabled(true, true, true, false);
                    break;
            }
        }

        private void FrmPresupuesto_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._menu.Enabled = true;
        }

        private void FrmPresupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.Accion == FormAccion.nuevo || this.Accion == FormAccion.editar) &&
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
