using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class PresupuestoCategoria
	{
		[DataMember]
		public short PresupuestoCategoriaID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Observaciones { get; set; }

        [DataMember]
        public decimal? Porcentaje { get; set; }

        [DataMember]
        public short? PadrePresupuestoCategoriaID { get; set; }

        public string TextoResumen
		{
			get 
			{
				string textoResumen = this.Nombre;
				if (this.Porcentaje != null) textoResumen += $" - ({this.Porcentaje.ToString()}%)";
                if (!string.IsNullOrEmpty(this.Observaciones)) textoResumen += $" - ({this.Observaciones})";
                return textoResumen; 
			}
		}

        [DataMember(EmitDefaultValue = false)]
        public PresupuestoCategoria PadrePresupuestoCategoria { get; set; }

        [DataMember]
        public List<PresupuestoCategoria> SubPresupuestoCategorias { get; set; } = new List<PresupuestoCategoria>();
	}
}
