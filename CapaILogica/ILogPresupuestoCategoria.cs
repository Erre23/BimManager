using CapaEntidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CapaILogica
{
    [ServiceContract]
    public interface ILogPresupuestoCategoria
    {
        [OperationContract]
        Task PresupuestoCategoriaActualizar(PresupuestoCategoria presupuestoCategoria);

        [OperationContract]
        Task<PresupuestoCategoria> PresupuestoCategoriaBuscarPorPresupuestoCategoriaID(short PresupuestoCategoriaID);

        [OperationContract]
        Task<List<PresupuestoCategoria>> PresupuestoCategoriaBuscarTodos();

        [OperationContract]
        Task<short> PresupuestoCategoriaInsertar(PresupuestoCategoria presupuestoCategoria);
    }
}