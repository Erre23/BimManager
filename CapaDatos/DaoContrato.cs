using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoContrato
	{
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoContrato(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoContrato(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<int> Insertar(Contrato Contrato)
        {
            var cmd = (SqlCommand)null;
            
            try
            {
                cmd = new SqlCommand("spContratoInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("CreacionUsuarioID", Contrato.CreacionUsuarioID));
                cmd.Parameters.Add(CreateParams.DateTime("CreacionFecha", Contrato.CreacionFecha));
                cmd.Parameters.Add(CreateParams.Int("PresupuestoID", Contrato.PresupuestoID));
                cmd.Parameters.Add(CreateParams.Date("FechaInicio", Contrato.FechaInicio));
                cmd.Parameters.Add(CreateParams.Date("FechaEstimadaEntrega", Contrato.FechaEstimadaEntrega));
                cmd.Parameters.Add(CreateParams.TinyInt("ContratoEstadoId", Contrato.ContratoEstadoId));

                Contrato.ContratoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Contrato.ContratoID;
        }


        public async Task ActualizarEstado(Contrato Contrato)
        {
            var cmd = (SqlCommand)null;

            try
            {
                cmd = new SqlCommand("spContratoActualizarEstado", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.TinyInt("ContratoEstadoId", Contrato.ContratoEstadoId));
                cmd.Parameters.Add(CreateParams.Int("UltActEstadoUsuarioID", Contrato.UltActEstadoUsuarioID));
                cmd.Parameters.Add(CreateParams.DateTime("UltActEstadoFecha", Contrato.UltActEstadoFecha));
                cmd.Parameters.Add(CreateParams.NVarchar("UltActEstadoComentario", Contrato.UltActEstadoComentario, -1));
                cmd.Parameters.Add(CreateParams.Int("ContratoID", Contrato.ContratoID));

                Contrato.ContratoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }

        public async Task<Contrato> BuscarPorContratoID(int ContratoID)
        {
            var cmd = (SqlCommand)null;
            var Contrato = (Contrato)null;
            try
            {
                cmd = new SqlCommand("spContratoBuscarPorContratoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ContratoID", ContratoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Contrato = await ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Contrato;
        }

        public async Task<Contrato> BuscarPorPresupuestoID(int presupuestoID)
        {
            var cmd = (SqlCommand)null;
            var Contrato = (Contrato)null;
            try
            {
                cmd = new SqlCommand("spContratoBuscarPorPresupuestoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("PresupuestoID", presupuestoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Contrato = await ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Contrato;
        }

        public async Task<List<Contrato>> BusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? ContratoEstadoId)
        {
            var cmd = (SqlCommand)null;
            var listaContratos = new List<Contrato>();
            try
            {
                cmd = new SqlCommand("spContratoBusquedaGeneral", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Date("FechaDesde", fechaDesde));
                cmd.Parameters.Add(CreateParams.Date("FechaHasta", fechaHasta.Date.AddDays(1)));
                cmd.Parameters.Add(CreateParams.Int("ClienteID", clienteID));
                cmd.Parameters.Add(CreateParams.Int("ProyectoID", proyectoID));
                cmd.Parameters.Add(CreateParams.TinyInt("ContratoEstadoId", ContratoEstadoId));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Contrato = await ReadEntidad(dr);
                    listaContratos.Add(Contrato);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaContratos;
        }

        private async Task<Contrato> ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new Contrato();
                obj.ContratoID = Convert.ToInt32(dr["ContratoID"]);
                obj.CreacionUsuarioID = Convert.ToInt32(dr["CreacionUsuarioID"]);
                obj.CreacionFecha = Convert.ToDateTime(dr["CreacionFecha"]);
                obj.PresupuestoID = Convert.ToInt32(dr["PresupuestoID"]);
                obj.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
                obj.FechaEstimadaEntrega = Convert.ToDateTime(dr["FechaEstimadaEntrega"]);
                obj.ContratoEstadoId = Convert.ToByte(dr["ContratoEstadoId"]);

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
