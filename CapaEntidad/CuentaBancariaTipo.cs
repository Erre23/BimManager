using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class CuentaBancariaTipo
    {
        [DataMember]
        public byte CuentaBancariaTipoID { get; set; }

        [DataMember]
        public string Nombre { get; set; }
    }
}
