using BimManager.Entidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoComprobantePagoDocumento
	{
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoComprobantePagoDocumento(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoComprobantePagoDocumento(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task Insertar(ComprobantePagoDocumento comprobantePagoDocumento)
        {
            var cmd = (SqlCommand)null;
            
            try
            {
                cmd = new SqlCommand("spComprobantePagoDocumentoInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("ComprobantePagoID", comprobantePagoDocumento.ComprobantePagoID));
                cmd.Parameters.Add(CreateParams.NVarchar("DigestValue", comprobantePagoDocumento.DigestValue, -1));
                cmd.Parameters.Add(CreateParams.NVarchar("DocumentoXML", comprobantePagoDocumento.DocumentoXML, -1));
                cmd.Parameters.Add(CreateParams.NVarchar("CDRXML", comprobantePagoDocumento.CDRXML, -1));

                await cmd.ExecuteNonQueryAsync();

                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }

        public async Task ActualizarCDRPorComprobantePagoId(int comprobantePagoID, string cdrXML)
        {
            var cmd = (SqlCommand)null;

            try
            {
                cmd = new SqlCommand("spComprobantePagoDocumentoActualizarCDRPorComprobantePagoId", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("ComprobantePagoID", comprobantePagoID));
                cmd.Parameters.Add(CreateParams.NVarchar("CDRXML", cdrXML, -1));

                await cmd.ExecuteNonQueryAsync();

                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }


        //public async Task ActualizarEstado(ComprobantePagoDocumento ComprobantePagoDocumento)
        //{
        //    var cmd = (SqlCommand)null;

        //    try
        //    {
        //        cmd = new SqlCommand("spComprobantePagoDocumentoActualizarEstado", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(CreateParams.TinyInt("ComprobantePagoDocumentoEstadoId", ComprobantePagoDocumento.ComprobantePagoDocumentoEstadoId));
        //        cmd.Parameters.Add(CreateParams.Int("UltActEstadoUsuarioID", ComprobantePagoDocumento.UltActEstadoUsuarioID));
        //        cmd.Parameters.Add(CreateParams.DateTime("UltActEstadoFecha", ComprobantePagoDocumento.UltActEstadoFecha));
        //        cmd.Parameters.Add(CreateParams.NVarchar("UltActEstadoComentario", ComprobantePagoDocumento.UltActEstadoComentario, -1));
        //        cmd.Parameters.Add(CreateParams.Int("ComprobantePagoDocumentoID", ComprobantePagoDocumento.ComprobantePagoDocumentoID));

        //        ComprobantePagoDocumento.ComprobantePagoDocumentoID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }
        //}

        public async Task<ComprobantePagoDocumento> BuscarPorComprobantePagoID(int ComprobantePagoID)
        {
            var cmd = (SqlCommand)null;
            var ComprobantePagoDocumento = (ComprobantePagoDocumento)null;
            try
            {
                cmd = new SqlCommand("spComprobantePagoDocumentoBuscarPorComprobantePagoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ComprobantePagoID", ComprobantePagoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    ComprobantePagoDocumento = await ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return ComprobantePagoDocumento;
        }

        //public async Task<ComprobantePagoDocumento> BuscarPorPresupuestoID(int presupuestoID)
        //{
        //    var cmd = (SqlCommand)null;
        //    var ComprobantePagoDocumento = (ComprobantePagoDocumento)null;
        //    try
        //    {
        //        cmd = new SqlCommand("spComprobantePagoDocumentoBuscarPorPresupuestoID", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(CreateParams.Int("PresupuestoID", presupuestoID));

        //        SqlDataReader dr = await cmd.ExecuteReaderAsync();
        //        while (await dr.ReadAsync())
        //        {
        //            ComprobantePagoDocumento = await ReadEntidad(dr);
        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }

        //    return ComprobantePagoDocumento;
        //}

        //public async Task<List<ComprobantePagoDocumento>> BusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? ComprobantePagoDocumentoEstadoId)
        //{
        //    var cmd = (SqlCommand)null;
        //    var listaComprobantePagoDocumentos = new List<ComprobantePagoDocumento>();
        //    try
        //    {
        //        cmd = new SqlCommand("spComprobantePagoDocumentoBusquedaGeneral", cnn, tran);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(CreateParams.Date("FechaDesde", fechaDesde));
        //        cmd.Parameters.Add(CreateParams.Date("FechaHasta", fechaHasta.Date.AddDays(1)));
        //        cmd.Parameters.Add(CreateParams.Int("ClienteID", clienteID));
        //        cmd.Parameters.Add(CreateParams.Int("ProyectoID", proyectoID));
        //        cmd.Parameters.Add(CreateParams.TinyInt("ComprobantePagoDocumentoEstadoId", ComprobantePagoDocumentoEstadoId));

        //        SqlDataReader dr = await cmd.ExecuteReaderAsync();
        //        while (await dr.ReadAsync())
        //        {
        //            var ComprobantePagoDocumento = await ReadEntidad(dr);
        //            listaComprobantePagoDocumentos.Add(ComprobantePagoDocumento);
        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        cmd.Dispose();
        //        throw e;
        //    }

        //    return listaComprobantePagoDocumentos;
        //}

        private async Task<ComprobantePagoDocumento> ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new ComprobantePagoDocumento();
                obj.ComprobantePagoID = Convert.ToInt32(dr["ComprobantePagoID"]);
                obj.DocumentoXML = Convert.ToString(dr["DocumentoXML"]);
                if (!(await dr.IsDBNullAsync(dr.GetOrdinal("CDRXML")))) obj.CDRXML = Convert.ToString(dr["CDRXML"]);

                return obj;
            }
            catch (Exception ex)
            {
                dr.Close();
                throw ex;
            }
        }
        #endregion métodos
    }
}
