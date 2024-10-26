using CapaDatos;
using CapaEntidad;
using CapaILogica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaLogica
{
    [Serializable]
    public class LogContrato : Conexion, ILogContrato
    {
        #region sigleton
        private static readonly LogContrato _instancia = new LogContrato();
        public static LogContrato Instancia { get { return _instancia; } }
        #endregion singleton

        #region Contrato

        public async Task<Contrato> ContratoInsertar(Contrato contrato)
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

        public async Task<Contrato> ContratoAnular(Contrato Contrato)
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
                        var ContratoFromBD = await daoContrato.BuscarPorContratoID(Contrato.ContratoID);
                        if (ContratoFromBD == null)
                        {
                            throw new Exception("El número de Contrato no existe");
                        }

                        if (ContratoFromBD.ContratoEstadoId == 2)
                        {
                            throw new Exception("No se puede anular el Contrato, porque ya ha sido anulado en otro momento");
                        }

                        if (ContratoFromBD.ContratoEstadoId == 4)
                        {
                            throw new Exception("No se puede anular el Contrato, porque se encuentra con estado \"Culminado\"");
                        }

                        Contrato.UltActEstadoFecha = DateTime.Now;
                        Contrato.ContratoEstadoId = 2;
                        Contrato.ContratoEstado = await new DaoContratoEstado(tran).BuscarPorContratoEstadoID(2);
                        await daoContrato.ActualizarEstado(Contrato);
                        tran.Commit();
                        Close(cnn);
                        return Contrato;
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
    }
}
