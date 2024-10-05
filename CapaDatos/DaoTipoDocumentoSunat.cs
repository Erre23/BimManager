using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoTipoDocumentoSunat
    {
        #region sigleton
        private static readonly DaoTipoDocumentoSunat _instancia = new DaoTipoDocumentoSunat();        
        public static DaoTipoDocumentoSunat Instancia { get { return _instancia; } }
        #endregion singleton


        #region metodos    
        public async Task<short> Insertar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            var cmd = (SqlCommand)null;
            SqlConnection cnn = Conexion.Instancia.Conectar();
            await cnn.OpenAsync();
            using (var tran = cnn.BeginTransaction())
            {
                try
                {
                    cmd = new SqlCommand("spTipoDocumentoSunatInsertar", cnn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParams.NVarchar("Nombre", tipoDocumentoSunat.Nombre, 50));
                    cmd.Parameters.Add(CreateParams.NVarchar("CodigoSunat", tipoDocumentoSunat.CodigoSunat, 3));

                    tipoDocumentoSunat.TipoDocumentoSunatID = Convert.ToInt16(await cmd.ExecuteScalarAsync());

                    tran.Commit();
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    cmd.Connection.Close();
                    cmd.Dispose();
                    throw e;
                }
            }

            return tipoDocumentoSunat.TipoDocumentoSunatID;
        }


        public async Task Actualizar(TipoDocumentoSunat tipoDocumentoSunat)
        {
            var cmd = (SqlCommand)null;
            SqlConnection cnn = Conexion.Instancia.Conectar();
            await cnn.OpenAsync();
            using (var tran = cnn.BeginTransaction())
            {
                try
                {
                    cmd = new SqlCommand("spTipoDocumentoSunatActualizar", cnn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParams.TinyInt("TipoDocumentoSunatID", tipoDocumentoSunat.TipoDocumentoSunatID));
					cmd.Parameters.Add(CreateParams.NVarchar("Nombre", tipoDocumentoSunat.Nombre, 50));
					cmd.Parameters.Add(CreateParams.NVarchar("CodigoSunat", tipoDocumentoSunat.CodigoSunat, 3));

					cmd.ExecuteNonQuery();

                    tran.Commit();
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    cmd.Connection.Close();
                    cmd.Dispose();
                    throw e;
                }
            }
        }


        public async Task Deshabilitar(int idTipoDocumentoSunat)
        {
            var cmd = (SqlCommand)null;
            SqlConnection cnn = Conexion.Instancia.Conectar();
            await cnn.OpenAsync();
            using (var tran = cnn.BeginTransaction())
            {
                try
                {
                    cmd = new SqlCommand("spTipoDocumentoSunatDeshabilitar", cnn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParams.Int("TipoDocumentoSunatID", idTipoDocumentoSunat));

                    cmd.ExecuteNonQuery();

                    tran.Commit();
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    cmd.Connection.Close();
                    cmd.Dispose();
                    throw e;
                }
            }
        }

        public async Task<List<TipoDocumentoSunat>> ListarActivos()
        {
            var cmd = (SqlCommand)null;
            var objLista = new List<TipoDocumentoSunat>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spTipoDocumentoSunatListarActivos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var obj = ReadEntidad(dr);
                    objLista.Add(obj);
                }
                dr.Close();

                cmd.Connection.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
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
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spTipoDocumentoSunatListarTodos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                await cnn.OpenAsync();

                SqlDataReader dr = cmd.ExecuteReader();
                while (await dr.ReadAsync())
                {
                    var obj = ReadEntidad(dr);
                    objLista.Add(obj);
                }
                dr.Close();

                cmd.Connection.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
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
                obj.TipoDocumentoSunatID = Convert.ToInt16(dr["TipoDocumentoSunatID"]);
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
