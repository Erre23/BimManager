using CapaEntidad;
using CapaPresentacion.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPresupuesto : FrmBase
    {
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
            CbTipoDocumentoIdentidad.SelectedIndex = -1;
            TbNumeroDocumento.Clear();
            CbProyectoNombre.SelectedIndex = -1;
            CbProyectoNombre.Items.Clear();
            TbProyectoDireccion.Clear();
            TbProyectoAreaTotal.Clear();
            TbProyectoAreaTechada.Clear();
            TbProyectoPisos.Clear();
            CbPlan.SelectedIndex = -1;
            TbPlanPrecio.Clear();
            TbPlanPlazo.Clear();
            DgvPresupuestoCategoria.Rows.Clear();
        }

        public void SetAccion(FormAccion accion)
        {
            this._accion = accion;
            switch (this._accion)
            {
                case FormAccion.ninguno:
                    Botones_Enabled(true, true, false, false, false);
                    Controles_Input_Enabled(false);
                    Controles_Clear();
                    DtpFechaDesde.Value = DateTime.Now;
                    break;
                case FormAccion.nuevo:
                    this._currentPresupuesto = null;
                    Botones_Enabled(false, false, false, true, true);
                    Controles_Input_Enabled(true);
                    Controles_Clear();
                    PresupuestoCategoria_Cargar_For_New();
                    break;
                case FormAccion.visualizar:
                    Botones_Enabled(true, true, true, false, false);
                    Controles_Input_Enabled(false);
                    DgvPresupuestoCategoria.Enabled = true;
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

		public void Proyecto_Cargar(List<Proyecto> proyectos, int? seleccionarProyectoID = null)
        {
            CbProyectoNombre.Items.Clear();
            CbProyectoNombre.DisplayMember = "Nombre";
            var selectedIndex = -1;
            foreach (var proyecto in proyectos)
            {
                CbProyectoNombre.Items.Add(proyecto);
                if (seleccionarProyectoID != null && seleccionarProyectoID == proyecto.ProyectoID) selectedIndex = CbProyectoNombre.Items.IndexOf(proyecto);
            }

            if (seleccionarProyectoID == null && CbProyectoNombre.Items.Count > 0) selectedIndex = 0;
            CbProyectoNombre.SelectedIndex = selectedIndex;
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
                else
                {
                    presupuestoDetalle = new PresupuestoDetalle
                    {
                        PresupuestoCategoriaID = cat.PresupuestoCategoriaID,
                        PresupuestoCategoria = cat,
                        Porcentaje = cat.Porcentaje
                    };
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

		private void CalcularAreaTechada()
		{
			var areaString = TbProyectoAreaTotal.Text.Trim();

			if (!string.IsNullOrEmpty(areaString))
			{
				var area = Convert.ToDecimal(areaString);
				if (area > 0)
				{
					var areaTechada = area * 0.7m;
					TbProyectoAreaTechada.Text = areaTechada.ToString("#,#0");
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
                    var presupuestoDetalle = DgvPresupuestoCategoria.Rows[index].Tag as PresupuestoDetalle;
                    if (presupuestoDetalle.PresupuestoCategoria.PadrePresupuestoCategoriaID == null)
                    {                        
                        var montoDetalle = montoTotalPosibleACobrar * (presupuestoDetalle.Seleccionar ? (presupuestoDetalle.Porcentaje.Value / 100m) : 0m);
                        presupuestoDetalle.Importe = montoDetalle;
                        montoTotalACobrar += montoDetalle;

                        DgvPresupuestoCategoria.Rows[index].Tag = presupuestoDetalle;
                        DgvPresupuestoCategoria.Rows[index].Cells["colImporte"].Value = presupuestoDetalle.Importe.ToString("#,#0.00");
					}
                }

                TbMontoTotal.Text = montoTotalACobrar.ToString("#,#0.00");
            }
        }

        private void CheckedCategoria(int rowIndex)
        {
            var presupuestoDetalle = DgvPresupuestoCategoria.Rows[rowIndex].Tag as PresupuestoDetalle;
            if (presupuestoDetalle.PresupuestoCategoria.PadrePresupuestoCategoriaID == null)
            {
                presupuestoDetalle.Seleccionar = !presupuestoDetalle.Seleccionar;
                DgvPresupuestoCategoria.Rows[rowIndex].Tag = presupuestoDetalle;
                DgvPresupuestoCategoria.Rows[rowIndex].Cells[0].Value = presupuestoDetalle.Seleccionar;
                CalcularMontoTotal();
            }
        }

        private void SetEstado(bool activo)
        {
            TbEstado.Text = activo ? "ACTIVO" : "ANULADO";
        }

        private void Presupuesto_Mostrar(Presupuesto presupuesto)
        {
            this._currentPresupuesto = presupuesto;
            TbNumeroPresupuesto.Text = presupuesto.PresupuestoID.ToString();
            SetEstado(presupuesto.Activo);
            DtpFechaDesde.Value = presupuesto.CreacionFecha.Date;
            DtpFechaHasta.Value = presupuesto.FechaExpiracion.Date;
            TbCreadoPor.Text = presupuesto.CreacionUsuario.ApellidosNombres;            
            for (int index = 0; index < CbTipoDocumentoIdentidad.Items.Count - 1; index++)
            {
                if ((CbTipoDocumentoIdentidad.Items[index] as TipoDocumentoIdentidad).TipoDocumentoIdentidadID == presupuesto.Cliente.TipoDocumentoIdentidadID)
                {
                    CbTipoDocumentoIdentidad.SelectedIndex = index;
                    break;
                }
            }            
            TbNumeroDocumento.Text = presupuesto.Cliente.DocumentoIdentidadNumero;
            TbCliente.Text = presupuesto.Cliente.RazonSocialOrApellidosYNombres;
            Proyecto_Cargar(new List<Proyecto> { presupuesto.Proyecto }, presupuesto.ProyectoID);
            TbProyectoAreaTotal.Text = presupuesto.AreaTotal.ToString("#,#0");
            TbProyectoAreaTechada.Text = presupuesto.AreaTechada.ToString("#,#0");
            TbProyectoPisos.Text = presupuesto.NumeroPisos.ToString();
            for (int index = 0; index < CbPlan.Items.Count - 1; index++)
            {
                if ((CbPlan.Items[index] as Plan).PlanID == presupuesto.Plan.PlanID)
                {
                    CbPlan.SelectedIndex = index;
                    break;
                }
            }
            PresupuestoCategoria_Cargar_For_Visualizer(presupuesto.PresupuestoDetalles);
            TbMontoTotal.Text = presupuesto.ImporteTotal.ToString("#,#0.00");
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
                var tiposDocumentoIdentidad = await this.ObjRemoteObject.LogTipoDocumentoIdentidad.TipoDocumentoIdentidadListarActivos();
                foreach (var item in tiposDocumentoIdentidad)
                {
                    CbTipoDocumentoIdentidad.Items.Add(item);
                }
                CbTipoDocumentoIdentidad.SelectedIndex = -1;

				CbPlan.Items.Clear();
				CbPlan.DisplayMember = "Nombre";
				var planes = await this.ObjRemoteObject.LogPlan.PlanListarActivos();
				foreach (var item in planes)
				{
					CbPlan.Items.Add(item);
				}
                CbPlan.SelectedIndex = -1;

				_presupuestoCategorias = await this.ObjRemoteObject.LogPresupuestoCategoria.PresupuestoCategoriaBuscarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var form = new FrmPresupuestoBuscar();
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            if (form.ShowDialog() == DialogResult.OK)
            {
                Presupuesto_Mostrar(form.GetPresupuestoSeleccionado);
                SetAccion(FormAccion.visualizar);
            }
            form.Dispose();
        }

        private void BnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._currentPresupuesto == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un presupuesto", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (this._currentPresupuesto.Activo == false)
                {
                    MessageBox.Show(this, "No se puede continuar ya que el presupuesto seleccionado, ya se encuentra anulado", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var form = new FrmPresupuestoAnular(this._currentPresupuesto, this._usuario);
                form.WindowState = FormWindowState.Normal;
                form.StartPosition = FormStartPosition.CenterScreen;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this._currentPresupuesto.Activo = false;
                }
                form.Dispose();
                SetEstado(this._currentPresupuesto.Activo);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BnGenerarContrato_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._currentPresupuesto == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un presupuesto", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (this._currentPresupuesto.Activo == false)
                {
                    MessageBox.Show(this, "No se puede continuar ya que el presupuesto seleccionado se encuentra anulado", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var form = new FrmPresupuestoAnular(this._currentPresupuesto, this._usuario);
                form.WindowState = FormWindowState.Normal;
                form.StartPosition = FormStartPosition.CenterScreen;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this._currentPresupuesto.Activo = false;
                }
                form.Dispose();
                SetEstado(this._currentPresupuesto.Activo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void BnGuardar_Click(object sender, EventArgs e)
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

                if (DtpFechaDesde.Value.Date > DtpFechaHasta.Value.Date)
                {
                    MessageBox.Show(this, "La fecha de vigencia de inicial no puede ser mayor a la fecha de termino", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var importeTotal = Convert.ToDecimal(!string.IsNullOrEmpty(TbMontoTotal.Text.Trim()) ? TbMontoTotal.Text.Trim() : "0.00");



                if (importeTotal <= 0)
                {
                    MessageBox.Show(this, "No existen categorías seleccionadas", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this._accion == FormAccion.nuevo) this._currentPresupuesto = new Presupuesto();

                var areaLibre = areaTotal - areaTechada;
                var areaLibrePorcentaje = Convert.ToByte((areaLibre / areaTotal) * 100);

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
                this._currentPresupuesto.AreaLibre = areaLibre;
                this._currentPresupuesto.AreaLibrePorcentaje = areaLibrePorcentaje;
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

                if (this._currentPresupuesto.PresupuestoDetalles.Count() == 0)
                {
                    MessageBox.Show(this, "No existen categorías seleccionadas", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this._accion == FormAccion.nuevo)
                {
                    this._currentPresupuesto = await this.ObjRemoteObject.LogPresupuesto.PresupuestoInsertar(this._currentPresupuesto);
                    this._currentPresupuesto.Activo = true;
                }

                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "Los datos fueron guardados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnGuardar.Enabled = true;

                SetAccion(FormAccion.visualizar);
                TbNumeroPresupuesto.Text = this._currentPresupuesto.PresupuestoID.ToString();
                SetEstado(this._currentPresupuesto.Activo);
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
                var datosFaltantes = "";
                var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)CbTipoDocumentoIdentidad.SelectedItem;

                if (tipoDocumentoIdentidad == null) datosFaltantes += "\n\r - Tipo de documento de identidad";
                if (TbNumeroDocumento.Text.Trim() == "") datosFaltantes += "\n\r - Nº de documento de identidad";

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var cliente = await this.ObjRemoteObject.LogCliente.ClienteBuscarPorDocumentoIdentidad(tipoDocumentoIdentidad.TipoDocumentoIdentidadID, TbNumeroDocumento.Text.Trim(), true, tipoDocumentoIdentidad.ConsultaApi);

                this.Cursor = Cursors.Default;
                if (cliente == null && MessageBox.Show(this, "No se encontraron datos ¿Desea agregar al cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var form = new FrmClienteModal(tipoDocumentoIdentidad, TbNumeroDocumento.Text.Trim());
                    form.WindowState = FormWindowState.Normal;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        cliente = form.GetCliente;
                    }
                    form.Dispose();                    
                }
                else
                {
                    TbNumeroDocumento.Focus();
                }


                if (cliente != null)
                {
                    if (cliente.Proyectos == null) cliente.Proyectos = new List<Proyecto>();
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
                TbPlanPrecio.Text = plan.CostoPorM2.ToString("#,#0");
                TbPlanPlazo.Text = plan.PlazoRango;
			}

			CalcularMontoTotal();
		}

		private void DgvPresupuestoCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this._accion == FormAccion.nuevo && e.ColumnIndex == 0 && e.RowIndex >= 0)
			{
                CheckedCategoria(e.RowIndex);
            }
		}

        private void DgvPresupuestoCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            var row = DgvPresupuestoCategoria.CurrentRow;
            if (this._accion == FormAccion.nuevo && e.KeyCode == Keys.Space && row != null)
            {
                CheckedCategoria(row.Index);
            }
        }

        private void BnAgregarProyecto_Click(object sender, EventArgs e)
        {
            var cliente = TbCliente.Tag as Cliente;
            if (cliente == null)
            {
                MessageBox.Show(this, "Primero debe buscar un cliente", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var form = new FrmProyectoModal(cliente);
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            if (form.ShowDialog() == DialogResult.OK)
            {
                var proyecto = form.GetProyecto;
                
                if (cliente.Proyectos == null) cliente.Proyectos = new List<Proyecto>();
                cliente.Proyectos.Add(proyecto);
                Proyecto_Cargar(cliente.Proyectos.OrderBy(x => x.Nombre).ToList(), proyecto.ProyectoID);
            }
            form.Dispose();
        }
    }
}
