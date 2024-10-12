using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
	public class Presupuesto
	{
		public int PresupuestoID { get; set; }
		public int CreacionUsuarioID { get; set; }
		public Usuario CreacionUsuario { get; set; }
		public DateTime CreacionFecha { get; set; }
		public int ClienteID { get; set; }
		public Cliente Cliente { get; set; }
		public int ProyectoID { get; set; }
		public Proyecto Proyecto { get; set; }
		public DateTime FechaExpiracion { get; set; }
		public int AnulacionUsuarioID { get; set; }
		public Usuario AnulacionUsuario { get; set; }
		public DateTime AnulacionFecha { get; set; }
		public string AnulacionMotivo { get; set; }
		public bool Activo { get; set; }
		public decimal AreaTotal { get; set; }
		public decimal AreaLibre { get; set; }
		public byte AreaLibrePorcentaje { get; set; }
		public decimal AreaTechada { get; set; }
		public byte NumeroPisos { get; set; }
		public byte PlanID { get; set; }
		public Plan Plan { get; set; }
		public decimal ImporteTotal { get; set; }
		List<PresupuestoDetalle> PresupuestoDetalles { get; set; }
    }
}
