using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoPresupuestoEstado
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoPresupuestoEstado(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoPresupuestoEstado(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<PresupuestoEstado> BuscarPorPresupuestoEstadoID(byte presupuestoEstadoID)
        {
            var cmd = (SqlCommand)null;
            var PresupuestoEstado = (PresupuestoEstado)null;
            try
            {
                cmd = new SqlCommand("spPresupuestoEstadoBuscarPorPresupuestoEstadoID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("PresupuestoEstadoID", presupuestoEstadoID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    PresupuestoEstado = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return PresupuestoEstado;
        }

        public async Task<List<PresupuestoEstado>> Listar()
        {
            var cmd = (SqlCommand)null;
            var listaPresupuestoEstados = new List<PresupuestoEstado>();
            try
            {
                cmd = new SqlCommand("spPresupuestoEstadoListar", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var PresupuestoEstado = ReadEntidad(dr);
                    listaPresupuestoEstados.Add(PresupuestoEstado);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaPresupuestoEstados;
        }

        private PresupuestoEstado ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new PresupuestoEstado();
                obj.PresupuestoEstadoID = Convert.ToByte(dr["PresupuestoEstadoID"]);
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
