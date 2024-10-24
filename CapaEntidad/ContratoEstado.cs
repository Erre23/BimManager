using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class ContratoEstado
	{
        [DataMember]
        public byte ContratoEstadoID { get; set; }
        
        [DataMember]
        public string Nombre { get; set; }
        
        [DataMember]
        public bool Activo { get; set; }
    }
}
