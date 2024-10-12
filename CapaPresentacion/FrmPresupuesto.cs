using CapaEntidad;
using CapaLogica;
using CapaPresentacion.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPresupuesto : Form
    {
        ToolStripMenuItem _menu;
        Usuario _usuario;
        public FrmPresupuesto(ToolStripMenuItem menu, Usuario usuario)
        {
            _menu = menu;
            _menu.Enabled = false;
            _usuario = usuario;
            InitializeComponent();
            SetAccion(FormAccion.ninguno);
        }

        private FormAccion Accion;
        private Presupuesto CurrentPresupuesto;

        public void Botones_Enabled(bool nuevo, bool buscar, bool anular, bool guardar, bool cancelar)
        {
            BnNuevo.Enabled = nuevo;
            BnBuscar.Enabled = buscar;
            BnAnular.Enabled = anular;
            BnGuardar.Enabled = guardar;
            BnCancelar.Enabled = cancelar;
        }

        public void Controles_Input_Enabled(bool enabled)
        {
            DtpFechaDesde.Enabled = enabled;
            DtpFechaHasta.Enabled = enabled;
            CbTipoDocumentoIdentidad.Enabled = enabled;
            TbNumeroDocumento.Enabled = enabled;
            BnBuscarCliente.Enabled = enabled;
            CbProyectoNombre.Enabled = enabled;
            BnAgregarProyecto.Enabled = enabled;
        }

        public void Controles_Clear()
        {
            TbNumeroPresupuesto.Clear();
            TbEstado.Clear();
            DtpFechaDesde.Text = string.Empty;
            DtpFechaHasta.Text = string.Empty;
            TbCreadoPor.Clear();
            TbNumeroDocumento.Clear();
            CbProyectoNombre.SelectedIndex = -1;
            CbProyectoNombre.Items.Clear();
        }

        public void SetAccion(FormAccion accion)
        {
            this.Accion = accion;
            this.CurrentPresupuesto = null;
            switch (this.Accion)
            {
                case FormAccion.ninguno:
                    Botones_Enabled(true, true, false, false, false);
                    Controles_Input_Enabled(false);
                    Controles_Clear();
                    break;
                case FormAccion.nuevo:
                    Botones_Enabled(false, false, false, true, true);
                    Controles_Input_Enabled(true);
                    Controles_Clear();
                    break;
                case FormAccion.visualizar:
                    Botones_Enabled(true, true, true, false, false);
                    Controles_Input_Enabled(false);
                    break;
            }
        }

        public void Cliente_Clear()
        {
            TbNumeroDocumento.Tag = null;
            TbCliente.Clear();
        }

        public void Proyecto_Clear()
        {
            TbProyectoDireccion.Clear();
            TbProyectoArea.Clear();
        }

        public void Proyecto_Cargar(List<Proyecto> proyectos)
        {
            CbProyectoNombre.Items.Clear();
            CbProyectoNombre.DisplayMember = "Nombre";
            foreach (var proyecto in proyectos)
            {
                CbProyectoNombre.Items.Add(proyecto);
            }

            if (CbProyectoNombre.Items.Count > 0) CbProyectoNombre.SelectedIndex = 0;
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

        private async void FrmPresupuesto_Load(object sender, EventArgs e)
        {
            try
            {
                CbTipoDocumentoIdentidad.Items.Clear();
                CbTipoDocumentoIdentidad.DisplayMember = "Nombre";
                var tiposDocumentoIdentidad = await LogTipoDocumentoIdentidad.Instancia.TipoDocumentoIdentidadListarActivos();
                foreach (var item in tiposDocumentoIdentidad)
                {
                    CbTipoDocumentoIdentidad.Items.Add(item);
                }

                if (CbTipoDocumentoIdentidad.Items.Count > 0) CbTipoDocumentoIdentidad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void BnNuevo_Click(object sender, EventArgs e)
        {
            SetAccion(FormAccion.nuevo);
            DtpFechaDesde.Value = DateTime.Now.Date;
            DtpFechaHasta.Value = DateTime.Now.Date.AddDays(1);
            TbCreadoPor.Text = _usuario.ApellidosNombres;
        }

        private void BnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BnAnular_Click(object sender, EventArgs e)
        {

        }

        private void BnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void BnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de cancelar? los datos que no han sido guardado se perderán", "Un momento por favor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SetAccion(FormAccion.ninguno);
            }
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CbTipoDocumentoIdentidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)CbTipoDocumentoIdentidad.SelectedItem;
            if (tipoDocumentoIdentidad == null)
            {
                TbNumeroDocumento.MaxLength = 0;
                TbNumeroDocumento.TipoCaracteres = CustomTextBox.TipoInput.Todo;
            }
            else
            {
                TbNumeroDocumento.MaxLength = tipoDocumentoIdentidad.LongitudMaxima;
                TbNumeroDocumento.TipoCaracteres = tipoDocumentoIdentidad.Alfanumerico ? CustomTextBox.TipoInput.NumerosYLetras : CustomTextBox.TipoInput.SoloNumeros;
            }
            TbNumeroDocumento.Clear();
            Cliente_Clear();
            CbProyectoNombre.Items.Clear();
        }

        private void TbNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            Cliente_Clear();
            CbProyectoNombre.Items.Clear();
        }

        private async void BnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)CbTipoDocumentoIdentidad.SelectedItem;
                if (tipoDocumentoIdentidad == null && !tipoDocumentoIdentidad.ConsultaApi)
                {
                    MessageBox.Show(this, "No se puede hacer consultas API con este tipo de documento", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TbNumeroDocumento.Text.Trim() == "")
                {
                    MessageBox.Show(this, $"Olvidó ingresar el número {tipoDocumentoIdentidad.Nombre}", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var documentoIdentidadNumero = TbNumeroDocumento.Text.Trim();
                if (tipoDocumentoIdentidad.LongitudMinima > documentoIdentidadNumero.Length)
                {
                    string mensaje = $"El tipo de documento de identidad \"{tipoDocumentoIdentidad.Nombre}\" debe tener como mínimo {tipoDocumentoIdentidad.LongitudMinima} dígitos";
                    MessageBox.Show(this, mensaje, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tipoDocumentoIdentidad.PersonaJuridica && !Cliente.RUCValido(documentoIdentidadNumero))
                {
                    string mensaje = $"El \"{tipoDocumentoIdentidad.Nombre}: {documentoIdentidadNumero}\" no tiene un formato válido";
                    MessageBox.Show(this, mensaje, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BnBuscarCliente.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                var cliente = await LogCliente.Instancia.ClienteBuscarPorDocumentoIdentidad(tipoDocumentoIdentidad.TipoDocumentoIdentidadID, TbNumeroDocumento.Text.Trim(), true);

                this.Cursor = Cursors.Default;
                if (cliente == null)
                {
                    MessageBox.Show(this, "No se encontraron datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TbNumeroDocumento.Focus();
                }
                else
                {
                    TbCliente.Text = cliente.RazonSocialOrApellidosYNombres;
                    Proyecto_Cargar(cliente.Proyectos);
                }
                BnBuscarCliente.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnBuscarCliente.Enabled = true;
            }
        }

        private void CbProyectoNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Proyecto_Clear();
            var proyecto = CbProyectoNombre.SelectedItem as Proyecto;
            if ( proyecto != null)
            {
                TbProyectoDireccion.Text = proyecto.DireccionCompleta;
                
            }
        }
    }
}
