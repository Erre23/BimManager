using CapaEntidad;
using CapaLogica;
using CapaPresentacion.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmClienteModal : Form
    {
        private short _IdTipoDocumentoIdentidad;
        private string _NumeroDocumentoIdentidad;
        public FrmClienteModal(short idTipoDocumentoIdentidad, string numeroDocumentoIdentidad)
        {
            InitializeComponent();
            SetAccion(FormAccion.ninguno);

            _IdTipoDocumentoIdentidad = idTipoDocumentoIdentidad;
            _NumeroDocumentoIdentidad = numeroDocumentoIdentidad;
        }



        private async void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                CmbTipoDocumentoIdentidad.Items.Clear();
                CmbTipoDocumentoIdentidad.DisplayMember = "Nombre";
                var tiposDocumentoIdentidad = await LogTipoDocumentoIdentidad.Instancia.TipoDocumentoIdentidadListarActivos();
                foreach (var item in tiposDocumentoIdentidad)
                {
                    CmbTipoDocumentoIdentidad.Items.Add(item);
                }

                SetAccion(FormAccion.nuevo);

                this.CurrentCliente = new Cliente
                {
                    TipoDocumentoIdentidadID = _IdTipoDocumentoIdentidad,
                    DocumentoIdentidadNumero = _NumeroDocumentoIdentidad,
                    TipoDocumentoIdentidad = tiposDocumentoIdentidad.Find(x => x.TipoDocumentoIdentidadID == _IdTipoDocumentoIdentidad)
                };
                
                GbDatos_MostrarDatos(this.CurrentCliente);
                CmbTipoDocumentoIdentidad.Enabled = false;
                TbDocumentoIdentidadNumero.Enabled = false;

                if (this.CurrentCliente.TipoDocumentoIdentidad.PersonaJuridica) TbRazonSocial.Focus();
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
            if ((this.Accion == FormAccion.nuevo || this.Accion == FormAccion.editar) && 
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Métodos

        private FormAccion Accion;
        private Cliente CurrentCliente;
        public Cliente GetCurrentCliente { get { return this.CurrentCliente; } }

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
            this.CurrentCliente = cliente;
            for (int indice = 0; indice < CmbTipoDocumentoIdentidad.Items.Count; indice++)
            {
                if((CmbTipoDocumentoIdentidad.Items[indice] as TipoDocumentoIdentidad).TipoDocumentoIdentidadID == cliente.TipoDocumentoIdentidadID)
                {
                    CmbTipoDocumentoIdentidad.SelectedIndex = indice;
                    break;
                }
            }
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
            this.CurrentCliente = null;
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
                case FormAccion.buscar:
                    LbOpcion.Text = "OPCIÓN : BUSCAR";
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

                
                if (this.Accion == FormAccion.nuevo) this.CurrentCliente = new Cliente();
                this.CurrentCliente.TipoDocumentoIdentidad = tipoDocumentoIdentidad;
                this.CurrentCliente.TipoDocumentoIdentidadID = tipoDocumentoIdentidad.TipoDocumentoIdentidadID;
                this.CurrentCliente.DocumentoIdentidadNumero = TbDocumentoIdentidadNumero.Text.Trim();
                this.CurrentCliente.RazonSocial = tipoDocumentoIdentidad.PersonaJuridica ? TbRazonSocial.Text.Trim() : null;
                this.CurrentCliente.Nombres = tipoDocumentoIdentidad.PersonaJuridica ? null : TbNombres.Text.Trim();
                this.CurrentCliente.Apellido1 = tipoDocumentoIdentidad.PersonaJuridica ? null : TbApellido1.Text.Trim();
                this.CurrentCliente.Apellido2 = tipoDocumentoIdentidad.PersonaJuridica ? null : TbApellido2.Text.Trim();
                this.CurrentCliente.Celular = TbCelular.Text.Trim();
                this.CurrentCliente.Email = TbEmail.Text.Trim();

                if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this.Accion == FormAccion.nuevo)
                {
                    this.CurrentCliente.ClienteID = await LogCliente.Instancia.ClienteInsertar(this.CurrentCliente);
                }
                else
                {
                    await LogCliente.Instancia.ClienteActualizar(this.CurrentCliente);
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
