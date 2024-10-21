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
        Task PresupuestoAnular(Presupuesto presupuesto);

        [OperationContract]
        Task<Presupuesto> PresupuestoBuscarPorPresupuestoID(int presupuestoID);

        [OperationContract]
        Task<List<Presupuesto>> PresupuestoBusquedaGeneral(DateTime fechaDesde, DateTime fechaHasta, int? clienteID, int? proyectoID, byte estado);

        [OperationContract]
        Task<List<PresupuestoDetalle>> PresupuestoDetalleBuscarPorPresupuestoID(int presupuestoID);

        [OperationContract]
        Task<Presupuesto> PresupuestoInsertar(Presupuesto presupuesto);
    }
}