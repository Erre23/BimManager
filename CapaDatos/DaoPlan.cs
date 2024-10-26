using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BimManager.Datos
{
    public class DaoPlan
    {
        private readonly SqlConnection cnn;
        private readonly SqlTransaction tran;

        public DaoPlan(SqlConnection _cnn)
        {
            cnn = _cnn;
        }

        public DaoPlan(SqlTransaction _tran)
        {
            tran = _tran;
            cnn = _tran.Connection;
        }

        #region métodos

        public async Task<Plan> BuscarPorPlanID(short PlanID)
        {
            var cmd = (SqlCommand)null;
            var Plan = (Plan)null;
            try
            {
                cmd = new SqlCommand("spPlanBuscarPorPlanID", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParams.Int("PlanID", PlanID));

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Plan = ReadEntidad(dr);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return Plan;
        }

        public async Task<List<Plan>> ListarActivos()
        {
            var cmd = (SqlCommand)null;
            var listaPlans = new List<Plan>();
            try
            {
                cmd = new SqlCommand("spPlanListarActivos", cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Plan = ReadEntidad(dr);
                    listaPlans.Add(Plan);
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                throw e;
            }

            return listaPlans;
        }

        private Plan ReadEntidad(SqlDataReader dr)
        {
            try
            {
                var obj = new Plan();
                obj.PlanID = Convert.ToByte(dr["PlanID"]);
                obj.Nombre = Convert.ToString(dr["Nombre"]);
                obj.CostoPorM2 = Convert.ToDecimal(dr["CostoPorM2"]);
				obj.PlazoDiasMinimo = Convert.ToByte(dr["PlazoDiasMinimo"]);
				obj.PlazoDiasMaximo = Convert.ToByte(dr["PlazoDiasMaximo"]);

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
