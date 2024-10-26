using System.Runtime.Serialization;

namespace BimManager.Entidad
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
