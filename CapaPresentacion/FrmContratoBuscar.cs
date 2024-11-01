using BimManager.Entidad;
using BimManager.Client.WipApp.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BimManager.Client.WipApp
{
    public partial class FrmContratoBuscar : FrmBase
    {
        public FrmContratoBuscar(byte? filtroContratoEstadoId = null)
        {
            InitializeComponent();
            _filtroContratoEstadoId = filtroContratoEstadoId;
        }

        private Contrato _contratoSeleccionado;
        public Contrato GetContratoSeleccionado { get { return this._contratoSeleccionado; } }
        private readonly byte? _filtroContratoEstadoId;

       

        public void Cliente_Clear()
        {
            TbCliente.Tag = null;
            TbCliente.Clear();
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

		public void DgvContrato_AddRow(Contrato contrato)
        {
            var index = -1;

            index = DgvContrato.Rows.Add(
                contrato.ContratoID,
                contrato.ContratoEstado.Nombre,
                contrato.FechaInicio.Date.ToString("dd/MM/yyyy"),
                contrato.FechaEstimadaEntrega.Date.ToString("dd/MM/yyyy"),
                contrato.PresupuestoID,
                contrato.Presupuesto.Cliente.RazonSocialOrApellidosYNombres,
                contrato.Presupuesto.Proyecto.Nombre,
                contrato.Presupuesto.AreaTotal,
                contrato.Presupuesto.AreaTechada,
                contrato.Presupuesto.NumeroPisos,
                contrato.Presupuesto.Plan.Nombre,
                contrato.Presupuesto.Plan.CostoPorM2.ToString("#,#0.00"),
                contrato.Presupuesto.Plan.PlazoRango,
                contrato.Presupuesto.ImporteTotal.ToString("#,#0.00")
            );

            DgvContrato.Rows[index].Tag = contrato;
            DgvContrato.Rows[index].Cells[1].Style.BackColor = contrato.ContratoEstado.Color;
            DgvContrato.Rows[index].Cells[1].Style.SelectionBackColor = contrato.ContratoEstado.Color;
            DgvContrato.Rows[index].Cells[1].Style.SelectionForeColor = Color.Black;
        }

        private async void FrmPresupuesto_Load(object sender, EventArgs e)
        {
            try
            {
                ControlesBusqueda_MostrarOcultar();
                CbTipoDocumentoIdentidad.Items.Clear();
                CbTipoDocumentoIdentidad.DisplayMember = "Nombre";
                var tiposDocumentoIdentidad = await this.ObjRemoteObject.LogTipoDocumentoIdentidad.TipoDocumentoIdentidadListarActivos();
                foreach (var item in tiposDocumentoIdentidad)
                {
                    CbTipoDocumentoIdentidad.Items.Add(item);
                }
                CbTipoDocumentoIdentidad.SelectedIndex = -1;

                CbEstado.Items.Clear();
                CbEstado.DisplayMember = "Nombre";
                var contratoEstados = await this.ObjRemoteObject.LogContrato.ContratoEstadoListar();
                if (_filtroContratoEstadoId == null)
                {
                    contratoEstados.Insert(0, new ContratoEstado { Nombre = "TODOS" });
                }
                else
                {
                    contratoEstados = contratoEstados.FindAll(x => x.ContratoEstadoID == _filtroContratoEstadoId);
                }
                foreach (var item in contratoEstados)
                {
                    CbEstado.Items.Add(item);
                }
                CbEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvContrato.CurrentRow == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un presupuesto", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                this._contratoSeleccionado = DgvContrato.CurrentRow.Tag as Contrato;
                this._contratoSeleccionado.Presupuesto.PresupuestoDetalles = await this.ObjRemoteObject.LogPresupuesto.PresupuestoDetalleBuscarPorPresupuestoID(this._contratoSeleccionado.Presupuesto.PresupuestoID);
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

                if (tipoDocumentoIdentidad == null)
                {
                    MessageBox.Show(this, $"Olvidó seleccionar el tipo de documento de identidad", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var cliente = await this.ObjRemoteObject.LogCliente.ClienteBuscarPorDocumentoIdentidad(tipoDocumentoIdentidad.TipoDocumentoIdentidadID, TbNumeroDocumento.Text.Trim(), true);

                this.Cursor = Cursors.Default;
                if (cliente == null)
                {
                    MessageBox.Show(this, "No se encontraron datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TbNumeroDocumento.Focus();
                }
                else
                {
                    TbCliente.Text = cliente.RazonSocialOrApellidosYNombres;
                    TbCliente.Tag = cliente;
                    var proyectos = await this.ObjRemoteObject.LogProyecto.ProyectoBuscarPorClienteID(cliente.ClienteID);
                    Proyecto_Cargar(proyectos.FindAll(x => x.Activo).OrderBy(x => x.Nombre).ToList());
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

        private async void BnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var contratoID = Convert.ToInt32(string.IsNullOrEmpty(TbNumeroContrato.Text.Trim()) ? "0" : TbNumeroContrato.Text.Trim());
                var presupuestoID = Convert.ToInt32(string.IsNullOrEmpty(TbNumeroPresupuesto.Text.Trim()) ? "0" : TbNumeroPresupuesto.Text.Trim());
                var fechaDesde = DtpFechaDesde.Value.Date;
                var fechaHasta = DtpFechaHasta.Value.Date;
                var cliente = TbCliente.Tag as Cliente;
                var proyecto = CbProyectoNombre.SelectedItem as Proyecto;

                if (RbNumeroContrato.Checked)
                {
                    if (contratoID <= 0)
                    {
                        MessageBox.Show(this, "Olvidó ingresar el número de contrato", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (RbNumeroPresupuesto.Checked)
                {
                    if (presupuestoID <= 0)
                    {
                        MessageBox.Show(this, "Olvidó ingresar el número de presupuesto", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (fechaDesde.Date > fechaHasta.Date)
                    {
                        MessageBox.Show(this, "La fecha de busqueda inicial no puede ser mayor a la fecha de búsqueda final", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                DgvContrato.Rows.Clear();
                BnBuscar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (RbNumeroContrato.Checked)
                {
                    var contrato = await this.ObjRemoteObject.LogContrato.ContratoBuscarPorContratoID(contratoID);
                    if (contrato != null) DgvContrato_AddRow(contrato);
                }
                else if (RbNumeroPresupuesto.Checked)
                {
                    var contrato = await this.ObjRemoteObject.LogContrato.ContratoBuscarPorPresupuestoID(presupuestoID);
                    if (contrato != null) DgvContrato_AddRow(contrato);
                }
                else
                {
                    var contratoEstado = CbEstado.SelectedItem as ContratoEstado;
                    var contratoEstadoId = contratoEstado?.ContratoEstadoID;
                    if (contratoEstadoId == 0) contratoEstadoId = null;

                    var listaContratos = await this.ObjRemoteObject.LogContrato.ContratoBusquedaGeneral(fechaDesde, fechaHasta, cliente?.ClienteID, proyecto?.ProyectoID, contratoEstadoId);
                    foreach (var contrato in listaContratos)
                    {
                        DgvContrato_AddRow(contrato);
                    }
                }

                this.Cursor = Cursors.Default;
                if (DgvContrato.Rows.Count == 0) MessageBox.Show(this, "No se encontraron resultados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BnBuscar.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnBuscar.Enabled = true;
            }
        }

        private void RbNumeroContrato_CheckedChanged(object sender, EventArgs e)
        {
            ControlesBusqueda_MostrarOcultar();
        }

        private void RbNumeroPresupuesto_CheckedChanged(object sender, EventArgs e)
        {
            ControlesBusqueda_MostrarOcultar();
        }

        private void RbBusquedaDetallada_CheckedChanged(object sender, EventArgs e)
        {
            ControlesBusqueda_MostrarOcultar();
        }

        private void ControlesBusqueda_MostrarOcultar()
        {
            var visibleGrupo1 = RbNumeroContrato.Checked;
            var visibleGrupo2 = RbNumeroPresupuesto.Checked;
            var visibleGrupo3 = RbBusquedaDetallada.Checked;

            LbContrato.Visible = visibleGrupo1;
            TbNumeroContrato.Visible = visibleGrupo1;

            LbPresupuesto.Visible = visibleGrupo2;
            TbNumeroPresupuesto.Visible = visibleGrupo2;

            LbDesde.Visible = visibleGrupo3;
            DtpFechaDesde.Visible = visibleGrupo3;
            LbAl.Visible = visibleGrupo3;
            DtpFechaHasta.Visible = visibleGrupo3;
            LbEstado.Visible = visibleGrupo3;
            CbEstado.Visible = visibleGrupo3;
            LbTipoDocumentoIdentidad.Visible = visibleGrupo3;
            CbTipoDocumentoIdentidad.Visible = visibleGrupo3;
            LbDocumentoIdentidadNumero.Visible = visibleGrupo3;
            TbNumeroDocumento.Visible = visibleGrupo3;
            BnBuscarCliente.Visible = visibleGrupo3;
            LbCliente.Visible = visibleGrupo3;
            TbCliente.Visible = visibleGrupo3;
            LbProyecto.Visible = visibleGrupo3;
            CbProyectoNombre.Visible = visibleGrupo3;

            if (visibleGrupo1 || visibleGrupo2)
            {
                GbDatosBusqueda.Size = new Size(847, 60);
                BnBuscar.Location = new Point(863, 103);
            }
            else if (visibleGrupo3)
            {
                GbDatosBusqueda.Size = new Size(847, 180);
                BnBuscar.Location = new Point(863, 223);
            }

            int locationY = GbDatosBusqueda.Location.Y + GbDatosBusqueda.Size.Height + 5;
            int height = BnAceptar.Location.Y - locationY - 5;

            GbResultados.Location = new Point(GbResultados.Location.X, locationY);
            GbResultados.Size = new Size(GbResultados.Size.Width, height);
        }
    }
}
