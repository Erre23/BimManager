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

namespace CapaPresentacion
{
    public partial class FrmTipoDocumentoIdentidad : Form
    {
        ToolStripMenuItem _menu;
        public FrmTipoDocumentoIdentidad(ToolStripMenuItem menu)
        {
            _menu = menu;
            _menu.Enabled = false;
            InitializeComponent();
            SetAccion(FormAccion.ninguno);
        }

        private async void FrmTipoDocumentoIdentidad_Load(object sender, EventArgs e)
        {
            try
            {
                DgvTipoDocumentoIdentidad.Rows.Clear();
                this.Cursor = Cursors.WaitCursor;

                var lista = await LogTipoDocumentoIdentidad.Instancia.TipoDocumentoIdentidadListarTodos();

                foreach (var item in lista)
                {
                    DgvTipoDocumentoIdentidad_Agregar(item);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmTipoDocumentoIdentidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.Accion == FormAccion.nuevo || this.Accion == FormAccion.editar) && 
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Métodos

        private void DgvTipoDocumentoIdentidad_Agregar(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            var indice = 
                DgvTipoDocumentoIdentidad.Rows.Add(
                    tipoDocumentoIdentidad.Nombre, 
                    tipoDocumentoIdentidad.LongitudExacta, 
                    tipoDocumentoIdentidad.LongitudMinima,
                    tipoDocumentoIdentidad.LongitudMaxima, 
                    tipoDocumentoIdentidad.Alfanumerico,
                    tipoDocumentoIdentidad.PersonaJuridica,
					tipoDocumentoIdentidad.ConsultaApi,
					tipoDocumentoIdentidad.Activo ? "SI" : ""
                );
            DgvTipoDocumentoIdentidad.Rows[indice].Tag = tipoDocumentoIdentidad;
        }

        private void DgvTipoDocumentoIdentidad_Actualizar(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {

            DgvTipoDocumentoIdentidad.CurrentRow.Tag = tipoDocumentoIdentidad;
            DgvTipoDocumentoIdentidad.CurrentRow.Cells[0].Value = tipoDocumentoIdentidad.Nombre;
            DgvTipoDocumentoIdentidad.CurrentRow.Cells[1].Value = tipoDocumentoIdentidad.LongitudExacta;
            DgvTipoDocumentoIdentidad.CurrentRow.Cells[2].Value = tipoDocumentoIdentidad.LongitudMinima;
            DgvTipoDocumentoIdentidad.CurrentRow.Cells[3].Value = tipoDocumentoIdentidad.LongitudMaxima;
            DgvTipoDocumentoIdentidad.CurrentRow.Cells[4].Value = tipoDocumentoIdentidad.Alfanumerico;
            DgvTipoDocumentoIdentidad.CurrentRow.Cells[5].Value = tipoDocumentoIdentidad.PersonaJuridica;
			DgvTipoDocumentoIdentidad.CurrentRow.Cells[6].Value = tipoDocumentoIdentidad.ConsultaApi;
			DgvTipoDocumentoIdentidad.CurrentRow.Cells[7].Value = tipoDocumentoIdentidad.Activo ? "SI" : "";
        }

        private FormAccion Accion;
        private TipoDocumentoIdentidad CurrentTipoDocumentoIdentidad;

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
            ChkLongitudExacta.Checked = false;
            TbLongitudMinima.Clear();
            TbLongitudMaxima.Clear();
            ChkAlfanumerico.Checked = false;
            ChkPersonaJuridica.Checked = false;
        }
        private void GbDatos_MostrarDatos(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            this.CurrentTipoDocumentoIdentidad = tipoDocumentoIdentidad;
            
            TbNombre.Text = tipoDocumentoIdentidad.Nombre;
            ChkLongitudExacta.Checked = tipoDocumentoIdentidad.LongitudExacta;
            TbLongitudMinima.Text = tipoDocumentoIdentidad.LongitudMinima.ToString();
            TbLongitudMaxima.Text = tipoDocumentoIdentidad.LongitudMaxima.ToString();
            ChkAlfanumerico.Checked = tipoDocumentoIdentidad.Alfanumerico;
            ChkPersonaJuridica.Checked = tipoDocumentoIdentidad.PersonaJuridica;
            ChkConsultaAPI.Checked = tipoDocumentoIdentidad.ConsultaApi;
        }

        public void SetAccion(FormAccion accion)
        {
            GBDatos_Limpiar();
            this.Accion = accion;
            this.CurrentTipoDocumentoIdentidad = null;
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

        private void CopiarLongitudMinima()
        {
            if (ChkLongitudExacta.Checked)
            {
                TbLongitudMaxima.Text = TbLongitudMinima.Text;
            }
        }

        #endregion Métodos

        private void BnNuevo_Click(object sender, EventArgs e)
        {
            SetAccion(FormAccion.nuevo);
        }

        private void BnEditar_Click(object sender, EventArgs e)
        {
            var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)DgvTipoDocumentoIdentidad.CurrentRow?.Tag;
            if (tipoDocumentoIdentidad == null)
            {
                MessageBox.Show(this, "Olvidó seleccionar un tipo de documento de identidad", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetAccion(FormAccion.editar);
            GbDatos_MostrarDatos(tipoDocumentoIdentidad);
        }

        private async void BnDeshabilitar_Click(object sender, EventArgs e)
        {
            var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)DgvTipoDocumentoIdentidad.CurrentRow?.Tag;
            if (tipoDocumentoIdentidad == null)
            {
                MessageBox.Show(this, "Olvidó seleccionar un tipo de documento de identidad", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string datos = "\n";
            datos += "\n\r - Nombre: " + tipoDocumentoIdentidad.Nombre;

            if (MessageBox.Show(this, "¿Está seguro de deshabilitar al tipo de documento de identidad?" + datos, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                BnDeshabilitar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                await LogTipoDocumentoIdentidad.Instancia.TipoDocumentoIdentidadDeshabilitar(tipoDocumentoIdentidad.TipoDocumentoIdentidadID);
                tipoDocumentoIdentidad.Activo = false;
                DgvTipoDocumentoIdentidad_Actualizar(tipoDocumentoIdentidad);


                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "El tipo de documento de identidad fue deshabilitado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (TbLongitudMinima.Text.Trim() == "") datosFaltantes += "\n\r - Longitud Mínima";
                if (TbLongitudMaxima.Text.Trim() == "") datosFaltantes += "\n\r - Longitud Máxima";

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (this.Accion == FormAccion.nuevo) this.CurrentTipoDocumentoIdentidad = new TipoDocumentoIdentidad();
                this.CurrentTipoDocumentoIdentidad.Nombre = TbNombre.Text.Trim();
                this.CurrentTipoDocumentoIdentidad.LongitudExacta = ChkLongitudExacta.Checked;
                this.CurrentTipoDocumentoIdentidad.LongitudMinima = Convert.ToInt16(TbLongitudMinima.Text.Trim());
                this.CurrentTipoDocumentoIdentidad.LongitudMaxima = Convert.ToInt16(TbLongitudMaxima.Text.Trim());
                this.CurrentTipoDocumentoIdentidad.Alfanumerico = ChkAlfanumerico.Checked;
                this.CurrentTipoDocumentoIdentidad.PersonaJuridica = ChkPersonaJuridica.Checked;
                this.CurrentTipoDocumentoIdentidad.ConsultaApi = ChkConsultaAPI.Checked;

                if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this.Accion == FormAccion.nuevo)
                {
                    this.CurrentTipoDocumentoIdentidad.TipoDocumentoIdentidadID = await LogTipoDocumentoIdentidad.Instancia.TipoDocumentoIdentidadInsertar(this.CurrentTipoDocumentoIdentidad);
                    DgvTipoDocumentoIdentidad_Agregar(this.CurrentTipoDocumentoIdentidad);
                }
                else
                {
                    await LogTipoDocumentoIdentidad.Instancia.TipoDocumentoIdentidadActualizar(this.CurrentTipoDocumentoIdentidad);
                    DgvTipoDocumentoIdentidad_Actualizar(this.CurrentTipoDocumentoIdentidad);
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

        private void FrmTipoDocumentoIdentidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._menu.Enabled = true;
        }

        private void ChkLongitudExacta_CheckedChanged(object sender, EventArgs e)
        {
            TbLongitudMaxima.Clear();
            TbLongitudMaxima.Enabled = !ChkLongitudExacta.Checked;
            CopiarLongitudMinima();
        }

        private void TbLongitudMinima_TextChanged(object sender, EventArgs e)
        {
            CopiarLongitudMinima();
        }
    }
}
