using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class TipoDocumentoSunat
	{
        [DataMember]
        public short TipoDocumentoSunatID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string CodigoSunat { get; set; }

        [DataMember]
        public bool Activo { get; set; } = true;
    }
}
