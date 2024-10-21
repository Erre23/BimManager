using System;
using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class PresupuestoDetalle
	{
        [DataMember(EmitDefaultValue = false)]
        public bool Seleccionar { get; set; }

        [DataMember]
        public int PresupuestoDetalleID { get; set; }

        [DataMember]
        public int PresupuestoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Presupuesto Presupuesto { get; set; }

        [DataMember]
        public short PresupuestoCategoriaID { get; set; }

        [DataMember]
        public PresupuestoCategoria PresupuestoCategoria { get; set; }

        [DataMember]
        public byte Orden { get; set; }

        [DataMember]
        public decimal? Porcentaje { get; set; }

        [DataMember]
        public decimal Importe { get; set; }
	}
}
