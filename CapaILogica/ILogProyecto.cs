using BimManager.Entidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BimManager.ILogica
{
    [ServiceContract]
    public interface ILogProyecto
    {
        [OperationContract]
        Task ProyectoActualizar(Proyecto Proyecto);

        [OperationContract]
        Task<List<Proyecto>> ProyectoBuscarPorClienteID(int clienteID);

        [OperationContract]
        Task<Proyecto> ProyectoBuscarPorProyectoID(int proyectoID);

        [OperationContract]
        Task<List<Proyecto>> ProyectoBusquedaGeneral(int? clienteID, string nombre, short? distritoID, short? provinciaID, short? departamentoID);

        [OperationContract]
        Task ProyectoDeshabilitar(int idProyecto);

        [OperationContract]
        Task<int> ProyectoInsertar(Proyecto Proyecto);
    }
}