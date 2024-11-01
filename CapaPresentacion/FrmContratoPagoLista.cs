using BimManager.Entidad;
using BimManager.Client.WipApp.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BimManager.Client.WipApp
{
    public partial class FrmContratoPagoLista : FrmBase
    {
        private Contrato _currentContrato;
        public Contrato GetContrato { get { return this._currentContrato; } }

        public FrmContratoPagoLista(Contrato contrato, Usuario usuario)
        {
            InitializeComponent();
            _currentContrato = contrato;
            _usuario = usuario;
        }

		public void DgvContratoPago_AddRow(ContratoPago contratoPago)
        {
            var index = -1;

            index = DgvContratoPago.Rows.Add(
                contratoPago.CuentaBancaria.NumeroCuentaCompleto,
                contratoPago.NumeroOperacion,
                contratoPago.PagoFecha,
                contratoPago.Importe,
                contratoPago.ComprobantePago.TipoDocumentoSunat.Nombre,
                contratoPago.ComprobantePago.SerieCorrelativo,
                contratoPago.Anulado ? "ANULADO" : "",
                ""
            );

            DgvContratoPago.Rows[index].Tag = contratoPago;
            if (contratoPago.Anulado)
            {
                DgvContratoPago.Rows[index].Cells[6].Style.BackColor = Color.Red;
                DgvContratoPago.Rows[index].Cells[6].Style.ForeColor = Color.White;
                DgvContratoPago.Rows[index].Cells[6].Style.SelectionBackColor = Color.Red;
                DgvContratoPago.Rows[index].Cells[6].Style.SelectionForeColor = Color.White;
            }
        }

        private async void FrmContratoPagoLista_Load(object sender, EventArgs e)
        {
            try
            {
                DgvContratoPago.Rows.Clear();
                this.Cursor = Cursors.WaitCursor;

                var listaContratoPagos = await this.ObjRemoteObject.LogContrato.ContratoPagoListarPorContratoID(_currentContrato.ContratoID);
                foreach (var contratoPago in listaContratoPagos)
                {
                    DgvContratoPago_AddRow(contratoPago);
                }

                this.Cursor = Cursors.Default;
                if (DgvContratoPago.Rows.Count == 0)
                {
                    DgvContratoPago.ContextMenuStrip = null;
                    MessageBox.Show(this, "No se encontraron resultados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DgvContratoPago.ContextMenuStrip = this.CmsOpciones;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enviarASUNATMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ConsultaCdrASunatMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void DocumentoXmlMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvContratoPago.CurrentRow == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un pago", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                var obj = DgvContratoPago.CurrentRow.Tag as ContratoPago;
                if (obj.ComprobantePago.ComprobantePagoDocumento == null)
                {
                    obj.ComprobantePago.ComprobantePagoDocumento = await this.ObjRemoteObject.LogContrato.ComprobantePagoDocumentoBuscarPorComprobantePagoID(obj.ComprobantePagoId);
                    DgvContratoPago.CurrentRow.Tag = obj;
                }
                Cursor = Cursors.Arrow;

                SaveFileDialog objSfd = Archivo_Guardar_Crear_SaveFileDialog("Archivo xml|*.xml");
                objSfd.FileName = obj.ComprobantePago.NombreDocumento_Formato_Sunat + ".xml";
                if (objSfd.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    System.IO.File.WriteAllBytes(objSfd.FileName, obj.ComprobantePago.ComprobantePagoDocumento.DocumentoXML_En_ArrayByte);
                    Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DocumentoPdfMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvContratoPago.CurrentRow == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un pago", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var obj = DgvContratoPago.CurrentRow.Tag as ContratoPago;
                if (obj.ComprobantePago.ComprobantePagoDocumento == null)
                {
                    obj.ComprobantePago.ComprobantePagoDocumento = await this.ObjRemoteObject.LogContrato.ComprobantePagoDocumentoBuscarPorComprobantePagoID(obj.ComprobantePagoId);
                    DgvContratoPago.CurrentRow.Tag = obj;
                }

                SaveFileDialog objSfd = Archivo_Guardar_Crear_SaveFileDialog("Archivo pdf|*.pdf");
                objSfd.FileName = obj.ComprobantePago.NombreDocumento_Formato_Sunat + ".pdf";
                if (objSfd.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    new Sunat.Entidad.RepresentacionImpresa.ComprobanteElectronico(obj.ComprobantePago.ComprobantePagoDocumento.DocumentoXML).Generar_Ticket_En_Pdf(objSfd.FileName);
                    Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CdrXmlMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvContratoPago.CurrentRow == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un pago", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var obj = DgvContratoPago.CurrentRow.Tag as ContratoPago;
                if (obj.ComprobantePago.ComprobantePagoDocumento == null)
                {
                    obj.ComprobantePago.ComprobantePagoDocumento = await this.ObjRemoteObject.LogContrato.ComprobantePagoDocumentoBuscarPorComprobantePagoID(obj.ComprobantePagoId);
                    DgvContratoPago.CurrentRow.Tag = obj;
                }

                if (string.IsNullOrEmpty(obj.ComprobantePago.ComprobantePagoDocumento.CDRXML))
                {
                    MessageBox.Show(this, "El comprobante no tiene una CDR", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                SaveFileDialog objSfd = Archivo_Guardar_Crear_SaveFileDialog("Archivo xml|*.xml");
                objSfd.FileName = "R-" + obj.ComprobantePago.NombreDocumento_Formato_Sunat + ".xml";
                if (objSfd.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    System.IO.File.WriteAllBytes(objSfd.FileName, obj.ComprobantePago.ComprobantePagoDocumento.CDRXML_En_ArrayByte);
                    Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enviarEmailMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
