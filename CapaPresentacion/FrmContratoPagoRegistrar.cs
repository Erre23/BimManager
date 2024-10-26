using CapaEntidad;
using CapaPresentacion.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmContratoPagoRegistrar : FrmBase
    {
        private FormAccion Accion;

        private Contrato _currentContrato;
        public Contrato GetContrato { get { return this._currentContrato; } }

        private ContratoPago _currentContratoPago;
        public ContratoPago GetContratoPago { get { return this._currentContratoPago; } }

        public FrmContratoPagoRegistrar(Contrato contrato, Usuario usuario)
        {
            InitializeComponent();
            SetAccion(FormAccion.ninguno);
            _currentContrato = contrato;
            _usuario = usuario;
        }

        private async void FrmContratoPagoRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                CbCuentaBancaria.Items.Clear();
                CbCuentaBancaria.DisplayMember = "NumeroCuentaCompleto";
                var cuentasBancarias = await this.ObjRemoteObject.LogContrato.CuentaBancariaListarActivos();
                foreach (var item in cuentasBancarias)
                {
                    CbCuentaBancaria.Items.Add(item);
                }

                SetAccion(FormAccion.nuevo);

                if (CbCuentaBancaria.Items.Count > 0) CbCuentaBancaria.SelectedIndex = 0;
                
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
            CbCuentaBancaria.SelectedIndex = -1;
            DtpPagoFecha.Text = string.Empty;
            TbImporte.Clear();
        }

        public void SetAccion(FormAccion accion)
        {
            GBDatos_Limpiar();
            this.Accion = accion;
            this._currentContratoPago = null;
            switch(this.Accion)
            {
                case FormAccion.ninguno:
                    LbOpcion.Text = "";
                    GbDatos.Enabled = false;
                    break;
                case FormAccion.nuevo:
                    LbOpcion.Text = "OPCIÓN : NUEVO";
                    CbCuentaBancaria.SelectedIndex = 0;
                    GbDatos.Enabled = true;
                    break;
                case FormAccion.editar:
                    LbOpcion.Text = "OPCIÓN : EDITAR";
                    GbDatos.Enabled = true;
                    break;
            }
        }

        #endregion Métodos

        private async void BnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";
                var cuentaBancaria = (CuentaBancaria)CbCuentaBancaria.SelectedItem;

                if (cuentaBancaria == null) datosFaltantes += "\n\r - CuentaBancaria";
                if (TbNumeroOperacion.Text.Trim() == "") datosFaltantes += "\n\r - Nº Operación";
                var importe = Convert.ToDecimal(string.IsNullOrEmpty(TbImporte.Text.Trim()) ? "0" : TbImporte.Text.Trim());
                if (importe <= 0) datosFaltantes += "\n\r - Importe";                

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (importe > _currentContrato.Presupuesto.ImporteTotal)
                {
                    string mensaje = $"El importe del pago no puede ser al mayor monto faltante del contrato \"{_currentContrato.Presupuesto.ImporteTotal.ToString("#,#0.00")}\"";
                    MessageBox.Show(this, mensaje, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (this.Accion == FormAccion.nuevo) this._currentContratoPago = new ContratoPago();
                this._currentContratoPago.ContratoID = this._currentContrato.ContratoID;
                this._currentContratoPago.CreacionUsuarioID = this._usuario.UsuarioID;
                this._currentContratoPago.CuentaBancariaID = cuentaBancaria.CuentaBancariaID;
                this._currentContratoPago.CuentaBancaria = cuentaBancaria;
                this._currentContratoPago.NumeroOperacion = TbNumeroOperacion.Text.Trim();
                this._currentContratoPago.PagoFecha = DtpPagoFecha.Value.Date;
                this._currentContratoPago.Importe = importe;

                if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this.Accion == FormAccion.nuevo)
                {
                    if (this._currentContrato.ContratoID == 0)
                    {
                        this._currentContrato = await this.ObjRemoteObject.LogContrato.ContratoInsertar(this._currentContrato, this._currentContratoPago);
                    }
                    else
                    {
                        //this._currentContratoPago = await this.ObjRemoteObject.LogContrato.ContratoPagoInsertar(this._currentContrato);
                    }
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
