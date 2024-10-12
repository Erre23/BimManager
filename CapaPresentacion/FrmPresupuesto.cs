using CapaEntidad;
using CapaLogica;
using CapaPresentacion.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private FormAccion _accion;
        private Presupuesto _currentPresupuesto;
        private List<PresupuestoCategoria> _presupuestoCategorias;

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
            DtpFechaHasta.Enabled = enabled;
            CbTipoDocumentoIdentidad.Enabled = enabled;
            TbNumeroDocumento.Enabled = enabled;
            BnBuscarCliente.Enabled = enabled;
            CbProyectoNombre.Enabled = enabled;
            BnAgregarProyecto.Enabled = enabled;
            TbProyectoAreaTotal.Enabled = enabled;
            TbProyectoPisos.Enabled = enabled;
            CbPlan.Enabled = enabled;
            DgvPresupuestoCategoria.Enabled = enabled;
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
            TbProyectoAreaTotal.Clear();
            TbProyectoAreaTechada.Clear();
            TbProyectoPisos.Clear();
            DgvPresupuestoCategoria.Rows.Clear();
        }

        public void SetAccion(FormAccion accion)
        {
            this._accion = accion;
            this._currentPresupuesto = null;
            switch (this._accion)
            {
                case FormAccion.ninguno:
                    Botones_Enabled(true, true, false, false, false);
                    Controles_Input_Enabled(false);
                    Controles_Clear();
                    DtpFechaDesde.Value = DateTime.Now;
                    break;
                case FormAccion.nuevo:
                    Botones_Enabled(false, false, false, true, true);
                    Controles_Input_Enabled(true);
                    Controles_Clear();
                    PresupuestoCategoria_Cargar_For_New();
                    break;
                case FormAccion.visualizar:
                    Botones_Enabled(true, true, true, false, false);
                    Controles_Input_Enabled(false);
                    break;
            }
        }

        public void Cliente_Clear()
        {
            TbCliente.Tag = null;
            TbCliente.Clear();
        }

        public void Proyecto_Clear()
        {
            TbProyectoDireccion.Clear();
            TbProyectoAreaTotal.Clear();
		}

		public void Plan_Clear()
		{
			TbPlanPrecio.Clear();
			TbPlanPlazo.Clear();
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

        public void PresupuestoCategoria_Cargar_For_New()
        {
            DgvPresupuestoCategoria.Rows.Clear();
            PresupuestoCategoria_Cargar_For_New(_presupuestoCategorias);
		}

		public void PresupuestoCategoria_Cargar_For_New(List<PresupuestoCategoria> presupuestoCategorias)
		{
			foreach (var cat in presupuestoCategorias)
			{
				var presupuestoDetalle = new PresupuestoDetalle
				{
					PresupuestoCategoriaID = cat.PresupuestoCategoriaID,
					PresupuestoCategoria = cat,
                    Porcentaje = cat.Porcentaje
				};

				DgvPresupuestoCategoria_AddRow(presupuestoDetalle);

                if (cat.SubPresupuestoCategorias.Count() > 0) PresupuestoCategoria_Cargar_For_New(cat.SubPresupuestoCategorias);
			}
		}

		public void DgvPresupuestoCategoria_AddRow(PresupuestoDetalle presupuestoDetalle)
        {
            var index = DgvPresupuestoCategoria.Rows.Add(
				presupuestoDetalle.Seleccionar, 
                presupuestoDetalle.PresupuestoCategoria.Nombre,
				presupuestoDetalle.PresupuestoCategoria.Observaciones,
                $"{presupuestoDetalle.PresupuestoCategoria.Porcentaje}%",
                presupuestoDetalle.Importe
				);

            DgvPresupuestoCategoria.Rows[index].Tag = presupuestoDetalle;
            if (presupuestoDetalle.PresupuestoCategoria.PadrePresupuestoCategoriaID == null)
            {
                DgvPresupuestoCategoria.Rows[index].Cells[0].ReadOnly = false;
                DgvPresupuestoCategoria.Rows[index].DefaultCellStyle.BackColor = Color.Khaki;
            }
            else
            {
				DgvPresupuestoCategoria.Rows[index].Cells[0].ReadOnly = true;
				DgvPresupuestoCategoria.Rows[index].DefaultCellStyle.BackColor = Color.Gainsboro;
                DgvPresupuestoCategoria.Rows[index].Cells[0].Style.BackColor = Color.Black;
            }
        }

		private void CalcularAreaTechada()
		{
			var areaString = TbProyectoAreaTotal.Text.Trim();

			if (!string.IsNullOrEmpty(areaString))
			{
				var area = Convert.ToDecimal(areaString);
				if (area > 0)
				{

					var areaTechada = area * 0.7m;
					TbProyectoAreaTechada.Text = areaTechada.ToString("#0");
				}
				else
				{
					TbProyectoAreaTechada.Clear();
				}
			}
			else
			{
				TbProyectoAreaTechada.Clear();
			}
		}

        private void CalcularMontoTotal()
        {
            TbMontoTotal.Clear();
            var areaTechada = Convert.ToDecimal( string.IsNullOrEmpty(TbProyectoAreaTechada.Text.Trim()) ? "0" : TbProyectoAreaTechada.Text.Trim());
            var pisos = Convert.ToDecimal(string.IsNullOrEmpty(TbProyectoPisos.Text.Trim()) ? "0" : TbProyectoPisos.Text.Trim()); ;
            var plan = CbPlan.SelectedItem as Plan;
            if (areaTechada > 0 && pisos > 0 && plan != null)
            {
                var montoTotalPosibleACobrar = areaTechada * pisos * plan.CostoPorM2;
                var montoTotalACobrar = 0m;

                for (int index = 0; index < DgvPresupuestoCategoria.Rows.Count; index++)
                {
                    if (!DgvPresupuestoCategoria.Rows[index].Cells[0].ReadOnly)
                    {
                        var presupuestoDetalle = DgvPresupuestoCategoria.Rows[index].Tag as PresupuestoDetalle;
                        var montoDetalle = montoTotalPosibleACobrar * (presupuestoDetalle.Seleccionar ? (presupuestoDetalle.Porcentaje.Value / 100m) : 0m);
                        presupuestoDetalle.Importe = montoDetalle;
                        montoTotalACobrar += montoDetalle;

                        DgvPresupuestoCategoria.Rows[index].Tag = presupuestoDetalle;
                        DgvPresupuestoCategoria.Rows[index].Cells["colImporte"].Value = presupuestoDetalle.Importe.ToString("#0.00");
					}
                }

                TbMontoTotal.Text = montoTotalACobrar.ToString("#0.00");
            }
        }

		private void FrmPresupuesto_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._menu.Enabled = true;
        }

        private void FrmPresupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this._accion == FormAccion.nuevo || this._accion == FormAccion.editar) &&
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

				CbPlan.Items.Clear();
				CbPlan.DisplayMember = "Nombre";
				var planes = await LogPlan.Instancia.PlanListarActivos();
				foreach (var item in planes)
				{
					CbPlan.Items.Add(item);
				}

				if (CbPlan.Items.Count > 0) CbPlan.SelectedIndex = 0;

				_presupuestoCategorias = await LogPresupuestoCategoria.Instancia.PresupuestoCategoriaBuscarTodos();
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
            try
            {
                var datosFaltantes = "";

                var cliente = TbCliente.Tag as Cliente;
                if (cliente == null) datosFaltantes += "\n\r - Cliente";

                var proyecto = CbProyectoNombre.SelectedItem as Proyecto;
                if (proyecto == null) datosFaltantes += "\n\r - Proyecto";

                var areaTotal = Convert.ToDecimal(!string.IsNullOrEmpty(TbProyectoAreaTotal.Text.Trim()) ? TbProyectoAreaTotal.Text.Trim() : "0.00");
                var areaTechada = Convert.ToDecimal(!string.IsNullOrEmpty(TbProyectoAreaTechada.Text.Trim()) ? TbProyectoAreaTechada.Text.Trim() : "0.00");
                var pisos = Convert.ToByte(!string.IsNullOrEmpty(TbProyectoPisos.Text.Trim()) ? TbProyectoPisos.Text.Trim() : "0");

                if (areaTotal <= 0) datosFaltantes += "\n\r - Área Total";
                if (pisos <= 0) datosFaltantes += "\n\r - N° Pisos";

                var plan = CbPlan.SelectedItem as Plan;
                if (plan == null) datosFaltantes += "\n\r - Plan";

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DateTime.Now.Date > DtpFechaDesde.Value.Date)
                {
                    MessageBox.Show(this, "La fecha de vigencia de inicio no puede ser menor a la fecha actual", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DateTime.Now.Date > DtpFechaDesde.Value.Date)
                {
                    MessageBox.Show(this, "La fecha de vigencia de termino no puede ser menor a la fecha actual", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DtpFechaDesde.Value.Date < DtpFechaHasta.Value.Date)
                {
                    MessageBox.Show(this, "La fecha de vigencia de inicial no puede ser mayor a la fecha de termino", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var importeTotal = Convert.ToDecimal(!string.IsNullOrEmpty(TbMontoTotal.Text.Trim()) ? TbMontoTotal.Text.Trim() : "0.00");

                if (this._accion == FormAccion.nuevo) this._currentPresupuesto = new Presupuesto();

                this._currentPresupuesto.CreacionUsuarioID = this._usuario.UsuarioID;
                this._currentPresupuesto.CreacionUsuario = this._usuario;
                this._currentPresupuesto.CreacionFecha = DateTime.Now;
                this._currentPresupuesto.ClienteID = cliente.ClienteID;
                this._currentPresupuesto.Cliente = cliente;
                this._currentPresupuesto.ProyectoID = proyecto.ProyectoID;
                this._currentPresupuesto.Proyecto = proyecto;
                this._currentPresupuesto.FechaExpiracion = DtpFechaHasta.Value;
                this._currentPresupuesto.AreaTotal = areaTotal;
                this._currentPresupuesto.AreaTechada = areaTechada;
                this._currentPresupuesto.AreaLibre = areaTotal - areaTechada;
                this._currentPresupuesto.NumeroPisos = pisos;
                this._currentPresupuesto.PlanID = plan.PlanID;
                this._currentPresupuesto.Plan = plan;
                this._currentPresupuesto.ImporteTotal = importeTotal;
                this._currentPresupuesto.PresupuestoDetalles = new List<PresupuestoDetalle>();

                for (int index = 0; index < DgvPresupuestoCategoria.Rows.Count; index++)
                {
                    var presupuestoDetalle = DgvPresupuestoCategoria.Rows[index].Tag as PresupuestoDetalle;
                    if (presupuestoDetalle.Seleccionar)
                    {
                        this._currentPresupuesto.PresupuestoDetalles.Add(presupuestoDetalle);
                    }
                }

                if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this._accion == FormAccion.nuevo)
                {
                    //this._currentPresupuesto.PresupuestoID = await LogProyecto.Instancia.ProyectoInsertar(this.CurrentProyecto);
                    this._currentPresupuesto.Activo = true;
                }

                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "Los datos fueron guardados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnGuardar.Enabled = true;

                SetAccion(FormAccion.visualizar);
                TbNumeroPresupuesto.Text = this._currentPresupuesto.PresupuestoID.ToString();
                TbEstado.Text = this._currentPresupuesto.Activo ? "VIGENTE" : "";
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
                    TbCliente.Tag = cliente;
                    Proyecto_Cargar(cliente.Proyectos.FindAll(x => x.Activo).OrderBy(x => x.Nombre).ToList());
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

		private void TbProyectoAreaTotal_TextChanged(object sender, EventArgs e)
		{
            CalcularAreaTechada();
            CalcularMontoTotal();
		}

		private void TbProyectoPisos_TextChanged(object sender, EventArgs e)
		{
			CalcularMontoTotal();
		}

		private void CbPlan_SelectedIndexChanged(object sender, EventArgs e)
		{
			Plan_Clear();
			var plan = CbPlan.SelectedItem as Plan;
			if (plan != null)
			{
                TbPlanPrecio.Text = plan.CostoPorM2.ToString("#0");
                TbPlanPlazo.Text = plan.PlazoRango;
			}

			CalcularMontoTotal();
		}

		private void DgvPresupuestoCategoria_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
            //MessageBox.Show("cambio el valor");
		}

		private void DgvPresupuestoCategoria_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			//MessageBox.Show("terminó la edición");
		}

		private void DgvPresupuestoCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0 && e.RowIndex >= 0 && !DgvPresupuestoCategoria.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
			{
                var presupuestoDetalle = DgvPresupuestoCategoria.Rows[e.RowIndex].Tag as PresupuestoDetalle;
                presupuestoDetalle.Seleccionar = !presupuestoDetalle.Seleccionar;
                DgvPresupuestoCategoria.Rows[e.RowIndex].Tag = presupuestoDetalle;
                CalcularMontoTotal();
			}
		}
	}
}
