using BimManager.Entidad;
using BimManager.Client.WipApp.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BimManager.Client.WipApp
{
    public partial class FrmPresupuestoBuscar : FrmBase
    {
        public FrmPresupuestoBuscar(byte? filtroPresupuestoEstadoId = null)
        {
            InitializeComponent();
            _filtroPresupuestoEstadoId = filtroPresupuestoEstadoId;
        }

        private Presupuesto _presupuestoSeleccionado;
        public Presupuesto GetPresupuestoSeleccionado { get { return this._presupuestoSeleccionado; } }
        private readonly byte? _filtroPresupuestoEstadoId;

       

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
                presupuesto.PresupuestoEstado.Nombre,
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
            DgvPresupuesto.Rows[index].Cells[1].Style.BackColor = presupuesto.PresupuestoEstado.Color;
            DgvPresupuesto.Rows[index].Cells[1].Style.SelectionBackColor = presupuesto.PresupuestoEstado.Color;
            DgvPresupuesto.Rows[index].Cells[1].Style.SelectionForeColor = Color.Black;
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
                var presupuestoEstados = await this.ObjRemoteObject.LogPresupuesto.PresupuestoEstadoListar();
                if (_filtroPresupuestoEstadoId == null)
                {
                    presupuestoEstados.Insert(0, new PresupuestoEstado { Nombre = "TODOS" });
                }
                else
                {
                    presupuestoEstados = presupuestoEstados.FindAll(x => x.PresupuestoEstadoID == _filtroPresupuestoEstadoId);
                }
                foreach (var item in presupuestoEstados)
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
                if (DgvPresupuesto.CurrentRow == null)
                {
                    MessageBox.Show(this, "Olvidó seleccionar un presupuesto", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this._presupuestoSeleccionado = DgvPresupuesto.CurrentRow.Tag as Presupuesto;
                this._presupuestoSeleccionado.PresupuestoDetalles = await this.ObjRemoteObject.LogPresupuesto.PresupuestoDetalleBuscarPorPresupuestoID(this._presupuestoSeleccionado.PresupuestoID);
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
                var presupuestoID = Convert.ToInt32(string.IsNullOrEmpty(TbNumeroPresupuesto.Text.Trim()) ? "0" : TbNumeroPresupuesto.Text.Trim());
                var fechaDesde = DtpFechaDesde.Value.Date;
                var fechaHasta = DtpFechaHasta.Value.Date;
                var cliente = TbCliente.Tag as Cliente;
                var proyecto = CbProyectoNombre.SelectedItem as Proyecto;

                if (RbNumeroPresupuesto.Checked)
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

                DgvPresupuesto.Rows.Clear();
                BnBuscar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (RbNumeroPresupuesto.Checked)
                {
                    var presupuesto = await this.ObjRemoteObject.LogPresupuesto.PresupuestoBuscarPorPresupuestoID(presupuestoID);
                    if (presupuesto != null) DgvPresupuesto_AddRow(presupuesto);
                }
                else
                {
                    var presupuestoEstado = CbEstado.SelectedItem as PresupuestoEstado;
                    var presupuestoEstadoId = presupuestoEstado?.PresupuestoEstadoID;
                    if (presupuestoEstadoId == 0) presupuestoEstadoId = null;

                    var listaPresupuestos = await this.ObjRemoteObject.LogPresupuesto.PresupuestoBusquedaGeneral(fechaDesde, fechaHasta, cliente?.ClienteID, proyecto?.ProyectoID, presupuestoEstadoId);
                    foreach (var presupuesto in listaPresupuestos)
                    {
                        DgvPresupuesto_AddRow(presupuesto);
                    }
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
            var visibleGrupo1 = RbNumeroPresupuesto.Checked;
            var visibleGrupo2 = RbBusquedaDetallada.Checked;

            LbPresupuesto.Visible = visibleGrupo1;
            TbNumeroPresupuesto.Visible = visibleGrupo1;

            LbDesde.Visible = visibleGrupo2;
            DtpFechaDesde.Visible = visibleGrupo2;
            LbAl.Visible = visibleGrupo2;
            DtpFechaHasta.Visible = visibleGrupo2;
            LbEstado.Visible = visibleGrupo2;
            CbEstado.Visible = visibleGrupo2;
            LbTipoDocumentoIdentidad.Visible = visibleGrupo2;
            CbTipoDocumentoIdentidad.Visible = visibleGrupo2;
            LbDocumentoIdentidadNumero.Visible = visibleGrupo2;
            TbNumeroDocumento.Visible = visibleGrupo2;
            BnBuscarCliente.Visible = visibleGrupo2;
            LbCliente.Visible = visibleGrupo2;
            TbCliente.Visible = visibleGrupo2;
            LbProyecto.Visible = visibleGrupo2;
            CbProyectoNombre.Visible = visibleGrupo2;

            if (visibleGrupo1)
            {
                GbDatosBusqueda.Size = new Size(847, 60);
                BnBuscar.Location = new Point(863, 103);
            }
            else if (visibleGrupo2)
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
