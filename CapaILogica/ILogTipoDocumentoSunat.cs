using BimManager.Entidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BimManager.ILogica
{
    [ServiceContract]
    public interface ILogTipoDocumentoSunat
    {
        [OperationContract]
        Task TipoDocumentoSunatActualizar(TipoDocumentoSunat tipoDocumentoSunat);

        [OperationContract]
        Task TipoDocumentoSunatDeshabilitar(short idTipoDocumentoSunat);

        [OperationContract]
        Task<short> TipoDocumentoSunatInsertar(TipoDocumentoSunat tipoDocumentoSunat);

        [OperationContract]
        Task<List<TipoDocumentoSunat>> TipoDocumentoSunatListarActivos();

        [OperationContract]
        Task<List<TipoDocumentoSunat>> TipoDocumentoSunatListarTodos();
    }
}