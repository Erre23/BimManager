using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogPresupuesto
    {
        #region sigleton
        private static readonly LogPresupuesto _instancia = new LogPresupuesto();
        public static LogPresupuesto Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos
        
        public async Task<Presupuesto> PresupuestoInsertar(Presupuesto presupuesto)
        {
            SqlConnection cnn = Conexion.Instancia.Conectar();
            await cnn.OpenAsync();
            using (var tran = cnn.BeginTransaction())
            {
                try
                {
                    presupuesto.PresupuestoID = await DaoPresupuesto.Instancia.Insertar(presupuesto, cnn, tran);
                    foreach (var presupuestoDetalle in presupuesto.PresupuestoDetalles)
                    {
                        presupuestoDetalle.PresupuestoID = presupuesto.PresupuestoID;
                        presupuestoDetalle.PresupuestoDetalleID = await DaoPresupuestoDetalle.Instancia.Insertar(presupuestoDetalle, cnn, tran);
                    }

                    tran.Commit();
                    cnn.Close();
                    return presupuesto;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    cnn.Close();
                    throw e;
                }
            }
        }

        public async Task PresupuestoAnular(Presupuesto presupuesto)
        {
            SqlConnection cnn = Conexion.Instancia.Conectar();
            await cnn.OpenAsync();
            using (var tran = cnn.BeginTransaction())
            {
                try
                {
                    presupuesto.AnulacionFecha = DateTime.Now;
                    await DaoPresupuesto.Instancia.Anular(presupuesto, cnn, tran);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }
        }

        public async Task<Presupuesto> PresupuestoBuscarPorPresupuestoID(int presupuestoID)
        {
            var presupuesto = await DaoPresupuesto.Instancia.BuscarPorPresupuestoID(presupuestoID);
            if (presupuesto != null)
            {
                presupuesto.CreacionUsuario = await DaoUsuario.Instancia.BuscarPorUsuarioID(presupuesto.CreacionUsuarioID);
                presupuesto.Cliente = await DaoCliente.Instancia.BuscarPorClienteID(presupuesto.ClienteID);
                presupuesto.Cliente.TipoDocumentoIdentidad = await DaoTipoDocumentoIdentidad.Instancia.BuscarPorTipoDocumentoIdentidadID(presupuesto.Cliente.TipoDocumentoIdentidadID);
                presupuesto.Proyecto = await DaoProyecto.Instancia.BuscarPorProyectoID(presupuesto.ProyectoID);
                presupuesto.Proyecto.DireccionDepartamento = await DaoDepartamento.Instancia.BuscarPorDepartamentoID(presupuesto.Proyecto.DireccionDepartamentoID);
                presupuesto.Proyecto.DireccionProvincia = await DaoProvincia.Instancia.BuscarPorProvinciaID(presupuesto.Proyecto.DireccionProvinciaID);
                presupuesto.Proyecto.DireccionDistrito = await DaoDistrito.Instancia.BuscarPorDistritoID(presupuesto.Proyecto.DireccionDistritoID);
                presupuesto.Plan = await DaoPlan.Instancia.BuscarPorPlanID(presupuesto.PlanID);

                if (presupuesto.AnulacionUsuarioID != null) presupuesto.CreacionUsuario = await DaoUsuario.Instancia.BuscarPorUsuarioID(presupuesto.CreacionUsuarioID);
            }

            return presupuesto;
        }

        public async Task<List<Presupuesto>> PresupuestoBusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte estado)
        {
            bool? activo = null;
            if (estado == 1) activo = true;
            else if (estado == 2) activo = false;

            var listaPresupuestos = await DaoPresupuesto.Instancia.BusquedaGeneral(fechaDesde, fechaHasta, clienteID, proyectoID, activo);
            if (listaPresupuestos.Count > 0)
            {
                var tiposDocumentoIdentidad = await DaoTipoDocumentoIdentidad.Instancia.ListarTodos();
                var ubigeos = await LogDepartamento.Instancia.DepartamentoBuscarTodos();
                foreach (var presupuesto in listaPresupuestos)
                {
                    presupuesto.CreacionUsuario = await DaoUsuario.Instancia.BuscarPorUsuarioID(presupuesto.CreacionUsuarioID);
                    presupuesto.Cliente = await DaoCliente.Instancia.BuscarPorClienteID(presupuesto.ClienteID);
                    presupuesto.Cliente.TipoDocumentoIdentidad = tiposDocumentoIdentidad.Find(x => x.TipoDocumentoIdentidadID == presupuesto.Cliente.TipoDocumentoIdentidadID);
                    presupuesto.Proyecto = await DaoProyecto.Instancia.BuscarPorProyectoID(presupuesto.ProyectoID);
                    presupuesto.Proyecto.DireccionDepartamento = await DaoDepartamento.Instancia.BuscarPorDepartamentoID(presupuesto.Proyecto.DireccionDepartamentoID);
                    presupuesto.Proyecto.DireccionProvincia = await DaoProvincia.Instancia.BuscarPorProvinciaID(presupuesto.Proyecto.DireccionProvinciaID);
                    presupuesto.Proyecto.DireccionDistrito = await DaoDistrito.Instancia.BuscarPorDistritoID(presupuesto.Proyecto.DireccionDistritoID);
                    presupuesto.Plan = await DaoPlan.Instancia.BuscarPorPlanID(presupuesto.PlanID);

                    if (presupuesto.AnulacionUsuarioID != null) presupuesto.CreacionUsuario = await DaoUsuario.Instancia.BuscarPorUsuarioID(presupuesto.CreacionUsuarioID);
                }
            }

            return listaPresupuestos;
        }

        public async Task<List<PresupuestoDetalle>> PresupuestoDetalleBuscarPorPresupuestoID(int presupuestoID)
        {
            var presupuestoDetalles = await DaoPresupuestoDetalle.Instancia.BuscarPorPresupuestoID(presupuestoID);
            return presupuestoDetalles;
        }

        #endregion metodos
    }
}
