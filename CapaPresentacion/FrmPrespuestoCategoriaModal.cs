using CapaEntidad;
using CapaLogica;
using CapaPresentacion.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrespuestoCategoriaModal : Form
    {
        private PresupuestoCategoria _presupuestoCategoriaOwner;
        private PresupuestoCategoria _presupuestoCategoria;
        public PresupuestoCategoria GetPresupuestoCategoria { get { return _presupuestoCategoria; } }
        public FrmPrespuestoCategoriaModal(FormAccion accion, PresupuestoCategoria presupuestoCategoria)
        {
            InitializeComponent();
            SetAccion(accion);
            if (accion == FormAccion.nuevo)
            {
                _presupuestoCategoria = null;
                _presupuestoCategoriaOwner = presupuestoCategoria;
                TbPorcentaje.Enabled = (_presupuestoCategoriaOwner == null);
            }
            else if (accion == FormAccion.editar)
            {
                _presupuestoCategoria = presupuestoCategoria;
                _presupuestoCategoriaOwner = presupuestoCategoria.PadrePresupuestoCategoria;
                TbPorcentaje.Enabled = (presupuestoCategoria.PadrePresupuestoCategoria == null);
            }
        }

        private void FrmPrespuestoCategoriaModal_Load(object sender, EventArgs e)
        {
            TbCategoriaRaiz.Text = (_presupuestoCategoriaOwner != null ? _presupuestoCategoriaOwner.Nombre : "");
            if (_presupuestoCategoria != null)
            {
                TbNombre.Text = _presupuestoCategoria.Nombre;
                TbObservaciones.Text = _presupuestoCategoria.Observaciones;
                if(_presupuestoCategoria.Porcentaje != null) TbPorcentaje.Text = _presupuestoCategoria.Porcentaje.ToString();
            }
            else
            {
                TbNombre.Clear();
                TbObservaciones.Clear();
                TbPorcentaje.Clear();
            }
        }

        private void FrmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.Accion == FormAccion.nuevo || this.Accion == FormAccion.editar) && 
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Métodos

        private FormAccion Accion;

        public void SetAccion(FormAccion accion)
        {
            this.Accion = accion;
            switch(this.Accion)
            {
                case FormAccion.nuevo:
                    this.Text += "Nuevo";
                    LbTitulo.Text += "Nuevo";
                    LbOpcion.Text = "OPCIÓN : NUEVO";
                    break;
                case FormAccion.editar:
                    this.Text += "Editar";
                    LbTitulo.Text += "Editar";
                    LbOpcion.Text = "OPCIÓN : EDITAR";
                    break;
            }
        }

        #endregion Métodos


        private async void BnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";
                if (TbNombre.Text.Trim() == "") datosFaltantes += "\n\r - Nombre";
                if (_presupuestoCategoriaOwner == null && string.IsNullOrEmpty(TbPorcentaje.Text)) datosFaltantes += "\n\r - Porcentaje";

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (_presupuestoCategoriaOwner == null)
                {
                    var porcentaje = Convert.ToDecimal(TbPorcentaje.Text.Trim());
                    if (_presupuestoCategoriaOwner == null && porcentaje <= 0)
                    {
                        string mensaje = $"El porcentaje debe ser mayor a \"0.00\" cero";
                        MessageBox.Show(this, mensaje, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                
                if (this.Accion == FormAccion.nuevo) this._presupuestoCategoria = new PresupuestoCategoria();
                this._presupuestoCategoria.Nombre = TbNombre.Text.Trim();
                this._presupuestoCategoria.Observaciones = TbObservaciones.Text.Trim();
                if (this._presupuestoCategoriaOwner == null) this._presupuestoCategoria.Porcentaje = Convert.ToDecimal(TbPorcentaje.Text.Trim());
                else this._presupuestoCategoria.Porcentaje = null;

                this._presupuestoCategoria.PadrePresupuestoCategoriaID = _presupuestoCategoriaOwner?.PresupuestoCategoriaID;
                this._presupuestoCategoria.PadrePresupuestoCategoria = _presupuestoCategoriaOwner;

                if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this.Accion == FormAccion.nuevo)
                {
                    this._presupuestoCategoria.PresupuestoCategoriaID = await LogPresupuestoCategoria.Instancia.PresupuestoCategoriaInsertar(this._presupuestoCategoria);
                }
                else
                {
                    await LogPresupuestoCategoria.Instancia.PresupuestoCategoriaActualizar(this._presupuestoCategoria);
                }

                
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "Los datos fueron guardados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnGuardar.Enabled = true;
                this.Accion = FormAccion.ninguno;
                this.DialogResult = DialogResult.OK;
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
            this.Close();
        }
    }
}
