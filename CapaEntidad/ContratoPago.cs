using System;
using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class ContratoPago
    {
        [DataMember]
        public int ContratoPagoID { get; set; }

        [DataMember]
        public int ContratoID { get; set; }

        [DataMember]
        public int CreacionUsuarioID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Usuario CreacionUsuario { get; set; }

        [DataMember]
        public DateTime CreacionFecha { get; set; }

        [DataMember]
        public int CuentaBancariaID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public CuentaBancaria CuentaBancaria { get; set; }

        [DataMember]
        public string NumeroOperacion { get; set; }

        [DataMember]
        public DateTime PagoFecha { get; set; }

        [DataMember]
        public decimal Importe { get; set; }

        [DataMember]
        public int ComprobantePagoId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ComprobantePago ComprobantePago { get; set; }

        [DataMember]
        public bool Anulado { get; set; }

        [DataMember]
        public int? AnulacionUsuarioID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Usuario AnulacionUsuario { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime AnulacionFecha { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AnulacionMotivo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? AnulacionComprobantePagoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ComprobantePago AnulacionComprobantePago { get; set; }
    }
}
