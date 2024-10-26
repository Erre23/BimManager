using BimManager.Entidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BimManager.ILogica
{
    [ServiceContract]
    public interface ILogCliente
    {
        [OperationContract]
        Task ClienteActualizar(Cliente cliente);
        
        [OperationContract]
        Task<Cliente> ClienteBuscarPorDocumentoIdentidad(short idTipoDocumentoIdentidad, string numeroDocumentoIdentidad, bool buscarProyectos = false, bool buscarEnAPI = false);

        [OperationContract]
        Task<Cliente> ClienteBuscarPorIdCliente(int idCliente);

        [OperationContract]
        Task<List<Cliente>> ClienteBusquedaGeneral(short? idTipoDocumentoIdentidad, string numeroDocumentoIdentidad, string razonSocial, string nombres, string apellido1, string apellido2);

        [OperationContract]
        Task<Cliente> ClienteConsultaApiPorDocumentoIdentidad(short idTipoDocumentoIdentidad, string numeroDocumentoIdentidad);

        [OperationContract]
        Task ClienteDeshabilitar(int idCliente);

        [OperationContract]
        Task<int> ClienteInsertar(Cliente cliente);
    }
}