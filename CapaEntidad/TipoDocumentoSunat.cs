using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class TipoDocumentoSunat
	{
        [DataMember]
        public byte TipoDocumentoSunatID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string CodigoSunat { get; set; }

        [DataMember]
        public bool Activo { get; set; } = true;

        [DataMember(EmitDefaultValue = false)]
        public List<Serie> Series { get; set; }
    }
}
