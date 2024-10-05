using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Controls;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;

namespace CapaPresentacion
{
    public partial class FrmPrespuestoCategoria : Form
    {
        ToolStripMenuItem _menu;
        public FrmPrespuestoCategoria(ToolStripMenuItem menu)
        {
            _menu = menu;
            _menu.Enabled = false;
            InitializeComponent();
            SetAccion(FormAccion.ninguno);
        }

        private async void FrmPrespuestoCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                tvPresupuestoCategoria.Nodes.Clear();
                var presupuestoCategorias = await LogPresupuestoCategoria.Instancia.PresupuestoCategoriaBuscarTodos();
                foreach (var item in presupuestoCategorias)
                {
                    TreeNode node = CrearNode(item, null);
                    tvPresupuestoCategoria.Nodes.Add(node);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private TreeNode CrearNode(PresupuestoCategoria presupuestoCategoria, TreeNode nodeOwner)
        {
			TreeNode node = new TreeNode(presupuestoCategoria.Nombre + (!string.IsNullOrEmpty(presupuestoCategoria.Observaciones) ? $" ({presupuestoCategoria.Observaciones})" : ""));
            if (nodeOwner != null) nodeOwner.Nodes.Add(node);

            foreach (var subItem in presupuestoCategoria.SubPresupuestoCategorias)
            {
                CrearNode(subItem, node);
            }

            return node;
		}

        private void FrmPrespuestoCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.Accion == FormAccion.nuevo || this.Accion == FormAccion.editar) && 
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Métodos

        private FormAccion Accion;
        private Cliente CurrentCliente;

        public void Botones_Enabled(bool nuevo, bool editar, bool deshabilitar, bool buscar)
        {
            BnNuevo.Enabled = nuevo;
            BnEditar.Enabled = editar;
            BnDeshabilitar.Enabled = deshabilitar;
            BnBuscar.Enabled = buscar;
        }

        public void SetAccion(FormAccion accion)
        {
            this.Accion = accion;
            this.CurrentCliente = null;
            switch(this.Accion)
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

        #endregion Métodos

        private void BnNuevo_Click(object sender, EventArgs e)
        {
            SetAccion(FormAccion.nuevo);
        }

        private void BnEditar_Click(object sender, EventArgs e)
        {
            //var cliente = (Cliente)DgvCliente.CurrentRow?.Tag;
            //if (cliente == null)
            //{
            //    MessageBox.Show(this, "Olvidó seleccionar un cliente", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //SetAccion(FormAccion.editar);
            //GbDatos_MostrarDatos(cliente);
        }

        private async void BnDeshabilitar_Click(object sender, EventArgs e)
        {
            //var cliente = (Cliente)DgvCliente.CurrentRow?.Tag;
            //if (cliente == null)
            //{
            //    MessageBox.Show(this, "Olvidó seleccionar un cliente", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //string datosCliente = "\n";
            //datosCliente += "\n\r - Tipo de Doc.:" + cliente.TipoDocumentoIdentidad.Nombre;
            //datosCliente += "\n\r - Nº de Documento: " + cliente.DocumentoIdentidadNumero;
            //if (cliente.TipoDocumentoIdentidad.PersonaJuridica)
            //{
            //    datosCliente += "\n\r - Razón Social: " + cliente.RazonSocial;
            //}
            //else
            //{
            //    datosCliente += "\n\r - Nombres: " + cliente.Nombres;
            //    datosCliente += "\n\r - Apellido1: " + cliente.Apellido1;
            //    datosCliente += "\n\r - Apellido2: " + cliente.Apellido2;
            //}

            //if (MessageBox.Show(this, "¿Está seguro de deshabilitar al cliente?" + datosCliente, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}

            //try
            //{
            //    BnDeshabilitar.Enabled = false;
            //    this.Cursor = Cursors.WaitCursor;
            //    await LogCliente.Instancia.ClienteDeshabilitar(cliente.ClienteID);
            //    cliente.Activo = false;
            //    DgvCliente_Actualizar(cliente);


            //    this.Cursor = Cursors.Default;
            //    MessageBox.Show(this, "El cliente fue deshabilitado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    BnDeshabilitar.Enabled = true;

            //    SetAccion(FormAccion.ninguno);
            //}
            //catch (Exception ex)
            //{
            //    this.Cursor = Cursors.Default;
            //    MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    BnDeshabilitar.Enabled = true;
            //}
        }

        private void BnBuscar_Click(object sender, EventArgs e)
        {
            SetAccion(FormAccion.buscar);
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._menu.Enabled = true;
        }
	}
}
