using BimManager.Entidad;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BimManager.ILogica
{
    [ServiceContract]
    public interface ILogContrato
    {
        [OperationContract]
        Task<ComprobantePagoDocumento> ComprobantePagoDocumentoBuscarPorComprobantePagoID(int comprobantePagoID);

        [OperationContract]
        Task<Contrato> ContratoAnular(Contrato Contrato);

        [OperationContract]
        Task<Contrato> ContratoBuscarPorContratoID(int ContratoID);

        [OperationContract]
        Task<Contrato> ContratoBuscarPorPresupuestoID(int presupuestoID);

        [OperationContract]
        Task<List<Contrato>> ContratoBusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? ContratoEstadoId);

        [OperationContract]
        Task<Contrato> ContratoInsertar(Contrato Contrato, ContratoPago contratoPago = null);

        [OperationContract]
        Task<List<ContratoPago>> ContratoPagoListarPorContratoID(int contratoID);

        [OperationContract]
        Task<ContratoEstado> ContratoEstadoBuscarPorContratoEstadoID(byte ContratoEstadoID);

        [OperationContract]
        Task<List<ContratoEstado>> ContratoEstadoListar();

        [OperationContract]
        Task<CuentaBancaria> CuentaBancariaBuscarPorCuentaBancariaID(short cuentaBancariaID);

        [OperationContract]
        Task<List<CuentaBancaria>> CuentaBancariaListarActivos();
    }
}