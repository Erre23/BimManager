using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class ContratoComprobante
    {
        [DataMember]
        public int ContratoID { get; set; }
        
        [DataMember]
        public int ComprobantePagoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ComprobantePago ComprobantePago { get; set; }
    }
}
