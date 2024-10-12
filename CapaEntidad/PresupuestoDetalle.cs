using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
	public class PresupuestoDetalle
	{
		public bool Seleccionar { get; set; }
		public int PresupuestoDetalleID { get; set; }
		public int PresupuestoID { get; set; }
		public Presupuesto Presupuesto { get; set; }
		public short PresupuestoCategoriaID { get; set; }
		public PresupuestoCategoria PresupuestoCategoria { get; set; }
		public byte Orden { get; set; }
		public decimal? Porcentaje { get; set; }
		public decimal Importe { get; set; }
	}
}
