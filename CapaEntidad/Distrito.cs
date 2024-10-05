using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Distrito
    {
        public short DistritoID { get; set; }
        public string Nombre { get; set; }
        public short ProvinciaID { get; set; }
		public string CodigoUbigeoSunat { get; set; }
		public string CodigoUbigeoReniec { get; set; }
		public bool Activo { get; set; }
		public Provincia Provincia { get; set; }
    }
}
