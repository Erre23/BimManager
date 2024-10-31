using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static BimManager.Sunat.Entidad.CDR;

namespace BimManager.Client.WipApp
{
    public partial class FrmContrato : FrmBase
    {
        public FrmContrato(ToolStripMenuItem menu, Usuario usuario)
        {
            _menu = menu;
            _menu.Enabled = false;
            _usuario = usuario;
            InitializeComponent();
            SetAccion(FormAccion.ninguno);
        }

        private List<PresupuestoCategoria> _presupuestoCategorias;
        private FormAccion _accion;
        private Contrato _currentContrato;


        public void SetAccion(FormAccion accion)
        {
            this._accion = accion;
            switch (this._accion)
            {
                case FormAccion.ninguno:
                    Botones_Enabled(true, true, false, false, false, false);
                    Controles_Input_Enabled(false);
                    Controles_Clear();
                    break;
                case FormAccion.nuevo:
                    this._currentContrato = null;
                    Botones_Enabled(false, false, false, false, true, true);
                    Controles_Input_Enabled(true);
                    Controles_Clear();
                    DtpFechaInicio.MinDate = DateTime.Now.Date;
                    DtpFechaInicio.Value = DateTime.Now.Date;
                    break;
                case FormAccion.visualizar:
                    Botones_Enabled(true, true, true, true, false, false);
                    Controles_Input_Enabled(false);
                    break;
            }
        }

        public void Botones_Enabled(bool nuevo, bool buscar, bool anular, bool pagos, bool guardar, bool cancelar)
        {
            BnNuevo.Enabled = nuevo;
            BnBuscar.Enabled = buscar;
            BnAnular.Enabled = anular;
            BnPagos.Enabled = pagos;
            BnGuardar.Enabled = guardar;
            BnCancelar.Enabled = cancelar;
        }

        public void Controles_Input_Enabled(bool enabled)
        {
            DtpFechaInicio.Enabled = enabled;
            BnBuscarPresupuesto.Enabled = enabled;
        }

        public void Controles_Clear()
        {
            TbContratoNumero.Clear();
            TbContratoEstado.Clear();
            TbContratoEstado.BackColor = SystemColors.Control;
            DtpFechaInicio.Text = string.Empty;
            DtpFechaEstimadaEntrega.Text = string.Empty;
            TbContratoUsuario.Clear();
            
            TbPresupuestoNumero.Clear();
            TbPresupuestoNumero.Tag = null;
            TbCliente.Clear();

            TbProyectoNombre.Clear();
            TbProyectoDireccion.Clear();
            TbProyectoAreaTotal.Clear();
            TbProyectoAreaTechada.Clear();
            TbProyectoPisos.Clear();

            TbPlanNombre.Clear();
            TbPlanPrecio.Clear();
            TbPlanPlazo.Clear();
            
            DgvPresupuestoCategoria.Rows.Clear();

            TbMontoTotal.Clear();
            TbMontoPagado.Clear();
            TbMontoFaltante.Clear();
        }

        private void Contrato_Mostrar(Contrato contrato)
        {
            this._currentContrato = contrato;
            Presupuesto_Mostrar(contrato.Presupuesto);
            TbContratoNumero.Text = contrato.ContratoID.ToString();
            DtpFechaInicio.MinDate = contrato.FechaInicio.Date;
            DtpFechaInicio.Value = contrato.FechaInicio.Date;
            DtpFechaEstimadaEntrega.Value = contrato.FechaEstimadaEntrega.Date;
            SetDatosEstado(contrato);
            SetDatosMonto(contrato);
        }

        private void Presupuesto_Mostrar(Presupuesto presupuesto)
        {
            TbPresupuestoNumero.Tag = presupuesto;
            TbPresupuestoNumero.Text = presupuesto.PresupuestoID.ToString();
            TbCliente.Text = presupuesto.Cliente.TipoDocumentoIdentidad_RazonSocialOrApellidosYNombres;

            TbProyectoNombre.Text = presupuesto.Proyecto.Nombre;
            TbProyectoDireccion.Text = presupuesto.Proyecto.DireccionCompleta;
            TbProyectoAreaTotal.Text = presupuesto.AreaTotal.ToString("#,#0");
            TbProyectoAreaTechada.Text = presupuesto.AreaTechada.ToString("#,#0");
            TbProyectoPisos.Text = presupuesto.NumeroPisos.ToString();

            TbPlanNombre.Text = presupuesto.Plan.Nombre;
            TbPlanPrecio.Text = presupuesto.Plan.CostoPorM2.ToString("#,#0.00");
            TbPlanPlazo.Text = presupuesto.Plan.PlazoRango;

            PresupuestoCategoria_Cargar_For_Visualizer(presupuesto.PresupuestoDetalles);
            TbMontoTotal.Text = presupuesto.ImporteTotal.ToString("#,#0.00");
            TbMontoPagado.Text = "0.00";
            TbMontoFaltante.Text = presupuesto.ImporteTotal.ToString("#,#0.00");
        }

        public void PresupuestoCategoria_Cargar_For_Visualizer(List<PresupuestoDetalle> presupuestoDetalles)
        {
            DgvPresupuestoCategoria.Rows.Clear();
            PresupuestoCategoria_Cargar_For_Visualizer(_presupuestoCategorias, presupuestoDetalles);
        }

        public void PresupuestoCategoria_Cargar_For_Visualizer(List<PresupuestoCategoria> presupuestoCategorias, List<PresupuestoDetalle> presupuestoDetalles)
        {
            foreach (var cat in presupuestoCategorias)
            {
                var presupuestoDetalle = presupuestoDetalles.Find(x => x.PresupuestoCategoriaID == cat.PresupuestoCategoriaID);
                if (presupuestoDetalle != null)
                {
                    presupuestoDetalle.Seleccionar = true;
                }
                else if (cat.PadrePresupuestoCategoriaID != null)
                {
                    presupuestoDetalle = new PresupuestoDetalle
                    {
                        PresupuestoCategoriaID = cat.PresupuestoCategoriaID,
                        PresupuestoCategoria = cat,
                        Porcentaje = cat.Porcentaje
                    };
                }
                else
                {
                    continue;
                }

                presupuestoDetalle.PresupuestoCategoria = cat;

                DgvPresupuestoCategoria_AddRow(presupuestoDetalle);

                if (cat.SubPresupuestoCategorias.Count() > 0) PresupuestoCategoria_Cargar_For_Visualizer(cat.SubPresupuestoCategorias, presupuestoDetalles);
            }
        }

        public void DgvPresupuestoCategoria_AddRow(PresupuestoDetalle presupuestoDetalle)
        {
            var index = -1;
            if (presupuestoDetalle.PresupuestoCategoria.PadrePresupuestoCategoriaID == null)
            {
                index = DgvPresupuestoCategoria.Rows.Add(
                    presupuestoDetalle.Seleccionar,
                    presupuestoDetalle.PresupuestoCategoria.Nombre,
                    presupuestoDetalle.PresupuestoCategoria.Observaciones,
                    $"{presupuestoDetalle.PresupuestoCategoria.Porcentaje}%",
                    presupuestoDetalle.Importe.ToString("#,#0.00")
                );

                DgvPresupuestoCategoria.Rows[index].DefaultCellStyle.BackColor = Color.Khaki;
            }
            else
            {
                index = DgvPresupuestoCategoria.Rows.Add(
                    presupuestoDetalle.Seleccionar,
                    presupuestoDetalle.PresupuestoCategoria.Nombre,
                    presupuestoDetalle.PresupuestoCategoria.Observaciones
                );

                DgvPresupuestoCategoria.Rows[index].DefaultCellStyle.BackColor = Color.Gainsboro;
                DgvPresupuestoCategoria.Rows[index].Cells[0].Style.BackColor = Color.Black;
            }

            DgvPresupuestoCategoria.Rows[index].Tag = presupuestoDetalle;
        }

        private void FechaEstimadaEntrega_Calcular()
        {
            var fechaInicio = DtpFechaInicio.Value;
            var presupuesto = TbPresupuestoNumero.Tag as Presupuesto;
            if (fechaInicio != null && presupuesto != null)
            {
                DtpFechaEstimadaEntrega.Value = fechaInicio.AddDays(presupuesto.Plan.PlazoDiasMaximo);
            }
        }

        private void SetDatosEstado(Contrato contrato)
        {
            TbContratoEstado.Text = contrato.ContratoEstado.Nombre;
            TbContratoEstado.BackColor = contrato.ContratoEstado.Color;
            TbContratoUsuario.Text = contrato.UltimoEstadoUsuario;
            TbContratoComentario.Text = contrato.UltimoEstadoComentario;
        }

        private void SetDatosMonto(Contrato contrato)
        {
            TbMontoTotal.Text = contrato.Presupuesto.ImporteTotal.ToString("#,#0.00");
            TbMontoPagado.Text = contrato.MontoPagado.ToString("#,#0.00");
            TbMontoFaltante.Text = contrato.MontoFaltante.ToString("#,#0.00"); ;
        }

        private async void FrmContrato_Load(object sender, EventArgs e)
        {
            try
            {
                _presupuestoCategorias = await this.ObjRemoteObject.LogPresupuestoCategoria.PresupuestoCategoriaBuscarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmContrato_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._menu.Enabled = true;
        }

        private void FrmContrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this._accion == FormAccion.nuevo || this._accion == FormAccion.editar) &&
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BnNuevo_Click(object sender, EventArgs e)
        {
            SetAccion(FormAccion.nuevo);
            if (Presupuesto_Buscar() == DialogResult.OK)
            {
                DtpFechaInicio.Value = DateTime.Now.Date;
                TbContratoUsuario.Text = _usuario.ApellidosNombres;
                DtpFechaInicio.Focus();
            }
            else
            {
                SetAccion(FormAccion.ninguno);
            }
        }

        private void BnBuscar_Click(object sender, EventArgs e)
        {
            var form = new FrmContratoBuscar();
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            if (form.ShowDialog() == DialogResult.OK)
            {
                Contrato_Mostrar(form.GetContratoSeleccionado);
                SetAccion(FormAccion.visualizar);
            }
            form.Dispose();
        }

        private void BnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._currentContrato == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un contrato", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (this._currentContrato.ContratoEstadoId == 2)
                {
                    MessageBox.Show(this, "No se puede continuar ya que el contrato seleccionado, ya se encuentra anulado", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var form = new FrmContratoAnular(this._currentContrato, this._usuario);
                form.WindowState = FormWindowState.Normal;
                form.StartPosition = FormStartPosition.CenterScreen;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this._currentContrato = form.GetContrato;
                }
                form.Dispose();
                SetDatosEstado(this._currentContrato);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BnPagos_Click(object sender, EventArgs e)
        {

        }

        private void BnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";

                var presupuesto = TbPresupuestoNumero.Tag as Presupuesto;
                if (presupuesto == null) datosFaltantes += "\n\r - Presupuesto";

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DateTime.Now.Date > DtpFechaInicio.Value.Date)
                {
                    MessageBox.Show(this, "La fecha de vigencia de inicio no puede ser menor a la fecha actual", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var importeTotal = Convert.ToDecimal(!string.IsNullOrEmpty(TbMontoTotal.Text.Trim()) ? TbMontoTotal.Text.Trim() : "0.00");

                if (importeTotal <= 0)
                {
                    MessageBox.Show(this, "El importe total no puede ser cero (0.00)", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this._accion == FormAccion.nuevo) this._currentContrato = new Contrato();

                this._currentContrato.CreacionUsuarioID = this._usuario.UsuarioID;
                this._currentContrato.CreacionUsuario = this._usuario;
                this._currentContrato.CreacionFecha = DateTime.Now;
                this._currentContrato.FechaInicio = DtpFechaInicio.Value.Date;
                this._currentContrato.FechaEstimadaEntrega = DtpFechaEstimadaEntrega.Value.Date;
                this._currentContrato.PresupuestoID = presupuesto.PresupuestoID;
                this._currentContrato.Presupuesto = presupuesto;

                var form = new FrmContratoPagoRegistrar(this._currentContrato, this._usuario);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.WindowState = FormWindowState.Normal;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this._currentContrato = form.GetContrato;
                    form.Dispose();
                }
                else
                {
                    form.Dispose();
                    return;
                }

                //if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return;
                //}


                //BnGuardar.Enabled = false;
                //BnCancelar.Enabled = false;
                //BnSalir.Enabled = false;
                //this.Cursor = Cursors.WaitCursor;

                //if (this._accion == FormAccion.nuevo)
                //{
                //    this._currentContrato = await this.ObjRemoteObject.LogContrato.ContratoInsertar(this._currentContrato);
                    
                //}

                //this.Cursor = Cursors.Default;
                //MessageBox.Show(this, "Los datos fueron guardados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //BnGuardar.Enabled = true;
                //BnCancelar.Enabled = true;
                //BnSalir.Enabled = true;

                SetAccion(FormAccion.visualizar);
                TbContratoNumero.Text = this._currentContrato.ContratoID.ToString();
                SetDatosEstado(this._currentContrato);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnGuardar.Enabled = true;
                BnCancelar.Enabled = true;
                BnSalir.Enabled = true;
            }
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

        private void BnBuscarPresupuesto_Click(object sender, EventArgs e)
        {
            Presupuesto_Buscar();
        }

        private DialogResult Presupuesto_Buscar()
        {
            var form = new FrmPresupuestoBuscar(1);
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Presupuesto_Mostrar(form.GetPresupuestoSeleccionado);
                FechaEstimadaEntrega_Calcular();
            }
            form.Dispose();
            return dialogResult;
        }

        private void DtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            FechaEstimadaEntrega_Calcular();
        }
    }
}
