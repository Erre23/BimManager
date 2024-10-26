using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoPresupuesto
	{
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoPresupuesto(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoPresupuesto(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<int> Insertar(Presupuesto presupuesto)
        {
            var cmd = (SqlCommand)null;
            
            try
            {
                cmd = new SqlCommand("spPresupuestoInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("CreacionUsuarioID", presupuesto.CreacionUsuarioID));
                cmd.Parameters.Add(CreateParams.DateTime("CreacionFecha", presupuesto.CreacionFecha));
                cmd.Parameters.Add(CreateParams.Int("ClienteID", presupuesto.ClienteID));
                cmd.Parameters.Add(CreateParams.Int("ProyectoID", presupuesto.ProyectoID));
                cmd.Parameters.Add(CreateParams.Date("FechaExpiracion", presupuesto.FechaExpiracion));
                cmd.Parameters.Add(CreateParams.Decimal("AreaTotal", presupuesto.AreaTotal, 10, 2));
                cmd.Parameters.Add(CreateParams.Decimal("AreaLibre", presupuesto.AreaLibre, 10, 2));
                cmd.Parameters.Add(CreateParams.TinyInt("AreaLibrePorcentaje", presupuesto.AreaLibrePorcentaje));
                cmd.Parameters.Add(CreateParams.Decimal("AreaTechada", presupuesto.AreaTechada, 10, 2));
                cmd.Parameters.Add(CreateParams.TinyInt("NumeroPisos", presupuesto.NumeroPisos));
                cmd.Parameters.Add(CreateParams.TinyInt("PlanID", presupuesto.PlanID));
                cmd.Parameters.Add(CreateParams.Decimal("ImporteTotal", presupuesto.ImporteTotal, 10, 2));
                cmd.Parameters.Add(CreateParams.TinyInt("PresupuestoEstadoId", presupuesto.PresupuestoEstadoId));

                presupuesto.PresupuestoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return presupuesto.PresupuestoID;
        }


        public async Task ActualizarEstado(Presupuesto presupuesto)
        {
            var cmd = (SqlCommand)null;

            try
            {
                cmd = new SqlCommand("spPresupuestoActualizarEstado", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.TinyInt("PresupuestoEstadoId", presupuesto.PresupuestoEstadoId));
                cmd.Parameters.Add(CreateParams.Int("UltActEstadoUsuarioID", presupuesto.UltActEstadoUsuarioID));
                cmd.Parameters.Add(CreateParams.DateTime("UltActEstadoFecha", presupuesto.UltActEstadoFecha));
                cmd.Parameters.Add(CreateParams.NVarchar("UltActEstadoComentario", presupuesto.UltActEstadoComentario, -1));
                cmd.Parameters.Add(CreateParams.Int("PresupuestoID", presupuesto.PresupuestoID));

                presupuesto.PresupuestoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }

        public async Task<Presupuesto> BuscarPorPresupuestoID(int PresupuestoID)
        {
            var cmd = (SqlCommand)null;
            var Presupuesto = (Presupuesto)null;
            try
            {
                cmd = new SqlCommand("spPresupuestoBuscarPorPresupuestoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("PresupuestoID", PresupuestoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Presupuesto = await ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Presupuesto;
        }

        public async Task<List<Presupuesto>> BusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? presupuestoEstadoId)
        {
            var cmd = (SqlCommand)null;
            var listaPresupuestos = new List<Presupuesto>();
            try
            {
                cmd = new SqlCommand("spPresupuestoBusquedaGeneral", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Date("FechaDesde", fechaDesde));
                cmd.Parameters.Add(CreateParams.Date("FechaHasta", fechaHasta.Date.AddDays(1)));
                cmd.Parameters.Add(CreateParams.Int("ClienteID", clienteID));
                cmd.Parameters.Add(CreateParams.Int("ProyectoID", proyectoID));
                cmd.Parameters.Add(CreateParams.TinyInt("PresupuestoEstadoId", presupuestoEstadoId));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Presupuesto = await ReadEntidad(dr);
                    listaPresupuestos.Add(Presupuesto);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaPresupuestos;
        }

        private async Task<Presupuesto> ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new Presupuesto();
                obj.PresupuestoID = Convert.ToInt32(dr["PresupuestoID"]);
                obj.CreacionUsuarioID = Convert.ToInt32(dr["CreacionUsuarioID"]);
                obj.CreacionFecha = Convert.ToDateTime(dr["CreacionFecha"]);
                obj.ClienteID = Convert.ToInt32(dr["ClienteID"]);
                obj.ProyectoID = Convert.ToInt32(dr["ProyectoID"]);
                obj.FechaExpiracion = Convert.ToDateTime(dr["FechaExpiracion"]);
                obj.AreaTotal = Convert.ToDecimal(dr["AreaTotal"]);
                obj.AreaTechada = Convert.ToDecimal(dr["AreaTechada"]);
                obj.AreaLibre = Convert.ToDecimal(dr["AreaLibre"]);
                obj.AreaLibrePorcentaje = Convert.ToByte(dr["AreaLibrePorcentaje"]);
                obj.NumeroPisos = Convert.ToByte(dr["NumeroPisos"]);
                obj.PlanID = Convert.ToByte(dr["PlanID"]);
                obj.ImporteTotal = Convert.ToDecimal(dr["ImporteTotal"]);
                obj.PresupuestoEstadoId = Convert.ToByte(dr["PresupuestoEstadoId"]);

                if (!(await dr.IsDBNullAsync(dr.GetOrdinal("UltActEstadoUsuarioID")))) obj.UltActEstadoUsuarioID = Convert.ToInt32(dr["UltActEstadoUsuarioID"]);
                if (!(await dr.IsDBNullAsync(dr.GetOrdinal("UltActEstadoFecha")))) obj.UltActEstadoFecha = Convert.ToDateTime(dr["UltActEstadoFecha"]);
                if (!(await dr.IsDBNullAsync(dr.GetOrdinal("UltActEstadoComentario")))) obj.UltActEstadoComentario = Convert.ToString(dr["UltActEstadoComentario"]);
                
                return obj;
            }
            catch(Exception ex)
            {
                dr.Close();
                throw ex;
            }
        }
        #endregion métodos
    }
}
