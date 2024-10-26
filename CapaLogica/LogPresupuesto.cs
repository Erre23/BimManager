using BimManager.Datos;
using BimManager.Entidad;
using BimManager.ILogica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Logica
{
    [Serializable]
    public class LogPresupuesto : Conexion, ILogPresupuesto
    {
        #region sigleton
        private static readonly LogPresupuesto _instancia = new LogPresupuesto();
        public static LogPresupuesto Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos Presupuesto

        public async Task<Presupuesto> PresupuestoInsertar(Presupuesto presupuesto)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        presupuesto.CreacionFecha = DateTime.Now;
                        presupuesto.PresupuestoEstadoId = 1;
                        presupuesto.PresupuestoEstado = await new DaoPresupuestoEstado(tran).BuscarPorPresupuestoEstadoID(1);
                        presupuesto.PresupuestoID = await new DaoPresupuesto(tran).Insertar(presupuesto);
                        var daoPresupuestoDetalle = new DaoPresupuestoDetalle(tran);
                        foreach (var presupuestoDetalle in presupuesto.PresupuestoDetalles)
                        {
                            presupuestoDetalle.PresupuestoID = presupuesto.PresupuestoID;
                            presupuestoDetalle.PresupuestoDetalleID = await daoPresupuestoDetalle.Insertar(presupuestoDetalle);
                        }

                        tran.Commit();
                        Close(cnn);
                        return presupuesto;
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

        public async Task<Presupuesto> PresupuestoAnular(Presupuesto presupuesto)
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
                        var presupuestoFromBD = await daoPresupuesto.BuscarPorPresupuestoID(presupuesto.PresupuestoID);
                        if (presupuestoFromBD == null)
                        {
                            throw new Exception("El número de presupuesto no existe");
                        }

                        if (presupuestoFromBD.PresupuestoEstadoId == 2)
                        {
                            throw new Exception("No se puede anular el presupuesto, porque ya ha sido anulado en otro momento");
                        }

                        if (presupuestoFromBD.PresupuestoEstadoId == 3)
                        {
                            throw new Exception("No se puede anular el presupuesto, porque se encuentra con estado \"Vencido\"");
                        }

                        if (presupuestoFromBD.PresupuestoEstadoId == 4)
                        {
                            throw new Exception("No se puede anular el presupuesto, porque se encuentra con estado \"Aprobado\"");
                        }

                        presupuesto.UltActEstadoFecha = DateTime.Now;
                        presupuesto.PresupuestoEstadoId = 2;
                        presupuesto.PresupuestoEstado = await new DaoPresupuestoEstado(tran).BuscarPorPresupuestoEstadoID(2);
                        await daoPresupuesto.ActualizarEstado(presupuesto);
                        tran.Commit();
                        Close(cnn);
                        return presupuesto;
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

        public async Task<Presupuesto> PresupuestoBuscarPorPresupuestoID(int presupuestoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var presupuesto = await new DaoPresupuesto(cnn).BuscarPorPresupuestoID(presupuestoID);
                if (presupuesto != null)
                {
                    presupuesto.CreacionUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(presupuesto.CreacionUsuarioID);
                    presupuesto.Cliente = await new DaoCliente(cnn).BuscarPorClienteID(presupuesto.ClienteID);
                    presupuesto.Cliente.TipoDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).BuscarPorTipoDocumentoIdentidadID(presupuesto.Cliente.TipoDocumentoIdentidadID);
                    presupuesto.Proyecto = await new DaoProyecto(cnn).BuscarPorProyectoID(presupuesto.ProyectoID);
                    presupuesto.Proyecto.DireccionDepartamento = await new DaoDepartamento(cnn).BuscarPorDepartamentoID(presupuesto.Proyecto.DireccionDepartamentoID);
                    presupuesto.Proyecto.DireccionProvincia = await new DaoProvincia(cnn).BuscarPorProvinciaID(presupuesto.Proyecto.DireccionProvinciaID);
                    presupuesto.Proyecto.DireccionDistrito = await new DaoDistrito(cnn).BuscarPorDistritoID(presupuesto.Proyecto.DireccionDistritoID);
                    presupuesto.Plan = await new DaoPlan(cnn).BuscarPorPlanID(presupuesto.PlanID);
                    presupuesto.PresupuestoEstado = await new DaoPresupuestoEstado(cnn).BuscarPorPresupuestoEstadoID(presupuesto.PresupuestoEstadoId);
                    if (presupuesto.UltActEstadoUsuarioID != null) presupuesto.UltActEstadoUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(presupuesto.UltActEstadoUsuarioID.Value);
                }
                Close(cnn);
                return presupuesto;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<Presupuesto>> PresupuestoBusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? presupuestoEstadoId)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var listaPresupuestos = await new DaoPresupuesto(cnn).BusquedaGeneral(fechaDesde, fechaHasta, clienteID, proyectoID, presupuestoEstadoId);
                if (listaPresupuestos.Count > 0)
                {
                    var tiposDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).ListarTodos();
                    var presupuestoEstados = await new DaoPresupuestoEstado(cnn).Listar();
                    foreach (var presupuesto in listaPresupuestos)
                    {
                        presupuesto.CreacionUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(presupuesto.CreacionUsuarioID);
                        presupuesto.Cliente = await new DaoCliente(cnn).BuscarPorClienteID(presupuesto.ClienteID);
                        presupuesto.Cliente.TipoDocumentoIdentidad = tiposDocumentoIdentidad.Find(x => x.TipoDocumentoIdentidadID == presupuesto.Cliente.TipoDocumentoIdentidadID);
                        presupuesto.Proyecto = await new DaoProyecto(cnn).BuscarPorProyectoID(presupuesto.ProyectoID);
                        presupuesto.Proyecto.DireccionDepartamento = await new DaoDepartamento(cnn).BuscarPorDepartamentoID(presupuesto.Proyecto.DireccionDepartamentoID);
                        presupuesto.Proyecto.DireccionProvincia = await new DaoProvincia(cnn).BuscarPorProvinciaID(presupuesto.Proyecto.DireccionProvinciaID);
                        presupuesto.Proyecto.DireccionDistrito = await new DaoDistrito(cnn).BuscarPorDistritoID(presupuesto.Proyecto.DireccionDistritoID);
                        presupuesto.Plan = await new DaoPlan(cnn).BuscarPorPlanID(presupuesto.PlanID);
                        presupuesto.PresupuestoEstado = presupuestoEstados.Find(x => x.PresupuestoEstadoID == presupuesto.PresupuestoEstadoId);
                        if (presupuesto.UltActEstadoUsuarioID != null) presupuesto.UltActEstadoUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(presupuesto.UltActEstadoUsuarioID.Value);
                    }
                }
                Close(cnn);
                return listaPresupuestos;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<PresupuestoDetalle>> PresupuestoDetalleBuscarPorPresupuestoID(int presupuestoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var presupuestoDetalles = await new DaoPresupuestoDetalle(cnn).BuscarPorPresupuestoID(presupuestoID);
                Close(cnn);
                return presupuestoDetalles;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        #endregion metodos

        #region metodos PresupuestoEstado
        public async Task<PresupuestoEstado> PresupuestoEstadoBuscarPorPresupuestoEstadoID(byte presupuestoEstadoID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var presupuestoEstado = await new DaoPresupuestoEstado(cnn).BuscarPorPresupuestoEstadoID(presupuestoEstadoID);
                Close(cnn);
                return presupuestoEstado;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<PresupuestoEstado>> PresupuestoEstadoListar()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var presupuestoEstados = await new DaoPresupuestoEstado(cnn).Listar();
                Close(cnn);
                return presupuestoEstados;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }
        #endregion
    }
}
