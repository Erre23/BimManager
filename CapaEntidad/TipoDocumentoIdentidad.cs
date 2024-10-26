using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class TipoDocumentoIdentidad
    {
        [DataMember]
        public short TipoDocumentoIdentidadID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool LongitudExacta { get; set; }

        [DataMember]
        public short LongitudMaxima { get; set; }

        [DataMember]
        public short LongitudMinima { get; set; }

        [DataMember]
        public bool Alfanumerico { get; set; }

        [DataMember]
        public bool PersonaJuridica { get; set; } = false;

        [DataMember]
        public bool ConsultaApi { get; set; } = false;

        [DataMember]
        public bool Activo { get; set; } = true;
    }
}
