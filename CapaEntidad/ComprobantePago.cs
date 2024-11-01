using System;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class ComprobantePago
    {
        [DataMember]
        public int ComprobantePagoID { get; set; }

        [DataMember]
        public int ClienteID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Cliente Cliente { get; set; }

        [DataMember]
        public byte TipoDocumentoSunatID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public TipoDocumentoSunat TipoDocumentoSunat { get; set; }

        [DataMember]
        public string Serie { get; set; }

        [DataMember]
        public int Correlativo { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal SubTotal { get; set; }

        [DataMember]
        public decimal IGV { get; set; }

        [DataMember]
        public byte IGVPorcentaje { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember]
        public bool Enviado { get; set; }

        [DataMember]
        public string CDRCodigo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int AfectaComprobantePagoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ComprobantePago AfectaComprobantePago { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ComprobantePagoDocumento ComprobantePagoDocumento { get; set; }

        public string NombreDocumento_Formato_Sunat { get { return $"{Sunat.Entidad.Constantes.EmpresaDatos.RUC}-{TipoDocumentoSunat.CodigoSunat}-{Serie}-{Correlativo.ToString().PadLeft(8, '0')}"; } }

        public string SerieCorrelativo { get { return $"{Serie}-{Correlativo.ToString().PadLeft(8, '0')}"; } }
    }
}
