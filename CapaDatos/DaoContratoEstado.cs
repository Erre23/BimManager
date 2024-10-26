using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoContratoEstado
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoContratoEstado(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoContratoEstado(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<ContratoEstado> BuscarPorContratoEstadoID(byte ContratoEstadoID)
        {
            var cmd = (SqlCommand)null;
            var ContratoEstado = (ContratoEstado)null;
            try
            {
                cmd = new SqlCommand("spContratoEstadoBuscarPorContratoEstadoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("ContratoEstadoID", ContratoEstadoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    ContratoEstado = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return ContratoEstado;
        }

        public async Task<List<ContratoEstado>> Listar()
        {
            var cmd = (SqlCommand)null;
            var listaContratoEstados = new List<ContratoEstado>();
            try
            {
                cmd = new SqlCommand("spContratoEstadoListar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var ContratoEstado = ReadEntidad(dr);
                    listaContratoEstados.Add(ContratoEstado);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaContratoEstados;
        }

        private ContratoEstado ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new ContratoEstado();
                obj.ContratoEstadoID = Convert.ToByte(dr["ContratoEstadoID"]);
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
