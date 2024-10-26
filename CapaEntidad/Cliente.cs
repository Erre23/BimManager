using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int ClienteID { get; set; }

        [DataMember]
        public short TipoDocumentoIdentidadID { get; set; }

        [DataMember]
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }

        [DataMember]
        public string DocumentoIdentidadNumero { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public string Nombres { get; set; }

        [DataMember]
        public string Apellido1 { get; set; }

        [DataMember]
        public string Apellido2 { get; set; }

        [DataMember]
        public string Celular { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public bool Activo { get; set; } = true;

        [DataMember(EmitDefaultValue = false)]
        public List<Proyecto> Proyectos { get; set; }

        public string TipoDocumentoIdentidad_RazonSocialOrApellidosYNombres
        {
            get
            {
                return TipoDocumentoIdentidad.Nombre + ": " + DocumentoIdentidadNumero + " - " + RazonSocialOrApellidosYNombres;
            }
        }

        public string RazonSocialOrApellidosYNombres
        {
            get 
            {
                string razonSocialOrApellidosYNombres = "";

                if (!string.IsNullOrEmpty(RazonSocial))
                {
                    razonSocialOrApellidosYNombres = RazonSocial;
                }
                else
                {
                    razonSocialOrApellidosYNombres = Apellido1;
                    razonSocialOrApellidosYNombres += string.IsNullOrEmpty(Apellido2) ? "" : " " + Apellido2;
                    razonSocialOrApellidosYNombres += string.IsNullOrEmpty(Nombres) ? "" : " " + Nombres;
                }

                return razonSocialOrApellidosYNombres;
            }
        }

        public static bool RUCValido(string ruc)
        {
            // Verifica que tenga 11 caracteres
            if (ruc.Length != 11 || !long.TryParse(ruc, out _))
                return false;

            // Verifica el primer dígito
            int tipoContribuyente = int.Parse(ruc.Substring(0, 1));
            if (tipoContribuyente < 1 || tipoContribuyente > 2)
                return false;

            // Cálculo del dígito verificador
            int[] factores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 }; // Arreglo correcto
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += int.Parse(ruc[i].ToString()) * factores[i];
            }

            int mod = suma % 11;
            int digitoVerificador = (mod == 0) ? 0 : (11 - mod);

            // Ajuste para asegurarse de que el dígito verificador sea un solo dígito
            if (digitoVerificador == 10 || digitoVerificador == 11)
                digitoVerificador = 0;

            // Compara el dígito verificador con el último dígito del RUC
            return digitoVerificador == int.Parse(ruc[10].ToString());
        }
    }
}
