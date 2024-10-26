using BimManager.Entidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BimManager.ILogica
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