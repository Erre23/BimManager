using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoTipoDocumentoSunat
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoTipoDocumentoSunat(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoTipoDocumentoSunat(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }


        #region metodos    
        public async Task<byte> Insertar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            var cmd = (SqlCommand)null;
            try
            {
                cmd = new SqlCommand("spTipoDocumentoSunatInsertar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.NVarchar("Nombre", tipoDocumentoSunat.Nombre, 50));
                cmd.Parameters.Add(CreateParams.NVarchar("CodigoSunat", tipoDocumentoSunat.CodigoSunat, 3));

                tipoDocumentoSunat.TipoDocumentoSunatID = Convert.ToByte(await cmd.ExecuteScalarAsync());
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return tipoDocumentoSunat.TipoDocumentoSunatID;
        }


        public async Task Actualizar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            var cmd = (SqlCommand)null;
            try
            {
                cmd = new SqlCommand("spTipoDocumentoSunatActualizar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.TinyInt("TipoDocumentoSunatID", tipoDocumentoSunat.TipoDocumentoSunatID));
				cmd.Parameters.Add(CreateParams.NVarchar("Nombre", tipoDocumentoSunat.Nombre, 50));
				cmd.Parameters.Add(CreateParams.NVarchar("CodigoSunat", tipoDocumentoSunat.CodigoSunat, 3));

				await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }


        public async Task Deshabilitar(byte idTipoDocumentoSunat)
        {
            var cmd = (SqlCommand)null;
            try
            {
                cmd = new SqlCommand("spTipoDocumentoSunatDeshabilitar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.TinyInt("TipoDocumentoSunatID", idTipoDocumentoSunat));

                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }
        }

        public async Task<List<TipoDocumentoSunat>> ListarActivos()
        {
            var cmd = (SqlCommand)null;
            var objLista = new List<TipoDocumentoSunat>();
            try
            {
                cmd = new SqlCommand("spTipoDocumentoSunatListarActivos", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var obj = ReadEntidad(dr);
                    objLista.Add(obj);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return objLista;
        }

        public async Task<List<TipoDocumentoSunat>> ListarTodos()
        {
            var cmd = (SqlCommand)null;
            var objLista = new List<TipoDocumentoSunat>();
            try
            {
                cmd = new SqlCommand("spTipoDocumentoSunatListarTodos", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var obj = ReadEntidad(dr);
                    objLista.Add(obj);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return objLista;
        }

        private TipoDocumentoSunat ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new TipoDocumentoSunat();
                obj.TipoDocumentoSunatID = Convert.ToByte(dr["TipoDocumentoSunatID"]);
                obj.Nombre = dr["Nombre"].ToString();
                obj.CodigoSunat = dr["CodigoSunat"].ToString();

                return obj;

            }
            catch(Exception ex)
            {
                dr.Close();
                throw ex;
            }
        }
        #endregion metodos
    }
}
