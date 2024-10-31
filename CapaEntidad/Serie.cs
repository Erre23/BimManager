using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BimManager.Entidad
{
    [DataContract]
    public class Serie
    {
        [DataMember]
        public byte SerieID { get; set; }

        [DataMember]
        public byte TipoDocumentoSunatID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public TipoDocumentoSunat TipoDocumentoSunat { get; set; }

        [DataMember]
        public string SerieNumero { get; set; }

        [DataMember]
        public int UltimoCorrelativo { get; set; }

        [DataMember]
        public bool Activo { get; set; }
    }
}
