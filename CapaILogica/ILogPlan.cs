using CapaEntidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CapaILogica
{
    [ServiceContract]
    public interface ILogPlan
    {
        [OperationContract]
        Task<Plan> PlanBuscarPorPlanID(short PlanID);

        [OperationContract]
        Task<List<Plan>> PlanListarActivos();
    }
}