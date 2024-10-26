using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class Distrito
    {
        [DataMember]
        public short DistritoID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public short ProvinciaID { get; set; }

        [DataMember]
        public string CodigoUbigeoSunat { get; set; }

        [DataMember]
        public string CodigoUbigeoReniec { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Provincia Provincia { get; set; }
    }
}
