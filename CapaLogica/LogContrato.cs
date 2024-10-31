using BimManager.Datos;
using BimManager.Entidad;
using BimManager.ILogica;
using BimManager.Sunat.Entidad;
using BimManager.Sunat.Entidad.Constantes;
using BimManager.Sunat.Entidad.Estructuras;
using BimManager.Sunat.Entidad.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.IO;
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

                            contratoPago.ComprobantePago.Correlativo = await new DaoSerie(tran).GenerarCorrelativoPorTipoDocumentoSunatID(contratoPago.ComprobantePago.TipoDocumentoSunatID);
                            contratoPago.ComprobantePago.Fecha = contratoPago.CreacionFecha;
                            contratoPago.ComprobantePago.Activo = true;

                            var daoComprobantePago = new DaoComprobantePago(tran);
                            contratoPago.ComprobantePago.ComprobantePagoID = await daoComprobantePago.Insertar(contratoPago.ComprobantePago);
                            contratoPago.ComprobantePagoId = contratoPago.ComprobantePago.ComprobantePagoID;

                                                       
                            var documentoElectronico = LLenar_DocumentoElectronico(contratoPago.ComprobantePago);
                            var facturacionELectronicaService = new Sunat.FacturacionElectronica();
                            documentoElectronico = facturacionELectronicaService.Generar_BoletaFactura(documentoElectronico);

                            contratoPago.ComprobantePago.ComprobantePagoDocumento = new ComprobantePagoDocumento
                            {
                                ComprobantePagoID = contratoPago.ComprobantePagoId,
                                DigestValue = documentoElectronico.DigestValue,
                                DocumentoXML = documentoElectronico.ComprobanteXml_Base64String
                            };

                            var daoComprobantePagoDocumento = new DaoComprobantePagoDocumento(tran);
                            await daoComprobantePagoDocumento.Insertar(contratoPago.ComprobantePago.ComprobantePagoDocumento);

                            var cdr = facturacionELectronicaService.Enviar_Factura_NotaCreditoDeFactura(documentoElectronico.ComprobanteXml_Base64String,
                                $"{EmpresaDatos.RUC}-{documentoElectronico.TipoDocumento}-{documentoElectronico.Serie}-{documentoElectronico.Correlativo.ToString().PadLeft(8, '0')}");

                            await daoComprobantePagoDocumento.ActualizarCDRPorComprobantePagoId(contratoPago.ComprobantePagoId, cdr.CDR_Base64String);

                            contratoPago.ComprobantePago.CDRCodigo = cdr.Respuesta_Codigo;
                            contratoPago.ComprobantePago.Enviado = true;

                            await daoComprobantePago.ActualizarDatosEnvio(contratoPago.ComprobantePagoId, true, cdr.Respuesta_Codigo);
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


        private DocumentoElectronico LLenar_DocumentoElectronico(ComprobantePago comprobantePago)
        {
            try
            {

                var objDocumentoElectronicoSunat = new DocumentoElectronico();

                //Datos de cabecera del comprobante
                objDocumentoElectronicoSunat.FechaEmision = comprobantePago.Fecha.ToString("yyyy-MM-dd");
                objDocumentoElectronicoSunat.TipoDocumento = comprobantePago.TipoDocumentoSunat.CodigoSunat;
                objDocumentoElectronicoSunat.Serie = comprobantePago.Serie;
                objDocumentoElectronicoSunat.Correlativo = comprobantePago.Correlativo;
                objDocumentoElectronicoSunat.CalculoIgv = Math.Round(comprobantePago.IGVPorcentaje / 100m, 2);
                objDocumentoElectronicoSunat.Gravadas = comprobantePago.SubTotal;
                objDocumentoElectronicoSunat.Inafectas = 0;
                objDocumentoElectronicoSunat.Exoneradas = 0;
                objDocumentoElectronicoSunat.Gratuitas = 0;
                objDocumentoElectronicoSunat.DescuentoGlobal = 0;
                objDocumentoElectronicoSunat.TotalIgv = comprobantePago.IGV;
                objDocumentoElectronicoSunat.TotalVenta = comprobantePago.Total;
                objDocumentoElectronicoSunat.MontoEnLetras = new NumberToLetters().ToCustomCardinal(comprobantePago.Total).ToUpper();

                //Datos del contribuyente receptor
                if (objDocumentoElectronicoSunat.TipoDocumento == Catalogo_01_TipoDocumento.Factura)
                {
                    objDocumentoElectronicoSunat.Receptor =
                        new Contribuyente
                        {
                            TipoDocumento = Catalogo_06_TipoDocumentoIdentidad.Ruc,
                            NroDocumento = comprobantePago.Cliente.DocumentoIdentidadNumero,
                            NombreLegal = comprobantePago.Cliente.RazonSocial,
                            NombreComercial = "",
                            Direccion = comprobantePago.Cliente.Direccion,
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
                        TipoDocumento = comprobantePago.Cliente.TipoDocumentoIdentidad.CodigoSunat,
                        NroDocumento = comprobantePago.Cliente.DocumentoIdentidadNumero,
                        NombreLegal = comprobantePago.Cliente.RazonSocialOrApellidosYNombres
                    };
                }


                #region[Datos Adicionales]

                //Nombre del documento Ruc-TipoDocumento-Serie-Correlativo
                objDocumentoElectronicoSunat.DatoAdicionales_Internos.Add
                (
                    new DatoAdicional
                    {
                        Codigo = "NOMBRE",
                        Valor = $"{EmpresaDatos.RUC}-{comprobantePago.TipoDocumentoSunat.CodigoSunat}-{comprobantePago.Serie}-{comprobantePago.Correlativo.ToString().PadLeft(8, '0')}"
                    }
                );



                //Hora de Emisión
                objDocumentoElectronicoSunat.DatoAdicionales_Internos.Add
                (
                    new DatoAdicional
                    {
                        Codigo = "HORA EMISION",
                        Valor = comprobantePago.Fecha.ToString("hh:mm tt").ToUpper().Replace(".", "")
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
                        UnidadMedida = Catalogo_03_TipoUnidadDeMedida.UnidadServicios,
                        Descripcion = comprobantePago.Descripcion,
                        TipoAfectacionIgv = Catalogo_07_TipoAfectacionIgv.Gravada_OperacionOnerosa,
                        TipoPrecio = Catalogo_16_TipoPrecioVentaUnitario.PrecioUnitario_IncluyeIGV,
                        PrecioUnitario = comprobantePago.Total,
                        PrecioReferencial = comprobantePago.SubTotal,
                        Impuesto = comprobantePago.IGV,
                        TotalVenta = comprobantePago.Total,
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
