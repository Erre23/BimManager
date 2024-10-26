using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class Provincia
    {
        [DataMember]
        public short ProvinciaID { get; set; }
        
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public short DepartamentoID { get; set; }

        [DataMember]
        public string CodigoUbigeoSunat { get; set; }

        [DataMember]
        public string CodigoUbigeoReniec { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember]
        public List<Distrito> Distritos { get; set; } = new List<Distrito>();

        [DataMember(EmitDefaultValue = false)]
        public Departamento Departamento { get; set; }
    }
}
