using BimManager.Entidad;
using BimManager.Client.WipApp.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace BimManager.Client.WipApp
{
    public partial class FrmEmailEnviar : FrmBase
    {
        private readonly ComprobantePago _comprobantePago;
        public FrmEmailEnviar(ComprobantePago comprobantePago)
        {
            _comprobantePago = comprobantePago;
            InitializeComponent();
        }

        private void FrmEmailEnviar_Load(object sender, EventArgs e)
        {

        }

        #region Métodos

        public static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #endregion Métodos

        private async void BnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";

                if (this._comprobantePago == null) datosFaltantes += "\n\r - Comprobante de Pago";
                if (string.IsNullOrEmpty(TbEmail.Text.Trim())) datosFaltantes += "\n\r - Email";
               
                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var emails = TbEmail.Text.Trim().Split(',').ToList();
                emails.ForEach(x => x = x.Trim());
                string mensaje = string.Empty;
                foreach (var email in emails)
                {
                    if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
                    {
                        mensaje += "\n\r- " + email;
                    }
                }

                if (!string.IsNullOrEmpty(mensaje))
                {                    
                    MessageBox.Show(this, "Los siguientes emails no son válidos:\n" + mensaje, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BnEnviar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                //var response = await this.ObjRemoteObject.LogContrato.ContratoPagoListarPorContratoID(this.CurrentCliente);
                
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "Correo enviado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnEnviar.Enabled = true;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnEnviar.Enabled = true;
            }
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
