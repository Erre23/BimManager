using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class Presupuesto
	{
        [DataMember]
        public int PresupuestoID { get; set; }

        [DataMember]
        public int CreacionUsuarioID { get; set; }

        [DataMember]
        public Usuario CreacionUsuario { get; set; }

        [DataMember]
        public DateTime CreacionFecha { get; set; }

        [DataMember]
        public int ClienteID { get; set; }

        [DataMember]
        public Cliente Cliente { get; set; }

        [DataMember]
        public int ProyectoID { get; set; }

        [DataMember]
        public Proyecto Proyecto { get; set; }

        [DataMember]
        public DateTime FechaExpiracion { get; set; }

        [DataMember]
        public decimal AreaTotal { get; set; }

        [DataMember]
        public decimal AreaLibre { get; set; }

        [DataMember]
        public byte AreaLibrePorcentaje { get; set; }

        [DataMember]
        public decimal AreaTechada { get; set; }

        [DataMember]
        public byte NumeroPisos { get; set; }

        [DataMember]
        public byte PlanID { get; set; }

        [DataMember]
        public Plan Plan { get; set; }

        [DataMember]
        public decimal ImporteTotal { get; set; }

        [DataMember]
        public byte PresupuestoEstadoId { get; set; }

        [DataMember]
        public PresupuestoEstado PresupuestoEstado { get; set; }

        [DataMember]
        public int? UltActEstadoUsuarioID { get; set; }

        [DataMember]
        public Usuario UltActEstadoUsuario { get; set; }

        [DataMember]
        public DateTime? UltActEstadoFecha { get; set; }

        [DataMember]
        public string UltActEstadoComentario { get; set; }

        [DataMember]
        public List<PresupuestoDetalle> PresupuestoDetalles { get; set; }

        public string UltimoEstadoUsuario
        {
            get
            {
                if (PresupuestoEstadoId == 1) return this.CreacionUsuario?.ApellidosNombres;
                else return this.UltActEstadoUsuario?.ApellidosNombres;
            }
        }

        public string UltimoEstadoComentario
        {
            get
            {
                if (PresupuestoEstadoId == 1) return "";
                else return this.UltActEstadoComentario ?? "";
            }
        }
    }
}
