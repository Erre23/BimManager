using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class Departamento
    {
        [DataMember]
        public short DepartamentoID { get; set; }
        
        [DataMember]
        public string Nombre { get; set; }
        
        [DataMember]
        public string CodigoUbigeoSunat { get; set; }
        
        [DataMember]
        public string CodigoUbigeoReniec { get; set; }
        
        [DataMember]
        public bool Activo { get; set; }
        
        [DataMember]
        public List<Provincia> Provincias { get; set; } = new List<Provincia>();
    }
}
