using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoDepartamento
    {
        #region sigleton
        private static readonly DaoDepartamento _instancia = new DaoDepartamento();
        public static DaoDepartamento Instancia { get { return _instancia; } }
        #endregion singleton

        #region métodos

        public async Task<Departamento> BuscarPorDepartamentoID(short departamentoID)
        {
            var cmd = (SqlCommand)null;
            var Departamento = (Departamento)null;
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDepartamentoBuscarPorDepartamentoID", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("DepartamentoID", departamentoID));
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Departamento = ReadEntidad(dr);
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

            return Departamento;
        }

        public async Task<List<Departamento>> BuscarTodos()
        {
            var cmd = (SqlCommand)null;
            var listaDepartamentos = new List<Departamento>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDepartamentoBuscarTodos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Departamento = ReadEntidad(dr);
                    listaDepartamentos.Add(Departamento);
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

            return listaDepartamentos;
        }

        private Departamento ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new Departamento();
                obj.DepartamentoID = Convert.ToInt16(dr["DepartamentoID"]);
                obj.Nombre = Convert.ToString(dr["Nombre"]);

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
