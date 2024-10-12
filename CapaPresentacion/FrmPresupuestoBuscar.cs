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
    public partial class FrmPresupuestoBuscar : Form
    {
        public FrmPresupuestoBuscar()
        {
            InitializeComponent();
        }

        private FormAccion _accion;
        private Presupuesto _presupuestoSeleccionado;
        public Presupuesto GetPresupuestoSeleccionado { get { return this._presupuestoSeleccionado; } }

       

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

		public void DgvPresupuesto_AddRow(Presupuesto presupuesto)
        {
            var index = -1;
            
            index = DgvPresupuesto.Rows.Add(
                presupuesto.PresupuestoID,
                presupuesto.CreacionFecha.Date.ToString("dd/MM/yyyy"),
                presupuesto.FechaExpiracion.Date.ToString("dd/MM/yyyy"),
                presupuesto.Cliente.RazonSocialOrApellidosYNombres,
                presupuesto.Proyecto.Nombre,
                presupuesto.AreaTotal,
                presupuesto.AreaTechada,
                presupuesto.NumeroPisos,
                presupuesto.Plan.Nombre,
                presupuesto.Plan.CostoPorM2.ToString("#,#0.00"),
                presupuesto.Plan.PlazoRango,
                presupuesto.ImporteTotal.ToString("#,#0.00")
            );

            DgvPresupuesto.Rows[index].Tag = presupuesto;
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
                CbTipoDocumentoIdentidad.SelectedIndex = -1;
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
                if (DgvPresupuesto.CurrentRow == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un presupuesto", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this._presupuestoSeleccionado = DgvPresupuesto.CurrentRow.Tag as Presupuesto;
                this._presupuestoSeleccionado.PresupuestoDetalles = await LogPresupuesto.Instancia.PresupuestoDetalleBuscarPorPresupuestoID(this._presupuestoSeleccionado.PresupuestoID);
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

        private async void BnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var datosFaltantes = "";
                var fechaDesde = DtpFechaDesde.Value.Date;
                var fechaHasta = DtpFechaHasta.Value.Date;
                var cliente = TbCliente.Tag as Cliente;
                var proyecto = CbProyectoNombre.SelectedItem as Proyecto;

                if (!string.IsNullOrEmpty(datosFaltantes))
                {
                    MessageBox.Show(this, "Olvidó ingresar los siguientes datos: " + datosFaltantes, "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (fechaDesde.Date > fechaHasta.Date)
                {
                    MessageBox.Show(this, "La fecha de busqueda inicial no puede ser mayor a la fecha de búsqueda final", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DgvPresupuesto.Rows.Clear();
                BnBuscar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                var listaPresupuestos = await LogPresupuesto.Instancia.PresupuestoBusquedaGeneral(fechaDesde, fechaHasta, cliente?.ClienteID, proyecto?.ClienteID, 0);
                foreach (var presupuesto in listaPresupuestos)
                {
                    DgvPresupuesto_AddRow(presupuesto);
                }

                this.Cursor = Cursors.Default;
                if (DgvPresupuesto.Rows.Count == 0) MessageBox.Show(this, "No se encontraron resultados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BnBuscar.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BnBuscar.Enabled = true;
            }
        }
    }
}
