using BimManager.Datos;
using BimManager.Entidad;
using BimManager.ILogica;
using BimManager.Sunat.Entidad;
using BimManager.Sunat.Entidad.Constantes;
using BimManager.Sunat.Entidad.Estructuras;
using BimManager.Sunat.Entidad.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BimManager.Logica
{
    [Serializable]
    public class LogContrato : Conexion, ILogContrato
    {
        #region sigleton
        private static readonly LogContrato _instancia = new LogContrato();
        public static LogContrato Instancia { get { return _instancia; } }
        #endregion singleton

        #region Contrato

        public async Task<Contrato> ContratoInsertar(Contrato contrato, ContratoPago contratoPago = null)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        var daoPresupuesto = new DaoPresupuesto(tran);
                        var presupuestoFromBD = await daoPresupuesto.BuscarPorPresupuestoID(contrato.PresupuestoID);

                        if (presupuestoFromBD.PresupuestoEstadoId == 2)
                        {
                            throw new Exception("No se puede guardar el contrato porque el presupuesto seleccionado se encuentra \"Anulado\"");
                        }
                        else if (presupuestoFromBD.PresupuestoEstadoId == 3)
                        {
                            throw new Exception("No se puede guardar el contrato porque el presupuesto seleccionado se encuentra \"Vencido\"");
                        }
                        if (presupuestoFromBD.PresupuestoEstadoId == 4)
                        {
                            throw new Exception("No se puede guardar el contrato porque el presupuesto seleccionado se encuentra \"Aprobado\"");
                        }

                        contrato.CreacionFecha = DateTime.Now;
                        contrato.ContratoEstadoId = 1;
                        contrato.ContratoEstado = await new DaoContratoEstado(tran).BuscarPorContratoEstadoID(1);
                        contrato.ContratoID = await new DaoContrato(tran).Insertar(contrato);

                        presupuestoFromBD.PresupuestoEstadoId = 4;
                        presupuestoFromBD.UltActEstadoUsuarioID = contrato.CreacionUsuarioID;
                        presupuestoFromBD.UltActEstadoComentario = $"Aprobado con contrato Nº {contrato.ContratoID}";
                        await daoPresupuesto.ActualizarEstado(presupuestoFromBD);

                        if (contratoPago != null)
                        {
                            contratoPago.ContratoID = contrato.ContratoID;
                            contratoPago.CreacionFecha = DateTime.Now;
                            contratoPago.Anulado = false;
                            contratoPago.ContratoPagoID = await new DaoContratoPago(tran).Insertar(contratoPago);

                            contrato.MontoPagado = contratoPago.Importe;
                        }

                        tran.Commit();
                        Close(cnn);

                        return contrato;
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
            catch(Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<Contrato> ContratoAnular(Contrato contrato)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        var daoContrato = new DaoContrato(tran);
                        var contratoFromBD = await daoContrato.BuscarPorContratoID(contrato.ContratoID);
                        if (contratoFromBD == null)
                        {
                            throw new Exception("El número de Contrato no existe");
                        }

                        if (contratoFromBD.ContratoEstadoId == 2)
                        {
                            throw new Exception("No se puede anular el Contrato, porque ya ha sido anulado en otro momento");
                        }

                        if (contratoFromBD.ContratoEstadoId == 4)
                        {
                            throw new Exception("No se puede anular el Contrato, porque se encuentra con estado \"Culminado\"");
                        }

                        contrato.UltActEstadoFecha = DateTime.Now;
                        contrato.ContratoEstadoId = 2;
                        contrato.ContratoEstado = await new DaoContratoEstado(tran).BuscarPorContratoEstadoID(2);
                        await daoContrato.ActualizarEstado(contrato);

                        var daoPresupuesto = new DaoPresupuesto(tran);
                        var presupuestoFrmBD = await daoPresupuesto.BuscarPorPresupuestoID(contrato.PresupuestoID);

                        presupuestoFrmBD.PresupuestoEstadoId = 1;
                        presupuestoFrmBD.UltActEstadoUsuarioID = null;
                        presupuestoFrmBD.UltActEstadoFecha = null;
                        presupuestoFrmBD.UltActEstadoComentario = null;
                        await daoPresupuesto.ActualizarEstado(presupuestoFrmBD);

                        tran.Commit();
                        Close(cnn);
                        return contrato;
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<Contrato> ContratoBuscarPorContratoID(int contratoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var contrato = await new DaoContrato(cnn).BuscarPorContratoID(contratoID);
                if (contrato != null)
                {
                    contrato.CreacionUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(contrato.CreacionUsuarioID);
                    contrato.Presupuesto = await new DaoPresupuesto(cnn).BuscarPorPresupuestoID(contrato.PresupuestoID);
                    contrato.Presupuesto.Cliente = await new DaoCliente(cnn).BuscarPorClienteID(contrato.Presupuesto.ClienteID);
                    contrato.Presupuesto.Cliente.TipoDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).BuscarPorTipoDocumentoIdentidadID(contrato.Presupuesto.Cliente.TipoDocumentoIdentidadID);
                    contrato.Presupuesto.Proyecto = await new DaoProyecto(cnn).BuscarPorProyectoID(contrato.Presupuesto.ProyectoID);
                    contrato.Presupuesto.Proyecto.DireccionDepartamento = await new DaoDepartamento(cnn).BuscarPorDepartamentoID(contrato.Presupuesto.Proyecto.DireccionDepartamentoID);
                    contrato.Presupuesto.Proyecto.DireccionProvincia = await new DaoProvincia(cnn).BuscarPorProvinciaID(contrato.Presupuesto.Proyecto.DireccionProvinciaID);
                    contrato.Presupuesto.Proyecto.DireccionDistrito = await new DaoDistrito(cnn).BuscarPorDistritoID(contrato.Presupuesto.Proyecto.DireccionDistritoID);
                    contrato.Presupuesto.Plan = await new DaoPlan(cnn).BuscarPorPlanID(contrato.Presupuesto.PlanID);
                    contrato.ContratoEstado = await new DaoContratoEstado(cnn).BuscarPorContratoEstadoID(contrato.ContratoEstadoId);
                    if (contrato.UltActEstadoUsuarioID != null) contrato.UltActEstadoUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(contrato.UltActEstadoUsuarioID.Value);
                }
                Close(cnn);
                return contrato;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<Contrato> ContratoBuscarPorPresupuestoID(int presupuestoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var contrato = await new DaoContrato(cnn).BuscarPorPresupuestoID(presupuestoID);
                if (contrato != null)
                {
                    contrato.CreacionUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(contrato.CreacionUsuarioID);
                    contrato.Presupuesto = await new DaoPresupuesto(cnn).BuscarPorPresupuestoID(contrato.PresupuestoID);
                    contrato.Presupuesto.Cliente = await new DaoCliente(cnn).BuscarPorClienteID(contrato.Presupuesto.ClienteID);
                    contrato.Presupuesto.Cliente.TipoDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).BuscarPorTipoDocumentoIdentidadID(contrato.Presupuesto.Cliente.TipoDocumentoIdentidadID);
                    contrato.Presupuesto.Proyecto = await new DaoProyecto(cnn).BuscarPorProyectoID(contrato.Presupuesto.ProyectoID);
                    contrato.Presupuesto.Proyecto.DireccionDepartamento = await new DaoDepartamento(cnn).BuscarPorDepartamentoID(contrato.Presupuesto.Proyecto.DireccionDepartamentoID);
                    contrato.Presupuesto.Proyecto.DireccionProvincia = await new DaoProvincia(cnn).BuscarPorProvinciaID(contrato.Presupuesto.Proyecto.DireccionProvinciaID);
                    contrato.Presupuesto.Proyecto.DireccionDistrito = await new DaoDistrito(cnn).BuscarPorDistritoID(contrato.Presupuesto.Proyecto.DireccionDistritoID);
                    contrato.Presupuesto.Plan = await new DaoPlan(cnn).BuscarPorPlanID(contrato.Presupuesto.PlanID);
                    contrato.ContratoEstado = await new DaoContratoEstado(cnn).BuscarPorContratoEstadoID(contrato.ContratoEstadoId);
                    if (contrato.UltActEstadoUsuarioID != null) contrato.UltActEstadoUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(contrato.UltActEstadoUsuarioID.Value);
                }
                Close(cnn);
                return contrato;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<Contrato>> ContratoBusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? ContratoEstadoId)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                var documentoElectronico = FacturacionElectronica_LLenar_En_Modelo_DocumentoElectronico();
                var facturacionELectronicaService = new Sunat.FacturacionElectronica();
                documentoElectronico = facturacionELectronicaService.Generar_BoletaFactura(documentoElectronico);
                var cdr = facturacionELectronicaService.Enviar_Factura_NotaCreditoDeFactura(documentoElectronico.ComprobanteXml_Base64String, EmpresaDatos.RUC + "-01-F001-00000001");

                



                await cnn.OpenAsync();
                var listaContratos = await new DaoContrato(cnn).BusquedaGeneral(fechaDesde, fechaHasta, clienteID, proyectoID, ContratoEstadoId);
                if (listaContratos.Count > 0)
                {
                    var tiposDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).ListarTodos();
                    var ContratoEstados = await new DaoContratoEstado(cnn).Listar();
                    foreach (var contrato in listaContratos)
                    {
                        contrato.CreacionUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(contrato.CreacionUsuarioID);
                        contrato.Presupuesto = await new DaoPresupuesto(cnn).BuscarPorPresupuestoID(contrato.PresupuestoID);
                        contrato.Presupuesto.Cliente = await new DaoCliente(cnn).BuscarPorClienteID(contrato.Presupuesto.ClienteID);
                        contrato.Presupuesto.Cliente.TipoDocumentoIdentidad = tiposDocumentoIdentidad.Find(x => x.TipoDocumentoIdentidadID == contrato.Presupuesto.Cliente.TipoDocumentoIdentidadID);
                        contrato.Presupuesto.Proyecto = await new DaoProyecto(cnn).BuscarPorProyectoID(contrato.Presupuesto.ProyectoID);
                        contrato.Presupuesto.Proyecto.DireccionDepartamento = await new DaoDepartamento(cnn).BuscarPorDepartamentoID(contrato.Presupuesto.Proyecto.DireccionDepartamentoID);
                        contrato.Presupuesto.Proyecto.DireccionProvincia = await new DaoProvincia(cnn).BuscarPorProvinciaID(contrato.Presupuesto.Proyecto.DireccionProvinciaID);
                        contrato.Presupuesto.Proyecto.DireccionDistrito = await new DaoDistrito(cnn).BuscarPorDistritoID(contrato.Presupuesto.Proyecto.DireccionDistritoID);
                        contrato.Presupuesto.Plan = await new DaoPlan(cnn).BuscarPorPlanID(contrato.Presupuesto.PlanID);
                        contrato.ContratoEstado = ContratoEstados.Find(x => x.ContratoEstadoID == contrato.ContratoEstadoId);
                        if (contrato.UltActEstadoUsuarioID != null) contrato.UltActEstadoUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(contrato.UltActEstadoUsuarioID.Value);
                    }
                }
                Close(cnn);
                return listaContratos;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        #endregion Contrato

        #region ContratoPago

        

        #endregion ContratoPago

        #region ContratoEstado
        public async Task<ContratoEstado> ContratoEstadoBuscarPorContratoEstadoID(byte presupuestoEstadoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var contratoEstado = await new DaoContratoEstado(cnn).BuscarPorContratoEstadoID(presupuestoEstadoID);
                Close(cnn);
                return contratoEstado;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<ContratoEstado>> ContratoEstadoListar()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var contratoEstados = await new DaoContratoEstado(cnn).Listar();
                Close(cnn);
                return contratoEstados;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }
        #endregion ContratoEstado

        #region CuentaBancaria

        public async Task<CuentaBancaria> CuentaBancariaBuscarPorCuentaBancariaID(short cuentaBancariaID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var cuentaBancaria = await new DaoCuentaBancaria(cnn).BuscarPorCuentaBancariaID(cuentaBancariaID);
                Close(cnn);
                return cuentaBancaria;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<CuentaBancaria>> CuentaBancariaListarActivos()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var cuentaBancarias = await new DaoCuentaBancaria(cnn).ListarActivos();
                Close(cnn);
                return cuentaBancarias;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        #endregion CuentaBancaria


        private DocumentoElectronico FacturacionElectronica_LLenar_En_Modelo_DocumentoElectronico()
        {
            try
            {

                var objDocumentoElectronicoSunat = new DocumentoElectronico();

                //Separamos la Serie y corraltivo
                string Serie = "F001";
                int Correlativo = 1;

                //Datos de cabecera del comprobante
                objDocumentoElectronicoSunat.FechaEmision = DateTime.Now.Date.ToString("yyyy-MM-dd");
                objDocumentoElectronicoSunat.TipoDocumento = Catalogo_01_TipoDocumento.Factura;
                objDocumentoElectronicoSunat.Serie = Serie;
                objDocumentoElectronicoSunat.Correlativo = Correlativo;
                objDocumentoElectronicoSunat.CalculoIgv = 0.18m;
                objDocumentoElectronicoSunat.Gravadas = 84.75m;
                objDocumentoElectronicoSunat.Inafectas = 0;
                objDocumentoElectronicoSunat.Exoneradas = 0;
                objDocumentoElectronicoSunat.Gratuitas = 0;
                objDocumentoElectronicoSunat.DescuentoGlobal = 0;
                objDocumentoElectronicoSunat.TotalIgv = 15.25m;
                objDocumentoElectronicoSunat.TotalVenta = 100.00m;
                objDocumentoElectronicoSunat.MontoEnLetras = new NumberToLetters().ToCustomCardinal(100.00m).ToUpper();

                //Datos del contribuyente receptor
                if (objDocumentoElectronicoSunat.TipoDocumento == Catalogo_01_TipoDocumento.Factura)
                {
                    objDocumentoElectronicoSunat.Receptor =
                        new Contribuyente
                        {
                            TipoDocumento = Catalogo_06_TipoDocumentoIdentidad.Ruc,
                            NroDocumento = "10457024067",
                            NombreLegal = "EDUARDO RAFAEL RODRIGUEZ ESCOBAR",
                            NombreComercial = "",
                            Direccion = "TRUJILLO",
                            Urbanizacion = "-",
                            Distrito = "-",
                            Provincia = "-",
                            Departamento = "-"
                        };
                }
                else if (objDocumentoElectronicoSunat.TipoDocumento == Catalogo_01_TipoDocumento.Boleta)
                {
                    objDocumentoElectronicoSunat.Receptor = new Contribuyente
                    {
                        TipoDocumento = Catalogo_06_TipoDocumentoIdentidad.Dni,
                        NroDocumento = "45702406",
                        NombreLegal = "EDUARDO RODRIGUEZ ESCOBAR"
                    };
                }


                #region[Datos Adicionales]

                //Nombre del documento Ruc-TipoDocumento-Serie-Correlativo
                objDocumentoElectronicoSunat.DatoAdicionales_Internos.Add
                (
                    new DatoAdicional
                    {
                        Codigo = "NOMBRE",
                        Valor = EmpresaDatos.RUC + "-F001-0000001"
                    }
                );



                //Hora de Emisión
                objDocumentoElectronicoSunat.DatoAdicionales_Internos.Add
                (
                    new DatoAdicional
                    {
                        Codigo = "HORA EMISION",
                        Valor = DateTime.Now.ToString("hh:mm tt").ToUpper().Replace(".", "")
                    }
                );

                #endregion [Fin Datos Adicionales]


                short ItemNumero = 1;

                objDocumentoElectronicoSunat.Items.Add
                (
                    new DocumentoElectronicoDetalle
                    {
                        Id = ItemNumero,
                        Cantidad = 1,
                        UnidadMedida = Catalogo_03_TipoUnidadDeMedida.Unidad,
                        Descripcion = "Prueba de registro de comprobante",
                        TipoAfectacionIgv = Catalogo_07_TipoAfectacionIgv.Gravada_OperacionOnerosa,
                        TipoPrecio = Catalogo_16_TipoPrecioVentaUnitario.PrecioUnitario_IncluyeIGV,
                        PrecioUnitario = 100.00m,
                        PrecioReferencial = 74.85m,
                        Impuesto = 15.25m,
                        TotalVenta = 100.00m,
                    }
                );

                ItemNumero++;

                return objDocumentoElectronicoSunat;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }
        }
    }
}
