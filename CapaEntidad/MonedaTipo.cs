using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class MonedaTipo
    {
        [DataMember]
        public byte MonedaTipoID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Divisa { get; set; }
    }
}
