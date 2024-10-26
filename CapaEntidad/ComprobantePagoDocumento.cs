using System;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class ComprobantePagoDocumento
    {
        [DataMember]
        public int ComprobantePagoID { get; set; }

        [DataMember]
        public string DigestValue { get; set; }
        
        [DataMember]
        public string DocumentoXML { get; set; }

        [IgnoreDataMember]
        public byte[] DocumentoXML_En_ArrayByte { get { return Convert.FromBase64String(DocumentoXML); } }

        [DataMember]
        public string CDRXML { get; set; }

        [IgnoreDataMember]
        public byte[] CDRXML_En_ArrayByte { get { return Convert.FromBase64String(CDRXML); } }
    }
}
