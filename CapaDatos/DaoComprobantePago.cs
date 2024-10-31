﻿using BimManager.Entidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoComprobantePago
	{
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoComprobantePago(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoComprobantePago(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<int> Insertar(ComprobantePago comprobantePago)
        {
            var cmd = (SqlCommand)null;
            
            try
            {
                cmd = new SqlCommand("spComprobantePagoInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("ClienteID", comprobantePago.ClienteID));
                cmd.Parameters.Add(CreateParams.TinyInt("TipoDocumentoSunatID", comprobantePago.TipoDocumentoSunatID));
                cmd.Parameters.Add(CreateParams.NVarchar("Serie", comprobantePago.Serie, 4));
                cmd.Parameters.Add(CreateParams.Int("Correlativo", comprobantePago.Correlativo));
                cmd.Parameters.Add(CreateParams.Date("Fecha", comprobantePago.Fecha));
                cmd.Parameters.Add(CreateParams.Decimal("SubTotal", comprobantePago.SubTotal, 10, 2));
                cmd.Parameters.Add(CreateParams.Decimal("IGV", comprobantePago.IGV, 10, 2));
                cmd.Parameters.Add(CreateParams.TinyInt("IGVPorcentaje", comprobantePago.IGVPorcentaje));
                cmd.Parameters.Add(CreateParams.Decimal("Total", comprobantePago.Total, 10, 2));
                cmd.Parameters.Add(CreateParams.Bit("Activo", comprobantePago.Activo));

                comprobantePago.ComprobantePagoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return comprobantePago.ComprobantePagoID;
        }

        public async Task ActualizarDatosEnvio(int comprobantePagoID, bool enviado, string cdrCodigo)
        {
            var cmd = (SqlCommand)null;

            try
            {
                cmd = new SqlCommand("spComprobantePagoActualizarDatosEnvio", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("ComprobantePagoID", comprobantePagoID));
                cmd.Parameters.Add(CreateParams.Bit("Enviado", enviado));
                cmd.Parameters.Add(CreateParams.NVarchar("CDRCodigo", cdrCodigo, 5));

                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }


        //public async Task ActualizarEstado(ComprobantePago ComprobantePago)
        //{
        //    var cmd = (SqlCommand)null;

        //    try
        //    {
        //        cmd = new SqlCommand("spComprobantePagoActualizarEstado", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(CreateParams.TinyInt("ComprobantePagoEstadoId", ComprobantePago.ComprobantePagoEstadoId));
        //        cmd.Parameters.Add(CreateParams.Int("UltActEstadoUsuarioID", ComprobantePago.UltActEstadoUsuarioID));
        //        cmd.Parameters.Add(CreateParams.DateTime("UltActEstadoFecha", ComprobantePago.UltActEstadoFecha));
        //        cmd.Parameters.Add(CreateParams.NVarchar("UltActEstadoComentario", ComprobantePago.UltActEstadoComentario, -1));
        //        cmd.Parameters.Add(CreateParams.Int("ComprobantePagoID", ComprobantePago.ComprobantePagoID));

        //        ComprobantePago.ComprobantePagoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }
        //}

        //public async Task<ComprobantePago> BuscarPorComprobantePagoID(int ComprobantePagoID)
        //{
        //    var cmd = (SqlCommand)null;
        //    var ComprobantePago = (ComprobantePago)null;
        //    try
        //    {
        //        cmd = new SqlCommand("spComprobantePagoBuscarPorComprobantePagoID", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(CreateParams.Int("ComprobantePagoID", ComprobantePagoID));

        //        SqlDataReader dr = await cmd.ExecuteReaderAsync();
        //        while (await dr.ReadAsync())
        //        {
        //            ComprobantePago = await ReadEntidad(dr);
        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }

        //    return ComprobantePago;
        //}

        //public async Task<ComprobantePago> BuscarPorPresupuestoID(int presupuestoID)
        //{
        //    var cmd = (SqlCommand)null;
        //    var ComprobantePago = (ComprobantePago)null;
        //    try
        //    {
        //        cmd = new SqlCommand("spComprobantePagoBuscarPorPresupuestoID", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(CreateParams.Int("PresupuestoID", presupuestoID));

        //        SqlDataReader dr = await cmd.ExecuteReaderAsync();
        //        while (await dr.ReadAsync())
        //        {
        //            ComprobantePago = await ReadEntidad(dr);
        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }

        //    return ComprobantePago;
        //}

        //public async Task<List<ComprobantePago>> BusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? ComprobantePagoEstadoId)
        //{
        //    var cmd = (SqlCommand)null;
        //    var listaComprobantePagos = new List<ComprobantePago>();
        //    try
        //    {
        //        cmd = new SqlCommand("spComprobantePagoBusquedaGeneral", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(CreateParams.Date("FechaDesde", fechaDesde));
        //        cmd.Parameters.Add(CreateParams.Date("FechaHasta", fechaHasta.Date.AddDays(1)));
        //        cmd.Parameters.Add(CreateParams.Int("ClienteID", clienteID));
        //        cmd.Parameters.Add(CreateParams.Int("ProyectoID", proyectoID));
        //        cmd.Parameters.Add(CreateParams.TinyInt("ComprobantePagoEstadoId", ComprobantePagoEstadoId));

        //        SqlDataReader dr = await cmd.ExecuteReaderAsync();
        //        while (await dr.ReadAsync())
        //        {
        //            var ComprobantePago = await ReadEntidad(dr);
        //            listaComprobantePagos.Add(ComprobantePago);
        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }

        //    return listaComprobantePagos;
        //}

        //private async Task<ComprobantePago> ReadEntidad(SqlDataReader dr)
        //{
        //    try
        //    {
        //        var obj = new ComprobantePago();
        //        obj.ComprobantePagoID = Convert.ToInt32(dr["ComprobantePagoID"]);
        //        obj.CreacionUsuarioID = Convert.ToInt32(dr["CreacionUsuarioID"]);
        //        obj.CreacionFecha = Convert.ToDateTime(dr["CreacionFecha"]);
        //        obj.PresupuestoID = Convert.ToInt32(dr["PresupuestoID"]);
        //        obj.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
        //        obj.FechaEstimadaEntrega = Convert.ToDateTime(dr["FechaEstimadaEntrega"]);
        //        obj.ComprobantePagoEstadoId = Convert.ToByte(dr["ComprobantePagoEstadoId"]);

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
