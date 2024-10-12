using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DaoPlan
    {
        #region sigleton
        private static readonly DaoPlan _instancia = new DaoPlan();
        public static DaoPlan Instancia { get { return _instancia; } }
        #endregion singleton

        #region métodos

        public async Task<Plan> BuscarPorPlanID(short PlanID)
        {
            var cmd = (SqlCommand)null;
            var Plan = (Plan)null;
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spPlanBuscarPorPlanID", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(CreateParams.Int("PlanID", PlanID));
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Plan = ReadEntidad(dr);
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

            return Plan;
        }

        public async Task<List<Plan>> ListarActivos()
        {
            var cmd = (SqlCommand)null;
            var listaPlans = new List<Plan>();
            try
            {
                SqlConnection cnn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spPlanListarActivos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                await cnn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var Plan = ReadEntidad(dr);
                    listaPlans.Add(Plan);
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
