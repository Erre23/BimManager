using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Plan
    {
        public byte PlanID { get; set; }
        public string Nombre { get; set; }
        public decimal CostoPorM2 { get; set; }
		public byte PlazoDiasMinimo { get; set; }
		public byte PlazoDiasMaximo { get; set; }
		public bool Activo { get; set; }
		public string PlazoRango
        {
            get { return $"{PlazoDiasMinimo} - {PlazoDiasMaximo}"; }
        }
    }
}
