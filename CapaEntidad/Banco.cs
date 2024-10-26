using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class Banco
    {
        [DataMember]
        public byte BancoID { get; set; }

        [DataMember]
        public string Nombre { get; set; }
    }
}
