using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogPlan
    {
        #region sigleton
        private static readonly LogPlan _instancia = new LogPlan();
        public static LogPlan Instancia { get { return _instancia; } }
        #endregion singleton

        #region metodos

        public async Task<Plan> PlanBuscarPorPlanID(short PlanID)
        {
            return await DaoPlan.Instancia.BuscarPorPlanID(PlanID);
        }

        public async Task<List<Plan>> PlanListarActivos()
        {
            return await DaoPlan.Instancia.ListarActivos();
        }

        #endregion metodos
    }
}
