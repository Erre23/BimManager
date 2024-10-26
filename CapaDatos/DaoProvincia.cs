using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoProvincia
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoProvincia(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoProvincia(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<Provincia> BuscarPorProvinciaID(short provinciaID)
        {
            var cmd = (SqlCommand)null;
            var Provincia = (Provincia)null;
            try
            {
                cmd = new SqlCommand("spProvinciaBuscarPorProvinciaID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ProvinciaID", provinciaID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Provincia = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Provincia;
        }

        public async Task<List<Provincia>> BuscarPorDepartamento(short departamentoID)
        {
            var cmd = (SqlCommand)null;
            var listaProvincias = new List<Provincia>();
            try
            {
                cmd = new SqlCommand("spProvinciaBuscarPorDepartamentoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("DepartamentoID", departamentoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Provincia = ReadEntidad(dr);
                    listaProvincias.Add(Provincia);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaProvincias;
        }

        public async Task<List<Provincia>> BuscarTodos()
        {
            var cmd = (SqlCommand)null;
            var listaProvincias = new List<Provincia>();
            try
            {
                cmd = new SqlCommand("spProvinciaBuscarTodos", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Provincia = ReadEntidad(dr);
                    listaProvincias.Add(Provincia);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
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
