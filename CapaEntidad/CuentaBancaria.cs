using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class CuentaBancaria
    {
        [DataMember]
        public short CuentaBancariaID { get; set; }

        [DataMember]
        public byte BancoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Banco Banco { get; set; }

        [DataMember]
        public byte CuentaBancariaTipoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public CuentaBancariaTipo CuentaBancariaTipo { get; set; }

        [DataMember]
        public byte MonedaTipoID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public MonedaTipo MonedaTipo { get; set; }

        [DataMember]
        public string CuentaNumero { get; set; }

        [DataMember]
        public string CCI { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        public string NumeroCuentaCompleto
        {
            get
            {
                string numereoCuentaCompleto = Banco?.Nombre ?? "";
                numereoCuentaCompleto += " - " + CuentaBancariaTipo?.Nombre ?? "";
                numereoCuentaCompleto += " - " + MonedaTipo?.Divisa ?? "";
                numereoCuentaCompleto += " - " + CuentaNumero ?? "";
                numereoCuentaCompleto += " (" + (Nombre ?? "") + ")";

                return numereoCuentaCompleto;
            }
        }

        public string CCICompleto
        {
            get
            {
                string numereoCuentaCompleto = Banco?.Nombre ?? "";
                numereoCuentaCompleto += " - " + CuentaBancariaTipo?.Nombre ?? "";
                numereoCuentaCompleto += " - " + MonedaTipo?.Divisa ?? "";
                numereoCuentaCompleto += " - " + CCI ?? "";
                numereoCuentaCompleto += " (" + (Nombre ?? "") + ")";

                return numereoCuentaCompleto;
            }
        }
    }
}
