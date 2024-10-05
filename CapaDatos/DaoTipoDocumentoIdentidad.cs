using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoTipoDocumentoIdentidad
    {
        #region sigleton
        private static readonly DaoTipoDocumentoIdentidad _instancia = new DaoTipoDocumentoIdentidad();        
        public static DaoTipoDocumentoIdentidad Instancia { get { return _instancia; } }
        #endregion singleton


        #region metodos    
        public async Task<short> Insertar(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            var cmd = (SqlCommand)null;
            SqlConnection cnn = Conexion.Instancia.Conectar();
            await cnn.OpenAsync();
            using (var tran = cnn.BeginTransaction())
            {
                try
                {
                    cmd = new SqlCommand("spTipoDocumentoIdentidadInsertar", cnn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParams.NVarchar("Nombre", tipoDocumentoIdentidad.Nombre, 50));
                    cmd.Parameters.Add(CreateParams.Bit("LongitudExacta", tipoDocumentoIdentidad.LongitudExacta));
                    cmd.Parameters.Add(CreateParams.TinyInt("LongitudMinima", tipoDocumentoIdentidad.LongitudMinima));
                    cmd.Parameters.Add(CreateParams.TinyInt("LongitudMaxima", tipoDocumentoIdentidad.LongitudMaxima));
                    cmd.Parameters.Add(CreateParams.Bit("Alfanumerico", tipoDocumentoIdentidad.Alfanumerico));
                    cmd.Parameters.Add(CreateParams.Bit("PersonaJuridica", tipoDocumentoIdentidad.PersonaJuridica));
					cmd.Parameters.Add(CreateParams.Bit("ConsultaApi", tipoDocumentoIdentidad.ConsultaApi));

					tipoDocumentoIdentidad.TipoDocumentoIdentidadID = Convert.ToInt16(await cmd.ExecuteScalarAsync());

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

            return tipoDocumentoIdentidad.TipoDocumentoIdentidadID;
        }


        public async Task Actualizar(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            var cmd = (SqlCommand)null;
            SqlConnection cnn = Conexion.Instancia.Conectar();
            await cnn.OpenAsync();
            using (var tran = cnn.BeginTransaction())
            {
                try
                {
                    cmd = new SqlCommand("spTipoDocumentoIdentidadActualizar", cnn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParams.TinyInt("TipoDocumentoIdentidadID", tipoDocumentoIdentidad.TipoDocumentoIdentidadID));
                    cmd.Parameters.Add(CreateParams.NVarchar("Nombre", tipoDocumentoIdentidad.Nombre, 50));
                    cmd.Parameters.Add(CreateParams.Bit("LongitudExacta", tipoDocumentoIdentidad.LongitudExacta));
                    cmd.Parameters.Add(CreateParams.TinyInt("LongitudMinima", tipoDocumentoIdentidad.LongitudMinima));
                    cmd.Parameters.Add(CreateParams.TinyInt("LongitudMaxima", tipoDocumentoIdentidad.LongitudMaxima));
                    cmd.Parameters.Add(CreateParams.Bit("Alfanumerico", tipoDocumentoIdentidad.Alfanumerico));
                    cmd.Parameters.Add(CreateParams.Bit("PersonaJuridica", tipoDocumentoIdentidad.PersonaJuridica));
					cmd.Parameters.Add(CreateParams.Bit("ConsultaApi", tipoDocumentoIdentidad.ConsultaApi));

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


        public async Task Deshabilitar(int idTipoDocumentoIdentidad)
        {
            var cmd = (SqlCommand)null;
            SqlConnection cnn = Conexion.Instancia.Conectar();
            await cnn.OpenAsync();
            using (var tran = cnn.BeginTransaction())
            {
                try
                {
                    cmd = new SqlCommand("spTipoDocumentoIdentidadDeshabilitar", cnn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParams.Int("TipoDocumentoIdentidadID", idTipoDocumentoIdentidad));

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

        public async Task<List<TipoDocumentoIdentidad>> ListarActivos()
        {
            var cmd = (SqlCommand)null;
            var objLista = new List<TipoDocumentoIdentidad>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spTipoDocumentoIdentidadListarActivos", cnn);
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

        public async Task<List<TipoDocumentoIdentidad>> ListarTodos()
        {
            var cmd = (SqlCommand)null;
            var objLista = new List<TipoDocumentoIdentidad>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spTipoDocumentoIdentidadListarTodos", cnn);
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

        private TipoDocumentoIdentidad ReadEntidad(SqlDataReader dr)
        {
            try
            {

                var obj = new TipoDocumentoIdentidad();
                obj.TipoDocumentoIdentidadID = Convert.ToInt16(dr["TipoDocumentoIdentidadID"]);
                obj.Nombre = dr["Nombre"].ToString();
                obj.LongitudExacta = Convert.ToBoolean(dr["LongitudExacta"]);
                obj.LongitudMaxima = Convert.ToInt16(dr["LongitudMaxima"]);
                obj.LongitudMinima = Convert.ToInt16(dr["LongitudMinima"]);
                obj.Alfanumerico = Convert.ToBoolean(dr["Alfanumerico"]);
                obj.PersonaJuridica = Convert.ToBoolean(dr["PersonaJuridica"]);
				obj.ConsultaApi = Convert.ToBoolean(dr["ConsultaApi"]);
				obj.Activo = Convert.ToBoolean(dr["Activo"]);

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
