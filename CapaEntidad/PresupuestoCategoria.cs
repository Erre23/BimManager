using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
	public class PresupuestoCategoria
	{
		public short PresupuestoCategoriaID { get; set; }
		public string Nombre { get; set; }
		public string Observaciones { get; set; }
		public short? PadrePresupuestoCategoriaID { get; set; }
		public PresupuestoCategoria PadrePresupuestoCategoria { get; set; }
		public List<PresupuestoCategoria> SubPresupuestoCategorias { get; set; } = new List<PresupuestoCategoria>();
	}
}
