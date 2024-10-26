﻿using BimManager.Entidad;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BimManager.ILogica
{
    [ServiceContract]
    public interface ILogTipoDocumentoIdentidad
    {
        [OperationContract]
        Task TipoDocumentoIdentidadActualizar(TipoDocumentoIdentidad tipoDocumentoIdentidad);

        [OperationContract]
        Task TipoDocumentoIdentidadDeshabilitar(short idTipoDocumentoIdentidad);

        [OperationContract]
        Task<short> TipoDocumentoIdentidadInsertar(TipoDocumentoIdentidad tipoDocumentoIdentidad);

        [OperationContract]
        Task<List<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListarActivos();

        [OperationContract]
        Task<List<TipoDocumentoIdentidad>> TipoDocumentoIdentidadListarTodos();
    }
}