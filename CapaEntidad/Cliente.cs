using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public short TipoDocumentoIdentidadID { get; set; }
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }
        public string DocumentoIdentidadNumero { get; set; }
        public string RazonSocial { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; } = true;

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
            if (ruc.Length != 11 || !long.TryParse(ruc, out _))
                return false;

            int[] weights = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += (ruc[i] - '0') * weights[i];
            }

            int remainder = sum % 11;
            int expectedDigit = remainder == 0 ? 0 : 11 - remainder;

            return (ruc[10] - '0') == expectedDigit;
        }
    }
}
