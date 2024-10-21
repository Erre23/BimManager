using CapaEntidad;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPresupuestoAnular : FrmBase
    {
        private Presupuesto _presupuesto;
        private readonly Usuario _usuario;

        public FrmPresupuestoAnular(Presupuesto presupuesto, Usuario usuario)
        {
            InitializeComponent();
            this._presupuesto = presupuesto;
            this._usuario = usuario;

            TbNumeroPresupuesto.Text = this._presupuesto.PresupuestoID.ToString();
            TbAnuladoPor.Text = this._usuario.ApellidosNombres;
        }

        private void FrmPresupuestoAnular_Load(object sender, EventArgs e)
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

                var mensaje = $"¿Está seguro de anular el presupuesto Nº: {this._presupuesto.PresupuestoID}? una vez anulado no se podrá revertir la operación";
                if (MessageBox.Show(this, mensaje, "Un momento por favor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                this._presupuesto.AnulacionUsuarioID = this._usuario.UsuarioID;
                this._presupuesto.AnulacionMotivo = TbMotivo.Text.Trim();
                await this.ObjRemoteObject.LogPresupuesto.PresupuestoAnular(this._presupuesto);
                MessageBox.Show(this, "El presupuesto ha sido anulado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
