using CapaEntidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CapaILogica
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