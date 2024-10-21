using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public  class Proyecto
	{
        [DataMember]
        public int ProyectoID { get; set; }

        [DataMember]
        public int ClienteID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Cliente Cliente { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string DireccionReferencia { get; set; }

        [DataMember]
        public short DireccionDistritoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Distrito DireccionDistrito { get; set; }

        [DataMember]
        public short DireccionProvinciaID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Provincia DireccionProvincia { get; set; }

        [DataMember]
        public short DireccionDepartamentoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Departamento DireccionDepartamento { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        public string DireccionCompleta
		{
			get
			{
				var direccionCompleta = this.Direccion ?? "";
				direccionCompleta += (string.IsNullOrEmpty(this.DireccionReferencia) ? "" : $", Ref: {this.DireccionReferencia}");
				direccionCompleta += $" - {this.DireccionDistrito?.Nombre ?? ""}";
                direccionCompleta += $" - {this.DireccionProvincia?.Nombre ?? ""}";
                direccionCompleta += $" - {this.DireccionDepartamento?.Nombre ?? ""}";

                return direccionCompleta;
			}
		}
	}
}
