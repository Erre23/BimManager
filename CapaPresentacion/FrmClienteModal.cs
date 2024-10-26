using BimManager.Entidad;
using BimManager.Client.WipApp.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BimManager.Client.WipApp
{
    public partial class FrmClienteModal : FrmBase
    {
        private readonly TipoDocumentoIdentidad _tipoDocumentoIdentidad;
        private readonly string _documentoIdentidadNumero;

        private FormAccion Accion;
        private Cliente _currentCliente;
        public Cliente GetCliente { get { return this._currentCliente; } }
        public FrmClienteModal(TipoDocumentoIdentidad tipoDocumentoIdentidad, string documentoIdentidadNumero)
        {
            InitializeComponent();
            SetAccion(FormAccion.ninguno);

            _tipoDocumentoIdentidad = tipoDocumentoIdentidad;
            _documentoIdentidadNumero = documentoIdentidadNumero;
        }

        private async void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                CmbTipoDocumentoIdentidad.Items.Clear();
                CmbTipoDocumentoIdentidad.DisplayMember = "Nombre";
                var tiposDocumentoIdentidad = await this.ObjRemoteObject.LogTipoDocumentoIdentidad.TipoDocumentoIdentidadListarActivos();
                var selectedIndex = -1;
                foreach (var item in tiposDocumentoIdentidad)
                {
                    CmbTipoDocumentoIdentidad.Items.Add(item);
                    if (this._tipoDocumentoIdentidad?.TipoDocumentoIdentidadID == item.TipoDocumentoIdentidadID) selectedIndex = CmbTipoDocumentoIdentidad.Items.IndexOf(item);
                }

                SetAccion(FormAccion.nuevo);

                CmbTipoDocumentoIdentidad.SelectedIndex = selectedIndex;
                TbDocumentoIdentidadNumero.Text = this._documentoIdentidadNumero;

                CmbTipoDocumentoIdentidad.Enabled = false;
                TbDocumentoIdentidadNumero.Enabled = false;

                if (this._tipoDocumentoIdentidad.PersonaJuridica) TbRazonSocial.Focus();
                else TbNombres.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void FrmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.DialogResult != DialogResult.OK) && 
                MessageBox.Show(this, "¿Está seguro de cancelar? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Métodos

        public void GBDatos_Limpiar()
        {
            CmbTipoDocumentoIdentidad.SelectedIndex = -1;
            TbDocumentoIdentidadNumero.Clear();
            TbNombres.Clear();
            TbApellido1.Clear();
            TbApellido2.Clear();
            TbRazonSocial.Clear();
            TbCelular.Clear();
            TbEmail.Clear();
        }

        private void GbDatos_MostrarDatos(Cliente cliente)
        {
            this._currentCliente = cliente;
            CmbTipoDocumentoIdentidad.SelectedIndex = CmbTipoDocumentoIdentidad.Items.IndexOf(cliente.TipoDocumentoIdentidad);            
            TbDocumentoIdentidadNumero.Text = cliente.DocumentoIdentidadNumero;
            if (cliente.TipoDocumentoIdentidad.PersonaJuridica)
            {
                TbRazonSocial.Text = cliente.RazonSocial;
            }
            else
            {
                TbNombres.Text = cliente.Nombres;
                TbApellido1.Text = cliente.Apellido1;
                TbApellido2.Text = cliente.Apellido2;
            }
            TbCelular.Text = cliente.Celular;
            TbEmail.Text = cliente.Email;
        }

        public void SetAccion(FormAccion accion)
        {
            GBDatos_Limpiar();
            this.Accion = accion;
            this._currentCliente = null;
            switch(this.Accion)
            {
                case FormAccion.ninguno:
                    LbOpcion.Text = "";
                    GbDatos.Enabled = false;
                    break;
                case FormAccion.nuevo:
                    LbOpcion.Text = "OPCIÓN : NUEVO";
                    CmbTipoDocumentoIdentidad.SelectedIndex = 0;
                    GbDatos.Enabled = true;
                    break;
                case FormAccion.editar:
                    LbOpcion.Text = "OPCIÓN : EDITAR";
                    GbDatos.Enabled = true;
                    break;
            }
        }

        private void ControlesPersonaJuridica_Mostrar(bool show)
        {
            LbNombres.Visible = !show;
            TbNombres.Visible = !show;
            LbApellido1.Visible = !show;
            TbApellido1.Visible = !show;
            LbApellido2.Visible = !show;
            TbApellido2.Visible = !show;

            LbRazonSocial.Visible = show;
            TbRazonSocial.Visible = show;

            LbCelular.Location = show ? new Point(75, 108) : new Point(75, 143);
            TbCelular.Location = show ? new Point(153, 106) : new Point(153, 140);
            LbEmail.Location = show ? new Point(479, 108) : new Point(479, 143);
            TbEmail.Location = show ? new Point(547, 106) : new Point(547, 140);
        }

        #endregion Métodos

        private void CmbTipoDocumentoIdentidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)CmbTipoDocumentoIdentidad.SelectedItem;
            if (tipoDocumentoIdentidad == null)
            {
                TbDocumentoIdentidadNumero.MaxLength = 0;
                TbDocumentoIdentidadNumero.TipoCaracteres = CustomTextBox.TipoInput.Todo;
                ControlesPersonaJuridica_Mostrar(false);
            }
            else
            {
                TbDocumentoIdentidadNumero.MaxLength = tipoDocumentoIdentidad.LongitudMaxima;
                TbDocumentoIdentidadNumero.TipoCaracteres = tipoDocumentoIdentidad.Alfanumerico ? CustomTextBox.TipoInput.NumerosYLetras : CustomTextBox.TipoInput.SoloNumeros;
                ControlesPersonaJuridica_Mostrar(tipoDocumentoIdentidad.PersonaJuridica);
            }
            TbDocumentoIdentidadNumero.Clear();
        }

        private async void BnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";
                var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)CmbTipoDocumentoIdentidad.SelectedItem;

                if (TbDocumentoIdentidadNumero.Text.Trim() == "") datosFaltantes += "\n\r - Nº de documento de identidad";
                if (tipoDocumentoIdentidad.PersonaJuridica)
                {
                    if (TbRazonSocial.Text.Trim() == "") datosFaltantes += "\n\r - Razón Social";
                }
                else
                {
                    if (TbNombres.Text.Trim() == "") datosFaltantes += "\n\r - Nombres";
                    if (TbApellido1.Text.Trim() == "") datosFaltantes += "\n\r - Apellido1";
                }

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var documentoIdentidadNumero = TbDocumentoIdentidadNumero.Text.Trim();
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

                
                if (this.Accion == FormAccion.nuevo) this._currentCliente = new Cliente();
                this._currentCliente.TipoDocumentoIdentidad = tipoDocumentoIdentidad;
                this._currentCliente.TipoDocumentoIdentidadID = tipoDocumentoIdentidad.TipoDocumentoIdentidadID;
                this._currentCliente.DocumentoIdentidadNumero = TbDocumentoIdentidadNumero.Text.Trim();
                this._currentCliente.RazonSocial = tipoDocumentoIdentidad.PersonaJuridica ? TbRazonSocial.Text.Trim() : null;
                this._currentCliente.Nombres = tipoDocumentoIdentidad.PersonaJuridica ? null : TbNombres.Text.Trim();
                this._currentCliente.Apellido1 = tipoDocumentoIdentidad.PersonaJuridica ? null : TbApellido1.Text.Trim();
                this._currentCliente.Apellido2 = tipoDocumentoIdentidad.PersonaJuridica ? null : TbApellido2.Text.Trim();
                this._currentCliente.Celular = TbCelular.Text.Trim();
                this._currentCliente.Email = TbEmail.Text.Trim();

                if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this.Accion == FormAccion.nuevo)
                {
                    this._currentCliente.ClienteID = await this.ObjRemoteObject.LogCliente.ClienteInsertar(this._currentCliente);
                }
                else
                {
                    await this.ObjRemoteObject.LogCliente.ClienteActualizar(this._currentCliente);
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
