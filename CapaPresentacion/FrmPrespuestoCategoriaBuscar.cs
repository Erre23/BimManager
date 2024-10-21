using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrespuestoCategoriaBuscar : FrmBase
    {
        private FrmPrespuestoCategoria GetFormPresupuestoCategoria { get { return this.Owner as FrmPrespuestoCategoria; } }
        public FrmPrespuestoCategoriaBuscar()
        {
            InitializeComponent();
        }

        private void FrmPrespuestoCategoriaModal_Load(object sender, EventArgs e)
        {

        }

        #region Métodos

        private List<TreeNode> foundNodes;
        private int currentIndex = -1;
        private void SearchTree(TreeNodeCollection nodes, string searchTerm)
        {
            var foundList = new System.Collections.Generic.List<TreeNode>(); // Lista para almacenar nodos encontrados

            foreach (TreeNode node in nodes)
            {
                var presupuestoCategoria = node.Tag as PresupuestoCategoria;
                if (presupuestoCategoria.Nombre.ToUpper().Contains(searchTerm.ToUpper()))
                {
                    foundList.Add(node); // Agregar a la lista
                }

                // Busca recursivamente en los nodos hijos
                if (node.Nodes.Count > 0)
                {
                    SearchTree(node.Nodes, searchTerm);
                }
            }

            foundNodes.AddRange(foundList);
            currentIndex = -1; 
            if (foundNodes.Count() > 0)
            {
                currentIndex = 0;
                SelectNode(foundNodes[currentIndex]); // Seleccionar el primer nodo encontrado
            }
        }

        private void SelectNode(TreeNode node)
        {
            GetFormPresupuestoCategoria.tvPresupuestoCategoria.SelectedNode = node; // Seleccionar el nodo
            node.EnsureVisible(); // Asegurar que sea visible
        }
        #endregion Métodos


        private void BnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbNombre.Text.Trim() == "") 
                {
                    MessageBox.Show(this, "Olvidó ingresar el dato de búsqueda", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BnBuscar.Enabled = false;
                BnSiguiente.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                foundNodes = new List<TreeNode>();
                currentIndex = -1;
                SearchTree(GetFormPresupuestoCategoria.tvPresupuestoCategoria.Nodes, TbNombre.Text.Trim());
                this.Cursor = Cursors.Default;
                BnBuscar.Enabled = true;
                if (foundNodes == null || foundNodes.Count() == 0)
                {
                    MessageBox.Show(this, "No se encontraron coincidencias", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    BnSiguiente.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnBuscar.Enabled = true;
            }
        }

        private void BnSiguiente_Click(object sender, EventArgs e)
        {
            if (foundNodes != null && foundNodes.Count() > 0)
            {
                currentIndex++;
                if (currentIndex >= foundNodes.Count())
                {
                    currentIndex = 0; // Volver al inicio si llegamos al final
                }

                SelectNode(foundNodes[currentIndex]);
            }
        }

        private void BnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPrespuestoCategoriaBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.GetFormPresupuestoCategoria.BnBuscar.Enabled = true;
        }
    }
}
