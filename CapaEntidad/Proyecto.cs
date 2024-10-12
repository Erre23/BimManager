using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
	public  class Proyecto
	{
		public int ProyectoID { get; set; }
		public int ClienteID { get; set; }
		public Cliente Cliente { get; set; }
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public string DireccionReferencia { get; set; }
		public short DireccionDistritoID { get; set; }
		public Distrito DireccionDistrito { get; set; }
		public short DireccionProvinciaID { get; set; }
		public Provincia DireccionProvincia { get; set; }
		public short DireccionDepartamentoID { get; set; }
		public Departamento DireccionDepartamento { get; set; }
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
