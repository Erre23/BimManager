using BimManager.Entidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BimManager.ILogica
{
    [ServiceContract]
    public interface ILogDepartamento
    {
        [OperationContract]
        Task<Departamento> DepartamentoBuscarPorDepartamentoID(short departamentoID);

        [OperationContract]
        Task<List<Departamento>> DepartamentoBuscarTodos();
    }
}