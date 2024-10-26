using System.Runtime.Serialization;

namespace BimManager.Entidad
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
