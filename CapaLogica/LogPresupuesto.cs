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
    public class LogPresupuesto : Conexion, ILogPresupuesto
    {
        #region sigleton
        private static readonly LogPresupuesto _instancia = new LogPresupuesto();
        public static LogPresupuesto Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

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

        public async Task PresupuestoAnular(Presupuesto presupuesto)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                using (var tran = cnn.BeginTransaction())
                {
                    try
                    {
                        presupuesto.AnulacionFecha = DateTime.Now;
                        await new DaoPresupuesto(tran).Anular(presupuesto);
                        tran.Commit();
                        Close(cnn);
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

                    if (presupuesto.AnulacionUsuarioID != null) presupuesto.CreacionUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(presupuesto.CreacionUsuarioID);
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

        public async Task<List<Presupuesto>> PresupuestoBusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte estado)
        {
            bool? activo = null;
            if (estado == 1) activo = true;
            else if (estado == 2) activo = false;

            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var listaPresupuestos = await new DaoPresupuesto(cnn).BusquedaGeneral(fechaDesde, fechaHasta, clienteID, proyectoID, activo);
                if (listaPresupuestos.Count > 0)
                {
                    var tiposDocumentoIdentidad = await new DaoTipoDocumentoIdentidad(cnn).ListarTodos();
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

                        if (presupuesto.AnulacionUsuarioID != null) presupuesto.CreacionUsuario = await new DaoUsuario(cnn).BuscarPorUsuarioID(presupuesto.CreacionUsuarioID);
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
    }
}
