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
			TreeNode node = new TreeNode(presupuestoCategoria.TextoResumen);
            node.Tag = presupuestoCategoria;
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
            FrmPrespuestoCategoriaModal frm = new FrmPrespuestoCategoriaModal(FormAccion.nuevo, null);
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TreeNode node = CrearNode(frm.GetPresupuestoCategoria, null);
                tvPresupuestoCategoria.Nodes.Add(node);
            }
        }

        private void BnNuevoSubcategoria_Click(object sender, EventArgs e)
        {
            if (tvPresupuestoCategoria.SelectedNode == null)
            {
                MessageBox.Show(this, "Olvidó seleccionar una categoría", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            PresupuestoCategoria presupuestoCategoria = tvPresupuestoCategoria.SelectedNode.Tag as PresupuestoCategoria;
            if (presupuestoCategoria.PadrePresupuestoCategoriaID != null)
            {
                MessageBox.Show(this, "No se puede agregar una subcategoria de 2do nivel", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FrmPrespuestoCategoriaModal frm = new FrmPrespuestoCategoriaModal(FormAccion.nuevo, presupuestoCategoria);
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var nuevoPresupuestoCategoria = frm.GetPresupuestoCategoria;
                nuevoPresupuestoCategoria.PadrePresupuestoCategoria = presupuestoCategoria;
                presupuestoCategoria.SubPresupuestoCategorias.Add(nuevoPresupuestoCategoria);
                CrearNode(frm.GetPresupuestoCategoria, tvPresupuestoCategoria.SelectedNode);
            }
        }

        private void BnEditar_Click(object sender, EventArgs e)
        {
            if (tvPresupuestoCategoria.SelectedNode == null)
            {
                MessageBox.Show(this, "Olvidó seleccionar una categoría", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            PresupuestoCategoria presupuestoCategoria = tvPresupuestoCategoria.SelectedNode.Tag as PresupuestoCategoria;

            FrmPrespuestoCategoriaModal frm = new FrmPrespuestoCategoriaModal(FormAccion.editar, presupuestoCategoria);
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                presupuestoCategoria = frm.GetPresupuestoCategoria;
                presupuestoCategoria.PadrePresupuestoCategoria = presupuestoCategoria;

                tvPresupuestoCategoria.SelectedNode.Tag = presupuestoCategoria;
                tvPresupuestoCategoria.SelectedNode.Text = presupuestoCategoria.TextoResumen;
            }
        }

        private async void BnDeshabilitar_Click(object sender, EventArgs e)
        {
        }

        private void BnBuscar_Click(object sender, EventArgs e)
        {
            FrmPrespuestoCategoriaBuscar frm = new FrmPrespuestoCategoriaBuscar();
            frm.TopMost = true;
            frm.Owner = this;
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            this.BnBuscar.Enabled = false;
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._menu.Enabled = true;
        }

        private void ChkExpandirTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExpandirTodo.Checked)
            {
                tvPresupuestoCategoria.ExpandAll();
                ChkContraerTodo.Checked = false;
            }
        }

        private void ChkContraerTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkContraerTodo.Checked)
            {
                tvPresupuestoCategoria.CollapseAll();
                ChkExpandirTodo.Checked = false;
            }
        }
    }
}
