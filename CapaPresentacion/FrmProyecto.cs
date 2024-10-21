using CapaEntidad;
using CapaPresentacion.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
	public partial class FrmProyecto : FrmBase
    {
        ToolStripMenuItem _menu;
        public FrmProyecto(ToolStripMenuItem menu)
        {
            _menu = menu;
            _menu.Enabled = false;
            InitializeComponent();
            BnFiltrar.Location = BnCancelar.Location;
            SetAccion(FormAccion.ninguno);
        }

        private async void FrmProyecto_Load(object sender, EventArgs e)
        {
            try
            {
                CmbTipoDocumentoIdentidad.Items.Clear();
                CmbTipoDocumentoIdentidad.DisplayMember = "Nombre";
                var tiposDocumentoIdentidad = await this.ObjRemoteObject.LogTipoDocumentoIdentidad.TipoDocumentoIdentidadListarActivos();
                foreach (var item in tiposDocumentoIdentidad)
                {
                    CmbTipoDocumentoIdentidad.Items.Add(item);
                }

                if (CmbTipoDocumentoIdentidad.Items.Count > 0) CmbTipoDocumentoIdentidad.SelectedIndex = 0;

				var departamentos = await this.ObjRemoteObject.LogDepartamento.DepartamentoBuscarTodos();
				var departamentoDefault = new Departamento { Nombre = "Todos" };
				LLenarComboBox<Departamento>(departamentoDefault, departamentos, CbDepartamento);
			}
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void FrmProyecto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.Accion == FormAccion.nuevo || this.Accion == FormAccion.editar) && 
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Métodos

        private void DgvProyecto_Agregar(Proyecto proyecto)
        {
            var indice = 
                DgvProyecto.Rows.Add(
                    proyecto.Nombre, 
                    proyecto.Direccion, 
                    proyecto.DireccionReferencia,
                    proyecto.DireccionDistrito.Nombre,
					proyecto.DireccionProvincia.Nombre,
					proyecto.DireccionDepartamento.Nombre,
					proyecto.Cliente.TipoDocumentoIdentidad_RazonSocialOrApellidosYNombres,
					proyecto.Activo ? "SI" : ""
                );
            DgvProyecto.Rows[indice].Tag = proyecto;
        }

        private void DgvProyecto_Actualizar(Proyecto proyecto)
        {

            DgvProyecto.CurrentRow.Tag = proyecto;
            DgvProyecto.CurrentRow.Cells[0].Value = proyecto.Nombre;
            DgvProyecto.CurrentRow.Cells[1].Value = proyecto.Direccion;
            DgvProyecto.CurrentRow.Cells[2].Value = proyecto.DireccionReferencia;
            DgvProyecto.CurrentRow.Cells[3].Value = proyecto.DireccionDistrito.Nombre;
			DgvProyecto.CurrentRow.Cells[4].Value = proyecto.DireccionProvincia.Nombre;
			DgvProyecto.CurrentRow.Cells[5].Value = proyecto.DireccionDepartamento.Nombre;
			DgvProyecto.CurrentRow.Cells[6].Value = proyecto.Cliente.TipoDocumentoIdentidad_RazonSocialOrApellidosYNombres;
			DgvProyecto.CurrentRow.Cells[7].Value = proyecto.Activo ? "SI" : "";
        }

        private FormAccion Accion;
        private Cliente CurrentCliente;
        private Proyecto CurrentProyecto;

        public void Botones_Enabled(bool nuevo, bool editar, bool deshabilitar, bool buscar)
        {
            BnNuevo.Enabled = nuevo;
            BnEditar.Enabled = editar;
            BnDeshabilitar.Enabled = deshabilitar;
            BnBuscar.Enabled = buscar;
        }

        public void Botones_Visible(bool guardar, bool cancelar, bool filtrar)
        {
            BnGuardar.Visible = guardar;
            BnCancelar.Visible = cancelar;
            BnFiltrar.Visible = filtrar;
        }

        public void GBDatosCliente_Limpiar()
        {
            CmbTipoDocumentoIdentidad.SelectedIndex = -1;
            TbDocumentoIdentidadNumero.Clear();
            TbCliente.Clear();
		}

		public void GBDatosProyecto_Limpiar()
		{
			TbNombre.Clear();
			TbDireccion.Clear();
			TbDireccionReferencia.Clear();
			CbDepartamento.SelectedIndex = -1;
			CbProvincia.SelectedIndex = -1;
			CbDistrito.SelectedIndex = -1;
		}

		private void LLenarComboBox<T>(T defaultValue, List<T> lista, ComboBox comboBox)
		{
			comboBox.Items.Clear();
			comboBox.DisplayMember = "Nombre";
			comboBox.Items.Add(defaultValue);
			if (lista == null) lista = new List<T>();
			foreach (var item in lista)
			{
				comboBox.Items.Add(item);
			}
		}

		private void GbDatosCliente_MostrarDatos(Cliente cliente)
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
            TbCliente.Text = cliente.RazonSocialOrApellidosYNombres;
        }

		private void GbDatosProyecto_MostrarDatos(Proyecto proyecto)
		{
			this.CurrentProyecto = proyecto;
            TbNombre.Text = proyecto.Nombre;
            TbDireccion.Text = proyecto.Direccion;
            TbDireccionReferencia.Text = proyecto.DireccionReferencia;
			for (int indice = 0; indice < CbDepartamento.Items.Count; indice++)
			{
				if ((CbDepartamento.Items[indice] as Departamento).DepartamentoID == proyecto.DireccionDepartamentoID)
				{
					CbDepartamento.SelectedIndex = indice;
					break;
				}
			}
			for (int indice = 0; indice < CbProvincia.Items.Count; indice++)
			{
				if ((CbProvincia.Items[indice] as Provincia).ProvinciaID == proyecto.DireccionProvinciaID)
				{
					CbProvincia.SelectedIndex = indice;
					break;
				}
			}
			for (int indice = 0; indice < CbDistrito.Items.Count; indice++)
			{
				if ((CbDistrito.Items[indice] as Distrito).DistritoID == proyecto.DireccionDistritoID)
				{
					CbDistrito.SelectedIndex = indice;
					break;
				}
			}
		}

		public void SetAccion(FormAccion accion)
        {
            GBDatosCliente_Limpiar();
            GBDatosProyecto_Limpiar();
            this.Accion = accion;
            this.CurrentCliente = null;
            this.CurrentProyecto = null;
            switch(this.Accion)
            {
                case FormAccion.ninguno:
                    LbOpcion.Text = "";
                    Botones_Enabled(true, true, true, true);
                    Botones_Visible(false, false, false);
                    GbDatos_Cliente.Enabled = false;
                    GbDatos_Proyecto.Enabled = false;
                    GbLista.Enabled = true;
                    break;
                case FormAccion.nuevo:
                    LbOpcion.Text = "OPCIÓN : NUEVO";
                    Botones_Enabled(false, false, false, false);
                    Botones_Visible(true, true, false);
					GbDatos_Cliente.Enabled = true;
					GbDatos_Proyecto.Enabled = true;
                    GbLista.Enabled = false;
                    break;
                case FormAccion.editar:
                    LbOpcion.Text = "OPCIÓN : EDITAR";
					Botones_Enabled(false, false, false, false);
                    Botones_Visible(true, true, false);
					GbDatos_Cliente.Enabled = true;
					GbDatos_Proyecto.Enabled = true;
                    GbLista.Enabled = false;
                    break;
                case FormAccion.buscar:
                    LbOpcion.Text = "OPCIÓN : BUSCAR";
					Botones_Enabled(true, true, true, false);
                    Botones_Visible(false, false, true);
					GbDatos_Cliente.Enabled = true;
					GbDatos_Proyecto.Enabled = true;
                    GbLista.Enabled = true;
                    break;
            }
        }

        #endregion Métodos

        private void CmbTipoDocumentoIdentidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)CmbTipoDocumentoIdentidad.SelectedItem;
            if (tipoDocumentoIdentidad == null)
            {
                TbDocumentoIdentidadNumero.MaxLength = 0;
                TbDocumentoIdentidadNumero.TipoCaracteres = CustomTextBox.TipoInput.Todo;
            }
            else
            {
                TbDocumentoIdentidadNumero.MaxLength = tipoDocumentoIdentidad.LongitudMaxima;
                TbDocumentoIdentidadNumero.TipoCaracteres = tipoDocumentoIdentidad.Alfanumerico ? CustomTextBox.TipoInput.NumerosYLetras : CustomTextBox.TipoInput.SoloNumeros;
            }
            TbDocumentoIdentidadNumero.Clear();
            TbCliente.Clear();
		}

		private void CbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
		{
			var departamento = (Departamento)CbDepartamento.SelectedItem;
			var provinciaDefault = new Provincia { Nombre = "Todos" };
			LLenarComboBox<Provincia>(provinciaDefault, departamento?.Provincias, CbProvincia);
		}

		private void CbProvincia_SelectedIndexChanged(object sender, EventArgs e)
		{
			var provincia = (Provincia)CbProvincia.SelectedItem;
			var distritoDefault = new Distrito { Nombre = "Todos" };
			LLenarComboBox<Distrito>(distritoDefault, provincia?.Distritos, CbDistrito);
		}

		private void BnNuevo_Click(object sender, EventArgs e)
        {
            SetAccion(FormAccion.nuevo);
        }

        private void BnEditar_Click(object sender, EventArgs e)
        {
            var proyecto = (Proyecto)DgvProyecto.CurrentRow?.Tag;
            if (proyecto == null)
            {
                MessageBox.Show(this, "Olvidó seleccionar un proyecto", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetAccion(FormAccion.editar);
            GbDatosCliente_MostrarDatos(proyecto.Cliente);
			GbDatosProyecto_MostrarDatos(proyecto);
		}

        private async void BnDeshabilitar_Click(object sender, EventArgs e)
        {
            var proyecto = (Proyecto)DgvProyecto.CurrentRow?.Tag;
            if (proyecto == null)
            {
                MessageBox.Show(this, "Olvidó seleccionar un proyecto", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string datosProyecto = "\n";
            datosProyecto += "\n\r - Nombre.:" + proyecto.Nombre;
            datosProyecto += "\n\r - Dirección: " + proyecto.Direccion;
			datosProyecto += "\n\r - Dir. Referencia: " + proyecto.DireccionReferencia;
			datosProyecto += "\n\r - Distrito: " + proyecto.DireccionDistrito.Nombre;
			datosProyecto += "\n\r - Provincia: " + proyecto.DireccionProvincia.Nombre;
			datosProyecto += "\n\r - Departamento: " + proyecto.DireccionDepartamento.Nombre;
			datosProyecto += "\n\r - Cliente: " + proyecto.Cliente.TipoDocumentoIdentidad_RazonSocialOrApellidosYNombres;

			if (MessageBox.Show(this, "¿Está seguro de deshabilitar al proyecto?" + datosProyecto, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                BnDeshabilitar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                await this.ObjRemoteObject.LogCliente.ClienteDeshabilitar(proyecto.ProyectoID);
                proyecto.Activo = false;
                DgvProyecto_Actualizar(proyecto);


                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "El cliente fue deshabilitado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnDeshabilitar.Enabled = true;

                SetAccion(FormAccion.ninguno);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnDeshabilitar.Enabled = true;
            }
        }

        private void BnBuscar_Click(object sender, EventArgs e)
        {
            SetAccion(FormAccion.buscar);
        }

        private async void BnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";

                if (this.CurrentCliente == null) datosFaltantes += "\n\r - Cliente";
                if (TbNombre.Text.Trim() == "") datosFaltantes += "\n\r - Nombre";
                if (TbDireccion.Text.Trim() == "") datosFaltantes += "\n\r - Dirección";
				var departamento = (Departamento)CbDepartamento.SelectedItem;
				if (departamento == null || departamento.DepartamentoID == 0) datosFaltantes += "\n\r - Departamento";
				var provincia = (Provincia)CbProvincia.SelectedItem;
				if (provincia == null || provincia.ProvinciaID == 0) datosFaltantes += "\n\r - Provincia";
				var distrito = (Distrito)CbDistrito.SelectedItem;
				if (distrito == null || distrito.DistritoID == 0) datosFaltantes += "\n\r - Distrito";

				if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.Accion == FormAccion.nuevo) this.CurrentProyecto = new Proyecto();
                this.CurrentProyecto.Nombre = TbNombre.Text;
                this.CurrentProyecto.Direccion = TbDireccion.Text;
				this.CurrentProyecto.DireccionReferencia = TbDireccionReferencia.Text;
				this.CurrentProyecto.DireccionDepartamentoID = departamento.DepartamentoID;
				this.CurrentProyecto.DireccionDepartamento = departamento;
				this.CurrentProyecto.DireccionProvinciaID = provincia.ProvinciaID;
				this.CurrentProyecto.DireccionProvincia = provincia;
				this.CurrentProyecto.DireccionDistritoID = distrito.DistritoID;
				this.CurrentProyecto.DireccionDistrito = distrito;
                this.CurrentProyecto.ClienteID = this.CurrentCliente.ClienteID;
				this.CurrentProyecto.Cliente = this.CurrentCliente;


				if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this.Accion == FormAccion.nuevo)
                {
                    this.CurrentProyecto.ProyectoID = await this.ObjRemoteObject.LogProyecto.ProyectoInsertar(this.CurrentProyecto);
                    this.CurrentProyecto.Activo = true;
                    DgvProyecto_Agregar(this.CurrentProyecto);
                }
                else
                {
                    await this.ObjRemoteObject.LogProyecto.ProyectoActualizar(this.CurrentProyecto);
                    DgvProyecto_Actualizar(this.CurrentProyecto);
                }

                
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "Los datos fueron guardados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnGuardar.Enabled = true;

                SetAccion(FormAccion.ninguno);
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
            SetAccion(FormAccion.ninguno);
        }

        private async void BnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DgvProyecto.Rows.Clear();
                BnFiltrar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

				var departamento = (Departamento)CbDepartamento.SelectedItem;
				var provincia = (Provincia)CbProvincia.SelectedItem;
				var distrito = (Distrito)CbDistrito.SelectedItem;

				var listaProyecto = await this.ObjRemoteObject.LogProyecto.ProyectoBusquedaGeneral(
                    this.CurrentCliente?.TipoDocumentoIdentidadID,
                    TbNombre.Text.Trim(),
                    distrito?.DistritoID,
                    provincia?.ProvinciaID,
                    departamento?.DepartamentoID
                );

                foreach (var proyecto in listaProyecto)
                {
                    DgvProyecto_Agregar(proyecto);
                }

                BnFiltrar.Enabled = true;
                this.Cursor = Cursors.Default;

                if (listaProyecto.Count() == 0)
                {
                    MessageBox.Show(this, "No se encontraron resultados con los datos de búsqueda ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnFiltrar.Enabled = true;
            }
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._menu.Enabled = true;
        }

		private async void BnBuscarCliente_Click(object sender, EventArgs e)
		{
			try
			{
				var datosFaltantes = "";
				var tipoDocumentoIdentidad = (TipoDocumentoIdentidad)CmbTipoDocumentoIdentidad.SelectedItem;

				if (TbDocumentoIdentidadNumero.Text.Trim() == "") datosFaltantes += "\n\r - Nº de documento de identidad";

				if (!string.IsNullOrEmpty(datosFaltantes))
				{
					MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var numeroDocumentoIdentidad = TbDocumentoIdentidadNumero.Text.Trim();
				if (tipoDocumentoIdentidad.LongitudMinima > numeroDocumentoIdentidad.Length)
				{
					string mensaje = $"El tipo de documento de identidad \"{tipoDocumentoIdentidad.Nombre}\" debe tener como mínimo {tipoDocumentoIdentidad.LongitudMinima} dígitos";
					MessageBox.Show(this, mensaje, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				BnBuscarCliente.Enabled = false;
				this.Cursor = Cursors.WaitCursor;

				this.CurrentCliente = await this.ObjRemoteObject.LogCliente.ClienteBuscarPorDocumentoIdentidad(tipoDocumentoIdentidad.TipoDocumentoIdentidadID, numeroDocumentoIdentidad);

				this.Cursor = Cursors.Default;
				BnBuscarCliente.Enabled = true;

				if (this.CurrentCliente == null)
				{
					string msg = $"No se encontró el cliente con \"{tipoDocumentoIdentidad.Nombre}: {numeroDocumentoIdentidad}\"";
                    MessageBox.Show(this, msg, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TbDocumentoIdentidadNumero.Focus();
				}
                else
                {
                    this.CurrentCliente.TipoDocumentoIdentidad = tipoDocumentoIdentidad;
					TbCliente.Text = this.CurrentCliente.RazonSocialOrApellidosYNombres;
				}
			}
			catch (Exception ex)
			{
				this.Cursor = Cursors.Default;
				MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				BnBuscarCliente.Enabled = true;
			}

		}
	}
}
