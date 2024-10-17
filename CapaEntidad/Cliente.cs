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
        public List<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

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
