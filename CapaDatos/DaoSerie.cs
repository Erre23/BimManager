using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoSerie
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoSerie(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoSerie(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<int> GenerarCorrelativoPorTipoDocumentoSunatID(byte tipoDocumentoSunatID)
        {            
            var cmd = (SqlCommand)null;
            var correlativo = 0;
            try
            {
                cmd = new SqlCommand("spSerieGenerarCorrelativoPorTipoDocumentoSunatID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.TinyInt("TipoDocumentoSunatID", tipoDocumentoSunatID));

                correlativo = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return correlativo;
        }

        public async Task<List<Serie>> ListarActivosPorTipoDocumentoSunatID(byte tipoDocumentoSunatID)
        {
            var cmd = (SqlCommand)null;
            var listaSeries = new List<Serie>();
            try
            {
                cmd = new SqlCommand("spSerieListarActivosPorTipoDocumentoSunatID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.TinyInt("tipoDocumentoSunatID", tipoDocumentoSunatID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Serie = ReadEntidad(dr);
                    listaSeries.Add(Serie);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaSeries;
        }

        private Serie ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new Serie();
                obj.SerieID = Convert.ToByte(dr["SerieID"]);
                obj.TipoDocumentoSunatID = Convert.ToByte(dr["TipoDocumentoSunatID"]);
                obj.SerieNumero = Convert.ToString(dr["SerieNumero"]);
                obj.UltimoCorrelativo = Convert.ToInt16(dr["UltimoCorrelativo"]);
                obj.Activo = Convert.ToBoolean(dr["Activo"]);

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
