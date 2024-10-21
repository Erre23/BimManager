using CapaDatos;
using CapaEntidad;
using CapaILogica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaLogica
{
    [Serializable]
    public class LogPlan : Conexion, ILogPlan
    {
        #region sigleton
        private static readonly LogPlan _instancia = new LogPlan();
        public static LogPlan Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

        public async Task<Plan> PlanBuscarPorPlanID(short PlanID)
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var plan = await new DaoPlan(cnn).BuscarPorPlanID(PlanID);
                Close(cnn);
                return plan;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        public async Task<List<Plan>> PlanListarActivos()
        {
            SqlConnection cnn = this.Conectar();
            try
            {
                await cnn.OpenAsync();
                var planes = await new DaoPlan(cnn).ListarActivos();
                Close(cnn);
                return planes;
            }
            catch (Exception ex)
            {
                Close(cnn);
                throw ex;
            }
        }

        #endregion metodos
    }
}
