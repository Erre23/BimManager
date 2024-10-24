using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class Contrato
	{
        [DataMember]
        public int ContratoID { get; set; }

        [DataMember]
        public int CreacionUsuarioID { get; set; }

        [DataMember]
        public Usuario CreacionUsuario { get; set; }

        [DataMember]
        public DateTime CreacionFecha { get; set; }

        [DataMember]
        public int PresupuestoID { get; set; }

        [DataMember]
        public Presupuesto Presupuesto { get; set; }

        [DataMember]
        public byte ContratoEstadoId { get; set; }

        [DataMember]
        public ContratoEstado ContratoEstado { get; set; }

        [DataMember]
        public DateTime FechaInicio { get; set; }

        [DataMember]
        public DateTime FechaCulminacionEstimada { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? CulminacionUsuarioID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Usuario CulminacionUsuario { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime CulminacionFecha { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int AnulacionUsuarioID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Usuario AnulacionUsuario { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime AnulacionFecha { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AnlacionMotivo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<ContratoComprobante> ContratoComprobantes { get; set; }
    }
}
