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
        public DateTime FechaInicio { get; set; }

        [DataMember]
        public DateTime FechaEstimadaEntrega { get; set; }

        [DataMember]
        public byte ContratoEstadoId { get; set; }

        [DataMember]
        public ContratoEstado ContratoEstado { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? UltActEstadoUsuarioID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Usuario UltActEstadoUsuario { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime UltActEstadoFecha { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string UltActEstadoComentario { get; set; }

        public string UltimoEstadoUsuario
        {
            get
            {
                if (ContratoEstadoId == 1) return this.CreacionUsuario?.ApellidosNombres;
                else return this.UltActEstadoUsuario?.ApellidosNombres;
            }
        }

        public string UltimoEstadoComentario
        {
            get
            {
                if (ContratoEstadoId == 1) return "";
                else return this.UltActEstadoComentario ?? "";
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public List<ContratoComprobante> ContratoComprobantes { get; set; }
    }
}
