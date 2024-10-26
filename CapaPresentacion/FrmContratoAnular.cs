using CapaEntidad;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmContratoAnular : FrmBase
    {
        private Contrato _contrato;
        public Contrato GetContrato { get { return _contrato; } }

        public FrmContratoAnular(Contrato contrato, Usuario usuario)
        {
            InitializeComponent();
            this._contrato = contrato;
            this._usuario = usuario;

            TbNumeroContrato.Text = this._contrato.PresupuestoID.ToString();
            TbAnuladoPor.Text = this._usuario.ApellidosNombres;
        }

        private void FrmContratoAnular_Load(object sender, EventArgs e)
        {
            TbMotivo.Focus();
        }

        private async void BnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TbMotivo.Text.Trim()))
                {
                    MessageBox.Show(this, "Olvidó ingresar el motivo de la anulación", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var mensaje = $"¿Está seguro de anular el contrato Nº: {this._contrato.ContratoID}? una vez anulado no se podrá revertir la operación";
                if (MessageBox.Show(this, mensaje, "Un momento por favor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                this._contrato.UltActEstadoUsuarioID = this._usuario.UsuarioID;
                this._contrato.UltActEstadoUsuario = this._usuario;                
                this._contrato.UltActEstadoComentario = TbMotivo.Text.Trim();
                this._contrato = await this.ObjRemoteObject.LogContrato.ContratoAnular(this._contrato);
                MessageBox.Show(this, "El contrato ha sido anulado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPresupuestoAnular_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.DialogResult != DialogResult.OK) &&
                MessageBox.Show(this, "¿Está seguro de cancelar? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
