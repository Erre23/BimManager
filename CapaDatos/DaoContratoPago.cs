using BimManager.Entidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoContratoPago
	{
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoContratoPago(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoContratoPago(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<int> Insertar(ContratoPago contratoPago)
        {
            var cmd = (SqlCommand)null;
            
            try
            {
                cmd = new SqlCommand("spContratoPagoInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("ContratoID", contratoPago.ContratoID));
                cmd.Parameters.Add(CreateParams.Int("CreacionUsuarioID", contratoPago.CreacionUsuarioID));
                cmd.Parameters.Add(CreateParams.DateTime("CreacionFecha", contratoPago.CreacionFecha));
                cmd.Parameters.Add(CreateParams.Int("CuentaBancariaId", contratoPago.CuentaBancariaID));
                cmd.Parameters.Add(CreateParams.Date("PagoFecha", contratoPago.PagoFecha));
                cmd.Parameters.Add(CreateParams.NVarchar("NumeroOperacion", contratoPago.NumeroOperacion, 20));
                cmd.Parameters.Add(CreateParams.Decimal("Importe", contratoPago.Importe, 10, 2));

                contratoPago.ContratoPagoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return contratoPago.ContratoPagoID;
        }


        //public async Task ActualizarEstado(ContratoPago ContratoPago)
        //{
        //    var cmd = (SqlCommand)null;

        //    try
        //    {
        //        cmd = new SqlCommand("spContratoPagoActualizarEstado", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(CreateParams.TinyInt("ContratoPagoEstadoId", ContratoPago.ContratoPagoEstadoId));
        //        cmd.Parameters.Add(CreateParams.Int("UltActEstadoUsuarioID", ContratoPago.UltActEstadoUsuarioID));
        //        cmd.Parameters.Add(CreateParams.DateTime("UltActEstadoFecha", ContratoPago.UltActEstadoFecha));
        //        cmd.Parameters.Add(CreateParams.NVarchar("UltActEstadoComentario", ContratoPago.UltActEstadoComentario, -1));
        //        cmd.Parameters.Add(CreateParams.Int("ContratoPagoID", ContratoPago.ContratoPagoID));

        //        ContratoPago.ContratoPagoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }
        //}

        //public async Task<ContratoPago> BuscarPorContratoPagoID(int ContratoPagoID)
        //{
        //    var cmd = (SqlCommand)null;
        //    var ContratoPago = (ContratoPago)null;
        //    try
        //    {
        //        cmd = new SqlCommand("spContratoPagoBuscarPorContratoPagoID", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(CreateParams.Int("ContratoPagoID", ContratoPagoID));

        //        SqlDataReader dr = await cmd.ExecuteReaderAsync();
        //        while (await dr.ReadAsync())
        //        {
        //            ContratoPago = await ReadEntidad(dr);
        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }

        //    return ContratoPago;
        //}

        //public async Task<ContratoPago> BuscarPorPresupuestoID(int presupuestoID)
        //{
        //    var cmd = (SqlCommand)null;
        //    var ContratoPago = (ContratoPago)null;
        //    try
        //    {
        //        cmd = new SqlCommand("spContratoPagoBuscarPorPresupuestoID", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(CreateParams.Int("PresupuestoID", presupuestoID));

        //        SqlDataReader dr = await cmd.ExecuteReaderAsync();
        //        while (await dr.ReadAsync())
        //        {
        //            ContratoPago = await ReadEntidad(dr);
        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }

        //    return ContratoPago;
        //}

        //public async Task<List<ContratoPago>> BusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? ContratoPagoEstadoId)
        //{
        //    var cmd = (SqlCommand)null;
        //    var listaContratoPagos = new List<ContratoPago>();
        //    try
        //    {
        //        cmd = new SqlCommand("spContratoPagoBusquedaGeneral", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(CreateParams.Date("FechaDesde", fechaDesde));
        //        cmd.Parameters.Add(CreateParams.Date("FechaHasta", fechaHasta.Date.AddDays(1)));
        //        cmd.Parameters.Add(CreateParams.Int("ClienteID", clienteID));
        //        cmd.Parameters.Add(CreateParams.Int("ProyectoID", proyectoID));
        //        cmd.Parameters.Add(CreateParams.TinyInt("ContratoPagoEstadoId", ContratoPagoEstadoId));

        //        SqlDataReader dr = await cmd.ExecuteReaderAsync();
        //        while (await dr.ReadAsync())
        //        {
        //            var ContratoPago = await ReadEntidad(dr);
        //            listaContratoPagos.Add(ContratoPago);
        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }

        //    return listaContratoPagos;
        //}

        //private async Task<ContratoPago> ReadEntidad(SqlDataReader dr)
        //{
        //    try
        //    {
        //        var obj = new ContratoPago();
        //        obj.ContratoPagoID = Convert.ToInt32(dr["ContratoPagoID"]);
        //        obj.CreacionUsuarioID = Convert.ToInt32(dr["CreacionUsuarioID"]);
        //        obj.CreacionFecha = Convert.ToDateTime(dr["CreacionFecha"]);
        //        obj.PresupuestoID = Convert.ToInt32(dr["PresupuestoID"]);
        //        obj.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
        //        obj.FechaEstimadaEntrega = Convert.ToDateTime(dr["FechaEstimadaEntrega"]);
        //        obj.ContratoPagoEstadoId = Convert.ToByte(dr["ContratoPagoEstadoId"]);

        //        if (!(await dr.IsDBNullAsync(dr.GetOrdinal("UltActEstadoUsuarioID")))) obj.UltActEstadoUsuarioID = Convert.ToInt32(dr["UltActEstadoUsuarioID"]);
        //        if (!(await dr.IsDBNullAsync(dr.GetOrdinal("UltActEstadoFecha")))) obj.UltActEstadoFecha = Convert.ToDateTime(dr["UltActEstadoFecha"]);
        //        if (!(await dr.IsDBNullAsync(dr.GetOrdinal("UltActEstadoComentario")))) obj.UltActEstadoComentario = Convert.ToString(dr["UltActEstadoComentario"]);
                
        //        return obj;
        //    }
        //    catch(Exception ex)
        //    {
        //        dr.Close();
        //        throw ex;
        //    }
        //}
        #endregion métodos
    }
}
