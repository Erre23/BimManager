using System.Collections.Generic;

namespace CapaEntidad
{
    public class Departamento
    {
        public short DepartamentoID { get; set; }
        public string Nombre { get; set; }
        public string CodigoUbigeoSunat { get; set; }
		public string CodigoUbigeoReniec { get; set; }
        public bool Activo { get; set; }
		public List<Provincia> Provincias { get; set; } = new List<Provincia>();
    }
}
