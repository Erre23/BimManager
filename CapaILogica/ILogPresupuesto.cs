using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CapaILogica
{
    [ServiceContract]
    public interface ILogPresupuesto
    {
        [OperationContract]
        Task<Presupuesto> PresupuestoAnular(Presupuesto presupuesto);

        [OperationContract]
        Task<Presupuesto> PresupuestoBuscarPorPresupuestoID(int presupuestoID);

        [OperationContract]
        Task<List<Presupuesto>> PresupuestoBusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte? presupuestoEstadoId);

        [OperationContract]
        Task<List<PresupuestoDetalle>> PresupuestoDetalleBuscarPorPresupuestoID(int presupuestoID);

        [OperationContract]
        Task<Presupuesto> PresupuestoInsertar(Presupuesto presupuesto);

        [OperationContract]
        Task<PresupuestoEstado> PresupuestoEstadoBuscarPorPresupuestoEstadoID(byte presupuestoEstadoID);

        [OperationContract]
        Task<List<PresupuestoEstado>> PresupuestoEstadoListar();
    }
}