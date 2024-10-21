using CapaEntidad;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmTipoDocumentoSunat : FrmBase
    {
        ToolStripMenuItem _menu;
        public FrmTipoDocumentoSunat(ToolStripMenuItem menu)
        {
            _menu = menu;
            _menu.Enabled = false;
            InitializeComponent();
            SetAccion(FormAccion.ninguno);
        }

        private async void FrmTipoDocumentoSunat_Load(object sender, EventArgs e)
        {
            try
            {
                DgvTipoDocumentoSunat.Rows.Clear();
                this.Cursor = Cursors.WaitCursor;

                var lista = await this.ObjRemoteObject.LogTipoDocumentoSunat.TipoDocumentoSunatListarTodos();

                foreach (var item in lista)
                {
                    DgvTipoDocumentoSunat_Agregar(item);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmTipoDocumentoSunat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.Accion == FormAccion.nuevo || this.Accion == FormAccion.editar) && 
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Métodos

        private void DgvTipoDocumentoSunat_Agregar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            var indice = 
                DgvTipoDocumentoSunat.Rows.Add(
                    tipoDocumentoSunat.Nombre, 
                    tipoDocumentoSunat.CodigoSunat,
                    tipoDocumentoSunat.Activo ? "SI" : ""
                );
            DgvTipoDocumentoSunat.Rows[indice].Tag = tipoDocumentoSunat;
        }

        private void DgvTipoDocumentoSunat_Actualizar(TipoDocumentoSunat tipoDocumentoSunat)
        {

            DgvTipoDocumentoSunat.CurrentRow.Tag = tipoDocumentoSunat;
            DgvTipoDocumentoSunat.CurrentRow.Cells[0].Value = tipoDocumentoSunat.Nombre;
            DgvTipoDocumentoSunat.CurrentRow.Cells[1].Value = tipoDocumentoSunat.CodigoSunat;
            DgvTipoDocumentoSunat.CurrentRow.Cells[2].Value = tipoDocumentoSunat.Activo ? "SI" : "";
        }

        private FormAccion Accion;
        private TipoDocumentoSunat CurrentTipoDocumentoSunat;

        public void Botones_Enabled(bool nuevo, bool editar, bool deshabilitar)
        {
            BnNuevo.Enabled = nuevo;
            BnEditar.Enabled = editar;
            BnDeshabilitar.Enabled = deshabilitar;
        }

        public void Botones_Visible(bool guardar, bool cancelar)
        {
            BnGuardar.Visible = guardar;
            BnCancelar.Visible = cancelar;
        }

        public void GBDatos_Limpiar()
        {   
            TbNombre.Clear();
            TbCodigoSunat.Clear();
        }
        private void GbDatos_MostrarDatos(TipoDocumentoSunat tipoDocumentoSunat)
        {
            this.CurrentTipoDocumentoSunat = tipoDocumentoSunat;
            
            TbNombre.Text = tipoDocumentoSunat.Nombre;
            TbCodigoSunat.Text = tipoDocumentoSunat.CodigoSunat;
        }

        public void SetAccion(FormAccion accion)
        {
            GBDatos_Limpiar();
            this.Accion = accion;
            this.CurrentTipoDocumentoSunat = null;
            switch(this.Accion)
            {
                case FormAccion.ninguno:
                    LbOpcion.Text = "";
                    Botones_Enabled(true, true, true);
                    Botones_Visible(false, false);
                    GbDatos.Enabled = false;
                    GbLista.Enabled = true;
                    break;
                case FormAccion.nuevo:
                    LbOpcion.Text = "OPCIÓN : NUEVO";
                    Botones_Enabled(false, false, false);
                    Botones_Visible(true, true);
                    GbDatos.Enabled = true;
                    GbLista.Enabled = false;
                    break;
                case FormAccion.editar:
                    LbOpcion.Text = "OPCIÓN : EDITAR";
                    Botones_Enabled(false, false, false);
                    Botones_Visible(true, true);
                    GbDatos.Enabled = true;
                    GbLista.Enabled = false;
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
            var tipoDocumentoSunat = (TipoDocumentoSunat)DgvTipoDocumentoSunat.CurrentRow?.Tag;
            if (tipoDocumentoSunat == null)
            {
                MessageBox.Show(this, "Olvidó seleccionar un tipo de documento de Sunat", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetAccion(FormAccion.editar);
            GbDatos_MostrarDatos(tipoDocumentoSunat);
        }

        private async void BnDeshabilitar_Click(object sender, EventArgs e)
        {
            var tipoDocumentoSunat = (TipoDocumentoSunat)DgvTipoDocumentoSunat.CurrentRow?.Tag;
            if (tipoDocumentoSunat == null)
            {
                MessageBox.Show(this, "Olvidó seleccionar un tipo de documento de Sunat", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string datos = "\n";
            datos += "\n\r - Nombre: " + tipoDocumentoSunat.Nombre;

            if (MessageBox.Show(this, "¿Está seguro de deshabilitar al tipo de documento de Sunat?" + datos, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                BnDeshabilitar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                await this.ObjRemoteObject.LogTipoDocumentoSunat.TipoDocumentoSunatDeshabilitar(tipoDocumentoSunat.TipoDocumentoSunatID);
                tipoDocumentoSunat.Activo = false;
                DgvTipoDocumentoSunat_Actualizar(tipoDocumentoSunat);


                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "El tipo de documento de Sunat fue deshabilitado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnDeshabilitar.Enabled = true;

                SetAccion(FormAccion.ninguno);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnDeshabilitar.Enabled = true;
            }
        }

        private async void BnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";
               
                if (TbNombre.Text.Trim() == "") datosFaltantes += "\n\r - Nombre";
                if (TbCodigoSunat.Text.Trim() == "") datosFaltantes += "\n\r - Código Sunat";

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (this.Accion == FormAccion.nuevo) this.CurrentTipoDocumentoSunat = new TipoDocumentoSunat();
                this.CurrentTipoDocumentoSunat.Nombre = TbNombre.Text.Trim();
                this.CurrentTipoDocumentoSunat.CodigoSunat = TbCodigoSunat.Text.Trim();

                if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this.Accion == FormAccion.nuevo)
                {
                    this.CurrentTipoDocumentoSunat.TipoDocumentoSunatID = await this.ObjRemoteObject.LogTipoDocumentoSunat.TipoDocumentoSunatInsertar(this.CurrentTipoDocumentoSunat);
                    DgvTipoDocumentoSunat_Agregar(this.CurrentTipoDocumentoSunat);
                }
                else
                {
                    await this.ObjRemoteObject.LogTipoDocumentoSunat.TipoDocumentoSunatActualizar(this.CurrentTipoDocumentoSunat);
                    DgvTipoDocumentoSunat_Actualizar(this.CurrentTipoDocumentoSunat);
                }

                
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "Los datos fueron guardados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnGuardar.Enabled = true;

                SetAccion(FormAccion.ninguno);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnGuardar.Enabled = true;
            }
        }

        private void BnCancelar_Click(object sender, EventArgs e)
        {
            SetAccion(FormAccion.ninguno);
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTipoDocumentoSunat_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._menu.Enabled = true;
        }
    }
}
