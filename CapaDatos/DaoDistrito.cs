using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoDistrito
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoDistrito(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoDistrito(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<Distrito> BuscarPorDistritoID(short distritoID)
        {
            var cmd = (SqlCommand)null;
            var Distrito = (Distrito)null;
            try
            {
                cmd = new SqlCommand("spDistritoBuscarPorDistritoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("DistritoID", distritoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Distrito = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Distrito;
        }

        public async Task<List<Distrito>> BuscarPorProvincia(short provinciaID)
        {
            var cmd = (SqlCommand)null;
            var listaDistritos = new List<Distrito>();
            try
            {
                cmd = new SqlCommand("spDistritoBuscarPorProvinciaID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ProvinciaID", provinciaID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var distrito = ReadEntidad(dr);
                    listaDistritos.Add(distrito);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaDistritos;
        }

        public async Task<List<Distrito>> BuscarTodos()
        {
            var cmd = (SqlCommand)null;
            var listaDistritos = new List<Distrito>();
            try
            {
                cmd = new SqlCommand("spDistritoBuscarTodos", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Distrito = ReadEntidad(dr);
                    listaDistritos.Add(Distrito);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaDistritos;
        }

        private Distrito ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new Distrito();
                obj.DistritoID = Convert.ToInt16(dr["DistritoID"]);
                obj.Nombre = Convert.ToString(dr["Nombre"]);
                obj.ProvinciaID = Convert.ToInt16(dr["ProvinciaID"]);                

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
