using CapaEntidad;
using CapaLogica;
using CapaPresentacion.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
	public partial class FrmProyectoModal : Form
    {
        private readonly Cliente _cliente;
        private FormAccion Accion;
        private Proyecto _currentProyecto;
        public Proyecto GetProyecto { get { return this._currentProyecto; } }
        public FrmProyectoModal(Cliente cliente)
        {
            _cliente = cliente;
            InitializeComponent();
            SetAccion(FormAccion.nuevo);
        }

        private async void FrmProyecto_Load(object sender, EventArgs e)
        {
            try
            {
                TbDocumentoIdentidadTipo.Text = _cliente.TipoDocumentoIdentidad.Nombre;
                TbDocumentoIdentidadNumero.Text = _cliente.DocumentoIdentidadNumero;
                TbCliente.Text = _cliente.RazonSocialOrApellidosYNombres;

				var departamentos = await LogDepartamento.Instancia.DepartamentoBuscarTodos();
				LLenarComboBox<Departamento>(departamentos, CbDepartamento);
			}
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void FrmProyecto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.DialogResult != DialogResult.OK) &&
                MessageBox.Show(this, "¿Está seguro de cerrar esta ventana? los datos que no han sido guardados se perderán", "Un momento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Métodos

		public void GBDatosProyecto_Limpiar()
		{
			TbNombre.Clear();
			TbDireccion.Clear();
			TbDireccionReferencia.Clear();
			CbDepartamento.SelectedIndex = -1;
			CbProvincia.SelectedIndex = -1;
			CbDistrito.SelectedIndex = -1;
		}

		private void LLenarComboBox<T>(List<T> lista, ComboBox comboBox)
		{
			comboBox.Items.Clear();
			comboBox.DisplayMember = "Nombre";
			if (lista == null) lista = new List<T>();
			foreach (var item in lista)
			{
				comboBox.Items.Add(item);
			}
		}

		public void SetAccion(FormAccion accion)
        {
            GBDatosProyecto_Limpiar();
            this.Accion = accion;
            this._currentProyecto = null;
            switch(this.Accion)
            {
                case FormAccion.nuevo:
                    LbOpcion.Text = "OPCIÓN : NUEVO";
                    break;
            }
        }

        #endregion Métodos

		private void CbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
		{
			var departamento = (Departamento)CbDepartamento.SelectedItem;
			LLenarComboBox<Provincia>(departamento?.Provincias, CbProvincia);
		}

		private void CbProvincia_SelectedIndexChanged(object sender, EventArgs e)
		{
			var provincia = (Provincia)CbProvincia.SelectedItem;
			LLenarComboBox<Distrito>(provincia?.Distritos, CbDistrito);
		}

        private async void BnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";

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

                this._currentProyecto = new Proyecto();
                this._currentProyecto.Nombre = TbNombre.Text;
                this._currentProyecto.Direccion = TbDireccion.Text;
				this._currentProyecto.DireccionReferencia = TbDireccionReferencia.Text;
				this._currentProyecto.DireccionDepartamentoID = departamento.DepartamentoID;
				this._currentProyecto.DireccionDepartamento = departamento;
				this._currentProyecto.DireccionProvinciaID = provincia.ProvinciaID;
				this._currentProyecto.DireccionProvincia = provincia;
				this._currentProyecto.DireccionDistritoID = distrito.DistritoID;
				this._currentProyecto.DireccionDistrito = distrito;
                this._currentProyecto.ClienteID = this._cliente.ClienteID;
				this._currentProyecto.Cliente = this._cliente;


				if (MessageBox.Show(this, "¿Está seguro guardar los datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }


                BnGuardar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                this._currentProyecto.ProyectoID = await LogProyecto.Instancia.ProyectoInsertar(this._currentProyecto);
                this._currentProyecto.Activo = true;

                
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "Los datos fueron guardados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BnGuardar.Enabled = true;

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
