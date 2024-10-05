using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoProvincia
    {
        #region sigleton
        private static readonly DaoProvincia _instancia = new DaoProvincia();
        public static DaoProvincia Instancia { get { return _instancia; } }
        #endregion singleton

        #region métodos

        public async Task<Provincia> BuscarPorProvinciaID(short provinciaID)
        {
            var cmd = (SqlCommand)null;
            var Provincia = (Provincia)null;
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spProvinciaBuscarPorProvinciaID", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("ProvinciaID", provinciaID));
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Provincia = ReadEntidad(dr);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

            return Provincia;
        }

        public async Task<List<Provincia>> BuscarPorDepartamento(short departamentoID)
        {
            var cmd = (SqlCommand)null;
            var listaProvincias = new List<Provincia>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spProvinciaBuscarPorDepartamentoID", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("DepartamentoID", departamentoID));
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Provincia = ReadEntidad(dr);
                    listaProvincias.Add(Provincia);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

            return listaProvincias;
        }

        public async Task<List<Provincia>> BuscarTodos()
        {
            var cmd = (SqlCommand)null;
            var listaProvincias = new List<Provincia>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spProvinciaBuscarTodos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Provincia = ReadEntidad(dr);
                    listaProvincias.Add(Provincia);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

            return listaProvincias;
        }

        private Provincia ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new Provincia();
                obj.ProvinciaID = Convert.ToInt16(dr["ProvinciaID"]);
                obj.Nombre = Convert.ToString(dr["Nombre"]);
                obj.DepartamentoID = Convert.ToInt16(dr["DepartamentoID"]);                

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
