using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoDepartamento
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoDepartamento(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoDepartamento(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<Departamento> BuscarPorDepartamentoID(short departamentoID)
        {
            var cmd = (SqlCommand)null;
            var Departamento = (Departamento)null;
            try
            {
                cmd = new SqlCommand("spDepartamentoBuscarPorDepartamentoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("DepartamentoID", departamentoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Departamento = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Departamento;
        }

        public async Task<List<Departamento>> BuscarTodos()
        {
            var cmd = (SqlCommand)null;
            var listaDepartamentos = new List<Departamento>();
            try
            {
                cmd = new SqlCommand("spDepartamentoBuscarTodos", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Departamento = ReadEntidad(dr);
                    listaDepartamentos.Add(Departamento);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
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
